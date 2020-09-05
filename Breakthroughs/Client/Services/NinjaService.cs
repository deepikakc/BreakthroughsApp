using Breakthroughs.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Breakthroughs.Client.Services
{
    public class NinjaService : INinjaService
    {
        private readonly HttpClient httpClient;

        public NinjaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<NinjaReadDto> GetNinjaById(string id)
        {
            return await httpClient
                .GetFromJsonAsync<NinjaReadDto>($"api/ninja/id/{id}");
        }

        public async Task<List<NinjaReadDto>> GetNinjaList()
        {
            return await httpClient
                .GetFromJsonAsync<List<NinjaReadDto>>("api/ninja/list");
        }
    }
}
