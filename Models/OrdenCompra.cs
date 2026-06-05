using System;
using Web_Inventario.Models;
namespace Web_Inventario.Models
{
    public class OrdenCompra
{
    public int OrdenCompraId { get; set; }
    public DateTime Fecha { get; set; }

    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }

    public List<OrdenDetalle> Detalles { get; set; } = new();
}
}
