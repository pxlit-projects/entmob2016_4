using Jogging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.DAL;

namespace EntMob_Uni.Services
{
    public class SessionService : ISessionService
    {
        private ISessionRepository sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public void DeleteSessionForSession(User user, int id)
        {
            sessionRepository.DeleteSessionForId(user, id);
        }

        public List<Session> GetAllSessions(User user)
        {
            return sessionRepository.GetAllSessions(user);
        }

        public Dictionary<string, double> GetAverageForSession(User user, int id)
        {
            return sessionRepository.GetAveragesForSession(user, id);
        }

        public Session GetSessionById(User user, int id)
        {
            return sessionRepository.GetSessionById(user, id);
        }
    }
}
