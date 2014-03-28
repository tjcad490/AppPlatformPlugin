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

        public ActionResult AppEntrance(int id)
        {
            ViewBag.URL = "http://jeasyui.com/";
            return Redirect("http://jeasyui.com/");
        }

    }
}
