<%@ Page Title="" Language="C#" MasterPageFile="~/Analista.Master" AutoEventWireup="true" CodeBehind="HistorialCreditos.aspx.cs" Inherits="BancoCK.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/Tramitador.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Contenedor">
        <div class="ImagenInicial">
            <img class="ImagenInicial_Fondo" src="/img/trabaner.gif" />
        </div>
        <div class="Titulo">
            <h1>Tramitador</h1>
        </div>

        <div class="ContenedorFormulario">
            <div class="ContenedorFormulario_contenido1">
                <h2 class="subtitulo">Solicitudes de préstamos</h2>
                <div class="columna2">
                     <div class="columna2-item">
                           <label>Ingrese la fecha inicial</label>
                           <input type="date" runat="server" id="fechaInicio" class="browser-default tbx tbxCedulaCliente">
                           <label>Ingrese tipo prestamo</label>
                            <div class="select is-danger">
                            <select AutoPostBack="True" runat="server" id="tipoPrestamo">
                               <option>Préstamo vehiculo</option>
                               <option>Préstamo Vivienda</option>
                               <option>Refundir deudas</option>
                               <option>Préstamo Educacion</option>
                               <option>Préstamo Personal</option>
                              <option>Apoyo negocio</option>
                            </select>
                           </div>
                           <label>Seleccione filtro a buscar</label>
                            <div class="select is-danger">
                            <select AutoPostBack="True" runat="server" id="tipoBusqueda">
                               <option>Nombre</option>
                               <option>Apellido</option>
                               <option>Correo</option>
                               <option>Telefono</option>
                               <option>Identificacion</option>
                            </select>
                           </div>
                     </div>
                    <div class="columna2-item">
                         <label>Ingrese la fecha Final</label>
                         <input type="date" id="fechaFinal" runat="server" class="browser-default tbx tbxCedulaCliente">
                         <label>Estado de créditos a buscar</label>
                        <div class="select is-danger">
                         <select AutoPostBack="True" runat="server" id="estadoCredito">
                               <option>Aprobado</option>
                               <option>Rechazado</option>
                               <option>Espera</option>
                               <option>Analizar</option>
                         </select>
                        </div>
                        <label>Ingrese campo a buscar</label>
                        <input type="text" id="filtro" runat="server" class="browser-default tbx tbxCedulaCliente">
                    </div>
                    
                </div>
              
                <asp:Button runat="server" ID="btnBuscar" CssClass="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
            </div>

            <div class="ContenedorFormulario_image">
                <img class="img-negociosImagen" src="/img/admintra.gif" />
            </div>

        </div>

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
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Estado crédito" HeaderText="Estado crédito">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                </Columns>

            </asp:GridView>
        </div>

    </div>


    <asp:ScriptManager ID="ScriptManager1" runat="server" />
</asp:Content>
