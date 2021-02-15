namespace UD27_EJ1.Models
{
    public class Suministra
    {
        public int CodigoPieza { get; set; }
        public string IdProveedor { get; set; }
        public int Precio { get; set; }

        public Pieza Pieza { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
