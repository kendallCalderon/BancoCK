using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class Registro : System.Web.UI.Page
    {
        ConsumoBaseDatos iConsumoBaseDatos = new ConsumoBaseDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPass.Visible = false;
            if (IsPostBack == false)
            {
                ListItem i;
                i = new ListItem("Nacional", "1");
                ddlTipoCedula.Items.Add(i);
                i = new ListItem("Extranjero", "2");
                ddlTipoCedula.Items.Add(i);





            }
         


        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string Rol = "Cliente";
            bool validarExistencia = false;

            validarExistencia = iConsumoBaseDatos.ValidarExistenciaUsuario(Identificacion.Value);

            if (validarExistencia == false)
            {
                iConsumoBaseDatos.RegistrarUsuario(Identificacion.Value, Nombre.Value, Rol, PrimerApellido.Value, SegundoApellido.Value, Correo.Value, Telefono.Value, Contraseña.Value, ddlTipoCedula.Text);
            }
            else
            {
                lblPass.Visible = true;
            }
            
           
                

            Page.ClientScript.RegisterStartupScript(this.GetType(), "QuitarRequired", "QuitarRequired();",  true);

            ModalExito.Show();
            
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("/pages/Home.aspx");
        }
    }
}