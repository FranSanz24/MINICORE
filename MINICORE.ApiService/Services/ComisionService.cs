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
            // Obtener las ventas del vendedor en el rango de fechas
            var ventas = _context.Ventas
                .Where(v => v.VendedorId == vendedorId && v.Fecha >= fechaInicio && v.Fecha <= fechaFin)
                .ToList();

            if (!ventas.Any())
            {
                return 0; // No hay ventas en el rango de fechas
            }

            // Obtener la regla que se aplica al rango de fechas
            var regla = _context.Reglas
                .Where(r => r.FechaInicio <= fechaFin && r.FechaFin >= fechaInicio)
                .FirstOrDefault();

            if (regla == null)
            {
                return 0; // No hay regla para el rango de fechas
            }

            // Calcular la comisión total
            decimal totalVentas = ventas.Sum(v => v.Monto);
            decimal comision = totalVentas * regla.Porcentaje / 100;

            return comision;
        }

    }
}
