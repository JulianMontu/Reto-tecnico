using Space.Aplication.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Aplication.Services.Vehiculo
{
    public class VehiculoServices
    {
        public VehicleDTO GetVehiculo()
        {
            VehicleDTO vehicle = new VehicleDTO();

            vehicle.Id = 1;
            vehicle.Name = "Test";
            vehicle.MaxSpeed = 10;
            vehicle.Color = "red";
            vehicle.IsTripulate = 1;

            return vehicle;
            
        }

        public SpacecraftDTO GetSpacecraft()
        {
            SpacecraftDTO spacecraftDTO =  new SpacecraftDTO();
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
