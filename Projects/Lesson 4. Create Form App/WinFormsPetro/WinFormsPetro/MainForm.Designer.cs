namespace WinFormsPetro
{
    partial class MainForm
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
            btnPlus = new Button();
            txtA = new TextBox();
            txtB = new TextBox();
            lbResult = new Label();
            SuspendLayout();
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(245, 28);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(112, 34);
            btnPlus.TabIndex = 0;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += btnPlus_Click;
            // 
            // txtA
            // 
            txtA.Location = new Point(21, 28);
            txtA.Name = "txtA";
            txtA.Size = new Size(150, 31);
            txtA.TabIndex = 1;
            // 
            // txtB
            // 
            txtB.Location = new Point(21, 76);
            txtB.Name = "txtB";
            txtB.Size = new Size(150, 31);
            txtB.TabIndex = 2;
            // 
            // lbResult
            // 
            lbResult.AutoSize = true;
            lbResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbResult.ForeColor = Color.Blue;
            lbResult.Location = new Point(21, 146);
            lbResult.Name = "lbResult";
            lbResult.Size = new Size(148, 38);
            lbResult.TabIndex = 3;
            lbResult.Text = "Результат";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 390);
            Controls.Add(lbResult);
            Controls.Add(txtB);
            Controls.Add(txtA);
            Controls.Add(btnPlus);
            Name = "MainForm";
            Text = "Калькулятор";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlus;
        private TextBox txtA;
        private TextBox txtB;
        private Label lbResult;
    }
}
