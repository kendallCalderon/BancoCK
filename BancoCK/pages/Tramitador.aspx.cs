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
   ServicesReferences.serviciosPruebaSoapClient metodos = new ServicesReferences.serviciosPruebaSoapClient();
     
        string script;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Login"] == null)
                {
                    Response.Redirect("Home.aspx");
                }


            }

            try
            {
                
                DataTable detalles = new DataTable();


                if (!IsPostBack)
                {
                    detalles = metodos.devolverPrestamosClientes();
                    detalles.Columns["idPrestamos"].ColumnName = "Préstamo #";
                    GridView1.DataSource = detalles;
                    GridView1.DataBind();
                }
                else
                {
                    if (Session["refrescar"] != null)
                    {
                        detalles = metodos.devolverPrestamosClientes();
                        detalles.Columns["idPrestamos"].ColumnName = "Préstamo #";
                        GridView1.DataSource = detalles;
                        GridView1.DataBind();
                        Session["refrescar"] = null;
                    }
                }

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al cargar la tabla con informacion de BD");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error",script, true);
            }

        }

        protected void AsignarAnalista(Object sender, CommandEventArgs e)
        {
            try
            {
                string idPrestamo = (sender as LinkButton).CommandArgument;
                string []arreglo = new string[3];
                arreglo = Session["opcionCombo"].ToString().Split(' ');
                string cedulaAnalista = metodos.devolverCedulaAnalista(arreglo[0], arreglo[1], arreglo[2]);
                metodos.asignarAnalista(cedulaAnalista, int.Parse(idPrestamo));
                Session["opcionCombo"] = null;
                metodos.cambiarEstadoPrestamoSolicitud(int.Parse(idPrestamo));
                Session["refrescar"] = "empezar";
                script = string.Format("javascript:notificacion('{0}')", "Se ha asignado el prestamo al analista correctamente");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion",script, true);


            }
            catch (Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al cargar al asignar un prestamo para un analista");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error",script, true);
            }
        }

        protected void CambioEnComBoBox(object sender, System.EventArgs e)
        {

            DropDownList listaAnalistas = sender as DropDownList;
            Session["opcionCombo"] = listaAnalistas.SelectedValue.ToString();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string prestamo = tipoPrestamo.Value.ToString();
                string cedula = txtCedulaAnalista.Value.ToString();
                DataTable prestamos = new DataTable();
                if(prestamo.Equals("") == false && cedula.Equals("") == false)
                {
                    prestamos = metodos.devolverPrestamos_nombre_cedula(prestamo, cedula);
                    if(prestamos.Rows.Count == 0)
                    {
                        script = string.Format("javascript:notificacion('{0}')", "No se encontraron registros con esos filtros");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion",script, true);
                    }
                    else
                    {
                        prestamos.Columns["idPrestamos"].ColumnName = "Préstamo #";
                        GridView1.DataSource = prestamos;
                        GridView1.DataBind();
                    }

                }else if(prestamo.Equals("") == false && cedula.Equals("") == true)
                {
                    prestamos = metodos.devolverPrestamos_tipoPrestamo(prestamo);
                    if (prestamos.Rows.Count == 0)
                    {
                        script = string.Format("javascript:notificacion('{0}')", "No se encontraron registros con esos filtros");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion",script, true);
                    }
                    else
                    {
                        prestamos.Columns["idPrestamos"].ColumnName = "Préstamo #";
                        GridView1.DataSource = prestamos;
                        GridView1.DataBind();
                    }
                }

            }catch(Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al tratar de buscar por filtro");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error",script, true);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList listaPrestamos = (e.Row.FindControl("ddlNombreAnalistas") as DropDownList);
                    Session["opcionCombo"] = listaPrestamos.SelectedValue.ToString();

                }
            }
            catch(Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al cargar la lista desplegable");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
               
            }
           
        }
    }
}