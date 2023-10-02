using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiCompras.Entities
{
    public class Detalleordencompra : DALBase
    {
        public int Id { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdInsumo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Detalleordencompra()
        {
            Id = 0;
            IdOrdenCompra = 0;
            IdInsumo = 0;
            Cantidad = 0;
            Precio = 0;
        }

        private static List<Detalleordencompra> mapeo(SqlDataReader dr)
        {
            List<Detalleordencompra> lst = new List<Detalleordencompra>();
            Detalleordencompra obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int IdOrdenCompra = dr.GetOrdinal("IdOrdenCompra");
                int IdInsumo = dr.GetOrdinal("IdInsumo");
                int Cantidad = dr.GetOrdinal("Cantidad");
                int Precio = dr.GetOrdinal("Precio");
                while (dr.Read())
                {
                    obj = new Detalleordencompra();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(IdOrdenCompra)) { obj.IdOrdenCompra = dr.GetInt32(IdOrdenCompra); }
                    if (!dr.IsDBNull(IdInsumo)) { obj.IdInsumo = dr.GetInt32(IdInsumo); }
                    if (!dr.IsDBNull(Cantidad)) { obj.Cantidad = dr.GetInt32(Cantidad); }
                    if (!dr.IsDBNull(Precio)) { obj.Precio = dr.GetDecimal(Precio); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Detalleordencompra> read()
        {
            try
            {
                List<Detalleordencompra> lst = new List<Detalleordencompra>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Detalleordencompra";
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

        public static Detalleordencompra getByPk(
        int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Detalleordencompra WHERE");
                sql.AppendLine("Id = @Id");
                Detalleordencompra obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Detalleordencompra> lst = mapeo(dr);
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

        public static int insert(Detalleordencompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Detalleordencompra(");
                sql.AppendLine("IdOrdenCompra");
                sql.AppendLine(", IdInsumo");
                sql.AppendLine(", Cantidad");
                sql.AppendLine(", Precio");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@IdOrdenCompra");
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
                    cmd.Parameters.AddWithValue("@IdOrdenCompra", obj.IdOrdenCompra);
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

        public static void update(Detalleordencompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Detalleordencompra SET");
                sql.AppendLine("IdOrdenCompra=@IdOrdenCompra");
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
                    cmd.Parameters.AddWithValue("@IdOrdenCompra", obj.IdOrdenCompra);
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

        public static void delete(Detalleordencompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Detalleordencompra ");
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

