using DemoProject.Components;
using DemoProject.Repositories;
using DemoProject.Services;
using DemoProject.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoProject.Pages
{
	public partial class JsInterop : ComponentBase
	{
		[Inject]
		public IJSRuntime JSRuntime { get; set; }

		public string SyncResult { get; set; }

		public GeolocationModel AsyncResult { get; set; } = new GeolocationModel();

		public void GetStringFromJs()
		{
			var jsInProcess = (IJSInProcessRuntime)JSRuntime;
			SyncResult = jsInProcess.Invoke<string>("getSimpleString", "JP");
		}

		public async Task DoeWatIngewikkelders()
		{
			try
			{
				AsyncResult = await JSRuntime.InvokeAsync<GeolocationModel>("getLocationForBlazor");
				Console.WriteLine("Locatie binnen");
			}
			catch(Exception e)
			{
				Console.WriteLine("Oh dat ging mis: " + e.Message);
			}
		}
	}
}