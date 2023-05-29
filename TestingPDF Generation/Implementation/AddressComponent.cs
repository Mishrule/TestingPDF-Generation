using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using TestingPDF_Generation.Models;

namespace TestingPDF_Generation.Implementation
{
   /* public class AddressComponent : IComponent
    {
        private string Title { get; }
        private Address Address { get; }

        public AddressComponent(string title, Address address)
        {
            Title = title;
            Address = address;
        }


        






        public void Compose(IContainer container)
        {
            container.Column(column =>
            {
                column.Spacing(2);

                column.Item().BorderBottom(1).PaddingBottom(5).Text(Title).SemiBold();

                column.Item().Text(Address.CompanyName);
                column.Item().Text(Address.Street);
                column.Item().Text($"{Address.City}, {Address.State}");
                column.Item().Text(Address.Email);
                column.Item().Text(Address.Phone);
            });
        }
    }

    */

    public class CustomStudentRegistrationComponent : IComponent
    {
        public CustomStudentRegistrationComponent(RegistrationInformation registrationInformation)
        {
            RegistrationInformation = registrationInformation;
        }

        private RegistrationInformation RegistrationInformation { get; }
        public void Compose(IContainer container)
        {
            container.Column(column =>
            {
                column.Spacing(2);

              //  column.Item().BorderBottom(1).PaddingBottom(5).Text(Title).SemiBold();

                column.Item().Text(RegistrationInformation.StudentNumber).FontSize(10).Bold();
                column.Item().Text(RegistrationInformation.IndexNumber).FontSize(10).Bold();
                column.Item().Text(RegistrationInformation.AcademicYear).FontSize(10).Bold();
                column.Item().Text(RegistrationInformation.StudentYear).FontSize(10).Bold();
                column.Item().Text(RegistrationInformation.Semester).FontSize(10).Bold();
            });
        }
    }

    public class CustomStudentRegistrationOtherComponent : IComponent
    {
        public CustomStudentRegistrationOtherComponent(RegistrationInformation registrationInformation)
        {
            RegistrationInformation = registrationInformation;
        }

        private RegistrationInformation RegistrationInformation { get; }

        public void Compose(IContainer container)
        {
            container.Column(column =>
            {
                column.Spacing(2);

                //  column.Item().BorderBottom(1).PaddingBottom(5).Text(Title).SemiBold();

                column.Item().Text(RegistrationInformation.Hall).FontSize(10).Bold();
                column.Item().Text(RegistrationInformation.PrimaryContact).FontSize(10).Bold();
                column.Item().Text(RegistrationInformation.OfficialEmail).FontSize(10).Bold();
                column.Item().Text(RegistrationInformation.RegistrationDate).FontSize(10).Bold();
            });
        }
    }



    public class RegistrationInformation
    {
        public string StudentNumber { get; set; }
        public string IndexNumber { get; set; }
        public string AcademicYear { get; set; }
        public string StudentYear { get; set; }
        public string Semester { get; set; }
        public string Hall { get; set; }
        public string PrimaryContact { get; set; }
        public string OfficialEmail { get; set; }
        public string RegistrationDate { get; set; }
    }

    
   
}
