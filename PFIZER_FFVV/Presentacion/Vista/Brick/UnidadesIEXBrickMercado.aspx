<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="UnidadesIEXBrickMercado.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Brick.UnidadesIEXBrickMercado" %>
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
<fieldset style="width:780px; height:auto; margin-left:15%; left: 200px; position: relative; top: -190px;">
      <legend>Brick/ IE Producto x Brick en el Mercado</legend> 
    
    <table style="top: 0px; position:relative; left: 10px;">
      <tr>
          <td valign="top">
             <b>Seleccione el Mercado:</b>
            <asp:DropDownList ID="DropDownList1" DataSourceID="SqlDataSource2" AutoPostBack="true"
              DataTextField="MERCADO" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" >
                <asp:ListItem Value="0">Seleccione</asp:ListItem>
              </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="MercadosSeleccionados"
              ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommandType="StoredProcedure" >
                <SelectParameters>
                    <asp:SessionParameter Name="mercado" SessionField="SesionUsuarioMercado" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
              <br />
         </td>
          <td style="width:505px"></td>
       </tr>

        <tr>
        <td valign="top">
          <br />
          <asp:GridView ID="GridView1" AllowSorting="True" AllowPaging="True" runat="server"
            DataSourceID="SqlDataSource1" DataKeyNames="PRODUCTO"
            AutoGenerateColumns="False" Width="237px" style="left: 0px; position: relative; top: 0px; text-align: center;" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="100">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
              <asp:CommandField ShowSelectButton="True" />
              <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" Visible="false" />
              <asp:BoundField DataField="PRODUCTO" HeaderText="Producto" SortExpression="PRODUCTO" />
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
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="ProductoXMercadoXPeriodo"
            ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommandType="StoredProcedure">
            <SelectParameters>
              <asp:ControlParameter ControlID="DropDownList1" Name="mercado" PropertyName="SelectedValue"
                Type="String" />
                <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
            </SelectParameters>
          </asp:SqlDataSource>
        </td>

        <td valign="top" style="width:250px">
            <br />
            <asp:GridView runat="server" DataKeyNames="PRODUCTO" AutoGenerateRows="False" DataSourceID="SqlDataSource3" 
            HeaderText="Detalle Periodos" ID="GridView2" Width="490px" AutoGenerateColumns="False" AllowPaging="True" style="left: 15px; position: relative; top: 0px; text-align: center;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="100">
            <AlternatingRowStyle BackColor="White" />
               <Columns>
                 <asp:BoundField DataField="MERCADO" HeaderText="Mercado" ReadOnly="True" SortExpression="MERCADO" Visible="false" />
                 <asp:BoundField DataField="PRODUCTO" HeaderText="Productos" ReadOnly="True" SortExpression="PRODUCTO" Visible="false" />
                 <asp:BoundField DataField="PERIODO" HeaderText="Periodos" ReadOnly="True" SortExpression="PERIODO" />
                 <asp:BoundField DataField="BRICK" HeaderText="Bricks" ReadOnly="True" SortExpression="BRICK" />
                 <asp:BoundField DataField="IE" HeaderText="Unid I.E Producto X Mercado" ReadOnly="True" SortExpression="IE" />
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
            <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="UnidadesBrickIExMercadoPeriodo" ID="SqlDataSource3" SelectCommandType="StoredProcedure">
               <SelectParameters>
                  <asp:ControlParameter ControlID="DropDownList1" Name="mercado" PropertyName="SelectedValue" Type="String" />
                  <asp:SessionParameter Name="periodo" SessionField="SesionUsuarioPeriodo" Type="String" />
                  <asp:ControlParameter ControlID="GridView1" Name="producto" PropertyName="SelectedValue" Type="String" />
               </SelectParameters>
            </asp:SqlDataSource>
        </td>
      </tr>
    </table>
    </fieldset>
</asp:Panel>
    <br />
</asp:Content>

