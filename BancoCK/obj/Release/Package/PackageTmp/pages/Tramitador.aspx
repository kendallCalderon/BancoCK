<%@ Page Title="" Language="C#" MasterPageFile="~/Analista.Master" AutoEventWireup="true" CodeBehind="Tramitador.aspx.cs" Inherits="BancoCK.Formulario_web12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/Tramitador.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Contenedor">
        <div class="ImagenInicial">
            <img class="ImagenInicial_Fondo" src="/img/tramitador.gif" />
        </div>
        <div class="Titulo">
            <h1>Tramitador</h1>
        </div>

        <div class="ContenedorFormulario">

            <div class="ContenedorFormulario_contenido1">
                <h2 class="subtitulo">Solicitudes de préstamos</h2>
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
                <label>Ingrese cedula del Analista:</label>
                <input type="text" placeholder="Cedula Analista" />
                <button class="btnBuscar">Buscar</button>
            </div>

            <div class="ContenedorFormulario_image">
                <img class="img-negociosImagen" src="/img/admintra.gif" />
            </div>

        </div>


        <div class="contenedor_tabla">
        <asp:GridView class="striped responsive-table tabla" ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>

                <asp:BoundField  HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Préstamo #" HeaderText="Préstamo #">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField  HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Identificación" HeaderText="Identificación">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField  HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Nombre Analista" HeaderText="Nombre Analista">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:TemplateField  HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" HeaderText="Acciones">
                    <ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <button class="boton3">Asignar</button>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
      </div>

    </div>
</asp:Content>
