<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="UnidadesMSMercado.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Mercado.UnidadesMSMercado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%--<form id="form1" runat="server">  --%> 
    <asp:Label ID="Label1" runat="server" style="color: #FF6600" Text="" Visible="false"></asp:Label>
    <asp:Label ID="Label3" runat="server" style="color: #FF6600" Text="" Visible="false"></asp:Label>

    <table>
        <tr>
            <td class="auto-style45" style="margin-left:15%; left: 150px; position: relative; top: 0px;">
                <asp:Button ID="Email" runat="server" Text="Enviar Adjunto" 
                    OnClick="AdjuntarArchivo_Click" style="text-align: center" />
            </td>
        </tr>
    </table>

<asp:Panel ID="Panel1" runat="server">

    <fieldset style="width:373px; height:auto; margin-left:15%; left: 200px; position: relative; top: -330px;">
      <legend>Mercados/ Unid % MS</legend> 
            <table>
                <tr>               
                    <td valign="top">
                        <asp:GridView ID="GridView1" AllowSorting="True" AllowPaging="True" runat="server"
                        DataSourceID="SqlDataSource1" DataKeyNames="MERCADO" AutoGenerateColumns="False"
                        Width="267px" style="left: 0px; position: relative; top: 0px; text-align: center;" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" PageSize="100">
                        <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                      <asp:CommandField ShowSelectButton="True" />
                                      <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" />
                                      <asp:BoundField DataField="MSPROMEDIO" HeaderText="% MS Total Mercado" ReadOnly="True" SortExpression="MSPROMEDIO" DataFormatString="{0:N0}"/>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="UnidadesMercadoMarketShareTotal" SelectCommandType="StoredProcedure" >
                          <SelectParameters>
                            <asp:SessionParameter Name="mercado" SessionField="SesionUsuarioMercado" Type="String" />
                            <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
                          </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td>
                    <asp:GridView ID="GridView2" runat="server" DataKeyNames="MERCADO" AutoGenerateRows="False"  
                        HeaderText="Detalle Periodos" DataSourceID="SqlDataSource3" Width="335px" AutoGenerateColumns="False" AllowPaging="True" 
                        style="left: 0px; position: relative; top: 0px;  text-align: center;" BackColor="White" BorderColor="#DEDFDE" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="100">
                        <AlternatingRowStyle BackColor="White" />
                            <Columns>
                            <asp:BoundField DataField="MERCADO" HeaderText="Productos" ReadOnly="True" SortExpression="MERCADO" />
                              <asp:BoundField DataField="PERIODOS" HeaderText="Periodos" ReadOnly="True" SortExpression="PERIODOS" />
                              <asp:BoundField DataField="MSPERIODO" HeaderText="% MS Periodo" ReadOnly="True" SortExpression="MSPERIODO" 
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
                     <asp:SqlDataSource ID="SqlDataSource3"  runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="UnidadesMercadoMarketSharePeriodo" SelectCommandType="StoredProcedure">
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
<%--    </form>--%>
<br />
</asp:Content>
