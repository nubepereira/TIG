﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PFIZER_FFVV.Presentacion.Vista.Representante
{
    public partial class Representantes : System.Web.UI.Page
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
                MessageBox.Show("Debe seleccionar Datos en la Página actual para continuar!", "REPRESENTANTES");
                Response.Redirect("~/Presentacion/Vista/Seleccion/Seleciones.aspx");
            }
        }
    }
}