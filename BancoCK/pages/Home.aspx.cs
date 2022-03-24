using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class Home :  System.Web.UI.Page 
    {
        ConsumoBaseDatos iConsumoBaseDatos= new ConsumoBaseDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

            lblError.Visible = false;
            
        }

        protected void btnRgistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/Registro.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            
            string validar  = iConsumoBaseDatos.CredencialesUsuario(tbxUsuario.Value, tbxPassword.Value);

            if (validar.Equals("0"))
            {
                lblError.Visible = true;
            }
            else if (validar.Equals("Cliente"))
            {
                Response.Redirect("/pages/HomeAutenticado.aspx");

            }else if (validar.Equals("Tramitador"))
            {
                Response.Redirect("/pages/Tramitador.aspx");
            }
            else
            {
                Response.Redirect("/pages/Analista.aspx");
            }
           
        }

     
    }
}