using Microsoft.AspNetCore.Mvc;
using MINICORE.ApiService.Data;
using MINICORE.ApiService.DTos;
using MINICORE.ApiService.Models;

namespace MINICORE.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear una venta
        [HttpPost]
        public ActionResult<Venta> CrearVenta([FromBody] Venta venta)
        {
            // Buscar el vendedor en la base de datos usando el VendedorId
            var vendedor = _context.Vendedores.Find(venta.VendedorId);
            if (vendedor == null)
            {
                return BadRequest("Vendedor no encontrado.");
            }

            // Crear la venta asociada con el vendedor
            _context.Ventas.Add(venta);
            _context.SaveChanges();

            return CreatedAtAction(nameof(CrearVenta), new { id = venta.Id }, venta);
        }


    }
}
