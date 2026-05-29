namespace WinAppPDR
{
    partial class CreateQuestionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnSkip = new Button();
            gpListAnswers = new GroupBox();
            lblQuestion = new Label();
            pbImage = new PictureBox();
            pnlOptions = new Panel();
            btnSubmit = new Button();
            btnChangeStyles = new Button();
            label1 = new Label();
            txtAnswer = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // btnSkip
            // 
            btnSkip.FlatAppearance.BorderSize = 0;
            btnSkip.FlatStyle = FlatStyle.Flat;
            btnSkip.Location = new Point(20, 702);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(200, 50);
            btnSkip.TabIndex = 5;
            btnSkip.Text = "Пропустити";
            btnSkip.Click += BtnSkip_Click;
            // 
            // gpListAnswers
            // 
            gpListAnswers.Location = new Point(20, 20);
            gpListAnswers.Name = "gpListAnswers";
            gpListAnswers.Size = new Size(1060, 100);
            gpListAnswers.TabIndex = 0;
            gpListAnswers.TabStop = false;
            gpListAnswers.Text = "Список питань";
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblQuestion.Location = new Point(20, 292);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(1060, 80);
            lblQuestion.TabIndex = 1;
            // 
            // pbImage
            // 
            pbImage.Location = new Point(20, 382);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(500, 300);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 2;
            pbImage.TabStop = false;
            // 
            // pnlOptions
            // 
            pnlOptions.Location = new Point(550, 382);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(500, 300);
            pnlOptions.TabIndex = 3;
            // 
            // btnSubmit
            // 
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Location = new Point(269, 702);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(200, 50);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Обрати";
            btnSubmit.Visible = false;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // btnChangeStyles
            // 
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.Location = new Point(900, 702);
            btnChangeStyles.Name = "btnChangeStyles";
            btnChangeStyles.Size = new Size(150, 50);
            btnChangeStyles.TabIndex = 6;
            btnChangeStyles.Text = "Світла тема";
            btnChangeStyles.Click += btnChangeStyles_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(20, 136);
            label1.Name = "label1";
            label1.Size = new Size(182, 32);
            label1.TabIndex = 7;
            label1.Text = "Питання тесту";
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(20, 171);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(1039, 90);
            txtAnswer.TabIndex = 8;
            // 
            // CreateQuestionForm
            // 
            ClientSize = new Size(1129, 761);
            Controls.Add(txtAnswer);
            Controls.Add(label1);
            Controls.Add(gpListAnswers);
            Controls.Add(lblQuestion);
            Controls.Add(pbImage);
            Controls.Add(pnlOptions);
            Controls.Add(btnSubmit);
            Controls.Add(btnSkip);
            Controls.Add(btnChangeStyles);
            Name = "CreateQuestionForm";
            Text = "Створення тесту";
            Load += QuestionForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnChangeStyles;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.GroupBox gpListAnswers;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnSubmit;
        private Label label1;
        private TextBox txtAnswer;
    }
}