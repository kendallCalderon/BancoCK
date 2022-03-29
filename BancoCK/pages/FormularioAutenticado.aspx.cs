using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class FormularioAutenticado : System.Web.UI.Page
    {
        WBSMetodos.WBSmetodosClient  metodos = new WBSMetodos.WBSmetodosClient();
        string script = "";
        Temporal temp = new Temporal();
        string descripcion = "", requisitos = "";
        DataTable tabla = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Login"] == null)
                {
                    Response.Redirect("Home.aspx");
                }


            }

            tabla = temp.devolverInformacionPrestamos(Session["tipoPrestamo"].ToString());
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
            try
            {
                if (txtSalarioNeto.Value.ToString().Equals("") || txtAñosLaborando.Value.ToString().Equals("") || txtSalarioBruto.Value.ToString().Equals(""))
                {
                    script = string.Format("javascript:notificacion('{0}')", "No pueden quedar campos sin llenar");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                }
                else
                {
                     string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    metodos.registrarPrestamoClienteOriginal(Session["Login"].ToString(), fecha, "espera", float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAños.Value.ToString()), 2344, float.Parse(txtSalarioNeto.Value.ToString()), int.Parse(txtAñosLaborando.Value.ToString()), float.Parse(txtSalarioBruto.Value.ToString()), Session["tipoPrestamo"].ToString());
                    string Rol = "Cliente";
                    string Correo = metodos.ObtenerCorreo(Session["Login"].ToString(), Rol);
                    metodos.enviarCorreo(Correo);
                    script = string.Format("javascript:notificacion('{0}')", "Se ha enviado tu solicitud de crédito, favor estar atento a tu correo sobre la aprobación de tu credito");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true); 
                  

                }
            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "Error al guardar la informacion del cliente en la BD, favor revisar la bd del sistema bancario");

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
           
        }
    }
}