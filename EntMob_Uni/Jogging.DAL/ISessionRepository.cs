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
        Task<List<Session>> GetAllSessions(User user);
        Task<Session> GetSessionById(User user, int id);
        Task<Session> StartSession(User user, Session session);
        Task<Session> StopSession(User user, Session session);
        Task DeleteSessionForId(User user, int id);
        Task<Dictionary<String, Double>> GetAveragesForSession(User user, int id);

    }
}
