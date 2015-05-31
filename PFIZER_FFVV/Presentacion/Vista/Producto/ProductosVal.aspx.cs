using System;
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

namespace PFIZER_FFVV.Presentacion.Vista.Producto
{
    public partial class ProductosVal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionUsuarioAno"] != null && Session["SesionUsuarioPeriodo"] != null && Session["SesionUsuarioLinea"] != null && Session["SesionUsuarioMercado"] != null)
            {
                //LblAno.Text = Session["SesionUsuarioAno"].ToString();
                //LblPeriodo.Text = Session["SesionUsuarioPeriodo"].ToString();
                //LblLinea.Text = Session["SesionUsuarioLinea"].ToString();
                //LblMercado.Text = Session["SesionUsuarioMercado"].ToString();

                //persona = (Usuario)Session["SesionUsuario"];
                //string idPersona = persona.CodigoPersona;                

            }
            else
            {
                MessageBox.Show("Debe seleccionar Datos en la Página actual para continuar!", "PRODUCTOS");
                Response.Redirect("~/Presentacion/Vista/Seleccion/Seleciones.aspx");
            }
        }
    }
}