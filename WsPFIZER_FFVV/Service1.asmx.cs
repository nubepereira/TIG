using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WsPFIZER_FFVV
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://localhost/", Name="Autenticar", Description="Validar acceso Usuario")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        bool result = false;

        [WebMethod]
        public bool AutenticarU(String UsuarioRed, String Clave)
        {
            if (UsuarioRed != null && Clave != null)
                result = true;

            return result;
        }
    }
}