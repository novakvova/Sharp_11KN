namespace FormOptions
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lbPIB = new Label();
            btnExit = new Button();
            btnRunTest = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(254, 35);
            label1.Name = "label1";
            label1.Size = new Size(586, 48);
            label1.TabIndex = 0;
            label1.Text = "Програма для тестування - ЖУК";
            // 
            // lbPIB
            // 
            lbPIB.AutoSize = true;
            lbPIB.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbPIB.ForeColor = Color.Green;
            lbPIB.Location = new Point(45, 119);
            lbPIB.Name = "lbPIB";
            lbPIB.Size = new Size(281, 45);
            lbPIB.TabIndex = 1;
            lbPIB.Text = "ПІБ користувача";
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnExit.ForeColor = Color.Red;
            btnExit.Location = new Point(935, 23);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(134, 60);
            btnExit.TabIndex = 2;
            btnExit.Text = "Вихід";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnRunTest
            // 
            btnRunTest.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRunTest.ForeColor = Color.Blue;
            btnRunTest.Location = new Point(45, 190);
            btnRunTest.Name = "btnRunTest";
            btnRunTest.Size = new Size(410, 58);
            btnRunTest.TabIndex = 3;
            btnRunTest.Text = "Пройти тест";
            btnRunTest.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 612);
            Controls.Add(btnRunTest);
            Controls.Add(btnExit);
            Controls.Add(lbPIB);
            Controls.Add(label1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbPIB;
        private Button btnExit;
        private Button btnRunTest;
    }
}