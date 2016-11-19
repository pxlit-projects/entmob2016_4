using EntMob.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models;

namespace EntMob_Xamarin.Services
{
    public class SessionService : ISessionService
    {
        private ISessionRepository sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

		public Task DeleteSessionForSession(User user, int id)
        {
            return sessionRepository.DeleteSessionForId(user, id);
        }

        public Task<List<Session>> GetAllSessions(User user)
        {
            return sessionRepository.GetAllSessions(user);
        }

		public Task<Session> StartSession(Session session)
		{
			return sessionRepository.StartSession(session);
		}

		public Task<Session> StopSession(Session session)
		{
			return sessionRepository.StopSession(session);
		}
	}
}
