<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site3.Master" AutoEventWireup="true" CodeBehind="CompetidoresVal.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Competidor.CompetidoresVal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblFicha" runat="server" Text="" Enabled="false" Visible="false"></asp:Label>
    
    
    <table style="border: 1px solid #EEEEEE; left: 450px; position: relative; top: -230px;">
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Competidor/ValoresCompetidorTerritorioClaseXMercado.aspx"  />
                <br />Valores Territorio Clase</td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Competidor/ValoresCompetidoresRegionClaseXMercado.aspx" />
                <br />Valores por Región Clase</td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Competidor/ValoresCompetidoresBrickClaseXMercado.aspx" />
                <br />Valores por Brick Clase </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Competidor/ValoresCompetidorResumenXProductoXMercado.aspx" />
                <br />Resumen por Productos en el Mercado</td>
        </tr>
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Competidor/ValoresCompetidorMSxTerritorioClaseXMercado.aspx" />
                <br />% MS Territorio Clase</td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Competidor/ValoresCompetidorCrecimientoTerritorioClaseXMercado.aspx" />
                <br />Crecimiento Territorio Clase</td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Competidor/ValoresCompetidorIExTerritorioClaseXMercado.aspx" />
                <br />I.E. Territorio Clase</td>
        </tr>
    </table>
       <br />
      &nbsp;
    <br />
</asp:Content>