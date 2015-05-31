using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using PFIZER_FFVV.LogicaDeNegocios.Clases.LNUsuarios;
using PFIZER_FFVV.Entidades.EUsuarios;
using PFIZER_FFVV.Presentacion.Vista.Login;

namespace PFIZER_FFVV.Presentacion.Vista.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Autenticacion.Autenticar oAutenticar = new Autenticacion.Autenticar();

        private string pass, usu, p1, p2, tipoUsu;
        

        protected void onClickLoginButton(object sender, EventArgs e)
        {
            bool verdad = false;
            usu = nombre.Text.ToString();
            pass = Clave.Value.ToString();

            
            LogicaUsuario acceso = new LogicaUsuario();
            Usuario variableUs = new Usuario();

            verdad = oAutenticar.AutenticarU(usu, pass);

            if(verdad == true)
            {
                variableUs = acceso.ValidarLoggin(usu, pass);

                if(variableUs !=null)
                {
                    p1 = variableUs.NombrePersona;
                    p2 = variableUs.CodigoPersona;
                    tipoUsu = variableUs.Rol;

                    if(p1 != null && p2 != null && tipoUsu != null)
                    {
                        Session["SesionUsuarioNomb"] = p1;
                        Session["SesionUsuarioClav"] = p2;
                        Session["SesionUsuarioRol"] = tipoUsu;

                        variableUs = acceso.ConsultarEmail(Session["SesionUsuarioClav"].ToString());
                        Session["SesionUsuarioEmail"] = variableUs.Email;     
                        Response.Redirect("~/Presentacion/Vista/Seleccion/Modulos.aspx");

                    }
                    else 
                    {
                         falla.Text = "Usuario o Contraseña Incorrecto";
                    }
                }
               else
               {
                   falla.Text = "Usuario o Contraseña Incorrecto";
               }
            }
            else
            {
               falla.Text = "Disculpe, este usuario no posee acceso";
            }
          }

        //    usu = nombre.Text.ToString();
        //    pass = Clave.Value.ToString();

        //    LogicaUsuario acceso = new LogicaUsuario();
        //    Usuario variableUs = new Usuario();

        //    variableUs = acceso.ValidarLoggin(usu, pass);

        //    p1 = variableUs.NombrePersona;
        //    p2 = variableUs.CodigoPersona;

        //    if (p1 != null)
        //    {
        //        if (p2 != null)
        //        {
        //            bool verdad = p1.Contains(usu);

        //            if (verdad == p2.Contains(pass))
        //            {
        //                //redirect the user Seleccion S.I.V
        //                Session["SesionUsuarioNomb"] = p1;
        //                Session["SesionUsuarioClav"] = p2;
        //                Response.Redirect("~/Presentacion/Vista/Seleccion/Modulos.aspx");
        //            }
        //            else
        //            {
        //                falla.Text = "Usuario o Contraseña Incorrecto";
        //            }
        //        }
        //        else
        //        {
        //            falla.Text = "Usuario o Contraseña Incorrecto";
        //        }
        //    }
        //    else
        //    {
        //        falla.Text = "Usuario o Contraseña Incorrecto";
        //    }
        //}

    }

}