<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Mercados.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Mercado.Mercados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>
<%--    <script type="text/javascript"> 
 
        //localizar timers
        var iddleTimeoutWarning = null;
        var iddleTimeout = null;
 
        //esta funcion automaticamente sera llamada por ASP.NET AJAX cuando la pagina cargue y un postback parcial complete
        function pageLoad() { 
 
            //borrar antiguos timers de postbacks anteriores
            if (iddleTimeoutWarning != null)
                clearTimeout(iddleTimeoutWarning);
            if (iddleTimeout != null)
                clearTimeout(iddleTimeout);
            //leer tiempos desde web.config
            var millisecTimeOutWarning = <%= int.Parse(System.Configuration.ConfigurationManager.AppSettings["SessionTimeoutWarning"]) * 60 * 1000 %>;
        var millisecTimeOut = <%= int.Parse(System.Configuration.ConfigurationManager.AppSettings["SessionTimeout"]) * 60 * 1000 %>; 
 
        //establece tiempo para mostrar advertencia si el usuario ha estado inactivo
        iddleTimeoutWarning = setTimeout("DisplayIddleWarning()", millisecTimeOutWarning);
        iddleTimeout = setTimeout("TimeoutPage()", millisecTimeOut);
    } 
 
    function DisplayIddleWarning() {
        alert("Tu sesion esta a punto de expirar debido a inactividad.");
    } 
 
    function TimeoutPage() {
        //actualizar pagina para este ejemplo, podriamos redirigir a otra pagina con codigo para eliminar variables de sesion
        location.reload();
    } 
 
</script>--%>
     <style type="text/css">
         .auto-style38
         {
             width: 260px;
         }
         .auto-style39
         {
             width: 178px;
         }
     </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LblFicha" runat="server" Text="" Enabled="false" Visible="false"></asp:Label>
    

    <table style="border: 1px solid #EEEEEE; left: 480px; position: relative; top: -200px;">
        <tr>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" PostBackUrl="~/Presentacion/Vista/Mercado/UnidadesVendidasTotalPaisMercado.aspx" style="text-align: center" Height="28px" Width="29px" />
                <br />Unid. vendidas total pais del Mercado
            </td>
            <td class="auto-style21"; style="border: 1px dotted #CCCCCC; padding: 1px 4px; align-content:center;">
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Presentacion/Imagenes/graficoTablas.png" PostBackUrl="~/Presentacion/Vista/Mercado/UnidadesMSMercado.aspx" style="text-align: center" Height="28px" Width="29px" />
                <br />MS % del Mercado
            </td>
        </tr>
    </table>
    <br />
    &nbsp;
    <br />
</asp:Content>
