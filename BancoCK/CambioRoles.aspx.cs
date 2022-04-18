using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DataTable tabla2 = new DataTable();
                    tabla2 = metodos.traerRoles();
                    tabla2.Columns["Apellido1"].ColumnName = "Primer Apellido";
                    tabla2.Columns["Apellido2"].ColumnName = "Segundo Apellido";
                    tabla2.Columns["Identificacion"].ColumnName = "Identificación";
                    tabla2.Columns["Telefono"].ColumnName = "Teléfono";
                    GridView1.DataSource = tabla2;
                    GridView1.DataBind();

                }


            }catch(Exception ex)
            {
                error.InnerText = "Ocurrio un error al llamar a la pantalla de cambio de roles, detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
            }
        }

        protected void Modificar(object sender, EventArgs e)
        {
            
            try
            {
                Session["identificcion"] = (sender as LinkButton).CommandArgument;
                Session["Rol"] = metodos.traerRolUsuario(Session["identificcion"].ToString());
                if (Session["Rol"].ToString().Equals("Tramitador")){
                    mensaje2.InnerText = "Rol actual: " + Session["Rol"].ToString();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalTramitador();", true);
                }
                else
                {
                    mensaje.InnerText = "Rol actual: " + Session["Rol"].ToString();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModal();", true);
                }
               
            }
            catch(Exception ex)
            {
                error.InnerText = "Ocurrio un error al llamar a la pantalla de cambio de roles, detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
            }


        }
        protected void btnModals(object sender, EventArgs e)
        {
            try
            {
                DataTable tabla = new DataTable();
                List<string> lista = new List<string>();
                string opcionEscogida;
                if (Session["Rol"].ToString().Equals("Analista"))
                {
                    opcionEscogida =  Opcion.Value.ToString();
                }
                else
                {
                    opcionEscogida = rolTramitadorEscogido.Value.ToString();
                }
                if (Session["Rol"].ToString().Equals("Analista") && opcionEscogida.Equals("Tramitador"))
                {
                    lista = metodos.traerAnalistas(Session["identificcion"].ToString());
                    if (lista.Count > 1)
                    {
                        var seed = Environment.TickCount;
                        var random = new Random(seed);
                        int value = random.Next(0, lista.Count - 1);
                        metodos.asignarPrestamos(Session["identificcion"].ToString(), lista[value]);
                        metodos.cambioRol(Session["identificcion"].ToString(), "Tramitador");
                    }
                    else
                    {
                        metodos.asignarPrestamos(Session["identificcion"].ToString(), lista[0]);
                        metodos.cambioRol(Session["identificcion"].ToString(), "Tramitador");
                    }
                }
                else if (Session["Rol"].ToString().Equals("Tramitador") && opcionEscogida.Equals("Analista"))
                {
                    metodos.cambioRolTramitador(Session["identificcion"].ToString(), "Analista", Encargo.Value.ToString());
                }

                tabla = metodos.traerRoles();
                tabla.Columns["Apellido1"].ColumnName = "Primer Apellido";
                tabla.Columns["Apellido2"].ColumnName = "Segundo Apellido";
                tabla.Columns["Identificacion"].ColumnName = "Identificación";
                tabla.Columns["Telefono"].ColumnName = "Teléfono";
                GridView1.DataSource = tabla;
                GridView1.DataBind();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
            }
            catch(Exception ex)
            {
                error.InnerText = "Ocurrio un error al llamar a la pantalla de cambio de roles, detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
            }
            
        }

        protected void busquedaFiltrada(object sender, EventArgs e)
        {
            try
            {
                string tipoFiltro = tipoBusqueda.Value.ToString();
                string rolUsuario = tipoRol.Value.ToString();
                string campoBusqueda = campotxt.Value.ToString();
                DataTable filtro = new DataTable();
                bool continuar = false;

                if (campoBusqueda.Equals(""))
                {
                   filtro =  metodos.traerRolesxrol(rolUsuario);
                }
                else
                {
                    busquedaFiltro(tipoFiltro, rolUsuario, campoBusqueda);
                    continuar = true;
                }

                if (continuar == false)
                {
                    if (filtro.Rows.Count == 0)
                    {
                        GridView1 = null;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalAviso();", true);
                    }
                    else
                    {

                        filtro.Columns["Apellido1"].ColumnName = "Primer Apellido";
                        filtro.Columns["Apellido2"].ColumnName = "Segundo Apellido";
                        filtro.Columns["Identificacion"].ColumnName = "Identificación";
                        filtro.Columns["Telefono"].ColumnName = "Teléfono";
                        GridView1 = null;
                        GridView1.DataSource = filtro;
                        GridView1.DataBind();
                    }
                }
               

            }
            catch(Exception ex)
            {
                error.InnerText = "Ocurrio un error al llamar a la pantalla de cambio de roles, detalles: " + ex.Message;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalError();", true);
            }
        }

        void busquedaFiltro(string tipoFiltro,string rol,string cadena)
        {
            try
            {
                DataTable filtro = new DataTable();
                switch (tipoFiltro)
                {
                    case "Nombre":
                        int contadorEspacios = contarEspacios(cadena);
                        if (contadorEspacios == 2)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            filtro = metodos.informacionRolxNombreCompleto(arreglo[0], arreglo[1], arreglo[2],rol);
                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[2];
                            arreglo = cadena.Split(' ');
                            filtro = metodos.informacionRolxNombreApellido(arreglo[0], arreglo[1],rol);
                        }
                        else
                        {
                            filtro = metodos.informacionRolxNombre(cadena,rol);
                        }
                        break;
                    case "Apellido":
                        contadorEspacios = contarEspacios(cadena);
                        if (contadorEspacios == 2)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            filtro = metodos.informacionRolxNombreCompleto(arreglo[0], arreglo[1], arreglo[2],rol);

                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            filtro = metodos.informacionRolxApellidos(arreglo[0], arreglo[1],rol);
                        }
                        else
                        {
                            filtro = metodos.informacionRolxApellido(cadena,rol);
                        }
                        break;
                    case "Correo":
                        filtro = metodos.informacionRolxCorreo(cadena,rol);
                        break;
                    case "Telefono":
                        filtro = metodos.informacionRolxTelefono(int.Parse(cadena),rol);
                        break;
                    case "Identificacion":
                        filtro = metodos.informacionRolxIdentificacion(cadena,rol);
                        break;
                }



                if (filtro.Rows.Count == 0)
                {
                    GridView1 = null;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalAviso();", true);
                }
                else
                {

                    filtro.Columns["Apellido1"].ColumnName = "Primer Apellido";
                    filtro.Columns["Apellido2"].ColumnName = "Segundo Apellido";
                    filtro.Columns["Telefono"].ColumnName = "Teléfono";
                    DataColumn column;
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.AllowDBNull = true;
                    column.ColumnName = "Identificación";
                    filtro.Columns.Add(column);

                    GridView1 = null;
                    GridView1.DataSource = filtro;
                    GridView1.DataBind();
                }
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int contarEspacios(string texto)
        {
            int contador = 0;
            string letra;

            for (int i = 0; i < texto.Length; i++)
            {
                letra = texto.Substring(i, 1);

                if (letra == " ")
                {
                    contador++;
                }
            }

            return contador;
        }

        protected void btnError(object sender, EventArgs e)
        {
           
        }


    }
}