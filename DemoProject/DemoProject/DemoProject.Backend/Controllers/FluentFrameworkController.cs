using DemoProject.Backend.Repositories;
using DemoProject.Shared;
using Microsoft.AspNetCore.Authorization;
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
    public class FluentFrameworkController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(FluentFrameworkModel newFramework)
        {
            return Ok("framework ontvangen: " + newFramework.Name);
        }
    }
}
