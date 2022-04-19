<%@ Page Title="" Language="C#" MasterPageFile="~/Analista.Master" AutoEventWireup="true" CodeBehind="Analista.aspx.cs" Inherits="BancoCK.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/analista.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Contenedor">

        <div class="cajaFlexible1">
            <div class="cajaFlexible1_elemento1">
                <img class="img-negocios" src="/img/salaanalista.gif" />
            </div>
            
        </div>

        <div class="Titulo">
            <h2>Analista</h2>
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
                               <option>Refundir mis deudas</option>
                               <option>Préstamo Educacion</option>
                               <option>Préstamo Personal</option>
                              <option>Apoyo Negocio</option>
                            </select>
                           </div>
                           <label>Ingrese campo a buscar</label>
                           <input type="text" id="filtro" runat="server" class="browser-default tbx tbxCedulaCliente">      
                     </div>
                    <div class="columna2-item">
                         <label>Ingrese la fecha Final</label>
                         <input type="date" id="fechaFinal" runat="server" class="browser-default tbx tbxCedulaCliente">
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
                    
                </div>
                <br />
                <br />
                <asp:Button runat="server" ID="btnBuscar" CssClass="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
            </div>

            <div class="ContenedorFormulario_image">
                <img class="img-negociosImagen" src="/img/admintra.gif" />
            </div>

        </div>



        <div class="contenedor_tabla">
        <asp:GridView class="striped responsive-table tabla" ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>

                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Préstamo #" HeaderText="Préstamo #">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Identificacion" HeaderText="Identificacion">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Nombre Cliente" HeaderText="Nombre Cliente">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Primer Apellido" HeaderText="Primer Apellido">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Segundo Apellido" HeaderText="Segundo Apellido">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Monto Préstamo" HeaderText="Monto Préstamo">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Moneda" HeaderText="Moneda">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Cuota Mensual" HeaderText="Cuota Mensual">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Salario Neto" HeaderText="Salario Neto">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Teléfono" HeaderText="Teléfono">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Correo" HeaderText="Correo">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Nivel de endeudamiento" HeaderText="Nivel de endeudamiento">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:TemplateField HeaderStyle-CssClass="tabla_header" HeaderText="Acciones Analista">
                    <ItemTemplate>
                        <asp:LinkButton Text="text" runat="server" CommandArgument='<%# Eval("Préstamo #") %>' OnClick="AceptarSolicitud" OnCommand="AceptarSolicitud"><i class="fa-solid fa-circle-check icn"></i></asp:LinkButton>
                        <asp:LinkButton Text="text" runat="server" CommandArgument='<%# Eval("Préstamo #") %>' OnClick="RechazarSolicitud" OnCommand="RechazarSolicitud"><i class="fa-solid fa-trash-can icn"></i></asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
            </div>

       <%-- <div class="contenedorCartas">
            <h2>Opciones analista</h2>
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
                                <button class="btnObservar">Observar</button>
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
                                <span class="card-title">Créditos pendientes</span>
                            </div>
                            <div class="card-content">
                                <button class="btnObservar">Observar</button>
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
                                <button class="btnObservar">Observar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>

    </div>

</asp:Content>
