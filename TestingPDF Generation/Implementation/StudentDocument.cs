using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TestingPDF_Generation.Models;

namespace TestingPDF_Generation.Implementation
{
    public class StudentDocument : IDocument
    {
       
            public InvoiceModel Model { get; }

            public StudentDocument(InvoiceModel model)
            {
                Model = model;
            }

            public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
            public DocumentSettings GetSettings() => DocumentSettings.Default;



            public void Compose(IDocumentContainer container)
            {
                container
                    .Page(page =>
                    {
                        page.Margin(50);

                        page.Header().ShowOnce().Element(ComposeHeader);
                       // page.Content().Element(LineComponent);
                        page.Content().Element(ComposeContent);


                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.CurrentPageNumber();
                            x.Span(" / ");
                            x.TotalPages();
                            x.AlignRight();

                        });
                    });
            }

            void ComposeHeader(IContainer container)
            {
                var titleStyle = TextStyle.Default.FontSize(15).SemiBold().FontColor(Colors.Blue.Medium);

                container.Row(row =>
                {
                    row.RelativeItem().Column(column =>
                    {
                        column.Item().Text(text =>
                            text.Span("University of Mines and Technology").Style(titleStyle.FontColor("#004c23").FontSize(14))
                        );
                        column.Item().Text(text =>
                            text.Span("{Department from Backend}").Style(titleStyle.FontColor("#FF0000").FontSize(13))
                        );
                        column.Item().Text(text =>
                            text.Span("Tel.: +233 362 2203 / 203 24 Fax: +233 362 20306").Style(titleStyle.FontColor("#000000").FontSize(9))
                        );
                        column.Item().Text(text =>
                            text.Span("P.O.Box 237, Tarkwa, Ghana, West Africa").Style(titleStyle.FontColor("#000000").FontSize(9))
                        );
                       // column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);

                        
                    });
                    

                     using var stream = new FileStream(@"C:\Users\mishr\source\repos\TestingPDF Generation\TestingPDF Generation\logo.png", FileMode.Open);
                     row.RelativeItem().AlignRight().Image(stream).FitHeight();
                     //row.AutoItem().Column(c =>
                     //{
                     //    c.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                     //});

                });
                
               // LineComponent(container);
        }

            


            void ComposeContent(IContainer container)
            {
                container.Column(column =>
                {
                    column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                    //column.Item().Element(LineComponent);
                    column.Spacing(5);
                    column.Item().AlignCenter().Text("{Department/Campus From Back}").Bold().FontSize(11);
                    column.Item().AlignCenter().Text("{StudentName}").Bold().FontSize(11);

                    column.Item().Row(row =>
                    {
                        row.RelativeItem().Component(new CustomStudentRegistrationComponent(Model.RegistrationInformation));
                        row.ConstantItem(15);
                        row.RelativeItem().Component(new CustomStudentRegistrationOtherComponent(Model.RegistrationBioData));
                        row.ConstantItem(15);
                        using var stream = new FileStream(
                                @"C:\Users\mishr\source\repos\TestingPDF Generation\TestingPDF Generation\image.png", FileMode.Open);
                        row.RelativeItem().AlignRight().Image(stream).FitArea().FitHeight();
                    });

                    if (Model.HasResit)
                    {

                        column.Item().Element(ComposeRegularTable);
                    }
                    else
                    {
                        column.Item().Element(ComposeRegularTable);
                        column.Item().Element(ComposeResitTable);
                    }
                    

                    //var totalPrice = Model.Items.Sum(x => x.Price * x.Quantity);
                    //column.Item().AlignRight().Text($"Grand total: {totalPrice}$").FontSize(14);

                    column.Spacing(5);
                    column.Item().Row(
                        row =>
                        {
                            row.AutoItem().Padding(6).Column(c =>
                            {
                                c.Item().Padding(2).Text("Student's Signature:................................................................................... ").FontSize(10);
                                c.Item().Padding(2).Text("Academic Tutor's Signature: ....................................................................").FontSize(10);
                                c.Item().Padding(2).Text("Head of Department's Signature:....................................................................").FontSize(10);
                               
                            });

                            row.ConstantItem(5);

                            row.RelativeItem().Padding(3).Column(c =>
                            {
                                c.Item().AlignRight().Padding(2).Text("Date: ..........................................................").FontSize(10);
                                c.Item().AlignRight().Padding(2).Text("Date: ..........................................................").FontSize(10);
                                c.Item().AlignRight().Padding(2).Text("Date: ..........................................................").FontSize(10);
                                
                            });
                        });


                    column.Spacing(3);

                    column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                    column.Item().AlignCenter().Text("FINANCIAL STANDING").Bold().FontSize(10);
                    column.Item().AlignCenter().Text("ACADEMIC FACILITY USER FEES").Bold().FontSize(10);

                    column.Item().Row(
                        row =>
                        {
                            row.AutoItem().Padding(3).Column(c =>
                            {
                                c.Item().Padding(2).Text("Amount Paid in First Semester:.......................................................... ").FontSize(10);
                                c.Item().Padding(2).Text("Outstanding Amount Paid: ...............................................................").FontSize(10);
                                c.Item().Padding(2).Text("Receipt Number for Outstanding Payment:................................").FontSize(10);

                            });

                          //  row.ConstantItem(5);

                            row.RelativeItem().Padding(3).Column(c =>
                            {
                                c.Item();
                                c.Item().Padding(2)
                                    .AlignCenter()
                                    .Text(" ..........................................................")
                                    .FontSize(10);
                                c.Item().Padding(2)
                                    .AlignCenter()
                                    .Text("Faculty Finance Officer")
                                    .FontSize(10);

                            });
                        });

                    //if (!string.IsNullOrWhiteSpace(Model.Comments))
                    //    column.Item().PaddingTop(25).Element(ComposeComments);
                });
            }


            //Compose To Table
            void ComposeRegularTable(IContainer container)
            {
                container.Table(table =>
                {
                    // step 1
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    // step 2
                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Padding(2).Text("Course Code").FontSize(11);
                        header.Cell().Element(CellStyle).Padding(2).Text("Course Name").FontSize(11);
                        header.Cell().Element(CellStyle).Padding(2).AlignLeft().Text("Credit").FontSize(11);
                        header.Cell().Element(CellStyle).Padding(2).AlignRight().Text("Status").FontSize(11);
                        header.Cell().Element(CellStyle).Padding(2).AlignRight().Text("Course Instructor").FontSize(11);

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(2).BorderBottom(1)
                                .BorderColor(Colors.Black);
                        }
                    });
                    table.Cell().ColumnSpan(5).AlignCenter().PaddingBottom(5).Text("Regular Registration").Bold();
                    // step 3
                    foreach (var item in Model.Items)
                    {
                        table.Cell().Element(CellStyle).Text(Model.Items.IndexOf(item) + 1).FontSize(10);
                        table.Cell().Element(CellStyle).Text(item.Name).FontSize(10);
                        table.Cell().Element(CellStyle).AlignLeft().Text($"{item.Price}$").FontSize(10);
                        table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity).FontSize(10);
                        table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price * item.Quantity}$").FontSize(10);

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(2);
                        }
                    }

                    table.Cell().ColumnSpan(2).BorderBottom(1).AlignRight().Text("Credit Registered: ");
                    table.Cell().ColumnSpan(3).BorderBottom(1).Padding(2).Text("{18}");
                });
            }



        //Compose To Table
        void ComposeResitTable(IContainer container)
        {
            container.Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // step 2
                //table.Header(header =>
                //{
                //    header.Cell().Element(CellStyle).Padding(2).Text("Course Code").FontSize(11);
                //    header.Cell().Element(CellStyle).Padding(2).Text("Course Name").FontSize(11);
                //    header.Cell().Element(CellStyle).Padding(2).AlignLeft().Text("Credit").FontSize(11);
                //    header.Cell().Element(CellStyle).Padding(2).AlignRight().Text("Status").FontSize(11);
                //    header.Cell().Element(CellStyle).Padding(2).AlignRight().Text("Course Instructor").FontSize(11);

                //    static IContainer CellStyle(IContainer container)
                //    {
                //        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(2).BorderBottom(1)
                //            .BorderColor(Colors.Black).Border(1);
                //    }
                //});
                table.Cell().ColumnSpan(5).AlignCenter().PaddingBottom(5).Text("Special Resit Registration").Bold();
                // step 3
                foreach (var item in Model.Items)
                {
                    table.Cell().Element(CellStyle).Text(Model.Items.IndexOf(item) + 1).FontSize(10);
                    table.Cell().Element(CellStyle).Text(item.Name).FontSize(10);
                    table.Cell().Element(CellStyle).AlignLeft().Text($"{item.Price}$").FontSize(10);
                    table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity).FontSize(10);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price * item.Quantity}$").FontSize(10);

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(2);
                    }
                }

                table.Cell().ColumnSpan(2).BorderBottom(1).AlignRight().Text("Credit Registered: ");
                table.Cell().ColumnSpan(3).BorderBottom(1).Padding(2).Text("{18}");
            });
        }



        void ComposeComments(IContainer container)
            {
                container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
                {
                    column.Spacing(5);
                    column.Item().Text("Comments").FontSize(14);
                    column.Item().Text(Model.Comments);
                });
            }

        }
    }

