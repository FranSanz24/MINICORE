namespace MINICORE.ApiService.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
    }
}
