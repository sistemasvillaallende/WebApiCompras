using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiCompras.Entities
{
    public class Insumos : DALBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Nota { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdOficina { get; set; }
        public int IdDireccion { get; set; }
        public int IdSecretaria { get; set; }

        public Insumos()
        {
            Id = 0;
            Nombre = string.Empty;
            Activo = false;
            Nota = string.Empty;
            Fecha = DateTime.Now;
            IdUsuario = 0;
            IdOficina = 0;
            IdDireccion = 0;
            IdSecretaria = 0;
        }

        private static List<Insumos> mapeo(SqlDataReader dr)
        {
            List<Insumos> lst = new List<Insumos>();
            Insumos obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int Nombre = dr.GetOrdinal("Nombre");
                int Activo = dr.GetOrdinal("Activo");
                int Nota = dr.GetOrdinal("Nota");
                int Fecha = dr.GetOrdinal("Fecha");
                int IdUsuario = dr.GetOrdinal("IdUsuario");
                int IdOficina = dr.GetOrdinal("IdOficina");
                int IdDireccion = dr.GetOrdinal("IdDireccion");
                int IdSecretaria = dr.GetOrdinal("IdSecretaria");
                while (dr.Read())
                {
                    obj = new Insumos();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(Activo)) { obj.Activo = dr.GetBoolean(Activo); }
                    if (!dr.IsDBNull(Nota)) { obj.Nota = dr.GetString(Nota); }
                    if (!dr.IsDBNull(Fecha)) { obj.Fecha = dr.GetDateTime(Fecha); }
                    if (!dr.IsDBNull(IdUsuario)) { obj.IdUsuario = dr.GetInt32(IdUsuario); }
                    if (!dr.IsDBNull(IdOficina)) { obj.IdOficina = dr.GetInt32(IdOficina); }
                    if (!dr.IsDBNull(IdDireccion)) { obj.IdDireccion = dr.GetInt32(IdDireccion); }
                    if (!dr.IsDBNull(IdSecretaria)) { obj.IdSecretaria = dr.GetInt32(IdSecretaria); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Insumos> read()
        {
            try
            {
                List<Insumos> lst = new List<Insumos>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Insumos";
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

        public static Insumos getByPk(
        int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Insumos WHERE");
                sql.AppendLine("Id = @Id");
                Insumos obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Insumos> lst = mapeo(dr);
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

        public static int insert(Insumos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Insumos(");
                sql.AppendLine("Nombre");
                sql.AppendLine(", Activo");
                sql.AppendLine(", Nota");
                sql.AppendLine(", Fecha");
                sql.AppendLine(", IdUsuario");
                sql.AppendLine(", IdOficina");
                sql.AppendLine(", IdDireccion");
                sql.AppendLine(", IdSecretaria");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nombre");
                sql.AppendLine(", @Activo");
                sql.AppendLine(", @Nota");
                sql.AppendLine(", @Fecha");
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
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Activo", obj.Activo);
                    cmd.Parameters.AddWithValue("@Nota", obj.Nota);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
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

        public static void update(Insumos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Insumos SET");
                sql.AppendLine("Nombre=@Nombre");
                sql.AppendLine(", Activo=@Activo");
                sql.AppendLine(", Nota=@Nota");
                sql.AppendLine(", Fecha=@Fecha");
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
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Activo", obj.Activo);
                    cmd.Parameters.AddWithValue("@Nota", obj.Nota);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
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

        public static void delete(Insumos obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Insumos ");
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

