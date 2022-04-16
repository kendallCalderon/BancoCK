using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();

        DataTable detalles = new DataTable();

        string script;

        protected void AsignarAnalista(object sender, EventArgs e)
        {
            bool continuar = false;
            try
            {
                string idPrestamo = (sender as LinkButton).CommandArgument;
                for(int x=0; x<GridView1.Rows.Count; x++)
                {
                    if (GridView1.Rows[x].Cells[0].Text.Equals(idPrestamo))
                    {
                        if ((GridView1.Rows[x].BackColor == System.Drawing.ColorTranslator.FromHtml("#D03737")) == false)
                        {
                            continuar = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (continuar)
                {
                    string[] arreglo = new string[2];
                    string analista = comboAnlista.SelectedValue.ToString();
                    arreglo = analista.Split('-');

                        metodos.asignarAnalista(arreglo[0], int.Parse(idPrestamo));
                        metodos.cambiarEstadoPrestamoSolicitud(int.Parse(idPrestamo));
                        detalles = metodos.devolverPrestamosClientes();
                        script = string.Format("javascript:notificacion('{0}')", "Se ha asignado el prestamo al analista correctamente");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                        string correo = metodos.ObtenerCorreo(arreglo[0], "Analista");
                        metodos.correoAnalistaInforme("camilorestrepo@outlook.es");
                        Response.Redirect("/pages/Tramitador.aspx");
                   
                }
                else
                {
                    script = string.Format("javascript:notificacion('{0}')", "El analista solo se le puede asignar solicitudes que no tienen color rojo");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
                }
               
            }
            catch (Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al cargar al asignar un prestamo para un analista");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                detalles = metodos.devolverPrestamosClientes();
                detalles.Columns["idPrestamos"].ColumnName = "Préstamo #";
                detalles.Columns["FechaCredito"].ColumnName = "Fecha crédito";
                detalles.Columns["TipoPrestamo"].ColumnName = "Tipo Prestamo";
                GridView1.DataSource = detalles;
                GridView1.DataBind();

                List<string> lista = new List<string>();
                lista = metodos.comboAnalistas();

                comboAnlista.Items.Clear();
                for (int x = 0; x < lista.Count; x++)
                {
                    comboAnlista.Items.Add(lista[x]);
                }

                try
                {
                    for (int x = 0; x < lista.Count; x++)
                    {
                        string[] arreglo = new string[2];
                        arreglo = lista[x].Split('-');
                        if (metodos.traerAnalistasGenerales(arreglo[0]) == true)
                        {
                            comboAnlista.SelectedValue = lista[x];
                            break;
                        }
                    }


                }
                catch (Exception ex)
                {
                    script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al cargar la tabla con informacion de BD");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
                }
            }

           

        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                string fechaInicial = fechaInicio.Value.ToString();
                string fechaLimite = fechaFinal.Value.ToString();
                DataTable tabla = new DataTable();
                string cedulaAnalista;
                string[] arreglo = new string[2];
                
                if(fechaInicial.Equals("") == false && fechaLimite.Equals("") == false)
                {
                    tabla = metodos.traerPrestamosEntreFechas(DateTime.Parse(fechaInicial), DateTime.Parse(fechaLimite));
                    if(tabla.Rows.Count == 0)
                    {
                        script = string.Format("javascript:notificacion('{0}')", "No se encontraron registros entre esas fechas escogidas");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error",script, true);
                    }
                    else
                    {
 
                        tabla.Columns["idPrestamos"].ColumnName = "Préstamo #";
                        tabla.Columns["FechaCredito"].ColumnName = "Fecha crédito";
                        tabla.Columns["TipoPrestamo"].ColumnName = "Tipo Prestamo";
                        GridView1.DataSource = tabla;
                        GridView1.DataBind();
                        if(tabla.Rows.Count == 0)
                        {
                            script = string.Format("javascript:notificacion('{0}')", "No hay solicitudes para ese rango de fechas escogido");
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
                        }
                        else
                        {
                            cedulaAnalista = comboAnlista.SelectedValue.ToString();
                            arreglo = cedulaAnalista.Split('-');


                            for (int x = 0; x < GridView1.Rows.Count; x++)
                            {
                                string encargo = metodos.EncargoAnalista(arreglo[0]);
                                string celda = GridView1.Rows[x].Cells[4].Text;
                                string[] vector = new string[2];
                                vector = celda.Split(' ');
                                if (metodos.EncargoAnalista(arreglo[0]).Contains(vector[1]) == false && metodos.EncargoAnalista(arreglo[0]).Equals("General") == false)
                                {
                                    GridView1.Rows[x].BackColor = System.Drawing.ColorTranslator.FromHtml("#D03737");
                                }
                
                            }
                        }
                       
                    }

                }else
                {

                    if(fechaInicial.Equals("") == true && fechaLimite.Equals("") == true)
                    {
                        detalles = metodos.devolverPrestamosClientes();
                        detalles.Columns["idPrestamos"].ColumnName = "Préstamo #";
                        detalles.Columns["FechaCredito"].ColumnName = "Fecha crédito";
                        detalles.Columns["TipoPrestamo"].ColumnName = "Tipo Prestamo";
                        GridView1.DataSource = detalles;
                        GridView1.DataBind();
                        cedulaAnalista = Session["tramitadorEscogido"].ToString();
                        arreglo = cedulaAnalista.Split('-');

                        for (int x = 0; x < GridView1.Rows.Count; x++)
                        {
                            string encargo = metodos.EncargoAnalista(arreglo[0]);
                            string celda = GridView1.Rows[x].Cells[4].Text;
                            string[]vector = new string[2];
                            vector = celda.Split(' ');
                            if (metodos.EncargoAnalista(arreglo[0]).Contains(vector[1]) == false && metodos.EncargoAnalista(arreglo[0]).Equals("General") == false)
                            {
                                GridView1.Rows[x].BackColor = System.Drawing.ColorTranslator.FromHtml("#D03737");
                            }
                           
                        }
                    }
                    else
                    {
                        script = string.Format("javascript:notificacion('{0}')", "Para buscar por fechas, debes llenar las dos listas desplegables");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);

                    }

                }
                

            }
            catch(Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al tratar de buscar por filtro");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error",script, true);
            }
        }

       protected void cbxComboAnlista_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["tramitadorEscogido"] = comboAnlista.SelectedValue.ToString();
        }

        protected void btnObservarCreditos_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/graficaDatos.aspx");
        }

        protected void btnObservarCreditosPendientes_Click(object sender, EventArgs e)
        {

        }

        protected void btnObservarHistorialCreditos_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/HistorialCreditos.aspx");
        }
    }
}