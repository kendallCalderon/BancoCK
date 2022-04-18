using System;
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

        public void guardarInformacionClienteNoAutenticado(string cedula, string nombre, string apellido1, string apellido2, string correo, int telefono, string rol)
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

        public void registrarPrestamoCliente(string identificacion, DateTime fechaCredito, string estadoCredito, float monto, int plazoAños, double cuotaMensual, float salarioNeto, int añosLaborando, float salarioBruto, string tipoPrestamo, int idMoneda)
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
                comando.Parameters.AddWithValue("@idMoneda", idMoneda);
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


        public void RegistrarUsuario(string Identificacion, string Nombre, string Rol, string PrimerApellido, string SegundoApellido, string Correo, string Telefono, string Password, string TipoCedula)

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

                if (dt.Rows.Count == 0 || dt.Rows[0][0].ToString().Equals(""))
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
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                float tasa = float.Parse(DatatableUsuarios.Rows[0]["Tasa"].ToString());
                return tasa;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar la tasa del préstamo solicitado, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }

        }

        public void correoAnalistaInforme(string correo)
        {
            string to = correo;
            string from = "bancock.control.interno@gmail.com";
            MailMessage message = new MailMessage(from, to);
            string cuerpo = "Saludos";
            string titulo = "Notificación de BancoCK";


            string body = @"<html lang=""en""><head><meta charset=""UTF-8""><meta http-equiv = ""X-UA-Compatible"" content=""IE=edge"" ><meta name=""viewport"" content=""width=device-width, initial-scale=1.0""><title> Document </title><body><style type=""text/css"">body{font-family: 'Poppins', sans-serif;}.cabecera {border: 3px solid #27292d;border-radius: 10px;background-color: #27292d;width: 500px;}.title{font-weight: 700;color: #D03737;text-align: center;}h2{text-align: center;color: white;}a{background-color: #D03737; border: 3px solid #6846ec;border-radius: 5px;color: #fff!important;text-decoration: none;font-weight: 600;padding: 8px; margin-bottom: 20px;}a:hover {background-color: #6846ec;color: white;border-color: #6846ec;}</style></head><body><div class=""cabecera""><h1 class=""title"">Control de recepción de solicitud de créditos</h1><h2>Se te informa que tenes una nueva solicitud de prestamo que requiere de tu revision</h2></div><p>" + cuerpo + @"</p><a href=""https://tiusr2pl.cuc-carrera-ti.ac.cr/BancoCK/pages/Home.aspx""> Ir al sistema</a> </body></html>";

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

            }

            catch (Exception ex)
            {
                throw ex;
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

        public bool enviarCorreoClienteSolicitudCredito(string receptor, string nombre, string apellido1, string apellido2, string identificacion, string tipoPrestamo)
        {
            string to = receptor;
            string from = "bancock.control.interno@gmail.com";
            MailMessage message = new MailMessage(from, to);
            string cuerpo = "Muchas gracias por escogernos, le invitamos a ingresar a nuestro sitio, para visualizar nuestros diferentes servicios.";
            string titulo = "Notificación de BancoCK";

            string cadena = "Estimado " + nombre + " " + apellido1 + " " + apellido2 + " con cedula " + identificacion + ". \n Le informamos que tu solicitud de prestamo que es " + tipoPrestamo + " Ha sido aprobado, favor llamar al 22783456 para mas informacion";

            string body = @"<html lang=""en""><head><meta charset=""UTF-8""><meta http-equiv = ""X-UA-Compatible"" content=""IE=edge"" ><meta name=""viewport"" content=""width=device-width, initial-scale=1.0""><title> Document </title><body><style type=""text/css"">body{font-family: 'Poppins', sans-serif;}.cabecera {border: 3px solid #27292d;border-radius: 10px;background-color: #27292d;width: 500px;}.title{font-weight: 700;color: #D03737;text-align: center;}h2{text-align: center;color: white;}a{background-color: #D03737; border: 3px solid #6846ec;border-radius: 5px;color: #fff!important;text-decoration: none;font-weight: 600;padding: 8px; margin-bottom: 20px;}a:hover {background-color: #6846ec;color: white;border-color: #6846ec;}</style></head><body><div class=""cabecera""><h1 class=""title"">Control de recepción de solicitud de créditos</h1><h2>" + cadena + "</h2></div><p>" + cuerpo + @"</p><a href=""https://tiusr2pl.cuc-carrera-ti.ac.cr/BancoCK/pages/Home.aspx""> Ir al sistema</a> </body></html>";

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


        public bool enviarCorreoClienteSolicitudCreditoRechazado(string receptor, string nombre, string apellido1, string apellido2, string identificacion, string tipoPrestamo)
        {
            string to = receptor;
            string from = "bancock.control.interno@gmail.com";
            MailMessage message = new MailMessage(from, to);
            string cuerpo = "Muchas gracias por escogernos, le invitamos a ingresar a nuestro sitio, para visualizar nuestros diferentes servicios.";
            string titulo = "Notificación de BancoCK";

            string cadena = "Estimado " + nombre + " " + apellido1 + " " + apellido2 + " con cedula " + identificacion + ". \n Le informamos que tu solicitud de prestamo que es " + tipoPrestamo + " Ha sido Denegado, favor llamar al 22783456 para mas informacion";

            string body = @"<html lang=""en""><head><meta charset=""UTF-8""><meta http-equiv = ""X-UA-Compatible"" content=""IE=edge"" ><meta name=""viewport"" content=""width=device-width, initial-scale=1.0""><title> Document </title><body><style type=""text/css"">body{font-family: 'Poppins', sans-serif;}.cabecera {border: 3px solid #27292d;border-radius: 10px;background-color: #27292d;width: 500px;}.title{font-weight: 700;color: #D03737;text-align: center;}h2{text-align: center;color: white;}a{background-color: #D03737; border: 3px solid #6846ec;border-radius: 5px;color: #fff!important;text-decoration: none;font-weight: 600;padding: 8px; margin-bottom: 20px;}a:hover {background-color: #6846ec;color: white;border-color: #6846ec;}</style></head><body><div class=""cabecera""><h1 class=""title"">Control de recepción de solicitud de créditos</h1><h2>" + cadena + "</h2></div><p>" + cuerpo + @"</p><a href=""https://tiusr2pl.cuc-carrera-ti.ac.cr/BancoCK/pages/Home.aspx""> Ir al sistema</a> </body></html>";

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



        public string ObtenerCorreo(string Identificacion, string Rol)
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
                comando.Parameters.AddWithValue("@tipoPrestamo", tipoPrestamo);
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
                double resultado = (prestamo * (tasaInteres / 100 / 12)) / (1 - Math.Pow(1 + (tasaInteres / 100 / 12), años));
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular la cuota mensual del prestamo, detalles:  " + ex.Message);
            }


        }


        public void registrarPrestamoClienteOriginal(string identificacion, DateTime fechaCredito, string estadoCredito, float monto, int plazoAños, double cuotaMensual, float salarioNeto, int añosLaborando, float salarioBruto, string tipoPrestamo, int idMoneda)
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
                comando.Parameters.AddWithValue("@idMoneda", idMoneda);
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

        public string generalDeudas()
        {

            try
            {
                abrirConexion();
                comando = new SqlCommand("generalDeudas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo refundir deudas, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalApoyoNegocio()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalApoyoNegocio", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo apoyo negocio, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalEducacion()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalEducacion", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo educación, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalPersonal()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalPersonal", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo personal, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalPrestamoVivienda()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalPrestamoVivienda", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo vivienda, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalVehiculo()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalVehiculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo vehiculo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalDeudasPrecalculo()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalDeudasPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo refundir deudas precalculo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalApoyoNegocioPrecalculo()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalApoyoNegocioPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo apoyo negocio precalculo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalEducacionPrecalculo()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalEducacionPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo educación precalculo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalPersonalPrecalculo()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalPersonalPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo personal Precalculo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalPrestamoViviendaPrecalculo()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalPrestamoViviendaPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo vivienda precalculo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string generalVehiculoPrecalculo()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("generalVehiculoPrecalculo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["NoAutenticados"].ToString() + "," + DatatableUsuarios.Rows[0]["Autenticados"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traerse los indicadores del prestamo vehiculo precalculo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public List<string> comboAnalistas()
        {
            List<string> lista = new List<string>();
            try
            {
                abrirConexion();
                comando = new SqlCommand("comboAnalistas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                for(int x=0; x<DatatableUsuarios.Rows.Count; x++)
                {
                    lista.Add(DatatableUsuarios.Rows[x]["NombreCompleto"].ToString());
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al tratar de llenar el comboBox de analistas, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traerPrestamosEntreFechas(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerPrestamosEntreFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal",fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los prestamos por fechas, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public bool traerAnalistasGenerales(string cedula)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerAnalistasGenerales", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion",cedula);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string valor = DatatableUsuarios.Rows[0]["PrestamoEncargado"].ToString();
                if (valor.Equals("General"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los prestamos por fechas, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string EncargoAnalista(string cedula)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("EncargoAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", cedula);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string valor = DatatableUsuarios.Rows[0]["PrestamoEncargado"].ToString();
                return valor;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el tipo de prestamo que le corresponde revisar al analista, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public int ContadorAnalista(string cedula)
        {
            int numero = 0;
            try
            {
                abrirConexion();
                comando = new SqlCommand("ContadorAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", cedula);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string valor = DatatableUsuarios.Rows[0]["SolicitudesAnalista"].ToString();
                if(valor.Equals("") || valor == null)
                {
                    numero = 0;
                }
                else
                {
                    numero = int.Parse(valor);
                }
                return numero;
     
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el el contador de solicitudes del analista escogido, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void sumarAnalista(int numero)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("sumarAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@contador",numero);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al sumarle al contador de solicitudes de prestamo del analista, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreCompleto(string nombre, string apellido1, string apellido2, string estadoCredito,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreCompleto", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre",nombre);
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@estadoCredito",estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por nombre del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreconApellido(string nombre, string apellido1, string estadoCredito,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreconApellido", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por nombre del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombre(string nombre,string estadoCredito, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombre", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por nombre del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxApellidos(string apellido1, string apellido2, string estadoCredito,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxApellidos", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por apellidos del cliente, detalles:  " + ex.Message);
            }
        }

        public DataTable traePrestamoxApellido(string apellido1, string estadoCredito,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxApellido", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por apellido del cliente, detalles:  " + ex.Message);
            }
        }

        public DataTable traePrestamoxCorreo(string correo, string estadoCredito,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxCorreo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Correo",correo);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por correo del cliente, detalles:  " + ex.Message);
            }
        }

        public DataTable traePrestamoxTelefono(int telefono, string estadoCredito,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTelefono", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Telefono",telefono);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por telefono del cliente, detalles:  " + ex.Message);
            }
        }

        public DataTable traePrestamoxIdentificacion(string identificacion, string estadoCredito,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxIdentificacion", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion",identificacion);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por Identificacion del cliente, detalles:  " + ex.Message);
            }
        }

        public DataTable traePrestamoxTipoEstado(string tipoPrestamo, string estadoCredito)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTipoEstado", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los prestamos de los clientes, detalles:  " + ex.Message);
            }
        }

        public DataTable traePrestamoxfechasEstado(DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo, string estadoCredito)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxfechasEstado", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los prestamos entre fechas de los clientes, detalles:  " + ex.Message);
            }
        }

        public DataTable traePrestamoxNombreCompletoFechas(string nombre, string apellido1, string apellido2, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreCompletoFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por nombre del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreconApellidoFechas(string nombre, string apellido1, DateTime fechaInicio, DateTime fechaFinal, string estadoCredito,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreconApellidoFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por nombre del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreFechas(string nombre, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por nombre del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxApellidosFechas(string apellido1, string apellido2, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxApellidosFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por apellidos del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxApellidoFechas(string apellido1, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxApellidoFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por apellido del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxCorreoFechas(string cadena, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxCorreoFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Correo",cadena);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por correo del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxTelefonoFechas(int telefono, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTelefonoFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Telefono",telefono);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por telefono del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxIdentificacionFechas(string identificacion, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTelefonoFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion",identificacion);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el prestamo por identificacion del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxTipoEstadoFechas(string tipoPrestamo, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTipoEstadoFechas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@estadoCredito", estadoCredito);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los prestamos de los clientes, detalles:  " + ex.Message);
            }
        }

        public DataTable traePrestamoxTipoEstadoAnalista(string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTipoEstadoAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito de los clientes, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxTipoEstadoFechasAnalista(string tipoPrestamo, DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTipoEstadoFechasAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito de los clientes entre fechas, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreCompletoFechasAnalista(string nombre, string apellido1, string apellido2, string tipoPrestamo, DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreCompletoFechasAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre",nombre);
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                comando.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por nombre completo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreconApellidoFechasAnalista(string nombre, string apellido1, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreconApellidoFechasAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre",nombre);
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@fechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo",tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por nombre y apellido, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreFechasAnalista(string nombre, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreFechasAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por nombre y apellido, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxApellidosFechasAnalistas(string apellido1, string apellido2, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxApellidosFechasAnalistas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por apellidos, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxApellidoFechasAnalistas(string apellido1, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxApellidoFechasAnalistas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por apellido, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxCorreoFechasAnalistas(string correo, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxCorreoFechasAnalistas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Correo", correo);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por correo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxTelefonoFechasAnalista(int telefono, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTelefonoFechasAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Telefono",telefono);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por telefono, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxIdentificacionFechasAnalista(string Identificacion, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxIdentificacionFechasAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion",Identificacion);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por identificacion, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreCompletoAnalista(string nombre, string apellido1, string apellido2, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreCompletoAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre",nombre);
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por identificacion, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreconApellidoAnalista(string nombre, string apellido1, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreconApellidoAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por nombre y apellido, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxNombreAnalista(string nombre, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxNombreAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por nombre y apellido, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxApellidosAnalista(string apellido1, string apellido2, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxApellidosAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por apellidos del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxApellidoAnalista(string apellido1, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxApellidoAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por apellidos del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxCorreoAnalista(string correo, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxCorreoAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Correo",correo);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por correo del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxTelefonoAnalista(int telefono, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxTelefonoAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Telefono",telefono);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por correo del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traePrestamoxIdentificacionAnalista(string identificacion, string tipoPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traePrestamoxIdentificacionAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@identificacion",identificacion);
                comando.Parameters.AddWithValue("@TipoPrestamo", tipoPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por correo del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public float traerSalarioBrutoCliente(int idPrestamos)
        {

            try
            {
                abrirConexion();
                comando = new SqlCommand("traerSalarioBrutoCliente", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPrestamos",idPrestamos);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return float.Parse(DatatableUsuarios.Rows[0]["SalarioBruto"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las solicitudes de crédito del cliente por correo del cliente, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void cambiarEstadoParaAprobrarAnalista(int idPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("cambiarEstadoParaAprobrarAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error al cambiar el estado de la solicitud de crédito, detalles: " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string ObtenerCorreoSolicitudCliente(int idPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("ObtenerCorreoSolicitudCliente", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Nombre"].ToString() + "," + DatatableUsuarios.Rows[0]["Apellido1"].ToString() + "," + DatatableUsuarios.Rows[0]["Apellido2"].ToString() + "," + DatatableUsuarios.Rows[0]["Identificacion"].ToString() + "," + DatatableUsuarios.Rows[0]["Correo"].ToString() + "," + DatatableUsuarios.Rows[0]["TipoPrestamo"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los datos del cliente para enviar el correo, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void cambiarEstadoParaRechazarAnalista(int idPrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("cambiarEstadoParaRechazarAnalista", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error al cambiar el estado de la solicitud de crédito, detalles: " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traerRoles()
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerRoles", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los roles de los usuarios, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable informacionRolxNombreCompleto(string nombre, string apellido1, string apellido2,string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("informacionRolxNombreCompleto", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre",nombre);
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@Rol",rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer la informacion del usuario, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable informacionRolxNombreApellido(string nombre, string apellido1,string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("informacionRolxNombreApellido", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@Rol",rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer la informacion del usuario, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable informacionRolxNombre(string nombre,string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("informacionRolxNombre", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Rol",rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer la informacion del usuario, detalles:  " + ex.Message);
            }
        }

        public DataTable informacionRolxApellidos(string apellido1, string apellido2,string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("informacionRolxApellidos", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1",apellido1);
                comando.Parameters.AddWithValue("@Apellido2", apellido2);
                comando.Parameters.AddWithValue("@Rol", rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer la informacion del usuario, detalles:  " + ex.Message);
            }
        }

        public DataTable informacionRolxApellido(string apellido1,string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("informacionRolxApellido", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Apellido1", apellido1);
                comando.Parameters.AddWithValue("@Rol",rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer la informacion del usuario, detalles:  " + ex.Message);
            }
        }

        public DataTable informacionRolxCorreo(string correo,string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("informacionRolxCorreo", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Correo",correo);
                comando.Parameters.AddWithValue("@Rol",rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer la informacion del usuario, detalles:  " + ex.Message);
            }
        }

        public DataTable informacionRolxTelefono(int telefono,string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("informacionRolxTelefono", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Telefono",telefono);
                comando.Parameters.AddWithValue("@Rol",rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer la informacion del usuario, detalles:  " + ex.Message);
            }
        }

        public DataTable informacionRolxIdentificacion(string identificacion,string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("informacionRolxIdentificacion", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion",identificacion);
                comando.Parameters.AddWithValue("@Rol", rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer la informacion del usuario, detalles:  " + ex.Message);
            }
        }

        public string traerRolUsuario(string identificacion)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerRolUsuario", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion",identificacion);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string cadena = DatatableUsuarios.Rows[0]["Rol"].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el rol del usuario, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traerRolesxrol(string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerRolesxrol", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Rol",rol);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer el rol del usuario, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public List<string> traerAnalistas(string cedula)
        {
            List<string> lista = new List<string>();
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerAnalistas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion",cedula);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                for(int x=0; x< DatatableUsuarios.Rows.Count; x++)
                {
                    lista.Add(DatatableUsuarios.Rows[0]["Identificacion"].ToString());
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los analistas, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void asignarPrestamos(string cedulaCambio, string cedula)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("asignarPrestamos", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdentificacionCambiar",cedulaCambio);
                comando.Parameters.AddWithValue("@Identificacion",cedula);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al asignar los prestamos para el analista, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void cambioRol(string identificacion, string rol)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("cambioRol", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion",identificacion);
                comando.Parameters.AddWithValue("@rol",rol);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar de rol de un usuario, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void cambioRolTramitador(string identificacion, string rol, string prestamoEncargo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("cambioRolTramitador", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                comando.Parameters.AddWithValue("@rol", rol);
                comando.Parameters.AddWithValue("@prestamoEncargado",prestamoEncargo);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar de rol de un usuario, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public DataTable traerTasas()
        {

            try
            {
                abrirConexion();
                comando = new SqlCommand("traerTasas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                return DatatableUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las tasas de interes, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public string traerPrestamosxTasas(string prestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("traerPrestamosxTasas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre",prestamo);
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                DatatableUsuarios = new DataTable();
                adaptador.Fill(DatatableUsuarios);
                string contenido = DatatableUsuarios.Rows[0]["Tasa"].ToString() + "," + DatatableUsuarios.Rows[0]["TasaDolares"].ToString();
                return contenido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer las tasas de interes, detalles:  " + ex.Message);
            }
            finally
            {
                cerrarConexion();
            }
        }

        public void cambioTasas(float tasaColones, float tasaDolares, string nombrePrestamo)
        {
            try
            {
                abrirConexion();
                comando = new SqlCommand("cambioTasas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tasaColones",tasaColones);
                comando.Parameters.AddWithValue("@tasaDolares",tasaDolares);
                comando.Parameters.AddWithValue("@NombrePrestamo",nombrePrestamo);
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
