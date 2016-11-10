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

        public void DeleteSessionForSession(User user, int id)
        {
            sessionRepository.DeleteSessionForId(user, id);
        }

        public List<Session> GetAllSessions(User user)
        {
            return sessionRepository.GetAllSessions(user);
        }

        public Session GetAverageForSession(Session session)
        {
            Dictionary<String, Double> averages = sessionRepository.GetAveragesForSession(session.User, session.Id);
            session.AverageActivity =  averages.ContainsKey("AverageActivity") ? averages["AverageActivity"]: 0;
            session.AverageHumidity = averages.ContainsKey("AverageHumidity") ? averages["AverageHumidity"]: 0;
            session.AveragePressure = averages.ContainsKey("Averagepressure") ? averages["AveragePressure"]: 0;
            session.AverageTemperature = averages.ContainsKey("AverageTemperature")?  averages["AverageTemperature"]: 0;
            return session;
        }

        public Session GetSessionById(User user, int id)
        {
            return sessionRepository.GetSessionById(user, id);
        }

		public Session StartSession(Session session)
		{
			return sessionRepository.StartSession(session);
		}

		public Session StopSession(Session session)
		{
			return sessionRepository.StopSession(session);
		}
	}
}
