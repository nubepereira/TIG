using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PFIZER_FFVV.Presentacion.MasterPage
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        protected void OutputDay()
        {
            Response.Write(DateTime.Now.ToString("D"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionUsuarioNomb"] != null & Session["SesionUsuarioClav"] != null)
            {
                LblUsuario.Text = Session["SesionUsuarioNomb"].ToString();
                LblFicha.Text = Session["SesionUsuarioClav"].ToString();
                //LblFicha.Visible = false;

                //persona = (Usuario)Session["SesionUsuario"];
                //string idPersona = persona.CodigoPersona;

            }
            else
            {
                Response.Redirect("~/Presentacion/Vista/Login/Login.aspx");
            }
        }
        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Session["SesionUsuarioNomb"] = null;
            Session["SesionUsuarioClav"] = null;
            Session["SesionUsuarioAno"] = null;
            Session["SesionUsuarioPeriodo"] = null;
            Session["SesionUsuarioLinea"] = null;
            Session["SesionUsuarioMercado"] = null;
            Response.Redirect("~/Presentacion/Vista/Login/Login.aspx");
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
        {

            ////obtiene el item inicial del menu
            //MenuItem item = e.Item;

            //// Usar la propiedad "Selected" para selecionar la opcion del menu "Selecciones"
            ////  item del menu cuando la pagina carga por primera vez
            //if (item.Text == "Selecciones")
            //{
            //    item.Selected = true;
            //}
        }

        protected void btMenu_Click(object sender, EventArgs e)
        {
            Session["SesionUsuarioAno"] = null;
            Session["SesionUsuarioPeriodo"] = null;
            Session["SesionUsuarioLinea"] = null;
            Session["SesionUsuarioMercado"] = null;
            Response.Redirect("~/Presentacion/Vista/Seleccion/Modulos.aspx");
        }
    }
}