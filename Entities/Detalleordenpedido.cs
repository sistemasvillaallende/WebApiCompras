using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCompras.Entities
{
    public class DetalleOrdenpedido : DALBase
    {
        public int Id { get; set; }
        public int IdOrdenPedido { get; set; }
        public int IdInsumo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string NombreInsumo { get; set; }

        public DetalleOrdenpedido()
        {
            Id = 0;
            IdOrdenPedido = 0;
            IdInsumo = 0;
            Cantidad = 0;
            Precio = 0;
            NombreInsumo = string.Empty;
        }

        private static List<DetalleOrdenpedido> mapeo(SqlDataReader dr)
        {
            List<DetalleOrdenpedido> lst = new List<DetalleOrdenpedido>();
            DetalleOrdenpedido obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int IdOrdenPedido = dr.GetOrdinal("IdOrdenPedido");
                int IdInsumo = dr.GetOrdinal("IdInsumo");
                int Cantidad = dr.GetOrdinal("Cantidad");
                int Precio = dr.GetOrdinal("Precio");
                int NombreInsumo = dr.GetOrdinal("NombreInsumo");
                while (dr.Read())
                {
                    obj = new DetalleOrdenpedido();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(IdOrdenPedido)) { obj.IdOrdenPedido = dr.GetInt32(IdOrdenPedido); }
                    if (!dr.IsDBNull(IdInsumo)) { obj.IdInsumo = dr.GetInt32(IdInsumo); }
                    if (!dr.IsDBNull(Cantidad)) { obj.Cantidad = dr.GetInt32(Cantidad); }
                    if (!dr.IsDBNull(Precio)) { obj.Precio = dr.GetDecimal(Precio); }
                    if (!dr.IsDBNull(NombreInsumo)) { obj.NombreInsumo = dr.GetString(NombreInsumo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<DetalleOrdenpedido> read()
        {
            try
            {
                List<DetalleOrdenpedido> lst = new List<DetalleOrdenpedido>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT DetalleOrdenpedido.*, Insumos.Nombre NombreInsumo FROM DetalleOrdenpedido INNER JOIN Insumos ON Insumos.Id = DetalleOrdenpedido.IdInsumo";
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

        public static DetalleOrdenpedido getByPk(int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DetalleOrdenpedido.*, Insumos.Nombre NombreInsumo FROM DetalleOrdenpedido INNER JOIN Insumos ON Insumos.Id = DetalleOrdenpedido.IdInsumo WHERE");
                sql.AppendLine("Id = @Id");
                DetalleOrdenpedido obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<DetalleOrdenpedido> lst = mapeo(dr);
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

        public static List<DetalleOrdenpedido> getByOrdenPedido(int idOrdenPedido)
        {
            try
            {
                List<DetalleOrdenpedido> lst = new List<DetalleOrdenpedido>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DetalleOrdenpedido.*, Insumos.Nombre NombreInsumo FROM DetalleOrdenpedido INNER JOIN Insumos ON Insumos.Id = DetalleOrdenpedido.IdInsumo WHERE");
                sql.AppendLine("IdOrdenPedido = @IdOrdenPedido");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdOrdenPedido", idOrdenPedido);
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

        public static int insert(DetalleOrdenpedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO DetalleOrdenpedido(");
                sql.AppendLine("IdOrdenPedido");
                sql.AppendLine(", IdInsumo");
                sql.AppendLine(", Cantidad");
                sql.AppendLine(", Precio");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@IdOrdenPedido");
                sql.AppendLine(", @IdInsumo");
                sql.AppendLine(", @Cantidad");
                sql.AppendLine(", @Precio");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdOrdenPedido", obj.IdOrdenPedido);
                    cmd.Parameters.AddWithValue("@IdInsumo", obj.IdInsumo);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(DetalleOrdenpedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  DetalleOrdenpedido SET");
                sql.AppendLine("IdOrdenPedido=@IdOrdenPedido");
                sql.AppendLine(", IdInsumo=@IdInsumo");
                sql.AppendLine(", Cantidad=@Cantidad");
                sql.AppendLine(", Precio=@Precio");
                sql.AppendLine("WHERE");
                sql.AppendLine("Id=@Id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdOrdenPedido", obj.IdOrdenPedido);
                    cmd.Parameters.AddWithValue("@IdInsumo", obj.IdInsumo);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(DetalleOrdenpedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  DetalleOrdenpedido ");
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

