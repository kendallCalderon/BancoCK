using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        DataTable tabla = new DataTable();

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

            tabla = metodos.traePrestamoxTipoEstadoGeneral();
                tabla.Columns["idPrestamos"].ColumnName = "Préstamo #";
                tabla.Columns["FechaCredito"].ColumnName = "Fecha crédito";
                tabla.Columns["TipoPrestamo"].ColumnName = "Tipo Prestamo";
                tabla.Columns["EstadoCredito"].ColumnName = "Estado crédito";
                
                GridView1.DataSource = tabla;
                GridView1.DataBind();
                if(tabla.Rows.Count > 1)
            {
                tabla.Rows.Clear();
            }
           

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                bool continuar = false;
                if((fechaInicio.Value.ToString().Equals("") || fechaInicio.Value.ToString() == null || fechaFinal.Value.ToString().Equals("") || fechaFinal.Value.ToString() == null) && (filtro.Value.ToString().Equals("") || filtro.Value.ToString() == null))
                {
                    tabla = metodos.traePrestamoxTipoEstado(tipoPrestamo.Value.ToString(), estadoCredito.Value.ToString().ToLower());
                    continuar = true;
                }else if((fechaInicio.Value.ToString().Equals("") == false || fechaInicio.Value.ToString() != null && fechaFinal.Value.ToString().Equals("") == false && fechaFinal.Value.ToString() != null) && (filtro.Value.ToString().Equals("")  || filtro.Value.ToString() == null))
                {
                    tabla = metodos.traePrestamoxfechasEstado(DateTime.Parse(fechaInicio.Value.ToString()), DateTime.Parse(fechaFinal.Value.ToString()), tipoPrestamo.Value.ToString(), estadoCredito.Value.ToString().ToLower());
                    continuar = true;

                }
                else if((fechaInicio.Value.ToString().Equals("") == false && fechaInicio.Value.ToString() != null && fechaFinal.Value.ToString().Equals("") == false && fechaFinal.Value.ToString() != null) && (filtro.Value.ToString().Equals("") == false || filtro.Value.ToString() != null))
                {
                    busquedaFiltroxFechas(DateTime.Parse(fechaInicio.Value.ToString()),DateTime.Parse(fechaFinal.Value.ToString()),tipoBusqueda.Value.ToString(),estadoCredito.Value.ToString().ToLower(), filtro.Value.ToString());
                    continuar = true;
                }
                else if(((fechaInicio.Value.ToString().Equals("") || fechaInicio.Value.ToString() == null) && (fechaFinal.Value.ToString().Equals("") || fechaFinal.Value.ToString() == null)) && (filtro.Value.ToString().Equals("") == false || filtro.Value.ToString() != null))
                {
                    busquedaFiltro(tipoBusqueda.Value.ToString(), estadoCredito.Value.ToString().ToLower(), filtro.Value.ToString());
                    continuar = true;
                }
                else
                {
                    script = string.Format("javascript:notificacion('{0}')", "Para filtrar por fechas debes poner la fecha inicial y final de forma obligatoria");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                }

                if (continuar)
                {
                    if(tabla.Rows.Count == 0)
                    {
                        script = string.Format("javascript:notificacion('{0}')", "No hay registros registrados por los filtros escogidos");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                    }
                    else
                    {
                        tabla.Columns["idPrestamos"].ColumnName = "Préstamo #";
                        tabla.Columns["FechaCredito"].ColumnName = "Fecha crédito";
                        tabla.Columns["TipoPrestamo"].ColumnName = "Tipo Prestamo";
                        tabla.Columns["EstadoCredito"].ColumnName = "Estado crédito";

                        GridView1.DataSource = tabla;
                        GridView1.DataBind();
                    }
                
                }
                else
                {
                    GridView1 = null;
                   
                }
                

            }
            catch(Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Error al buscar prestamos en la pantalla de historial de créditos");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
            }
        }


       
        void busquedaFiltroxFechas(DateTime fechaInicio, DateTime fechaFinal, string tipoFiltro, string estadoCrédito, string cadena)
        {
            try
            {
                switch (tipoFiltro)
                {
                    case "Nombre":
                        int contadorEspacios = contarEspacios(cadena);
                        if (contadorEspacios == 2)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreCompletoFechas(arreglo[0], arreglo[1], arreglo[2], estadoCrédito, fechaInicio,fechaFinal,tipoPrestamo.Value.ToString());
                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[2];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreconApellidoFechas(arreglo[0], arreglo[1],fechaInicio,fechaFinal,estadoCrédito,tipoPrestamo.Value.ToString());
                        }
                        else
                        {
                            tabla = metodos.traePrestamoxNombreFechas(cadena, estadoCrédito,fechaInicio,fechaFinal,tipoPrestamo.Value.ToString());
                        }
                        break;
                    case "Apellido":
                        contadorEspacios = contarEspacios(cadena);
                        if (contadorEspacios == 2)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreCompletoFechas(arreglo[0], arreglo[1], arreglo[2], estadoCrédito,fechaInicio,fechaFinal,tipoPrestamo.Value.ToString());

                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxApellidosFechas(arreglo[0], arreglo[1], estadoCrédito,fechaInicio,fechaFinal,tipoPrestamo.Value.ToString());
                        }
                        else
                        {
                            tabla = metodos.traePrestamoxApellidoFechas(cadena, estadoCrédito,fechaInicio,fechaFinal,tipoPrestamo.Value.ToString());
                        }
                        break;
                    case "Correo":
                        tabla = metodos.traePrestamoxCorreoFechas(cadena, estadoCrédito, fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        break;
                    case "Telefono":
                        tabla = metodos.traePrestamoxTelefonoFechas(int.Parse(cadena), estadoCrédito, fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        break;
                    case "Identificacion":
                        tabla = metodos.traePrestamoxIdentificacionFechas(cadena, estadoCrédito, fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void busquedaFiltro(string tipoFiltro, string estadoCrédito,string cadena)
        {
            try
            {
                switch (tipoFiltro)
                {
                    case "Nombre":
                        int contadorEspacios = contarEspacios(cadena);
                        if (contadorEspacios == 2)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreCompleto(arreglo[0], arreglo[1], arreglo[2], estadoCrédito,tipoPrestamo.Value.ToString());
                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[2];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreconApellido(arreglo[0], arreglo[1], estadoCrédito, tipoPrestamo.Value.ToString());
                        }
                        else
                        {
                            tabla = metodos.traePrestamoxNombre(cadena, estadoCrédito, tipoPrestamo.Value.ToString());
                        }
                        break;
                    case "Apellido":
                        contadorEspacios = contarEspacios(cadena);
                        if (contadorEspacios == 2)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreCompleto(arreglo[0], arreglo[1], arreglo[2], estadoCrédito, tipoPrestamo.Value.ToString());

                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxApellidos(arreglo[0], arreglo[1], estadoCrédito, tipoPrestamo.Value.ToString());
                        }
                        else
                        {
                            tabla = metodos.traePrestamoxApellido(cadena, estadoCrédito,tipoPrestamo.Value.ToString());
                        }
                        break;
                    case "Correo":
                        tabla = metodos.traePrestamoxCorreo(cadena, estadoCrédito, tipoPrestamo.Value.ToString());
                        break;
                    case "Telefono":
                        tabla = metodos.traePrestamoxTelefono(int.Parse(cadena), estadoCrédito, tipoPrestamo.Value.ToString());
                        break;
                    case "Identificacion":
                        tabla = metodos.traePrestamoxIdentificacion(cadena, estadoCrédito, tipoPrestamo.Value.ToString());
                        break;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public  int contarEspacios(string texto)
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


    }
}