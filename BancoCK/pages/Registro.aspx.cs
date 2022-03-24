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
            iConsumoBaseDatos.RegistrarUsuario(Identificacion.Value, Nombre.Value, Rol, PrimerApellido.Value, SegundoApellido.Value, Correo.Value, Telefono.Value, Salarioneto.Value, Añoslaborando.Value, Salariobruto.Value, Contraseña.Value, ddlTipoCedula.Text);
            ModalExito.Show();

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/Home.aspx");
        }
    }
}