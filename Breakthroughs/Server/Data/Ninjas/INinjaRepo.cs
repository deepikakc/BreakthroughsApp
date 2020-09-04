using Breakthroughs.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakthroughs.Server.Data.Ninjas
{
    public interface INinjaRepo
    {
        Task<NinjaModel> GetNinjaById(int id);
        Task<IEnumerable<NinjaModel>> GetNinjaList();
    }
}
