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

            lblPass.Visible = false;
            
        }

        protected void btnRgistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/Registro.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = tbxUsuario.Value;
            string password = tbxPassword.Value;
            string validar  = iConsumoBaseDatos.CredencialesUsuario(tbxUsuario.Value, tbxPassword.Value);

            if (validar.Equals("0"))
            {
                lblPass.Visible = true;
            }
            else if (validar.Equals("Cliente"))
            {
                HttpCookie cookie = new HttpCookie("Token", username);
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(cookie);

                Session["Login"] = username;
                Response.Redirect("/pages/HomeAutenticado.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                

            }else if (validar.Equals("Tramitador"))
            {

                HttpCookie cookie = new HttpCookie("Token", username);
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(cookie);

                Session["Login"] = username;
                Response.Redirect("/pages/Tramitador.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
               
            }
            else
            {

                HttpCookie cookie = new HttpCookie("Token", username);
                cookie.Expires = DateTime.Now.AddDays(-1);
                this.Response.Cookies.Add(cookie);

                Session["Login"] = username;
                Response.Redirect("/pages/Analista.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                
            }
           
        }

     
    }
}