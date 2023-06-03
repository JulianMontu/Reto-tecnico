using AutoMapper;
using Space.Aplication.DTOS;
using Space.Aplication.Interfaces;
using Space.Infrastructure.Persistencia.Contexts;
using Space.Infrastructure.Persistencia.Contexts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Aplication.Services.Vehiculo
{
    public class VehiculoServices : IVehiculoServices
    {
        private readonly SpaceContext _context;
        private readonly IMapper _mapper;
        

        public VehiculoServices(SpaceContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<VehicleDTO> GetVehiculo()
        {
            var vehiculos = _context.Vehiculos.ToList();
            var vehiculosDTO = _mapper.Map<List<VehicleDTO>>(vehiculos);

            return vehiculosDTO;
        }

        public SpacecraftDTO GetSpacecraft()
        {
            SpacecraftDTO spacecraftDTO = new SpacecraftDTO();
            spacecraftDTO.Id = 2;
            spacecraftDTO.Name = "Test";
            spacecraftDTO.MaxSpeed = 10;
            spacecraftDTO.Color = "red";
            spacecraftDTO.IsTripulate = 1;
            spacecraftDTO.PhotovoltaicCells = "photp";
            return spacecraftDTO;
        }
    }
}
