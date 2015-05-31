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
    //metodo para obtener el periodo asociado al año seleccionado
    public class LogicaAnoPeriodo
    {
        #region GetDataLogAnoPeriodo
        public DataSet GetDataLog(string SPName, SqlParameter SPParameter)
        {
            //Usuario miPersona = new Usuario();
            SqlServerAnoPeriodo objDataBase = new SqlServerAnoPeriodo();
            DataSet miListaPersona = new DataSet();

            miListaPersona = objDataBase.GetDataAnoPeriodo(SPName, SPParameter);

            return miListaPersona; //me devuelve la lista en cache que obtuve de GetDataAnoPeriodo
        }
        #endregion

     /*   public List<AnoPeriodo> ConsultarAnos()
        {
            List<AnoPeriodo> miMercado = new List<AnoPeriodo>();
            SqlServerAnoPeriodo objDataBase = new SqlServerAnoPeriodo();
            //miPersona = objDataBase.TraerUsuario(ficha);
            miMercado = objDataBase.ConsultarAnoSql();
            return miMercado;
        }*/

    }
}