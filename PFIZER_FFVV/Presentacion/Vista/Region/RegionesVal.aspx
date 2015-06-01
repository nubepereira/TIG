<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site3.Master" AutoEventWireup="true" CodeBehind="RegionesVal.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Region.RegionesVal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblFicha" runat="server" Text="" Enabled="false" Visible="false"></asp:Label>
    
    <table style="border: 1px solid #EEEEEE; left: 500px; position: relative; top: -200px;">
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Region/ValoresRegionMercado.aspx" />
                <br />Valores Mercado por Region
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Region/ValoresRegionProductoXMercado.aspx" />
                <br /> Valores Producto X Mercado por Region
            </td>
        </tr>
    </table>
</asp:Content>
