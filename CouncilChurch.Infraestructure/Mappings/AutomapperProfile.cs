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
            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Church, ChurchDto>().ReverseMap();

            CreateMap<CivilState, CivilStateDto>().ReverseMap();

            CreateMap<Council, CouncilDto>().ReverseMap();

            CreateMap<Member, MemberDto>().ReverseMap();

            CreateMap<Profession, ProfessionDto>().ReverseMap();

            CreateMap<SocialNetwork, SocialNetworkDto>().ReverseMap();
        }
    }
}
