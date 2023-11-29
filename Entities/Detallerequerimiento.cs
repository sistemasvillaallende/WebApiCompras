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
    public class DetalleRequerimiento : DALBase
    {
        public int Id { get; set; }
        public int IdRequerimiento { get; set; }
        public int IdInsumo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string NombreInsumo { get; set; }

        public DetalleRequerimiento()
        {
            Id = 0;
            IdRequerimiento = 0;
            IdInsumo = 0;
            Cantidad = 0;
            Precio = 0;
            NombreInsumo = string.Empty;
        }

        private static List<DetalleRequerimiento> mapeo(SqlDataReader dr)
        {
            List<DetalleRequerimiento> lst = new List<DetalleRequerimiento>();
            DetalleRequerimiento obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int IdRequerimiento = dr.GetOrdinal("IdRequerimiento");
                int IdInsumo = dr.GetOrdinal("IdInsumo");
                int Cantidad = dr.GetOrdinal("Cantidad");
                int Precio = dr.GetOrdinal("Precio");
                int NombreInsumo = dr.GetOrdinal("NombreInsumo");
                while (dr.Read())
                {
                    obj = new DetalleRequerimiento();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(IdRequerimiento)) { obj.IdRequerimiento = dr.GetInt32(IdRequerimiento); }
                    if (!dr.IsDBNull(IdInsumo)) { obj.IdInsumo = dr.GetInt32(IdInsumo); }
                    if (!dr.IsDBNull(Cantidad)) { obj.Cantidad = dr.GetInt32(Cantidad); }
                    if (!dr.IsDBNull(Precio)) { obj.Precio = dr.GetDecimal(Precio); }
                    if (!dr.IsDBNull(NombreInsumo)) { obj.NombreInsumo = dr.GetString(NombreInsumo); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<DetalleRequerimiento> read()
        {
            try
            {
                List<DetalleRequerimiento> lst = new List<DetalleRequerimiento>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT DetalleRequerimiento.*, Insumos.Nombre NombreInsumo " +
                        "FROM DetalleRequerimiento " +
                        "INNER JOIN Insumos ON Insumos.Id = DetalleRequerimiento.IdInsumo";
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

        public static DetalleRequerimiento getByPk(int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DetalleRequerimiento.*, Insumos.Nombre NombreInsumo " +
                    "FROM DetalleRequerimiento " +
                    "INNER JOIN Insumos ON Insumos.Id = DetalleRequerimiento.IdInsumo WHERE ");
                sql.AppendLine("Id = @Id");
                DetalleRequerimiento obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<DetalleRequerimiento> lst = mapeo(dr);
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

        public static int insert(DetalleRequerimiento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO DetalleRequerimiento(");
                sql.AppendLine("IdRequerimiento");
                sql.AppendLine(", IdInsumo");
                sql.AppendLine(", Cantidad");
                sql.AppendLine(", Precio");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@IdRequerimiento");
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
                    cmd.Parameters.AddWithValue("@IdRequerimiento", obj.IdRequerimiento);
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

        public static void insertList(List<DetalleRequerimiento> list, int idRequerimiento)
        {
            try
            {
                foreach (var item in list)
                {
                    item.IdRequerimiento = idRequerimiento;
                    insert(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void update(DetalleRequerimiento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  DetalleRequerimiento SET");
                sql.AppendLine("IdRequerimiento=@IdRequerimiento");
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
                    cmd.Parameters.AddWithValue("@IdRequerimiento", obj.IdRequerimiento);
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

        public static void updatePrecio(DetalleRequerimiento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  DetalleRequerimiento SET");
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

        public static void delete(DetalleRequerimiento obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  DetalleRequerimiento ");
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

        public static List<DetalleRequerimiento> getByIdRequerimiento(int idRequerimiento)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DetalleRequerimiento.*, Insumos.Nombre NombreInsumo " +
                    "FROM DetalleRequerimiento " +
                    "INNER JOIN Insumos ON Insumos.Id = DetalleRequerimiento.IdInsumo WHERE");
                sql.AppendLine("IdRequerimiento = @IdRequerimiento");
                List<DetalleRequerimiento> lst = new List<DetalleRequerimiento>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@IdRequerimiento", idRequerimiento);
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

