using System.Collections.Generic;

namespace UD27_EJ1.Models
{
    public class Pieza
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<Suministra> Suministras { get; set; }

    }
}
