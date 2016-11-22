using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntMob.Models;

namespace EntMob_Xamarin
{
	public interface ITemperatureService
	{

		Task<Temperature> AddTemperature(Temperature temperature);
		Task<List<Temperature>> GetTemperaturesForSession(Session session);

	}
}
