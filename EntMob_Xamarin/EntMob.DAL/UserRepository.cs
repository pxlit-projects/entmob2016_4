using EntMob.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EntMob.DAL
{
    public class UserRepository: Repository, IUserRepository
    {

        public async Task<User> GetUserByName(string name)
		{
			string allSessions = BASE_URL + "/user?username=" + name;
			var uri = new Uri(allSessions);
			var client = new HttpClient();
			var user = User.DefaultUser;
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
			var response = await client.GetAsync(uri);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<User>(result);
		}

		public async Task<User> PostUser(User user)
		{
			string allSessions = BASE_URL + "/user";
			var uri = new Uri(allSessions);
			var client = new HttpClient();
			var defaultUser = User.DefaultUser;
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
			string userObject = JsonConvert.SerializeObject(user);
			StringContent content = new StringContent(userObject.ToString(), Encoding.UTF8, "application/json");
			var response = await client.PostAsync(uri, content);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<User>(result);
		}

    }
}
