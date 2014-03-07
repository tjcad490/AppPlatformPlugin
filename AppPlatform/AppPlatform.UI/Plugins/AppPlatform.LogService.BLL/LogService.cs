using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPlatform.DAL;
using AppPlatform.IDAL;
using AppPlatform.Model.Models;

namespace AppPlatform.LogService.BLL
{
    public class LogService:ILogService
    {
        ILogRepository _logRepository = RepositoryFactory.LogRepository;

        bool LogWrite(Log a)//写日志
        {

            return _logRepository.AddEntity(a);

        }
        List<Log> LogGet(DateTime StartTime, DateTime EndTime)//按时间进行搜索
        {
            List<Log> t = _logRepository.LoadEntities(Log => (Log.Log_Time > StartTime && Log.Log_Time < EndTime)).ToList<Log>();
            return t;
        }

        List<Log> LogGet(String LogClass, DateTime StartTime, DateTime EndTime)//按类别，时间进行搜索
        {
            List<Log> t = _logRepository.LoadEntities(Log => (Log.Log_Time > StartTime && Log.Log_Time < EndTime && Log.Log_Class.Equals(LogClass))).ToList<Log>();
            return t;
        }
        bool LogDelete(Log a)//删除日志
        {
            return _logRepository.DeleteEntity(a);
        }
       
    }
}
