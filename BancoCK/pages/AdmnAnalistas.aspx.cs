using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class AdmnAnalistas : System.Web.UI.Page
    {
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["Login"] == null)
                {
                    Response.Redirect("Home.aspx");
                }


            }
            gvAnalistas.DataSource = metodos.ObtenerAnalistas();
            gvAnalistas.DataBind();

        }

        protected void gvAnalistas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "btnModificar")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAnalistas.Rows[fila];
                tbxIdentificacion.Value = row.Cells[0].Text;
                tbxNombre.Value = Server.HtmlDecode(row.Cells[1].Text);
                tbxPrimerApellido.Value = Server.HtmlDecode(row.Cells[2].Text);
                tbxSegundoApellido.Value = Server.HtmlDecode( row.Cells[3].Text);
                tbxMail.Value = Server.HtmlDecode( row.Cells[4].Text);
                tbxTelefono.Value = row.Cells[5].Text;
                ModalModificar.Show();
            }
            else if(e.CommandName== "btnEliminar")
            {

                GridViewRow row = gvAnalistas.Rows[Convert.ToInt32(e.CommandArgument)];
                metodos.EliminarAnalista(row.Cells[0].Text);
                gvAnalistas.DataSource = metodos.ObtenerAnalistas();
                gvAnalistas.DataBind();
            }

        }



        protected void btnInsertar_Click1(object sender, EventArgs e)
        {
            ModalInsertar.Show();
        }

        protected void btnicon_Click(object sender, EventArgs e)
        {
            ModalInsertar.Hide();
        }

        protected void btnCerrarModificar_Click(object sender, EventArgs e)
        {
            ModalModificar.Hide();
        }

        protected void btnInsertarConfirmar_Click1(object sender, EventArgs e)
        {
            metodos.InsertarAnalista(tbxId.Value, tbxNom.Value, tbxRol.Value, tbxPap.Value, tbxSap.Value, tbxCorreo.Value, tbxTel.Value, tbxPass.Value);
            ModalInsertar.Hide();
            gvAnalistas.DataSource = metodos.ObtenerAnalistas();
            gvAnalistas.DataBind();
            tbxId.Value = "";
            tbxNom.Value="";
            tbxPap.Value="";
            tbxSap.Value="";
            tbxCorreo.Value="";
            tbxTel.Value="";
            tbxPass.Value = "";
        }

        protected void btnModificarConfirmar_Click1(object sender, EventArgs e)
        {
            metodos.ModificarAnalista(tbxIdentificacion.Value, tbxNombre.Value, tbxPrimerApellido.Value, tbxSegundoApellido.Value, tbxMail.Value, tbxTelefono.Value);
            ModalModificar.Hide();
            gvAnalistas.DataSource = metodos.ObtenerAnalistas();
            gvAnalistas.DataBind();
        }

        protected void gvAnalistas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAnalistas.PageIndex = e.NewPageIndex;
            gvAnalistas.DataBind();
            
        }


      
    }
}