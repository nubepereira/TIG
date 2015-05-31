<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Login.Login" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cs1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--<form id="form1" runat="server"> --%>  
    <div class="auto-style8" style="height:60px">
        <h2 class="auto-style21">
            <span class="auto-style32"><strong>Bienvenido</strong></span>
        </h2> 
        <h2  class="auto-style21">
             <span class="auto-style30"><strong class="auto-style33">Indique Contraseña y password para acceder</strong></span>         
        </h2>
    </div>
    
    <div style="height:21px; text-align:center; font-family:Verdana;font-size: 1.5em;">
        <asp:Label ID="falla" runat="server" Text="" CssClass="falla"></asp:Label>
        <asp:Label ID="Exito" runat="server" Text="" CssClass="Exito"></asp:Label>
    </div>
       <fieldset style="width:373px; height:190px; margin-left:15%; left: 250px; position: relative; top: 0px;">
        <legend class="auto-style37">Inicie sesion</legend>        
            <table style="margin:50px auto 0px auto; height: 160px; left: 2px; position: relative; top: -29px;" border="0" 
                cellspacing="5px" cellpadding="0" >
            <tr>
                <td rowspan="3" class="auto-style36">
                    <a><asp:Image ID="Diamante" runat="server" ImageUrl="~/Presentacion/Imagenes/FaviconRemoto.png" Width="125" style="top: -20px; position: relative" />
                    </a>
                    &nbsp;</td>
                <td class="auto-style35">
                    <strong>Usuario:</strong></td>
                <td>
                    <asp:TextBox ID="nombre" runat="server" Height="15px" Width="130px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style35">
                    <strong>Contraseña: </strong> </td>
                <td>
                    <input id="Clave" type="password" runat="server" style="width:130px; height:15px;"/></td>
            </tr>
            <tr>
                <td>   
                </td>
                <td>
                <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="onClickLoginButton" />
                </td>
            </tr>
            </table>          
        </fieldset> 
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
           <!-- No puede ser vacio el campo usuario -->
           <asp:RequiredFieldValidator ID="valUsuario" runat="server" Display="Dynamic" 
               ErrorMessage="El campo &lt;strong>Usuario</strong> es requerido. Verifique"
               ControlToValidate="nombre" CssClass="itemError"> &nbsp;  
           </asp:RequiredFieldValidator>
           <cs1:validatorcalloutextender ID="Val1" runat="server" TargetControlID="valUsuario"
               Width="200px" HighlightCssClass="highlight">
           </cs1:validatorcalloutextender>
        </div>--%>   
<%--</form>--%>
</asp:Content>