﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ClienteAutenticado.Master" AutoEventWireup="true" CodeBehind="FormularioAutenticado.aspx.cs" Inherits="BancoCK.pages.FormularioAutenticado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Contenedor">
        <div class="contenidoPrincipal">
            <div class="contenidoPrincipal_formulario">

               
                <h2 class="titulo">Información laboral</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Años laborando</label>
                        <input type="text" runat="server" id="txtAñosLaborando"  required="required" />
                        <label>Salario Neto</label>
                        <input type="text" runat="server" id="txtSalarioNeto"  required="required"  />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Salario bruto</label>
                        <input type="text" runat="server" id="txtSalarioBruto"  required="required"  />
                    </div>
                </div>
                <h2 class="titulo">Información del préstamo</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Monto</label>
                        <input type="text" runat="server" id="txtMonto"  required="required"  />
                        <label>Plazo en años</label>
                        <input type="range" class="browser-default rango"  min="1" max="30" runat="server" id="txtRangoAños"  required="required" />
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
                <div class="parrafo">
                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                    Similique repudiandae, consequatur vitae at eum expedita
                    fugiat odio voluptatibus incidunt harum tenetur ullam
                    tempore veritatis, repellendus reiciendis? Illum dolorum
                    tempore veritatis, repellendus reiciendis? Illum dolorum 
                    consequuntur, iure dolores atque reiciendis tempore delectus
                    consequuntur, iure dolores atque reiciendis tempore delectus
                </div>

                 <div class="parrafo">
                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                    Similique repudiandae, consequatur vitae at eum expedita
                    fugiat odio voluptatibus incidunt harum tenetur ullam
                    tempore veritatis, repellendus reiciendis? Illum dolorum
                    tempore veritatis, repellendus reiciendis? Illum dolorum
                    consequuntur, iure dolores atque reiciendis tempore delectus
                    consequuntur, iure dolores atque reiciendis tempore delectus
                </div>


                <h2 class="titulo2">Requisitos del préstamo</h2>
                <div class="parrafo">
                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                    Similique repudiandae, consequatur vitae at eum expedita
                    fugiat odio voluptatibus incidunt harum tenetur ullam
                    tempore veritatis, repellendus reiciendis? Illum dolorum
                    consequuntur, iure dolores atque reiciendis tempore delectus
                    consequuntur, iure dolores atque reiciendis tempore delectus
                    consequuntur, iure dolores atque reiciendis tempore delectus
                </div>

                 <div class="parrafo">
                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                    Similique repudiandae, consequatur vitae at eum expedita
                    fugiat odio voluptatibus incidunt harum tenetur ullam
                    tempore veritatis, repellendus reiciendis? Illum dolorum
                    consequuntur, iure dolores atque reiciendis tempore delectus
                    consequuntur, iure dolores atque reiciendis tempore delectus
                </div>


            </div>
        </div>

    </div>
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
</asp:Content>