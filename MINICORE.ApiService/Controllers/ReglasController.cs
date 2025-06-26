using Microsoft.AspNetCore.Mvc;
using MINICORE.ApiService.Data;
using MINICORE.ApiService.Models;

namespace MINICORE.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReglasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReglasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear una regla
        [HttpPost]
        public ActionResult<Regla> CrearRegla([FromBody] Regla regla)
        {
            _context.Reglas.Add(regla);
            _context.SaveChanges();
            return CreatedAtAction(nameof(CrearRegla), new { id = regla.Id }, regla);
        }

        // Obtener todas las reglas
        [HttpGet]
        public ActionResult<IEnumerable<Regla>> ObtenerReglas()
        {
            var reglas = _context.Reglas.ToList();
            return Ok(reglas);
        }
    }
}
