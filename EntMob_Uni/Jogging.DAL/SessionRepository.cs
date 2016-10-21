using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogging.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace Jogging.DAL
{
    public class SessionRepository : ISessionRepository
    {

        private const string BASE_URL = "http://localhost:81";

        private static List<Session> sessionsList;

        public List<Session> GetAllSessions()
        {
            if (sessionsList == null)
            {
                LoadDummySessions();
            }
            return sessionsList;
        }

        public Session GetSessionById(int id)
        {
            if (sessionsList == null)
            {
                LoadSessions();
            }
            return sessionsList.Where(p => p.Id == id).FirstOrDefault();
        }

        private void LoadSessions()
        {
            string sessions = BASE_URL + "/sessions?id = 1";
            var uri = new Uri(sessions);
            var client = new HttpClient();
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            var root = JsonConvert.DeserializeObject<List<Session>>(result);

            sessionsList = root;
        }

        private void LoadDummySessions()
        {

        }
    }
}
