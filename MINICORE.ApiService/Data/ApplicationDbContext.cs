using Microsoft.EntityFrameworkCore;
using MINICORE.ApiService.Models;

namespace MINICORE.ApiService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Regla> Reglas { get; set; }
    }
}
