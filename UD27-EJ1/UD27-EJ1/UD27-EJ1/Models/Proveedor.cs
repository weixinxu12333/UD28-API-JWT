using System.Collections.Generic;

namespace UD27_EJ1.Models
{
    public class Proveedor
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Suministra> Suministras { get; set; }
    }
}
