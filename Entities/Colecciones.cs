using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiCompras.Entities
{
    public class Colecciones : DALBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Versionado { get; set; }
        public string Coleccion { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }
        public int IdSEctor { get; set; }

        public Colecciones()
        {
            Id = 0;
            Nombre = string.Empty;
            Versionado = string.Empty;
            Coleccion = string.Empty;
            Activo = false;
            IdUsuario = 0;
            IdSEctor = 0;
        }

        private static List<Colecciones> mapeo(SqlDataReader dr)
        {
            List<Colecciones> lst = new List<Colecciones>();
            Colecciones obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int Nombre = dr.GetOrdinal("Nombre");
                int Versionado = dr.GetOrdinal("Versionado");
                int Coleccion = dr.GetOrdinal("Coleccion");
                int Activo = dr.GetOrdinal("Activo");
                int IdUsuario = dr.GetOrdinal("IdUsuario");
                int IdSEctor = dr.GetOrdinal("IdSEctor");
                while (dr.Read())
                {
                    obj = new Colecciones();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(Versionado)) { obj.Versionado = dr.GetString(Versionado); }
                    if (!dr.IsDBNull(Coleccion)) { obj.Coleccion = dr.GetString(Coleccion); }
                    if (!dr.IsDBNull(Activo)) { obj.Activo = dr.GetBoolean(Activo); }
                    if (!dr.IsDBNull(IdUsuario)) { obj.IdUsuario = dr.GetInt32(IdUsuario); }
                    if (!dr.IsDBNull(IdSEctor)) { obj.IdSEctor = dr.GetInt32(IdSEctor); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Colecciones> read()
        {
            try
            {
                List<Colecciones> lst = new List<Colecciones>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Colecciones";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Colecciones getByPk(
        int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Colecciones WHERE");
                sql.AppendLine("Id = @Id");
                Colecciones obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Colecciones> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(Colecciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Colecciones(");
                sql.AppendLine("Nombre");
                sql.AppendLine(", Versionado");
                sql.AppendLine(", Coleccion");
                sql.AppendLine(", Activo");
                sql.AppendLine(", IdUsuario");
                sql.AppendLine(", IdSEctor");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nombre");
                sql.AppendLine(", @Versionado");
                sql.AppendLine(", @Coleccion");
                sql.AppendLine(", @Activo");
                sql.AppendLine(", @IdUsuario");
                sql.AppendLine(", @IdSEctor");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Versionado", obj.Versionado);
                    cmd.Parameters.AddWithValue("@Coleccion", obj.Coleccion);
                    cmd.Parameters.AddWithValue("@Activo", obj.Activo);
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdSEctor", obj.IdSEctor);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Colecciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Colecciones SET");
                sql.AppendLine("Nombre=@Nombre");
                sql.AppendLine(", Versionado=@Versionado");
                sql.AppendLine(", Coleccion=@Coleccion");
                sql.AppendLine(", Activo=@Activo");
                sql.AppendLine(", IdUsuario=@IdUsuario");
                sql.AppendLine(", IdSEctor=@IdSEctor");
                sql.AppendLine("WHERE");
                sql.AppendLine("Id=@Id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Versionado", obj.Versionado);
                    cmd.Parameters.AddWithValue("@Coleccion", obj.Coleccion);
                    cmd.Parameters.AddWithValue("@Activo", obj.Activo);
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdSEctor", obj.IdSEctor);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Colecciones obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Colecciones ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Id=@Id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

