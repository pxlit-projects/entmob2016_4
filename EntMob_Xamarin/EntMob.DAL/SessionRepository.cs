﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace EntMob.DAL
{
    public class SessionRepository : Repository, ISessionRepository
    {

        public async Task<List<Session>> GetAllSessions(User user)
		{
			string allSessions = BASE_URL + "/session/all";
			var uri = new Uri(allSessions);
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
			var response = await client.GetAsync(uri);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<Session>>(result);
		}

		public async Task<Session> GetSessionById(User user, int id)
		{
			string sessionsId = BASE_URL + "/session?id=" + id;
			var uri = new Uri(sessionsId);
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
			var response = await client.GetAsync(uri);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Session>(result);
		}

		public async Task DeleteSessionForId(User user, int id)
		{
			string deleteSession = BASE_URL + "/session/delete?id=" + id;
			var uri = new Uri(deleteSession);
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
			var response = await client.GetAsync(uri);
			response.EnsureSuccessStatusCode();
		}

		public async Task<Session> StartSession(Session session)
		{
			string startSession = BASE_URL + "/session/start";
			//var uri = new Uri(startSession);
			var client = new HttpClient();
			var defaultUser = session.User;
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
			string sessionObject = JsonConvert.SerializeObject(session);
			StringContent content = new StringContent(sessionObject.ToString(), Encoding.UTF8, "application/json");
			var response = await client.PostAsync(startSession, content);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				MissingMemberHandling = MissingMemberHandling.Ignore
			};
			return JsonConvert.DeserializeObject<Session>(result, settings);
		}

		public async Task<Session> StopSession(Session session)
		{
			string stopSession = BASE_URL + "/session/stop";
			//var uri = new Uri(stopSession);
			var client = new HttpClient();
			var defaultUser = session.User;
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(defaultUser.Name, defaultUser.Password);
			string sessionObject = JsonConvert.SerializeObject(session);
			StringContent content = new StringContent(sessionObject.ToString(), Encoding.UTF8, "application/json");
			var response = await client.PutAsync(stopSession, content);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Session>(result);
		}

		public async Task<Dictionary<string, double>> GetAveragesForSession(User user, int id)
		{
			string averageSession = BASE_URL + "/session/average?id=" + id;
			var uri = new Uri(averageSession);
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = BasicAuthenticationHelper.CreateBasicHeader(user.Name, user.Password);
			var response = await client.GetAsync(uri);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Dictionary<string, double>>(result);
		}

	}
}
