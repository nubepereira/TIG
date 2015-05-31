using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using AjaxControlToolkit;
//using AjaxDataTable;
using HtmlAgilityPack;
using Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PFIZER_FFVV.AccesoDeDatos.Conexion.InterfazConexion;
using PFIZER_FFVV.AccesoDeDatos.Conexion;
using PFIZER_FFVV.LogicaDeNegocios.Clases.LNUsuarios;
using PFIZER_FFVV.Entidades.EUsuarios;
using System.Windows.Forms;

namespace PFIZER_FFVV.Presentacion.Vista.Seleccion
{
    public partial class Modulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.Compare(Session["SesionUsuarioRol"].ToString(), "1", true) == 0)
            {
                LE.Visible = true;
            }
        }

        protected void Unidades_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Presentacion/Vista/Seleccion/Seleciones.aspx");
        }

        protected void Valores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/Vista/Seleccion/SeleccionesVal.aspx");
        }

        protected void Simuladores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/Vista/Simulador/SimuladorTerritorios.aspx");
        }

        protected void LE_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/Vista/Simulador/CRUD.aspx");
        }

    }
}