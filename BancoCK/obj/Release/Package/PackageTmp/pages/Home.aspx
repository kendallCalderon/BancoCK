<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BancoCK.pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../sass/Home.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="Contenedor">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="flexible">
            <div class="container_item_imagen">
                <%--<img class="img-imagenFondo" src="../img/imagenFondo.jpg" />--%>
                <video class="vid" src="../img/homevideo.mp4" muted loop  autoplay  ></video>
                   
            </div>

            <div class="container_item_formulario">

                <h1 class="titulo">Banca en Linea</h1>

                <div class="form__group field">
                    <input runat="server" type="text" id="tbxUsuario" class=" browser-default form__field" placeholder="Usuario" name="Usuario" />
                    <label for="Usuario" class="form__label">Usuario</label>
                </div>

                <div class="form__group2 field">
                    <input runat="server" id="tbxPassword" type="password" class=" browser-default form__field2" placeholder="Usuario" name="Usuario" />
                    <label for="Contraseña" class="form__label2">Contraseña</label>
                </div>

                <%-- <input class=" browser-default formulario_input"   type="text" placeholder="Usuario" />
                <input class=" browser-default formulario_input"   type="password" placeholder="Contraseña" />
                <label for="name" class="form__label">Name</label>--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:button runat="server" Text="Ingresar" OnClick="btnIngresar_Click" ID="btnIngresar" class="btnIngresar"/>
                        <asp:Label ID="lblPass" CssClass="lblError"  Text="Usuario y/o Contraseña incorrecta" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                
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
                            <img class="img-cartas" src="../img/Negocio.jpg">
                        </div>
                        <div>
                            <span class="card-title">Apoyo negocio</span>
                        </div>
                        <div class="card-content">
                            <p class="parr_carta">
                                Préstamo comercial puedes obtener financiamiento para expandir tu negocio y refinanciar tus deudas. Además, te ofrecemos la alternativa de obtener financiamiento con garantía gubernamental. 
                            </p>
                        </div>
                    </div>
                </div>
            <div class="row">
                
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="../img/Personal.jpg">
                        </div>
                        <div>
                            <span class="card-title">Préstamo Personal</span>
                        </div>
                        <div class="card-content">
                            <p class="parr_carta">
                                Sus necesidades cambian a lo largo de su vida y por supuesto, sus sueños también.
                            Tenemos un crédito que se adapta a cada momento, con las mejores condiciones y pensado para usted.
                            </p>
                        </div>
                    </div>
                </div>
            
            <div class="row">
               
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="../img/Educacion.jpg">
                        </div>
                        <div>
                            <span class="card-title">Préstamo Educación</span>
                        </div>
                        <div class="card-content">
                            <p class="parr_carta">
                               Ofrecemos a todos los estudiantes que requieran financiamiento. Abarcando desde la compra de equipo, materiales, libros hasta la carrera universitaria completa. 
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
                            <img class="img-cartas" src="../img/Vivienda.jpg">
                        </div>
                        <div>
                            <span class="card-title">Préstamo Vivienda</span>
                        </div>
                        <div class="card-content">
                            <p class="parr_carta">
                                ¡Lo suyo es estrenar o remodelar su casa y lo nuestro es hacer realidad sus sueños!
                                Le tenemos las mejores condiciones y beneficios de lograr tus metas.
                            </p>
                        </div>
                    </div>
                
            </div>
            <div class="row">
               
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="../img/Deuda.jpg">
                        </div>
                        <div>
                            <span class="card-title">Refundir mis deudas</span>
                        </div>
                        <div class="card-content">
                            <p class="parr_carta">
                                ¿Sus deudas se salieron de control?
                              Gane paz y liquidez al unificar sus deudas con BancoCK cuota única.
                              Una sola cuota y ¡muy atractiva!
                              Con garantía hipotecaria.
                            </p>
                        </div>
                    </div>
                </div>
           
            <div class="row">
                
                    <div class="card">
                        <div class="card-image">
                            <img class="img-cartas" src="../img/car.jpg">
                        </div>
                        <div>
                            <span class="card-title">Préstamo Vehiculo</span>
                        </div>
                        <div class="card-content">
                            <p class="parr_carta">
                                ¡Nada como el olor a carro nuevo!
                           Elija el vehículo que se ajusta a sus necesidades y nosotros lo hacemos realidad.
                           Variedad de garantías: prendaria
                           (responde el mismo vehículo, estando asegurado).
                            </p>
                        </div>
                    </div>
                </div>
            
        </div>
       </div>
        </div>


</asp:Content>
