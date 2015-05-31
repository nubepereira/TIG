<%@ Page Title="R.E.M.O.T.O" Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="PruebaDetalleUnidadesMercado.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Mercado.DetalleUnidadesMercado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table style="left: 200px; position: relative">
        <tr>
            <td></td>
            <td></td>
            <td>
                <strong>
            <span class="auto-style29">Mercado</span><span class="auto-style2">:</span></strong> <asp:Label ID="lblValues" runat="server" Text="" Enabled="true" Visible="true" style="font-weight: 700; color: #FF6600"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            
            <td></td>
            <td rowspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" style="left: 10px; position: relative">
                <Columns>
                    <asp:BoundField DataField="MERCADO" HeaderText="MERCADO" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" Visible="false" />
                    <asp:BoundField DataField="PERIODOS" HeaderText="PERIODOS" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" />
                    <asp:BoundField DataField="UNIDADES" DataFormatString="{0:N0}" HeaderText="UNIDADES" HeaderStyle-BackColor="#808080" HeaderStyle-ForeColor="White" />
                </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnPFIZER %>" SelectCommand="UnidadesVendidasTotalPaisMercado" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblValues" Name="mercado" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="LblPeriodo" Name="periodo" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <img alt="" class="auto-style24" height="125" src="../../Imagenes/logoRemoto.png" width="200" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblPeriodo" runat="server" Text="" Enabled="true" Visible="false"></asp:Label>
            </td>
            <td></td>
        </tr>
    </table>
    <br />   
</asp:Content>
