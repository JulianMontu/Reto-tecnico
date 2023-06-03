using AutoMapper;
using Space.Aplication.DTOS;
using Space.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Infrastructure.Persistencia.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Vehiculo, VehicleDTO>().ReverseMap();
        }
    }
}
