using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFIZER_FFVV.AccesoDeDatos.SqlServer
{
    //get y set para el encapsulamiento de las variables
    public class MercadoProducto
    {
        private int _idProduto;
        private string _codProducto;
        private string _nombreProducto;
        private string _productoPfizerMercado;
        private int _unidMercado;

        public int IDProducto
        {
            get { return _idProduto; }
            set { _idProduto = value; }
        }
        public String CodProducto
        {
            get { return _codProducto; }
            set { _codProducto = value; }
        }
        public String NombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }
        public String ProductoPfizerMercado
        {
            get { return _productoPfizerMercado; }
            set { _productoPfizerMercado = value; }
        }

        public int UnidMercado
        {
            get { return _unidMercado; }
            set { _unidMercado = value; }
        }

        public MercadoProducto()
        {

        }

        public MercadoProducto(int idProducto, String codProducto, String nombreProducto, String productoPfizerMercado, int unidMercado)
        {
            _idProduto = idProducto;
            _codProducto = codProducto;
            _nombreProducto = nombreProducto;
            _productoPfizerMercado = productoPfizerMercado;
            _unidMercado = unidMercado;
        }
    }
}