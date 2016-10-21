using Jogging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Uni.Services
{
    public interface ISessionDataService
    {
        List<Session> GetAllSessions();
        ISessionDataService GetSessionById(int id);
    }
}
