using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using AppPlatform.DAL;
using AppPlatform.IDAL;
using AppPlatform.Model.Models;
using AppPlatform.AppClassService.BLL;
namespace AppManagerPlugin.Controllers
{
    public class AppClassController : Controller
    {
        //
        // GET: /AppClass/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAppClassList()
        {

            IAppClassService _appClassService = new AppClassService();
            var list = _appClassService.AppClassListGet();
            var myjson = new { total = list.Count(), rows = list };
            return Json(myjson, JsonRequestBehavior.AllowGet);

        }
        public JsonResult searchAppClass(string name)
        {
            IAppClassRepository _appClassReposity = RepositoryFactory.AppClassRepository;
            List<AppClass> list = _appClassReposity.LoadEntities(AppClass => AppClass.AppClass_Name == name).ToList();
            var myjson = new { total = list.Count(), rows = list };
            return Json(myjson, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetById(int AppClassID)
        {
            IAppClassService _appClassService = new AppClassService();
            var AppClassList = _appClassService.AppClassGet(AppClassID);
            var myjson = new { total = AppClassList.Count(), rows = AppClassList };
            return Json(myjson, JsonRequestBehavior.AllowGet);

        }
        public bool AddNewAppClass()
        {
            AppClass appClass = new AppClass();
            appClass.AppClass_ID = Convert.ToInt32(Request.Form["AppClass_ID"]);
            appClass.AppClass_Name = Request.Form["AppClass_Name"];
            appClass.AppClass_PID = Convert.ToInt32(Request.Form["AppClass_PID"]);
            appClass.AppClass_Note = Request.Form["AppClass_Note"];
            IAppClassService _appClassService = new AppClassService();
            return _appClassService.AppClassCreate(appClass);
        }
        
        public bool EditAppClass()
        {
            int appClassid = Convert.ToInt32(Request.Form["AppClass_ID"]);
            IAppClassRepository _appClassReposity = RepositoryFactory.AppClassRepository;
            AppClass appClass = _appClassReposity.LoadEntities(AppClass => AppClass.AppClass_ID == appClassid).FirstOrDefault();

            appClass.AppClass_Name = Request.Form["AppClass_Name"];
            appClass.AppClass_PID = Convert.ToInt32(Request.Form["AppClass_PID"]);
            appClass.AppClass_Note = Request.Form["AppClass_Note"];
            IAppClassService _appClassService = new AppClassService();
            return _appClassService.AppClassUpdate(appClass);
        }
        public bool DestroyAppClass(int id)
        {
            IAppClassService _appClassService = new AppClassService();
            return _appClassService.AppClassDelete(id);
        }


    }
}
