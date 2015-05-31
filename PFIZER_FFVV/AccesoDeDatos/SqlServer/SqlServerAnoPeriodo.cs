using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using PFIZER_FFVV.AccesoDeDatos.Conexion.InterfazConexion;
using PFIZER_FFVV.AccesoDeDatos.Conexion;
using PFIZER_FFVV.AccesoDeDatos.SqlServer;
using PFIZER_FFVV.LogicaDeNegocios.Excepciones;
using PFIZER_FFVV.Entidades.EUsuarios;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PFIZER_FFVV.AccesoDeDatos.SqlServer
{
    public class SqlServerAnoPeriodo
    {
        IConexionSqlServer db = new ConexionSqlServer();

        //metodo que obtiene el año y sus periodos asociados para enviarlos al store procedure
        public DataSet GetDataAnoPeriodo(string SPName, SqlParameter SPParameter)
        {
            //colocarle try catch al metodo
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnPFIZER"].ToString();
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            //conexion.Open();

            //Colocar para evitar q expire el tiempo de ejecucon, xq no se conecta.
            ConexionSqlServer con = new ConexionSqlServer();
            con.AbrirConexion();
            SqlDataAdapter da = new SqlDataAdapter(SPName, conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 3600;

            if (SPParameter != null)
            {
                    da.SelectCommand.Parameters.Add(SPParameter);
            }
            DataSet DS = new DataSet();
            da.Fill(DS);
            con.CerrarConexion();
            return DS;

        }

        

       /* #region ConsultarPeriodo
        public List<AnoPeriodo> ConsultarPeriodoSql()
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnPFIZER"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            AnoPeriodo objetoPeriodo = new AnoPeriodo();
            List<AnoPeriodo> miLista = new List<AnoPeriodo>();

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("[dbo].[ComboPeriodoAnos]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                //Se recorre cada row
                while (dr.Read())
                {
                    objetoPeriodo = new AnoPeriodo();
                    objetoPeriodo.Periodos = dr.GetValue(0).ToString();
                    miLista.Add(objetoPeriodo);
                }

                db.CerrarConexion();

            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionConexion(("Error: " + error.Message), error));
            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }
        #endregion*/
    }
}