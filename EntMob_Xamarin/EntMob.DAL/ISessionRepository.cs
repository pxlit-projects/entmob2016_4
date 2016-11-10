using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models;

namespace EntMob.DAL
{
    public interface ISessionRepository
    {
        List<Session> GetAllSessions(User user);
        Session GetSessionById(User user, int id);
        Session StartSession(Session session);
        Session StopSession(Session session);
        void DeleteSessionForId(User user, int id);
        Dictionary<String, Double> GetAveragesForSession(User user, int id);

    }
}
