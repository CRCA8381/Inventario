using Web_Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Inventario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<OrdenCompra> OrdenesCompra{ get; set; }
        public DbSet<OrdenDetalle> OrdenesDetalle { get; set; }
    }
}

