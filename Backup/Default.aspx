<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PdfSendmail._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PdfSendmail</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Panel ID="Panel2" runat="server" Height="291px">
        <asp:Panel ID="Panel1" runat="server" Height="286px">
            <asp:Image ID="Image1" runat="server" Height="76px" 
                ImageUrl="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcT_U9NW6YIgaHzSGuqwlqV7BfSDj3GIcycDqKvlIzaysRslpzYprA" 
                Width="89px" />
            <br />
            <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True">
            </asp:GridView>
            <br />
        </asp:Panel>
    </asp:Panel>
    <p>
            <asp:Button ID="btnExport" runat="server" Text="Exportar" 
            onclick="btnExport_Click" />
        </p>
    </form>
</body>
</html>
