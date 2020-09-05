using Breakthroughs.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakthroughs.Server.Data.Ninjas
{
    public class NinjaRepo : INinjaRepo
    {
        private readonly NinjaDbContext dbContext;

        public NinjaRepo(NinjaDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<NinjaModel> GetNinjaById(string id)
        {
            return await dbContext.Ninjas.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<NinjaModel>> GetNinjaList()
        {
            return await dbContext.Ninjas.ToListAsync();
        }
    }
}
