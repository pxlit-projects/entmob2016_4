using Jogging.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.DAL
{
    public class UserRepository: Repository, IUserRepository
    {

        public User GetUserByName(string name)
        {
            string allSessions = BASE_URL + "/user?username=" + name;
            var uri = new Uri(allSessions);
            var client = new HttpClient();
            var user = User.DefaultUser;
            client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<User>(result);
        }

        public User PostUser(User user)
        {
            string allSessions = BASE_URL + "/user";
            var uri = new Uri(allSessions);
            var client = new HttpClient();
            var defaultUser = User.DefaultUser;
            client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
            string userObject = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(userObject.ToString(), Encoding.UTF8, "application/json");
            var response = Task.Run(() => client.PostAsync(uri, content)).Result;
            response.EnsureSuccessStatusCode();
            var result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            return JsonConvert.DeserializeObject<User>(result);
        }

    }
}
