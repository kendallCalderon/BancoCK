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


        protected void AsignarAnalista(object sender, EventArgs e)
        {
            try
            {
                string idPrestamo = (sender as LinkButton).CommandArgument;
               
                string[] arreglo = new string[2];
                string analista;

                if(Session["tramitadorEscogido"] != null)
                {
                   analista = Session["tramitadorEscogido"].ToString();
                }
                else
                {
                    analista = comboAnlista.SelectedValue;
                }
                arreglo = analista.Split('-');

                metodos.asignarAnalista(arreglo[0], int.Parse(idPrestamo));
                metodos.cambiarEstadoPrestamoSolicitud(int.Parse(idPrestamo));
               
                textoModal.InnerText = "Se ha asignado el prestamo al analista correctamente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
                        
                string correo = metodos.ObtenerCorreo(arreglo[0], "Analista");
                metodos.correoAnalistaInforme(correo);
                //Response.Redirect("Tramitador.aspx");
                Tabla();
         
            }
            catch (Exception ex)
            {

                error.InnerText = "Ocurrio un error al tratar al tratar de asignar analista detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
            }
        }

        public void Tabla()
        {
            if (Session["contenido"] == null)
            {
               
                string[] arreglo = new string[2];
                List<string> lista = new List<string>();

                lista = metodos.comboAnalistas();


                comboAnlista.Items.Clear();
                for (int x = 0; x < lista.Count; x++)
                {
                    arreglo = lista[x].Split('-');
                    int numero = metodos.traerNumero(arreglo[0]);
                    lista[x] = lista[x] + "-" + numero;
                    comboAnlista.Items.Add(lista[x]);
                }

            }
            else
            {
                string[] arreglo = new string[2];
                List<string> lista = new List<string>();
                lista = metodos.comboAnalistas();


                comboAnlista.Items.Clear();
                for (int x = 0; x < lista.Count; x++)
                {
                    arreglo = lista[x].Split('-');
                    int numero = metodos.traerNumero(arreglo[0]);
                    lista[x] = lista[x] + "-" + numero;
                    comboAnlista.Items.Add(lista[x]);
                }
                comboAnlista.SelectedValue = Session["tramitadorEscogido"].ToString();
                Session["contenido"] = null;
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Login"] == null)
                    {
                        Response.Redirect("Home.aspx");
                    }


                }
                if (!Page.IsPostBack)
                {
                    detalles = metodos.devolverPrestamosClientes();
                    detalles.Columns["idPrestamos"].ColumnName = "Préstamo #";
                    detalles.Columns["FechaCredito"].ColumnName = "Fecha crédito";
                    detalles.Columns["TipoPrestamo"].ColumnName = "Tipo Prestamo";
                    GridView1.DataSource = detalles;
                    GridView1.DataBind();
                    string[] arreglo = new string[2];
                    List<string> lista = new List<string>();

                    lista = metodos.comboAnalistas();


                    comboAnlista.Items.Clear();
                    for (int x = 0; x < lista.Count; x++)
                    {
                        arreglo = lista[x].Split('-');
                        int numero = metodos.traerNumero(arreglo[0]);
                        lista[x] = lista[x] + "-" + numero;
                        comboAnlista.Items.Add(lista[x]);
                    }

                }
                else
                {
                    detalles = metodos.devolverPrestamosClientes();
                    detalles.Columns["idPrestamos"].ColumnName = "Préstamo #";
                    detalles.Columns["FechaCredito"].ColumnName = "Fecha crédito";
                    detalles.Columns["TipoPrestamo"].ColumnName = "Tipo Prestamo";
                    GridView1.DataSource = detalles;
                    GridView1.DataBind();
                }


            } catch (Exception ex)
            {
                error.InnerText = "Ocurrio un error en el evento carga de la pantalla tramitador, detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
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

                        textoModal.InnerText = "No se encontraron registros entre esas fechas escogidas";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
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
                            textoModal.InnerText = "No hay solicitudes para ese rango de fechas escogido ";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
                        }
                        else
                        {
                            cedulaAnalista = comboAnlista.SelectedValue.ToString();
                            arreglo = cedulaAnalista.Split('-');
                            Session["contenido"] = "si";
                            string combito = comboAnlista.SelectedValue.ToString();
                            Session["tramitadorEscogido"] = comboAnlista.SelectedValue.ToString();

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
                        Session["contenido"] = "si";
                        Session["tramitadorEscogido"] = comboAnlista.SelectedValue.ToString();
                    }
                    else
                    {
                        textoModal.InnerText = "Para buscar por fechas, debes llenar las dos listas desplegables, detalles: ";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
                    }

                }
                

            }
            catch(Exception ex)
            {
                error.InnerText = "Ocurrio un error al tratar de buscar por filtro, detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
                
            }
        }

       protected void cbxComboAnlista_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["tramitadorEscogido"] = comboAnlista.SelectedValue.ToString();
        }

        protected void btnObservarCreditos_Click(object sender, EventArgs e)
        {
            Response.Redirect("graficaDatos.aspx");
        }

      

        protected void btnObservarHistorialCreditos_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistorialCreditos.aspx");
        }

        protected void btnAdministrarAnalistas_Click(object sender, EventArgs e)
        {

        }

        protected void btnObservarCreditosPendientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Configuraciones.aspx");

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}