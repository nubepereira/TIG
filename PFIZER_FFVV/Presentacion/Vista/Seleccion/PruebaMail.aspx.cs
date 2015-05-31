using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace PFIZER_FFVV.Presentacion.Vista.Seleccion
{
    public partial class PruebaMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //El botón de ejecución se llamó btnImprimir, el código asociado al evento clic de éste botón es:

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
        //System.Web.Exception opcional para manejar datos de respuesta HTTP a un cliente
        Response.Clear();
        Response.ContentType ="application/pdf";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //Para crear una instancia de documento de iTextSharp con el tamaño de página y tamaño de margenes correspondientes
        Document doc = new Document(PageSize.LETTER.Rotate(), 10, 10, 10, 10);
        //La ruta en donde será guardado el pdf dentro del servidor
        String path = this.Server.MapPath(".") + "\\Archivos\\MiArchivo.pdf";

        //Utilizamos System.IO para crear o sobreescribir el archivo si existe
        FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

        //iTextSharp para escribir en el documento PDF
        PdfWriter.GetInstance(doc, file);
        doc.Open();
        //Agregamos  el texto que esta dentro de la etiqueta
        //Se pueden agregar varios solamente añadiendo varias sentencias doc.Add(…)    
        //doc.Add(new Paragraph(GridView1.Attributes.ToString()));
        doc.Add(new Paragraph(Panel1.Controls.ToString()));

        doc.Close();

        Process.Start(path);
        }

    }
}