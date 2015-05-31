using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.IO;

namespace PFIZER_FFVV.Presentacion.Vista.Brick
{
    public partial class Bricks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (IOException error)
            {
                if (Session["SesionUsuarioAno"] == null || Session["SesionUsuarioPeriodo"] == null || Session["SesionUsuarioLinea"] == null | Session["SesionUsuarioMercado"] == null)
                {
                    MessageBox.Show("Ha expirado el tiempo de espera de la aplicacion", "BRICKS");
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