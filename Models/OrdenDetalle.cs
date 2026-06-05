namespace Web_Inventario.Models
{
    public class OrdenDetalle
    {
        public int OrdenDetalleId { get; set; }

        public int OrdenCompraId { get; set; }
        public OrdenCompra OrdenCompra { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
