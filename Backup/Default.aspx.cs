using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace PdfSendmail
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewRow renglon = GridView1.SelectedRow;

            DataTable detalles = null;

            detalles = new DataTable();
            detalles.Columns.Add("nombre");
            detalles.Columns.Add("apellido");
            detalles.Columns.Add("edad");
            DataRow registro = detalles.NewRow();
            registro[0] = "Jose";
            registro[1] = "Rojas";
            registro[2] = "20";

            detalles.Rows.Add(registro);
            GridView1.DataSource = detalles;
            GridView1.DataBind();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ExportGridToPDF()
        {
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
            doc.Add(new Paragraph("Primera Linea"));
            doc.Add(new Paragraph("Segunda Linea"));
            writer.CloseStream = false;

            doc.Close(); memoryStream.Position = 0;
            MailMessage mm = new MailMessage("destinatario@gmail.com", "destinatario2@gmail.com") { Subject = "Correo de prueba", IsBodyHtml = true, Body = "Mensaje de Prueba" };
            mm.Attachments.Add(new Attachment(memoryStream, "export.pdf"));
            SmtpClient smtp = new SmtpClient { Host = "smtp.gmail.com", Port = 587, EnableSsl = true, Credentials = new NetworkCredential("remitente@gmail.com", "password") };

            smtp.Send(mm);

        }
        
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }

    }

}
