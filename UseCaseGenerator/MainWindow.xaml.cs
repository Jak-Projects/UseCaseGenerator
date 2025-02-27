// MainWindow.xaml.cs
using System;
using System.Windows;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using UseCaseGenerator.ViewModel;

namespace UseCaseGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveAsPdf_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)DataContext;
            if (viewModel?.UseCase == null) return;

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                DefaultExt = "pdf",
                FileName = $"UseCase_{viewModel.UseCase.IdTitle}.pdf"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (var writer = new PdfWriter(saveFileDialog.FileName))
                    using (var pdf = new PdfDocument(writer))
                    using (var document = new Document(pdf))
                    {
                        var table = new Table(2);
                        table.AddCell(new Cell().Add(new Paragraph("Field")));
                        table.AddCell(new Cell().Add(new Paragraph("Value")));

                        table.AddCell(new Cell().Add(new Paragraph("Use Case ID & Title")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.IdTitle ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Intent")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.Intent ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Scope & Level")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.ScopeLevel ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Author & Last Update")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.AuthorLastUpdate ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Status")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.Status ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Primary Actors")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.PrimaryActors ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Secondary Actors")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.SecondaryActors ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Preconditions")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.Preconditions ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Dynamic Preconditions")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.DynamicPreconditions ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Assumptions")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.Assumptions ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Success Post Condition")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.SuccessPostCondition ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Failure Condition")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.FailureCondition ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Trigger")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.Trigger ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Operations")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.Operations ?? "N/A")));
                        table.AddCell(new Cell().Add(new Paragraph("Operations Concepts")));
                        table.AddCell(new Cell().Add(new Paragraph(viewModel.UseCase.OperationsConcepts ?? "N/A")));

                        document.Add(table); //t2d
                    }

                    MessageBox.Show("PDF saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving PDF: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}