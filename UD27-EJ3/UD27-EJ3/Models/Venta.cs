namespace UD27_EJ3.Models
{
    public class Venta
    {
        public int Cajero { get; set; }
        public int Maquina { get; set; }
        public int Producto { get; set; }

        public Cajero Cajeros { get; set; }
        public Maquina_Registradora Maquinas { get; set; }
        public Producto Productos { get; set; }
    }
}
