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

        Task<List<Session>> GetAllSessions(User user);
        Task<Session> GetSessionById(User user, int id);
        Task<Session> GetAverageForSession(Session session);
        Task DeleteSessionForSession(User user, int id);

    }
}
