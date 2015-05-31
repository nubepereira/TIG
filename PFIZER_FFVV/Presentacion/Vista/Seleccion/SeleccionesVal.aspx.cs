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
    public partial class SeleccionesVal : System.Web.UI.Page
    {
        //List<Usuario> listaPersona;
        LogicaUsuario logicaPersonaVal = new LogicaUsuario();
        LogicaAnoPeriodo logicaPeriodoVal = new LogicaAnoPeriodo();
        LogicaMercadoProducto logicaMercadoProductoVal = new LogicaMercadoProducto();
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

                    this.lbAnosVal.DataSource = logicaPeriodoVal.GetDataLog("ComboAnos", null);
                    //ddlAnos.DataSource = GetData("ComboAnos", null);
                    lbAnosVal.DataBind();

                    ListItem liAnos = new ListItem("Seleccione", "0");
                    lbAnosVal.Items.Insert(0, liAnos);

                    labelPeriodo.Visible = true;
                    //ListItem liPeriodos = new ListItem("Cargando los Periodos", "-1");
                    //lbPeriodos.Items.Insert(0, liPeriodos);

                    this.ddlLineaVal.DataSource = logicaPersonaVal.ConsultarLineaUsuario(Session["SesionUsuarioClav"].ToString());
                    //this.ddlLinea.DataTextField = "NombreLinea";
                    //this.ddlLinea.DataValueField = "LineaPersona";
                    this.ddlLineaVal.DataBind();

                    ListItem liLineas = new ListItem("Seleccione", "0");
                    ddlLineaVal.Items.Insert(0, liLineas);

                    //this.lbMercados.DataSource = logicaMercadoProducto.ConsultarMercadosLog();
                    //this.lbMercados.DataBind();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Lainformacion enviada es incorrecta", e);
                }
                catch (Exception)
                { 
                    Console.WriteLine("Se ha producido un error",e);
                }
            }

        }

        protected void ddlLineaVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLineaVal.SelectedIndex > 0)
            {
                Session["SesionUsuarioLinea"] = ddlLineaVal.SelectedValue;

                lbMercadosVal.Items.Clear(); //limpia el DropDownList periodo al cambiar la opcion del DropDownList del año
                SqlParameter parameter = new SqlParameter("@linea", Session["SesionUsuarioLinea"]);
                DataSet DS = logicaMercadoProductoVal.GetDataLogMercado("ComboMercadoLinea", parameter);
                lbMercadosVal.DataSource = DS;
                lbMercadosVal.DataBind();

                ListItem liMercados = new ListItem("Seleccione", "0");
                lbMercadosVal.Items.Insert(0, liMercados);

                etiquetaMercado.Visible = true;
                lbMercadosVal.Visible = true;
                lbMercadosVal.Enabled = true;

                if (lbAnosVal.SelectedIndex > 0)
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

        protected void lbAnosVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAnosVal.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar Año valido", "Mensaje de Error");
            }
            else
            {
                if (lbAnosVal.SelectedIndex > 0)
                {
                    etiquetaPeriodo.Visible = true;
                    lbPeriodosVal.Visible = true;
                    lbPeriodosVal.Enabled = true;

                    List<String> valoresAno = new List<String>();
                    foreach (ListItem item in lbAnosVal.Items)
                    {
                        if (item.Selected)
                            valoresAno.Add(item.Value);
                    }
                    if (valoresAno.Count > 0)
                    {
                        lbPeriodosVal.Items.Clear(); //limpia el DropDownList periodo al cambiar la opcion del DropDownList del año
                        Session["SesionUsuarioAno"] = string.Join(",", valoresAno.ToArray());
                        //SqlParameter parameter = new SqlParameter("@ano", lbAnos.SelectedValue);
                        SqlParameter parameter = new SqlParameter("@ano", Session["SesionUsuarioAno"]);
                        DataSet DS = logicaPeriodoVal.GetDataLog("ComboPeriodoAnos", parameter);
                        lbPeriodosVal.DataSource = DS;
                        lbPeriodosVal.DataBind();

                        ListItem liPeriodos = new ListItem("Seleccione", "0");
                        lbPeriodosVal.Items.Insert(0, liPeriodos);

                        if (ddlLineaVal.SelectedIndex > 0)
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

        protected void lbMercadosVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> valoresMercado = new List<String>();
            foreach (ListItem item in lbMercadosVal.Items)
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

        protected void lbPeriodosVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> valoresPeriodo = new List<String>();
            foreach (ListItem item in lbPeriodosVal.Items)
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

        protected void ButtonConsultar_Click(object sender, EventArgs e)
        {
            if (lbPeriodosVal.SelectedIndex > 0)
            {
                if (ddlLineaVal.SelectedIndex > 0)
                {
                    if (lbMercadosVal.SelectedIndex > 0)
                    {
                        Response.Redirect("~/Presentacion/Vista/Mercado/MercadosVal.aspx");
                        //Response.AddHeader("Cache-Control", "no-cache");
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

      

        