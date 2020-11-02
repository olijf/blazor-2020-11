using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoProject.Pages
{
	public partial class HelloWorld
	{
		public string Title { get; set; } = "Nogmaals hallo wereld";

		public List<FrameworkModel> Frameworks { get; set; } = new List<FrameworkModel>()
		{
			new FrameworkModel() { Id = 4, Name = "AngularJS", Grade = 3, Logo = "" },
			new FrameworkModel() { Id = 8, Name = "Angular", Grade = 8, Logo = ""},
			new FrameworkModel() { Id = 8, Name = "Blazor", Grade = 7, Logo = ""},
			new FrameworkModel() { Id = 15, Name = "Vue", Grade = 8, Logo = ""}
		};

		public void ChangeTitle()
		{
			Title += "Doei wereld";
		}

		public void AddFramework()
		{
			Frameworks.Add(new FrameworkModel()
			{
				Id = 23,
				Name = "React",
				Grade = 2,
				Logo = ""
			});
		}
	}
}