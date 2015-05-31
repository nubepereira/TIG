using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using PFIZER_FFVV.LogicaDeNegocios.Excepciones;


namespace PFIZER_FFVV.AccesoDeDatos.Conexion.InterfazConexion
{
    //clase que implementa la Interfaz para abrir y cerrar la conexion

    public class ConexionSqlServer : IConexionSqlServer
    {
        private static String cadenaConexion;
        SqlConnection objetoConexion;
        private static SqlConnection conexion;

        public ConexionSqlServer()
        {
            try
            {
                objetoConexion = null;
                cadenaConexion = ConfigurationManager.ConnectionStrings["ConnPFIZER"].ToString();
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (NullReferenceException)
            {
                throw new ExcepcionConexion("El estring de conexion del WebConfig no puede ser localizado");

            }


        }

        public static SqlConnection AccederAconexion
        {
            //permite hacer el enlace con la BD
            get { return conexion; }

            set { conexion = value; }

        }

        //Metodo para abrir la conexion
        public void AbrirConexion()
        {
            //cadenaConexion es el string que permite el acceso a la conexion a traves del objetoConexion 
            if (!String.IsNullOrEmpty(cadenaConexion))
            {
                objetoConexion = new SqlConnection(cadenaConexion);
                objetoConexion.Open();

                if (objetoConexion.State.ToString() != "Open")
                {
                    while (objetoConexion.State.ToString() != "Open")
                    {

                    }
                }
            }
        }

        //Metodo para cerrar la conexion
        public void CerrarConexion()
        {
            if (objetoConexion != null)
            {
                if (objetoConexion.State.ToString() == "Open")
                {
                    objetoConexion.Close();
                    objetoConexion.Dispose();
                }
            }
        }


        public SqlConnection ObjetoConexion()
        {
            return (objetoConexion);

        }
    }
}