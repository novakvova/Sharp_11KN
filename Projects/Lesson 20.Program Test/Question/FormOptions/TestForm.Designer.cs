namespace FormOptions
{
    partial class TestForm
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
            btnChangeStyles = new Button();
            label1 = new Label();
            lbQuestion = new Label();
            btnCont = new Button();
            rdBtnAnswer1 = new RadioButton();
            rdBtnAnswer2 = new RadioButton();
            rdBtnAnswer3 = new RadioButton();
            rdBtnAnswer4 = new RadioButton();
            lbTimerQuestion = new Label();
            lbTimerTotal = new Label();
            SuspendLayout();
            // 
            // btnChangeStyles
            // 
            btnChangeStyles.BackColor = Color.White;
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChangeStyles.Location = new Point(114, 453);
            btnChangeStyles.Margin = new Padding(4, 5, 4, 5);
            btnChangeStyles.Name = "btnChangeStyles";
            btnChangeStyles.Size = new Size(121, 58);
            btnChangeStyles.TabIndex = 0;
            btnChangeStyles.Text = "Темна";
            btnChangeStyles.UseVisualStyleBackColor = false;
            btnChangeStyles.Click += btnChangeStyles_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(17, 463);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 32);
            label1.TabIndex = 2;
            label1.Text = "ТЕМА :";
            // 
            // lbQuestion
            // 
            lbQuestion.AutoSize = true;
            lbQuestion.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbQuestion.ForeColor = Color.Black;
            lbQuestion.Location = new Point(17, 15);
            lbQuestion.Margin = new Padding(4, 0, 4, 0);
            lbQuestion.Name = "lbQuestion";
            lbQuestion.Size = new Size(983, 41);
            lbQuestion.TabIndex = 3;
            lbQuestion.Text = "Яка подія вважається офіційним початком Другої світової війни?";
            // 
            // btnCont
            // 
            btnCont.BackColor = Color.White;
            btnCont.FlatAppearance.BorderSize = 0;
            btnCont.FlatStyle = FlatStyle.Flat;
            btnCont.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCont.Location = new Point(866, 440);
            btnCont.Margin = new Padding(4, 5, 4, 5);
            btnCont.Name = "btnCont";
            btnCont.Size = new Size(179, 72);
            btnCont.TabIndex = 4;
            btnCont.Text = "Продовжити";
            btnCont.UseVisualStyleBackColor = false;
            btnCont.Click += btnCont_Click;
            // 
            // rdBtnAnswer1
            // 
            rdBtnAnswer1.AutoSize = true;
            rdBtnAnswer1.Font = new Font("Segoe UI", 15F);
            rdBtnAnswer1.Location = new Point(17, 82);
            rdBtnAnswer1.Margin = new Padding(4, 5, 4, 5);
            rdBtnAnswer1.Name = "rdBtnAnswer1";
            rdBtnAnswer1.Size = new Size(257, 45);
            rdBtnAnswer1.TabIndex = 5;
            rdBtnAnswer1.TabStop = true;
            rdBtnAnswer1.Text = "Аншлюз Австрії";
            rdBtnAnswer1.UseVisualStyleBackColor = true;
            // 
            // rdBtnAnswer2
            // 
            rdBtnAnswer2.AutoSize = true;
            rdBtnAnswer2.Font = new Font("Segoe UI", 15F);
            rdBtnAnswer2.Location = new Point(17, 145);
            rdBtnAnswer2.Margin = new Padding(4, 5, 4, 5);
            rdBtnAnswer2.Name = "rdBtnAnswer2";
            rdBtnAnswer2.Size = new Size(443, 45);
            rdBtnAnswer2.TabIndex = 6;
            rdBtnAnswer2.TabStop = true;
            rdBtnAnswer2.Text = "Напад Німеччини на Польщу";
            rdBtnAnswer2.UseVisualStyleBackColor = true;
            // 
            // rdBtnAnswer3
            // 
            rdBtnAnswer3.AutoSize = true;
            rdBtnAnswer3.Font = new Font("Segoe UI", 15F);
            rdBtnAnswer3.Location = new Point(17, 208);
            rdBtnAnswer3.Margin = new Padding(4, 5, 4, 5);
            rdBtnAnswer3.Name = "rdBtnAnswer3";
            rdBtnAnswer3.Size = new Size(358, 45);
            rdBtnAnswer3.TabIndex = 7;
            rdBtnAnswer3.TabStop = true;
            rdBtnAnswer3.Text = "Напад на Перл-Гарбор";
            rdBtnAnswer3.UseVisualStyleBackColor = true;
            // 
            // rdBtnAnswer4
            // 
            rdBtnAnswer4.AutoSize = true;
            rdBtnAnswer4.Font = new Font("Segoe UI", 15F);
            rdBtnAnswer4.Location = new Point(17, 272);
            rdBtnAnswer4.Margin = new Padding(4, 5, 4, 5);
            rdBtnAnswer4.Name = "rdBtnAnswer4";
            rdBtnAnswer4.Size = new Size(616, 45);
            rdBtnAnswer4.TabIndex = 8;
            rdBtnAnswer4.TabStop = true;
            rdBtnAnswer4.Text = "Підписання Пакту Молотова-Ріббентропа";
            rdBtnAnswer4.UseVisualStyleBackColor = true;
            // 
            // lbTimerQuestion
            // 
            lbTimerQuestion.AutoSize = true;
            lbTimerQuestion.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbTimerQuestion.ForeColor = Color.Green;
            lbTimerQuestion.Location = new Point(17, 360);
            lbTimerQuestion.Name = "lbTimerQuestion";
            lbTimerQuestion.Size = new Size(242, 30);
            lbTimerQuestion.TabIndex = 9;
            lbTimerQuestion.Text = "Час на питання: 00:30";
            // 
            // lbTimerTotal
            // 
            lbTimerTotal.AutoSize = true;
            lbTimerTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbTimerTotal.ForeColor = Color.Green;
            lbTimerTotal.Location = new Point(17, 395);
            lbTimerTotal.Name = "lbTimerTotal";
            lbTimerTotal.Size = new Size(267, 30);
            lbTimerTotal.TabIndex = 10;
            lbTimerTotal.Text = "Загальний час: 02:30";

            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1061, 532);
            Controls.Add(lbTimerTotal);
            Controls.Add(lbTimerQuestion);
            Controls.Add(rdBtnAnswer4);
            Controls.Add(rdBtnAnswer3);
            Controls.Add(rdBtnAnswer2);
            Controls.Add(rdBtnAnswer1);
            Controls.Add(btnCont);
            Controls.Add(lbQuestion);
            Controls.Add(label1);
            Controls.Add(btnChangeStyles);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "TestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Тест";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChangeStyles;
        private Label label1;
        private Label lbQuestion;
        private Button btnCont;
        private RadioButton rdBtnAnswer1;
        private RadioButton rdBtnAnswer2;
        private RadioButton rdBtnAnswer3;
        private RadioButton rdBtnAnswer4;
        private Label lbTimerQuestion;
        private Label lbTimerTotal;
    }
}
