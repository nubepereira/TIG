<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site2.Master" AutoEventWireup="true" CodeBehind="Modulos.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Seleccion.Modulos" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

 <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /> 
<%--<form id="form1" runat="server">--%>
<fieldset style="width:400px; height:auto; margin-left:27%; left: 18px; position: relative; top: 0px;">
<legend>Opciones a Seleccionar</legend>  
   <table style="border: 2px solid #FFFFFF; left: 70px; position: relative" >
       <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
        <tr>
            <td> &nbsp;&nbsp; </td>
            <td>
                <asp:Button ID="Unidades" runat="server" Text="S.I.V. Unidades"  Width="234px" OnClick="Unidades_Click" Visible="true" />
            </td>
            <td>&nbsp;</td>
        </tr>
       <tr>
           <td> &nbsp;&nbsp; </td>
            <td>
                <asp:Button ID="Valores" runat="server" Text="S.I.V. Valores"  Width="234px" OnClick="Valores_Click" Visible="true" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td> &nbsp;&nbsp; </td>
            <td>
                <asp:Button ID="Simuladores" runat="server" Text="Simuladores"  Width="234px" OnClick="Simuladores_Click" Visible="true" />
            </td>
            <td>&nbsp;</td>
        </tr>      
       <tr>
            <td> &nbsp;&nbsp; </td>
            <td>
                <asp:Button ID="LE" runat="server" Text="Estructura Organizacional" Width="234px" OnClick="LE_Click" Visible="false" />
                </td>
            <td>&nbsp;</td>
        </tr> 
   </table> 
    <br />
</fieldset>
<%--    </form>--%>
</asp:Content>