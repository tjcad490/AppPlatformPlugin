using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AppPlatform.IDAL;
using AppPlatform.Model;
using AppPlatform.DAL;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AppPlatform.Model.Models;
namespace AppPlatform.AppInfoService.BLL
{
    public class AppInfoService : IAppInfoService
    {
        

        public List<Model.Models.App> AppListGet()
        {
            IAppRepository _appRepository = RepositoryFactory.AppRepository;
            List<App> a = _appRepository.LoadEntities(App => (App.App_ID > 0)).ToList<App>();
            return a;
        }

        public List<App> AppInfoGet(int AppId)
        {
            IAppRepository _appRepository = RepositoryFactory.AppRepository;
            List<App> a = _appRepository.LoadEntities(App => (App.App_ID == AppId)).ToList<App>();
            return a;
        }

        public bool AppInfoCreate(Model.Models.App app)
        {
            IAppRepository _appRepository = RepositoryFactory.AppRepository;
            return _appRepository.AddEntity(app); ;
        }

        public bool AppInfoUpdate(Model.Models.App app)
        {
            IAppRepository _appRepository = RepositoryFactory.AppRepository;
            return _appRepository.UpdateEntity(app);
        }

        public bool AppDelete(int AppId)
        {
            IAppRepository _appRepository = RepositoryFactory.AppRepository;
            App app = _appRepository.LoadEntities(App => (App.App_ID == AppId)).FirstOrDefault();
            return _appRepository.DeleteEntity(app);
        }
    }
}
