using AutoMapper;
using Breakthroughs.Shared.Dtos;
using Breakthroughs.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakthroughs.Server.Profiles
{
    public class NinjaProfile : Profile
    {
        public NinjaProfile()
        {
            CreateMap<NinjaModel, NinjaReadDto>();
            CreateMap<NinjaReadDto, NinjaModel>();
        }
    }
}
