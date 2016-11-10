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

        List<Session> GetAllSessions(User user);
        Session GetSessionById(User user, int id);
        Session GetAverageForSession(Session session);
        void DeleteSessionForSession(User user, int id);

    }
}
