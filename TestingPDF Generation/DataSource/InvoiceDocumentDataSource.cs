using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Helpers;
using TestingPDF_Generation.Implementation;
using TestingPDF_Generation.Models;

namespace TestingPDF_Generation.DataSource
{
    public static class InvoiceDocumentDataSource
    {
        private static Random Random = new Random();

        public static InvoiceModel GetInvoiceDetails()
        {
            var items = Enumerable
                .Range(1, 8)
                .Select(i => GenerateRandomOrderItem())
                .ToList();

            return new InvoiceModel
            {
                InvoiceNumber = Random.Next(1_000, 10_000),
                IssueDate = DateTime.Now,
                DueDate = DateTime.Now + TimeSpan.FromDays(14),

                RegistrationInformation = GenerateRandomAddress(),
                RegistrationBioData = GenerateRandomAddress(),

                Items = items,
                Comments = Placeholders.Paragraph()
            };
        }

        private static OrderItem GenerateRandomOrderItem()
        {
            return new OrderItem
            {
                Name = Placeholders.Label(),
                Price = (decimal) Math.Round(Random.NextDouble() * 100, 2),
                Quantity = Random.Next(1, 10)
            };
        }

        private static RegistrationInformation GenerateRandomAddress()
        {
            return new RegistrationInformation
            {
                StudentNumber = "Student Number: "+ 9001464920,
                IndexNumber = "Index Number: " + "BS424101020",
                StudentYear = "Student Year: " + "Two",
                Hall = "Hall: "+"KT",
                OfficialEmail = "Official Email: "+ "",
                RegistrationDate = "Registration Date: " + "Friday, July 8, 2022",
                PrimaryContact = "Primary Phone No.: "+ "0547513183",
                AcademicYear = "Academic Year: "+ "2021 / 2022",
                Semester = "Semester: "+ "Two"
                
            };
        }
    }


}
