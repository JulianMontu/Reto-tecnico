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

    }
}
