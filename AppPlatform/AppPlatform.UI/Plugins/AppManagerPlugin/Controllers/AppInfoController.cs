using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using AppPlatform.DAL;
using AppPlatform.IDAL;
using AppPlatform.Model.Models;
using AppPlatform.AppInfoService.BLL;
using AppPlatform.AppClassService.BLL;

namespace AppManagerPlugin.Controllers
{
    public class AppInfoController : Controller
    {
        //
        // GET: /AppInfo/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAppList()
        {

            IAppInfoService _appInfoService = new AppInfoService();
            var list = _appInfoService.AppListGet();
            var myjson = new { total = list.Count(), rows = list };
            return Json(myjson, JsonRequestBehavior.AllowGet);

        }
        public JsonResult searchApp(string name)
        {
            IAppRepository _appReposity = RepositoryFactory.AppRepository;
            List<App> list = _appReposity.LoadEntities(App => App.App_Name == name).ToList();
            var myjson = new { total = list.Count(), rows = list };
            return Json(myjson, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetById(int AppID)
        {
            IAppInfoService _appInfoService = new AppInfoService();
            var AppList = _appInfoService.AppInfoGet(AppID);
            var myjson = new { total = AppList.Count(), rows = AppList };
            return Json(myjson, JsonRequestBehavior.AllowGet);

        }
        public bool AddNewApp(string id)
        {
            App app = new App();
            App addapp = new App();
            app.App_Name = Request.Form["App_Name"];
            app.App_Logo = System.Text.Encoding.Default.GetBytes(Request.Form["App_Logo"]);
            app.App_Description = Request.Form["App_Description"];
            app.App_url = Request.Form["App_url"];
            app.App_BrowseNum = Convert.ToInt64(Request.Form["App_BrowseNum"]);
            app.App_DownNum = Convert.ToInt64(Request.Form["App_DownNum"]);
            app.App_Gragh = System.Text.Encoding.Default.GetBytes(Request.Form["App_Gragh"]);
            app.AppUpdate_Time = Convert.ToDateTime(Request.Form["AppUpdate_Time"]);
            app.App_State = Convert.ToBoolean(Request.Form["App_State"]);
            app.App_Option = Request.Form["App_Option"];
            IAppInfoService _appInfoService = new AppInfoService();
             bool bool1=_appInfoService.AppInfoCreate(app);
           
            IAppRepository _appReposity = RepositoryFactory.AppRepository;
            addapp = _appReposity.LoadEntities(App => App.App_Name ==app.App_Name).FirstOrDefault();
            App_AppClass _App_AppClass = new App_AppClass();
            _App_AppClass.App_ID = addapp.App_ID;
            _App_AppClass.AppClass_ID =Convert.ToInt32(id);
            IApp_AppClassRepository _App_AppClassRepository = RepositoryFactory.App_AppClassRepository;
            bool bool2=_App_AppClassRepository.AddEntity(_App_AppClass);

            if (bool1 == bool2)
                return true;
            else return false;
        }
        public bool EditApp()
        {
            int appid = Convert.ToInt32(Request.Form["App_ID"]);
            IAppRepository _appReposity = RepositoryFactory.AppRepository;
            App app = _appReposity.LoadEntities(App => App.App_ID == appid).FirstOrDefault();
            IApp_AppClassRepository _App_AppClassRepository = RepositoryFactory.App_AppClassRepository;
            App_AppClass _App_AppClass = _App_AppClassRepository.LoadEntities(App_AppClass => App_AppClass.App_ID == appid).FirstOrDefault();
            String appclassname = Request.Form["AppClass_Name"];
            IAppClassRepository _AppClassRepository = RepositoryFactory.AppClassRepository;
            AppClass appclass = _AppClassRepository.LoadEntities(AppClass => AppClass.AppClass_Name == appclassname).FirstOrDefault();
            _App_AppClass.AppClass_ID = appclass.AppClass_ID;
            _App_AppClass.App_ID = appid;
            app.App_Name = Request.Form["App_Name"];
            app.App_Logo = System.Text.Encoding.Default.GetBytes(Request.Form["App_Logo"]);
            app.App_Description = Request.Form["App_Description"];
            app.App_url = Request.Form["App_url"];
            app.App_BrowseNum = Convert.ToInt64(Request.Form["App_BrowseNum"]);
            app.App_DownNum = Convert.ToInt64(Request.Form["App_DownNum"]);
            app.App_Gragh = System.Text.Encoding.Default.GetBytes(Request.Form["App_Gragh"]);
            app.AppUpdate_Time = Convert.ToDateTime(Request.Form["AppUpdate_Time"]);
            app.App_State = Convert.ToBoolean(Request.Form["App_State"]);
            app.App_Option = Request.Form["App_Option"];
            IAppInfoService _appInfoService = new AppInfoService();
            _App_AppClassRepository.UpdateEntity(_App_AppClass);
            return _appInfoService.AppInfoUpdate(app);
            
        }
        public bool DestroyApp(int id)
        {
            IAppInfoService _appInfoService = new AppInfoService();
            return _appInfoService.AppDelete(id);
        }
        public string GetAppClassList()
        {
            string result = "";  
            IAppClassService _appClassService = new AppClassService();
            var list = _appClassService.AppClassListGet();
                        foreach (AppClass node in list)
            {
                            if(node.AppClass_PID==0)
                result += Recursion(node) + ",";
            }
            return "[" + result.TrimEnd(',') + "]";
        }  
        public string Recursion(AppClass model)
        {
            string res_s = "";
            res_s += "{\"id\":" + model.AppClass_ID + ",\"text\":\"" + model.AppClass_Name + "\"";
            IAppClassService _appClassService = new AppClassService();
            List<AppClass> list = _appClassService.GetAppClassByPid(model.AppClass_ID).ToList<AppClass>();
            if (list != null)
            {
                res_s += "," + "\"children\":[";
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                        res_s += ",";
                    res_s += Recursion(list[i]);
                }
                res_s += "]";
            }
            res_s += "}";
            return res_s;
        }  
        //List<AppClass> newlist = new List<AppClass>();
       // StringBuilder str = new StringBuilder();
        //public void TransJson(AppClass temp, List<AppClass> list)
        //{

           // if ((newlist.Contains(temp) == false))
           // {

              //  str.Append("{");
              //  str.Append("AppClass_ID:");
                //str.Append(temp.AppClass_ID.ToString());
               // /str.Append(",");
               /// str.Append("AppClass_Name:'");
               // str.Append(temp.AppClass_Name.ToString());
              //  str.Append("'");
               // newlist.Add(temp);
              // /foreach (AppClass tem in list)
               // {
                 //  if (tem.AppClass_PID == temp.AppClass_ID)
                  //  {
                    //    str.Append("children:[");
                     // TransJson(tem, list);
                      //  str = str.Remove(str.Length - 1, 1);
                       // str.Append("]");
                   // }
              //  }
              //  str.Append("},");
       //     }
       // }
    }
}

