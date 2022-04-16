<%@ Page Title="" Language="C#" MasterPageFile="~/Analista.Master" AutoEventWireup="true" CodeBehind="Tramitador.aspx.cs" Inherits="BancoCK.Formulario_web12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/Tramitador.css" />
    <script src="https://cdn.jsdelivr.net/npm/uikit@3.13.7/dist/js/uikit.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Contenedor">
        <div class="ImagenInicial">
            <img class="ImagenInicial_Fondo" src="/img/trabaner.gif" />
        </div>

       

            </div>
      




        <div class="Titulo">
            <h1>Tramitador</h1>
        </div>

        <div class="ContenedorFormulario">

            <div class="ContenedorFormulario_contenido1">
                <h2 class="subtitulo">Solicitudes de préstamos</h2>
                <label>Ingrese la fecha inicial</label>
                <input type="date" runat="server" id="fechaInicio" class="browser-default tbx tbxCedulaCliente">
                <label>Ingrese la fecha Final</label>
                <input type="date" id="fechaFinal" runat="server" class="browser-default tbx tbxCedulaCliente">
                <label>Seleccione el analista</label>
                <div class="select is-danger">
                    <asp:DropDownList runat="server" id="comboAnlista" OnSelectedIndexChanged="cbxComboAnlista_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <asp:Button   runat="server" id="btnBuscar" CssClass="btnBuscar"  Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
            </div>

            <div class="ContenedorFormulario_image">
                <img class="img-negociosImagen" src="/img/admintra.gif" />
            </div>

        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />



        <div class="contenedor_tabla">
            <asp:GridView class="striped responsive-table tabla" ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>

                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Préstamo #" HeaderText="Préstamo #">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Identificacion" HeaderText="Identificacion">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Monto" HeaderText="Monto">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Fecha crédito" HeaderText="Fecha crédito">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Tipo Prestamo" HeaderText="Tipo Prestamo">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>


                    <asp:TemplateField ItemStyle-CssClass="tabla_item" HeaderText="Acciones">

                        <ItemTemplate>
                            <itemstyle horizontalalign="Center" />
                            <asp:LinkButton Text="text" runat="server" CommandArgument='<%# Eval("Préstamo #") %>' OnClick="AsignarAnalista" OnCommand="AsignarAnalista"><i class="fa-solid fa-circle-check icn"></i></asp:LinkButton>
                        </ItemTemplate> 

                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
        </div>



        <div class="contenedorCartas">
            <h2>Opciones Tramitador</h2>
            <div class="contenedorCartas_item">
                <div class="row">
                    <div>
                        <div class="card">
                            <div class="card-image">
                                <img class="imgs" src="/img/graficoana.jpg">
                            </div>
                            <div>
                                <span class="card-title">Comparativa Créditos</span>
                            </div>
                            <div class="card-content">
                                <asp:Button Text="Observar" runat="server" class="btnObservar browser-default" ID="btnObservarCreditos" OnClick="btnObservarCreditos_Click" />

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div>
                        <div class="card">
                            <div class="card-image">
                                <img class="imgs" src="/img/creditosana.jpg">
                            </div>
                            <div>
                                <span class="card-title">Configuraciones</span>
                            </div>
                            <div class="card-content">

                                
                                <asp:Button class=" btnObservar browser-default" Text="Observar" runat="server" id="btnObservarCreditosPendientes" OnClick="btnObservarCreditosPendientes_Click" />

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div>
                        <div class="card">
                            <div class="card-image">
                                <img class="imgs" src="/img/historialana.jpg">
                            </div>
                            <div>
                                <span class="card-title">Historial créditos</span>
                            </div>
                            <div class="card-content">
                                <asp:Button Text="Observar" runat="server" class="btnObservar browser-default" ID="btnObservarHistorialCreditos" OnClick="btnObservarHistorialCreditos_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



    </div>


        <asp:ScriptManager ID="ScriptManager1" runat="server" />
</asp:Content>
