using System;
using System.Collections.Generic;
using System.Text;

namespace UD27_EJ4.DataLayer.Models
{
    public class Facultad
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public ICollection<Investigador> Investigadores { get; set; }
        public ICollection<Equipo> Equipos { get; set; }
    }
}
