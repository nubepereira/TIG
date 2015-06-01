<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="UnidadesVendidasTotalPaisMercado.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Mercado.UnidadesVendidasTotalPaisMercado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
    <table>
        <tr>
            <td class="auto-style45" style="margin-left:15%; left: 150px; position: relative; top: 0px;">
                <asp:Button ID="Email" runat="server" Text="Enviar por Email" OnClick="Email_Click" style="text-align: center" />
            </td>
        </tr>
    </table>
    <fieldset style="width:373px; height:auto; margin-left:15%; left: 200px; position: relative; top: -330px;" >        
    <legend>Mercados/ Unid Vendidas Total Pais</legend> 
     <table>
      <tr>
        <td valign="top">
          <asp:GridView ID="GridView1" AllowSorting="True" AllowPaging="True" runat="server"
            DataSourceID="SqlDataSource1" DataKeyNames="MERCADO"
            AutoGenerateColumns="False" Width="427px" style="left: 0px; position: relative; top: 0px; 
            text-align: center;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
              CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="100">
              <AlternatingRowStyle BackColor="White" />
            <Columns>
              <asp:CommandField ShowSelectButton="True" />
              <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" />
              <asp:BoundField DataField="TOTAL_UNID" HeaderText="Total Unid." ReadOnly="True" SortExpression="TOTAL_UNID" 
              DataFormatString="{0:N0}" />
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
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="UnidadesMercadoVendidasPaisTotal" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:SessionParameter Name="mercado" SessionField="SesionUsuarioMercado" Type="String" />
                <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
            </SelectParameters>
          </asp:SqlDataSource>
        </td>
          <td valign="top">
              <asp:GridView ID="GridView2" runat="server" DataKeyNames="MERCADO" AutoGenerateRows="False" 
                  DataSourceID="SqlDataSource3" HeaderText="Detalle Periodos" Width="275px" AutoGenerateColumns="False" 
                  AllowPaging="True" style="left: 0px; position: relative; top: 0px;  text-align: center;" 
                  BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                  ForeColor="Black" GridLines="Vertical" PageSize="100">
                  <AlternatingRowStyle BackColor="White" />
                  <Columns>
                    <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" Visible="false" />
                      <asp:BoundField DataField="PERIODOS" HeaderText="Periodos" ReadOnly="True" SortExpression="PERIODOS" />
                      <asp:BoundField DataField="UNIDADES" HeaderText="Unidades" ReadOnly="True" SortExpression="UNIDADES" DataFormatString="{0:N0}" />
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
              <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="UnidadesMercadoVendidasPaisPeriodo" ID="SqlDataSource3" SelectCommandType="StoredProcedure">
                  <SelectParameters>
                      <asp:ControlParameter ControlID="GridView1" Name="mercado" PropertyName="SelectedValue" Type="String" />
                      <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
                  </SelectParameters>
              </asp:SqlDataSource>
          </td>
      </tr>
    </table>
    </fieldset>
</asp:Panel>
    <br />
</asp:Content>
