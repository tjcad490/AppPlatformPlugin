using AppPlatform.DAL;
using AppPlatform.IDAL;
using AppPlatform.LoginService.BLL;
using AppPlatform.Model.Models;
using AppplatformCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPlatform.UI.Controllers
{
    public class MainPageController : Controller
    {
        //
        // GET: /MainPage/
        
        [HttpPost]
        public ActionResult LoginSuccess()
        {
            UserLoginInfo userLoginInfo = new UserLoginInfo();
            var enterPriseID = Convert.ToInt32(Request["EnterpriseID"]);
            var userID = Convert.ToInt32(Request["UserID"]);
            var passWord = Request["Password"];
            ILoginService _loginService = new AppPlatform.LoginService.BLL.LoginService();
            userLoginInfo = _loginService.LoginAuthen(enterPriseID, userID, passWord);//用户登录基本信息
            if (userLoginInfo.loginResult == LoginResult.userNoExist)
            {
                //ViewData["EnterpriseName"] = enterPriseID+ "企业：";
                //ViewData["userName"] = userID;
                Session["LoginError"] = "登录错误：用户不存在";
                return Redirect("/Account/Login");
            }
            else if (userLoginInfo.loginResult == LoginResult.pwdError)
            {
                Session["LoginError"] = "登录错误：密码错误";
                return Redirect("/Account/Login");
            }
            else if (userLoginInfo.loginResult == LoginResult.userUnchecked)
            {
                Session["LoginError"] = "登录错误：用户未认证";
                return Redirect("/Account/Login");
            }
            else if (userLoginInfo.loginResult == LoginResult.userStop)
            {
                Session["LoginError"] = "登录错误：用户账户停用";
                return Redirect("/Account/Login");
            }
            else if (userLoginInfo.loginResult == LoginResult.ok)
            {
                //保存用户账户信息
                Session["EnterpriseAccount"] = enterPriseID;
                Session["UserAccount"] = userID;
                //显示欢迎页面信息
                IEnterpriseRepository _enterPriseRopository = RepositoryFactory.EnterpriseRepository;
                Enterprise enterPrise = _enterPriseRopository.LoadEntities(Enterprise => Enterprise.Enterprise_ID == enterPriseID).FirstOrDefault();
                ViewData["EnterpriseName"] = enterPrise.Enterprise_Name + "：";
                IUserRepository _userRepository = RepositoryFactory.UserRepository;
                User user = _userRepository.LoadEntities(User => User.Enterprise_ID == enterPrise.Enterprise_ID && User.User_ID == userID).FirstOrDefault();
                ViewData["userName"] = user.User_Name;
                //根据用户角色，动态加载菜单项
                

                IGroup_FunctionRepository _groupFunction = RepositoryFactory.Group_FunctionRepository;
                List<Group_Function> GroupFunction = _groupFunction.LoadEntities(Group_Function => Group_Function.Group_ID == userLoginInfo.UserGroupID).ToList<Group_Function>();
                List<Function> functionList = new List<Function>();
                foreach (var funitem in GroupFunction)
                {
                    IFunctionRepository _functionRepository = RepositoryFactory.FunctionRepository;
                    Function function = _functionRepository.LoadEntities(Function => Function.Function_ID == funitem.Function_ID).FirstOrDefault();
                    functionList.Add(function);
                }
                ViewData["function"] = functionList;
                ///加载企业应用
                ///
                List<App> applist = new List<App>();
                try
                {
                    IApp_RoleRepository _appRoleRepoitory = RepositoryFactory.App_RoleRepository;
                    var appRole = _appRoleRepoitory.LoadEntities(App_Role => App_Role.Role_ID == userLoginInfo.UserRoleID).ToList<App_Role>();
                    foreach (var appRoleItem in appRole)
                    {
                        IAppRepository _appRepoitory = RepositoryFactory.AppRepository;
                        var app = _appRepoitory.LoadEntities(App => App.App_ID == appRoleItem.App_ID).FirstOrDefault();
                        applist.Add(app);
                    }
                }
                catch(Exception e)
                { 
                }
                if (applist != null)
                {
                    ViewData["applist"] = applist;
                }
                

                return View();
            }
            return new EmptyResult();
        }
        [HttpPost]
        public bool PasswordEdit()
        {
            int UserID =Convert.ToInt32(Session["UserAccount"]);
            IUserRepository _userRepository = RepositoryFactory.UserRepository;
            User user = _userRepository.LoadEntities(User => User.User_ID == UserID).FirstOrDefault();
            if (user.Password != Request.Form["User_Pas0"])
            {
                return false;
            
            }
            else
            {
                user.Password= Request.Form["User_Pas"];
                _userRepository.UpdateEntity(user);
                return true;
            }
        }
        public ActionResult Logout()
        {
            return Redirect("/Account/Login");
        }

    }
}
