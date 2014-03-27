using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AppPlatform.GroupService.BLL;
using AppPlatform.Model.Models;
using AppPlatform.DAL;
using AppPlatform.IDAL;

namespace EnterpriseManagerPlugin.Controllers
{
    public class GroupController : Controller
    {
        //
        // GET: /Group/
        public JsonResult jsondata()
        {
            IGroupService _groupService = new GroupService();
            var GroupList = _groupService.GroupListGet();
            var jsonResult = new { total = GroupList.Count(), rows = GroupList };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public bool AddNewGroup()
        {
            Group group = new Group();
            //group.Group_ID = Convert.ToInt32(Request.Form["Group_ID1"]);
            group.Group_Name = Request.Form["Group_Name1"];
            group.Group_Desc = Request.Form["Group_Desc1"];
            group.Group_Note = Request.Form["Group_Note1"];
            IGroupService _groupService = new GroupService();
            return _groupService.GroupAdd(group);
        }
        public bool SaveGroupEdit()
        {
            IGroupRepository _groupRepository = RepositoryFactory.GroupRepository;
            int groupid = Convert.ToInt32(Request.Form["Group_ID"]);
            Group group = _groupRepository.LoadEntities(Group => Group.Group_ID == groupid).FirstOrDefault();
            group.Group_Name = Request.Form["Group_Name"];
            group.Group_Desc = Request.Form["Group_Desc"];
            group.Group_Note = Request.Form["Group_Note"];
            IGroupService _groupService = new GroupService();
            return _groupService.GroupUpdate(group);
        }
        public bool DestroyGroup(int id)
        {
            IGroupService _groupService = new GroupService();
            return _groupService.GroupDelete(id);
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
