<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Representantes.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Representante.Representantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblFicha" runat="server" Text="" Enabled="false" Visible="false"></asp:Label>
    
    <table style="border: 1px solid #EEEEEE; left: 450px; position: relative; top: -230px;">
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" />
                <br /> % Ventas Unid. por Rep en el Mercado
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" />
                <br /> Unid. por Rep en el Mercado
            </td> 
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" />
                <br />Resumen de Indicadores
            </td>
        </tr>
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" />
                <br />% MS por Rep en el Mercado
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" />
                <br />Crecimeinto por Rep en el Mercado
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" />
                <br />I.E. por Rep en el Mercado
            </td>         
        </tr>
    </table>
</asp:Content>
