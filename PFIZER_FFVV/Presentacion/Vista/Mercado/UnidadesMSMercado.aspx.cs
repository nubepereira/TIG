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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;
using PFIZER_FFVV.Presentacion.MasterPage;

namespace PFIZER_FFVV.Presentacion.Vista.Mercado
{
    public partial class UnidadesMSMercado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var miMaster = (Site)this.Master;
            System.Web.UI.WebControls.Menu mimenu = (System.Web.UI.WebControls.Menu)miMaster.FindControl("Menu1");
             mimenu.Items[1].Selected=true;


            //Label1.Text = "R.E.M.O.T.O";
            //Label3.Text = Session["SesionUsuarioEmail"].ToString();
            Label3.Text = "nubi30@gmail.com"; 
            //Response.Redirect("~/Presentacion/Vista/Email/EnvioEmail.aspx");

            if (Session["SesionUsuarioAno"] == null && Session["SesionUsuarioPeriodo"] == null && Session["SesionUsuarioLinea"] == null && Session["SesionUsuarioMercado"] == null)
            {
                MessageBox.Show("Debe seleccionar Datos correctos para continuar!", "MERCADOS");
                Response.Redirect("~/Presentacion/Vista/Seleccion/Seleciones.aspx");
            }
        }

        protected void EnvioEmailSMTP()
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
            _Message.To.Add(Label3.Text); //Cuenta de Correo al que se le quiere enviar el e-mail
            //_Message.From = new System.Net.Mail.MailAddress(correoFrom, "R.E.M.O.T.O.", System.Text.Encoding.UTF8); //correo desde donde se envia los emails
            _Message.From = new System.Net.Mail.MailAddress(nc.UserName, "R.E.M.O.T.O.", System.Text.Encoding.UTF8); //correo desde donde se envia los emails
            _Message.Subject = "Reporte de R.E.M.O.T.O"; // Titulo del email
            _Message.SubjectEncoding = System.Text.Encoding.UTF8; //Codificacion
            _Message.Body = "Reporte MS del mercado en Unidades"; //contenido del mail - mensaje
            _Message.BodyEncoding = System.Text.Encoding.UTF8;
            _Message.Priority = System.Net.Mail.MailPriority.Normal;
            _Message.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //ADICION DE DATOS ADJUNTOS     
            Document doc = new Document(PageSize.LETTER);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            HTMLWorker htmlparser = new HTMLWorker(doc);

            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();
            htmlparser.Parse(sr);
            doc.Add(new Paragraph("Archivo adjunto con Consulta del S.I.V"));
            doc.Add(new Paragraph("Consulta en UNIDADES del MS por Mercado"));
            writer.CloseStream = false;

            doc.Close(); memoryStream.Position = 0;

            _Message.Attachments.Add(new Attachment(memoryStream, "export.pdf"));

            // String _File = My.Application.Info.DirectoryPath & "archivo" //archivo que se quiere adjuntar
            //string _File = "C:/Users/NUBIELIS/Desktop/BD_TESIS_3b.xlsx";
            //System.Net.Mail.Attachment _Attachment = new System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet);
            //_Message.Attachments.Add(_Attachment);

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


        protected void AdjuntarArchivo_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = false;
            this.EnvioEmailSMTP();
        }

        ////msdn.microsoft.com/es-es/library/system.windows.forms.messagebox%28v=vs.110%29.aspx //dialogo de mensajes
    }
}