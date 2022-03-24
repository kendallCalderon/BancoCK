<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="BancoCK.pages.Registro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
             <h1>Registro Usuario</h1>
             <div class="formulario-cajas">
                 <div class="form__group field">
             <asp:DropDownList ID="ddlTipoCedula"  CssClass="ddlid" runat="server"></asp:DropDownList>
                     </div>
             <div class="form__group field">
             <input runat="server" class="form__field" type="text" name="name" id="Identificacion" placeholder=" Identificación" required="required" />
                 <label for="Usuario" class="form__label">Identificación</label>
                 </div>
                 <div class="form__group field">
             <input runat="server" class="form__field" type="text" name="name" id="Nombre" placeholder="Nombre" required="required" />
                     <label for="Usuario" class="form__label">Nombre</label>
                     </div>
                     <div class="form__group field">
             <input runat="server" class="form__field" type="text" name="name" id="PrimerApellido" placeholder="1er Apellido" required="required" />
                         <label for="Usuario" class="form__label">1er Apellido</label>
                         </div>
                     <div class="form__group field">
             <input runat="server" class="form__field" type="text" name="name" id="SegundoApellido" placeholder="2do Apellido" required="required" />
                         <label for="Usuario" class="form__label">2do Apellido</label>
                         </div>
                      <div class="form__group field">
             <input runat="server" class="form__field" type="password" name="name" id="Contraseña" placeholder="Contraseña" required="required" />
                         <label for="Usuario" class="form__label">Contraseña</label>
                         </div>
                 </div>
             <h1>Información de contacto</h1>
             <div class="formulario-cajas">
                     <div class="form__group field">
             <input runat="server" class="form__field" type="email" name="name" id="Correo" placeholder="Correo electrónico" required="required" />
                         <label for="Usuario" class="form__label">Correo electrónico</label>
                         </div>
                     <div class="form__group field">
             <input runat="server" class="form__field" type="tel" name="name" id="Telefono" placeholder="Número telefónico" required="required" />
                         <label for="Usuario" class="form__label">Número telefónico</label>
                         </div>
                 </div>
             <h1>Información laboral</h1>
             <div class="formulario-cajas">
                     <div class="form__group field">
             <input runat="server" class="form__field" type="number" name="name" id="Añoslaborando" placeholder="Años laborando (Opcional)"  />
                         <label for="Usuario" class="form__label">Años laboro (Opcional)</label>
                         </div>
                     <div class="form__group field">
             <input runat="server" class="form__field" type="text" name="name" id="Salariobruto" placeholder="Salario bruto (Opcional)"  />
                         <label for="Usuario" class="form__label">Salario bruto (Opcional)</label>
                         </div>
                     <div class="form__group field">
             <input runat="server" class="form__field" type="text" name="name" id="Salarioneto" placeholder="Salario neto (Opcional)"  />
                         <label for="Usuario" class="form__label">Salario neto (Opcional)</label>
                         </div>
                   </div>
             <asp:Button CssClass="btnConfirmar" OnClick="btnConfirmar_Click" Text="Confirmar" runat="server" />
                     
         </div>
          
            
          




     
     <asp:LinkButton ID="fake" runat="server" Enabled="false"></asp:LinkButton>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
       
            <ajaxtoolkit:modalpopupextender ID="ModalExito" runat="server" PopupControlID="ContenedorModal" TargetControlID="fake" BackgroundCssClass="BackgroundModal"></ajaxtoolkit:modalpopupextender>

            <div runat="server" id="ContenedorModal">
                <i class="fa-solid fa-circle-check fa-3x icono"></i>
                <label class="lblRegistro">Se ha registrado con éxito</label>
                <asp:Button Text="OK" runat="server" ID="btnOk" OnClick="btnOk_Click" />

            </div>

    </form>
</body>
</html>
