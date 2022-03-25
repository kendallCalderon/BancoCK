using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class Prestamos : System.Web.UI.Page
    {
        string script;

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            try
            {
                Session["tipoPrestamo"] = "Vivienda";
                Response.Redirect("/pages/FormularioPrestamo.aspx");

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "ocurrio un error al darle click al boton, detalles: " + ex.Message);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
                Session["tipoPrestamo"] = "Personal";
                Response.Redirect("/pages/FormularioPrestamo.aspx");

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "ocurrio un error al darle click al boton, detalles: " + ex.Message);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            try
            {
                Session["tipoPrestamo"] = "Vehiculo";
                Response.Redirect("/pages/FormularioPrestamo.aspx");

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "ocurrio un error al darle click al boton, detalles: " + ex.Message);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            try
            {
                Session["tipoPrestamo"] = "Refundir mis deudas";
                Response.Redirect("/pages/FormularioPrestamo.aspx");

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "ocurrio un error al darle click al boton, detalles: " + ex.Message);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            try
            {
                Session["tipoPrestamo"] = "Apoyo Negocio";
                Response.Redirect("/pages/FormularioPrestamo.aspx");

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "ocurrio un error al darle click al boton, detalles: " + ex.Message);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            try
            {
                Session["tipoPrestamo"] = "Financiar Educación";
                Response.Redirect("/pages/FormularioPrestamo.aspx");

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "ocurrio un error al darle click al boton, detalles: " + ex.Message);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

      
    }
}