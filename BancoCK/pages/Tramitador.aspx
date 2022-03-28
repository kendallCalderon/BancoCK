<%@ Page Title="" Language="C#" MasterPageFile="~/Analista.Master" AutoEventWireup="true" CodeBehind="Tramitador.aspx.cs" Inherits="BancoCK.Formulario_web12" %>

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
                <label>Ingrese tipo Préstamo</label>
                <div class="select is-danger">
                    <select AutoPostBack="True" runat="server" id="tipoPrestamo">
                        <option>Vehiculo</option>
                        <option>Vivienda</option>
                        <option>Refundir deudas</option>
                        <option>Educación</option>
                        <option>Personal</option>
                        <option>Apoyo negocio</option>
                    </select>
                </div>
                <label>Ingrese cedula del Analista</label>
                <input class="browser-default tbx tbxCedulaCliente" type="text" placeholder="Cedula Analista"  runat="server" id="txtCedulaAnalista"/>
                <asp:Button   runat="server" id="btnBuscar" CssClass="btnBuscar"  Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
            </div>

            <div class="ContenedorFormulario_image">
                <img class="img-negociosImagen" src="/img/admintra.gif" />
            </div>

        </div>


        <div class="contenedor_tabla">
            <asp:GridView class="striped responsive-table tabla" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" >
                <Columns>

                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Préstamo #" HeaderText="Préstamo #">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-CssClass="tabla_header" ItemStyle-CssClass="tabla_item" DataField="Identificacion" HeaderText="Identificación">
                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>


                    <asp:TemplateField ItemStyle-CssClass="tabla_item"   HeaderText="Nombre Analista">

                           <ItemTemplate>

                               <asp:DropDownList  ID="ddlNombreAnalistas" CssClass=" browser-default cbxCombo" AutoPostBack="True" name="listaUsuarios" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nombre Analista" DataValueField="Nombre Analista" OnSelectedIndexChanged="CambioEnComBoBox">

                               </asp:DropDownList>
                              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoSitiosConnectionString %>" SelectCommand="devolverAnalistasComboBox" SelectCommandType="StoredProcedure"></asp:SqlDataSource> 
                        </ItemTemplate>
                        
                           <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                    </asp:TemplateField>



                    <asp:TemplateField ItemStyle-CssClass="tabla_item"   HeaderText="Acciones">

                        <ItemTemplate>
                            <itemstyle horizontalalign="Center" />
                            <asp:LinkButton Text="text" runat="server" CommandArgument='<%# Eval("Préstamo #") %>' OnCommand="AsignarAnalista"><i class="fa-solid fa-circle-check icn"></i></asp:LinkButton>
                        </ItemTemplate>

                        <HeaderStyle CssClass="tabla_header"></HeaderStyle>

                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
        </div>



    </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
</asp:Content>
