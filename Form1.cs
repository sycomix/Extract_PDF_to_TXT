using System;
using System.IO;
using System.Windows.Forms;
//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;
using System.ComponentModel;
using Path = System.IO.Path;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;



namespace Extract_PDF_to_TXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //progressBar_pdf2txt.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            string pdfPath = txtPdfPath.Text.Trim();
            string outputFolder = txtOutputFolder.Text.Trim();

            if (string.IsNullOrEmpty(pdfPath) || string.IsNullOrEmpty(outputFolder))
            {
                MessageBox.Show("Please enter the full path!", "Error selecting PDF file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(pdfPath))
            {
                MessageBox.Show("PDF file does not exist!", "Error selecting Extract folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            progressBar_pdf2txt.Value = 0;
            progressBar_pdf2txt.Visible = true;
            btnExtract.Enabled = false;

            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.DoWork += (s, args) => ExtractPdfToTxt(pdfPath, outputFolder, bgWorker);
            bgWorker.ProgressChanged += (s, args) => progressBar_pdf2txt.Value = args.ProgressPercentage;
            bgWorker.RunWorkerCompleted += (s, args) =>
            {
                progressBar_pdf2txt.Visible = false;
                btnExtract.Enabled = true;
                MessageBox.Show("Extraction successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            bgWorker.RunWorkerAsync();
        }
        private void ExtractPdfToTxt(string pdfPath, string outputFolder, BackgroundWorker bgWorker)
        {
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pdfPath);
            string txtFilePath = Path.Combine(outputFolder, fileNameWithoutExt + ".txt");

            using (PdfReader reader = new PdfReader(pdfPath))
            using (PdfDocument pdfDoc = new PdfDocument(reader))
            using (StreamWriter writer = new StreamWriter(txtFilePath, false))
            {
                int totalPages = pdfDoc.GetNumberOfPages();

                for (int i = 1; i <= totalPages; i++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                    writer.WriteLine(text);

                    int progress = (int)((i / (float)totalPages) * 100);
                    bgWorker.ReportProgress(progress);
                }
            }
        }
        private void txtPdfPath_TextChanged(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files|*.pdf";
                openFileDialog.Title = "Select PDF file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPdfPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void txtOutputFolder_TextChanged(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save the TXT file";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutputFolder.Text = folderDialog.SelectedPath;
                }
            }
        }
    }
}
