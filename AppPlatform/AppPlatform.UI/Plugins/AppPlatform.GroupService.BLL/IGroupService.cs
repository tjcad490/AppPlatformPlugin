using System;
using System.Collections.Generic;
using System.Text;
using AppPlatform.Model.Models;

namespace AppPlatform.GroupService.BLL
{
    public interface IGroupService
    {
        List<Group> GroupListGet();//自己修改的返回Group的List表
        void GroupInfoGet(object GroupID);
        bool GroupAdd(Group group);
        bool GroupUpdate(Group group);
        bool GroupDelete(int GroupID);

    }
}
