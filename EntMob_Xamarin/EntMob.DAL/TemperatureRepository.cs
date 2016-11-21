using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EntMob.Models;
using Newtonsoft.Json;

namespace EntMob.DAL
{
	public class TemperatureRepository : Repository, ITemperatureRepository
	{
		public Task<Temperature> AddTemperature(Temperature temperature, User user)
		{
			string addUser = BASE_URL + "/temperature";
			var uri = new Uri(addUser);
			var client = new HttpClient();
			var defaultUser = user;
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
			string temperatureObject = JsonConvert.SerializeObject(temperature);
			StringContent content = new StringContent(userObject.ToString(), Encoding.UTF8, "application/json");
			var response = await client.PostAsync(uri, content);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<User>(result);
		}

		public Task<List<Temperature>> GetTemperaturesForSession(int id)
		{
			throw new NotImplementedException();
		}
	}
}
