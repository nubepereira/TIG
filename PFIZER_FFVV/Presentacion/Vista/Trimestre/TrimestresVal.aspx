<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site3.Master" AutoEventWireup="true" CodeBehind="TrimestresVal.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Trimestre.TrimestresVal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:Label ID="LblFicha" runat="server" Text="" Enabled="false" Visible="false"></asp:Label>
    
    <table style="border: 1px solid #EEEEEE; left: 480px; position: relative; top: -200px;">
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" PostBackUrl="~/Presentacion/Vista/Trimestre/ValoresPromedioTrimXBrickProducto.aspx" style="text-align: center" Height="28px" Width="29px" />
                <br />Promedio trimestre por Brick en el Producto
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" PostBackUrl="~/Presentacion/Vista/Trimestre/ValoresPromedioTrimXBrickMercado.aspx" style="text-align: center" Height="28px" Width="29px" />
                <br />Promedio trimestre por Brick en el Mercado
            </td>
        </tr>
    </table>
    <br />
   &nbsp;
    <br />
</asp:Content>

