﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Threading;

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
        public string comboBoxItem;

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

        public DataTable devolverPrestamosClientes()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerPrestamos", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar los requisitos del prestamo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
            return DatatableUsuarios;
        }

        public void guardarInformacionClienteNoAutenticado(string cedula, string nombre, string apellido1, string apellido2, string correo, int telefono,string rol)
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

        public void registrarPrestamoCliente(string identificacion, string fechaCredito, string estadoCredito,float monto,int plazoAños,double cuotaMensual,float salarioNeto,int añosLaborando,float salarioBruto, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("registrarPrestamo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                comando.Parameters.AddWithValue("@FechaCredito", fechaCredito);
                comando.Parameters.AddWithValue("@EstadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                comando.Parameters.AddWithValue("@Monto",monto);
                comando.Parameters.AddWithValue("@PlazoAños",plazoAños);
                comando.Parameters.AddWithValue("@CuotaMensual",cuotaMensual);
                comando.Parameters.AddWithValue("@SalarioNeto",salarioNeto);
                comando.Parameters.AddWithValue("@AñosLaborando",añosLaborando);
                comando.Parameters.AddWithValue("@SalarioBruto",salarioBruto);
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



        public string CredencialesUsuario(string Identificacion, string password)
        {
            abrirConexion();
            comando = new SqlCommand("CredencialesUsuario", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Identificacion", Identificacion);
            comando.Parameters.AddWithValue("@Contraseña", password);
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1 && dt.Rows[0][0].ToString().Equals("") || dt.Rows[0][1].ToString().Equals(""))
            {
                return "0";
            }
            else
            {
                return dt.Rows[0][2].ToString();
            }
        }


        public void RegistrarUsuario(string Identificacion, string Nombre, string Rol, string PrimerApellido, string SegundoApellido, string Correo, string Telefono,  string Password, string TipoCedula)

        {
            try
            {
                abrirConexion();

                comando = new SqlCommand("RegistroUsuarios", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", Identificacion);
                comando.Parameters.AddWithValue("@Nombre", Nombre);
                comando.Parameters.AddWithValue("@Rol", Rol);
                comando.Parameters.AddWithValue("@Apellido1", PrimerApellido);
                comando.Parameters.AddWithValue("@Apellido2", SegundoApellido);
                comando.Parameters.AddWithValue("@Correo", Correo);
                comando.Parameters.AddWithValue("@Telefono", Convert.ToInt32(Telefono));
                comando.Parameters.AddWithValue("@Contraseña", Password);
                comando.Parameters.AddWithValue("@TipoCedula", TipoCedula);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al registrar el usuario, detalles:  " + ex.Message);
            }



        }

        public void asignarAnalista(string identificacion, int idPrestamo)
        {

            try
            {
                abrirConexion();
                comando = new SqlCommand("asignarAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@identificacion", identificacion);
                comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error al asignar un analista para un prestamo, detalles: " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }

        }

        public DataTable devolverPrestamos_nombre_cedula(string tipoPrestamo, string cedula)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerPrestamos_TipoYcedula", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@cedula", cedula);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los prestamos por el filtro de nombre y cedula, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable devolverPrestamos_tipoPrestamo(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerPrestamos_TipoPrestamos", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los prestamos por el filtro de nombre, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void cambiarEstadoPrestamoSolicitud(int idPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("cambiarEstadoParaAprobrarONo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cambiar el estado prestamo, detalles: " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string devolverCedulaAnalista(string nombre, string apellido1, string apellido2)
        {

            try
            {
                abrirConexion();
                comando = new SqlCommand("traerAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string usuario = DatatableUsuarios.Rows[0]["Identificacion"].ToString();
                return usuario;
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


       public bool ValidarExistenciaUsuario(string Identificacion)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("ValidarExistenciaUsuario", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", Identificacion);
                SqlDataAdapter adp = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if(dt.Rows.Count==0 || dt.Rows[0][0].ToString().Equals(""))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar la cedula del analista, detalles:  " + ex.Message);
            }
        }

        public float devolverTasaTipoPrestamo(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("devolverTasa", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                float tasa = float.Parse(DatatableUsuarios.Rows[0]["Tasa"].ToString());
                return tasa;
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


        public bool enviarCorreo(string receptor)
        {
            string to = receptor;   
            string from = "bancock.control.interno@gmail.com"; 
            MailMessage message = new MailMessage(from, to);
            string cuerpo = "Muchas gracias por escogernos, le invitamos a ingresar a nuestro sitio, para visualizar nuestros diferentes servicios.";
            string titulo = "Notificación de BancoCK";


            string body = @"<html lang=""en""><head><meta charset=""UTF-8""><meta http-equiv = ""X-UA-Compatible"" content=""IE=edge"" ><meta name=""viewport"" content=""width=device-width, initial-scale=1.0""><title> Document </title><body><style type=""text/css"">body{font-family: 'Poppins', sans-serif;}.cabecera {border: 3px solid #27292d;border-radius: 10px;background-color: #27292d;width: 500px;}.title{font-weight: 700;color: #D03737;text-align: center;}h2{text-align: center;color: white;}a{background-color: #D03737; border: 3px solid #6846ec;border-radius: 5px;color: #fff!important;text-decoration: none;font-weight: 600;padding: 8px; margin-bottom: 20px;}a:hover {background-color: #6846ec;color: white;border-color: #6846ec;}</style></head><body><div class=""cabecera""><h1 class=""title"">Control de recepción de solicitud de créditos</h1><h2>Hola, hemos recibido su solicitud, la estaremos evaluando, pronto recibirá respuesta del estado</h2></div><p>" + cuerpo + @"</p><a href=""https://tiusr2pl.cuc-carrera-ti.ac.cr/BancoCK/pages/Home.aspx""> Ir al sistema</a> </body></html>";

            string mailbody = body;
            message.Subject = titulo;
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
           
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
           
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(from, "BancoCKinterno");
           
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                Thread.Sleep(3000);
                client.Send(message);
               
                return true;
            }

            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public string ObtenerCorreo(string Identificacion,string Rol)
        {


            abrirConexion();
            comando = new SqlCommand("ObtenerCorreo", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Identificacion", Identificacion);
            comando.Parameters.AddWithValue("@Rol", Rol);
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string Correo = dt.Rows[0][0].ToString();
            return Correo;


        }

        public string devolverLimiteMontoPrestamo(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("monto_Maximo_Minimo_préstamo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string usuario = DatatableUsuarios.Rows[0]["MontoMaximoColones"].ToString() + "," + DatatableUsuarios.Rows[0]["MontoMinimoColones"].ToString();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al devolver el monto maximo y minimo del prestamo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }

        }

        public string devolverLimiteMontoPrestamoDolares(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("monto_Maximo_Minimo_préstamo_Dolares", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string usuario = DatatableUsuarios.Rows[0]["MontoMaximoDolares"].ToString() + "," + DatatableUsuarios.Rows[0]["MontoMinimoDolares"].ToString();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al devolver el monto maximo y minimo del prestamo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public float devolverTasaTipoPrestamoDolares(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("devolverTasaDolares", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                float tasa = float.Parse(DatatableUsuarios.Rows[0]["TasaDolares"].ToString());
                return tasa;
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

       public double calcularCuotaMensual(float prestamo, int años, float tasaInteres)
        {
            try
            {
                double tasaInteresCredito = tasaInteres / 100;
                años = años * 12 * -1;
                double resultado = (prestamo * tasaInteresCredito) / (1 - ((Math.Pow(1+tasaInteresCredito, años))));
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular la cuota mensual del prestamo, detalles:  " + ex.Message);
            }
            
        }


        public void registrarPrestamoClienteOriginal(string identificacion, string fechaCredito, string estadoCredito, float monto, int plazoAños, double cuotaMensual, float salarioNeto, int añosLaborando, float salarioBruto, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("registrarPrestamo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                comando.Parameters.AddWithValue("@FechaCredito", fechaCredito);
                comando.Parameters.AddWithValue("@EstadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@Monto", monto);
                comando.Parameters.AddWithValue("@PlazoAños", plazoAños);
                comando.Parameters.AddWithValue("@CuotaMensual", cuotaMensual);
                comando.Parameters.AddWithValue("@SalarioNeto", salarioNeto);
                comando.Parameters.AddWithValue("@AñosLaborando", añosLaborando);
                comando.Parameters.AddWithValue("@SalarioBruto", salarioBruto);
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


        public float devolverTasaDolaresUsuarioNoLogeado(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("devolverTasaUsuarioNoLogeadoDolares", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                float tasa = float.Parse(DatatableUsuarios.Rows[0]["TasaDolares"].ToString());
                return tasa;
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


        public void registrarIndicadorPrestamoClickUsuarioNoAutenticado(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("registrarIndicador_tipoPrestamoNoAutenticados", conexion);
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


        public void registrarIndicadorPrestamoUsuarioNoAutenticadoPrecalculo(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha)
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
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
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

        public DataTable devolverFechasIndicadores()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("devolverFechasIndicadores", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
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


        public int indicadorAutenticadoVivienda(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadosVivienda", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int indicadorAutenticadoPersonal(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadosPersonal", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int indicadorAutenticadoApoyoNegocio(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadosApoyoNegocio", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int indicadorAutenticadoEducacion(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadosEducacion", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int indicadorAutenticadoDeudas(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadosDeudas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int indicadorAutenticadoVehiculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadosVehiculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int indicadorNoAutenticadoVehiculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosVehiculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresNoAutenticadosDeudas(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosDeudas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresNoAutenticadosEducacion(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosEducacion", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int devolverIndicadoresNoAutenticadosApoyoNegocio(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosApoyoNegocio", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresNoAutenticadosPersonal(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosPersonal", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int devolverIndicadoresNoAutenticadosVivienda(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosVivienda", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresNoAutenticadosPersonalPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosPersonalPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int devolverIndicadoresNoAutenticadosApoyoNegocioPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosApoyoNegocioPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int devolverIndicadoresNoAutenticadoViviendaPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosViviendaPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int devolverIndicadoresNoAutenticadoEducacionPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosEducacionPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int devolverIndicadoresNoAutenticadoDeudasPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosDeudasPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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

        public int devolverIndicadoresNoAutenticadoVehiculoPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresNoAutenticadosVehiculoPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresAutenticadoVehiculoPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadosVehiculoPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresAutenticadoDeudasPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadoDeudasPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresAutenticadoEducacionPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadoEducacionPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresAutenticadoViviendaPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadoViviendaPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresAutenticadoApoyoNegocioPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadoApoyoNegocioPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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


        public int devolverIndicadoresAutenticadoPersonalPrecalculo(DateTime fechaInicio, DateTime fechaFinal)
        {

            try
            {
                abrirConexion();
                int numero = 0;
                comando = new SqlCommand("devolverIndicadoresAutenticadoPersonalPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                if (cadena.Equals("") || cadena == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(cadena);
                }
                return numero;
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





    }
}
