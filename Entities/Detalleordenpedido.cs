using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApiCompras.Entities
{
    public class Detalleordenpedido : DALBase
    {
        public int Id { get; set; }
        public int IdOrdenPedido { get; set; }
        public int IdInsumo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Detalleordenpedido()
        {
            Id = 0;
            IdOrdenPedido = 0;
            IdInsumo = 0;
            Cantidad = 0;
            Precio = 0;
        }

        private static List<Detalleordenpedido> mapeo(SqlDataReader dr)
        {
            List<Detalleordenpedido> lst = new List<Detalleordenpedido>();
            Detalleordenpedido obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int IdOrdenPedido = dr.GetOrdinal("IdOrdenPedido");
                int IdInsumo = dr.GetOrdinal("IdInsumo");
                int Cantidad = dr.GetOrdinal("Cantidad");
                int Precio = dr.GetOrdinal("Precio");
                while (dr.Read())
                {
                    obj = new Detalleordenpedido();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(IdOrdenPedido)) { obj.IdOrdenPedido = dr.GetInt32(IdOrdenPedido); }
                    if (!dr.IsDBNull(IdInsumo)) { obj.IdInsumo = dr.GetInt32(IdInsumo); }
                    if (!dr.IsDBNull(Cantidad)) { obj.Cantidad = dr.GetInt32(Cantidad); }
                    if (!dr.IsDBNull(Precio)) { obj.Precio = dr.GetDecimal(Precio); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Detalleordenpedido> read()
        {
            try
            {
                List<Detalleordenpedido> lst = new List<Detalleordenpedido>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Detalleordenpedido";
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

        public static Detalleordenpedido getByPk(
        int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Detalleordenpedido WHERE");
                sql.AppendLine("Id = @Id");
                Detalleordenpedido obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Detalleordenpedido> lst = mapeo(dr);
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

        public static int insert(Detalleordenpedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Detalleordenpedido(");
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

        public static void update(Detalleordenpedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Detalleordenpedido SET");
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

        public static void delete(Detalleordenpedido obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Detalleordenpedido ");
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

