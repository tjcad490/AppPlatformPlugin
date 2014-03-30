using System;
using System.Collections.Generic;
using System.Text;
using AppPlatform.IDAL;
using AppPlatform.Model;
using AppPlatform.DAL;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AppPlatform.Model.Models;

namespace AppPlatform.AppClassService.BLL
{
    public interface IAppClassService
    {
        List<AppClass> GetAppClassByPid(int AppClass_Pid);
        List<AppClass> AppClassListGet();
        List<AppClass> AppClassGet(int AppClassID);
        bool AppClassCreate(AppClass AppClass);
        bool AppClassUpdate(AppClass AppClass);
        bool AppClassDelete(int AppClassID);
    }
}
