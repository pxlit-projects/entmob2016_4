using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntMob.DAL;
using EntMob.Models;

namespace EntMob_Xamarin
{
	public class TemperatureService: ITemperatureService
	{

		private ITemperatureRepository repository;

		public TemperatureService(ITemperatureRepository repository)
		{
			this.repository = repository;
		}

		public Task<Temperature> AddTemperature(Temperature temperature)
		{
			return repository.AddTemperature(temperature);
		}

		public Task<List<Temperature>> GetTemperaturesForSession(Session session)
		{
			return repository.GetTemperaturesForSession(session);
		}
	}
}
