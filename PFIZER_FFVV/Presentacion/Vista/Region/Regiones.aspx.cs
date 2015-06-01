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
    public partial class Regiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var miMaster = (Site)this.Master;
            System.Web.UI.WebControls.Menu mimenu = (System.Web.UI.WebControls.Menu)miMaster.FindControl("Menu1");
            mimenu.Items[8].Selected = true;

            if (Session["SesionUsuarioAno"] == null && Session["SesionUsuarioPeriodo"] == null && Session["SesionUsuarioLinea"] == null && Session["SesionUsuarioMercado"] == null)
            {
                MessageBox.Show("Debe seleccionar Datos correctos para continuar!", "REGIONES");
                Response.Redirect("~/Presentacion/Vista/Seleccion/Seleciones.aspx");
            }

        }
    }
}