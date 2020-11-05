using DemoProject.Repositories;
using DemoProject.Services;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5555/") });
			builder.Services.AddScoped<IFrameworkRepository, FrameworkRestRepository>();

			builder.Services.AddMatToaster(config =>
			{
				config.Position = MatToastPosition.BottomRight;
				config.PreventDuplicates = true;
				config.NewestOnTop = true;
				config.ShowCloseButton = true;
				config.MaximumOpacity = 95;
				config.VisibleStateDuration = 3000;
			});

			builder.Services.AddSingleton(services =>
			{
				var channel = GrpcChannel.ForAddress("https://localhost:5555", new GrpcChannelOptions()
				{
					HttpHandler = new GrpcWebHandler(new HttpClientHandler())
				});

				var client = new FrameworkService.FrameworkServiceClient(channel);
				return client;
			});
			builder.Services.AddOidcAuthentication(options =>
			{
				builder.Configuration.Bind("Auth", options.ProviderOptions);
				options.ProviderOptions.DefaultScopes.Add("demoprojectbackend");
			});

			await builder.Build().RunAsync();
		}
	}
}
