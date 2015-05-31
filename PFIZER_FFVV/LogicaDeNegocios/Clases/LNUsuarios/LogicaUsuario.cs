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
    // Valida que el usuaro loggeado exista en la BD

    public class LogicaUsuario
    {
        public Usuario ValidarLoggin(string loggin, string pass)
        {
            SqlServerUsuario bdUsuario = new SqlServerUsuario();
            Usuario usu = new Usuario();
            usu = bdUsuario.ConfirmacionLoggin(loggin, pass);
            return usu;
        }

    //Valida la linea a la que pertenece el usuario loggeado 
        #region ConsultarLineaUsuario
        public List<Usuario> ConsultarLineaUsuario(String loggin)
        {
            //Usuario miPersona = new Usuario();
            SqlServerUsuario objDataBase = new SqlServerUsuario();
            List<Usuario> miListaPersona = new List<Usuario>();


            miListaPersona = objDataBase.ConsultarLineaUsuario(loggin);

            return miListaPersona;
        }
        #endregion

        #region ConsultarLineaAdmin
        public List<Usuario> ConsultarLineaAdmin(String loggin)
        {
            //Usuario miPersona = new Usuario();
            SqlServerUsuario objDataBase = new SqlServerUsuario();
            List<Usuario> miListaPersona = new List<Usuario>();


            miListaPersona = objDataBase.ConsultarLineaAdmin(loggin);

            return miListaPersona;
        }
        #endregion


        #region ConsultarEail
        public Usuario ConsultarEmail(string loggin)
        {
            SqlServerUsuario bdUsuario = new SqlServerUsuario();
            Usuario usu = new Usuario();
            usu = bdUsuario.ConsultarEmailUsuario(loggin);
            return usu;
        }
        #endregion
    }
}