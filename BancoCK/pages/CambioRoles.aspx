<%@ Page Title="" Language="C#" MasterPageFile="~/Configuraciones.Master" AutoEventWireup="true" CodeBehind="CambioRoles.aspx.cs" Inherits="BancoCK.Formulario_web13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/CambioRoles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h1 >Administración de Roles</h1>
        <div class="ContenedorFormulario_contenido1">

            <div class="columna2">
                <div class="columna2-item">

                    <label class="etiquetaModel">Seleccione filtro a buscar</label>
                    <div class="select is-danger">
                        <select autopostback="True" runat="server" id="tipoBusqueda">
                            <option>Nombre</option>
                            <option>Apellido</option>
                            <option>Correo</option>
                            <option>Telefono</option>
                            <option>Identificacion</option>
                        </select>
                    </div>

                    <label  class="etiquetaModel">Ingrese campo a buscar</label>
                    <input type="text" id="campotxt" runat="server" class="browser-default tbx tbxCedulaCliente">
                </div>
                <div class="columna2-item">
                    <label class="etiquetaModel">Rol a buscar</label>
                    <div class="select is-danger">
                        <select autopostback="True" runat="server" id="tipoRol">
                            <option>Analista</option>
                            <option>Tramitador</option>
                        </select>
                    </div>

                </div>

            </div>
            <asp:Button runat="server" ID="btnBuscar" data-target="login" CssClass="btnBuscar" Text="Buscar" OnClick="busquedaFiltrada"></asp:Button>
        </div>


        <div class="contenedor_tabla">
            <asp:GridView  OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="tabla centered responsive-table"  ID="GridView1" runat="server" AutoGenerateColumns="False"  AllowPaging="True" PageSize="5">
                <Columns>

                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Identificación" HeaderText="Identificación">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Nombre" HeaderText="Nombre">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Primer Apellido" HeaderText="Primer Apellido">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Segundo Apellido" HeaderText="Segundo Apellido">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Correo" HeaderText="Correo">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Teléfono" HeaderText="Teléfono">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Rol" HeaderText="Rol">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField ItemStyle-CssClass="tabla_item" HeaderText="Acciones">


                        <ItemTemplate>
                            <itemstyle horizontalalign="Center" />
                            <asp:LinkButton Text="text" runat="server" CommandArgument='<%# Eval("Identificación") %>' OnClick="Modificar" OnCommand="Modificar"><i class="fa-solid fa-circle-check icn"></i></asp:LinkButton>
                        </ItemTemplate>


                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>


   



    <div id="Analista" class="modal modal-tramitador">
        <h5 class="modal-close">&#10005;</h5>
        <div class="modal-content center">
            <h4 class="tituloModal">Seleccione el nuevo rol del usuario</h4>
            <label runat="server" class="etiquetaModel" id="mensaje" style="font-size: 20px; color: white"></label>
            <br>
            <label  class="etiquetaModel">Digite el rol a cambiar</label>
            <div class="input-field">
                <div class="select is-danger">
                    <select autopostback="True" runat="server" id="Opcion">
                        <option>Analista</option>
                        <option>Tramitador</option>
                    </select>
                </div>
            </div>

            <br>
            <asp:Button runat="server" class="btn btn-large" Text="Cambiar" OnClick="btnModals" />
        </div>
    </div>


    <div id="Tramitador" class="modal modal-tramitador">
        <h5 class="modal-close">&#10005;</h5>
        <div class="modal-content center">
            <h4 class="tituloModal">Seleccione el nuevo rol del usuario</h4>
            <label runat="server" id="mensaje2" style="font-size: 20px; color: white"></label>
            <br>
            <label class="etiquetaModel">Rol a cambiar</label>
            <div class="input-field">
                <div class="select is-danger">
                    <select autopostback="True" runat="server" id="rolTramitadorEscogido">
                        <option>Analista</option>
                        <option>Tramitador</option>
                    </select>
                </div>
            </div>

            <label class="etiquetaModel">Créditos a cargo</label>
            <div class="input-field">
                <div class="select is-danger">
                    <select autopostback="True" runat="server" id="Encargo">
                        <option>Préstamo vehiculo</option>
                        <option>Préstamo Vivienda</option>
                        <option>Refundir mis deudas</option>
                        <option>Préstamo Educacion</option>
                        <option>Préstamo Personal</option>
                        <option>Apoyo Negocio</option>
                        <option>General</option>
                    </select>
                </div>
            </div>

            <br>
            <asp:Button runat="server" class="btn" Text="Cambiar" OnClick="btnModals" />
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


             <asp:Panel ID="PanelInforme" runat="server">
                  <div id="informe" class="modal">
                <h5 class="modal-close">&#10005;</h5>
                <div class="modal-content center">
                    <h4 class="tituloModal">Banco CK</h4>
                    <label style="font-size: 20px; color: white">No hay registros para los filtros ingresados</label>
                    <br>
                    <asp:Button runat="server" class="btn-large btn" Text="Aceptar" />

                </div>
            </div>
             </asp:Panel>

    
                <div id="confirmacion" class="modal">
                <h5 class="modal-close">&#10005;</h5>
                <div class="modal-content center">
                    <h4 class="tituloModal">Banco CK</h4>
                    <label style="font-size: 20px; color: white" id="textoModal" runat="server"></label>
                    <br>
                    <asp:Button runat="server" class="btn-large btn" Text="Aceptar" />

                </div>
            </div>

           


            <script language="javascript">
                function abrirModal() {
                    $('#Analista').modal();
                    $('#Analista').modal('open');
                }
            </script>

            <script language="javascript">
                function abrirModalError() {
                    $('#mensajeError').modal();
                    $('#mensajeError').modal('open');
                }
            </script>

            <script language="javascript">
                function abrirModalTramitador() {
                    $('#Tramitador').modal();
                    $('#Tramitador').modal('open');
                }
            </script>

            <script language="javascript">
                function abrirModalConfirmacion() {
                    $('#confirmacion').modal();
                    $('#confirmacion').modal('open');
                }
            </script>

            <script language="javascript">
                function abrirModalAviso() {
                    $('#informe').modal();
                    $('#informe').modal('open');        
                }
            </script>


            <asp:ScriptManager ID="ScriptManager1" runat="server" />
</asp:Content>
