using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntMob.Models;

namespace EntMob_Xamarin
{
	public interface IHumidityService
	{

		Task<Humidity> AddHumidity(Humidity humidity);
		Task<List<Humidity>> GetHumiditiesForSession(Session session);

	}
}
