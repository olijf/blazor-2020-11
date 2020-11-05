using DemoProject.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DemoProject.Repositories
{
	public class FrameworkRestRepository : IFrameworkRepository
	{
		HttpClient http;
		IAccessTokenProvider tokenProvider;
		public FrameworkRestRepository(HttpClient http, IAccessTokenProvider tokenProvider)
		{
			this.http = http;
			this.tokenProvider = tokenProvider;
		}

		public async Task<IEnumerable<FrameworkModel>> Query()
		{
			return await http.GetFromJsonAsync<IEnumerable<FrameworkModel>>("api/framework");
		}

		public async Task<FrameworkModel> Get(int id)
		{
			return await http.GetFromJsonAsync<FrameworkModel>("api/framework/" + id);
		}

		public async Task Add(FrameworkModel newFramework)
		{
			Console.WriteLine("Nu adden met auth");
			var tokenResponse = await tokenProvider.RequestAccessToken(new AccessTokenRequestOptions()
			{
				Scopes = new[] { "demoprojectbackend" }
			});
			if (tokenResponse.TryGetToken(out var token))
			{
				Console.WriteLine("Token: " + token.Value);
				var message = new HttpRequestMessage(new HttpMethod("POST"), "api/framework");
				message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
				message.Content = JsonContent.Create(newFramework);
				await http.SendAsync(message);
			}
			else
			{
				Console.WriteLine("Kon accesstoken niet verkrijgen");
			}
		}
	}
}
