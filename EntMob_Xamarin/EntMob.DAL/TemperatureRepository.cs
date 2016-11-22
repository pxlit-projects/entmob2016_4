using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models;
using Newtonsoft.Json;

namespace EntMob.DAL
{
	public class TemperatureRepository : Repository, ITemperatureRepository
	{
		public async Task<Temperature> AddTemperature(Temperature temperature)
		{
			string startSession = BASE_URL + "/temperature";
			var uri = new Uri(startSession);
			var client = new HttpClient();
			var defaultUser = temperature.Session.User;
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
			string temperatureObject = JsonConvert.SerializeObject(temperature);
			StringContent content = new StringContent(temperature.ToString(), Encoding.UTF8, "application/json");
			var response = await client.PostAsync(uri, content);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				MissingMemberHandling = MissingMemberHandling.Ignore
			};
			return JsonConvert.DeserializeObject<Temperature>(result, settings);
		}

		public Task<List<Temperature>> GetTemperaturesForSession(Session session)
		{
			throw new NotImplementedException();
		}
	}
}
