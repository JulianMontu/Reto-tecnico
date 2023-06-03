using Space.Aplication.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Aplication.Interfaces
{
    public interface IVehiculoServices
    {
        public List<VehicleDTO> GetVehiculo();
        public SpacecraftDTO GetSpacecraft();
        public VehicleDTO CreateVehicle(VehicleDTO vehicleDTO);
        public VehicleDTO UpdateVehicle(int vehicleId, VehicleDTO updatedVehicleDTO);
        public void DeleteVehiculo(int id);

    }
}
