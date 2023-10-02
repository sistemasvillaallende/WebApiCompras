using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiCompras.Entities
{
    public class Surtido : DALBase
    {
        public int Id { get; set; }
        public int IdInsumo { get; set; }
        public string Entidad { get; set; }
        public string Nota { get; set; }
        public DateTime Fecha { get; set; }
        public string Llaves { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }
        public int IdSEctor { get; set; }

        public Surtido()
        {
            Id = 0;
            IdInsumo = 0;
            Entidad = string.Empty;
            Nota = string.Empty;
            Fecha = DateTime.Now;
            Llaves = string.Empty;
            Activo = false;
            IdUsuario = 0;
            IdSEctor = 0;
        }

        private static List<Surtido> mapeo(SqlDataReader dr)
        {
            List<Surtido> lst = new List<Surtido>();
            Surtido obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int IdInsumo = dr.GetOrdinal("IdInsumo");
                int Entidad = dr.GetOrdinal("Entidad");
                int Nota = dr.GetOrdinal("Nota");
                int Fecha = dr.GetOrdinal("Fecha");
                int Llaves = dr.GetOrdinal("Llaves");
                int Activo = dr.GetOrdinal("Activo");
                int IdUsuario = dr.GetOrdinal("IdUsuario");
                int IdSEctor = dr.GetOrdinal("IdSEctor");
                while (dr.Read())
                {
                    obj = new Surtido();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(IdInsumo)) { obj.IdInsumo = dr.GetInt32(IdInsumo); }
                    if (!dr.IsDBNull(Entidad)) { obj.Entidad = dr.GetString(Entidad); }
                    if (!dr.IsDBNull(Nota)) { obj.Nota = dr.GetString(Nota); }
                    if (!dr.IsDBNull(Fecha)) { obj.Fecha = dr.GetDateTime(Fecha); }
                    if (!dr.IsDBNull(Llaves)) { obj.Llaves = dr.GetString(Llaves); }
                    if (!dr.IsDBNull(Activo)) { obj.Activo = dr.GetBoolean(Activo); }
                    if (!dr.IsDBNull(IdUsuario)) { obj.IdUsuario = dr.GetInt32(IdUsuario); }
                    if (!dr.IsDBNull(IdSEctor)) { obj.IdSEctor = dr.GetInt32(IdSEctor); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Surtido> read()
        {
            try
            {
                List<Surtido> lst = new List<Surtido>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Surtido";
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

        public static Surtido getByPk(
        int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Surtido WHERE");
                sql.AppendLine("Id = @Id");
                Surtido obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Surtido> lst = mapeo(dr);
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

        public static int insert(Surtido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Surtido(");
                sql.AppendLine("IdInsumo");
                sql.AppendLine(", Entidad");
                sql.AppendLine(", Nota");
                sql.AppendLine(", Fecha");
                sql.AppendLine(", Llaves");
                sql.AppendLine(", Activo");
                sql.AppendLine(", IdUsuario");
                sql.AppendLine(", IdSEctor");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@IdInsumo");
                sql.AppendLine(", @Entidad");
                sql.AppendLine(", @Nota");
                sql.AppendLine(", @Fecha");
                sql.AppendLine(", @Llaves");
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
                    cmd.Parameters.AddWithValue("@IdInsumo", obj.IdInsumo);
                    cmd.Parameters.AddWithValue("@Entidad", obj.Entidad);
                    cmd.Parameters.AddWithValue("@Nota", obj.Nota);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@Llaves", obj.Llaves);
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

        public static void update(Surtido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Surtido SET");
                sql.AppendLine("IdInsumo=@IdInsumo");
                sql.AppendLine(", Entidad=@Entidad");
                sql.AppendLine(", Nota=@Nota");
                sql.AppendLine(", Fecha=@Fecha");
                sql.AppendLine(", Llaves=@Llaves");
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
                    cmd.Parameters.AddWithValue("@IdInsumo", obj.IdInsumo);
                    cmd.Parameters.AddWithValue("@Entidad", obj.Entidad);
                    cmd.Parameters.AddWithValue("@Nota", obj.Nota);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@Llaves", obj.Llaves);
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

        public static void delete(Surtido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Surtido ");
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

