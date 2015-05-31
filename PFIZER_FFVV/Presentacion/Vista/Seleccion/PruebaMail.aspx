<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaMail.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Seleccion.PruebaMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
    
    </div>
        <asp:Panel ID="Panel1" runat="server" Height="291px">


            <asp:Label ID="lblContenido" Text="" runat="server" AssociatedControlID="GridView1"></asp:Label>

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

            

            </asp:Panel>
            <br />

    <p>
            <asp:Button ID="btnImprimir" runat="server" Text="Exportar" 
            onclick="btnImprimir_Click" />
        </p>
    </form>
       
</body>
</html>
