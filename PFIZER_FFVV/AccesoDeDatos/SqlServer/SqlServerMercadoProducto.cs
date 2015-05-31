using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PFIZER_FFVV.AccesoDeDatos.Conexion;
using PFIZER_FFVV.AccesoDeDatos.Conexion.InterfazConexion;
using PFIZER_FFVV.Entidades.EUsuarios;
using PFIZER_FFVV.LogicaDeNegocios.Excepciones;

namespace PFIZER_FFVV.AccesoDeDatos.SqlServer
{
    public class SqlServerMercadoProducto
    {
        IConexionSqlServer db = new ConexionSqlServer();

        //metodo que obtiene el mercado segun la linea seleccionada
        public DataSet GetDataMercadoLinea(string SPName, SqlParameter SPParameter)
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

        //#region ConsultarMercado
        //public List<MercadoProducto> ConsultarMercadoSql()
        //{
        //    string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnPFIZER"].ToString();
        //    SqlConnection conexion = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataReader dr;

        //    MercadoProducto objetoMercado = new MercadoProducto();
        //    List<MercadoProducto> miLista = new List<MercadoProducto>();

        //    try
        //    {
        //        conexion = new SqlConnection(cadenaConexion);
        //        conexion.Open();
        //        cmd = new SqlCommand("[dbo].[ComboMercados]", conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        dr = cmd.ExecuteReader();

        //        //Se recorre cada row
        //        while (dr.Read())
        //        {
        //            objetoMercado = new MercadoProducto();
        //            objetoMercado.ProductoPfizerMercado = dr.GetValue(0).ToString();
        //            miLista.Add(objetoMercado);
        //        }
        //        db.CerrarConexion();
        //    }
        //    catch (SqlException error)
        //    {
        //        //En caso de que se viole alguna restriccion sobre la BD
        //        throw (new ExcepcionConexion(("Error: " + error.Message), error));
        //    }
        //    finally
        //    {
        //        db.CerrarConexion();
        //    }
        //    return miLista;
        //}
        //#endregion

       
    }
}