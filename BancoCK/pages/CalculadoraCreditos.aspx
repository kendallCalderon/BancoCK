<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="CalculadoraCreditos.aspx.cs" Inherits="BancoCK.Formulario_web14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/Calculadora.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Contenedor">
        <div class="contenedorFlexible">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="contenedorFlexible_contenido_formulario">
                <div class="contenedorFlexible_contenido_subcontenido">
                    <h3>Moneda</h3>
                    <div class="contenedorFlexible_contenido_subcontenido_row_botones">
                        
                    
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
                    <input type="number"  id="txtRangoAñosPrestamo" runat="server"/>
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
                <div class="contenedorFlexible_contenido_subcontenido_row_botones">
                    <asp:Button runat="server" id="btnAtras" CssClass="btnColones" Text="Atras" OnClick="btnAtras_Click"></asp:Button>
                    <asp:Button runat="server" id="btnTramitar"  text="Tramitar" CssClass="btnDolares" OnClick="btnTramitar_Click"></asp:Button>
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
                     <img class="img-imagenFondo" src="/img/bank.gif" />
                </div>
            </div>
        </div>
    </div>
                <div id="confirmacion" class="modal">
                <h5 class="modal-close">&#10005;</h5>
                <div class="modal-content center">
                    <h4 class="tituloModal">Banco CK</h4>
                    <label style="font-size: 20px; color: white" id="textoModal" runat="server"></label>
                    <br>
                    <asp:Button runat="server" class="btn-large btn" Text="Aceptar" />

                </div>
            </div>

        <div id="mensajeError" class="modal datos">
        <h5 class="modal-close">&#10005;</h5>
        <div class="modal-content center">
            <h4 class="tituloModal">Error</h4>
            <label runat="server" id="error" style="font-size: 20px; color: white"></label>
            <br>
            <asp:Button runat="server" class="btn-large error" Text="Aceptar" />
            </div>
        </div>


           <script language="javascript">
                function abrirModalConfirmacion() {
                    $('#confirmacion').modal();
                    $('#confirmacion').modal('open');
                }
           </script>

             <script language="javascript">
                 function abrirModalError() {
                     $('#mensajeError').modal();
                     $('#mensajeError').modal('open');
                 }
             </script>
</asp:Content>
