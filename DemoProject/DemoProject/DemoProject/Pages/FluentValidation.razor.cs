using DemoProject.Components;
using DemoProject.Repositories;
using DemoProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DemoProject.Pages
{
    public partial class FluentValidation : ComponentBase
    {
        [Inject]
		public HttpClient Http { get; set; }

		public string Response { get; set; }

		public FluentFrameworkModel NewFramework { get; set; } = new FluentFrameworkModel();

        public void AddFramework()
        {
			Console.WriteLine("Adding framework");
        }

        public async Task AddFluentFramework()
		{
            var json = JsonContent.Create(new FluentFrameworkModel()
            {
                Name = "ietshoi",
                Grade = 10
            });
            var response = await Http.PostAsync("api/fluentframework", json);
            Response = await response.Content.ReadAsStringAsync();
		}
    }
}