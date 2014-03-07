using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPlatform.Model.Models;
using AppPlatform.IDAL;

namespace AppPlatform.DAL
{
    public class LogRepository:BaseRepository<Log>,ILogRepository
    {
    }
}
