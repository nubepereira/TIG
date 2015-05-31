using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;

namespace PFIZER_FFVV.Presentacion.MasterPage
{
    public partial class Site : System.Web.UI.MasterPage
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
                //Label1.Text = Session["SesionUsuarioAno"].ToString();
                
                string[] words = Session["SesionUsuarioAno"].ToString().Split(',');
                foreach (string s in words)
                {
                    ListBox1.Items.Add(s);
                }
                //Console.WriteLine(Session["SesionUsuarioAno"]);
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