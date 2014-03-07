using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AppPlatform.Model.Models
{
    public partial class Enterprise_AppContext : DbContext
    {
        static Enterprise_AppContext()
        {
            //Database.SetInitializer<Enterprise_AppContext>(null);
              Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Enterprise_AppContext>());
        }

        public Enterprise_AppContext()
            : base("Name=Enterprise_AppContext")
        {
        }

        public DbSet<App_AppClass> App_AppClass { get; set; }
        public DbSet<AppClass> AppClass { get; set; }
        public DbSet<App> App { get; set; }
        public DbSet<Internal_Authorization> Internal_Authorization { get; set; }
        public DbSet<App_Role> App_Role { get; set; }
        public DbSet<Enterprise_App> Enterprise_App { get; set; }
        public DbSet<Enterprise_EnterpriseClass> Enterprise_EnterpriseClass { get; set; }
        public DbSet<EnterpriseClass> EnterpriseClass { get; set; }
        public DbSet<Enterprise> Enterprise { get; set; }
        public DbSet<InternalOrganization> InternalOrganization { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User_InternalOrganization> User_InternalOrganization { get; set; }
        public DbSet<User_Group> User_Group { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<User_Internal_Authorization> User_Internal_Authorization { get; set; }
        public DbSet<User_Role> User_Role { get; set; }
        public DbSet<TaskList> TaskList { get; set; }
        public DbSet<Function> Function { get; set; }
        public DbSet<Group_Function> Group_Function { get; set; }
        public DbSet<User_Task> User_Task { get; set; }
        public DbSet<Log> Log { get; set; }

        
    }
}
