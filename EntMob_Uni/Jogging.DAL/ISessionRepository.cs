using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model;

namespace Jogging.DAL
{
    public interface ISessionRepository
    {
        List<Session> GetAllSessions(User user);
        Session GetSessionById(User user, int id);
        Session StartSession(User user, Session session);
        Session StopSession(User user, Session session);
        void DeleteSessionForId(User user, int id);
        Dictionary<String, Double> GetAveragesForSession(User user, int id);

    }
}
