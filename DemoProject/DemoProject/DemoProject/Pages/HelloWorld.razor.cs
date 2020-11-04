using DemoProject.Components;
using DemoProject.Repositories;
using DemoProject.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Pages
{
    public partial class HelloWorld : ComponentBase
    {
        [Inject]
        public IFrameworkRepository FrameworkRepository { get; set; }

        public FrameworkModel NewFramework { get; set; } = new FrameworkModel();

        public IEnumerable<FrameworkModel> Frameworks { get; set; }

        public IEnumerable<Autocompleter<FrameworkModel>.AutocompleterItem> FrameworkItems { get; set; }

        public DateTime Datumpje { get; set; }
        

        // lifecycle method
        protected async override Task OnInitializedAsync()
        {
            Console.WriteLine("Hallo vanaf rest repo!");
            Frameworks = await FrameworkRepository.Query();
            FrameworkItems = Frameworks.Select(x => new Autocompleter<FrameworkModel>.AutocompleterItem()
            {
                Text = $"{x.Name}",
                Item = x
            });
        }

        public void AddFramework()
        {
            FrameworkRepository.Add(NewFramework);
        }

        public void HandleFileChange()
        {
            Console.WriteLine("Bestand gewijzgd");
        }

        public void HandleItemSelect(object eventObj)
        {
            var e = (AutocompleterEventArgs<FrameworkModel>)eventObj;

            Console.WriteLine("Item geselecteerd: " + e.Item.Name);
        }
    }
}