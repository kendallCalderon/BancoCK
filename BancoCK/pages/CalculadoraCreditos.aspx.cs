using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        string script = "", tipoPrestamo = "", montosPermitidos = "", valor1 = "", valor2 = "", fecha="";
        decimal numero = 0;
        float tasaInteres = 0;
        string[] vector = new string[2];
        decimal temp;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Llenamos el combo box
                    cbxComboPrestamo.Items.Add("Préstamo vehiculo");
                    cbxComboPrestamo.Items.Add("Préstamo Vivienda");
                    cbxComboPrestamo.Items.Add("Refundir mis deudas");
                    cbxComboPrestamo.Items.Add("Préstamo Educacion");
                    cbxComboPrestamo.Items.Add("Préstamo Personal");
                    cbxComboPrestamo.Items.Add("Apoyo Negocio");
                    tipoPrestamo = Session["tipoPrestamo"].ToString();
                    cbxComboPrestamo.SelectedValue = tipoPrestamo;
                    //Obtenemos la tasa de interes
                    tasaInteres = metodos.devolverTasaTipoPrestamo(tipoPrestamo);
                    txtTasa.Value = tasaInteres.ToString();
                    //obtenemos el monto Maximo y minimo
                    montosPermitidos = metodos.devolverLimiteMontoPrestamo(tipoPrestamo);
                    vector = montosPermitidos.Split(',');
                    ponerDecimales();
                    txtMensajeMonto.InnerText = "Monto Maximo: " + vector[0].Replace('$', '₡') + ",  Monto Minimo: " + vector[1].Replace('$', '₡');

                }

                //preguntamos si se eligio un tipo de prestamo
                if (Session["tipoPrestamo"] != null)
                {
                    if (Session["tipoPrestamo"].ToString().Equals(cbxComboPrestamo.SelectedValue.ToString()) == false)
                    {
                        tipoPrestamo = cbxComboPrestamo.SelectedValue;
                        Session["MonedaEscogida"] = "Colones";
                    }
                    else
                    {
                        tipoPrestamo = Session["tipoPrestamo"].ToString();
                    }

                }
                //mostramos el mensaje con el monto máximo y minimo
                if (Session["MonedaEscogida"] != null)
                {
                    if (Session["MonedaEscogida"].ToString().Equals("Dolares"))
                    {
                        tasaInteres = metodos.devolverTasaTipoPrestamoDolares(tipoPrestamo);
                        txtTasa.Value = tasaInteres.ToString();
                        montosPermitidos = metodos.devolverLimiteMontoPrestamoDolares(tipoPrestamo);
                        vector = montosPermitidos.Split(',');
                        ponerDecimales();
                        txtMensajeMonto.InnerText = "Monto Maximo: " + vector[0].Replace('₡', '$') + ",  Monto Minimo: " + vector[1].Replace('₡', '$');
                        Session["MontoMaximo"] = vector[0];
                        Session["MontoMinimo"] = vector[1];
                        Session["MonedaSigno"] = '$';
                    }
                    else
                    {
                        tasaInteres = metodos.devolverTasaTipoPrestamo(tipoPrestamo);
                        txtTasa.Value = tasaInteres.ToString();
                        montosPermitidos = metodos.devolverLimiteMontoPrestamo(tipoPrestamo);
                        vector = montosPermitidos.Split(',');
                        ponerDecimales();
                        txtMensajeMonto.InnerText = "Monto Maximo: " + vector[0].Replace('$', '₡') + ",  Monto Minimo: " + vector[1].Replace('$', '₡');
                        vector[0] = vector[0].Replace('$', '₡');
                        vector[1] = vector[0].Replace('$', '₡');
                        Session["MontoMaximo"] = vector[0];
                        Session["MontoMinimo"] = vector[1];
                        Session["MonedaSigno"] = '₡';
                    }


                }


            }
            catch (Exception ex)
            {
                error.InnerText = "Ocurrio un error al calcular la cuota mensual del préstamo, detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
            }

        }

        private void ponerDecimales()
        {
            Session["montoMayor"] = vector[0];
            Session["montoMenor"] = vector[1];
            numero = Decimal.Parse(vector[0]);
            valor1 = String.Format("{0:C}", numero);
            vector[0] = valor1;
            numero = Decimal.Parse(vector[1]);
            valor2 = String.Format("{0:C}", numero);
            vector[1] = valor2;
        }
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prestamos.aspx");
        }

        protected void btnTramitar_Click(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("formularioPrestamo.aspx");
            }
            else
            {
                Response.Redirect("FormularioAutenticado.aspx");
            }
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
            
            Response.Redirect("CalculadoraCreditos.aspx");

        }

        protected void btnColones_Click(object sender, EventArgs e)
        {
            Session["MonedaEscogida"] = "Colones";
            Session["PresionoBotonMoneda"] = "presionado";
            Response.Redirect("CalculadoraCreditos.aspx");

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PresionoBotonMoneda"] == null)
                {
                    textoModal.InnerText = "Debes elegir un tipo de moneda antes de calcular";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
                }
                else if (txtMonto.Value.ToString().Equals("") || txtTasa.Value.ToString().Equals("") || txtRangoAñosPrestamo.Value.ToString().Equals(""))
                {
                    textoModal.InnerText = "Debes elegir un tipo de moneda antes de calcular";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
                }
                else
                {

                    if (double.Parse(txtMonto.Value.ToString()) > double.Parse(Session["MontoMayor"].ToString()) || double.Parse(txtMonto.Value.ToString()) < double.Parse(Session["MontoMenor"].ToString()))
                    {
                        if (Session["MonedaEscogida"].ToString().Equals("Dolares"))
                        {
                            textoModal.InnerText = "El monto debe esta entre " + Session["MontoMaximo"].ToString() + " y " + Session["MontoMinimo"].ToString() + " Dolares";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
                        }
                        else
                        {
                            textoModal.InnerText = "El monto debe esta entre " + Session["MontoMaximo"].ToString() + " y " + Session["MontoMinimo"].ToString() + " Colones";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
                        }
                      
                    }
                    else
                    {

                        int años = metodos.traerAños(Session["tipoPrestamo"].ToString());
                        if(int.Parse(txtRangoAñosPrestamo.Value.ToString()) > años || int.Parse(txtRangoAñosPrestamo.Value.ToString()) <= 0)
                        {
                            textoModal.InnerText = "El maximo de años permitido para el prestamo tipo " + Session["tipoPrestamo"].ToString() + " es de " + años + " años y minimo de un año";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
                        }
                        else
                        {
                            double resultado = metodos.calcularCuotaMensual(float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAñosPrestamo.Value.ToString()), float.Parse(txtTasa.Value.ToString()));
                            string cadena = string.Format("{0:N2}", resultado);
                            numero = Decimal.Parse(cadena);
                            valor1 = String.Format("{0:C}", numero);
                            String signo = Session["MonedaSigno"].ToString();
                            valor1 = valor1.Replace('₡', char.Parse(Session["MonedaSigno"].ToString()));
                            txtMontoMensual.Value = valor1;
                            Session["PresionoBotonMoneda"] = null;
                            Session["MonedaSigno"] = null;
                            txtMonto.Value = "";
                            txtRangoAñosPrestamo.Value = "";


                            if (Session["Login"] == null)
                            {
                                var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                                metodos.registrarIndicadorPrestamoUsuarioNoAutenticadoPrecalculo(Session["tipoPrestamo"].ToString(), 1, "Calculos", fecha);
                            }
                            else
                            {
                                var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                                metodos.registrarIndicadorPrestamoUsuarioAutenticadoPrecalculo(Session["tipoPrestamo"].ToString(), 1, "Calculos", fecha);
                            }
                        }
                       

                    }

                }


            }
            catch (Exception ex)
            {
                error.InnerText = "Ocurrio un error al calcular la cuota mensual del préstamo, detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
              
            }
        }

    }

}