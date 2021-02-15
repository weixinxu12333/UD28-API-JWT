using System.Collections.Generic;

namespace UD27_EJ2.Models
{
    public class Proyecto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Horas { get; set; }

        public ICollection<Asignado_a> Asignado_As { get; set; }
    }
}
