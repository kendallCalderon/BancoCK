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

                if(Session["Login"] == null)
                {
                Session["tipoPrestamo"] = "Vivienda";
                Response.Redirect("/pages/FormularioPrestamo.aspx");

                }
                else
                {
                    Session["tipoPrestamo"] = "Vivienda";
                    Response.Redirect("/pages/FormularioAutenticado.aspx");
                }

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
                if(Session["Login"]== null)
                {
                    Session["tipoPrestamo"] = "Personal";
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Personal";
                    Response.Redirect("/pages/FormularioAutenticado.aspx");
                }

               

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
                if (Session["Login"] == null)
                {
                    Session["tipoPrestamo"] = "Vehiculo";
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Vehiculo";
                    Response.Redirect("/pages/FormularioAutenticado.aspx");
                }

               

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

                if (Session["Login"] == null)
                {
                    Session["tipoPrestamo"] = "Refundir mis deudas";
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Refundir mis deudas";
                    Response.Redirect("/pages/FormularioAutenticado.aspx");
                }

                

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

                if (Session["Login"] == null)
                {
                    Session["tipoPrestamo"] = "Apoyo Negocio";
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Apoyo Negocio";
                    Response.Redirect("/pages/FormularioAutenticado.aspx");
                }

              

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
                if (Session["Login"] == null)
                {
                    Session["tipoPrestamo"] = "Financiar Educación";
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Financiar Educación";
                    Response.Redirect("/pages/FormularioAutenticado.aspx");
                }

              

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "ocurrio un error al darle click al boton, detalles: " + ex.Message);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

        protected void btnVivienda_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Préstamo Vivienda";
            Response.Redirect("/pages/CalculadoraCreditos.aspx");
        }

        protected void btnPersonal_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Préstamo Personal";
            Response.Redirect("/pages/CalculadoraCreditos.aspx");
        }

        protected void btnVehiculo_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Préstamo vehiculo";
            Response.Redirect("/pages/CalculadoraCreditos.aspx");
        }

        protected void btnDeudas_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Refundir mis deudas";
            Response.Redirect("/pages/CalculadoraCreditos.aspx");
        }

        protected void btnNegocio_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Apoyo Negocio";
            Response.Redirect("/pages/CalculadoraCreditos.aspx");
        }

        protected void btnEducacion_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Préstamo Educacion";
            Response.Redirect("/pages/CalculadoraCreditos.aspx");
        }
    }
}