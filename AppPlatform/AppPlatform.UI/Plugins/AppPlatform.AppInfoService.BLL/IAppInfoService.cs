using System;
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
    public interface IAppInfoService
    {
        //接口方法的返回类型以及参数根据数据库定义，接口的实现在Impl文件夹AppService实现
        List<App> AppListGet();
        List<App> AppInfoGet(int App_ID);
        bool AppInfoCreate(App app);
        bool AppInfoUpdate(App app);
        bool AppDelete(int App_ID);
    }
}
