using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCompras.Entities
{
    public class Proveedor : DALBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreContacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string ProvinciaEstado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string SitioWeb { get; set; }
        public string TipoProveedor { get; set; }
        public string CategoriaProductosServicios { get; set; }
        public string Notas { get; set; }
        public DateTime Fecha { get; set; }
        public string Llaves { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }
        public int IdOficina { get; set; }
        public int IdDireccion { get; set; }
        public int IdSecretaria { get; set; }

        public Proveedor()
        {
            Id = 0;
            Nombre = string.Empty;
            NombreContacto = string.Empty;
            Direccion = string.Empty;
            Ciudad = string.Empty;
            ProvinciaEstado = string.Empty;
            CodigoPostal = string.Empty;
            Pais = string.Empty;
            Telefono = string.Empty;
            CorreoElectronico = string.Empty;
            SitioWeb = string.Empty;
            TipoProveedor = string.Empty;
            CategoriaProductosServicios = string.Empty;
            Notas = string.Empty;
            Fecha = DateTime.Now;
            Llaves = string.Empty;
            Activo = false;
            IdUsuario = 0;
            IdOficina = 0;
            IdDireccion = 0;
            IdSecretaria = 0;
        }

        private static List<Proveedor> mapeo(SqlDataReader dr)
        {
            List<Proveedor> lst = new List<Proveedor>();
            Proveedor obj;
            if (dr.HasRows)
            {
                int Id = dr.GetOrdinal("Id");
                int Nombre = dr.GetOrdinal("Nombre");
                int NombreContacto = dr.GetOrdinal("NombreContacto");
                int Direccion = dr.GetOrdinal("Direccion");
                int Ciudad = dr.GetOrdinal("Ciudad");
                int ProvinciaEstado = dr.GetOrdinal("ProvinciaEstado");
                int CodigoPostal = dr.GetOrdinal("CodigoPostal");
                int Pais = dr.GetOrdinal("Pais");
                int Telefono = dr.GetOrdinal("Telefono");
                int CorreoElectronico = dr.GetOrdinal("CorreoElectronico");
                int SitioWeb = dr.GetOrdinal("SitioWeb");
                int TipoProveedor = dr.GetOrdinal("TipoProveedor");
                int CategoriaProductosServicios = dr.GetOrdinal("CategoriaProductosServicios");
                int Notas = dr.GetOrdinal("Notas");
                int Fecha = dr.GetOrdinal("Fecha");
                int Llaves = dr.GetOrdinal("Llaves");
                int Activo = dr.GetOrdinal("Activo");
                int IdUsuario = dr.GetOrdinal("IdUsuario");
                int IdOficina = dr.GetOrdinal("IdOficina");
                int IdDireccion = dr.GetOrdinal("IdDireccion");
                int IdSecretaria = dr.GetOrdinal("IdSecretaria");
                while (dr.Read())
                {
                    obj = new Proveedor();
                    if (!dr.IsDBNull(Id)) { obj.Id = dr.GetInt32(Id); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(NombreContacto)) { obj.NombreContacto = dr.GetString(NombreContacto); }
                    if (!dr.IsDBNull(Direccion)) { obj.Direccion = dr.GetString(Direccion); }
                    if (!dr.IsDBNull(Ciudad)) { obj.Ciudad = dr.GetString(Ciudad); }
                    if (!dr.IsDBNull(ProvinciaEstado)) { obj.ProvinciaEstado = dr.GetString(ProvinciaEstado); }
                    if (!dr.IsDBNull(CodigoPostal)) { obj.CodigoPostal = dr.GetString(CodigoPostal); }
                    if (!dr.IsDBNull(Pais)) { obj.Pais = dr.GetString(Pais); }
                    if (!dr.IsDBNull(Telefono)) { obj.Telefono = dr.GetString(Telefono); }
                    if (!dr.IsDBNull(CorreoElectronico)) { obj.CorreoElectronico = dr.GetString(CorreoElectronico); }
                    if (!dr.IsDBNull(SitioWeb)) { obj.SitioWeb = dr.GetString(SitioWeb); }
                    if (!dr.IsDBNull(TipoProveedor)) { obj.TipoProveedor = dr.GetString(TipoProveedor); }
                    if (!dr.IsDBNull(CategoriaProductosServicios)) { obj.CategoriaProductosServicios = dr.GetString(CategoriaProductosServicios); }
                    if (!dr.IsDBNull(Notas)) { obj.Notas = dr.GetString(Notas); }
                    if (!dr.IsDBNull(Fecha)) { obj.Fecha = dr.GetDateTime(Fecha); }
                    if (!dr.IsDBNull(Llaves)) { obj.Llaves = dr.GetString(Llaves); }
                    if (!dr.IsDBNull(Activo)) { obj.Activo = dr.GetBoolean(Activo); }
                    if (!dr.IsDBNull(IdUsuario)) { obj.IdUsuario = dr.GetInt32(IdUsuario); }
                    if (!dr.IsDBNull(IdOficina)) { obj.IdOficina = dr.GetInt32(IdOficina); }
                    if (!dr.IsDBNull(IdDireccion)) { obj.IdDireccion = dr.GetInt32(IdDireccion); }
                    if (!dr.IsDBNull(IdSecretaria)) { obj.IdSecretaria = dr.GetInt32(IdSecretaria); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Proveedor> read()
        {
            try
            {
                List<Proveedor> lst = new List<Proveedor>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Proveedor";
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

        public static Proveedor getByPk(
        int Id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Proveedor WHERE");
                sql.AppendLine("Id = @Id");
                Proveedor obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Proveedor> lst = mapeo(dr);
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

        public static int insert(Proveedor obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Proveedor(");
                sql.AppendLine("Nombre");
                sql.AppendLine(", NombreContacto");
                sql.AppendLine(", Direccion");
                sql.AppendLine(", Ciudad");
                sql.AppendLine(", ProvinciaEstado");
                sql.AppendLine(", CodigoPostal");
                sql.AppendLine(", Pais");
                sql.AppendLine(", Telefono");
                sql.AppendLine(", CorreoElectronico");
                sql.AppendLine(", SitioWeb");
                sql.AppendLine(", TipoProveedor");
                sql.AppendLine(", CategoriaProductosServicios");
                sql.AppendLine(", Notas");
                sql.AppendLine(", Fecha");
                sql.AppendLine(", Llaves");
                sql.AppendLine(", Activo");
                sql.AppendLine(", IdUsuario");
                sql.AppendLine(", IdOficina");
                sql.AppendLine(", IdDireccion");
                sql.AppendLine(", IdSecretaria");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nombre");
                sql.AppendLine(", @NombreContacto");
                sql.AppendLine(", @Direccion");
                sql.AppendLine(", @Ciudad");
                sql.AppendLine(", @ProvinciaEstado");
                sql.AppendLine(", @CodigoPostal");
                sql.AppendLine(", @Pais");
                sql.AppendLine(", @Telefono");
                sql.AppendLine(", @CorreoElectronico");
                sql.AppendLine(", @SitioWeb");
                sql.AppendLine(", @TipoProveedor");
                sql.AppendLine(", @CategoriaProductosServicios");
                sql.AppendLine(", @Notas");
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
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@NombreContacto", obj.NombreContacto);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@ProvinciaEstado", obj.ProvinciaEstado);
                    cmd.Parameters.AddWithValue("@CodigoPostal", obj.CodigoPostal);
                    cmd.Parameters.AddWithValue("@Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@SitioWeb", obj.SitioWeb);
                    cmd.Parameters.AddWithValue("@TipoProveedor", obj.TipoProveedor);
                    cmd.Parameters.AddWithValue("@CategoriaProductosServicios", obj.CategoriaProductosServicios);
                    cmd.Parameters.AddWithValue("@Notas", obj.Notas);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@Llaves", obj.Llaves);
                    cmd.Parameters.AddWithValue("@Activo", obj.Activo);
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

        public static void update(Proveedor obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Proveedor SET");
                sql.AppendLine("Nombre=@Nombre");
                sql.AppendLine(", NombreContacto=@NombreContacto");
                sql.AppendLine(", Direccion=@Direccion");
                sql.AppendLine(", Ciudad=@Ciudad");
                sql.AppendLine(", ProvinciaEstado=@ProvinciaEstado");
                sql.AppendLine(", CodigoPostal=@CodigoPostal");
                sql.AppendLine(", Pais=@Pais");
                sql.AppendLine(", Telefono=@Telefono");
                sql.AppendLine(", CorreoElectronico=@CorreoElectronico");
                sql.AppendLine(", SitioWeb=@SitioWeb");
                sql.AppendLine(", TipoProveedor=@TipoProveedor");
                sql.AppendLine(", CategoriaProductosServicios=@CategoriaProductosServicios");
                sql.AppendLine(", Notas=@Notas");
                sql.AppendLine(", Fecha=@Fecha");
                sql.AppendLine(", Llaves=@Llaves");
                sql.AppendLine(", Activo=@Activo");
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
                    cmd.Parameters.AddWithValue("@NombreContacto", obj.NombreContacto);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@ProvinciaEstado", obj.ProvinciaEstado);
                    cmd.Parameters.AddWithValue("@CodigoPostal", obj.CodigoPostal);
                    cmd.Parameters.AddWithValue("@Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@SitioWeb", obj.SitioWeb);
                    cmd.Parameters.AddWithValue("@TipoProveedor", obj.TipoProveedor);
                    cmd.Parameters.AddWithValue("@CategoriaProductosServicios", obj.CategoriaProductosServicios);
                    cmd.Parameters.AddWithValue("@Notas", obj.Notas);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@Llaves", obj.Llaves);
                    cmd.Parameters.AddWithValue("@Activo", obj.Activo);
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

        public static void delete(Proveedor obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Proveedor ");
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

