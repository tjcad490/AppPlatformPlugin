using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppplatformCommon;
using AppPlatform.LoginService.BLL;
using AppPlatform.DAL;
using AppPlatform.IDAL;
using AppPlatform.Model.Models;
using AppPlatform.RegisterServie.BLL;
using AppPlatform.Contracts.Commands.RegistryService;
using System.Web.Security;

namespace AppPlatform.UI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            SSORequest ssoRequest = new SSORequest();
            #region 验证 Post 过来的参数
            //--------------------------------
            // 请求注销
            if (!string.IsNullOrEmpty(Request["Logout"]))
            {
                Authentication.Logout();
            }
            //--------------------------------
            // 各独立站点标识
            if (!string.IsNullOrEmpty(Request["IASID"]))
            {
                ssoRequest.IASID = Request["IASID"];
            }

            //--------------------------------
            // 时间戳
            if (!string.IsNullOrEmpty(Request["TimeStamp"]))
            {
                ssoRequest.TimeStamp = Request["TimeStamp"];
            }

            //--------------------------------
            // 各独立站点的访问地址
            if (!string.IsNullOrEmpty(Request["AppUrl"]))
            {
                ssoRequest.AppUrl = Request["AppUrl"];
            }

            //--------------------------------
            // 各独立站点的 Token
            if (!string.IsNullOrEmpty(Request["Authenticator"]))
            {
                ssoRequest.Authenticator = Request["Authenticator"];
            }

            Session["SSORequest"] = ssoRequest;

            #endregion

            //验证从分站发过来的Token
            if (Authentication.ValidateAppToken(ssoRequest))
            {
                string userAccount = null;
                string EnterpriseId = null;
                // 验证用户之前是否登录过
                //验证 EAC 认证中心的 Cookie,验证通过时获取用户登录账号
                if (Authentication.ValidateEACCookie(out userAccount, out EnterpriseId))
                {
                    ssoRequest.UserAccount = userAccount;
                    ssoRequest.EnterpriseId = EnterpriseId;
                    //创建认证中心发往各分站的 Token
                    if (Authentication.CreateEACToken(ssoRequest))
                    {
                        SSOSDK.Post ps=new SSOSDK.Post();
                        ps.post(ssoRequest);
                    }
                }
            }
            if (Session["LoginError"] != null)
            {
                ViewData["error"] = Session["LoginError"];
            }
            
            return View();
        }
       
       

        public ActionResult Create()//创建用户界面
        {
            IGroupRepository _group = RepositoryFactory.GroupRepository;
            List<Group> grouplist = _group.LoadEntities(Group => Group.Group_ID > 0).ToList<Group>();
            ViewData["group"] = grouplist;
            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {
            
            Enterprise enterprise = new Enterprise();
            User user = new User();
            enterprise.Enterprise_Name = Request.Form["Enterprise_Name"];
            user.User_Name = Request.Form["Enterprise_Adm"];
            user.Password = Request.Form["Enterprise_Pas"];
            enterprise.Enterprise_Code = Request.Form["Enterprise_Code"];
            enterprise.Enterprise_Email = Request.Form["Enterprise_Email"];
            var EnterpriseType = Request.Form["Enterprise_Type"];
            IRegisterService _registerService = new AppPlatform.RegisterServie.BLL.RegisterService();
            RegisterInfo registerInfo = _registerService.Regiter(enterprise, user, EnterpriseType);
            
            ServiceBus.Bus.Send(new CreateNewUserCmd 
            {
                
                EnterpriseId = registerInfo.EnterpriseAccount,
                UserId = registerInfo.UserAccount,
                EmailAddress = enterprise.Enterprise_Email
            });

            return RedirectToAction("Login");
        }
        
    }
}
