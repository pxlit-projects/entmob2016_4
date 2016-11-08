using Jogging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Uni.Services
{
    public interface ISessionService
    {

        List<Session> GetAllSessions(User user);
        Session GetSessionById(User user, int id);
        Dictionary<String, Double> GetAverageForSession(User user, int id);
        void DeleteSessionForSession(User user, int id);

    }
}
