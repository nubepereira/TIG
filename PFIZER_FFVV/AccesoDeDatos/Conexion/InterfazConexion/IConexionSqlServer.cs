using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PFIZER_FFVV.AccesoDeDatos.Conexion.InterfazConexion
{
     //Interfaz de los metodos AbrirConexion y Cerrarconexion;y el objeto que permite hacer la conexion con la BD

    public interface IConexionSqlServer
    {
        void AbrirConexion();

        void CerrarConexion();

        SqlConnection ObjetoConexion();
    }
}