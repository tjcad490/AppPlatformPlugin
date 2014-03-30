using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppPlatform.IDAL;
using AppPlatform.DAL;
using AppPlatform.Model.Models;

namespace AppPlatform.UI.Controllers
{
    public class HomeController : Controller
    {
        public string UserAccount
        {
            get
            {
                if (Session["UserAccount"] != null)
                {
                    return  Session["UserAccount"].ToString();
                }
                return string.Empty;
            }
            set
            {
                Session["UserAccount"] = value;
            }
        }
        public string EnterpriseId
        {
            get
            {
                if (Session["EnterpriseAccount"] != null)
                {
                    return Session["EnterpriseAccount"].ToString();
                }
                return string.Empty;
            }
            set
            {
                Session["EnterpriseAccount"] = value;
            }
        }
        //
        // GET: /Home/

        public ActionResult SystemFunction(int ID)
        {
           var  FunctionID = ID;
           IFunctionRepository _fuctionRepository = RepositoryFactory.FunctionRepository;
           List<Function> functionlist = _fuctionRepository.LoadEntities(Function => Function.Function_PID == FunctionID).ToList<Function>();
           ViewData["functionlist"] = functionlist;
            return View();
        }

        public void AppEntrance(int id)
        {
            ///根据传过来的ID获取URL地址
            SSORequest ssoRequest = new SSORequest();

            ssoRequest.UserAccount = this.UserAccount;
            ssoRequest.EnterpriseId = this.EnterpriseId;
            //分站标识ID,从数据库或者配置文件中读取
            ssoRequest.IASID = id.ToString();
            //分站地址,从数据库或者配置文件中读取
            ssoRequest.AppUrl = "http://localhost:38065/NewApp/Default2.aspx";
            ssoRequest.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            ssoRequest.Authenticator = string.Empty;


            if (Authentication.CreateEACToken(ssoRequest))
            {
                int CookieHours = 30;
                //CookieHours = int.Parse(ConfigurationManager.AppSettings["CookieHours"]);
                string expireTime = DateTime.Now.AddSeconds(CookieHours).ToString("yyyy-MM-dd HH:mm");

                Authentication.CreatEACCookie(ssoRequest.UserAccount, ssoRequest.EnterpriseId, ssoRequest.TimeStamp, expireTime);
                SSOSDK.Post ps = new SSOSDK.Post();
                ps.post(ssoRequest);
            }
        }

    }
}
