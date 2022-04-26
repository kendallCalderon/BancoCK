using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class Prestamos : System.Web.UI.Page
    {
        string script;
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
     
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            try
            {



                if (Session["Login"] == null)
                {



                    Session["tipoPrestamo"] = "Préstamo Vivienda";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Préstamo Vivienda", 1, "clicks", fecha);
                    Response.Redirect("FormularioPrestamo.aspx");

                }
                else
                {
                    Session["tipoPrestamo"] = "Préstamo Vivienda";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickAutenticado("Préstamo Vivienda", 1, "clicks", fecha);
                    Response.Redirect("FormularioAutenticado.aspx");
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
                if (Session["Login"] == null)
                {

                    Session["tipoPrestamo"] = "Préstamo Personal";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Préstamo Personal", 1, "clicks", fecha);
                    Response.Redirect("FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Préstamo Personal";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickAutenticado("Préstamo Personal", 1, "clicks", fecha);
                    Response.Redirect("FormularioAutenticado.aspx");
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
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Préstamo vehiculo", 1, "clicks", fecha);
                    Response.Redirect("FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Préstamo vehiculo";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickAutenticado("Préstamo vehiculo", 1, "clicks", fecha);
                    Response.Redirect("FormularioAutenticado.aspx");
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
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Refundir mis deudas", 1, "clicks", fecha);
                    Response.Redirect("FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Refundir mis deudas";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickAutenticado("Refundir mis deudas", 1, "clicks", fecha);
                    Response.Redirect("FormularioAutenticado.aspx");
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
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Apoyo Negocio", 1, "clicks", fecha);
                    Response.Redirect("FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Apoyo Negocio";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickAutenticado("Apoyo Negocio", 1, "clicks", fecha);
                    Response.Redirect("FormularioAutenticado.aspx");
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
                    Session["tipoPrestamo"] = "Préstamo Educacion";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickUsuarioNoAutenticado("Préstamo Educación", 1, "clicks", fecha);
                    Response.Redirect("FormularioPrestamo.aspx");
                }
                else
                {
                    Session["tipoPrestamo"] = "Préstamo Educacion";
                    var fecha = DateTime.ParseExact(DateTime.Now.ToString("MM-dd-yyyy"), "MM-dd-yyyy", CultureInfo.InvariantCulture); // guardamos la fecha actual del préstamo
                    metodos.registrarIndicadorPrestamoClickAutenticado("Préstamo Educación", 1, "clicks", fecha);
                    Response.Redirect("FormularioAutenticado.aspx");
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
            Response.Redirect("CalculadoraCreditos.aspx");
        }

        protected void btnPersonal_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Préstamo Personal";
            Response.Redirect("CalculadoraCreditos.aspx");
        }

        protected void btnVehiculo_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Préstamo vehiculo";
            Response.Redirect("CalculadoraCreditos.aspx");
        }

        protected void btnDeudas_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Refundir mis deudas";
            Response.Redirect("CalculadoraCreditos.aspx");
        }

        protected void btnNegocio_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Apoyo Negocio";
            Response.Redirect("CalculadoraCreditos.aspx");
        }

        protected void btnEducacion_Click(object sender, EventArgs e)
        {
            Session["tipoPrestamo"] = "Préstamo Educacion";
            Response.Redirect("CalculadoraCreditos.aspx");
        }
    }
}