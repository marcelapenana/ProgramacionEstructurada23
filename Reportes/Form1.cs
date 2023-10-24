using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

using Reportes.Clases;
//IMPORTAMOS CLASS
namespace Reportes
{
    public partial class Form1 : Form
        
    {

        DaeContext contexto = new DaeContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //configuración del doc pdf
            //CONFIG PARA REPORT
            string rutaPDF = "Reporte_Productos.pdf";//name doc
                                                     //config nuevo documento PDF
          
       

            //config new document pdf
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(rutaPDF));
            Document doc = new Document(pdfDoc);

            //Diseño pdf
            try {
                //gener table datos bd
                Table tabla = new Table(4);//cantidad de columnas que tiene la tabla add id
                //encabezados
                tabla.AddCell(new Cell().Add(new Paragraph("ID")).SetBackgroundColor(ColorConstants.GRAY));
                tabla.AddCell(new Cell().Add(new Paragraph(" NOMBRE PRODUCTO")).SetBackgroundColor(ColorConstants.GRAY));
                tabla.AddCell(new Cell().Add(new Paragraph(" COSTO PRODUCTO")).SetBackgroundColor(ColorConstants.GRAY));
                tabla.AddCell(new Cell().Add(new Paragraph(" CANTIDAD")).SetBackgroundColor(ColorConstants.GRAY));

                //RECORRER DATOS
                foreach (var item in contexto.Productos)
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(item.IdProd.ToString())));
                    tabla.AddCell(new Cell().Add(new Paragraph(item.NombreProd.ToString())));
                    tabla.AddCell(new Cell().Add(new Paragraph(item.CostoProd.ToString())));
                    tabla.AddCell(new Cell().Add(new Paragraph(item.Cantidad.ToString())));
                }

                //generar titulo
                var titulo = new Paragraph("TITULO DEL REPORTE");
                titulo.SetTextAlignment(TextAlignment.CENTER);
                titulo.SetFontSize(16);
                //dentro de la carpeta raiz del proytc crear carpeta img
                //generar un log: ruta
                //string ruta_imagen = "../../../img/logo.png";
                //var img = new iText.Layout.Element.Image
                    //(ImageDataFactory.Create(ruta_imagen));
                //img.ScaleToFit(200, 100);
                //img.SetFixedPosition(50, 750);

                //                       x,y : x=de abajo para arriba y y izquierda hacia arriba
                //ARMADO DEL DOCUEMENTO
                doc.Add(titulo);
                //doc.Add(img);
                var salto = new Paragraph("\n\n");
                doc.Add(salto);
                var texto = new Paragraph("Esto es una descripción de los datos a presentar en este reporte, puede haber mas información si asi lo desea");
                doc.Add(texto);
                doc.Add(tabla);

                //CERRAMOS EL DOCUMENTO
                doc.Close();
                pdfDoc.Close();




            }
            catch (Exception ex) { 
            
            }
        }
    }
}