using DemoProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController
    {
        [HttpGet]
        public IEnumerable<MovieModel> Get()
        {
            var terminator = new MovieModel() { Title = "Terminator", Actors = new List<ActorModel>() };
            var genesis = new MovieModel() { Title = "Terminator Genesis", Actors = new List<ActorModel>() };
            var m3 = new MovieModel() { Title = "Scarface", Actors = new List<ActorModel>() };
            var diehard1 = new MovieModel() { Title = "Die Hard", Actors = new List<ActorModel>() };
            var diehard2 = new MovieModel() { Title = "Die Hard: This time it's personal", Actors = new List<ActorModel>() };

            var bruce = new ActorModel() { Name = "Bruce Willis", Movies = new List<MovieModel>() };
            var arnold = new ActorModel() { Name = "Arnold Schwarzenegger", Movies = new List<MovieModel>() };
            var emilia = new ActorModel() { Name = "Emilia", Movies = new List<MovieModel>() };

            terminator.Actors.Add(arnold);
            genesis.Actors.Add(arnold);
            genesis.Actors.Add(emilia);
            diehard1.Actors.Add(bruce);
            diehard2.Actors.Add(bruce);

            arnold.Movies.Add(terminator);
            arnold.Movies.Add(genesis);
            emilia.Movies.Add(genesis);
            bruce.Movies.Add(diehard1);
            bruce.Movies.Add(diehard2);

            return new List<MovieModel>() { terminator, genesis, m3, diehard1, diehard2 };
        }
    }
}
