using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Login"] == null)
                {
                    Response.Redirect("Home.aspx");
                }


            }
            DataTable detalles = new DataTable();

            detalles.Columns.Add("Identificacion");
            detalles.Columns.Add("Nombre Cliente");
            detalles.Columns.Add("Primer Apellido");
            detalles.Columns.Add("Segundo Apellido");
            detalles.Columns.Add("Monto Préstamo");
            detalles.Columns.Add("Moneda");
            detalles.Columns.Add("Cuota Mensual");
            detalles.Columns.Add("Salario Neto");
            detalles.Columns.Add("Teléfono");
            detalles.Columns.Add("Correo");


            System.Data.DataRow row = detalles.NewRow();

            row["Identificacion"] = "y2y22yy3";
            row["Nombre Cliente"] = "Cristian";
            row["Primer Apellido"] = "Arias";
            row["Segundo Apellido"] = "calero";
            row["Monto Préstamo"] = "2000";
            row["Moneda"] = "dolares";
            row["Cuota Mensual"] = "2000";
            row["Salario Neto"] = "2000";
            row["Teléfono"] = "838394";
            row["Correo"] = "camilorestrepo@cuc.cr";
            detalles.Rows.Add(row);

            GridView1.DataSource = detalles;
            GridView1.DataBind();
        }
    }
}