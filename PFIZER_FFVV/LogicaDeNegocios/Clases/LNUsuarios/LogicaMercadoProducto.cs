using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using AjaxDataTable;
using HtmlAgilityPack;
using Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using PFIZER_FFVV.Entidades.EUsuarios;
using PFIZER_FFVV.AccesoDeDatos.SqlServer;

namespace PFIZER_FFVV.LogicaDeNegocios.Clases.LNUsuarios
{
    //obtiene los mercados asociados a la linea

    public class LogicaMercadoProducto
    {
        //public List<MercadoProducto> ConsultarMercadosLog()
        //{
        //    List<MercadoProducto> miMercado = new List<MercadoProducto>();
        //    SqlServerMercadoProducto objDataBase = new SqlServerMercadoProducto();
        //    //miPersona = objDataBase.TraerUsuario(ficha);
        //    miMercado = objDataBase.ConsultarMercadoSql();
        //    return miMercado;
        //}

        #region GetDataLogMercadoLinea        
        public DataSet GetDataLogMercado(string SPName, SqlParameter SPParameter)
        {
            //Usuario miPersona = new Usuario();
            SqlServerMercadoProducto objDataBase = new SqlServerMercadoProducto();
            DataSet miListaPersona = new DataSet();

            miListaPersona = objDataBase.GetDataMercadoLinea(SPName, SPParameter);

            return miListaPersona;
        }
        #endregion
    }
}


