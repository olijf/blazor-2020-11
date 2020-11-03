using DemoProject.Backend.DataAccess;
using DemoProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Backend.Repositories
{
    public class FrameworkEntityRepository : IFrameworkRepository
    {
        FrameworkDbContext context;
        public FrameworkEntityRepository(FrameworkDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<FrameworkModel>> Query()
        {
            return await context.Frameworks.ToListAsync();
        }

        public async Task<FrameworkModel> Get(int id)
        {
            return await context.Frameworks.SingleAsync(x => x.Id == id);
        }

        public async Task<FrameworkModel> Add(FrameworkModel newFramework)
        {
            context.Add(newFramework);
            await context.SaveChangesAsync();
            return newFramework;
        }
    }
}
