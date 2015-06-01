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
            if (Session["SesionUsuarioNomb"] != null & Session["SesionUsuarioClav"] != null && Session["SesionUsuarioRol"] !=null)
            {
                LblUsuario.Text = Session["SesionUsuarioNomb"].ToString();
                LblFicha.Text = Session["SesionUsuarioClav"].ToString();
                
                string[] anos = Session["SesionUsuarioAno"].ToString().Split(',');
                LBAnos.Items.Clear();
                foreach (string s in anos)
                {
                    LBAnos.Items.Add(s);
                }
                string[] periodos = Session["SesionUsuarioPeriodo"].ToString().Split(',');
                LBPeriodos.Items.Clear();
                foreach (string p in periodos)
                {
                    LBPeriodos.Items.Add(p);
                }
                string[] lineas = Session["SesionUsuarioLinea"].ToString().Split(',');
                LBLineas.Items.Clear();
                foreach (string l in lineas)
                {
                    LBLineas.Items.Add(l);
                }
                string[] mercados = Session["SesionUsuarioMercado"].ToString().Split(',');
                LBMercados.Items.Clear();
                foreach (string m in mercados)
                {
                    LBMercados.Items.Add(m);
                }
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