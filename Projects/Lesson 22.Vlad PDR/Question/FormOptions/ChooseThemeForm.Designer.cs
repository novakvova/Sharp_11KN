namespace WinFormsApp1
{
    partial class ChooseThemeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseThemeForm));
            lb1 = new Label();
            lb2 = new Label();
            rdBtnDarkTheme = new RadioButton();
            bgPicBoxDarkTheme = new Label();
            picBoxDarkTheme = new PictureBox();
            picBoxLightTheme = new PictureBox();
            bgPicBoxLightTheme = new Label();
            rdBtnLightTheme = new RadioButton();
            bgChooseThemeForm = new Label();
            btnCancel = new Button();
            btnApply = new Button();
            ((System.ComponentModel.ISupportInitialize)picBoxDarkTheme).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxLightTheme).BeginInit();
            SuspendLayout();
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lb1.ForeColor = Color.Black;
            lb1.Location = new Point(148, 34);
            lb1.Name = "lb1";
            lb1.Size = new Size(507, 38);
            lb1.TabIndex = 2;
            lb1.Text = "Вітаємо! Спершу оберіть вашу тему";
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lb2.ForeColor = Color.Black;
            lb2.Location = new Point(105, 99);
            lb2.Name = "lb2";
            lb2.Size = new Size(590, 19);
            lb2.TabIndex = 3;
            lb2.Text = "Застосуйте тему, якій надаєте перевагу. Ви зможете будь-коли змінити в меню програми.";
            // 
            // rdBtnDarkTheme
            // 
            rdBtnDarkTheme.BackColor = Color.FromArgb(237, 239, 241);
            rdBtnDarkTheme.FlatStyle = FlatStyle.Flat;
            rdBtnDarkTheme.ForeColor = Color.Black;
            rdBtnDarkTheme.Location = new Point(444, 346);
            rdBtnDarkTheme.Name = "rdBtnDarkTheme";
            rdBtnDarkTheme.Size = new Size(272, 35);
            rdBtnDarkTheme.TabIndex = 9;
            rdBtnDarkTheme.Text = "🌙 Темна";
            rdBtnDarkTheme.UseVisualStyleBackColor = false;
            // 
            // bgPicBoxDarkTheme
            // 
            bgPicBoxDarkTheme.BackColor = Color.FromArgb(64, 64, 64);
            bgPicBoxDarkTheme.Location = new Point(444, 171);
            bgPicBoxDarkTheme.Name = "bgPicBoxDarkTheme";
            bgPicBoxDarkTheme.Size = new Size(272, 172);
            bgPicBoxDarkTheme.TabIndex = 15;
            // 
            // picBoxDarkTheme
            // 
            picBoxDarkTheme.Image = (Image)resources.GetObject("picBoxDarkTheme.Image");
            picBoxDarkTheme.InitialImage = (Image)resources.GetObject("picBoxDarkTheme.InitialImage");
            picBoxDarkTheme.Location = new Point(457, 186);
            picBoxDarkTheme.Name = "picBoxDarkTheme";
            picBoxDarkTheme.Size = new Size(247, 143);
            picBoxDarkTheme.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxDarkTheme.TabIndex = 16;
            picBoxDarkTheme.TabStop = false;
            // 
            // picBoxLightTheme
            // 
            picBoxLightTheme.Image = (Image)resources.GetObject("picBoxLightTheme.Image");
            picBoxLightTheme.InitialImage = (Image)resources.GetObject("picBoxLightTheme.InitialImage");
            picBoxLightTheme.Location = new Point(98, 186);
            picBoxLightTheme.Name = "picBoxLightTheme";
            picBoxLightTheme.Size = new Size(247, 143);
            picBoxLightTheme.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxLightTheme.TabIndex = 19;
            picBoxLightTheme.TabStop = false;
            // 
            // bgPicBoxLightTheme
            // 
            bgPicBoxLightTheme.BackColor = Color.White;
            bgPicBoxLightTheme.Location = new Point(85, 171);
            bgPicBoxLightTheme.Name = "bgPicBoxLightTheme";
            bgPicBoxLightTheme.Size = new Size(272, 172);
            bgPicBoxLightTheme.TabIndex = 18;
            // 
            // rdBtnLightTheme
            // 
            rdBtnLightTheme.BackColor = Color.FromArgb(237, 239, 241);
            rdBtnLightTheme.Checked = true;
            rdBtnLightTheme.FlatStyle = FlatStyle.Flat;
            rdBtnLightTheme.ForeColor = Color.Black;
            rdBtnLightTheme.Location = new Point(85, 346);
            rdBtnLightTheme.Name = "rdBtnLightTheme";
            rdBtnLightTheme.Size = new Size(272, 35);
            rdBtnLightTheme.TabIndex = 17;
            rdBtnLightTheme.TabStop = true;
            rdBtnLightTheme.Text = "🔅 Світла";
            rdBtnLightTheme.UseVisualStyleBackColor = false;
            // 
            // bgChooseThemeForm
            // 
            bgChooseThemeForm.BackColor = Color.FromArgb(228, 230, 233);
            bgChooseThemeForm.Location = new Point(-7, 410);
            bgChooseThemeForm.Name = "bgChooseThemeForm";
            bgChooseThemeForm.Size = new Size(814, 102);
            bgChooseThemeForm.TabIndex = 20;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(528, 431);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 50);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Відміна";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.White;
            btnApply.Cursor = Cursors.Hand;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.ForeColor = Color.Black;
            btnApply.Location = new Point(651, 431);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(126, 50);
            btnApply.TabIndex = 21;
            btnApply.Text = "Застосувати";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // ChooseThemeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 239, 241);
            ClientSize = new Size(800, 504);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(bgChooseThemeForm);
            Controls.Add(picBoxLightTheme);
            Controls.Add(bgPicBoxLightTheme);
            Controls.Add(rdBtnLightTheme);
            Controls.Add(picBoxDarkTheme);
            Controls.Add(bgPicBoxDarkTheme);
            Controls.Add(rdBtnDarkTheme);
            Controls.Add(lb2);
            Controls.Add(lb1);
            MaximizeBox = false;
            Name = "ChooseThemeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Тема програми";
            Load += ChooseThemeForm_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxDarkTheme).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxLightTheme).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb1;
        private Label lb2;
        private RadioButton rdBtnDarkTheme;
        private Label bgPicBoxDarkTheme;
        private PictureBox picBoxDarkTheme;
        private PictureBox picBoxLightTheme;
        private Label bgPicBoxLightTheme;
        private RadioButton rdBtnLightTheme;
        private Label bgChooseThemeForm;
        private Button btnCancel;
        private Button btnApply;
    }
}
