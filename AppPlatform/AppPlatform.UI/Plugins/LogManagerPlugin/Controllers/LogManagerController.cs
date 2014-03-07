using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppPlatform.LogService.BLL;
using AppPlatform.Model.Models;

namespace EnterpriseManagerPlugin.Controllers
{
    public class LogManagerController : Controller, ILogService
    {
        //
        // GET: /LogManager/

        ILogService _logservice= new AppPlatform.LogService.BLL.LogService();
        public ActionResult Index()
        {
            string arr = Request["arr"].ToString();
            string[] myarr = arr.Split(',');
            string LogType = myarr[0];
            string StartTime = myarr[1];
            string EndTime = myarr[2];
            Console.WriteLine(LogType);
            Console.WriteLine(StartTime);
            Console.WriteLine(EndTime);


            _logservice.LogGet(LogType, StartTime, EndTime);

          
           return View();
        }

        

        
    }
}
