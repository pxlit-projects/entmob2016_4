using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models;
using Newtonsoft.Json;

namespace EntMob.DAL
{
	public class HumidityRepository: Repository, IHumidityRepository
	{

		public async Task<Humidity> AddHumidity(Humidity humidity)
		{
			string addHumidity = BASE_URL + "/humidity";
			//var uri = new Uri(startSession);
			var client = new HttpClient();
			var defaultUser = humidity.Session.User;
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
			string sessionObject = JsonConvert.SerializeObject(humidity);
			StringContent content = new StringContent(sessionObject.ToString(), Encoding.UTF8, "application/json");
			var response = await client.PostAsync(addHumidity, content);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				MissingMemberHandling = MissingMemberHandling.Ignore
			};
			return JsonConvert.DeserializeObject<Humidity>(result, settings);
		}

		public async Task<List<Humidity>> GetHumiditiesForSession(Session session)
		{
			string humdities = BASE_URL + "/humidity?id=" + session.Id;
			//var uri = new Uri(startSession);
			var client = new HttpClient();
			var defaultUser = session.User;
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
			var response = await client.GetAsync(humdities);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<Humidity>>(result);
		}
	}
}
