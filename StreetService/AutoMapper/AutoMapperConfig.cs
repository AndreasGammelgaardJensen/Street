using AutoMapper;
using StreetService.ModelDTO;
using StreetService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StreetService.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<SpotDTO, Spot>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(x => x.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(x => x.Images, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<GroupDTO, Group>()
               .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(x => x.Created, opt => opt.MapFrom(src => src.Created))
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(x => x.IsPublic, opt => opt.MapFrom(src => src.IsPublic))
               .ForMember(x => x.Spots, opt=>opt.MapFrom(src => src.Spots))
               .ForMember(x => x.Users, opt => opt.MapFrom(src=>src.Users))
               .ReverseMap();


            CreateMap<UserDTO, User>()
              .ForMember(x => x.Username, opt => opt.MapFrom(src => src.Username))
              .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(x => x.Posts, opt => opt.MapFrom(src => src.Posts))
              .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
              .ForMember(x => x.PasswordSalt, opt => opt.MapFrom(src => src.PasswordSalt))
              .ReverseMap();

            CreateMap<ImageDTO, Image>()
              .ReverseMap();


        }
    }
}
