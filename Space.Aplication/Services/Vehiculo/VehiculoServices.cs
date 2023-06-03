using AutoMapper;
using Space.Aplication.DTOS;
using Space.Aplication.Interfaces;
using Space.Domain.Entities;
using Space.Infrastructure.Persistencia.Contexts;
using Space.Infrastructure.Persistencia.Contexts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space.Domain.Entities;

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

        public VehicleDTO CreateVehicle(VehicleDTO vehicleDTO)
        {
            // Realizar las validaciones y lógica de negocio necesarias

            // Mapear el DTO a la entidad del vehículo
            var vehicleEntity = _mapper.Map<Space.Domain.Entities.Vehiculo>(vehicleDTO);

            // Guardar la entidad del vehículo en el contexto
            _context.Vehiculos.Add(vehicleEntity);
            _context.SaveChanges();

            // Mapear la entidad del vehículo de vuelta a un DTO
            var createdVehicleDTO = _mapper.Map<VehicleDTO>(vehicleEntity);

            return createdVehicleDTO;
        }

        public VehicleDTO UpdateVehicle(int vehicleId, VehicleDTO updatedVehicleDTO)
        {
            // Buscar el vehículo por su ID en la base de datos
            var vehicleEntity = _context.Vehiculos.FirstOrDefault(v => v.Id == vehicleId);

            if (vehicleEntity == null)
            {
                // El vehículo no existe, se puede lanzar una excepción o manejar el error de alguna otra forma
                throw new Exception("Vehicle not found");
            }

            // Actualizar las propiedades del vehículo con los datos proporcionados en updatedVehicleDTO
            vehicleEntity.Name = updatedVehicleDTO.Name;
            vehicleEntity.Color = updatedVehicleDTO.Color;
            vehicleEntity.IsTripulate = updatedVehicleDTO.IsTripulate;
            vehicleEntity.MaxSpeed = updatedVehicleDTO.MaxSpeed;
            // Actualizar las demás propiedades según sea necesario

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Mapear la entidad del vehículo actualizada de vuelta a un DTO
            var updatedVehicleDto = _mapper.Map<VehicleDTO>(vehicleEntity);

            return updatedVehicleDto;
        }

        public void DeleteVehiculo(int id)
        {
            var vehiculo = _context.Vehiculos.Find(id);

            if (vehiculo == null)
            {
                throw new Exception($"Vehicle with ID {id} not found.");
            }

            _context.Vehiculos.Remove(vehiculo);
            _context.SaveChanges();
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
