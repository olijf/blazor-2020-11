using DemoProject.Backend.Repositories;
using DemoProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DemoProject.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworkController : ControllerBase
    {
        IFrameworkRepository frameworkRepository;
        public FrameworkController(IFrameworkRepository frameworkRepository)
        {
            this.frameworkRepository = frameworkRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<FrameworkModel>> Get()
        {
            return await frameworkRepository.Query();
        }

        [HttpPost]
        public async Task<IActionResult> Post(FrameworkModel newFramework)
        {
            await frameworkRepository.Add(newFramework);
            return Created("api/framework/" + newFramework.Id, newFramework);
        }
    }
}
