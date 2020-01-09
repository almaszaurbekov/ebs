using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterface.ViewModels.Entities;

namespace UserInterface.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
