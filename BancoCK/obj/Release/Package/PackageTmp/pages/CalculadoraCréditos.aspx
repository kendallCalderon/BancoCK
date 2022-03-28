<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="CalculadoraCréditos.aspx.cs" Inherits="BancoCK.Formulario_web14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/Calculadora.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Contenedor">
        <div class="contenedorFlexible">
            <div class="contenedorFlexible_contenido_formulario">
                <div class="contenedorFlexible_contenido_subcontenido">
                    <h3>Moneda</h3>
                    <div class="contenedorFlexible_contenido_subcontenido_row">
                        <button class="btnDolares">Dolares</button>
                        <button class="btnColones">Colones</button>
                    </div>
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                    <label>Monto a solicitar</label>
                    <input type="text" />
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                    <label>Plazo en años</label>
                    <input type="range" class="rango" id="test5" min="1" max="30" />
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                    <label>Tasa %</label>
                    <input type="text" />
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                    <label>Monto mensual</label>
                    <input type="text" />
                </div>
                <div class="contenedorFlexible_contenido_subcontenido_row">
                    <button class="btnAtras">Atras</button>
                    <button class="btnTramitador">Tramitador</button>
                </div>

            </div>
            <div class="contenedorFlexible_contenido_imagen">
                  <div class="contenedorFlexible_contenido_subcontenido margen">
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
                </div>
                <div class="contenedorFlexible_contenido_subcontenido">
                     <img class="img-imagenFondo" src="/img/bank.gif"></img>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
