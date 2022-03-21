<%@ Page Title="" Language="C#" MasterPageFile="~/Analista.Master" AutoEventWireup="true" CodeBehind="graficaDatos.aspx.cs" Inherits="BancoCK.pages.graficaDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/graficaDatos.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        
            <img class="contenedor_Imagen_imagenFondo" src="../img/bank.gif" />
        
        <div class="ContenedorBusqueda">
            <h3>Créditos historicos por fecha</h3>
            <div class="contenedor_formulario">
                <div class="contenedor_formulario_item">
                    <label class="lblfechas">Seleccione fecha de inicio:</label>
                    <div class="select is-danger">
                        <select class="cbxfechas">
                            <option>Vehiculo</option>
                            <option>Vivienda</option>
                            <option>Refundir deudas</option>
                            <option>Educación</option>
                            <option>Personal</option>
                            <option>Apoyo negocio</option>
                        </select>
                    </div>
                </div>
                <div class="contenedor_formulario_item">
                    <label class="lblfechas">Seleccione la fecha final:</label>
                    <div class="select is-danger">
                        <select class="cbxfechas">
                            <option>Vehiculo</option>
                            <option>Vivienda</option>
                            <option>Refundir deudas</option>
                            <option>Educación</option>
                            <option>Personal</option>
                            <option>Apoyo negocio</option>
                        </select>
                    </div>
                </div>
                <div class="contenedor_formulario_item">
                <button class="boton_aceptar">Aceptar</button>
                    </div>
            </div>

        </div>

        <div class="contenedorTarjetas">
            <h3>Visitas de créditos</h3>
            <div class="contenedorTarjetas_contenido">
                <div class="contenedorTarjetas_contenido1">
                    <div class="row">
                        <div>
                            <div class="card cartaUno">
                              
                                <div>
                                    <span class="card-title">Apoyo Negocio</span>
                                </div>
                                <div class="card-content">
                                    <p>
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
                                    <p>
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
                                    <p>
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
                                    <p>
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
                                    <p>
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
                                    <p>
                                    45
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            </div>

       


   
</asp:Content>
