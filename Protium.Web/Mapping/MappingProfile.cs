
using Autofac;
using AutoMapper;
using Protium.Data.Entity;
using Protium.Repository.Dto;
using Protium.Repository.Interface;
using System;
using System.Linq;
using System.Reflection;

namespace Protium.Repository.Mapping
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile :  Profile
    {
        public MappingProfile()
        {
            CreateMap<Driver, DriverDto>().ReverseMap();
        }
    }

    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            return mapperConfig.CreateMapper();
        }
    }
}