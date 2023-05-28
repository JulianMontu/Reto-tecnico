using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Aplication.DTOS
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IsTripulate { get; set; }
        public string? Color { get; set; }
        public int MaxSpeed { get; set; }
    }
}
