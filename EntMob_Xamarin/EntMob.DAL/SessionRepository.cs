using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace EntMob.DAL
{
    public class SessionRepository : Repository, ISessionRepository
    {

        public List<Session> GetAllSessions(User user)
        {
            string allSessions = BASE_URL + "/session/all";
            var uri = new Uri(allSessions);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<List<Session>>(result);
        }

        public Session GetSessionById(User user, int id)
        {
            string sessionsId = BASE_URL + "/session?id=" + id;
            var uri = new Uri(sessionsId);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<Session>(result);
        }

        public void DeleteSessionForId(User user, int id)
        {
            string deleteSession = BASE_URL + "/session/delete?id=" + id;
            var uri = new Uri(deleteSession);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
        }

        public Session StartSession(Session session)
        {
            string allSessions = BASE_URL + "/session/start";
            var uri = new Uri(allSessions);
            var client = new HttpClient();
			var defaultUser = session.User;
            client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
            string sessionObject = JsonConvert.SerializeObject(session);
            StringContent content = new StringContent(sessionObject.ToString(), Encoding.UTF8, "application/json");
            var response = Task.Run(() => client.PostAsync(uri, content)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<Session>(result);
        }

        public Session StopSession(Session session)
        {
            string stopSession = BASE_URL + "/session/stop";
            var uri = new Uri(stopSession);
            var client = new HttpClient();
			var defaultUser = session.User;
            client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
            string sessionObject = JsonConvert.SerializeObject(session);
            StringContent content = new StringContent(sessionObject.ToString(), Encoding.UTF8, "application/json");
            var response = Task.Run(() => client.PutAsync(uri, content)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<Session>(result);
        }

        public Dictionary<string, double> GetAveragesForSession(User user, int id)
        {
            string averageSession = BASE_URL + "/session/average?id=" + id;
            var uri = new Uri(averageSession);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<Dictionary<string, double>>(result);
        }

    }
}
