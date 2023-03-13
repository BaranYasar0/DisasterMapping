using AutoMapper;
using DisasterMapping.Api.Application.Features.Commands.Disasters.Create;
using DisasterMapping.Api.Application.Features.Dtos.Disaster;
using DisasterMapping.Api.Application.Features.Queries.Disasters.GetList;
using DisasterMapping.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Api.Application.Features.Profiles
{
    public class DisasterProfile:Profile
    {
        public DisasterProfile()
        {
            CreateMap<CreateDisasterDto,Disaster>().ForMember(x=>x.Address,y=>y.MapFrom(x=>x.AddressDto)).ReverseMap();
            CreateMap<CreateDisasterCommand,Disaster>().ForMember(x=>x.Address,y=>y.MapFrom(x=>x.AddressDto)).ReverseMap();
            
            CreateMap<AddressDto, Address>().ReverseMap();
            
            CreateMap<GetDisasterListDto, Disaster>().ForMember(x => x.Address, y => y.MapFrom(x => x.AddressDto)).ReverseMap();
            CreateMap<GetDisasterByIdDto, Disaster>().ForMember(x => x.Address, y => y.MapFrom(x => x.AddressDto)).ReverseMap();


        }
    }
}
