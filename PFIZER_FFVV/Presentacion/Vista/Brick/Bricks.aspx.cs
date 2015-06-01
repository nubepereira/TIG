using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using PFIZER_FFVV.Presentacion.MasterPage;

namespace PFIZER_FFVV.Presentacion.Vista.Brick
{
    public partial class Bricks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var miMaster = (Site)this.Master;
                System.Web.UI.WebControls.Menu mimenu = (System.Web.UI.WebControls.Menu)miMaster.FindControl("Menu1");
                mimenu.Items[6].Selected = true;
            }
            catch (IOException error)
            {
                if (Session["SesionUsuarioAno"] == null || Session["SesionUsuarioPeriodo"] == null || Session["SesionUsuarioLinea"] == null | Session["SesionUsuarioMercado"] == null)
                {
                    MessageBox.Show("Debe seleccionar Datos correctos para continuar!", "BRICKS");
                    Response.Redirect("~/Presentacion/Vista/Seleccion/Seleciones.aspx");
                }
                else { 
                        if(error.Source != null)
                        {
                            Console.WriteLine("IOException source: {0}", error.Source);
                        } throw;
                }

            }


        }
    }
}