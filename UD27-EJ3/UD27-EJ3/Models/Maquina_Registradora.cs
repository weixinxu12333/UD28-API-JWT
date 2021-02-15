using System.Collections.Generic;

namespace UD27_EJ3.Models
{
    public class Maquina_Registradora
    {
        public int Codigo { get; set; }
        public int Piso { get; set; }

        public ICollection<Venta> Ventas { get; set; }
    }
}
