using DemoProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DemoProject.Repositories
{
    public class FrameworkMemoryRepository : IFrameworkRepository
    {
        private List<FrameworkModel> Frameworks { get; set; } = new List<FrameworkModel>()
        {
            new FrameworkModel() { Id = 4, Name = "AngularJS", Grade = 3, Logo = "https://angular.io/assets/images/logos/angularjs/AngularJS-Shield.svg" },
            new FrameworkModel() { Id = 8, Name = "Angular", Grade = 8, Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cf/Angular_full_color_logo.svg/250px-Angular_full_color_logo.svg.png"},
            new FrameworkModel() { Id = 15, Name = "Blazor", Grade = 7, Logo = "https://www.delta-n.nl/wp-content/uploads/2019/10/BrandBlazor_uitgelicht.png"},
            new FrameworkModel() { Id = 16, Name = "Vue", Grade = 8, Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Vue.js_Logo_2.svg/1200px-Vue.js_Logo_2.svg.png"}
        };

        public Task<IEnumerable<FrameworkModel>> Query()
        {
            return Task.FromResult<IEnumerable<FrameworkModel>>(Frameworks);
        }

        public Task<FrameworkModel> Get(int id)
        {
            return Task.FromResult(Frameworks.Find(x => x.Id == id));
        }

        public Task Add(FrameworkModel newFramework)
        {
            newFramework.Id = Frameworks.Max(x => x.Id) + 1;
            Frameworks.Add(newFramework);
            return Task.CompletedTask;
        }
    }
}
