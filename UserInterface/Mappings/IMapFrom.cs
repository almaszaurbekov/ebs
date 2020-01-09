using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
