using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BancoCK
{
    public class Temporal
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

        public void registrarIndicadorPrestamoClickUsuarioNoAutenticado(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("registrarIndicador_tipoPrestamoNoAutenticados", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@contador", contador);
                comando.Parameters.AddWithValue("@tipoIndicador",tipoIndicador);
                comando.Parameters.AddWithValue("@fecha",fecha);
                comando.ExecuteNonQuery();

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


        public void registrarIndicadorPrestamoUsuarioNoAutenticadoPrecalculo(string tipoPrestamo, int contador, string tipoIndicador, DateTime  fecha)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("registrarIndicador_tipoPrestamoNoAutenticadosPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@contador", contador);
                comando.Parameters.AddWithValue("@tipoIndicador", tipoIndicador);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.ExecuteNonQuery();

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

        public void registrarIndicadorPrestamoUsuarioAutenticadoPrecalculo(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("registrarIndicador_tipoPrestamoAutenticadosPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@contador", contador);
                comando.Parameters.AddWithValue("@tipoIndicador", tipoIndicador);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.ExecuteNonQuery();

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
        //devolverInformacionPrestamos

        public DataTable devolverInformacionPrestamos(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("devolverInformacionPrestamos", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar la cedula del analista, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void registrarIndicadorPrestamoClickAutenticado(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("registrarIndicador_tipoPrestamoAutenticados", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@contador", contador);
                comando.Parameters.AddWithValue("@tipoIndicador", tipoIndicador);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.ExecuteNonQuery();

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


    }
}