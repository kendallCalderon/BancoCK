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
                                Le tenemos las mejores condiciones y beneficios de lograr tus metas, Tasa cómoda.
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" OnClick="Unnamed1_Click"  Text="Solicitar" runat="server" /> 
                        <asp:LinkButton id="btnVivienda" OnClick="btnVivienda_Click" runat="server" ><img src="/img/Calculator.png" class="iconoo"  /></asp:LinkButton>
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
                            Tenemos un crédito que se adapta a cada momento, con las mejores condiciones y pensado para usted.
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" OnClick="Unnamed2_Click"  Text="Solicitar" runat="server" />
                        <%--<i class="fa-solid fa-calculator fa-2x icono"></i>--%>
                        <asp:LinkButton id="btnPersonal" OnClick="btnPersonal_Click" runat="server" ><img src="/img/Calculator.png" class="iconoo"  /></asp:LinkButton>
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
                          
                           Crédito que se ajusta a sus necesidades con cuota atractiva.
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" OnClick="Unnamed3_Click" Text="Solicitar" runat="server" />
                       <asp:LinkButton id="btnVehiculo" OnClick="btnVehiculo_Click" runat="server" ><img src="/img/Calculator.png" class="iconoo"  /></asp:LinkButton>
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
                              Gane paz y liquidez al unificar sus deudas con banco CK Cuota Única.
                              Una sola cuota y muy atractiva.
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" OnClick="Unnamed4_Click"  Text="Solicitar" runat="server" />
                        <asp:LinkButton id="btnDeudas" OnClick="btnDeudas_Click" runat="server" ><img src="/img/Calculator.png" class="iconoo"  /></asp:LinkButton>
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
                          Préstamo comercial puedes obtener financiamiento para expandir tu negocio y refinanciar tus deudas.
                          
                        </p>
                    </div>
                    <div class="card-action">
                     <asp:Button class="btnSolicitar" OnClick="Unnamed5_Click"  Text="Solicitar" runat="server" />
                       <asp:LinkButton id="btnNegocio" OnClick="btnNegocio_Click" runat="server" ><img src="/img/Calculator.png" class="iconoo"  /></asp:LinkButton>
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
                           El Banco CK le ofrece diferentes opciones de financiamiento de acuerdo con sus necesidades.
                        </p>
                    </div>
                    <div class="card-action">
                        <asp:Button class="btnSolicitar" OnClick="Unnamed6_Click"  Text="Solicitar" runat="server" />
                        <asp:LinkButton id="btnEducacion" OnClick="btnEducacion_Click" runat="server" ><img src="/img/Calculator.png" class="iconoo"  /></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>



   



















</asp:Content>
