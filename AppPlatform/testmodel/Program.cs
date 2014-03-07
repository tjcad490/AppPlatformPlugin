using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPlatform.Model.Models;
using System.Data.SqlClient;
using AppPlatform.IDAL;
using AppPlatform.DAL;

namespace testmodel
{
    class Program
    {
        static void Main(string[] args)
        {
            AppClass appclass1 = new AppClass
            {
                AppClass_ID = 1,
                AppClass_PID=0,
                AppClass_Name = "class1"
            };
           AppClass appclass2 = new AppClass
            {
                AppClass_ID=2,
                AppClass_PID=1,
                AppClass_Name = "class2"
            };
           IAppClassRepository _appClassRepository = RepositoryFactory.AppClassRepository;
           _appClassRepository.AddEntity(appclass1);
           // _appClassRepository.AddEntity(appclass2);

            //_appClassRepository.UpdateEntity(appclass2);
           // _appClassRepository.DeleteEntity(appclass1);

            List<AppClass> t=_appClassRepository.LoadEntities(AppClass => AppClass.AppClass_ID>0).ToList<AppClass>();
            foreach(AppClass x in t)
            {
                Console.WriteLine("AppClass_ID:"+x.AppClass_ID);
                Console.WriteLine("AppClass_Name:" + x.AppClass_Name);
                Console.WriteLine("AppClass_PID:" + x.AppClass_PID);
                Console.WriteLine("AppClass_Note:" + x.AppClass_Note);
            }

            Console.WriteLine("end");

            Console.Read();
           


        }
    }
}
