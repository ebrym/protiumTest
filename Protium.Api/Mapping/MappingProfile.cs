
using Autofac;
using AutoMapper;
using Protium.Api.Models.Request;
using Protium.Api.Models.Response;
using Protium.Data.Entity;
using Protium.Repository.Dto;
using Protium.Repository.Interface;
using System;
using System.Linq;
using System.Reflection;

namespace Protium.Api.Mapping
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
            CreateMap<DriverDto, CreateDriverRequestModel>().ReverseMap();
            CreateMap<DriverDto, DriverRequestModel>().ReverseMap();
            CreateMap<DriverDto, DriverResponseModel>().ReverseMap();


            CreateMap<Shipment, ShipmentDto>().ReverseMap();
            CreateMap<ShipmentDto, CreateShipmentRequestModel>().ReverseMap();
            CreateMap<ShipmentDto, ShipmentRequestModel>().ReverseMap();
            CreateMap<ShipmentDto, ShipmentResponseModel>().ReverseMap();
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