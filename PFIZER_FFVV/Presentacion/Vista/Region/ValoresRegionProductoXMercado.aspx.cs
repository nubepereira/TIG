using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PFIZER_FFVV.Presentacion.Vista.Region
{
    public partial class ValoresRegionProductoXMercado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
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