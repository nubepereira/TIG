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
    public class SqlServerUsuario
    {
        IConexionSqlServer db = new ConexionSqlServer();

        #region Confirmacion para el loggin del usuario parametro nombreUser y contraseña
        public Usuario ConfirmacionLoggin(string Loggin, string password)
        {
            {
                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionSqlServer conex = new ConexionSqlServer();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                Usuario usuarioConfirmado = new Usuario();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que esta hecho
                    command.CommandText = "[dbo].[BuscarLoginWS]";
                    command.CommandTimeout = 3600;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@contraseña", password);
                    command.Parameters.AddWithValue("@nombreUsuario", Loggin);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@contraseña"].Direction = ParameterDirection.Input;
                    command.Parameters["@nombreUsuario"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto
                    while (reader.Read())
                    {

                        usuarioConfirmado.CodigoPersona = reader.GetString(0);
                        usuarioConfirmado.NombrePersona = reader.GetString(1);
                        usuarioConfirmado.Rol = reader.GetInt32(2).ToString();
                    }

                    return usuarioConfirmado;
                }
                catch (SqlException)
                {

                    throw new Exception();
                }

                finally
                {
                    if (reader != null)
                        reader.Close();
                    conex.CerrarConexion();
                }
            }
        }
        #endregion Confirmacion para el loggin del usuario parametro nombreUser y contraseña


        #region ConsultarLineaUsuario
        public List<Usuario> ConsultarLineaUsuario(string loggin)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnPFIZER"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Usuario objetoPersona = new Usuario();
            List<Usuario> miLista = new List<Usuario>();
            int _loggin = Convert.ToInt32(loggin);

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("[dbo].[ConsultarUsuarioTipoLinea]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@loggin", _loggin);
                dr = cmd.ExecuteReader();

                //Se recorre cada row
                while (dr.Read())
                {
                    objetoPersona = new Usuario();
                    objetoPersona.LineaPersona = Convert.ToInt32(dr.GetValue(0));
                    objetoPersona.NombreLinea = dr.GetValue(1).ToString();
                    miLista.Add(objetoPersona);
                }
                db.CerrarConexion();
            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionConexion(("Error: " + error.Message), error)); //en las lineas que recibe
            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }
        #endregion

        #region ConsultarLineaAdmin
        public List<Usuario> ConsultarLineaAdmin(string loggin)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConnPFIZER"].ToString();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Usuario objetoPersona = new Usuario();
            List<Usuario> miLista = new List<Usuario>();
            int _loggin = Convert.ToInt32(loggin);

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                cmd = new SqlCommand("[dbo].[ConsultarAdminTipoLinea]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@loggin", _loggin);
                dr = cmd.ExecuteReader();

                //Se recorre cada row
                while (dr.Read())
                {
                    objetoPersona = new Usuario();
                    objetoPersona.LineaPersona = Convert.ToInt32(dr.GetValue(0));
                    objetoPersona.NombreLinea = dr.GetValue(1).ToString();
                    miLista.Add(objetoPersona);
                }
                db.CerrarConexion();
            }
            catch (SqlException error)
            {
                //En caso de que se viole alguna restriccion sobre la BD
                throw (new ExcepcionConexion(("Error: " + error.Message), error)); //en las lineas que recibe
            }
            finally
            {
                db.CerrarConexion();
            }
            return miLista;
        }
        #endregion

        #region Devuelve el email asociado al usuario
        public Usuario ConsultarEmailUsuario(string Loggin)
        {
            {
                // instancio un objeto conexion y otro Sqlcommand para la BD
                ConexionSqlServer conex = new ConexionSqlServer();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader = null;
                Usuario usuarioConfirmado = new Usuario();

                try
                {

                    conex.AbrirConexion();
                    command.Connection = conex.ObjetoConexion();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Aqui debo poner el nombre del storeProcedure que esta hecho
                    command.CommandText = "[dbo].[BuscarEmail]";
                    command.CommandTimeout = 3600;

                    //Aqui van los parametros del store procesure
                    command.Parameters.AddWithValue("@fichaUsuario", Loggin);
                    //Se indica que es un parametro de entrada
                    command.Parameters["@fichaUsuario"].Direction = ParameterDirection.Input;
                    reader = command.ExecuteReader();
                    // guarda registro a registro cada objeto
                    while (reader.Read())
                    {
                        usuarioConfirmado.Email = reader.GetString(0);
                    }
                    return usuarioConfirmado;
                }
                catch (SqlException)
                {

                    throw new Exception();
                }

                finally
                {
                    if (reader != null)
                        reader.Close();
                    conex.CerrarConexion();
                }
            }
        }
        #endregion Confirmacion de Email



       


        /*   #region TraerUsuario
        public Usuario TraerUsuario(string Loggin)
        {
            Usuario Us = new Usuario();
            // instancio un objeto conexion y otro Sqlcommand para la BD
            ConexionSqlServer conex = new ConexionSqlServer();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            try
            {
                
                conex.AbrirConexion();
                command.Connection = conex.ObjetoConexion();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Aqui debo poner el nombre del storeProcedure que no esta hecho
                command.CommandText = "[dbo].[ConsultarUsuarioGte]";
                command.CommandTimeout = 50;

                //Aqui van los parametros del store procesure
                command.Parameters.AddWithValue("@loggin", Loggin);
                //Se indica que es un parametro de entrada
                command.Parameters["@loggin"].Direction = ParameterDirection.Input;
                reader = command.ExecuteReader();
                // guarda registro a registro cada objeto
                while (reader.Read())
                {
                    Us.CodigoPersona = reader.GetString(0);
                    Us.NombrePersona = reader.GetString(1);                    
                }

                return Us;
            }
            catch (SqlException)
            {

                throw new Exception();
            }

            finally
            {
                if (reader != null)
                    reader.Close();
                conex.CerrarConexion();
            }
        }
        #endregion
*/






    }
}

