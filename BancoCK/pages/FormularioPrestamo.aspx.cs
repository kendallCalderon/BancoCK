using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class FormularioPrestamo : System.Web.UI.Page
    {
    ServicesReferences.serviciosPruebaSoapClient metodos = new ServicesReferences.serviciosPruebaSoapClient();
        string script = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (!IsPostBack)
            {
                if (Session["Login"] == null)
                {
                    Response.Redirect("Home.aspx");
                }


            }*/
        }

        protected void btnTramitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/Tramitador.aspx");
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            try
            {
                float tasaPrestamo = 0;
                double cuotaMensual = 0;
                
                if (txtIdentificacion.Value.ToString().Equals("") || txtNombre.Value.ToString().Equals("") || txtApellido1.Value.ToString().Equals("") || txtApellido2.Value.ToString().Equals("") || txtCorreo.Value.ToString().Equals("") || txtTelefono.Value.ToString().Equals("") || txtSalarioNeto.Value.ToString().Equals("") || txtAñosLaborando.Value.ToString().Equals("") || txtSalarioBruto.Value.ToString().Equals(""))
                {
                    script = string.Format("javascript:notificacion('{0}')", "No pueden quedar campos sin llenar");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                }
                else
                {
                    string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                    metodos.guardarInformacionClienteNoAutenticado(txtIdentificacion.Value.ToString(), txtNombre.Value.ToString(), txtApellido1.Value.ToString(), txtApellido2.Value.ToString(), txtCorreo.Value.ToString(), int.Parse(txtTelefono.Value.ToString()),"NoLogeado");
                    if(txtCombo.SelectedIndex == 0)
                    {
                        tasaPrestamo = metodos.devolverTasaTipoPrestamoDolares(Session["tipoPrestamo"].ToString());
                        cuotaMensual = metodos.calcularCuotaMensual(float.Parse(txtMonto.Value.ToString()),int.Parse(txtRangoAños.Value.ToString()),tasaPrestamo);
                    }
                    else
                    {
                        tasaPrestamo = metodos.devolverTasaTipoPrestamo(Session["tipoPrestamo"].ToString());
                        cuotaMensual = metodos.calcularCuotaMensual(float.Parse(txtMonto.Value.ToString()), int.Parse(txtRangoAños.Value.ToString()), tasaPrestamo);
                    }
                    metodos.registrarPrestamoClienteOriginal( txtIdentificacion.Value.ToString(), fecha,"espera",float.Parse(txtMonto.Value.ToString()),int.Parse(txtRangoAños.Value.ToString()),cuotaMensual, float.Parse(txtSalarioNeto.Value.ToString()),int.Parse(txtAñosLaborando.Value.ToString()), float.Parse(txtSalarioBruto.Value.ToString()), Session["tipoPrestamo"].ToString());
                    script = string.Format("javascript:notificacion('{0}')", "Se ha enviado tu solicitud de crédito, favor estar atento a tu correo sobre la aprobación de tu credito");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                    Session["tipoPrestamo"] = null;
                    metodos.enviarCorreo(txtCorreo.Value.ToString());
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