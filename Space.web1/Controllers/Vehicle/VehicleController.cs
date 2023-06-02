using Microsoft.AspNetCore.Mvc;
using Space.Aplication.DTOS;
using Space.Aplication.Interfaces;
using Space.Aplication.Services.Vehiculo;

namespace Space.Web.Controllers.Vehicle
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IVehiculoServices _vehiculoServices;
        public VehicleController(IVehiculoServices vehiculoServicio)
        {
            _vehiculoServices = vehiculoServicio;
        }

        [HttpGet(Name = "GetVehicle")]
        public ActionResult<IEnumerable<VehicleDTO>> GetVehicle()
        {
            var vehiculosDTO = _vehiculoServices.GetVehiculo();
            return vehiculosDTO;
        }
        //public VehicleDTO GetVehicle()
        //{
        //    VehiculoServices vehiculoServices = new VehiculoServices();

        //    return vehiculoServices.GetSpacecraft();
        //}

    }
}
