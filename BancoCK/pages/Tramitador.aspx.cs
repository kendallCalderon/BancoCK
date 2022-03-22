using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable detalles = new DataTable();

                detalles.Columns.Add("Préstamo #");
                detalles.Columns.Add("Identificación");
                detalles.Columns.Add("Nombre Analista");


                System.Data.DataRow row = detalles.NewRow();

                row["Préstamo #"] = "y2y22yy3";
                row["Identificación"] = "Cristian";
                row["Nombre Analista"] = "Arias";
                detalles.Rows.Add(row);

                GridView1.DataSource = detalles;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {

            }
           
        }
    }
}