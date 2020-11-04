using DemoProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DemoProject.Repositories
{
    public class FrameworkRestRepository : IFrameworkRepository
    {
        HttpClient http;
        public FrameworkRestRepository(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<FrameworkModel>> Query()
        {
            return await http.GetFromJsonAsync<IEnumerable<FrameworkModel>>("api/framework");
        }

        public async Task<FrameworkModel> Get(int id)
        {

            

            return await http.GetFromJsonAsync<FrameworkModel>("api/framework/" + id);
        }

        public async Task Add(FrameworkModel newFramework)
        {
            await http.PostAsJsonAsync<FrameworkModel>("api/framework", newFramework);
        }
    }
}
