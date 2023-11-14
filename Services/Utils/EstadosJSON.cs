using Newtonsoft.Json;
using WebApiCompras.Entities.Soporte;

namespace WebApiCompras.Services.Utils
{
    public class EstadosJSON
    {
        public class MiObjeto
        {
            public Estado objEstado { get; set; }

            public MiObjeto()
            { 
                objEstado = new Estado();
            }
        }
        public static List<Estado> ConvertirJsonALista(string json)
        {
            try
            {
                // Deserializa la cadena JSON en un objeto MiObjeto.
                MiObjeto objeto = JsonConvert.DeserializeObject<MiObjeto>(json);

                // Crea una lista de Estado y agrega el objeto Estado al resultado.
                List<Estado> listaEstados = new List<Estado>();
                listaEstados.Add(objeto.objEstado);

                return listaEstados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al convertir JSON a lista: " + ex.Message);
                return null; // Manejo de error
            }
        }
        public static string AgregarEstado(int id, string nombre, string tipo, string? json = null)
        {
            MiObjeto objeto;

            // Si el JSON es nulo, crea una nueva instancia con la estructura y la fecha actual.
            if (string.IsNullOrEmpty(json))
            {
                objeto = new MiObjeto
                {
                    objEstado = new Estado
                    {
                        id = id,
                        nombre = nombre,
                        tipo = tipo,
                        fecha = DateTime.Now.ToString("MM-dd-yyyy")
                    }
                };
            }
            else
            {
                // Si el JSON no es nulo, deserializa el JSON en un objeto C#.
                objeto = JsonConvert.DeserializeObject<MiObjeto>(json);

                // Agrega el nuevo estado al objeto C#.
                Estado nuevoEstado = new Estado
                {
                    id = id,
                    nombre = nombre,
                    tipo = tipo,
                    fecha = DateTime.Now.ToString("MM-dd-yyyy")
                };

                objeto.objEstado = nuevoEstado;
            }

            // Vuelve a serializar el objeto C# en JSON y lo devuelve como resultado.
            return JsonConvert.SerializeObject(objeto);
        }
    }
}
