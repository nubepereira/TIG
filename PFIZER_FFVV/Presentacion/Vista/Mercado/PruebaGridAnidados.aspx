 <%@ Page Title="R.E.M.O.T.O" Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="PruebaGridAnidados.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Mercado.PruebaGridAnidados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<%--http://www.es-asp.net/tutoriales-asp-net/tutorial-61-96/enlazando-a-bases-de-datos.aspx--%>
<%--http://quickstarts.asp.net/QuickStartv20/util/srcview.aspx?path=~/aspnet/samples/data/GridViewMasterDetails.src--%>
<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">
  <fieldset style="width:auto; height:auto; margin-left:12%; margin-right: 11%; position: relative; top: 0px;" >
      <legend>Prueba</legend> 
    <table style="border: 2px solid #808080; left: 20px; position: relative; top: 20px;">
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
 <%--  <b>
    <br />
    Selecione Mercado:</b>
    <asp:DropDownList ID="DropDownList1" DataSourceID="SqlDataSource2" AutoPostBack="true"
      DataTextField="MERCADO" runat="server" />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="MarketShareTotalUnidMercado" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="mercado" SessionField="SesionUsuarioMercado" Type="String" />
                <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    <br />
    <br />--%>
    <table>
      <tr>
        <td valign="top">
          <asp:GridView ID="GridView1" AllowSorting="True" AllowPaging="True" runat="server"
            DataSourceID="SqlDataSource1" DataKeyNames="MERCADO"
            AutoGenerateColumns="False" Width="427px" style="left: 190px; position: relative; top: -90px; text-align: center;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="50">
              <AlternatingRowStyle BackColor="White" />
            <Columns>
              <asp:CommandField ShowSelectButton="True" />
              <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" />
              <asp:BoundField DataField="totalUnidMercado" HeaderText="Unidades" ReadOnly="True" SortExpression="totalUnidMercado" DataFormatString="{0:N0}" />
                <%--<asp:BoundField DataField="totalUnidMercado" HeaderText="total Unidades" SortExpression="totalUnidMercado" />--%>
            </Columns>
                  <FooterStyle BackColor="#ff9933" />
                  <HeaderStyle BackColor="#ff6600" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#ff9933" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle BackColor="#fda835" />
                  <SelectedRowStyle BackColor="#6495AB" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#FBFBF2" />
                  <SortedAscendingHeaderStyle BackColor="#848384" />
                  <SortedDescendingCellStyle BackColor="#EAEAD3" />
                  <SortedDescendingHeaderStyle BackColor="#575357" />
          </asp:GridView>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="MarketShareTotalUnidMercado" SelectCommandType="StoredProcedure" >
            <SelectParameters>
              <%--<asp:ControlParameter ControlID="DropDownList1" Name="mercado" PropertyName="SelectedValue"
                Type="String" />--%>
                <asp:SessionParameter Name="mercado" SessionField="SesionUsuarioMercado" Type="String" />
                <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
            </SelectParameters>
          </asp:SqlDataSource>
        </td>
          <td>
              <asp:GridView runat="server" DataKeyNames="MERCADO" AutoGenerateRows="False" DataSourceID="SqlDataSource3" 
                  HeaderText="Detalle Periodos" ID="GridView2" Width="275px" AutoGenerateColumns="False" AllowPaging="True" style="left: 210px; position: relative; top: -90px;  text-align: center;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="50">
                  <AlternatingRowStyle BackColor="White" />
                  <Columns>
                    <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" Visible="false" />
                    <asp:BoundField DataField="PRODUCTOS" HeaderText="Productos" ReadOnly="True" SortExpression="PRODUCTOS" />
                      <asp:BoundField DataField="PERIODOS" HeaderText="Periodos" ReadOnly="True" SortExpression="PERIODOS" />
                      <asp:BoundField DataField="MarketShare" HeaderText="% MS" ReadOnly="True" SortExpression="MarketShare" />
                <%--<asp:BoundField DataField="totalUnidMercado" HeaderText="total Unidades" SortExpression="totalUnidMercado" />--%>
            </Columns>
                  <FooterStyle BackColor="#ff9933" />
                  <HeaderStyle BackColor="#ff6600" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#ff9933" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle BackColor="#fda835" />
                  <SelectedRowStyle BackColor="#6495AB" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#FBFBF2" />
                  <SortedAscendingHeaderStyle BackColor="#848384" />
                  <SortedDescendingCellStyle BackColor="#EAEAD3" />
                  <SortedDescendingHeaderStyle BackColor="#575357" />
              </asp:GridView>
              <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="MarketShareUnidMercado" ID="SqlDataSource3" SelectCommandType="StoredProcedure">
                  <SelectParameters>
                      <asp:ControlParameter ControlID="GridView1" Name="mercado" PropertyName="SelectedValue" Type="String" />
                      <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
                  </SelectParameters>
              </asp:SqlDataSource>
          </td>
      </tr>
    </table>
    </fieldset>
    <br />
</asp:Content>

