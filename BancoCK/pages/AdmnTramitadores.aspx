<%@ Page Title="" Language="C#" MasterPageFile="~/Configuraciones.Master" AutoEventWireup="true" CodeBehind="AdmnTramitadores.aspx.cs" Inherits="BancoCK.pages.AdmnTramitadores" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/css/AdminTramitadores.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Button ID="btnInsertar" CssClass="btnInsertar" Text="Insertar" runat="server" OnClick="btnInsertar_Click1" />

    <asp:GridView CssClass="tabla centered responsive-table" AllowPaging="True" PageSize="5"  OnPageIndexChanging="gvTramitadores_PageIndexChanging"  ID="gvTramitadores" runat="server"  OnRowCommand="gvTramitadores_RowCommand" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Identificación" DataField="Identificacion" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Primer Apellido" DataField="Apellido1" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Segundo Apellido" DataField="Apellido2" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Correo Electrónico" DataField="Correo" />
            <asp:BoundField ItemStyle-CssClass="tabla_item" HeaderStyle-CssClass="tabla_item_header" HeaderText="Teléfono" DataField="Telefono" />
            <asp:TemplateField HeaderStyle-CssClass="tabla_item_header" HeaderText="Modificar" ItemStyle-CssClass="tabla_item">
                <ItemTemplate>
                    <asp:LinkButton ID="btnModificar" CommandName="btnModificar" runat="server"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fas fa-edit iedit"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-CssClass="tabla_item_header" HeaderText="Eliminar" ItemStyle-CssClass="tabla_item">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEliminar"  CommandName="btnEliminar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fas fa-trash-alt itrash"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

<img class="imgAnalista" src="/img/TramitadorConf.gif" />


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    <asp:LinkButton ID="fake" runat="server" Enabled="false"></asp:LinkButton>



    <ajaxToolkit:ModalPopupExtender ID="ModalInsertar" runat="server" PopupControlID="PanelInsertar" TargetControlID="btnInsertar" CancelControlID="btnicon" BackgroundCssClass="BackgroundModal"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PanelInsertar" runat="server">
        <div class="ContenedorInsertar">
            <asp:LinkButton ID="btnicon" CssClass="btnicon browser-default" runat="server" OnClick="btnicon_Click"><i class="fa-solid fa-circle-arrow-left icnAtras"></i></asp:LinkButton>
            <div class="form__group field t">
                <input runat="server" class="form__field browser-default " type="text" name="name" id="tbxId" placeholder=" Identificación" required="required" />
                <label for="Usuario" class="form__label">Identificación</label>
            </div>
            <div class="form__group field t">
                <input runat="server" class="form__field browser-default " type="text" name="name" id="tbxNom" placeholder="Nombre" required="required" />
                <label for="Usuario" class="form__label">Nombre</label>
            </div>
            <div class="form__group field">
                <input type="Text" value="Tramitador" id="tbxRol" class="form__field browser-default " runat="server" readonly="Readonly" />
                <label for="Usuario" class="form__label">Rol</label>
            </div>
            <div class="form__group field">
                <input runat="server" class="form__field browser-default" type="text" name="name" id="tbxPap" placeholder="1er Apellido" required="required" />
                <label for="Usuario" class="form__label">1er Apellido</label>
            </div>
            <div class="form__group field">
                <input runat="server" class="form__field browser-default" type="text" name="name" id="tbxSap" placeholder="2do Apellido" required="required" />
                <label for="Usuario" class="form__label">2do Apellido</label>
            </div>
            <div class="form__group field">
                <input runat="server" class="form__field browser-default" type="Email" name="name" id="tbxCorreo" placeholder="CorreoElectronico" required="required" />
                <label for="Usuario" class="form__label">CorreoElectronico</label>
            </div>
            <div class="form__group field">
                <input runat="server" class="form__field browser-default" type="text" name="name" id="tbxTel" placeholder="Teléfono" required="required" />
                <label for="Usuario" class="form__label">Teléfono</label>
            </div>
            <div class="form__group field">
                <input runat="server" class="form__field browser-default" type="password" name="name" id="tbxPass" placeholder="Contraseña" required="required" />
                <label for="Usuario" class="form__label">Contraseña</label>
            </div>
            <asp:LinkButton ID="btnInsertarConfirmar" Text="Insertar" runat="server" CssClass="btnModal browser-default" OnClick="btnInsertarConfirmar_Click1" />
        </div>
    </asp:Panel>


    <ajaxToolkit:ModalPopupExtender ID="ModalModificar" runat="server" PopupControlID="PanelModificar" CancelControlID="btnCerrarModificar" TargetControlID="fake" BackgroundCssClass="BackgroundModal"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PanelModificar" runat="server">
        <div class="ContenedorInsertar">
            <asp:LinkButton ID="btnCerrarModificar" CssClass="btnicon browser-default" runat="server" OnClick="btnCerrarModificar_Click"><i class="fa-solid fa-circle-arrow-left icnAtras"></i></asp:LinkButton>
            <div class="form__group field t">
                <input runat="server" class="form__field browser-default" type="text" name="name" id="tbxIdentificacion" placeholder=" Identificación" readonly="readonly" />
                <label for="Usuario" class="form__label">Identificación</label>
            </div>
            <div class="form__group field t">
                <input runat="server" class="form__field browser-default" type="text" name="name" id="tbxNombre" placeholder="Nombre" required="required" />
                <label for="Usuario" class="form__label">Nombre</label>
            </div>
            <div class="form__group field">
                <input type="Text" value="Tramitador" id="tbxPrimerApellido" class="form__field browser-default " runat="server" required="required"  />
                <label for="Usuario" class="form__label">1er Apellido</label>
            </div>
            <div class="form__group field">
                <input runat="server" class="form__field browser-default" type="text" name="name" id="tbxSegundoApellido" placeholder="1er Apellido" required="required" />
                <label for="Usuario" class="form__label">2do Apellido</label>
            </div>
            <div class="form__group field">
                <input runat="server" class="form__field browser-default" type="text" name="name" id="tbxMail" placeholder="2do Apellido" required="required" />
                <label for="Usuario" class="form__label">Correo Electrónico</label>
            </div>
            <div class="form__group field">
                <input runat="server" class="form__field browser-default" type="text" name="name" id="tbxTelefono" placeholder="Teléfono" required="required" />
                <label for="Usuario" class="form__label">Teléfono</label>
            </div>
            <asp:LinkButton ID="btnModificarConfirmar" Text="Modificar" runat="server" CssClass="btnModal browser-default" OnClick="btnModificarConfirmar_Click1" />
        </div>
    </asp:Panel>


</asp:Content>
