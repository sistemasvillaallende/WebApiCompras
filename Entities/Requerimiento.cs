using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiCompras.Entities
{
    public class Requerimiento : DALBase
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Llaves { get; set; }
        public string Nota { get; set; }
        public string Estado { get; set; }
        public string Historia { get; set; }
        public int IdUsuario { get; set; }
        public int IdOficina { get; set; }
        public int IdDireccion { get; set; }
        public int IdSecretaria { get; set; }

        public Requerimiento()
        {
            Id = 0;
            Fecha = DateTime.Now;
            Llaves = string.Empty;
            Nota = string.Empty;
            Estado = string.Empty;
            Historia = string.Empty;
            IdUsuario = 0;
            IdOficina = 0;
            IdDireccion = 0;
            IdSecretaria = 0;
        }

        private static List<Requerimiento> mapeo(SqlDataReader dr)
        {
            List<Requerimiento> lst = new List<Requerimiento>();
            Requerimiento obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int Fecha = dr.GetOrdinal("Fecha");
                int Llaves = dr.GetOrdinal("Llaves");
                int Nota = dr.GetOrdinal("Nota");
                int Estado = dr.GetOrdinal("Estado");
                int Historia = dr.GetOrdinal("Historia");
                int IdUsuario = dr.GetOrdinal("IdUsuario");
                int IdOficina = dr.GetOrdinal("IdOficina");
                int IdDireccion = dr.GetOrdinal("IdDireccion");
                int IdSecretaria = dr.GetOrdinal("IdSecretaria");
                while (dr.Read())
                {
                    obj = new Requerimiento();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(Fecha)) { obj.Fecha = dr.GetDateTime(Fecha); }
                    if (!dr.IsDBNull(Llaves)) { obj.Llaves = dr.GetString(Llaves); }
                    if (!dr.IsDBNull(Nota)) { obj.Nota = dr.GetString(Nota); }
                    if (!dr.IsDBNull(Estado)) { obj.Estado = dr.GetString(Estado); }
                    if (!dr.IsDBNull(Historia)) { obj.Historia = dr.GetString(Historia); }
                    if (!dr.IsDBNull(IdUsuario)) { obj.IdUsuario = dr.GetInt32(IdUsuario); }
                    if (!dr.IsDBNull(IdOficina)) { obj.IdOficina = dr.GetInt32(IdOficina); }
                    if (!dr.IsDBNull(IdDireccion)) { obj.IdDireccion = dr.GetInt32(IdDireccion); }
                    if (!dr.IsDBNull(IdSecretaria)) { obj.IdSecretaria = dr.GetInt32(IdSecretaria); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Requerimiento> read()
        {
            try
            {
                List<Requerimiento> lst = new List<Requerimiento>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Requerimiento";
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

        public static Requerimiento getByPk(
        int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Requerimiento WHERE");
                sql.AppendLine("Id = @Id");
                Requerimiento obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Requerimiento> lst = mapeo(dr);
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

        public static int insert(Requerimiento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Requerimiento(");
                sql.AppendLine("Fecha");
                sql.AppendLine(", Llaves");
                sql.AppendLine(", Nota");
                sql.AppendLine(", Estado");
                sql.AppendLine(", Historia");
                sql.AppendLine(", IdUsuario");
                sql.AppendLine(", IdOficina");
                sql.AppendLine(", IdDireccion");
                sql.AppendLine(", IdSecretaria");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Fecha");
                sql.AppendLine(", @Llaves");
                sql.AppendLine(", @Nota");
                sql.AppendLine(", @Estado");
                sql.AppendLine(", @Historia");
                sql.AppendLine(", @IdUsuario");
                sql.AppendLine(", @IdOficina");
                sql.AppendLine(", @IdDireccion");
                sql.AppendLine(", @IdSecretaria");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@Llaves", obj.Llaves);
                    cmd.Parameters.AddWithValue("@Nota", obj.Nota);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@Historia", obj.Historia);
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdOficina", obj.IdOficina);
                    cmd.Parameters.AddWithValue("@IdDireccion", obj.IdDireccion);
                    cmd.Parameters.AddWithValue("@IdSecretaria", obj.IdSecretaria);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Requerimiento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Requerimiento SET");
                sql.AppendLine("Fecha=@Fecha");
                sql.AppendLine(", Llaves=@Llaves");
                sql.AppendLine(", Nota=@Nota");
                sql.AppendLine(", Estado=@Estado");
                sql.AppendLine(", Historia=@Historia");
                sql.AppendLine(", IdUsuario=@IdUsuario");
                sql.AppendLine(", IdOficina=@IdOficina");
                sql.AppendLine(", IdDireccion=@IdDireccion");
                sql.AppendLine(", IdSecretaria=@IdSecretaria");
                sql.AppendLine("WHERE");
                sql.AppendLine("Id=@Id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@Llaves", obj.Llaves);
                    cmd.Parameters.AddWithValue("@Nota", obj.Nota);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@Historia", obj.Historia);
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdOficina", obj.IdOficina);
                    cmd.Parameters.AddWithValue("@IdDireccion", obj.IdDireccion);
                    cmd.Parameters.AddWithValue("@IdSecretaria", obj.IdSecretaria);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Requerimiento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Requerimiento ");
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

