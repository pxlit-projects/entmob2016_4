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

        public Task DeleteSessionForSession(User user, int id)
        {
            return sessionRepository.DeleteSessionForId(user, id);
        }

        public Task<List<Session>> GetAllSessions(User user)
        {
            return sessionRepository.GetAllSessions(user);
        }

        public async Task<Session> GetAverageForSession(Session session)
        {
            Dictionary<String, Double> averages = await sessionRepository.GetAveragesForSession(session.User, session.Id);
            session.AverageActivity =  averages.ContainsKey("AverageActivity") ? averages["AverageActivity"]: 0;
            session.AverageHumidity = averages.ContainsKey("AverageHumidity") ? averages["AverageHumidity"]: 0;
            session.AveragePressure = averages.ContainsKey("Averagepressure") ? averages["AveragePressure"]: 0;
            session.AverageTemperature = averages.ContainsKey("AverageTemperature")?  averages["AverageTemperature"]: 0;
            return session;
        }

        public Task<Session> GetSessionById(User user, int id)
        {
            return sessionRepository.GetSessionById(user, id);
        }
    }
}
