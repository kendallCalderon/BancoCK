using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class FormularioPrestamo : System.Web.UI.Page
    {
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        string script = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTramitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/Tramitador.aspx");
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                metodos.guardarInformacionClienteNoAutenticado(txtIdentificacion.Value.ToString(), txtNombre.Value.ToString(), txtApellido1.Value.ToString(), txtApellido2.Value.ToString(), txtCorreo.Value.ToString(), int.Parse(txtTelefono.Value.ToString()), float.Parse(txtSalarioNeto.Value.ToString()), int.Parse(txtAñosLaborando.Value.ToString()), float.Parse(txtSalarioBruto.Value.ToString()), "Cliente");
                metodos.registrarPrestamoCliente(txtIdentificacion.Value.ToString(), fecha);
                script = string.Format("javascript:notificacion('{0}')", "Se ha enviado tu solicitud de crédito, favor estar atento a tu correo sobre la aprobación de tu credito");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:alerta('{0}')", "Error al guardar la informacion del cliente en la BD, favor revisar la bd del sistema bancario");

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", script, true);
            }
        }

    }
}