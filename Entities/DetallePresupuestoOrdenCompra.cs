
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Entities
{
    public class DetallePresupuestoOrdenCompra : DALBase
    {
        public int Id { get; set; }
        public int IdPresupuestoOrdenCompra { get; set; }
        public int IdInsumo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string NombreInsumo { get; set; }

        public DetallePresupuestoOrdenCompra()
        {
            Id = 0;
            IdPresupuestoOrdenCompra = 0;
            IdInsumo = 0;
            Cantidad = 0;
            Precio = 0;
            NombreInsumo = string.Empty;
        }

        private static List<DetallePresupuestoOrdenCompra> mapeo(SqlDataReader dr)
        {
            List<DetallePresupuestoOrdenCompra> lst = new List<DetallePresupuestoOrdenCompra>();
            DetallePresupuestoOrdenCompra obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int IdPresupuestoPedido = dr.GetOrdinal("IdPresupuestoOrdenCompra");
                int IdInsumo = dr.GetOrdinal("IdInsumo");
                int Cantidad = dr.GetOrdinal("Cantidad");
                int Precio = dr.GetOrdinal("Precio");
                int NombreInsumo = dr.GetOrdinal("NombreInsumo");
                while (dr.Read())
                {
                    obj = new DetallePresupuestoOrdenCompra();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(IdPresupuestoPedido)) { obj.IdPresupuestoOrdenCompra = dr.GetInt32(IdPresupuestoPedido); }
                    if (!dr.IsDBNull(IdInsumo)) { obj.IdInsumo = dr.GetInt32(IdInsumo); }
                    if (!dr.IsDBNull(Cantidad)) { obj.Cantidad = dr.GetInt32(Cantidad); }
                    if (!dr.IsDBNull(Precio)) { obj.Precio = dr.GetDecimal(Precio); }
                    if (!dr.IsDBNull(NombreInsumo)) { obj.NombreInsumo = dr.GetString(NombreInsumo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<DetallePresupuestoOrdenCompra> read()
        {
            try
            {
                List<DetallePresupuestoOrdenCompra> lst = new List<DetallePresupuestoOrdenCompra>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT DetallePresupuestoOrdenCompra.*, Insumos.Nombre NombreInsumo FROM DetallePresupuestoOrdenCompra INNER JOIN Insumos ON Insumos.Id = DetallePresupuestoOrdenCompra.IdInsumo";
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

        public static DetallePresupuestoOrdenCompra getByPk(int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DetallePresupuestoOrdenCompra.*, Insumos.Nombre NombreInsumo FROM DetallePresupuestoOrdenCompra INNER JOIN Insumos ON Insumos.Id = DetallePresupuestoOrdenCompra.IdInsumo WHERE");
                sql.AppendLine("Id = @Id");
                DetallePresupuestoOrdenCompra obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<DetallePresupuestoOrdenCompra> lst = mapeo(dr);
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

        public static int insert(DetallePresupuestoOrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO DetallePresupuestoOrdenCompra(");
                sql.AppendLine("IdPresupuestoOrdenCompra");
                sql.AppendLine(", IdInsumo");
                sql.AppendLine(", Cantidad");
                sql.AppendLine(", Precio");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@IdPresupuestoOrdenCompra");
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
                    cmd.Parameters.AddWithValue("@IdPresupuestoOrdenCompra", obj.IdPresupuestoOrdenCompra);
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

        public static void insertList(List<DetallePresupuestoOrdenCompra> list, int IdPresupuestoOrdenCompra)
        {
            try
            {
                foreach (var item in list)
                {
                    item.IdPresupuestoOrdenCompra = IdPresupuestoOrdenCompra;
                    insert(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void update(DetallePresupuestoOrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  DetallePresupuestoOrdenCompra SET");
                sql.AppendLine("IdPresupuestoOrdenCompra=@IdPresupuestoOrdenCompra");
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
                    cmd.Parameters.AddWithValue("@IdPresupuestoOrdenCompra", obj.IdPresupuestoOrdenCompra);
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

        public static void updatePrecio(DetallePresupuestoOrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  DetallePresupuestoOrdenCompra SET");
                sql.AppendLine(", Precio=@Precio");
                sql.AppendLine("WHERE");
                sql.AppendLine("Id=@Id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
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

        public static void delete(DetallePresupuestoOrdenCompra obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  DetallePresupuestoOrdenCompra ");
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

        public static List<DetallePresupuestoOrdenCompra> getByIdPresupuestoOrdenCompra(int IdPresupuestoPedido)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DetallePresupuestoOrdenCompra.*, Insumos.Nombre NombreInsumo FROM DetallePresupuestoOrdenCompra INNER JOIN Insumos ON Insumos.Id = DetallePresupuestoOrdenCompra.IdInsumo WHERE");
                sql.AppendLine("IdPresupuestoOrdenCompra = @IdPresupuestoOrdenCompra");
                List<DetallePresupuestoOrdenCompra> lst = new List<DetallePresupuestoOrdenCompra>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdPresupuestoOrdenCompra", IdPresupuestoPedido);
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

    }
}

