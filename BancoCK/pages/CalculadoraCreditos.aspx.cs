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
        string script = "",tipoPrestamo = "", montosPermitidos="",formato = "";
        float tasaInteres = 0;
        string[] vector = new string[2];
        decimal temp;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cbxComboPrestamo.Items.Add("Préstamo vehiculo");
                    cbxComboPrestamo.Items.Add("Préstamo Vivienda");
                    cbxComboPrestamo.Items.Add("Refundir mis deudas");
                    cbxComboPrestamo.Items.Add("Préstamo Educacion");
                    cbxComboPrestamo.Items.Add("Préstamo Personal");
                    cbxComboPrestamo.Items.Add("Apoyo Negocio");
                    tipoPrestamo = Session["tipoPrestamo"].ToString();
                    cbxComboPrestamo.SelectedValue = tipoPrestamo;
                    tasaInteres = metodos.devolverTasaTipoPrestamo(tipoPrestamo);
                    txtTasa.Value = tasaInteres.ToString();
                    montosPermitidos = metodos.devolverLimiteMontoPrestamo(tipoPrestamo);
                    vector = montosPermitidos.Split(',');
                    ponerDecimales();
                    txtMensajeMonto.InnerText = "Monto Maximo: " + vector[0] + ",  Monto Minimo: " + vector[1];

                }


                if (Session["tipoPrestamo"] != null)
                {
                    if(Session["tipoPrestamo"].ToString().Equals(cbxComboPrestamo.SelectedValue.ToString())== false)
                    {
                        tipoPrestamo = cbxComboPrestamo.SelectedValue;
                        Session["MonedaEscogida"] = "Colones";
                    }
                    else
                    {
                        tipoPrestamo = Session["tipoPrestamo"].ToString();
                    }

                }

                if (Session["MonedaEscogida"] != null)
                {
                    if (Session["MonedaEscogida"].ToString().Equals("Dolares"))
                    {
                        tasaInteres = metodos.devolverTasaTipoPrestamoDolares(tipoPrestamo);
                        txtTasa.Value = tasaInteres.ToString();
                        montosPermitidos = metodos.devolverLimiteMontoPrestamoDolares(tipoPrestamo);
                        vector = montosPermitidos.Split(',');
                        ponerDecimales();
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
                        ponerDecimales();
                        txtMensajeMonto.InnerText = "Monto Maximo: " + vector[0] + ",  Monto Minimo: " + vector[1];
                        Session["MontoMaximo"] = vector[0];
                        Session["MontoMinimo"] = vector[1];
                    }
                    Session["MonedaEscogida"] = null;
                   

                }
               

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:error('{0}')", "Ocurrio un error en el evento carga de la pantalla calculadora de crédito");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
            }  

        }

        private void ponerDecimales()
        {
            temp = 0;
            formato = vector[0];
            decimal.TryParse(formato, out temp);
            formato = temp.ToString("N2");
            vector[0] = formato.ToString();
            temp = 0;
            formato = vector[1];
            decimal.TryParse(formato, out temp);
            formato = temp.ToString("N2");
            vector[1] = formato.ToString();
        }

        protected void cbxComboPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Contents.Remove("tipoPrestamo");
            Session["tipoPrestamo"] = cbxComboPrestamo.SelectedValue.ToString();
            Session["MonedaEscogida"] = "Colones";
        }

        protected void btnDolares_Click(object sender, EventArgs e)
        {
            Session["MonedaEscogida"] = "Dolares";
            Session["PresionoBotonMoneda"] = "presionado";
            Response.Redirect("/pages/CalculadoraCreditos.aspx");
        }

        protected void btnColones_Click(object sender, EventArgs e)
        {
            Session["MonedaEscogida"] = "Colones";
            Session["PresionoBotonMoneda"] = "presionado";
            Response.Redirect("/pages/CalculadoraCreditos.aspx");
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PresionoBotonMoneda"] == null)
                {
                    script = string.Format("javascript:notificacion('{0}')", "Debes elegir un tipo de moneda antes de calcular");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                }
                else if (txtMonto.Value.ToString().Equals("") || txtTasa.Value.ToString().Equals("") || txtRangoAñosPrestamo.Value.ToString().Equals(""))
                {
                    script = string.Format("javascript:notificacion('{0}')", "No pueden quedar campos sin llenar");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                }
                else
                {
                    if (double.Parse(txtMonto.Value.ToString()) > double.Parse(Session["MontoMaximo"].ToString()) || double.Parse(txtMonto.Value.ToString()) < double.Parse(Session["MontoMinimo"].ToString()))
                    {
                        script = string.Format("javascript:notificacion('{0}')", "El monto ingresado no esta entre el monto minimo y maximo, favor cambiarlo");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                    }
                    else
                    {
                        double resultado = metodos.calcularCuotaMensual(float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAñosPrestamo.Value.ToString()), float.Parse(txtTasa.Value.ToString()));
                        decimal temp = 0;
                        string formato = resultado.ToString();
                        decimal.TryParse(formato, out temp);
                        formato = temp.ToString("N2");
                        txtMontoMensual.Value = formato.ToString();
                        Session["PresionoBotonMoneda"] = null;
                        txtMonto.Value = "";
                        txtRangoAñosPrestamo.Value = "";
                    }

                }


            }
            catch (Exception ex)
            {
                script = string.Format("javascript:error('{0}')", "Ocurrio un error al calcular la cuota mensual del préstamo");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
            }
        }


    }
}