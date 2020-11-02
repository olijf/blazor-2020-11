using DemoProject.Models;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoProject.Pages
{
    public partial class HelloWorld : ComponentBase
    {
        [Inject]
        public IFrameworkRepository FrameworkRepository { get; set; }

        public FrameworkModel NewFramework { get; set; } = new FrameworkModel();

        public IEnumerable<FrameworkModel> Frameworks { get; set; }

        // lifecycle method
        protected override void OnInitialized()
        {
            Console.WriteLine("Hallo!");
            Frameworks = FrameworkRepository.Query();
        }

        public void AddFramework()
        {
            FrameworkRepository.Add(NewFramework);
        }
    }
}