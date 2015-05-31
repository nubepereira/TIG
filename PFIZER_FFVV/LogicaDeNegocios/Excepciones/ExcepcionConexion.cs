using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFIZER_FFVV.LogicaDeNegocios.Excepciones
{
    public class ExcepcionConexion : System.Exception
    {
        public ExcepcionConexion() : base() { }
        public ExcepcionConexion(string message) : base(message) { }
        public ExcepcionConexion(string message, System.Exception inner) : base(message, inner) { }
    }
}