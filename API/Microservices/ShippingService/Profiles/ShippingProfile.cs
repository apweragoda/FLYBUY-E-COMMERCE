using AutoMapper;
using ShippingService.Dtos;
using ShippingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Profiles
{
    public class ShippingProfile : Profile
    {
        public ShippingProfile()
        {
            CreateMap<Shipping, ShippingReadDto>();
            CreateMap<ShippingCreateDto, Shipping>();
        }
    }
}
