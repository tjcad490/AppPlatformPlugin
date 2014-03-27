using System;
using System.Collections.Generic;
using System.Text;
using AppPlatform.DAL;
using AppPlatform.IDAL;
using AppPlatform.Model.Models;
using System.Linq;

namespace AppPlatform.GroupService.BLL
{
    public class GroupService : IGroupService
    {
        //自己修改获取方法
        public List<Model.Models.Group> GroupListGet()
        {
            IGroupRepository _groupRepository = RepositoryFactory.GroupRepository;
            List<Group> grouplist = _groupRepository.LoadEntities(Group => Group.Group_ID >= 0).ToList<Group>();
            return grouplist;
        }

        public void GroupInfoGet(object GroupID)
        {
            throw new NotImplementedException();
        }

        public bool GroupAdd(Group group)
        {
            IGroupRepository _groupRepository = RepositoryFactory.GroupRepository;
            return _groupRepository.AddEntity(group);
        }

        public bool GroupUpdate(Group group)
        {
            IGroupRepository _groupRepository = RepositoryFactory.GroupRepository;
            return _groupRepository.UpdateEntity(group);
        }

        public bool GroupDelete(int GroupID)
        {
            IGroupRepository _groupRepository = RepositoryFactory.GroupRepository;
            Group group = _groupRepository.LoadEntities(Group => Group.Group_ID == GroupID).FirstOrDefault();
            return _groupRepository.DeleteEntity(group);
        }
    }
}
