<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="Prestamos.aspx.cs" Inherits="BancoCK.pages.Prestamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Prestamos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="Contenedor_img">
        <img class="img_DosManos" src="../img/DosManos.jpg" />
    </div>

    <div class="column is-full Contenedor_cards">

        <div class="divflex">
            <div class="col s12 m7 divvivienda">
                <div class="card medium carta">
                    <div class="card-image">
                        <img class="imgvivienda" src="../img/Vivienda.jpg">
                        <span class="card-title titulo">Vivienda</span>
                    </div>
                    <div class="card-content contenido_card">
                        <p>
                               Cumple tu sueño de
                                    casa propia
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" Text="Solicitar" runat="server" /> 
                    </div>
                </div>
            </div>


            <div class="col s12 m7 divvivienda">
                <div class="card medium">
                    <div class="card-image">
                        <img class="imgvivienda" src="../img/Personal.jpg">
                        <span class="card-title titulo">Personal</span>
                    </div>
                    <div class="card-content contenido_card">
                        <p>
                            Consigue tu prestamo
                                 para tus metas personales
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" Text="Solicitar" runat="server" /> 
                    </div>
                </div>
            </div>




            <div class="col s12 m7 divvivienda">
                <div class="card medium">
                    <div class="card-image">
                        <img class="imgvivienda" src="../img/car.jpg">
                        <span class="card-title titulo">Vehículo</span>
                    </div>
                    <div class="card-content contenido_card">
                        <p>
                          Consigue tu auto propio
                                     con nosotros
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" Text="Solicitar" runat="server" /> 
                    </div>
                </div>
            </div>
        </div>

        <div class="divflex">
            <div class="col s12 m7 divvivienda">
                <div class="card medium">
                    <div class="card-image">
                        <img class="imgvivienda" src="../img/Deuda.jpg">
                        <span class="card-title titulo">Refundir Deudas</span>
                    </div>
                    <div class="card-content contenido_card">
                        <p>
                             Cancele sus deudas,
                                    nosotros te prestamos
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" Text="Solicitar" runat="server" /> 
                    </div>
                </div>
            </div>

            <div class="col s12 m7 divvivienda">
                <div class="card medium">
                    <div class="card-image">
                        <img class="imgvivienda" src="../img/Negocio.jpg">
                        <span class="card-title titulo">Apoyar Negocio</span>
                    </div>
                    <div class="card-content contenido_card">
                        <p>
                          Cumple tu sueño de
                                    emprender un nuevo negocio
                        </p>
                    </div>
                    <div class="card-action">
                     <asp:Button class="btnSolicitar" Text="Solicitar" runat="server" /> 
                    </div>
                </div>
            </div>

            <div class="col s12 m7 divvivienda">
                <div class="card medium">
                    <div class="card-image">
                        <img class="imgvivienda" src="../img/Educacion.jpg">
                        <span class="card-title titulo">Financiar Educación</span>
                    </div>
                    <div class="card-content contenido_card">
                        <p>
                           Te préstamos para 
                                  tu educación
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" Text="Solicitar" runat="server" /> 
                    </div>
                </div>
            </div>
        </div>
    </div>



   



















</asp:Content>
