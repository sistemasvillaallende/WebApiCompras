using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCompras.Entities
{
    public class OrdenCompra : DALBase
    {
        #region propiedades
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Llaves { get; set; }
        public string Nota { get; set; }
        public int IdOrdenPedido { get; set; }
        public string Historia { get; set; }
        public int IdUsuario { get; set; }
        public int IdOficina { get; set; }
        public int IdDireccion { get; set; }
        public int IdSecretaria { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        #endregion

        #region metodos
        public OrdenCompra()
        {
            Id = 0;
            Fecha = DateTime.Now;
            Llaves = string.Empty;
            Nota = string.Empty;
            IdOrdenPedido = 0;
            Historia = string.Empty;
            IdUsuario = 0;
            IdOficina = 0;
            IdDireccion = 0;
            IdSecretaria = 0;
            IdProveedor = 0;
            NombreProveedor = string.Empty;
        }

        private static List<OrdenCompra> mapeo(SqlDataReader dr)
        {
            List<OrdenCompra> lst = new List<OrdenCompra>();
            OrdenCompra obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int Fecha = dr.GetOrdinal("Fecha");
                int Llaves = dr.GetOrdinal("Llaves");
                int Nota = dr.GetOrdinal("Nota");
                int IdOrdenPedido = dr.GetOrdinal("IdOrdenPedido");
                int Historia = dr.GetOrdinal("Historia");
                int IdUsuario = dr.GetOrdinal("IdUsuario");
                int IdOficina = dr.GetOrdinal("IdOficina");
                int IdDireccion = dr.GetOrdinal("IdDireccion");
                int IdSecretaria = dr.GetOrdinal("IdSecretaria");
                int IdProveedor = dr.GetOrdinal("IdProveedor");
                int NombreProveedor = dr.GetOrdinal("NombreProveedor");
                while (dr.Read())
                {
                    obj = new OrdenCompra();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(Fecha)) { obj.Fecha = dr.GetDateTime(Fecha); }
                    if (!dr.IsDBNull(Llaves)) { obj.Llaves = dr.GetString(Llaves); }
                    if (!dr.IsDBNull(Nota)) { obj.Nota = dr.GetString(Nota); }
                    if (!dr.IsDBNull(IdOrdenPedido)) { obj.IdOrdenPedido = dr.GetInt32(IdOrdenPedido); }
                    if (!dr.IsDBNull(Historia)) { obj.Historia = dr.GetString(Historia); }
                    if (!dr.IsDBNull(IdUsuario)) { obj.IdUsuario = dr.GetInt32(IdUsuario); }
                    if (!dr.IsDBNull(IdOficina)) { obj.IdOficina = dr.GetInt32(IdOficina); }
                    if (!dr.IsDBNull(IdDireccion)) { obj.IdDireccion = dr.GetInt32(IdDireccion); }
                    if (!dr.IsDBNull(IdSecretaria)) { obj.IdSecretaria = dr.GetInt32(IdSecretaria); }
                    if (!dr.IsDBNull(IdProveedor)) { obj.IdProveedor = dr.GetInt32(IdProveedor); }
                    if (!dr.IsDBNull(NombreProveedor)) { obj.NombreProveedor = dr.GetString(NombreProveedor); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<OrdenCompra> read()
        {
            try
            {
                List<OrdenCompra> lst = new List<OrdenCompra>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT OrdenCompra.*, Proveedor.Nombre NombreProveedor " +
                        "FROM OrdenCompra " +
                        "INNER JOIN Proveedor ON Proveedor.Id = OrdenCompra.IdProveedor";
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

        public static OrdenCompra getByPk(int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT OrdenCompra.*, Proveedor.Nombre NombreProveedor " +
                    "FROM OrdenCompra " +
                    "INNER JOIN Proveedor ON Proveedor.Id = OrdenCompra.IdProveedor WHERE");
                sql.AppendLine("Id = @Id");
                OrdenCompra obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<OrdenCompra> lst = mapeo(dr);
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

        public static OrdenCompra GetByOrdenPedido(int idOrdenPedido)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT OrdenCompra.*, Proveedor.Nombre NombreProveedor " +
                    "FROM OrdenCompra " +
                    "INNER JOIN Proveedor ON Proveedor.Id = OrdenCompra.IdProveedor WHERE");
                sql.AppendLine("IdOrdenPedido = @IdOrdenPedido");
                OrdenCompra obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdOrdenPedido", idOrdenPedido);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<OrdenCompra> lst = mapeo(dr);
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

        public static int insert(OrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO OrdenCompra(");
                sql.AppendLine("Fecha");
                sql.AppendLine(", Llaves");
                sql.AppendLine(", Nota");
                sql.AppendLine(", IdOrdenPedido");
                sql.AppendLine(", Historia");
                sql.AppendLine(", IdUsuario");
                sql.AppendLine(", IdOficina");
                sql.AppendLine(", IdDireccion");
                sql.AppendLine(", IdSecretaria");
                sql.AppendLine(", IdProveedor");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Fecha");
                sql.AppendLine(", @Llaves");
                sql.AppendLine(", @Nota");
                sql.AppendLine(", @IdOrdenPedido");
                sql.AppendLine(", @Historia");
                sql.AppendLine(", @IdUsuario");
                sql.AppendLine(", @IdOficina");
                sql.AppendLine(", @IdDireccion");
                sql.AppendLine(", @IdSecretaria");
                sql.AppendLine(", @IdProveedor");
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
                    cmd.Parameters.AddWithValue("@IdOrdenPedido", obj.IdOrdenPedido);
                    cmd.Parameters.AddWithValue("@Historia", obj.Historia);
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdOficina", obj.IdOficina);
                    cmd.Parameters.AddWithValue("@IdDireccion", obj.IdDireccion);
                    cmd.Parameters.AddWithValue("@IdSecretaria", obj.IdSecretaria);
                    cmd.Parameters.AddWithValue("@IdProveedor", obj.IdSecretaria);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(OrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  OrdenCompra SET");
                sql.AppendLine("Fecha=@Fecha");
                sql.AppendLine(", Llaves=@Llaves");
                sql.AppendLine(", Nota=@Nota");
                sql.AppendLine(", IdOrdenPedido=@IdOrdenPedido");
                sql.AppendLine(", Historia=@Historia");
                sql.AppendLine(", IdUsuario=@IdUsuario");
                sql.AppendLine(", IdOficina=@IdOficina");
                sql.AppendLine(", IdDireccion=@IdDireccion");
                sql.AppendLine(", IdSecretaria=@IdSecretaria");
                sql.AppendLine(", IdProveedor=@IdProveedor");
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
                    cmd.Parameters.AddWithValue("@IdOrdenPedido", obj.IdOrdenPedido);
                    cmd.Parameters.AddWithValue("@Historia", obj.Historia);
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdOficina", obj.IdOficina);
                    cmd.Parameters.AddWithValue("@IdDireccion", obj.IdDireccion);
                    cmd.Parameters.AddWithValue("@IdSecretaria", obj.IdSecretaria);
                    cmd.Parameters.AddWithValue("@IdProveedor", obj.IdProveedor);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(OrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  OrdenCompra ");
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

        public static List<OrdenCompra> getByUsuario(int idUsuario)
        {
            try
            {
                List<OrdenCompra> lst = new List<OrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT OrdenCompra.*, Proveedor.Nombre NombreProveedor " +
                    "FROM OrdenCompra " +
                    "INNER JOIN Proveedor ON Proveedor.Id = OrdenCompra.IdProveedor WHERE");
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
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<OrdenCompra> getByOficina(int idOficina)
        {
            try
            {
                List<OrdenCompra> lst = new List<OrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT OrdenCompra.*, Proveedor.Nombre NombreProveedor " +
                    "FROM OrdenCompra " +
                    "INNER JOIN Proveedor ON Proveedor.Id = OrdenCompra.IdProveedor WHERE");
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
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<OrdenCompra> getBySecretaria(int idSecretaria)
        {
            try
            {
                List<OrdenCompra> lst = new List<OrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT OrdenCompra.*, Proveedor.Nombre NombreProveedor " +
                    "FROM OrdenCompra " +
                    "INNER JOIN Proveedor ON Proveedor.Id = OrdenCompra.IdProveedor WHERE");
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
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<OrdenCompra> getByDireccion(int idDireccion)
        {
            try
            {
                List<OrdenCompra> lst = new List<OrdenCompra>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT OrdenCompra.*, Proveedor.Nombre NombreProveedor " +
                    "FROM OrdenCompra " +
                    "INNER JOIN Proveedor ON Proveedor.Id = OrdenCompra.IdProveedor WHERE");
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
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}

