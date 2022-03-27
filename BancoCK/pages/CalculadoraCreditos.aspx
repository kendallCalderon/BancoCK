<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="CalculadoraCreditos.aspx.cs" Inherits="BancoCK.Formulario_web14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/Calculadora.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Contenedor">
        <div class="contenedorFlexible">
            <div class="contenedorFlexible_contenido_formulario">
                <div class="contenedorFlexible_contenido_subcontenido">
                    <h3>Moneda</h3>
                    <div class="contenedorFlexible_contenido_subcontenido_row">
                        <asp:Button runat="server" id="btnDolaresMoneda"  text="Dolares" name="btnDolares" CssClass="btnDolares" OnClick="btnDolares_Click"></asp:Button>
                        <asp:Button runat="server" id="btnColonesMoneda" CssClass="btnColones" name="btnColones" Text="Colones" OnClick="btnColones_Click"></asp:Button>
                    </div>
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                    <label>Monto a solicitar</label>
                    <input type="text" id="txtMonto" runat="server"/>
                    <p id="txtMensajeMonto" runat="server" class="marginMensaje">Monto a solicitar</p>
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                    <label>Plazo en años</label>
                    <input type="number"  id="txtRangoAñosPrestamo" runat="server" max="30"  min="1"/>
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                    <label>Tasa %</label>
                    <input type="text" runat="server" id="txtTasa" readonly="readonly" />
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                       <label>Monto mensual</label>
                       <div class="cajaIconoCalcular">
                            <input type="text" runat="server" id="txtMontoMensual" readonly="readonly" />
                           <asp:LinkButton Text="text" ID="btnCalcular"  runat="server" OnClick="btnCalcular_Click"><i class='fa fa-calculator fa-2x icono'></i></asp:LinkButton>
                       </div>   
                </div>
                <div class="contenedorFlexible_contenido_subcontenido_row">
                    <button class="btnAtras">Atras</button>
                    <button class="btnTramitador">Tramitador</button>
                </div>

            </div>
            <div class="contenedorFlexible_contenido_imagen">
                  <div class="contenedorFlexible_contenido_subcontenido margen">
                     <div class="select is-danger">
                    <asp:DropDownList runat="server" id="cbxComboPrestamo" OnSelectedIndexChanged="cbxComboPrestamo_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>

                </div>
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                     <img class="img-imagenFondo" src="/img/bank.gif"></img>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
