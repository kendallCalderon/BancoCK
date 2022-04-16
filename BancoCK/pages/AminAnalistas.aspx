<%@ Page Title="" Language="C#" MasterPageFile="~/Configuraciones.Master" AutoEventWireup="true" CodeBehind="AminAnalistas.aspx.cs" Inherits="BancoCK.pages.AminAnalistas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/AdminAnalistas.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <asp:GridView CssClass="tabla" ID="gvAnalistas" runat="server" OnRowCommand="gvAnalistas_RowCommand" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Identificación" DataField="IDESTUDIANTE" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Nombre" DataField="NOMBRE" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Primer Apellido" DataField="PRIMERAPELLIDO" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Segundo Apellido" DataField="SEGUNDOAPELLIDO" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Fecha de Nacimiento" DataField="FECHA_NAC" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Contraseña" DataField="CONTRASEÑA" />
            <asp:TemplateField HeaderStyle-CssClass="tabla_item_header" HeaderText="Modificar" ItemStyle-CssClass="tabla_item">
                <ItemTemplate>
                    <asp:LinkButton ID="btnModificar" CommandName="btnModificar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-edit iedit"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="tabla_item_header" HeaderText="Eliminar" ItemStyle-CssClass="tabla_item">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEliminar" CommandName="btnEliminar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"><i class="fas fa-trash-alt itrash"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


</asp:Content>
