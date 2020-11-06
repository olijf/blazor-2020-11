using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Shared
{
	public class GeolocationModel
	{
		public decimal Latitude { get; set; }

		public decimal Longitude { get; set; }

		public decimal Accuracy { get; set; }
	}
}
