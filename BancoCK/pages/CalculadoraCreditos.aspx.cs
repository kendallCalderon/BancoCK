using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        string script = "",tipoPrestamo = "", montosPermitidos="";
        float tasaInteres = 0;
        string[] vector = new string[2];

        protected void cbxComboPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] =  cbxComboPrestamo.SelectedValue.ToString();
        }

        protected void btnDolares_Click(object sender, EventArgs e)
        {
            try
            {
                Session["MonedaEscogida"] = "Dolares";
            }catch(Exception ex)
            {

            }
        }

        protected void btnColones_Click(object sender, EventArgs e)
        {
            try
            {
                Session["MonedaEscogida"] = "Colones";
            }
            catch (Exception ex)
            {

            }
        }

        protected void CalcularCuota(Object sender, EventArgs e)
        {
            try
            {
               if(txtMonto.Value.ToString().Equals("") || txtTasa.Value.ToString().Equals("") || txtRangoAñosPrestamo.Value.ToString().Equals(""))
                {
                    script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al cargar al asignar un prestamo para un analista");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
                }
                else
                {
                    if (double.Parse(txtMonto.Value.ToString()) > double.Parse(Session["MontoMaximo"].ToString()) || double.Parse(txtMonto.Value.ToString()) < double.Parse(Session["MontoMinimo"].ToString()))
                    {
                        script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al cargar al asignar un prestamo para un analista");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
                    }
                    else
                    {
                        double resultado = metodos.calcularCuotaMensual(float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAñosPrestamo.Value.ToString()), float.Parse(txtTasa.Value.ToString()));
                        txtMontoMensual.Value = resultado.ToString();
                    }

                }
             

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al cargar al asignar un prestamo para un analista");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cbxComboPrestamo.Items.Add("Préstamo vehiculo");
                cbxComboPrestamo.Items.Add("Préstamo Vivienda");
                cbxComboPrestamo.Items.Add("Refundir mis deudas");
                cbxComboPrestamo.Items.Add("Préstamo Educacion");
                cbxComboPrestamo.Items.Add("Préstamo Personal");
                cbxComboPrestamo.Items.Add("Apoyo Negocio");

            }


            if (Session["tipoPrestamo"] != null)
            {
                tipoPrestamo = Session["tipoPrestamo"].ToString();
                Session["tipoPrestamo"] = null;
               
            }

            if (Session["MonedaEscogida"] != null)
            {
                if (Session["MonedaEscogida"].ToString().Equals("Dolares"))
                {
                    tasaInteres = metodos.devolverTasaTipoPrestamoDolares(tipoPrestamo);
                    txtTasa.Value = tasaInteres.ToString();
                    montosPermitidos = metodos.devolverLimiteMontoPrestamoDolares(tipoPrestamo);
                    vector = montosPermitidos.Split(',');
                    txtMensajeMonto.InnerText = "Monto Maximo: " + vector[0] + ",  Monto Minimo: " + vector[1];
                    Session["MontoMaximo"] = vector[0];
                    Session["MontoMinimo"] = vector[1];
                }
                else
                {
                    tasaInteres = metodos.devolverTasaTipoPrestamo(tipoPrestamo);
                    txtTasa.Value = tasaInteres.ToString();
                    montosPermitidos = metodos.devolverLimiteMontoPrestamo(tipoPrestamo);
                    vector = montosPermitidos.Split(',');
                    txtMensajeMonto.InnerText = "Monto Maximo: " + vector[0] + ",  Monto Minimo: " + vector[1];
                    Session["MontoMaximo"] = vector[0];
                    Session["MontoMinimo"] = vector[1];
                }
                Session["MonedaEscogida"] = null;
                if(Session["PresionoBotonMoneda"] == null)
                {
                    Session["PresionoBotonMoneda"] = "presionado";
                }

            }
            


        }
    }
}