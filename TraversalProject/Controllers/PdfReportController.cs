using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/pdfReports/"+"fayl1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasiya Pdf Hesabatı");
            document.Add(paragraph);
            document.Close();
            return File("/pdfReports/fayl1.pdf", "application/pdf", "fayl1.pdf");

        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfReports/" + "fayl2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            PdfPTable pdfTable = new PdfPTable(3);

            pdfTable.AddCell("İstifadəçi Adı");
            pdfTable.AddCell("İstifadəçi Soyadı");
            pdfTable.AddCell("İstifadəçi ŞVSN");

            pdfTable.AddCell("Elvin");
            pdfTable.AddCell("İsmayılov");
            pdfTable.AddCell("11111111");

            pdfTable.AddCell("Əli");
            pdfTable.AddCell("Səfərov");
            pdfTable.AddCell("11111111");

            pdfTable.AddCell("Neman");
            pdfTable.AddCell("Musayev");
            pdfTable.AddCell("11111111");

            document.Add(pdfTable);
            document.Close();
            return File("/pdfReports/fayl2.pdf", "application/pdf", "fayl2.pdf");

        }
    }
}
