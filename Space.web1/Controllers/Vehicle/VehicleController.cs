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

        [HttpPost(Name = "CreateVehicle")]
        public ActionResult<VehicleDTO> CreateVehicle(VehicleDTO vehicleDTO)
        {
            // Validar y procesar los datos recibidos

            // Llamar al servicio para crear el vehículo
            var createdVehicle = _vehiculoServices.CreateVehicle(vehicleDTO);

            // Devolver una respuesta adecuada
            if (createdVehicle != null)
            {
                return CreatedAtAction("GetVehicle", new { id = createdVehicle.Id }, createdVehicle);
            }
            else
            {
                return BadRequest("No se pudo crear el vehículo");
            }
        }

        [HttpPut("{id}", Name = "UpdateVehicle")]
        public ActionResult<VehicleDTO> UpdateVehicle(int id, [FromBody] VehicleDTO updatedVehicleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            try
            {
                var updatedVehicle = _vehiculoServices.UpdateVehicle(id, updatedVehicleDTO);
                return Ok(updatedVehicle);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the vehicle.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteVehicle")]
        public IActionResult DeleteVehicle(int id)
        {
            try
            {
                _vehiculoServices.DeleteVehiculo(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the vehicle.");
            }
        }


    }
}
