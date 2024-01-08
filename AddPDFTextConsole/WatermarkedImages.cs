using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.IO;

namespace AddPDFTextConsole
{
    /*
     * Code from:
     * https://kb.itextpdf.com/itext/adding-watermarks-to-images
     */
    internal class WatermarkedImages
    {
        private static readonly string baseFile = @"C:\Users\AndreaMollo\Desktop\testPDF\origin.pdf";

        private static readonly string watermarkFile = @"C:\Users\AndreaMollo\Desktop\testPDF\watermark.jpg";

        private static readonly string outputFile = @"C:\Users\AndreaMollo\Desktop\testPDF\output.pdf";

        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(outputFile);
            file.Directory.Create();

            new WatermarkedImages().ManipulatePdf(outputFile);
        }

        protected void ManipulatePdf(string outputFile)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(outputFile));
            Document doc = new Document(pdfDoc);

            Image image = GetWatermarkedImage(pdfDoc, new Image(ImageDataFactory.Create(watermarkFile)), "Test");
            doc.Add(image);

            doc.Close();
        }

        private static Image GetWatermarkedImage(PdfDocument pdfDoc, Image image, string watermark)
        {
            float width = image.GetImageScaledWidth();
            float height = image.GetImageScaledHeight();

            PdfFormXObject template = new PdfFormXObject(new Rectangle(width, height));

            new Canvas(template, pdfDoc)
                .Add(image)
                .SetFontColor(DeviceGray.BLACK)
                .ShowTextAligned(watermark, width / 2, width / 2, TextAlignment.CENTER, (float)Math.PI / 6)
                .Close();

            return new Image(template);
        }
    }
}
