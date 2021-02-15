using System;
using System.Collections.Generic;
using System.Text;

namespace UD27_EJ4.DataLayer.Models
{
    public class Investigador
    {
        public string DNI { get; set; }
        public string NomApels { get; set; }
        public Facultad Facultad { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
