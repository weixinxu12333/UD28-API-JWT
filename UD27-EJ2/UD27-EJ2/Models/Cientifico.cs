using System.Collections.Generic;

namespace UD27_EJ2.Models
{
    public class Cientifico
    {
        public string Dni { get; set; }
        public string NomApels { get; set; }

        public ICollection<Asignado_a> Asignado_As { get; set; }
    }
}
