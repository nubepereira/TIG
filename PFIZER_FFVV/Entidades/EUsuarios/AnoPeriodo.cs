using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PFIZER_FFVV.AccesoDeDatos.Conexion.InterfazConexion;
using PFIZER_FFVV.AccesoDeDatos.Conexion;
using PFIZER_FFVV.AccesoDeDatos.SqlServer;


namespace PFIZER_FFVV.Entidades.EUsuarios
{
    //get y set para el encapsulamiento de las variables
    public class AnoPeriodo
    {
        private string _ano;
        private string _periodo;
        private AnoPeriodo _idAno;

        public AnoPeriodo IDano
        {
            get { return _idAno; }
            set { _idAno = value; }
        }
        public string Anos
        {
            get { return _ano; }
            set { _ano = value; }
        }
        public string Periodos
        {
            get { return _periodo; }
            set { _periodo = value; }
        }

        #region Construccion
        public AnoPeriodo()
        {

        }
        public AnoPeriodo(AnoPeriodo idAno, string ano, string peri)
        {
            _ano = ano;
            _periodo = peri;
            _idAno = idAno;
        }
        #endregion

        /*public AnoPeriodo ConsultarPeriodoAno(string ano)
        {
            String usu = new AnoPeriodo();
            SqlServerAnoPeriodo usuconexion = new SqlServerAnoPeriodo();
            usu = usuconexion.ListaPeriodoAnos(ano);
            return usu;
        }*/



    }
}