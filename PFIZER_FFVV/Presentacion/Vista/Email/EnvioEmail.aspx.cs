using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Microsoft.Office.Interop.Outlook;
using PFIZER_FFVV.LogicaDeNegocios.Clases.LNUsuarios;
using PFIZER_FFVV.Entidades.EUsuarios;

namespace PFIZER_FFVV.Presentacion.Vista.Email
{
    public partial class EnvioEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "R.E.M.O.T.O";
            Label3.Text = Session["SesionUsuarioEmail"].ToString();
            //Label3.Text = "nubi30@gmail.com";            
        }


        protected void ButtonEnvio_Click(object sender, EventArgs e)
        {
            this.EnvioEmailSMTP(Label1.Text, Label3.Text, TextBox3.Text, TextBox4.Text);
            //Convert.ToInt32(DropDownList1.SelectedItem.Value)
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            ButtonRegresar.Attributes.Add("onclick", "history.back(); return false;");
        }

        protected void EnvioEmailSMTP(String correoFrom, String correoTo, String subject, String mensaje)
        //, int tipo_mensaje
        {
            //CLIENTE DE CORREO
            System.Net.Mail.MailMessage _Message = new System.Net.Mail.MailMessage(); //objeto de mensaje    
            System.Net.Mail.SmtpClient _SMTP = new System.Net.Mail.SmtpClient();

            System.Net.NetworkCredential nc = new System.Net.NetworkCredential();
            nc.UserName = System.Configuration.ConfigurationManager.AppSettings["SMTP_ID"].ToString();
            nc.Password = System.Configuration.ConfigurationManager.AppSettings["SMTP_PASS"].ToString();
            //_SMTP.Credentials = new System.Net.NetworkCredential("nubi30@gmail.com", "nubeClimbing3086");

            //Obligatorio para realizar envios de email desde gmail
            _SMTP.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP"].ToString();
            _SMTP.Credentials = nc;
            _SMTP.Port = 587; // 25/587 tls/465 ssl;
            _SMTP.EnableSsl = true;

            //CONFIGURACION DEL MENSAJE
            _Message.To.Add(correoTo); //Cuenta de Correo al que se le quiere enviar el e-mail
            //_Message.From = new System.Net.Mail.MailAddress(correoFrom, "R.E.M.O.T.O.", System.Text.Encoding.UTF8); //correo desde donde se envia los emails
            _Message.From = new System.Net.Mail.MailAddress(nc.UserName, "R.E.M.O.T.O.", System.Text.Encoding.UTF8); //correo desde donde se envia los emails
            _Message.SubjectEncoding = System.Text.Encoding.UTF8; //Codificacion
            _Message.Body = mensaje; //contenido del mail
            _Message.BodyEncoding = System.Text.Encoding.UTF8;
            _Message.Priority = System.Net.Mail.MailPriority.Normal;
            _Message.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //ADICION DE DATOS ADJUNTOS           
            // String _File = My.Application.Info.DirectoryPath & "archivo" //archivo que se quiere adjuntar
            string _File = "C:/Users/NUBIELIS/Desktop/BD_TESIS_3b.xlsx";
            System.Net.Mail.Attachment _Attachment = new System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet);
            _Message.Attachments.Add(_Attachment);

            //ENVIODE EMAIL
            try
            {
                _SMTP.Send(_Message);
                MessageBox.Show("El email ha sido enviado");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

        }
    }
}

//protected void EnvioEmailSMTP(String correoFrom, String correoTo, String subject, String mensaje)
////, int tipo_mensaje
//{
//    //CLIENTE DE CORREO
//    System.Net.Mail.MailMessage _Message = new System.Net.Mail.MailMessage(); //objeto de mensaje    
//    System.Net.Mail.SmtpClient _SMTP = new System.Net.Mail.SmtpClient();

//    System.Net.NetworkCredential nc = new System.Net.NetworkCredential();
//    nc.UserName = System.Configuration.ConfigurationManager.AppSettings["SMTP_ID"].ToString();
//    nc.Password = System.Configuration.ConfigurationManager.AppSettings["SMTP_PASS"].ToString();
//    //_SMTP.Credentials = new System.Net.NetworkCredential("nubi30@gmail.com", "nubeClimbing3086");

//    //Obligatorio para realizar envios de email desde gmail
//    _SMTP.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP"].ToString();
//    _SMTP.Credentials = nc;
//    _SMTP.Port = 587; // 25/587 tls/465 ssl;
//    _SMTP.EnableSsl = true;

//    //CONFIGURACION DEL MENSAJE
//    _Message.To.Add(correoTo); //Cuenta de Correo al que se le quiere enviar el e-mail
//    //_Message.From = new System.Net.Mail.MailAddress(correoFrom, "R.E.M.O.T.O.", System.Text.Encoding.UTF8); //correo desde donde se envia los emails
//    _Message.From = new System.Net.Mail.MailAddress(nc.UserName, "R.E.M.O.T.O.", System.Text.Encoding.UTF8); //correo desde donde se envia los emails
//    _Message.SubjectEncoding = System.Text.Encoding.UTF8; //Codificacion
//    _Message.Body = mensaje; //contenido del mail
//    _Message.BodyEncoding = System.Text.Encoding.UTF8;
//    _Message.Priority = System.Net.Mail.MailPriority.Normal;
//    _Message.IsBodyHtml = false; //Si no queremos que se envíe como HTML

//    //ADICION DE DATOS ADJUNTOS           
//    // String _File = My.Application.Info.DirectoryPath & "archivo" //archivo que se quiere adjuntar
//    string _File = "C:/Users/NUBIELIS/Desktop/BD_TESIS_3b.xlsx";
//    System.Net.Mail.Attachment _Attachment = new System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet);
//    _Message.Attachments.Add(_Attachment);

