<%@ Page Title="R.E.M.O.T.O." Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentacion/MasterPage/Site3.Master" CodeBehind="ValoresEnElMercado.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Brick.ValoresEnElMercado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">
 <asp:Panel ID="Panel1" runat="server">
    <table>
        <tr>
            <td class="auto-style45" style="margin-left:15%; left: 150px; position: relative; top: 0px;">
                <asp:Button ID="Email" runat="server" Text="Enviar por Email" OnClick="Email_Click" style="text-align: center" />
            </td>
        </tr>
    </table>

<fieldset style="width:750px; height:auto; margin-left:15%; left: 200px; position: relative; top: -330px;">
      <legend>Brick/ Valores Mercado</legend> 

    <table style="top: 0px; position:relative; left: 10px;">
      <tr>
        <td valign="top">
          <asp:GridView ID="GridView1" AllowSorting="True" AllowPaging="True" runat="server"
            DataSourceID="SqlDataSource1" DataKeyNames="MERCADO"
            AutoGenerateColumns="False" Width="257px" style="left: 0px; position: relative; top: 0px; text-align: center;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="100">
              <AlternatingRowStyle BackColor="White" />
            <Columns>
              <asp:CommandField ShowSelectButton="True" />
              <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" />
              <asp:BoundField DataField="TOTAL" HeaderText="Total " ReadOnly="True" SortExpression="TOTAL" DataFormatString="{0:N0}" />
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
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="ValoresBrickEnElMercadoTotal" SelectCommandType="StoredProcedure" >
            <SelectParameters>
                <asp:SessionParameter Name="mercado" SessionField="SesionUsuarioMercado" Type="String" />
                <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
            </SelectParameters>
          </asp:SqlDataSource>
        </td>

        <td>
              <asp:GridView runat="server" DataKeyNames="MERCADO" AutoGenerateRows="False" DataSourceID="SqlDataSource3" 
                  HeaderText="Detalle Mercado" ID="GridView2" Width="470px" AutoGenerateColumns="False" AllowPaging="True" style="left: 0px; position: relative; top: 0px;  text-align: center;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="100">
                  <AlternatingRowStyle BackColor="White" />
                  <Columns>
                      <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" Visible="false" />
                      <asp:BoundField DataField="BRICK" HeaderText="Brick" ReadOnly="True" SortExpression="BRICK" />
                      <asp:BoundField DataField="PERIODO" HeaderText="Periodo" ReadOnly="True" SortExpression="PERIODO" />                      
                      <asp:BoundField DataField="TOTAL" HeaderText="Valores Brick X Mercado" ReadOnly="True" SortExpression="TOTAL" DataFormatString="{0:N0}" />
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
              <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="ValoresBrickEnElMercadoPeriodo" ID="SqlDataSource3" SelectCommandType="StoredProcedure">
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

