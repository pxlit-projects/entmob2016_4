using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntMob.Models;

namespace EntMob.DAL
{
	public interface ITemperatureRepository
	{
		Task<Temperature> AddTemperature(Temperature temperature);
		Task<List<Temperature>> GetTemperaturesForSession(Session session);

	}
}
