<%@ Page Title="R.E.M.O.T.O." Language="C#" MasterPageFile="~/Presentacion/MasterPage/Site2.Master" AutoEventWireup="true" CodeBehind="SeleccionesVal.aspx.cs" Inherits="PFIZER_FFVV.Presentacion.Vista.Seleccion.SeleccionesVal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <link rel="Shortcut Icon" href="../../Imagenes/FaviconRemoto.png"/>   
    
<%--      <script type="text/javascript">
          $(document).ready(function() {    
              $('.button').click(function(){

                  //Añadimos la imagen de carga en el contenedor
                  $('#content').html('<div><img src="images/ajax-loader.gif"/></div>');

                  var page = $(this).attr('data');        
                  var dataString = 'page='+page;


                  $.ajax({
                      type: "GET",
                      url: "includes/Seleciones.aspx",
                      data: dataString,
                      success: function(data) {
                          //Cargamos finalmente el contenido deseado
                          $('#content').fadeIn(1000).html(data);
                      }
                  });
              });              
          });    
</script>--%>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /> 
<fieldset style="width:733px; height:auto; margin-left:18%; left: 22px; position: relative; top: 0px;">
<legend>Opciones a Seleccionar</legend>  
   <table style="border: 2px solid #FFFFFF; left: 100px; position: relative">
       <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
        <tr>
            <td><asp:Label ID="etiquetaLinea" runat="server" Text="Linea:" ForeColor="#ff9933" Visible="true" Enabled="true" style="font-weight: 700"></asp:Label></td>
                <td></td><td rowspan="4" class="auto-style40"> &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td><asp:DropDownList ID="ddlLineaVal" runat="server" DataTextField="NombreLinea" DataValueField="LineaPersona" Height="16px" Width="194px" Visible="true" Enabled="true" OnSelectedIndexChanged="ddlLineaVal_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Text="Seleccione" Value="0" />
                    </asp:DropDownList>  
                </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td><asp:label id="etiquetaAno" runat="server" Text="Año:" ForeColor="#ff9933" Visible="true" style="font-weight: 700"></asp:label> </td>
            <td>
                <div><asp:ListBox ID="lbAnosVal" runat="server" DataTextField="Ano" DataValueField="Ano" OnSelectedIndexChanged="lbAnosVal_SelectedIndexChanged" AutoPostBack="true" Width="100px" SelectionMode="Multiple" Visible="true">
                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                    </asp:ListBox>
                <br /></div>
            </td>    
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>                                                             
            <td>
<%--            Pruebas para el icono de cargando en la pantalla, la 2 y 3 prueba va con un stilo en la hoja Style  
    
                3)  <div style="width:140px; height:120px" class="precarga">
                    <a href="SeleccionesVal.aspx">
                        <img src="../../Imagenes/ajax-loader.gif" alt="" />
                    </a>
                </div>--%>

<%--            2)    <div id="imgLOAD" style="background-position:center; text-align:center;position:fixed;z-index:6;" title="click para cerrar" onclick="cerrar">
                    <img alt="" src="../../Imagenes/ajax-loader.gif" />
                </div>--%>

<%--                       1) <div title="Click para Cerrar" id="carga" style="cursor:pointer;border-radius:10px;-webkit-border-radius:10px;
                        box-shadow:inset yellow 0px 0px 14px;background-image:url(~/Presentacion/Imagenes/ajax-loader.gif);
                        background-position:center;background-size:100%;background-color:#FFFFFF;
                        width:300px;color:#ff6a00;text-align:center;height:100px;padding:52px 12px 12px 12px;
                        position:fixed;top:30%;left:40%;z-index:6;">Procesando . . . </div>  --%>         
                

                <asp:Label ID="etiquetaMercado" runat="server" Text="Mercado:" ForeColor="#ff9933" Visible="false" Enabled="false" style="font-weight: 700"></asp:Label>
                 &nbsp; </td>

            <td>&nbsp;</td>
            <td>
                <asp:ListBox ID="lbMercadosVal" runat="server" DataTextField="MERCADO" DataValueField="MERCADO" AppendDataBoundItems="true" Width="200" SelectionMode="Multiple" Visible="false" Enabled="false" OnSelectedIndexChanged="lbMercadosVal_SelectedIndexChanged">
                <asp:ListItem Text="Seleccione" Value="0" />
                </asp:ListBox>
            </td>   
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>                      
                <asp:Label ID="etiquetaPeriodo" runat="server" Text="Periodo" ForeColor="#ff9933" Visible="false" style="font-weight: 700"></asp:Label></td>
            
            <td>
                <div>
                    <br />                    
                    <asp:ListBox ID="lbPeriodosVal" runat="server" DataTextField="PERIODOS" DataValueField="PERIODOS" Width="100px" SelectionMode="Multiple" Visible="false" Enabled="false" AppendDataBoundItems="True" OnSelectedIndexChanged="lbPeriodosVal_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione</asp:ListItem>
                    </asp:ListBox>   
                    <br />
                <br /></div>
            </td>              
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td> 
        </tr>
       <tr>
           <td colspan="4">
                <asp:Label ID="labelPeriodo" runat="server" Text="Seleccione Linea y Año, luego espere la carga de Información..." ForeColor="Red" Visible="false"></asp:Label>
            </td>
           <td></td> 
           <td></td> 
       </tr>
        <tr>
            <td></td>
            <td></td> 
            <td>
                <asp:Button ID="ButtonConsultar" runat="server" Text="Consultar" CssClass="button" Width="90px" OnClick="ButtonConsultar_Click" Visible="false" />
            </td>              
            <td></td> 
            <td></td> 
            <td></td>          
        </tr>  
   </table> 
    <br />
</fieldset>
</asp:Content>