//    //ENVIODE EMAIL
//    try
//    {
//        _SMTP.Send(_Message);
//        MessageBox.Show("El email ha sido enviado");
//    }
//    catch (System.Net.Mail.SmtpException ex)
//    {
//        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
//    }

//}





//************************ENVIO DE CORREOS A GMAIL CON EL SERVIDOR SMTP CONFIGURADO ********************//

////CLIENTE DE CORREO
//            System.Net.Mail.MailMessage _Message = new System.Net.Mail.MailMessage(); //objeto de mensaje    
//            System.Net.Mail.SmtpClient _SMTP = new System.Net.Mail.SmtpClient();

//            System.Net.NetworkCredential nc = new System.Net.NetworkCredential();
//            nc.UserName = System.Configuration.ConfigurationManager.AppSettings["SMTP_ID"].ToString();
//            nc.Password = System.Configuration.ConfigurationManager.AppSettings["SMTP_PASS"].ToString();

//            //_SMTP.Credentials = new System.Net.NetworkCredential("nubi30@gmail.com", "nubeClimbing3086");
//            //_SMTP.Host = "smtp.gmail.com";


//            //Obligatorio para realizar envios de email desde gmail
//            _SMTP.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP"].ToString();
//            _SMTP.Credentials = nc;
//            _SMTP.Port = 587; // 25/587;
//            _SMTP.EnableSsl = true;

//            //CONFIGURACION DEL MENSAJE
//            _Message.To.Add(correo); //Cuenta de Correo al que se le quiere enviar el e-mail
//            _Message.From = new System.Net.Mail.MailAddress("nubielis.pereira@gmail.com", "R.E.M.O.T.O.", System.Text.Encoding.UTF8); //correo desde donde se envia los emails
//            _Message.SubjectEncoding = System.Text.Encoding.UTF8; //Codificacion
//            _Message.Body = mensaje; //contenido del mail
//            _Message.BodyEncoding = System.Text.Encoding.UTF8;
//            _Message.Priority = System.Net.Mail.MailPriority.Normal;
//            _Message.IsBodyHtml = false; //Si no queremos que se envíe como HTML

//            if (tipo_mensaje.Equals(1))
//            {
//                _Message.Subject = "Aprobación Pendiente"; //Sujeto del e-mail
//            }
//            else
//            {
//                if (tipo_mensaje.Equals(2))
//                {
//                    _Message.Subject = "Solicitud Aprobada";  //Sujeto del e-mail
//                }
//                else
//                {
//                    if (tipo_mensaje.Equals(3))
//                    {
//                        _Message.Subject = "Solicitud Rechazada"; //Sujeto del e-mail
//                    }
//                }
//            }


//            //ADICION DE DATOS ADJUNTOS           

//            string _File = "C:/Users/NUBIELIS/Desktop/BD_TESIS_3b.xlsx";
//            System.Net.Mail.Attachment _Attachment = new System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet);
//            _Message.Attachments.Add(_Attachment);

//            //ENVIODE EMAIL
//            try
//            {
//                _SMTP.Send(_Message);
//            }
//            catch (System.Net.Mail.SmtpException ex)
//            {
//                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//*************************** ENVIO DE CORREOS A GMAIL SIN SMTP *****************************//

//protected void EnvioEmailGmail(String correo, String mensaje, int tipo_mensaje)
//{
//    System.Net.Mail.MailMessage _Message = new System.Net.Mail.MailMessage(); //objeto de mensaje    

//    //CLIENTE DE CORREO
//    System.Net.Mail.SmtpClient _SMTP = new System.Net.Mail.SmtpClient();
//    _SMTP.Credentials = new System.Net.NetworkCredential("nubi30@gmail.com", "nubeClimbing3086");

//    _SMTP.Host = "smtp.gmail.com";

//    //Obligatorio para realizar envios de email desde gmail
//    _SMTP.Port = 587; // 25/587;
//    _SMTP.EnableSsl = true;

//    //CONFIGURACION DEL MENSAJE
//    _Message.To.Add(correo); //Cuenta de Correo al que se le quiere enviar el e-mail
//    _Message.From = new System.Net.Mail.MailAddress(correo, "R.E.M.O.T.O.", System.Text.Encoding.UTF8); //correo desde donde se envia los emails
//    _Message.SubjectEncoding = System.Text.Encoding.UTF8; //Codificacion
//    _Message.Body = mensaje; //contenido del mail
//    _Message.BodyEncoding = System.Text.Encoding.UTF8;
//    _Message.Priority = System.Net.Mail.MailPriority.Normal;
//    _Message.IsBodyHtml = false; //Si no queremos que se envíe como HTML

//    if (tipo_mensaje.Equals(1))
//    {
//        _Message.Subject = "Aprobación Pendiente"; //Sujeto del e-mail
//    }
//    else
//    {
//        if (tipo_mensaje.Equals(2))
//        {
//            _Message.Subject = "Solicitud Aprobada";  //Sujeto del e-mail
//        }
//        else
//        {
//            if (tipo_mensaje.Equals(3))
//            {
//                _Message.Subject = "Solicitud Rechazada"; //Sujeto del e-mail
//            }
//        }
//    }


//    //ADICION DE DATOS ADJUNTOS           

//    string _File = "C:/Users/NUBIELIS/Desktop/BD_TESIS_3b.xlsx";
//    System.Net.Mail.Attachment _Attachment = new System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet);
//    _Message.Attachments.Add(_Attachment);

//    //ENVIODE EMAIL
//    try
//    {
//        _SMTP.Send(_Message);
//    }
//    catch (System.Net.Mail.SmtpException ex)
//    {
//        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }

//}