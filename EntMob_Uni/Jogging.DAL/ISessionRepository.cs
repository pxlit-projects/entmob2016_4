using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model;

namespace Jogging.DAL
{
    public interface ISessionRepository
    {
        List<Session> GetAllSessions();
        Session GetSessionById(int id);
    }
}
