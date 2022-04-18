<%@ Page Title="" Language="C#" MasterPageFile="~/Configuraciones.Master" AutoEventWireup="true" CodeBehind="CambioTasas.aspx.cs" Inherits="BancoCK.Formulario_web2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="/css/Tasas.css" />
    <script src="/js/modals.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="ContenedorFormulario">
        <h1 class="tituloConfiguracion2">Administración de Tasas</h1>
        <div class="contenedor_tabla">
            <asp:GridView class="centered responsive-table tabla" ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>

                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Nombre Préstamo" HeaderText="Nombre Préstamo">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Tasa en dólares" HeaderText="Tasa en dólares">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Tasa en Colones" HeaderText="Tasa en Colones">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                

                    <asp:TemplateField ItemStyle-CssClass="tabla_item" HeaderText="Acciones">

                        <ItemTemplate>
                            <itemstyle horizontalalign="Center" />
                            <asp:LinkButton Text="text" runat="server" CommandArgument='<%# Eval("Nombre Préstamo") %>' OnClick="Modificar" OnCommand="Modificar"><i class="fa-solid fa-circle-check icn"></i></asp:LinkButton>
                        </ItemTemplate>


                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>
            </div>

    <div id="tasas" class="modal modalTasas">
        <h5 class="modal-close">&#10005;</h5>
        <div class="modal-content center">
            <h4 class="tituloModal">Ingrese las nuevas tasas de Interés</h4>
            <br>

            <label>Tasa en Colones</label>
            <div class="input-field">
                <input  type="text" id="tasaColones" runat="server"/>
            </div>

            <label>Tasa en Dolares</label>
            <div class="input-field">
                <input  type="text" id="tasaDolares" runat="server"/>
            </div>

            <br>
            <asp:Button runat="server" class="btn btn-large" Text="Cambiar" OnClick="btnModals" />
        </div>
    </div>

    <div id="aviso" class="modal">
                <h5 class="modal-close">&#10005;</h5>
                <div class="modal-content center">
                    <h4 class="tituloModal">Banco CK</h4>
                    <label style="font-size: 20px; color: white">Las tasas de interes no pueden ser menor o igual a 1, ni tampoco mayor a 20 porciento</label>
                    <br>
                    <asp:Button runat="server" class="btn-large btn" Text="Aceptar" />

                </div>
            </div>

     <div id="confirmacion" class="modal">
                <h5 class="modal-close">&#10005;</h5>
                <div class="modal-content center">
                    <h4 class="tituloModal">Banco CK</h4>
                    <label style="font-size: 20px; color: white">Se ha modificado las tasas de interés del préstamo exitosamente</label>
                    <br>
                    <asp:Button runat="server" class="btn-large btn" Text="Aceptar" />

                </div>
            </div>


            <script language="javascript">
                function abrirModal() {
                    $('#tasas').modal();
                    $('#tasas').modal('open');
                }
            </script>

              <script language="javascript">
                  function abrirModalAviso() {
                      $('#aviso').modal();
                      $('#aviso').modal('open');
                  }
              </script>
              
              <script language="javascript">
                  function abrirModalConfirmacion() {
                      $('#confirmacion').modal();
                      $('#confirmacion').modal('open');
                  }
              </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
</asp:Content>
