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
            <div class="cajaFlexible1_elemento2">
                <img class="img-negocios" src="/img/manosanalista.gif" />
            </div>
        </div>


        <div class="Titulo">
            <h2>Analista</h2>
        </div>

        <div class="ContenedorFormulario">

            <div class="ContenedorFormulario_contenido1">
                <h1 class="subtitulo">Solicitudes de préstamos</h1>
                <label>Ingrese tipo Préstamo</label>
                <div class="select is-danger">
                    <select>
                        <option>Vehiculo</option>
                        <option>Vivienda</option>
                        <option>Refundir deudas</option>
                        <option>Educación</option>
                        <option>Personal</option>
                        <option>Apoyo negocio</option>
                    </select>
                </div>
                <label>Ingrese cedula del cliente:</label>
                <input type="text" placeholder="Cedula Cliente" class=" browser-default tbxCedulaCliente" />
                <button class="btnBuscar">Buscar</button>
            </div>

            <div class="ContenedorFormulario_imagen">
                <img class="img-negociosImagen" src="/img/bank.gif" />
            </div>

        </div>


        <div class="contenedor_tabla">
        <asp:GridView class="striped responsive-table tabla" ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>

                <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Identificacion" HeaderText="Identificacion">
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

                <asp:TemplateField HeaderStyle-CssClass="tabla_header" HeaderText="Acciones Analista">
                    <ItemTemplate>
                        <button class="boton3">Aceptar</button>
                        <button class="boton3">Modificar</button>
                        <button class="boton3">Eliminar</button>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
            </div>

        <div class="contenedorCartas">
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
        </div>

    </div>


</asp:Content>
