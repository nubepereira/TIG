<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="PruebaUnidadesMarketShare.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Mercado.UnidadesMarketShare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border: 2px solid #808080; left: 150px; position: relative">
        <tr>
            <td style="border: 1px solid #EEEEEE">Años:</td>
            <td style="border: 1px solid #EEEEEE"><asp:Label ID="LblAno" runat="server" Text="" Enabled="true" Visible="true"></asp:Label></td>
        </tr>
        <tr>
            <td style="border: 1px solid #EEEEEE">Periodos:</td>
            <td style="border: 1px solid #EEEEEE"><asp:Label ID="LblPeriodo" runat="server" Text="" Enabled="true" Visible="true"></asp:Label></td>
        </tr>
        <tr>
            <td style="border: 1px solid #EEEEEE">Linea:</td>
            <td style="border: 1px solid #EEEEEE"><asp:Label ID="LblLinea" runat="server" Text="" Enabled="true" Visible="true"></asp:Label></td>
        </tr>
        <tr>
            <td style="border: 1px solid #EEEEEE">Mercados:</td>
            <td style="border: 1px solid #EEEEEE"><asp:Label ID="LblMercado" runat="server" Text="" Enabled="true" Visible="true"></asp:Label></td>
        </tr>
    </table>
    <table style="left: 300px; position: relative; top: -105px;">
    <tr>
        <td>
        </td>
        <td></td>
        <td rowspan="3">
    <asp:GridView ID="GridViewTotalMercado" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceTotalMercado" style="left: -1px; position: relative; text-align: center; top: 0px; width: 184px;" AllowPaging="True" PageSize="5">
        <Columns>
            <asp:HyperLinkField DataTextField="MERCADO" HeaderText="Mercado" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" DataNavigateUrlFields="MERCADO" DataNavigateUrlFormatString="~/Presentacion/Vista/Mercado/DetalleUnidadesMarketShare.aspx?mercado={0}"/>
            <asp:BoundField DataField="totalUnidMercado" HeaderText="% MS en el Periodo Seleccionado" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" DataFormatString="{0:N0}" />                        
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceTotalMercado" runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="MarketShareTotalUnidMercado" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="mercado" SessionField="SesionUsuarioMercado" Type="String" />
            <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
    </table>
    <br />
</asp:Content>
