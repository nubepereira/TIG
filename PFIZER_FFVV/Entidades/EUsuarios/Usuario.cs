using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PFIZER_FFVV.AccesoDeDatos.Conexion;
using PFIZER_FFVV.AccesoDeDatos.SqlServer;

namespace PFIZER_FFVV.Entidades.EUsuarios
{
    //get y set para el encapsulamiento de las variables
    public class Usuario
    {
        #region Atributos
        private String _codigoPersona; //ficha
        private String _nombrePersona;
        private int _distritoPersona;
        private int _lineaPersona; //idL dbo.Reps
        private String _nombreLinea;
        private String _brickPersona;
        private String _descripcionBrick;
        private String _email;
        private String _rol;
        #endregion

        #region Encapsulado
        public string CodigoPersona
        {
            get { return _codigoPersona; }
            set { _codigoPersona = value; }
        }
        public String NombrePersona
        {
            get { return _nombrePersona; }
            set { _nombrePersona = value; }
        }
        public int DistritoPersona
        {
            get { return _distritoPersona; }
            set { _distritoPersona = value; }
        }
        public int LineaPersona
        {
            get { return _lineaPersona; }
            set { _lineaPersona = value; }
        }
        public String NombreLinea
        {
            get { return _nombreLinea; }
            set { _nombreLinea = value; }
        }
        public String BrickPersona
        {
            get { return _brickPersona; }
            set { _brickPersona = value; }
        }
        public String DescripcionBrick
        {
            get { return _descripcionBrick; }
            set { _descripcionBrick = value; }
        }
        public String Email
        {
            get { return _email;}
            set { _email = value; }
        }
        public String Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        #endregion

        #region Construccion
        public Usuario()
        {

        }
        public Usuario(String codPer, String nombrePer, int distriPer, int lineaPer, String nombreLinea, String brickPer, String desBrick, String  email, String rol)
        {
            _codigoPersona = codPer;
            _nombrePersona = nombrePer;
            _distritoPersona = distriPer;
            _lineaPersona = lineaPer;
            _nombreLinea = nombreLinea;
            _brickPersona = brickPer;
            _descripcionBrick = desBrick;
            _email = email;
            _rol = rol;

        }
        #endregion
    }
}