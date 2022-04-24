using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        string script;
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        DataTable tabla = new DataTable();

        public void mostrarTabla(string tipoPrestamo)
        {
            tabla = metodos.traePrestamoxTipoEstadoAnalista(tipoPrestamo);
            tabla.Columns["idPrestamos"].ColumnName = "Préstamo #";
            tabla.Columns["Nombre"].ColumnName = "Nombre Cliente";
            tabla.Columns["Apellido1"].ColumnName = "Primer Apellido";
            tabla.Columns["Apellido2"].ColumnName = "Segundo Apellido";
            tabla.Columns["Monto"].ColumnName = "Monto Préstamo";
            tabla.Columns["CuotaMensual"].ColumnName = "Cuota Mensual";
            tabla.Columns["SalarioNeto"].ColumnName = "Salario Neto";
            tabla.Columns["telefono"].ColumnName = "Teléfono";
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.AllowDBNull = true;
            column.ColumnName = "Nivel de endeudamiento";
            tabla.Columns.Add(column);

            foreach (DataRow dr in tabla.Rows)
            {
                int idPrestamo1 = int.Parse(dr["Préstamo #"].ToString());
                float salarioBruto = metodos.traerSalarioBrutoCliente(idPrestamo1);
                float salarioFinal = float.Parse(dr["Salario Neto"].ToString());
                float porcentajeEndeudamiento = salarioFinal / salarioBruto;
                porcentajeEndeudamiento = porcentajeEndeudamiento * 100;
                double nivel = porcentajeEndeudamiento;
                nivel = Math.Round(nivel, 0);
                string nivelEndeudamiento = nivel.ToString() + " %";
                dr["Nivel de endeudamiento"] = nivelEndeudamiento;
                double cuota = double.Parse(dr["Cuota Mensual"].ToString());
                cuota = Math.Round(cuota, 0);
                dr["Cuota Mensual"] = cuota;
            }

            GridView1.DataSource = tabla;
            GridView1.DataBind();

            for (int x = 0; x < GridView1.Rows.Count; x++)
            {
                string nivelEndeudamiento = GridView1.Rows[x].Cells[11].Text.Replace(" %", "");
                if (float.Parse(nivelEndeudamiento) > 60 || (float.Parse(GridView1.Rows[x].Cells[4].Text) > float.Parse(GridView1.Rows[x].Cells[6].Text)))
                {
                    GridView1.Rows[x].BackColor = System.Drawing.ColorTranslator.FromHtml("#D03737");
                }
            }
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              /*  if (Session["Login"] == null)
                {
                    Response.Redirect("Home.aspx");
                }*/



            if(Session["cambio"] != null)
            {
                Session["cambio"] = null;
                mostrarTabla(Session["tipoPrestamo"].ToString());
                Session["tipoPrestamo"] = null;
            }

            if(Session["denegado"] != null)
            {
                Session["denegado"] = null;
                mostrarTabla(Session["tipoPrestamo"].ToString());
                Session["tipoPrestamo"] = null;
                
            }
            }
            
        }

        protected void RechazarSolicitud(object sender, EventArgs e)
        {
            try
            {
                bool continuar = false;
                Session["tipoPrestamo"] = tipoPrestamo.Value.ToString();
                string idPrestamo = (sender as LinkButton).CommandArgument;
                for (int x = 0; x < GridView1.Rows.Count; x++)
                {
                    if (GridView1.Rows[x].Cells[0].Text.Equals(idPrestamo))
                    {
                        if ((GridView1.Rows[x].BackColor ==  System.Drawing.ColorTranslator.FromHtml("#D03737")) == true)
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

                    metodos.cambiarEstadoParaRechazarAnalista(int.Parse(idPrestamo));
                    string enviarCorreo = metodos.ObtenerCorreoSolicitudCliente(int.Parse(idPrestamo));
                    string[] arreglo = new string[6];
                    arreglo = enviarCorreo.Split(',');
                    metodos.enviarCorreoClienteSolicitudCreditoRechazado(arreglo[4], arreglo[0], arreglo[1], arreglo[2], arreglo[3], arreglo[5]);
                    Session["denegado"] = "cambio";
                    mostrarTabla(Session["tipoPrestamo"].ToString());
                }
                else
                {
                    script = string.Format("javascript:notificacion('{0}')", "El analista solo puede rechazar solicitudes que  tienen color rojo");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
                }

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al aceptar la solicitud de préstamo de un cliente ");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
            }
        }


        protected void AceptarSolicitud(object sender, EventArgs e)
        {
            bool continuar = false;
            try
            {
                Session["tipoPrestamo"] = tipoPrestamo.Value.ToString();
                string idPrestamo = (sender as LinkButton).CommandArgument;
                for (int x = 0; x < GridView1.Rows.Count; x++)
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
                  
                        metodos.cambiarEstadoParaAprobrarAnalista(int.Parse(idPrestamo));
                        string enviarCorreo = metodos.ObtenerCorreoSolicitudCliente(int.Parse(idPrestamo));
                        string[] arreglo = new string[6];
                        arreglo = enviarCorreo.Split(',');
                        metodos.enviarCorreoClienteSolicitudCredito(arreglo[4],arreglo[0],arreglo[1],arreglo[2],arreglo[3],arreglo[5]);
                        Session["cambio"] = "cambio";
                    mostrarTabla(Session["tipoPrestamo"].ToString());
                }
                else
                {
                    script = string.Format("javascript:notificacion('{0}')", "El analista solo puede aceptar solicitudes que no tienen color rojo");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
                }

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Ocurrio un error al aceptar la solicitud de préstamo de un cliente ");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", script, true);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                bool continuar = false;
                if ((fechaInicio.Value.ToString().Equals("") || fechaInicio.Value.ToString() == null || fechaFinal.Value.ToString().Equals("") || fechaFinal.Value.ToString() == null) && (filtro.Value.ToString().Equals("") || filtro.Value.ToString() == null))
                {
                    tabla = metodos.traePrestamoxTipoEstadoAnalista(tipoPrestamo.Value.ToString());
                    continuar = true;
                }
                else if ((fechaInicio.Value.ToString().Equals("") == false || fechaInicio.Value.ToString() != null && fechaFinal.Value.ToString().Equals("") == false && fechaFinal.Value.ToString() != null) && (filtro.Value.ToString().Equals("") || filtro.Value.ToString() == null))
                {
                    tabla = metodos.traePrestamoxTipoEstadoFechasAnalista(tipoPrestamo.Value.ToString(),DateTime.Parse(fechaInicio.Value.ToString()), DateTime.Parse(fechaFinal.Value.ToString()));
                    continuar = true;

                }
                else if ((fechaInicio.Value.ToString().Equals("") == false && fechaInicio.Value.ToString() != null && fechaFinal.Value.ToString().Equals("") == false && fechaFinal.Value.ToString() != null) && (filtro.Value.ToString().Equals("") == false || filtro.Value.ToString() != null))
                {
                    busquedaFiltroxFechas(DateTime.Parse(fechaInicio.Value.ToString()), DateTime.Parse(fechaFinal.Value.ToString()), tipoBusqueda.Value.ToString(), filtro.Value.ToString());
                    continuar = true;
                }
                else if (((fechaInicio.Value.ToString().Equals("") || fechaInicio.Value.ToString() == null) && (fechaFinal.Value.ToString().Equals("") || fechaFinal.Value.ToString() == null)) && (filtro.Value.ToString().Equals("") == false || filtro.Value.ToString() != null))
                {
                    busquedaFiltro(tipoBusqueda.Value.ToString(), filtro.Value.ToString());
                    continuar = true;
                }
                else
                {
                    script = string.Format("javascript:notificacion('{0}')", "Para filtrar por fechas debes poner la fecha inicial y final de forma obligatoria");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                }

                if (continuar)
                {
                    if (tabla.Rows.Count == 0)
                    {
                        GridView1 = null;
                        script = string.Format("javascript:notificacion('{0}')", "No hay registros registrados por los filtros escogidos");
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
                    }
                    else
                    {
                        tabla.Columns["idPrestamos"].ColumnName = "Préstamo #";
                        tabla.Columns["Nombre"].ColumnName = "Nombre Cliente";
                        tabla.Columns["Apellido1"].ColumnName = "Primer Apellido";
                        tabla.Columns["Apellido2"].ColumnName = "Segundo Apellido";
                        tabla.Columns["Monto"].ColumnName = "Monto Préstamo"; 
                        tabla.Columns["CuotaMensual"].ColumnName = "Cuota Mensual"; 
                        tabla.Columns["SalarioNeto"].ColumnName = "Salario Neto";
                        tabla.Columns["telefono"].ColumnName = "Teléfono";
                        DataColumn column;
                        column = new DataColumn();
                        column.DataType = System.Type.GetType("System.String");
                        column.AllowDBNull = true;
                        column.ColumnName = "Nivel de endeudamiento";
                        tabla.Columns.Add(column);

                        foreach (DataRow dr in tabla.Rows)
                        {
                            int idPrestamo = int.Parse(dr["Préstamo #"].ToString());
                            float salarioBruto = metodos.traerSalarioBrutoCliente(idPrestamo);
                            float salarioFinal = float.Parse(dr["Salario Neto"].ToString());
                            float porcentajeEndeudamiento = salarioFinal / salarioBruto;
                            porcentajeEndeudamiento = porcentajeEndeudamiento * 100;
                            double nivel = porcentajeEndeudamiento;
                            nivel = Math.Round(nivel,0);
                            string nivelEndeudamiento = nivel.ToString() + " %";
                            dr["Nivel de endeudamiento"] = nivelEndeudamiento;
                            double cuota = double.Parse(dr["Cuota Mensual"].ToString());
                            cuota =  Math.Round(cuota,0);
                            dr["Cuota Mensual"] = cuota;
                        }

                        GridView1.DataSource = tabla;
                        GridView1.DataBind();

                        for(int x=0; x < GridView1.Rows.Count; x++)
                        {
                            string nivelEndeudamiento = GridView1.Rows[x].Cells[11].Text.Replace(" %", "");
                            if (float.Parse(nivelEndeudamiento) > 60 || (float.Parse(GridView1.Rows[x].Cells[4].Text) > float.Parse(GridView1.Rows[x].Cells[6].Text)))
                            {
                                GridView1.Rows[x].BackColor = System.Drawing.ColorTranslator.FromHtml("#D03737");
                            }
                        }
                    }

                }
                else
                {
                    GridView1 = null;
                }

            }
            catch (Exception ex)
            {
                script = string.Format("javascript:notificacion('{0}')", "Error al buscar prestamos en la pantalla de historial de créditos");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "notificacion", script, true);
            }
        }

        void busquedaFiltroxFechas(DateTime fechaInicio, DateTime fechaFinal, string tipoFiltro,string cadena)
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
                            tabla = metodos.traePrestamoxNombreCompletoFechasAnalista(arreglo[0], arreglo[1], arreglo[2], tipoPrestamo.Value.ToString(), fechaInicio, fechaFinal);
                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[2];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreconApellidoFechasAnalista(arreglo[0], arreglo[1], fechaInicio, fechaFinal,tipoPrestamo.Value.ToString());
                        }
                        else
                        {
                            tabla = metodos.traePrestamoxNombreFechasAnalista(cadena,fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        }
                        break;
                    case "Apellido":
                        contadorEspacios = contarEspacios(cadena);
                        if (contadorEspacios == 2)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreCompletoFechasAnalista(arreglo[0], arreglo[1], arreglo[2], tipoPrestamo.Value.ToString(), fechaInicio, fechaFinal);

                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxApellidosFechasAnalistas(arreglo[0], arreglo[1], fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        }
                        else
                        {
                            tabla = metodos.traePrestamoxApellidoFechasAnalistas(cadena,fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        }
                        break;
                    case "Correo":
                        tabla = metodos.traePrestamoxCorreoFechasAnalistas(cadena, fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        break;
                    case "Telefono":
                        tabla = metodos.traePrestamoxTelefonoFechasAnalista(int.Parse(cadena),fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        break;
                    case "Identificacion":
                        tabla = metodos.traePrestamoxIdentificacionFechasAnalista(cadena,fechaInicio, fechaFinal, tipoPrestamo.Value.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void busquedaFiltro(string tipoFiltro,string cadena)
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
                            tabla = metodos.traePrestamoxNombreCompletoAnalista(arreglo[0], arreglo[1], arreglo[2],tipoPrestamo.Value.ToString());
                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[2];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreconApellidoAnalista(arreglo[0], arreglo[1], tipoPrestamo.Value.ToString());
                        }
                        else
                        {
                            tabla = metodos.traePrestamoxNombreAnalista(cadena,tipoPrestamo.Value.ToString());
                        }
                        break;
                    case "Apellido":
                        contadorEspacios = contarEspacios(cadena);
                        if (contadorEspacios == 2)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxNombreCompletoAnalista(arreglo[0], arreglo[1], arreglo[2],tipoPrestamo.Value.ToString());

                        }
                        else if (contadorEspacios == 1)
                        {
                            string[] arreglo = new string[3];
                            arreglo = cadena.Split(' ');
                            tabla = metodos.traePrestamoxApellidosAnalista(arreglo[0], arreglo[1],tipoPrestamo.Value.ToString());
                        }
                        else
                        {
                            tabla = metodos.traePrestamoxApellidoAnalista(cadena,tipoPrestamo.Value.ToString());
                        }
                        break;
                    case "Correo":
                        tabla = metodos.traePrestamoxCorreoAnalista(cadena,tipoPrestamo.Value.ToString());
                        break;
                    case "Telefono":
                        tabla = metodos.traePrestamoxTelefonoAnalista(int.Parse(cadena),tipoPrestamo.Value.ToString());
                        break;
                    case "Identificacion":
                        tabla = metodos.traePrestamoxIdentificacionAnalista(cadena,tipoPrestamo.Value.ToString());
                        break;
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
    }
}