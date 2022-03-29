<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="FormularioPrestamo.aspx.cs" Inherits="BancoCK.pages.FormularioPrestamo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/formularioPréstamo.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Contenedor">
        <div class="contenidoPrincipal">
            <div class="contenidoPrincipal_formulario">

                <h2 class="titulo">Información Personal</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Identificación</label>
                        <input type="text" maxlength="15" runat="server" id="txtIdentificacion"/>
                        <label>Primer Apellido</label>
                        <input type="text" runat="server" id="txtApellido1"/>
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Nombre</label>
                        <input type="text" runat="server" id="txtNombre" />
                        <label>Segundo Apellido</label>
                        <input type="text" runat="server" id="txtApellido2" />
                    </div>
                </div>
                <h2 class="titulo">Información de contácto</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Número Teléfonico</label>
                        <input type="text" runat="server" id="txtTelefono" />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Correo electrónico</label>
                        <input type="text" runat="server" id="txtCorreo" />
                    </div>  
                </div>
                <h2 class="titulo">Información laboral</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Años laborando</label>
                        <input type="text" runat="server" id="txtAñosLaborando" />
                        <label>Salario Neto</label>
                        <input type="text" runat="server" id="txtSalarioNeto" />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Salario bruto</label>
                        <input type="text" runat="server" id="txtSalarioBruto" />
                    </div>
                </div>
                <h2 class="titulo">Información del préstamo</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Monto</label>
                        <input type="text" runat="server" id="txtMonto" />
                        <label>Plazo en años</label>
                        <input type="range" class="browser-default rango"  min="1" max="30" runat="server" id="txtRangoAños" />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Moneda</label>
                        <div class="select is-danger">
                            <select runat="server" id="txtCombo">
                                <option>Colones</option>
                                <option>Dolares</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="contenidoPrincipal_formulario_Acomodo_Botones">
                    <asp:Button class="btn1" Text="Atras" runat="server" ID="btnTramitar" OnClick="btnTramitar_Click"/>
                    <asp:Button class="btn2" Text="Tramitar" runat="server" ID="btnAtras" OnClick="btnAtras_Click"/>
                </div>


            </div>

            <div class="Descripciones">
                <h2 class="titulo2">Información del préstamo</h2>
                <div class="parrafo" id="contenido1" runat="server">

                </div>


                <h2 class="titulo2">Requisitos del préstamo</h2>
                <div class="parrafo" id="contenido3" runat="server">

                </div>


            </div>
        </div>

    </div>
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
</asp:Content>
