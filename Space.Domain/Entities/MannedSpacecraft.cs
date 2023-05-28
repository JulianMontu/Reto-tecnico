using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Domain.Entities
{
    public class MannedSpacecraft : Vehiculo
    {
        public int CapacityPerson { get; set; }
    }
}
