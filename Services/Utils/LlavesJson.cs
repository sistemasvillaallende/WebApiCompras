using Newtonsoft.Json;
using WebApiCompras.Entities.Soporte;

namespace WebApiCompras.Services.Utils
{
    public class LlavesJson
    {
        public class MiObjeto
        {
            public Llave objLlave { get; set; }

            public MiObjeto()
            {
                objLlave = new Llave();
            }
        }
        public static List<Llave> ConvertirJsonALista(string json)
        {
            try
            {
                // Deserializa la cadena JSON en un objeto MiObjeto.
                MiObjeto objeto = JsonConvert.DeserializeObject<MiObjeto>(json);

                // Crea una listaLlaves de Estado y agrega el objeto Estado al resultado.
                List<Llave> listaLlaves = new List<Llave>();
                listaLlaves.Add(objeto.objLlave);

                return listaLlaves;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al convertir JSON a listaLlaves: " + ex.Message);
                return null; // Manejo de error
            }
        }
        public static string AgregarLlave(int id, string nombre, string tipo,int idRequerimiento, string json = null)
        {
            MiObjeto objeto;

            // Si el JSON es nulo, crea una nueva instancia con la estructura y la fecha actual.
            if (string.IsNullOrEmpty(json))
            {
                objeto = new MiObjeto
                {
                    objLlave = new Llave
                    {
                        Id = id,
                        Nota = nombre,
                        Nombre = tipo,
                        Fecha = DateTime.Parse(DateTime.Now.ToString("MM-dd-yyyy")),
                        IdRequerimiento = idRequerimiento
                    }
                };
            }
            else
            {
                // Si el JSON no es nulo, deserializa el JSON en un objeto C#.
                objeto = JsonConvert.DeserializeObject<MiObjeto>(json);

                // Agrega el nuevo estado al objeto C#.
                Llave nuevaLlave = new Llave
                {
                    Id = id,
                    Nota = nombre,
                    Nombre = tipo,
                    Fecha = DateTime.Parse(DateTime.Now.ToString("MM-dd-yyyy")),
                    IdRequerimiento = idRequerimiento
                };

                objeto.objLlave = nuevaLlave;
            }

            // Vuelve a serializar el objeto C# en JSON y lo devuelve como resultado.
            return JsonConvert.SerializeObject(objeto);
        }
    }
}
