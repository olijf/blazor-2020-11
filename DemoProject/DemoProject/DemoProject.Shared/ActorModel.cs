using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Shared
{
	public class ActorModel
	{
        public string Name { get; set; }

        public List<MovieModel> Movies { get; set; }
    }
}
