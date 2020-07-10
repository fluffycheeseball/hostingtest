using AutoMapper;
using Data;
using Interfaces.Models;

namespace Services.Mappers {

    public class ProfileAutoMapping : Profile {
       public ProfileAutoMapping() {
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileDto, UserProfile>();
            }
        }
    }
