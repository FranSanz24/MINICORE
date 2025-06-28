using MINICORE.ApiService.Data;
using Microsoft.EntityFrameworkCore;


namespace MINICORE.ApiService.Services
{
    public class ComisionService
    {
        private readonly ApplicationDbContext _context;

        public ComisionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public decimal CalcularComision(int vendedorId, DateTime fechaInicio, DateTime fechaFin)
        {
            // 1. Traer ventas del vendedor en el rango
            var ventas = _context.Ventas
                .Where(v => v.VendedorId == vendedorId
                         && v.Fecha >= fechaInicio
                         && v.Fecha <= fechaFin)
                .ToList();

            if (!ventas.Any())
                return 0;

            // 2. Cargar todas las reglas de una vez
            var reglas = _context.Reglas.ToList();
            decimal totalComision = 0;

            // 3. Para cada venta, buscar la regla aplicable
            foreach (var venta in ventas)
            {
                var regla = reglas
                    .FirstOrDefault(r => venta.Fecha >= r.FechaInicio
                                      && venta.Fecha <= r.FechaFin);

                if (regla == null)
                    continue; // o decide devolver error si falta regla

                // 4. Aplicar porcentaje (divide por 100 si guardas '5' para 5%)
                totalComision += venta.Monto * regla.Porcentaje / 100;
            }

            return totalComision;
        }


    }
}
