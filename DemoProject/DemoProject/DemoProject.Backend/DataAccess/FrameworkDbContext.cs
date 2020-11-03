using DemoProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Backend.DataAccess
{
    public class FrameworkDbContext : DbContext
    {
        public DbSet<FrameworkModel> Frameworks { get; set; }

        public FrameworkDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
