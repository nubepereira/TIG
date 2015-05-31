using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using AjaxControlToolkit;
//using AjaxDataTable;
using HtmlAgilityPack;
using Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PFIZER_FFVV.AccesoDeDatos.Conexion.InterfazConexion;
using PFIZER_FFVV.LogicaDeNegocios.Clases.LNUsuarios;
using PFIZER_FFVV.Entidades.EUsuarios;
using System.Windows.Forms;


//para limpiar ListBox
// listBox1.ClearSelected();

/*Carga el ListBox con los años, luego selecciona los periodos asociados, la linea y el mercado que desee 
 * visualizar en el S.I.V por Unidades; verificando que los items sean validos en las 4 opciones que se
 * le presentan, esto para poder realizar posteriormente los querys necesarios que se mostraran en las otras vistas.*/

namespace PFIZER_FFVV.Presentacion.Vista.Seleccion
{
    public partial class Seleciones : System.Web.UI.Page
    {
        //List<Usuario> listaPersona;
        LogicaUsuario logicaPersona = new LogicaUsuario();
        LogicaAnoPeriodo logicaPeriodo = new LogicaAnoPeriodo();
        LogicaMercadoProducto logicaMercadoProducto = new LogicaMercadoProducto();
        Usuario objPersona = new Usuario();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Session["SesionUsuarioAno"] = null;
                    Session["SesionUsuarioPeriodo"] = null;
                    Session["SesionUsuarioLinea"] = null;
                    Session["SesionUsuarioMercado"] = null;

                    this.lbAnos.DataSource = logicaPeriodo.GetDataLog("ComboAnos", null);
                    //ddlAnos.DataSource = GetData("ComboAnos", null);
                    lbAnos.DataBind();

                    ListItem liAnos = new ListItem("Seleccione", "0");
                    lbAnos.Items.Insert(0, liAnos);

                    labelPeriodo.Visible = true;
                    //ListItem liPeriodos = new ListItem("Cargando los Periodos", "-1");
                    //lbPeriodos.Items.Insert(0, liPeriodos);

                    if (String.Compare(Session["SesionUsuarioRol"].ToString(), "2", true) == 0)
                    {
                        this.ddlLinea.DataSource = logicaPersona.ConsultarLineaUsuario(Session["SesionUsuarioClav"].ToString());
                    }
                    else
                    {
                        if (String.Compare(Session["SesionUsuarioRol"].ToString(), "1", true) == 0)
                        {
                            this.ddlLinea.DataSource = logicaPersona.ConsultarLineaAdmin(Session["SesionUsuarioClav"].ToString());
                        }
                    }
                        //this.ddlLinea.DataTextField = "NombreLinea";
                        //this.ddlLinea.DataValueField = "LineaPersona";
                        this.ddlLinea.DataBind();

                        ListItem liLineas = new ListItem("Seleccione", "0");
                        ddlLinea.Items.Insert(0, liLineas);

