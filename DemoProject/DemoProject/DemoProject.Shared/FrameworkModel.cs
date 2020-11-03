using System;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Shared
{
	public class FrameworkModel
	{
		public int Id { get; set; }

		[Required]
		[RegularExpression("^[a-zA-Z0-9.]+$", ErrorMessage = "Alleen letters en cijfers graag")]
		public string Name { get; set; }

		[Range(0, 50)]
		public int Grade { get; set; }

		[Required]
		public string Logo { get; set; }
	}
}
