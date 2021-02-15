using System.Collections.Generic;

namespace UD27_EJ3.Models
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public ICollection<Venta> Ventas { get; set; }
    }
}
