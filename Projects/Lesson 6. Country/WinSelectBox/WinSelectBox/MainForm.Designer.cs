namespace WinSelectBox
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
            myTextInput = new TextBox();
            label1 = new Label();
            btnAdd = new Button();
            cbCountries = new ComboBox();
            pbImage = new PictureBox();
            txtImagePath = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // myTextInput
            // 
            myTextInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            myTextInput.Location = new Point(27, 119);
            myTextInput.Name = "myTextInput";
            myTextInput.PlaceholderText = "Вкажіть назву країни ...";
            myTextInput.Size = new Size(328, 39);
            myTextInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(27, 80);
            label1.Name = "label1";
            label1.Size = new Size(169, 32);
            label1.TabIndex = 1;
            label1.Text = "Назва країни";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(400, 102);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 56);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbCountries
            // 
            cbCountries.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountries.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbCountries.FormattingEnabled = true;
            cbCountries.Location = new Point(27, 180);
            cbCountries.Name = "cbCountries";
            cbCountries.Size = new Size(328, 40);
            cbCountries.TabIndex = 3;
            // 
            // pbImage
            // 
            pbImage.Location = new Point(604, 102);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(141, 97);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage.TabIndex = 4;
            pbImage.TabStop = false;
            // 
            // txtImagePath
            // 
            txtImagePath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtImagePath.Location = new Point(27, 38);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.PlaceholderText = "Вкажіть шлях до файлу ...";
            txtImagePath.Size = new Size(718, 39);
            txtImagePath.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(27, -1);
            label2.Name = "label2";
            label2.Size = new Size(190, 32);
            label2.TabIndex = 1;
            label2.Text = "Прапор країни";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbImage);
            Controls.Add(cbCountries);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtImagePath);
            Controls.Add(myTextInput);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox myTextInput;
        private Label label1;
        private Button btnAdd;
        private ComboBox cbCountries;
        private PictureBox pbImage;
        private TextBox txtImagePath;
        private Label label2;
    }
}
