<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Trimestres.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Trimestre.Trimestres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:Label ID="LblFicha" runat="server" Text="" Enabled="false" Visible="false"></asp:Label>
    
    <table style="border: 1px solid #EEEEEE; left: 450px; position: relative; top: -160px;">
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" PostBackUrl="~/Presentacion/Vista/Trimestre/UnidadesPromedioTrimXBrickProducto.aspx" style="text-align: center" Height="28px" Width="29px" />
                <br />Promedio trimestre por Brick en el Producto
            </td>
            <td class="auto-style41"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" PostBackUrl="~/Presentacion/Vista/Trimestre/UnidadesPromedioTrimXBrickMercado.aspx" style="text-align: center" Height="28px" Width="29px" />
                <br />Promedio trimestre por Brick en el Mercado
            </td>
        </tr>
    </table>
</asp:Content>
