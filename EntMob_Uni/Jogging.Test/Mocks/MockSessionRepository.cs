using Jogging.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model;

namespace Jogging.Test.Assets
{
    class MockSessionRepository : ISessionRepository
    {
        public Task DeleteSessionForId(User user, int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Session>> GetAllSessions(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, double>> GetAveragesForSession(User user, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Session> GetSessionById(User user, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Session> StartSession(User user, Session session)
        {
            throw new NotImplementedException();
        }

        public Task<Session> StopSession(User user, Session session)
        {
            throw new NotImplementedException();
        }
    }
}
