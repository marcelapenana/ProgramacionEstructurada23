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
            //config new document pdf
            PdfDocument pdfCoc = new PdfDocument(new PdfWriter(rutaPDF));

            //Diseño pdf
            try {
                //gener table datos bd
                Table tabla = new Table(4);//cantidad de columnas que tiene la tabla add id
                //encabezados
                tabla.AddCell(new Cell().Add(new Paragraph("ID")));
                tabla.AddCell(new Cell().Add(new Paragraph("NAME")));
                tabla.AddCell(new Cell().Add(new Paragraph("COST")));
                tabla.AddCell(new Cell().Add(new Paragraph("CANT")));

                //RECORRER DATOS
                foreach (var item in contexto.Productos)
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(item.IdProd.ToString())));
                    tabla.AddCell(new Cell().Add(new Paragraph(item.NombreProd.ToString())));
                    tabla.AddCell(new Cell().Add(new Paragraph(item.CostoProd.ToString())));
                    tabla.AddCell(new Cell().Add(new Paragraph(item.Cantidad.ToString())));
                }

                //generar titulo
                var titulo=new Paragraph("REPORTE PRODUCTOS");
                titulo.SetTextAlignment(TextAlignment.CENTER);
                titulo.SetFontSize(8);
                //dentro de la carpeta raiz del proytc crear carpeta img
                //generar un log: ruta
                string ruta_imagen = "../../../img/logo.png";
                var img = new iText.Layout.Element.Image(ImageDataFactory.Create(ruta_imagen));
                img.ScaleToFit(200,100);
                img.SetFixedPosition(50, 750);
                //                       x,y : x=de abajo para arriba y y izquierda hacia arriba


            } catch (Exception ex) { 
            
            }
        }
    }
}