using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class FormularioPrestamo : System.Web.UI.Page
    {
        //variables globales de la pantalla
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        string script = "";
        DataTable tabla = new DataTable();
        string descripcion = "", requisitos = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            //Traemos los requisitos del préstamo
            tabla = metodos.devolverInformacionPrestamos(Session["tipoPrestamo"].ToString());
            descripcion = tabla.Rows[0]["Descripcion"].ToString();
            requisitos = tabla.Rows[0]["Requisito"].ToString();
            contenido1.InnerText = descripcion;
            contenido3.InnerText = requisitos; 

        }

        protected void btnTramitar_Click(object sender, EventArgs e)
        {
            string error;
            try
            {
                float tasaPrestamo = 0;
                int idMoneda = 0;
                double cuotaMensual = 0;
                decimal numero = 0;
                string montoValores;
                string[] arreglo = new string[2];
                string mensaje, montoMaximo, montoMinimo;
                char signo;


                //validamos que no queden campos sin llenar
                if (txtIdentificacion.Value.ToString().Equals("") || txtNombre.Value.ToString().Equals("") || txtApellido1.Value.ToString().Equals("") || txtApellido2.Value.ToString().Equals("") || txtCorreo.Value.ToString().Equals("") || txtTelefono.Value.ToString().Equals("") || txtSalarioNeto.Value.ToString().Equals("") || txtAñosLaborando.Value.ToString().Equals("") || txtSalarioBruto.Value.ToString().Equals(""))
                {
                    script = string.Format("javascript:notificacion('{0}')", "No pueden quedar campos sin llenar");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                }
                else
                {


                    // calculamos la cuota del prestamo de acuerdo a el tipo de moneda escogido
                    if (txtCombo.SelectedIndex == 1)
                    {
                        idMoneda = 2;
                        tasaPrestamo = metodos.devolverTasaTipoPrestamoDolares(Session["tipoPrestamo"].ToString());
                        cuotaMensual = metodos.calcularCuotaMensual(float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAños.Value.ToString()), tasaPrestamo);
                        montoValores = metodos.devolverLimiteMontoPrestamoDolares(Session["tipoPrestamo"].ToString());
                        signo = '$';

                    }
                    else
                    {
                        idMoneda = 1;
                        tasaPrestamo = metodos.devolverTasaTipoPrestamo(Session["tipoPrestamo"].ToString());
                        cuotaMensual = metodos.calcularCuotaMensual(float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAños.Value.ToString()), tasaPrestamo);
                        montoValores = metodos.devolverLimiteMontoPrestamo(Session["tipoPrestamo"].ToString());
                        signo = '₡';
                    }


                    if (idMoneda == 2)
                    {
                        arreglo = montoValores.Split(',');
                        numero = Decimal.Parse(arreglo[0]);
                        montoMaximo = string.Format(new CultureInfo("en-US"), "{0:C}", numero);
                        numero = Decimal.Parse(arreglo[1]);
                        montoMinimo = string.Format(new CultureInfo("en-US"), "{0:C}", numero);
                    }
                    else
                    {
                        // damos formato al monto maximo y minimo
                        arreglo = montoValores.Split(',');
                        numero = Decimal.Parse(arreglo[0]);
                        montoMaximo = String.Format("{0:C}", numero);
                        montoMaximo= montoMaximo.Replace('$','₡');
                        numero = Decimal.Parse(arreglo[1]);
                        montoMinimo = String.Format("{0:C}", numero);
                        montoMinimo=montoMinimo.Replace('$','₡');
                    }


                    //validamos que el monto ingresado por el usuario este en el rango del monto maximo y minimo
                    if (double.Parse(txtMonto.Value.ToString()) > double.Parse(arreglo[0]) || double.Parse(txtMonto.Value.ToString()) < double.Parse(arreglo[1]) || int.Parse(txtRangoAños.Value.ToString()) > metodos.traerAños(Session["tipoPrestamo"].ToString()) || int.Parse(txtRangoAños.Value.ToString()) <= 0)
                    {
                        mensaje = "El monto no puede pasar de " + montoMaximo + " y " + montoMinimo + " , ni tampoco puede ser mayor a un plazo en años de " + metodos.traerAños(Session["tipoPrestamo"].ToString()) +" años";
                        script = string.Format("javascript:notificacion('{0}')", mensaje);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                    }
                    else
                    {
                        string fecha = DateTime.Now.ToString("dd-MM-yyyy"); // guardamos la fecha actual del préstamo
                        // guardamos los datos del cliente no autenticado
                        metodos.guardarInformacionClienteNoAutenticado(txtIdentificacion.Value.ToString(), txtNombre.Value.ToString(), txtApellido1.Value.ToString(), txtApellido2.Value.ToString(), txtCorreo.Value.ToString(), int.Parse(txtTelefono.Value.ToString()), "NoLogeado");
                        // registramos el préstamo del cliente
                        metodos.registrarPrestamoClienteOriginal(txtIdentificacion.Value.ToString(), DateTime.Parse(fecha), "espera", float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAños.Value.ToString()), cuotaMensual, float.Parse(txtSalarioNeto.Value.ToString()), int.Parse(txtAñosLaborando.Value.ToString()), float.Parse(txtSalarioBruto.Value.ToString()), Session["tipoPrestamo"].ToString(), idMoneda);
                        script = string.Format("javascript:notificacion('{0}')", "Se ha enviado tu solicitud de crédito, favor estar atento a tu correo sobre la aprobación de tu credito");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);;
                        // enviamos el correo al cliente
                        metodos.enviarCorreo(txtCorreo.Value.ToString());
                        Response.Redirect("/pages/Prestamos.aspx");
                    }


                }
            }
            catch (Exception ex)
            {
                error = "Error al guardar la informacion del cliente en la BD, favor revisar la bd del sistema bancario, detalles: " + ex.Message;
                script = string.Format("javascript:alerta('{0}')", error);

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/Prestamos.aspx");
        }

    }
}