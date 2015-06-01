﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using PFIZER_FFVV.Presentacion.MasterPage;

namespace PFIZER_FFVV.Presentacion.Vista.Region
{
    public partial class ValoresRegionProductoXMercado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var miMaster = (Site3)this.Master;
            System.Web.UI.WebControls.Menu mimenu = (System.Web.UI.WebControls.Menu)miMaster.FindControl("Menu1");
            mimenu.Items[8].Selected = true;

            if (Session["SesionUsuarioAno"] == null && Session["SesionUsuarioPeriodo"] == null && Session["SesionUsuarioLinea"] == null && Session["SesionUsuarioMercado"] == null)
            {
                MessageBox.Show("Debe seleccionar Datos correctos para continuar!", "REGIONES");
                Response.Redirect("~/Presentacion/Vista/Seleccion/SelecionesVal.aspx");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Insert(0, new ListItem("Seleccione", "0"));
            DropDownList2.DataBind();
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        protected void Email_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/Vista/Email/EnvioEmail.aspx");
        }
    }
}