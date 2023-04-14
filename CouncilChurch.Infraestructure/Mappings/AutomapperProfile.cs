using AutoMapper;
using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Infraestructure.Mappings
{
    public class AutomapperProfile :Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Church, ChurchDto>();
            CreateMap<ChurchDto, Church>();

            CreateMap<CivilState, CivilStateDto>();
            CreateMap<CivilStateDto, CivilState>();

            CreateMap<Council, CouncilDto>();
            CreateMap<CouncilDto, Council>();

            CreateMap<Member, ChurchDto>();
            CreateMap<ChurchDto, Church>();

            CreateMap<Profession, ProfessionDto>();
            CreateMap<ProfessionDto, Profession>();

            CreateMap<SocialNetwork, ProfessionDto>();
            CreateMap<ProfessionDto, SocialNetwork>();

        }
    }
}
