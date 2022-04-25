using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Cliente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                btnCerrarSesion.Visible = false;
            }
            else
            {
                btnCerrarSesion.Visible = true;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if(Session["Login"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("HomeAutenticado.aspx");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}