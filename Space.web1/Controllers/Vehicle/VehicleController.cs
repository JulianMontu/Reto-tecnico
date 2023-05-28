using Microsoft.AspNetCore.Mvc;
using Space.Aplication.DTOS;
using Space.Aplication.Services.Vehiculo;

namespace Space.Web.Controllers.Vehicle
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        [HttpGet(Name = "GetVehicle")]
        public VehicleDTO GetVehicle()
        {
            VehiculoServices vehiculoServices = new VehiculoServices();

            return vehiculoServices.GetSpacecraft();
        }

    }
}
