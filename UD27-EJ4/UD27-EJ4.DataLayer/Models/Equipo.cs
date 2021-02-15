using System;
using System.Collections.Generic;
using System.Text;

namespace UD27_EJ4.DataLayer.Models
{
    public class Equipo
    {
        public string NumSerie { get; set; }
        public string Nombre { get; set; }
        public Facultad Facultad { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
