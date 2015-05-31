<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site3.Master" AutoEventWireup="true" CodeBehind="BricksVal.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Brick.BricksVal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Label ID="LblFicha" runat="server" Text="" Enabled="false" Visible="false"></asp:Label>
    
        <table style="border: 1px solid #EEEEEE; left: 450px; position: relative; top: -160px;">
        <tr>

            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Brick/ValoresEnElMercadoXProducto.aspx" />
                <br /> Valores en el Mercado X Producto
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Brick/ValoresEnElMercado.aspx" />
                <br /> Valores en el Mercado
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Brick/ValoresIEXBrickMercado.aspx" />
                <br />I. E. Producto x Brick en el Mercado
            </td>
        </tr>
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Brick/ValoresMSXBrickMercado.aspx" />
                <br />% MS por Brick en el Mercado
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Brick/ValoresMSXTrimBrickMercadoProducto.aspx"/>
                <br />% MS Trimestres por Brick en el Mercado
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Brick/ValoresCrecimientoXBrickMercadoProducto.aspx" />
                <br />Crecimiento por Brick en el Mercado
            </td>
        </tr>
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Brick/ValoresXBrickEnElMercadoXProducto.aspx" />
                <br />% Producto por Brick en el Mercado
            </td>
        </tr>
    </table>
</asp:Content>
