using EntMob_Uni.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model;
using Jogging.Test.Assets;

namespace Jogging.Test.Mocks
{
    class MockSessionService : ISessionService
    {

        private MockSessionRepository repository = new MockSessionRepository();

        public Task DeleteSessionForSession(User user, int id)
        {
            return repository.DeleteSessionForId(user, id);
        }

        public Task<List<Session>> GetAllSessions(User user)
        {
            return repository.GetAllSessions(user);
        }

        public Task<Session> GetAverageForSession(Session session)
        {
            throw new NotImplementedException();
        }

        public Task<Session> GetSessionById(User user, int id)
        {
            return repository.GetSessionById(user, id);
        }
    }
}
