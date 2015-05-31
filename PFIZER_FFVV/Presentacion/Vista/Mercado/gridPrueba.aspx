<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="gridPrueba.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Mercado.gridPrueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            Años: 
            <asp:Label ID="LblAno" runat="server" Text="" Enabled="true" Visible="true"></asp:Label>
            <br />
            Periodos:
            <asp:Label ID="LblPeriodo" runat="server" Text="" Enabled="true" Visible="true"></asp:Label>
            <br />
            Linea:
            <asp:Label ID="LblLinea" runat="server" Text="" Enabled="true" Visible="true"></asp:Label>
            <br />
            Mercados:
            <asp:Label ID="LblMercado" runat="server" Text="" Enabled="true" Visible="true"></asp:Label>
            <br />
        </ItemTemplate>
     </asp:DataList>
    <asp:sqldatasource runat="server" ID="SqlDataSource1"></asp:sqldatasource>
</asp:Content>
