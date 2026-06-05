using System.ComponentModel.DataAnnotations;

namespace Web_Inventario.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }
        }
    }
