using Microsoft.AspNetCore.Mvc;
using MINICORE.ApiService.Models;
using MINICORE.ApiService.Services;
using MINICORE.ApiService.DTos;

namespace MINICORE.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComisionesController : ControllerBase
    {
        private readonly ComisionService _comisionService;

        public ComisionesController(ComisionService comisionService)
        {
            _comisionService = comisionService;
        }

        // Calcular la comisión para un vendedor en un rango de fechas
        [HttpPost("calcular")]
        public ActionResult<ComisionResponseDTO> CalcularComision([FromBody] ComisionRequestDTO request)
        {
            // Validar que las fechas son correctas
            if (request.FechaInicio > request.FechaFin)
            {
                return BadRequest("La fecha de inicio no puede ser posterior a la fecha de fin.");
            }

            // Llamar al servicio para calcular la comisión
            decimal comision = _comisionService.CalcularComision(request.VendedorId, request.FechaInicio, request.FechaFin);

            if (comision == 0)
            {
                return NotFound("No se encontraron ventas o no se encontró una regla de comisión para las fechas proporcionadas.");
            }

            // Retornar la comisión calculada en un DTO
            var response = new ComisionResponseDTO
            {
                Comision = comision
            };

            return Ok(response);
        }
    }
}
