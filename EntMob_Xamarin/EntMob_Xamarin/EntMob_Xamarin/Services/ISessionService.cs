using EntMob.DAL;
using EntMob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Xamarin.Services
{
    public interface ISessionService
    {

        Task<List<Session>> GetAllSessions(User user);
		Task<Session> StartSession(Session session);
		Task<Session> StopSession(Session session);
		Task DeleteSessionForSession(User user, int id);

    }
}
