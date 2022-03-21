<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="BancoCK.pages.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

        <link href="/css/ClienteMaster.css" rel="stylesheet" />
    <link href="/sass/Registro.css" rel="stylesheet" />
    
    
     <script src="https://kit.fontawesome.com/be9c2ad52f.js" crossorigin="anonymous"></script>
 
  
</head>
<body>


      <img class="logo" src="/img/log.gif"  />
   
    <video class="vid" src="/img/regis.mp4" autoplay="autoplay" muted="muted" loop="loop"></video>
       
   
    
    

        <form class="contenedor_form" id="form1" runat="server">

         <div class="formulario">
             <h1>Registro Cliente</h1>
             <div class="formulario-cajas">
                 <div class="form__group field">
             <asp:DropDownList ID="ddlTipoCedula"  CssClass="ddlid" runat="server"></asp:DropDownList>
                     </div>
             <div class="form__group field">
             <input class="form__field" type="text" name="name" value="" placeholder=" Identificación" />
                 <label for="Usuario" class="form__label">Identificación</label>
                 </div>
                 <div class="form__group field">
             <input class="form__field" type="text" name="name" value="" placeholder="Nombre" />
                     <label for="Usuario" class="form__label">Nombre</label>
                     </div>
                     <div class="form__group field">
             <input class="form__field" type="text" name="name" value="" placeholder="1er Apellido"  />
                         <label for="Usuario" class="form__label">1er Apellido</label>
                         </div>
                     <div class="form__group field">
             <input class="form__field" type="text" name="name" value="" placeholder="2do Apellido"  />
                         <label for="Usuario" class="form__label">2do Apellido</label>
                         </div>
                      <div class="form__group field">
             <input class="form__field" type="password" name="name" value="" placeholder="Contraseña"  />
                         <label for="Usuario" class="form__label">Contraseña</label>
                         </div>
                 </div>
             <h1>Información de contacto</h1>
             <div class="formulario-cajas">
                     <div class="form__group field">
             <input class="form__field" type="email" name="name" value="" placeholder="Correo electrónico"  />
                         <label for="Usuario" class="form__label">Correo electrónico</label>
                         </div>
                     <div class="form__group field">
             <input class="form__field" type="tel" name="name" value="" placeholder="Número telefónico"  />
                         <label for="Usuario" class="form__label">Número telefónico</label>
                         </div>
                 </div>
             <h1>Información laboral</h1>
             <div class="formulario-cajas">
                     <div class="form__group field">
             <input class="form__field" type="number" name="name" value="" placeholder="Años laborando"  />
                         <label for="Usuario" class="form__label">Años laborando</label>
                         </div>
                     <div class="form__group field">
             <input class="form__field" type="text" name="name" value="" placeholder="Salario bruto"  />
                         <label for="Usuario" class="form__label">Salario bruto</label>
                         </div>
                     <div class="form__group field">
             <input class="form__field" type="text" name="name" value="" placeholder="Salario neto"  />
                         <label for="Usuario" class="form__label">Salario neto</label>
                         </div>
                   </div>
                     
         </div>





       






    </form>
</body>
</html>
