using System.Collections.Generic;

namespace UD27_EJ3.Models
{
    public class Cajero
    {
        public int Codigo { get; set; }
        public string NomApels { get; set; }

        public ICollection<Venta> Ventas { get; set; }
    }
}
