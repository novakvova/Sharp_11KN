namespace WinAppPDR
{
    partial class CreateCustomTestForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateCustomTestForm));
            txtQuestion = new TextBox();
            lbQuestion = new Label();
            lbError1 = new Label();
            txtAnswer1 = new TextBox();
            txtAnswer2 = new TextBox();
            txtAnswer3 = new TextBox();
            txtAnswer4 = new TextBox();
            rdBtnAnswer1 = new RadioButton();
            rdBtnAnswer2 = new RadioButton();
            rdBtnAnswer3 = new RadioButton();
            rdBtnAnswer4 = new RadioButton();
            btnNextQuestion = new Button();
            btnDone = new Button();
            btnImage = new Button();
            txtImage = new TextBox();
            lbImage = new Label();
            SuspendLayout();
            // 
            // txtQuestion
            // 
            txtQuestion.BackColor = Color.FromArgb(237, 239, 241);
            txtQuestion.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtQuestion, "txtQuestion");
            txtQuestion.ForeColor = Color.Black;
            txtQuestion.Name = "txtQuestion";
            // 
            // lbQuestion
            // 
            resources.ApplyResources(lbQuestion, "lbQuestion");
            lbQuestion.Name = "lbQuestion";
            // 
            // lbError1
            // 
            resources.ApplyResources(lbError1, "lbError1");
            lbError1.ForeColor = Color.Red;
            lbError1.Name = "lbError1";
            // 
            // txtAnswer1
            // 
            txtAnswer1.BackColor = Color.FromArgb(237, 239, 241);
            txtAnswer1.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtAnswer1, "txtAnswer1");
            txtAnswer1.ForeColor = Color.Black;
            txtAnswer1.Name = "txtAnswer1";
            // 
            // txtAnswer2
            // 
            txtAnswer2.BackColor = Color.FromArgb(237, 239, 241);
            txtAnswer2.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtAnswer2, "txtAnswer2");
            txtAnswer2.ForeColor = Color.Black;
            txtAnswer2.Name = "txtAnswer2";
            // 
            // txtAnswer3
            // 
            txtAnswer3.BackColor = Color.FromArgb(237, 239, 241);
            txtAnswer3.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtAnswer3, "txtAnswer3");
            txtAnswer3.ForeColor = Color.Black;
            txtAnswer3.Name = "txtAnswer3";
            // 
            // txtAnswer4
            // 
            txtAnswer4.BackColor = Color.FromArgb(237, 239, 241);
            txtAnswer4.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtAnswer4, "txtAnswer4");
            txtAnswer4.ForeColor = Color.Black;
            txtAnswer4.Name = "txtAnswer4";
            // 
            // rdBtnAnswer1
            // 
            resources.ApplyResources(rdBtnAnswer1, "rdBtnAnswer1");
            rdBtnAnswer1.Name = "rdBtnAnswer1";
            // 
            // rdBtnAnswer2
            // 
            resources.ApplyResources(rdBtnAnswer2, "rdBtnAnswer2");
            rdBtnAnswer2.Name = "rdBtnAnswer2";
            // 
            // rdBtnAnswer3
            // 
            resources.ApplyResources(rdBtnAnswer3, "rdBtnAnswer3");
            rdBtnAnswer3.Name = "rdBtnAnswer3";
            // 
            // rdBtnAnswer4
            // 
            resources.ApplyResources(rdBtnAnswer4, "rdBtnAnswer4");
            rdBtnAnswer4.Name = "rdBtnAnswer4";
            // 
            // btnNextQuestion
            // 
            resources.ApplyResources(btnNextQuestion, "btnNextQuestion");
            btnNextQuestion.Name = "btnNextQuestion";
            // 
            // btnDone
            // 
            resources.ApplyResources(btnDone, "btnDone");
            btnDone.Name = "btnDone";
            // 
            // btnImage
            // 
            btnImage.BackColor = Color.White;
            resources.ApplyResources(btnImage, "btnImage");
            btnImage.Name = "btnImage";
            btnImage.UseVisualStyleBackColor = false;
            // 
            // txtImage
            // 
            txtImage.BackColor = Color.FromArgb(237, 239, 241);
            txtImage.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtImage, "txtImage");
            txtImage.ForeColor = Color.Black;
            txtImage.Name = "txtImage";
            // 
            // lbImage
            // 
            resources.ApplyResources(lbImage, "lbImage");
            lbImage.Name = "lbImage";
            // 
            // CreateCustomTestForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 239, 241);
            Controls.Add(btnDone);
            Controls.Add(btnNextQuestion);
            Controls.Add(btnImage);
            Controls.Add(lbImage);
            Controls.Add(txtImage);
            Controls.Add(rdBtnAnswer4);
            Controls.Add(rdBtnAnswer3);
            Controls.Add(rdBtnAnswer2);
            Controls.Add(rdBtnAnswer1);
            Controls.Add(txtAnswer4);
            Controls.Add(txtAnswer3);
            Controls.Add(txtAnswer2);
            Controls.Add(txtAnswer1);
            Controls.Add(lbError1);
            Controls.Add(lbQuestion);
            Controls.Add(txtQuestion);
            Name = "CreateCustomTestForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.Label lbError1;
        private System.Windows.Forms.TextBox txtAnswer1;
        private System.Windows.Forms.TextBox txtAnswer2;
        private System.Windows.Forms.TextBox txtAnswer3;
        private System.Windows.Forms.TextBox txtAnswer4;
        private System.Windows.Forms.RadioButton rdBtnAnswer1;
        private System.Windows.Forms.RadioButton rdBtnAnswer2;
        private System.Windows.Forms.RadioButton rdBtnAnswer3;
        private System.Windows.Forms.RadioButton rdBtnAnswer4;
        private System.Windows.Forms.Button btnNextQuestion;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Label lbImage;
    }
}
