using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPlatform.Model.Models;
using System.Data.SqlClient;
using AppPlatform.IDAL;
using AppPlatform.DAL;


namespace AppPlatform.LogService.BLL
{
    public interface ILogService
    {
        bool   LogWrite(object Log);//log 是一个log对象
        List<Log> LogGet(String StartTime, String EndTime);//返回应该是一个Log的list
        List<Log> LogGet(String LogClass, String StartTime, String EndTime);//返回应该是一个Log的list
        bool   LogDelete(object Log);
       
    }
}
