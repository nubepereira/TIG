using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PFIZER_FFVV.Presentacion.Vista.Mercado
{
    public partial class UnidadesMarketShare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblAno.Text = Session["SesionUsuarioAno"].ToString();
            LblPeriodo.Text = Session["SesionUsuarioPeriodo"].ToString();
            LblLinea.Text = Session["SesionUsuarioLinea"].ToString();
            LblMercado.Text = Session["SesionUsuarioMercado"].ToString();
        }
    }
}