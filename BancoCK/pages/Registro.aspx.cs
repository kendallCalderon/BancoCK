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
    }
}