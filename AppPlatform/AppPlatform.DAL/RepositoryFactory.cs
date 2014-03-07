using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPlatform.IDAL;

namespace AppPlatform.DAL
{
    public static class RepositoryFactory//简单工厂
    {
        public static IApp_AppClassRepository App_AppClassRepository
        {

            get { return new App_AppClassRepository(); }

        }
        public static IAppRepository AppRepository
        {

            get { return new AppRepository(); }

        }

        public static IApp_RoleRepository App_RoleRepository
        {

            get { return new App_RoleRepository(); }

        }
        public static IAppClassRepository AppClassRepository
        {

            get { return new AppClassRepository(); }

        }
        public static IEnterpriseRepository EnterpriseRepository
        {

            get { return new EnterpriseRepository(); }

        }
        public static IEnterprise_AppRepository Enterprise_AppRepository
        {

            get { return new Enterprise_AppRepository(); }

        }

        public static IEnterprise_EnterpriseClassRepository Enterprise_EnterpriseClassRepository
        {

            get { return new Enterprise_EnterpriseClassRepository(); }

        }
        public static IEnterpriseClassRepository EnterpriseClassRepository
        {

            get { return new EnterpriseClassRepository(); }

        }

        public static IInternal_AuthorizationRepository Internal_AuthorizationRepository
        {

            get { return new Internal_AuthorizationRepository(); }

        }

        public static IInternalOrganizationRepository InternalOrganizationRepository
        {

            get { return new InternalOrganizationRepository(); }

        }

        public static IRoleRepository RoleRepository
        {

            get { return new RoleRepository(); }

        }

        public static IUser_InternalOrganizationRepository User_InternalOrganizationRepository
        {
            get { return new User_InternalOrganizationRepository(); }
        }

        public static IUser_GroupRepository User_GroupRepository
        {
            get { return new User_GroupRepository(); }
        }

        public static IGroupRepository GroupRepository
        {
            get { return new GroupRepository(); }
        }

        public static IUserRepository UserRepository
        {
            get { return new UserRepository(); }
        }

        public static IUser_Internal_AuthorizationRepository User_Internal_AuthorizationRepository
        {
            get { return new User_Internal_AuthorizationRepository(); }
        }

        public static IUser_RoleRepository User_RoleRepository
        {
            get { return new User_RoleRepository(); }
        }

        public static ITaskListRepository TaskListRepository
        {
            get { return new TaskListRepository(); }
        }

        public static IFunctionRepository FunctionRepository
        {
            get { return new FunctionRepository(); }
        }

        public static IGroup_FunctionRepository Group_FunctionRepository
        {
            get { return new Group_FunctionRepository(); }
        }

        public static IUser_TaskRepository User_TaskRepository
        {
            get { return new User_TaskRepository(); }
        }

        public static ILogRepository LogRepository
        {
            get { return new LogRepository(); }
        }

    }

}
