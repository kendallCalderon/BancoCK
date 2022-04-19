<%@ Page Title="" Language="C#" MasterPageFile="~/ClienteAutenticado.Master" AutoEventWireup="true" CodeBehind="FormularioAutenticado.aspx.cs" Inherits="BancoCK.pages.FormularioAutenticado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/FormularioAutenticado.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="Contenedor">
        <div class="contenidoPrincipal">
            <div class="contenidoPrincipal_formulario">


                <h2 class="titulo">Información laboral</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Años laborando</label>
                        <input type="text" runat="server" id="txtAñosLaborando" required="required" />
                        <label>Salario Neto</label>
                        <input type="text" runat="server" id="txtSalarioNeto" required="required" />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Salario bruto</label>
                        <input type="text" runat="server" id="txtSalarioBruto" required="required" />
                    </div>
                </div>
                <h2 class="titulo">Información del préstamo</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Monto</label>
                        <input type="text" runat="server" id="txtMonto" required="required" />
                        <label>Plazo en años</label>
                        <input type="number" class="browser-default rango" runat="server" id="txtRangoAños" required="required" />
                        

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
                    <asp:Button class="btn1" Text="Atras" runat="server" UseSubmitBehavior="false" ID="btnAtras" OnClick="btnAtras_Click1"  />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    <asp:Button class="btn2" Text="Tramitar" ID="btnTramitar"  OnClick="Unnamed_Click" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
    
</asp:Content>
