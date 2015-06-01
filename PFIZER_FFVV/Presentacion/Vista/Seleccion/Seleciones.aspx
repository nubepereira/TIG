<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site2.Master" AutoEventWireup="true" CodeBehind="Seleciones.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Seleccion.Seleciones" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

  <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>   

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /> 

<fieldset style="width:733px; height:auto; margin-left:18%; left: 22px; position: relative; top: 0px;">
<legend>Opciones a Seleccionar</legend>  


   <table style="border: 2px solid #FFFFFF; left: 100px; position: relative">

        <tr>
            
            <td><asp:Label ID="etiquetaLinea" runat="server" Text="Linea:" ForeColor="#ff9933" Visible="true" Enabled="true" style="font-weight: 700"></asp:Label></td>
                <td></td><td rowspan="4" class="auto-style40"> &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td><asp:DropDownList ID="ddlLinea" runat="server" DataTextField="NombreLinea" DataValueField="LineaPersona" Height="16px" Width="194px" Visible="true" Enabled="true" OnSelectedIndexChanged="ddlLinea_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Text="Seleccione" Value="0" />
                    </asp:DropDownList>  
                </td>
            
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td><asp:label id="etiquetaAno" runat="server" Text="Año:" ForeColor="#ff9933" Visible="true" style="font-weight: 700"></asp:label> </td>
            <td>
                <div><asp:ListBox ID="lbAnos" runat="server" DataTextField="Ano" DataValueField="Ano" OnSelectedIndexChanged="lbAnos_SelectedIndexChanged" AutoPostBack="true" Width="100px" SelectionMode="Multiple" Visible="true">
                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                    </asp:ListBox>
                <br /></div>
            </td>    
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>                                      
            <td><asp:Label ID="etiquetaMercado" runat="server" Text="Mercado:" ForeColor="#ff9933" Visible="false" Enabled="false" style="font-weight: 700"></asp:Label>&nbsp; </td>
            <td>&nbsp;</td>
            <td>
                <asp:ListBox ID="lbMercados" runat="server" DataTextField="MERCADO" DataValueField="MERCADO" AppendDataBoundItems="true" Width="200" SelectionMode="Multiple" Visible="false" Enabled="false" OnSelectedIndexChanged="lbMercados_SelectedIndexChanged">
                <asp:ListItem Text="Seleccione" Value="0" />
                </asp:ListBox>
            </td>   
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td><asp:Label ID="etiquetaPeriodo" runat="server" Text="Periodo" ForeColor="#ff9933" Visible="false" style="font-weight: 700"></asp:Label></td>
            <td>
                <div>
                    <br />                    
                    <asp:ListBox ID="lbPeriodos" runat="server" DataTextField="PERIODOS" DataValueField="PERIODOS" Width="100px" SelectionMode="Multiple" Visible="false" Enabled="false" AppendDataBoundItems="True" OnSelectedIndexChanged="lbPeriodos_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione</asp:ListItem>
                    </asp:ListBox>   
                    <br />
                <br /></div>
            </td>              
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td> 
        </tr>
       <tr>
           <td colspan="4">
                <asp:Label ID="labelPeriodo" runat="server" Text="Seleccione Linea y Año, luego espere la carga de Información..." ForeColor="Red" Visible="false"></asp:Label>
            </td>
           <td></td> 
           <td></td> 
       </tr>
        <tr>
            <td></td>
            <td></td> 
            <td>
                <asp:Button ID="ButtonConsultar" runat="server" Text="Consultar" Width="90px" OnClick="ButtonConsultar_Click" Visible="false" />
            </td>              
            <td></td> 
            <td></td> 
            <td></td>          
        </tr>  
   </table> 
    <br />
</fieldset>
<%--    </form>--%>
</asp:Content>