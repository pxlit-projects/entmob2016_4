using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntMob.DAL;
using EntMob.Models;

namespace EntMob_Xamarin
{
	public class HumidityService: IHumidityService
	{

		private IHumidityRepository repository;

		public HumidityService(IHumidityRepository repository)
		{
			this.repository = repository;
		}

		public Task<Humidity> AddHumidity(Humidity humidity)
		{
			return repository.AddHumidity(humidity);
		}

		public Task<List<Humidity>> GetHumiditiesForSession(Session session)
		{
			return repository.GetHumiditiesForSession(session);
		}
	}
}
