using System.Diagnostics;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TestingPDF_Generation.DataSource;
using TestingPDF_Generation.Implementation;

namespace TestingPDF_Generation
{
    public class Program
    {
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Community;

           
            var filePath = @"C:\Users\mishr\Desktop\invoice.pdf";

            var model = InvoiceDocumentDataSource.GetInvoiceDetails();
            // var document = new InvoiceDocument(model);
             var document = new StudentDocument(model);
            document.GeneratePdf(filePath);

            Process.Start("explorer.exe", filePath);

        }

    }
}