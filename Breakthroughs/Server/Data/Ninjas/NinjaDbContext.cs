using Breakthroughs.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakthroughs.Server.Data.Ninjas
{
    public class NinjaDbContext : DbContext
    {
        public NinjaDbContext(DbContextOptions<NinjaDbContext> options)
            : base(options)
        {
        }

        public DbSet<NinjaModel> Ninjas { get; set; }
    }
}
