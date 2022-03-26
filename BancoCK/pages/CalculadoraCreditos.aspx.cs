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
        string script = "",tipoPrestamo = "";

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
                float tasa = metodos.devolverTasaTipoPrestamo(tipoPrestamo);
                txtTasa.Value = tasa.ToString();
            }

           
        }
    }
}