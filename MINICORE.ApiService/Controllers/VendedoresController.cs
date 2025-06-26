using Microsoft.AspNetCore.Mvc;
using MINICORE.ApiService.Data;
using MINICORE.ApiService.Models;


namespace MINICORE.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear vendedor
        [HttpPost]
        public ActionResult<Vendedor> CrearVendedor([FromBody] Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(CrearVendedor), new { id = vendedor.Id }, vendedor);
        }

        // Obtener todos los vendedores
        [HttpGet]
        public ActionResult<IEnumerable<Vendedor>> ObtenerVendedores()
        {
            var vendedores = _context.Vendedores.ToList();
            return Ok(vendedores);
        }

        // Obtener un vendedor por Id
        [HttpGet("{id}")]
        public ActionResult<Vendedor> ObtenerVendedor(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return Ok(vendedor);
        }

        // Actualizar un vendedor
        [HttpPut("{id}")]
        public ActionResult<Vendedor> ActualizarVendedor(int id, [FromBody] Vendedor vendedorActualizado)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            vendedor.Nombre = vendedorActualizado.Nombre;
            vendedor.Email = vendedorActualizado.Email;

            _context.SaveChanges();

            return Ok(vendedor);
        }

        // Eliminar un vendedor
        [HttpDelete("{id}")]
        public ActionResult EliminarVendedor(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
