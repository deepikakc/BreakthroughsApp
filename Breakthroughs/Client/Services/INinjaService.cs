using Breakthroughs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakthroughs.Client.Services
{
    public interface INinjaService
    {
        Task<NinjaReadDto> GetNinjaById(int id);
        Task<List<NinjaReadDto>> GetNinjaList();
    }
}
