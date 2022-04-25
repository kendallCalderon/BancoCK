using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoCK.pages
{
    public partial class graficaDatos : System.Web.UI.Page
    {

        DataTable tabla = new DataTable();
        List<string> lista = new List<string>();
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();

        public void mostrarIndicadorxFechas()
        {
            int bloque1 = 0, bloque2 = 0, bloque3 = 0, bloque4 = 0;

            // autenticados
            pClicsVivienda.InnerText = Convert.ToString(metodos.indicadorAutenticadoVivienda(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsVehiculo.InnerText = Convert.ToString(metodos.indicadorAutenticadoVehiculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsNegocio.InnerText = Convert.ToString(metodos.indicadorAutenticadoApoyoNegocio(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsdeudas.InnerText = Convert.ToString(metodos.indicadorAutenticadoDeudas(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsPersonal.InnerText = Convert.ToString(metodos.indicadorAutenticadoPersonal(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsEducacion.InnerText = Convert.ToString(metodos.indicadorAutenticadoEducacion(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));


            if(pClicsVivienda.InnerText.ToString().Equals("0") && pClicsVehiculo.InnerText.Equals("0") && pClicsNegocio.InnerText.Equals("0") && pClicsdeudas.InnerText.Equals("0") && pClicsPersonal.InnerText.Equals("0") && pClicsEducacion.InnerText.Equals("0"))
            {
                bloque1 = 1;
            }


            // no autenticado
                pClicsNoAutenticadoVivienda.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosVivienda(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsNoAutenticadoVehículo.InnerText = Convert.ToString(metodos.indicadorNoAutenticadoVehiculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsNoAutenticadoNegocio.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosApoyoNegocio(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsNoAutenticadodeudas.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosDeudas(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsNoAutenticadoPersonal.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosPersonal(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pClicsNoAutenticadoEducacion.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosEducacion(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));

            if(pClicsNoAutenticadoVivienda.InnerText.Equals("0") && pClicsNoAutenticadoVehículo.InnerText.Equals("0") && pClicsNoAutenticadoNegocio.InnerText.Equals("0") && pClicsNoAutenticadodeudas.InnerText.Equals("0") && pClicsNoAutenticadoPersonal.InnerText.Equals("0") && pClicsNoAutenticadoEducacion.InnerText.Equals("0"))
            {
                bloque2 = 1;
            }


                //precalculo autenticados
                pAutenticadoVivienda.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoViviendaPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pAutenticadoVehiculo.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoVehiculoPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pAutenticadoNegocio.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoApoyoNegocioPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pAutenticadodeudas.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoDeudasPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pAutenticadoPersonal.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoPersonalPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pAutenticadoEducacion.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoEducacionPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));

            if(pAutenticadoVivienda.InnerText.Equals("0") && pAutenticadoVehiculo.InnerText.Equals("0") && pAutenticadoNegocio.InnerText.Equals("0") && pAutenticadodeudas.InnerText.Equals("0") && pAutenticadoPersonal.InnerText.Equals("0") && pAutenticadoEducacion.InnerText.Equals("0"))
            {
                bloque3 = 1;
            }


            //precalculo no autenticados
            pNoAutenticadoVivienda.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadoViviendaPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pNoAutenticadoVehiculo.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadoVehiculoPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pNoAutenticadoNegocio.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosApoyoNegocioPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pNoAutenticadodeudas.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadoDeudasPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pNoAutenticadoPersonal.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosPersonalPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));
            pNoAutenticadoEducacion.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadoEducacionPrecalculo(DateTime.Parse(Session["fechaInicial"].ToString()), DateTime.Parse(Session["fechaFinal"].ToString())));

            if(pNoAutenticadoVivienda.InnerText.Equals("0") && pNoAutenticadoVehiculo.InnerText.Equals("0") && pNoAutenticadoNegocio.InnerText.Equals("0") && pNoAutenticadodeudas.InnerText.Equals("0") && pNoAutenticadoPersonal.InnerText.Equals("0") && pNoAutenticadoEducacion.InnerText.Equals("0"))
            {
                bloque4 = 1;
            }


            if(bloque1 == 1 && bloque2 == 1 && bloque3 == 1 && bloque4 == 1){
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "abrirModal", "abrirModalConfirmacion();", true);
            }
        }

        public void llenarIndicadoresGeneralClicks(string cadena, string prestamo)
        {
            string[] arreglo = new string[2];
            switch (prestamo)
            {
                case "Deudas":
                    arreglo = cadena.Split(',');
                    pClicsNoAutenticadodeudas.InnerText = arreglo[0];
                    pClicsdeudas.InnerText = arreglo[1];
                    break;
                case "Negocio":
                    arreglo = cadena.Split(',');
                    pClicsNoAutenticadoNegocio.InnerText = arreglo[0];
                    pClicsNegocio.InnerText = arreglo[1];
                    break;
                case "Educacion":
                    arreglo = cadena.Split(',');
                    pClicsNoAutenticadoEducacion.InnerText = arreglo[0];
                    pClicsEducacion.InnerText = arreglo[1];
                    break;
                case "Personal":
                    arreglo = cadena.Split(',');
                    pClicsNoAutenticadoPersonal.InnerText = arreglo[0];
                    pClicsPersonal.InnerText = arreglo[1];
                    break;
                case "Vivienda":
                    arreglo = cadena.Split(',');
                    pClicsNoAutenticadoVivienda.InnerText = arreglo[0];
                    pClicsVivienda.InnerText = arreglo[1];
                    break;
                case "Vehiculo":
                    arreglo = cadena.Split(',');
                    pClicsNoAutenticadoVehículo.InnerText = arreglo[0];
                    pClicsVehiculo.InnerText = arreglo[1];
                    break;
            }
        }

        public void llenarIndicadoresGeneralPrecalculo(string cadena, string prestamo)
        {
            string[] arreglo = new string[2];
            switch (prestamo)
            {
                case "Deudas":
                    arreglo = cadena.Split(',');
                    pNoAutenticadodeudas.InnerText = arreglo[0];
                    pAutenticadodeudas.InnerText = arreglo[1];
                    break;
                case "Negocio":
                    arreglo = cadena.Split(',');
                    pNoAutenticadoNegocio.InnerText = arreglo[0];
                    pAutenticadoNegocio.InnerText = arreglo[1];
                    break;
                case "Educacion":
                    arreglo = cadena.Split(',');
                    pNoAutenticadoEducacion.InnerText = arreglo[0];
                    pAutenticadoEducacion.InnerText = arreglo[1];
                    break;
                case "Personal":
                    arreglo = cadena.Split(',');
                    pNoAutenticadoPersonal.InnerText = arreglo[0];
                    pAutenticadoPersonal.InnerText = arreglo[1];
                    break;
                case "Vivienda":
                    arreglo = cadena.Split(',');
                    pNoAutenticadoVivienda.InnerText = arreglo[0];
                    pAutenticadoVivienda.InnerText = arreglo[1];
                    break;
                case "Vehiculo":
                    arreglo = cadena.Split(',');
                    pNoAutenticadoVehiculo.InnerText = arreglo[0];
                    pAutenticadoVehiculo.InnerText = arreglo[1];
                    break;
            }
        }

        protected void mostrar_Click(object sender, EventArgs e)
        {

            Session["fechaInicial"] = cbxfechas1.Value.ToString();
            Session["fechaFinal"] = cbxfechas2.Value.ToString();

                //me traigo los indicadores de clicks logeados y no logeados
                string generalDeudas = metodos.generalDeudas();
                string generalNegocio = metodos.generalApoyoNegocio();
                string generalEducacion = metodos.generalEducacion();
                string generalPersonal = metodos.generalPersonal();
                string generalVivienda = metodos.generalPrestamoVivienda();
                string generalVehiculo = metodos.generalVehiculo();

                //lleno las cartas con el indicador
                llenarIndicadoresGeneralClicks(generalDeudas, "Deudas");
                llenarIndicadoresGeneralClicks(generalNegocio, "Negocio");
                llenarIndicadoresGeneralClicks(generalEducacion, "Educacion");
                llenarIndicadoresGeneralClicks(generalPersonal, "Personal");
                llenarIndicadoresGeneralClicks(generalVivienda, "Vivienda");
                llenarIndicadoresGeneralClicks(generalVehiculo, "Vehiculo");

                //me traigo los indicadores de precalculo logeados y no logeados
                string generalDeudasPrecalculo = metodos.generalDeudasPrecalculo();
                string generalNegocioPrecalculo = metodos.generalApoyoNegocioPrecalculo();
                string generalEducacionPrecalculo = metodos.generalEducacionPrecalculo();
                string generalPersonalPrecalculo = metodos.generalPersonalPrecalculo();
                string generalViviendaPrecalculo = metodos.generalPrestamoViviendaPrecalculo();
                string generalVehiculoPrecalculo = metodos.generalVehiculoPrecalculo();

                //lleno las cartas con el indicador
                llenarIndicadoresGeneralPrecalculo(generalDeudas, "Deudas");
                llenarIndicadoresGeneralPrecalculo(generalNegocio, "Negocio");
                llenarIndicadoresGeneralPrecalculo(generalEducacion, "Educacion");
                llenarIndicadoresGeneralPrecalculo(generalPersonal, "Personal");
                llenarIndicadoresGeneralPrecalculo(generalVivienda, "Vivienda");
                llenarIndicadoresGeneralPrecalculo(generalVehiculo, "Vehiculo");

                if (Session["fechaInicial"] != null || Session["fechaFinal"] != null)
            {
                mostrarIndicadorxFechas();
                Session["fechaInicial"] = null;
                Session["fechaFinal"] = null;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
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
                if (Session["fechaInicial"] == null || Session["fechaFinal"] == null)
                {


                    //me traigo los indicadores de clicks logeados y no logeados
                    string generalDeudas = metodos.generalDeudas();
                    string generalNegocio = metodos.generalApoyoNegocio();
                    string generalEducacion = metodos.generalEducacion();
                    string generalPersonal = metodos.generalPersonal();
                    string generalVivienda = metodos.generalPrestamoVivienda();
                    string generalVehiculo = metodos.generalVehiculo();

                    //lleno las cartas con el indicador
                    llenarIndicadoresGeneralClicks(generalDeudas, "Deudas");
                    llenarIndicadoresGeneralClicks(generalNegocio, "Negocio");
                    llenarIndicadoresGeneralClicks(generalEducacion, "Educacion");
                    llenarIndicadoresGeneralClicks(generalPersonal, "Personal");
                    llenarIndicadoresGeneralClicks(generalVivienda, "Vivienda");
                    llenarIndicadoresGeneralClicks(generalVehiculo, "Vehiculo");

                    //me traigo los indicadores de precalculo logeados y no logeados
                    string generalDeudasPrecalculo = metodos.generalDeudasPrecalculo();
                    string generalNegocioPrecalculo = metodos.generalApoyoNegocioPrecalculo();
                    string generalEducacionPrecalculo = metodos.generalEducacionPrecalculo();
                    string generalPersonalPrecalculo = metodos.generalPersonalPrecalculo();
                    string generalViviendaPrecalculo = metodos.generalPrestamoViviendaPrecalculo();
                    string generalVehiculoPrecalculo = metodos.generalVehiculoPrecalculo();

                    //lleno las cartas con el indicador
                    llenarIndicadoresGeneralPrecalculo(generalDeudas, "Deudas");
                    llenarIndicadoresGeneralPrecalculo(generalNegocio, "Negocio");
                    llenarIndicadoresGeneralPrecalculo(generalEducacion, "Educacion");
                    llenarIndicadoresGeneralPrecalculo(generalPersonal, "Personal");
                    llenarIndicadoresGeneralPrecalculo(generalVivienda, "Vivienda");
                    llenarIndicadoresGeneralPrecalculo(generalVehiculo, "Vehiculo");

                }
                else
                {
                    mostrarIndicadorxFechas();
                }
            }

            
               

        }

    }
}