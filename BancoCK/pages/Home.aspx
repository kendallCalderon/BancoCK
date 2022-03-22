<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BancoCK.pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/sass/Home.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="Contenedor">

        <div class="flexible">
            <div class="container_item_imagen">
                <%--<img class="img-imagenFondo" src="/img/imagenFondo.jpg" />--%>
                <video class="vid" src="/img/homevideo.mp4" muted loop  autoplay  ></video>
                   
            </div>

            <div class="container_item_formulario">

                <h1 class="titulo">Banca en Linea</h1>

                <div class="form__group field">
                    <input type="text" class=" browser-default form__field" placeholder="Usuario" name="Usuario" />
                    <label for="Usuario" class="form__label">Usuario</label>
                </div>

                <div class="form__group2 field">
                    <input type="password" class=" browser-default form__field2" placeholder="Usuario" name="Usuario" />
                    <label for="Contraseña" class="form__label2">Contraseña</label>
                </div>

                <%-- <input class=" browser-default formulario_input"   type="text" placeholder="Usuario" />
                <input class=" browser-default formulario_input"   type="password" placeholder="Contraseña" />
                <label for="name" class="form__label">Name</label>--%>

                <button class="btnIngresar">Ingresar</button>
                <hr class="uk-divider-small">
                <p class="parrafo">¿Primera vez que ingresa?</p>
                <asp:Button runat="server" id="btnRgistrarse" OnClick="btnRgistrarse_Click" class="btnRegistrarse" Text="Registrarse"/>

            </div>
        </div>

        <div class="publicidad">
            <div class="publicidad__elemento1">
                <div class="anuncio1">
                    <i class="fas fa-hand-holding-usd fa-5x"></i>

                    <p>
                        Ponemos a tu disposicion 
                   diferentes tipos de ahorros 
                     para cumplir tus metas
                    </p>
                </div>
            </div>


            <div class="publicidad__elemento1">
                <div class="anuncio1">
                    <i class="fas fa-money-check fa-5x"></i>
                    <p>
                        Promovemos acciones para el 
                         beneficio de nuestros clientes
                    </p>
                </div>
            </div>

            <div class="publicidad__elemento1">
                <div class="anuncio1">
                    <i class="fa-solid fa-vault fa-5x"></i>
                    <p>
                        Apoyamos las personas 
                           emprendedoras
                    </p>
                </div>
            </div>
        </div>


        <div class="Contenedor_cards">
        <div class="flexible2">
            <div class="row">
                
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="/img/Negocio.jpg">
                        </div>
                        <div>
                            <span class="card-title">Apoyo negocio</span>
                        </div>
                        <div class="card-content">
                            <p>
                                Cumple tu sueño de
                                    emprender un nuevo negocio
                            </p>
                        </div>
                    </div>
                </div>
            <div class="row">
                
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="/img/Personal.jpg">
                        </div>
                        <div>
                            <span class="card-title">Préstamo Personal</span>
                        </div>
                        <div class="card-content">
                            <p>
                                Consigue tu prestamo
                                 para tus metas personales
                            </p>
                        </div>
                    </div>
                </div>
            
            <div class="row">
               
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="/img/Educacion.jpg">
                        </div>
                        <div>
                            <span class="card-title">Préstamo Educación</span>
                        </div>
                        <div class="card-content">
                            <p>
                                Te préstamos para 
                                  tu educación
                            </p>
                        </div>
                    </div>
               
            </div>
        </div>
        <div class="flexible3">
            <!-- rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr!-->
            <div class="row">
               
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="/img/Vivienda.jpg">
                        </div>
                        <div>
                            <span class="card-title">Préstamo Vivienda</span>
                        </div>
                        <div class="card-content">
                            <p>
                                Cumple tu sueño de
                                    casa propia
                            </p>
                        </div>
                    </div>
                
            </div>
            <div class="row">
               
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="/img/Deuda.jpg">
                        </div>
                        <div>
                            <span class="card-title">Refundir mis deudas</span>
                        </div>
                        <div class="card-content">
                            <p>
                                Cancele sus deudas,
                                    nosotros te prestamos
                            </p>
                        </div>
                    </div>
                </div>
           
            <div class="row">
                
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="/img/car.jpg">
                        </div>
                        <div>
                            <span class="card-title">Préstamo Vehiculo</span>
                        </div>
                        <div class="card-content">
                            <p>
                                Consigue tu auto propio
                                     con nosotros
                            </p>
                        </div>
                    </div>
                </div>
            
        </div>
       </div>
        </div>


</asp:Content>
