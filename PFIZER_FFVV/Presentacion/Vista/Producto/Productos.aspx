﻿<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Producto.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblFicha" runat="server" Text="" Enabled="false" Visible="false"></asp:Label>
    
    <table style="border: 1px solid #EEEEEE; left: 450px; position: relative; top: -160px;">
        <tr>
            <td class="auto-style21"> &nbsp;&nbsp;</td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" style="text-align: center" Height="28px" Width="29px" PostBackUrl="~/Presentacion/Vista/Producto/UnidadesPaisXProducto.aspx" />
                <br />Total Pais por Producto en el Mercado
            </td> 
        </tr>
    </table>
</asp:Content>    

