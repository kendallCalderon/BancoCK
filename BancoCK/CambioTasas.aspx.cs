using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        DataTable tabla = new DataTable();
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                tabla = metodos.traerTasas();

                tabla.Columns["Nombre"].ColumnName = "Nombre Préstamo";
                tabla.Columns["Tasa"].ColumnName = "Tasa en Colones";
                tabla.Columns["TasaDolares"].ColumnName = "Tasa en dólares";

                GridView1.DataSource = tabla;
                GridView1.DataBind();

            }
            catch(Exception ex)
            {

            }
        }

        protected void Modificar(object sender, EventArgs e)
        {

            try
            {
                Session["nombre"] = (sender as LinkButton).CommandArgument;
                string tasas = metodos.traerPrestamosxTasas(Session["nombre"].ToString());
                string[] arreglo = new string[2];
                arreglo = tasas.Split(',');
                tasaColones.Value = arreglo[0];
                tasaDolares.Value = arreglo[1];
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModal();", true);

            }
            catch(Exception ex)
            {

            }

        }

        protected void btnModals(object sender, EventArgs e)
        {
            if(float.Parse(tasaColones.Value) <=1 || float.Parse(tasaDolares.Value) <= 1 || float.Parse(tasaColones.Value) >20  || float.Parse(tasaDolares.Value) > 20 )
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalAviso();", true);
            }
            else
            {
                metodos.cambioTasas(float.Parse(tasaColones.Value), float.Parse(tasaDolares.Value), Session["nombre"].ToString());
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
            }
            
        }
    }
}