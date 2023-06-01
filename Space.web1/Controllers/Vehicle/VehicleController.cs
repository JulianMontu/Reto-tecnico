using Microsoft.AspNetCore.Mvc;
using Space.Aplication.DTOS;
using Space.Aplication.Services.Vehiculo;

namespace Space.Web.Controllers.Vehicle
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehiculoServices _vehiculoServicio;
        public VehicleController(VehiculoServices vehiculoServicio)
        {
            _vehiculoServicio = vehiculoServicio;
        }

        [HttpGet(Name = "GetVehicle")]
        public ActionResult<IEnumerable<VehicleDTO>> GetVehicle()
        {
            var vehiculosDTO = _vehiculoServicio.GetVehiculo();
            return vehiculosDTO;
        }
        //public VehicleDTO GetVehicle()
        //{
        //    VehiculoServices vehiculoServices = new VehiculoServices();

        //    return vehiculoServices.GetSpacecraft();
        //}

    }
}
