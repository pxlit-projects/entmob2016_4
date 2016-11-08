using Jogging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.DAL;

namespace EntMob_Uni.Services
{
    public class SessionDataService : ISessionDataService
    {
        SessionRepository repository = new SessionRepository();

        public SessionDataService()
        {

        }

        /*public async void PushUser(UserObject user)
        {
            repository.PostUser(user.id);
        }*/

        public async Task<List<Session>> GetAllSessions()
        {
            //return await Task.Run(() => repository.GetAllSessions());
            throw new NotImplementedException();
        }

        public Session GetSessionById(int id)
        {
            //return repository.GetSessionById(id);
            throw new NotImplementedException();
        }

        List<Session> ISessionDataService.GetAllSessions()
        {
            throw new NotImplementedException();
        }

        ISessionDataService ISessionDataService.GetSessionById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
