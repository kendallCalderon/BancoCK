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
        int vivienda, vehiculo, negocio, educacion, deudas, personal;
        ConsumoBaseDatos metodos = new ConsumoBaseDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["Login"] == null)
            //    {
            //        Response.Redirect("Home.aspx");
            //    }


            //}


           

            tabla = metodos.devolverFechasIndicadores();



            for (int x = 0; x < tabla.Rows.Count; x++)
            {
                if (lista.Contains(tabla.Rows[x]["Fecha"].ToString()) == false)
                {
                    lista.Add(tabla.Rows[x]["Fecha"].ToString());
                }
            }



            for (int x = 0; x < lista.Count; x++)
            {
                cbxfechas1.Items.Add(lista[x]);
                cbxfechas2.Items.Add(lista[x]);
            }



            // autenticados
            pClicsVivienda.InnerText = Convert.ToString(metodos.indicadorAutenticadoVivienda(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString()))); 
           pClicsVehiculo.InnerText = Convert.ToString(metodos.indicadorAutenticadoVehiculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsNegocio.InnerText = Convert.ToString(metodos.indicadorAutenticadoApoyoNegocio(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsdeudas.InnerText = Convert.ToString(metodos.indicadorAutenticadoDeudas(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsPersonal.InnerText = Convert.ToString(metodos.indicadorAutenticadoPersonal(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsEducacion.InnerText = Convert.ToString(metodos.indicadorAutenticadoEducacion(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));



            // no autenticado
            pClicsNoAutenticadoVivienda.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosVivienda(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsNoAutenticadoVehículo.InnerText = Convert.ToString(metodos.indicadorNoAutenticadoVehiculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsNoAutenticadoNegocio.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosApoyoNegocio(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsNoAutenticadodeudas.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosDeudas(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsNoAutenticadoPersonal.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosPersonal(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pClicsNoAutenticadoEducacion.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosEducacion(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));



            //precalculo autenticados
            pAutenticadoVivienda.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoViviendaPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pAutenticadoVehiculo.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoVehiculoPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pAutenticadoNegocio.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoApoyoNegocioPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pAutenticadodeudas.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoDeudasPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pAutenticadoPersonal.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoPersonalPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pAutenticadoEducacion.InnerText = Convert.ToString(metodos.devolverIndicadoresAutenticadoEducacionPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));




            //precalculo no autenticados
            pNoAutenticadoVivienda.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadoViviendaPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pNoAutenticadoVehiculo.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadoVehiculoPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pNoAutenticadoNegocio.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosApoyoNegocioPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pNoAutenticadodeudas.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadoDeudasPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pNoAutenticadoPersonal.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadosPersonalPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));
            pNoAutenticadoEducacion.InnerText = Convert.ToString(metodos.devolverIndicadoresNoAutenticadoEducacionPrecalculo(DateTime.Parse(cbxfechas1.SelectedValue.ToString()), DateTime.Parse(cbxfechas2.SelectedValue.ToString())));




        }
    }
}