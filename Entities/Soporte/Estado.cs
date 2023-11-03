namespace WebApiCompras.Entities.Soporte
{
    public class Estado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string fecha { get; set; }

        public Estado()
        {
            id = 0;
            nombre = String.Empty;
            tipo = string.Empty;
            fecha = String.Empty;
        }
    }
}
