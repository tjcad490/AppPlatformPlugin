using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AppPlatform.IDAL;
using AppPlatform.Model;
using AppPlatform.DAL;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AppPlatform.Model.Models;


namespace AppPlatform.AppClassService.BLL
{
    public class AppClassService : IAppClassService
    {
         public List<Model.Models.AppClass>  GetAppClassByPid(int AppClass_ID)
        {
            IAppClassRepository _appclassRepository = RepositoryFactory.AppClassRepository;
            List<AppClass> a = _appclassRepository.LoadEntities(AppClass => (AppClass.AppClass_PID == AppClass_ID)).ToList<AppClass>();
            return a;
        }
        public List<Model.Models.AppClass> AppClassListGet()
        {
            IAppClassRepository _appclassRepository = RepositoryFactory.AppClassRepository;
            List<AppClass> a = _appclassRepository.LoadEntities(AppClass => (AppClass.AppClass_ID!=null)).ToList<AppClass>();
            return a;
        }

        public List<AppClass> AppClassGet(int AppClassId)
        {
            IAppClassRepository _appclassRepository = RepositoryFactory.AppClassRepository;
            List<AppClass> a = _appclassRepository.LoadEntities(AppClass => (AppClass.AppClass_ID == AppClassId)).ToList<AppClass>();
            return a;
        }

        public bool AppClassCreate(Model.Models.AppClass appClass)
        {
            IAppClassRepository _appClassRepository = RepositoryFactory.AppClassRepository;
            return _appClassRepository.AddEntity(appClass); ;
        }

        public bool AppClassUpdate(Model.Models.AppClass appClass)
        {
            IAppClassRepository _appClassRepository = RepositoryFactory.AppClassRepository;
            return _appClassRepository.UpdateEntity(appClass);
        }

        public bool AppClassDelete(int AppClassID)
        {
            IAppClassRepository _appClassRepository = RepositoryFactory.AppClassRepository;
            AppClass appClass = _appClassRepository.LoadEntities(AppClass => (AppClass.AppClass_ID == AppClassID)).FirstOrDefault();
            return _appClassRepository.DeleteEntity(appClass);
        }
    }
}