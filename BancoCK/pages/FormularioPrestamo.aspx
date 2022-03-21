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
                        <input type="text" />
                        <label>Primer Apellido</label>
                        <input type="text" />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Nombre</label>
                        <input type="text" />
                        <label>Segundo Apellido</label>
                        <input type="text" />
                    </div>
                </div>
                <h2 class="titulo">Información de contácto</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Número Teléfonico</label>
                        <input type="text" />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Correo electrónico</label>
                        <input type="text" />
                    </div>  
                </div>
                <h2 class="titulo">Información laboral</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Años laborando</label>
                        <input type="text" />
                        <label>Salario Neto</label>
                        <input type="text" />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Salario bruto</label>
                        <input type="text" />
                    </div>
                </div>
                <h2 class="titulo">Información del préstamo</h2>
                <div class="contenidoPrincipal_formulario_Acomodo">
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Monto</label>
                        <input type="text" />
                        <label>Plazo en años</label>
                        <input type="range" class="browser-default rango" id="test5" min="1" max="30" />
                    </div>
                    <div class="contenidoPrincipal_formulario_elementoDoble">
                        <label>Moneda</label>
                        <div class="select is-danger">
                            <select>
                                <option>Colones</option>
                                <option>Dolares</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="contenidoPrincipal_formulario_Acomodo_Botones">
                    <button class="btn1">Atrás</button>
                    <button class="btn2">Tramitar</button>
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
</asp:Content>