                    //this.lbMercados.DataSource = logicaMercadoProducto.ConsultarMercadosLog();
                    //this.lbMercados.DataBind();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Lainformacion enviada es incorrecta", e);
                }
                catch (Exception)
                {
                    Console.WriteLine("Se ha producido un error", e);
                }
            }
        }

        protected void lbAnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAnos.SelectedIndex == 0)
            {
                  MessageBox.Show("Debe seleccionar Año valido", "Mensaje de Error");
            }
            else
            {
                if (lbAnos.SelectedIndex > 0)
                {

                    etiquetaPeriodo.Visible = true;
                    lbPeriodos.Visible = true;
                    lbPeriodos.Enabled = true;
                
                    List<String> valoresAno = new List<String>();
                    foreach (ListItem item in lbAnos.Items)
                    {
                        if (item.Selected)
                            valoresAno.Add(item.Value);
                    } 
                    if (valoresAno.Count > 0)
                    {
                        lbPeriodos.Items.Clear(); //limpia el DropDownList periodo al cambiar la opcion del DropDownList del año
                        Session["SesionUsuarioAno"] = string.Join(",", valoresAno.ToArray());
                                               
                        //SqlParameter parameter = new SqlParameter("@ano", lbAnos.SelectedValue);
                        SqlParameter parameter = new SqlParameter("@ano", Session["SesionUsuarioAno"]);
                        DataSet DS = logicaPeriodo.GetDataLog("ComboPeriodoAnos", parameter);
                        lbPeriodos.DataSource = DS;
                        lbPeriodos.DataBind();

                        ListItem liPeriodos = new ListItem("Seleccione", "0");
                        lbPeriodos.Items.Insert(0, liPeriodos);

                        if (ddlLinea.SelectedIndex > 0)
                        {
                            labelPeriodo.Visible = false;
                            ButtonConsultar.Visible = true;
                        }
                        else
                        {
                            labelPeriodo.Visible = true;
                            ButtonConsultar.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar Año valido", "Mensaje de Error");
                    } 
                }
                else
                {
                    MessageBox.Show("Debe seleccionar Año valido", "Mensaje de Error");
                }
           }            
        }

        protected void lbPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
                List<String> valoresPeriodo = new List<String>();
                foreach (ListItem item in lbPeriodos.Items)
                {
                    if (item.Selected)
                        valoresPeriodo.Add("'" + item.Value + "'");
                }

                if (valoresPeriodo.Count > 0)
                {
                    Session["SesionUsuarioPeriodo"] = string.Join(",", valoresPeriodo.ToArray());
                }
                else
                {
                    MessageBox.Show("Debe seleccionar Periodo", "Mensaje de Error");
                }
        }

        protected void ddlLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLinea.SelectedIndex > 0)
            {
                Session["SesionUsuarioLinea"] = ddlLinea.SelectedValue;

                lbMercados.Items.Clear(); //limpia el DropDownList periodo al cambiar la opcion del DropDownList del año
                SqlParameter parameter = new SqlParameter("@linea", Session["SesionUsuarioLinea"]);
                DataSet DS = logicaMercadoProducto.GetDataLogMercado("ComboMercadoLinea", parameter);
                lbMercados.DataSource = DS;
                lbMercados.DataBind();

                ListItem liMercados = new ListItem("Seleccione", "0");
                lbMercados.Items.Insert(0, liMercados);

                etiquetaMercado.Visible = true;
                lbMercados.Visible = true;
                lbMercados.Enabled = true;

                if (lbAnos.SelectedIndex > 0 )
                {
                    labelPeriodo.Visible = false;
                    ButtonConsultar.Visible = true;
                }
                else
                {
                    labelPeriodo.Visible = true;
                    ButtonConsultar.Visible = false;
                }
            }
        }

        protected void lbMercados_SelectedIndexChanged(object sender, EventArgs e)
        {
                List<String> valoresMercado = new List<String>();
                foreach (ListItem item in lbMercados.Items)
                {
                    if (item.Selected)
                        valoresMercado.Add("'" + item.Value + "'");
                }
                if (valoresMercado.Count > 0)
                {
                    Session["SesionUsuarioMercado"] = string.Join(",", valoresMercado.ToArray());
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el Mercado", "Mensaje de Error");
                }
        }

        protected void ButtonConsultar_Click(object sender, EventArgs e)
        {
            if (lbPeriodos.SelectedIndex > 0)
            {
                if (ddlLinea.SelectedIndex > 0)
                {
                    if(lbMercados.SelectedIndex >0)
                    {
                    Response.Redirect("~/Presentacion/Vista/Mercado/Mercados.aspx");
                    //Response.Redirect("~/Presentacion/Vista/Seleccion/PruebaMail.aspx");
                    }
                    else 
                    {
                        MessageBox.Show("Debe seleccionar el Mercado", "Mensaje de Error");
                    }
                }
                else 
                {
                    MessageBox.Show("Debe seleccionar Linea", "Mensaje de Error");
                }
            }
            else 
            {
               MessageBox.Show("Debe seleccionar Periodo", "Mensaje de Error");
            }
        }
    }
}


//for (int i = 0; i < parRoles.Length; i++)
//{
//    cmd.Parameters[0].Value = usuariorolID;
//    cmd.Parameters[1].Value = parUserId;

//    valor = parRoles.GetValue(i).ToString();
//    usuariorolID = usuariorolID + 1;
//    cmd.ExecuteNonQuery();
//}