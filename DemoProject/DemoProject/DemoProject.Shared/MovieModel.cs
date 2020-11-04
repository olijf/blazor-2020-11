using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Shared
{
	public class MovieModel
	{
        public string Title { get; set; }

        public List<ActorModel> Actors { get; set; }
    }
}
