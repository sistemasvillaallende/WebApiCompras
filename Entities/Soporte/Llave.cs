namespace WebApiCompras.Entities.Soporte
{
    public class Llave
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string? Nota { get; set; }
        public int IdRequerimiento { get; set; }

        public Llave()
        {
            Id=0;
            Nombre=string.Empty;
            Fecha = DateTime.Now;
            Nota=string.Empty;
            IdRequerimiento=0;
        }
    }
}
