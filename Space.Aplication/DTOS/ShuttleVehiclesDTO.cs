using Space.Aplication.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Domain.Entities
{
    public class ShuttleVehiclesDTO : VehicleDTO
    {
        public decimal CapacityTransport { get; set; }
    }
}
