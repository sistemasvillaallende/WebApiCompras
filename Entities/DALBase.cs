using System.Data.SqlClient;

namespace WebApiCompras.Entities
{
    public class DALBase
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                //return new SqlConnection("Data Source=10.11.15.107;Initial Catalog=SIIMVA;User ID=general");
                return new SqlConnection("Data Source=10.0.0.8;Initial Catalog=SIIMVA;User ID=general");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
