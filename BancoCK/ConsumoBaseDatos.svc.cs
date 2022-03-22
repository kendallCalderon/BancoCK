using System;
using System.Data;
using System.Data.SqlClient;

namespace BancoCK
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ConsumoBaseDatos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ConsumoBaseDatos.svc o ConsumoBaseDatos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ConsumoBaseDatos : IConsumoBaseDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataAdapter adaptador;
        DataTable DatatableUsuarios = null;

        public void abrirConexion()
        {
            try
            {
                string strConexion = "Password=Morado571998Medellin;Persist Security Info=True;User ID=proyectoWebGrupo9;Initial Catalog=ProyectoSitios;Data Source=tiusr2pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019";
                conexion = new SqlConnection(strConexion);
                conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexion con la base de datos, detalles: " + ex.Message);
            }
        }

        public void cerrarConexion()
        {
            conexion.Close();
        }

        public void guardarInformacionClienteNoAutenticado(string cedula, string nombre, string apellido1, string apellido2, string correo, int telefono, float salarioNeto, int añosLaborando, float salarioBruto, string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("almacenarInformacionClienteNoLogeado", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", cedula);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@Correo", correo);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@SalarioNeto", salarioNeto);
                comando.Parameters.AddWithValue("@AñosLaborando", añosLaborando);
                comando.Parameters.AddWithValue("@SalarioBruto",salarioBruto);
                comando.Parameters.AddWithValue("@Rol", rol);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al guardar los datos del cliente en BD, detalles: " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string mostrarDescripcion(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerDescripcionPrestamo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string usuario = DatatableUsuarios.Rows[0]["Descripcion"].ToString();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar la descripcion del prestamo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string mostrarRequisitos(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerDescripcionRequisitos", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string usuario = DatatableUsuarios.Rows[0]["Requisito"].ToString();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar los requisitos del prestamo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void registrarPrestamoCliente(string identificacion, string fechaCredito,string estadoCredito)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("registrarPrestamo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                comando.Parameters.AddWithValue("@FechaCredito", fechaCredito);
                comando.Parameters.AddWithValue("@EstadoCredito",estadoCredito);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar los requisitos del prestamo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        



    }
}
