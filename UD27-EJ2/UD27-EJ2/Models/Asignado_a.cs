namespace UD27_EJ2.Models
{
    public class Asignado_a
    {
        public string Cientifico { get; set; }
        public string Proyecto { get; set; }

        public Cientifico Cientificos { get; set; }
        public Proyecto Proyectos { get; set; }
    }
}
