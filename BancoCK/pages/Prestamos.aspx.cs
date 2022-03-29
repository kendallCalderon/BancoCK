using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class Prestamos : System.Web.UI.Page
    {
        string script;
        WBSMetodos.WBSmetodosClient metodos = new WBSMetodos.WBSmetodosClient();
        Temporal temp = new Temporal();
        string fecha;
        DataTable tabla = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            try
            {

                if(Session["Login"] == null)
                {

                Session["tipoPrestamo"] = "Préstamo Vivienda";
                fecha = DateTime.Now.ToString("dd-MM-yyyy");
                temp.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Préstamo Vivienda", 1, "clicks", DateTime.Parse(fecha));
                Response.Redirect("/pages/FormularioPrestamo.aspx");
                
                }
                else
                {
                    Session["tipoPrestamo"] = "Préstamo Vivienda";
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickAutenticado("Préstamo Vivienda", 1, "clicks", DateTime.Parse(fecha));
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
                    
                    Session["tipoPrestamo"] = "Préstamo Personal";
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Préstamo Personal", 1, "clicks", DateTime.Parse(fecha));
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Préstamo Personal";
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickAutenticado("Préstamo Personal", 1, "clicks", DateTime.Parse(fecha));
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
                    Session["tipoPrestamo"] = "Préstamo vehiculo";
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Préstamo vehiculo", 1, "clicks", DateTime.Parse(fecha));
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Préstamo vehiculo";
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickAutenticado("Préstamo vehiculo", 1, "clicks", DateTime.Parse(fecha));
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
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Refundir mis deudas", 1, "clicks", DateTime.Parse(fecha));
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Refundir mis deudas";
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickAutenticado("Refundir mis deudas", 1, "clicks", DateTime.Parse(fecha));
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
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Apoyo Negocio", 1, "clicks", DateTime.Parse(fecha));
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Apoyo Negocio";
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickAutenticado("Apoyo Negocio", 1, "clicks", DateTime.Parse(fecha));
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
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Financiar Educación", 1, "clicks", DateTime.Parse(fecha));
                    Response.Redirect("/pages/FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Financiar Educación";
                    fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    temp.registrarIndicadorPrestamoClickAutenticado("Financiar Educación", 1, "clicks", DateTime.Parse(fecha));
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