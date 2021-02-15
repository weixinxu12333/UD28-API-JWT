using System;
using System.Collections.Generic;
using System.Text;

namespace UD27_EJ4.DataLayer.Models
{
    public class Reserva
    {
        public string Investigador_DNI { get; set; }
        public string Equipo_NumSerie { get; set; }

        public DateTime Comienzo { get; set; }
        public DateTime Fin { get; set; }

        public Investigador Investigador { get; set; }
        public Equipo Equipo { get; set; }
    }
}
