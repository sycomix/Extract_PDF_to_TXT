namespace Extract_PDF_to_TXT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnExtract = new Button();
            txtPdfPath = new TextBox();
            txtOutputFolder = new TextBox();
            progressBar_pdf2txt = new ProgressBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnExtract
            // 
            btnExtract.Location = new Point(490, 70);
            btnExtract.Name = "btnExtract";
            btnExtract.Size = new Size(122, 42);
            btnExtract.TabIndex = 0;
            btnExtract.Text = "Extract PDF";
            btnExtract.UseVisualStyleBackColor = true;
            btnExtract.Click += btnExtract_Click;
            // 
            // txtPdfPath
            // 
            txtPdfPath.Location = new Point(12, 12);
            txtPdfPath.Name = "txtPdfPath";
            txtPdfPath.PlaceholderText = "Choose file PDF";
            txtPdfPath.Size = new Size(600, 23);
            txtPdfPath.TabIndex = 1;
            txtPdfPath.Click += txtPdfPath_TextChanged;
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Location = new Point(12, 41);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.PlaceholderText = "Folder Extract PDF to TXT";
            txtOutputFolder.Size = new Size(600, 23);
            txtOutputFolder.TabIndex = 2;
            txtOutputFolder.Click += txtOutputFolder_TextChanged;
            // 
            // progressBar_pdf2txt
            // 
            progressBar_pdf2txt.Location = new Point(12, 61);
            progressBar_pdf2txt.Name = "progressBar_pdf2txt";
            progressBar_pdf2txt.Size = new Size(600, 3);
            progressBar_pdf2txt.TabIndex = 3;
            progressBar_pdf2txt.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 78);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 4;
            label1.Text = "Only used for PDF";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 135);
            Controls.Add(label1);
            Controls.Add(progressBar_pdf2txt);
            Controls.Add(txtOutputFolder);
            Controls.Add(txtPdfPath);
            Controls.Add(btnExtract);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Extract PDF to TXT";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExtract;
        private TextBox txtPdfPath;
        private TextBox txtOutputFolder;
        private ProgressBar progressBar_pdf2txt;
        private Label label1;
    }
}
