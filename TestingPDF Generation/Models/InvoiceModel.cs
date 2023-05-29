using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingPDF_Generation.Implementation;

namespace TestingPDF_Generation.Models
{
    public class InvoiceModel
    {
        public int InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }

        public RegistrationInformation RegistrationInformation { get; set; }
        public RegistrationInformation RegistrationBioData { get; set; }

        public List<OrderItem> Items { get; set; }
        public bool HasResit { get; set; } = false;
        public string Comments { get; set; }
    }
}
