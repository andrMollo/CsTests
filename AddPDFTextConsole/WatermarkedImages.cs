using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;

namespace AddPDFTextConsole
{
    internal class WatermarkedImages
    {
        private static readonly string inputFile = @"C:\Users\AndreaMollo\Desktop\testPDF\input.pdf";

        private static readonly string outputFile = @"C:\Users\AndreaMollo\Desktop\testPDF\output.pdf";

        static void Main(string[] args)
        {
            AddWatermarkToPdf();            
        }

        private static void AddWatermarkToPdf()
        {
            using (var pdfReader = new PdfReader(inputFile))
            {
                using (var pdfWriter = new PdfWriter(outputFile))
                {
                    using (var pdfDocument = new PdfDocument(pdfReader, pdfWriter))
                    {
                        // Create a text watermark
                        var watermarkText = "Confidential";
                        var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                        var color = ColorConstants.GRAY;
                        var opacity = 0.5f;

                        // Add the watermark to each page
                        for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
                        {
                            var page = pdfDocument.GetPage(i);
                            var canvas = new PdfCanvas(page);
                            var pageSize = page.GetPageSize();
                            var x = pageSize.GetWidth() / 2;
                            var y = pageSize.GetHeight() / 2;

                            var transform = new AffineTransform(1, 0, 0, 1, x, y); // Create an AffineTransform
                            canvas.SaveState()
                                .SetExtGState(new PdfExtGState().SetFillOpacity(opacity))
                                .BeginText()
                                .SetFontAndSize(font, 40)
                                .SetColor(color, true)
                                .SetTextMatrix(transform) // Use the AffineTransform
                                .ShowText(watermarkText)
                                .EndText()
                                .RestoreState();
                        }
                    }
                }
            }
        }
    }
}
