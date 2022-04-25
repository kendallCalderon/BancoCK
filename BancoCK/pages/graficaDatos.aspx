﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Analista.Master" AutoEventWireup="true" CodeBehind="graficaDatos.aspx.cs" Inherits="BancoCK.pages.graficaDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/graficaDatos.css" />
    <link rel="stylesheet" href="/css/CambioRoles.css" />
    <script src="https://cdn.jsdelivr.net/npm/uikit@3.13.5/dist/js/uikit.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            right: 188px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <img class="contenedor_Imagen_imagenFondo" src="../img/bank.gif" />
    <a class="btnRegresar" href="/pages/Tramitador.aspx"><i class="fa-solid fa-left-long"></i><span>Regresar</span></a>
    <div class="ContenedorBusqueda">
        <h3>Créditos historicos por fecha</h3>
        <div class="contenedor_formulario">
            <div class="contenedor_formulario_item">
                <label class="lblfechas">Seleccione fecha de inicio:</label>
                <input type="date" ID="cbxfechas1" runat="server" />
            </div>
            <div class="contenedor_formulario_item">
                <label class="lblfechas">Seleccione la fecha final:</label>
                    <input type="date" ID="cbxfechas2" runat="server" />
            </div>
            <div class="contenedor_formulario_item">
                <label class="lblfechas" style="visibility:hidden">Seleccione fecha de inicio:</label>
                <asp:Button runat="server" ID="mostrar" Text="Aceptar" cssClass="boton_aceptar" OnClick="mostrar_Click"></asp:Button>
            </div>
        </div>

    </div>
    <h3>Tendencias de créditos</h3>

    <ul class="uk-subnav uk-subnav-pill Encabezado" uk-switcher="animation: uk-animation-fade">
        <li><a class="browser-default a a-after" href="#">Autenticados Precálculo</a></li>
        <li><a class="browser-default a a-after" href="#">No Autenticados Precálculo</a></li>
        <li><a class="browser-default a a-after" href="#">Clics Autenticados</a></li>
        <li><a class="browser-default a a-after" href="#">Clics No Autenticados</a></li>
    </ul>

    <ul class="uk-switcher uk-margin">
        <li>




            <div class="contenedorTarjetas">
                <div class="contenedorTarjetas_contenido">
                    <div class="contenedorTarjetas_contenido1">
                        <div class="row">
                            <div>
                                <div class="card cartaUno">

                                    <div>
                                        <span class="card-title">Apoyo Negocio</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pAutenticadoNegocio">
                                            38
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaDos">

                                    <div>
                                        <span class="card-title">Préstamo Personal</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pAutenticadoPersonal">
                                            40
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaTres">

                                    <div>
                                        <span class="card-title">Préstamo Educación</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pAutenticadoEducacion">
                                            20
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="contenedorTarjetas_contenido1">
                        <div class="row">
                            <div>
                                <div class="card cartaCuatro">

                                    <div>
                                        <span class="card-title">Refundir mis deudas</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pAutenticadodeudas">
                                            23
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaCinco">

                                    <div>
                                        <span class="card-title">Préstamo Vehículo</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pAutenticadoVehiculo">
                                            56
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaSeis">

                                    <div>
                                        <span class="card-title">Préstamo Vivienda</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pAutenticadoVivienda">
                                            45
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>




        </li>
        <li>


            <div class="contenedorTarjetas">
                <div class="contenedorTarjetas_contenido">
                    <div class="contenedorTarjetas_contenido1">
                        <div class="row">
                            <div>
                                <div class="card cartaUno">

                                    <div>
                                        <span class="card-title">Apoyo Negocio</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pNoAutenticadoNegocio">
                                            38
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaDos">

                                    <div>
                                        <span class="card-title">Préstamo Personal</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pNoAutenticadoPersonal">
                                            40
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaTres">

                                    <div>
                                        <span class="card-title">Préstamo Educación</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pNoAutenticadoEducacion">
                                            20
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="contenedorTarjetas_contenido1">
                        <div class="row">
                            <div>
                                <div class="card cartaCuatro">

                                    <div>
                                        <span class="card-title">Refundir mis deudas</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pNoAutenticadodeudas">
                                            23
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaCinco">

                                    <div>
                                        <span class="card-title">Préstamo Vehículo</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pNoAutenticadoVehiculo">
                                            56
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaSeis">

                                    <div>
                                        <span class="card-title">Préstamo Vivienda</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pNoAutenticadoVivienda">
                                            45
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>







        </li>
        <li>


            <div class="contenedorTarjetas">
                <div class="contenedorTarjetas_contenido">
                    <div class="contenedorTarjetas_contenido1">
                        <div class="row">
                            <div>
                                <div class="card cartaUno">

                                    <div>
                                        <span class="card-title">Apoyo Negocio</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsNegocio">
                                            38
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaDos">

                                    <div>
                                        <span class="card-title">Préstamo Personal</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsPersonal">
                                            40
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaTres">

                                    <div>
                                        <span class="card-title">Préstamo Educación</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsEducacion">
                                            20
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="contenedorTarjetas_contenido1">
                        <div class="row">
                            <div>
                                <div class="card cartaCuatro">

                                    <div>
                                        <span class="card-title">Refundir mis deudas</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsdeudas">
                                            23
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaCinco">

                                    <div>
                                        <span class="card-title">Préstamo Vehículo</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsVehiculo">
                                            56
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaSeis">

                                    <div>
                                        <span class="card-title">Préstamo Vivienda</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsVivienda">
                                            45
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>













        </li>
        <li>


            <div class="contenedorTarjetas">
                <div class="contenedorTarjetas_contenido">
                    <div class="contenedorTarjetas_contenido1">
                        <div class="row">
                            <div>
                                <div class="card cartaUno">

                                    <div>
                                        <span class="card-title">Apoyo Negocio</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsNoAutenticadoNegocio">
                                            38
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaDos">

                                    <div>
                                        <span class="card-title">Préstamo Personal</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsNoAutenticadoPersonal">
                                            40
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaTres">

                                    <div>
                                        <span class="card-title">Préstamo Educación</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsNoAutenticadoEducacion">
                                            20
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="contenedorTarjetas_contenido1">
                        <div class="row">
                            <div>
                                <div class="card cartaCuatro">

                                    <div>
                                        <span class="card-title">Refundir mis deudas</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsNoAutenticadodeudas">
                                            23
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaCinco">

                                    <div>
                                        <span class="card-title">Préstamo Vehículo</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsNoAutenticadoVehículo">
                                            56
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <div class="card cartaSeis">

                                    <div>
                                        <span class="card-title">Préstamo Vivienda</span>
                                    </div>
                                    <div class="card-content">
                                        <p runat="server" id="pClicsNoAutenticadoVivienda">
                                            45
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


        </li>
    </ul>
     
                    <div id="confirmacion" class="modal">
                <h5 class="modal-close">&#10005;</h5>
                <div class="modal-content center">
                    <h4 class="tituloModal">Banco CK</h4>
                    <label style="font-size: 20px; color: white" id="textoModal" runat="server">"Le informamos que no hay indicadores para las fechas ingresadas, pruebe con otras fechas por favor</label>
                    <br>
                    <asp:Button runat="server" class="btn-large btn" Text="Aceptar" />

                </div>
            </div>


                <script language="javascript">
                function abrirModalConfirmacion() {
                    $('#confirmacion').modal();
                    $('#confirmacion').modal('open');
                }
                </script>



</asp:Content>
