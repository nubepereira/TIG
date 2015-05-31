using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PFIZER_FFVV.Presentacion.Vista.Mercado
{
    public partial class DetalleUnidadesMercado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblPeriodo.Text = Session["SesionUsuarioPeriodo"].ToString();
            //String _Dato = Request.QueryString["mercado"];            
            //lblValues.Text = _Dato;

            lblValues.Text = Request.QueryString["mercado"];
        }
    }
}