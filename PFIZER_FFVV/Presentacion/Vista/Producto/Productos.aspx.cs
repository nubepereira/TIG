using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using AjaxDataTable;
using HtmlAgilityPack;
using Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PFIZER_FFVV.AccesoDeDatos.Conexion.InterfazConexion;
using PFIZER_FFVV.LogicaDeNegocios.Clases.LNUsuarios;
using PFIZER_FFVV.Entidades.EUsuarios;
using System.Windows.Forms;
using PFIZER_FFVV.Presentacion.MasterPage;

namespace PFIZER_FFVV.Presentacion.Vista.Producto
{
    public partial class Productos : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            var miMaster = (Site)this.Master;
            System.Web.UI.WebControls.Menu mimenu = (System.Web.UI.WebControls.Menu)miMaster.FindControl("Menu1");
            mimenu.Items[2].Selected = true;

            if (Session["SesionUsuarioAno"] == null && Session["SesionUsuarioPeriodo"] == null && Session["SesionUsuarioLinea"] == null && Session["SesionUsuarioMercado"] == null)
            {
                MessageBox.Show("Debe seleccionar Datos correctos para continuar!", "PRODUCTOS");
                Response.Redirect("~/Presentacion/Vista/Seleccion/Seleciones.aspx");
            }
        }     
    }
}