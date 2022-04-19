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
    public partial class FormularioAutenticado : System.Web.UI.Page
    {
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        string script = "";
        DataTable tabla = new DataTable();
        string descripcion = "", requisitos = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                if (Session["Login"] == null)
                {
                    Response.Redirect("Home.aspx");
                }


            }
            //traemos los requisitos y descripcion del préstamo
            tabla = metodos.devolverInformacionPrestamos(Session["tipoPrestamo"].ToString());
            descripcion = tabla.Rows[0]["Descripcion"].ToString();
            requisitos = tabla.Rows[0]["Requisito"].ToString();

            contenido1.InnerText = descripcion;
            contenido3.InnerText = requisitos;
        }

      


        protected void btnAtras_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/pages/Prestamos.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string error;
            try
            {
                float tasaPrestamo = 0;
                double cuotaMensual = 0;
                decimal numero = 0;
                string montoValores;
                string[] arreglo = new string[2];
                string mensaje, montoMaximo, montoMinimo;
                char signo;
                int idMoneda = 0;

                //validamos que no queden campos sin llenar
                if (txtSalarioNeto.Value.ToString().Equals("") || txtAñosLaborando.Value.ToString().Equals("") || txtSalarioBruto.Value.ToString().Equals(""))
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
                        montoMaximo.Replace('₡', signo);
                        numero = Decimal.Parse(arreglo[1]);
                        montoMinimo = String.Format("{0:C}", numero);
                        montoMaximo.Replace('₡', signo);
                    }


                    //validamos que el monto ingresado por el usuario este en el rango del monto maximo y minimo
                    if (double.Parse(txtMonto.Value.ToString()) > double.Parse(arreglo[0]) || double.Parse(txtMonto.Value.ToString()) < double.Parse(arreglo[0]))
                    {
                        mensaje = "El monto no puede pasar de " + montoMaximo + " y " + montoMinimo;
                        script = string.Format("javascript:notificacion('{0}')", mensaje);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                    }
                    else
                    {
                        //recuperamos la fecha actual
                        string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                        //registramos el préstamo del cliente
                        metodos.registrarPrestamoCliente(Session["Login"].ToString(), DateTime.Parse(fecha), "espera", float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAños.Value.ToString()), cuotaMensual, float.Parse(txtSalarioNeto.Value.ToString()), int.Parse(txtAñosLaborando.Value.ToString()), float.Parse(txtSalarioBruto.Value.ToString()), Session["tipoPrestamo"].ToString(), idMoneda);
                        string Rol = "Cliente";
                        //Obtenemos el correo del cliente
                        string Correo = metodos.ObtenerCorreo(Session["Login"].ToString(), Rol);
                        //enviamos el correo del cliente
                        metodos.enviarCorreo(Correo);
                        script = string.Format("javascript:notificacion('{0}')", "Se ha enviado tu solicitud de crédito, favor estar atento a tu correo sobre la aprobación de tu credito");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                        Session["tipoPrestamo"] = null;
                        Response.Redirect("/pages/Prestamos.aspx");
                    }


                }
            }
            catch (Exception ex)
            {
                error = "Error al guardar la informacion del cliente en la BD, favor revisar la bd del sistema bancario " + ex.Message;
                script = string.Format("javascript:alerta('{0}')", error);

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }

        }
    }
}