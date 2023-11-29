using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCompras.Entities;
using WebApiCompras.Entities.Soporte;

namespace WebApiCompras.Entities
{
    public class PresupuestoOrdenCompra : DALBase
    {
        #region propiedades
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
        public int IdOrdenCompra { get; set; }
        public string NombreProveedor { get; set; }
        public List<DetallePresupuestoOrdenCompra> Items { get; set; }
        #endregion

        public PresupuestoOrdenCompra()
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
            IdOrdenCompra = 0;
            NombreProveedor = string.Empty;
            Items = new List<DetallePresupuestoOrdenCompra>();
        }

        #region metodos
        private static List<PresupuestoOrdenCompra> mapeo(SqlDataReader dr)
        {
            List<PresupuestoOrdenCompra> lst = new List<PresupuestoOrdenCompra>();
            PresupuestoOrdenCompra obj;
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
                int IdOrdenCompra = dr.GetOrdinal("IdOrdenCompra");
                int NombreProveedor = dr.GetOrdinal("NombreProveedor");
                while (dr.Read())
                {
                    obj = new PresupuestoOrdenCompra();
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
                    if (!dr.IsDBNull(IdOrdenCompra)) { obj.IdOrdenCompra = dr.GetInt32(IdOrdenCompra); }
                    if (!dr.IsDBNull(NombreProveedor)) { obj.NombreProveedor = dr.GetString(NombreProveedor); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PresupuestoOrdenCompra> read()
        {
            try
            {
                List<PresupuestoOrdenCompra> lst = new List<PresupuestoOrdenCompra>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM PresupuestoOrdenCompra";
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

        public static PresupuestoOrdenCompra getByPk(int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM PresupuestoOrdenCompra WHERE");
                sql.AppendLine("Id = @Id");
                PresupuestoOrdenCompra obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PresupuestoOrdenCompra> lst = mapeo(dr);
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

        public static int insert(PresupuestoOrdenCompra obj)
        {
            try
            {
                #region stringSql
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PresupuestoOrdenCompra(");
                sql.AppendLine("Fecha");
                sql.AppendLine(", Llaves");
                sql.AppendLine(", Nota");
                sql.AppendLine(", Estado");
                sql.AppendLine(", Historia");
                sql.AppendLine(", IdUsuario");
                sql.AppendLine(", IdOficina");
                sql.AppendLine(", IdDireccion");
                sql.AppendLine(", IdSecretaria");
                sql.AppendLine(", IdOrdenCompra");
                sql.AppendLine(", NombreProveedor");
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
                sql.AppendLine(", @IdOrdenCompra");
                sql.AppendLine(", @NombreProveedor");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                #endregion
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
                    cmd.Parameters.AddWithValue("@IdOrdenCompra", obj.IdOrdenCompra);
                    cmd.Parameters.AddWithValue("@NombreProveedor", obj.NombreProveedor);
                    cmd.Connection.Open();

                    obj.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    
                    DetallePresupuestoOrdenCompra.insertList(obj.Items, obj.Id);
                    
                    return obj.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PresupuestoOrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PresupuestoOrdenCompra SET");
                sql.AppendLine("Fecha=@Fecha");
                sql.AppendLine(", Llaves=@Llaves");
                sql.AppendLine(", Nota=@Nota");
                sql.AppendLine(", Estado=@Estado");
                sql.AppendLine(", Historia=@Historia");
                sql.AppendLine(", IdUsuario=@IdUsuario");
                sql.AppendLine(", IdOficina=@IdOficina");
                sql.AppendLine(", IdDireccion=@IdDireccion");
                sql.AppendLine(", IdSecretaria=@IdSecretaria");
                sql.AppendLine(", IdOrdenCompra=@IdOrdenCompra");
                sql.AppendLine(", NombreProveedor=@NombreProveedor");
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
                    cmd.Parameters.AddWithValue("@IdOrdenCompra", obj.IdOrdenCompra);
                    cmd.Parameters.AddWithValue("@NombreProveedor", obj.NombreProveedor);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(PresupuestoOrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PresupuestoOrdenCompra ");
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

        public static List<PresupuestoOrdenCompra> getByUsuario(int idUsuario)
        {
            try
            {
                List<PresupuestoOrdenCompra> lst = new List<PresupuestoOrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM PresupuestoOrdenCompra WHERE");
                sql.AppendLine("IdUsuario = @IdUsuario");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
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

        public static List<PresupuestoOrdenCompra> getByOficina(int idOficina)
        {
            try
            {
                List<PresupuestoOrdenCompra> lst = new List<PresupuestoOrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM PresupuestoOrdenCompra WHERE");
                sql.AppendLine("IdOficina = @IdOficina");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdOficina", idOficina);
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

        public static List<PresupuestoOrdenCompra> getByDireccion(int idDireccion)
        {
            try
            {
                List<PresupuestoOrdenCompra> lst = new List<PresupuestoOrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM PresupuestoOrdenCompra WHERE");
                sql.AppendLine("IdDireccion = @IdDireccion");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdDireccion", idDireccion);
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

        public static List<PresupuestoOrdenCompra> getBySecretaria(int idSecretaria)
        {
            try
            {
                List<PresupuestoOrdenCompra> lst = new List<PresupuestoOrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM PresupuestoOrdenCompra WHERE");
                sql.AppendLine("IdSecretaria = @IdSecretaria");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdSecretaria", idSecretaria);
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

        public static List<PresupuestoOrdenCompra> getByOrdenCompra(int IdOrdenCompra)
        {
            try
            {
                List<PresupuestoOrdenCompra> lst = new List<PresupuestoOrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM PresupuestoOrdenCompra WHERE");
                sql.AppendLine("IdOrdenCompra = @IdOrdenCompra");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdOrdenCompra", IdOrdenCompra);
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
        #endregion
    }
}

