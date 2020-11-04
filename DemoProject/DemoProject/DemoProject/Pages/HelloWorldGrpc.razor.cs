using DemoProject.Components;
using DemoProject.Repositories;
using DemoProject.Services;
using DemoProject.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoProject.Pages
{
	public partial class HelloWorldGrpc : ComponentBase
	{
		[Inject]
		public IFrameworkRepository FrameworkRepository { get; set; }

		[Inject]
		public FrameworkService.FrameworkServiceClient Client { get; set; }

		public FrameworkModel NewFramework { get; set; } = new FrameworkModel();

		public List<FrameworkModel> Frameworks { get; set; }

		// lifecycle method
		protected async override Task OnInitializedAsync()
		{
			var reply = await Client.QueryAsync(new Empty());
			Frameworks = reply.Frameworks.Select(f => new FrameworkModel()
			{
				Id = f.Id,
				Name = f.Name,
				Grade = f.Grade,
				Logo = f.Logo,
			}).ToList();
		}

		public async Task AddFramework()
		{
			Console.WriteLine("Nu met gRPC");
			var reply = await Client.AddAsync(new AddRequest()
			{
				Framework = new Framework()
				{
					Id = NewFramework.Id,
					Name = NewFramework.Name,
					Grade = NewFramework.Grade,
					Logo = NewFramework.Logo,
				}
			});
			Frameworks.Add(new FrameworkModel() {
				Id = reply.UpdatedFramework.Id,
				Name = reply.UpdatedFramework.Name,
				Grade = reply.UpdatedFramework.Grade,
				Logo = reply.UpdatedFramework.Logo,
			});
		}
	}
}