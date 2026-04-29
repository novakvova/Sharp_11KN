namespace FormOptions
{
    partial class RegisterForm
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
            label2 = new Label();
            txtFirstName = new TextBox();
            label3 = new Label();
            txtLastName = new TextBox();
            txtGroup = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            txtPassword = new TextBox();
            label7 = new Label();
            ConfigmPassword = new TextBox();
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
            lbQuestion.Location = new Point(370, 9);
            lbQuestion.Margin = new Padding(4, 0, 4, 0);
            lbQuestion.Name = "lbQuestion";
            lbQuestion.Size = new Size(361, 41);
            lbQuestion.TabIndex = 3;
            lbQuestion.Text = "Стоврити новий акаунт";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(17, 68);
            label2.Name = "label2";
            label2.Size = new Size(62, 32);
            label2.TabIndex = 4;
            label2.Text = "Ім'я";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtFirstName.Location = new Point(17, 112);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(489, 39);
            txtFirstName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(12, 173);
            label3.Name = "label3";
            label3.Size = new Size(130, 32);
            label3.TabIndex = 4;
            label3.Text = "Прізвище";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLastName.Location = new Point(12, 217);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(489, 39);
            txtLastName.TabIndex = 5;
            // 
            // txtGroup
            // 
            txtGroup.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtGroup.Location = new Point(546, 112);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(489, 39);
            txtGroup.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(546, 68);
            label4.Name = "label4";
            label4.Size = new Size(80, 32);
            label4.TabIndex = 6;
            label4.Text = "Група";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(546, 173);
            label5.Name = "label5";
            label5.Size = new Size(233, 32);
            label5.TabIndex = 6;
            label5.Text = "Електронна пошта";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtEmail.Location = new Point(546, 217);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(489, 39);
            txtEmail.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.Blue;
            label6.Location = new Point(12, 276);
            label6.Name = "label6";
            label6.Size = new Size(102, 32);
            label6.TabIndex = 4;
            label6.Text = "Пароль";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPassword.Location = new Point(12, 320);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(489, 39);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.Blue;
            label7.Location = new Point(546, 276);
            label7.Name = "label7";
            label7.Size = new Size(195, 32);
            label7.TabIndex = 4;
            label7.Text = "Повтор пароля";
            // 
            // ConfigmPassword
            // 
            ConfigmPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ConfigmPassword.Location = new Point(546, 320);
            ConfigmPassword.Name = "ConfigmPassword";
            ConfigmPassword.Size = new Size(489, 39);
            ConfigmPassword.TabIndex = 5;
            ConfigmPassword.UseSystemPasswordChar = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1061, 532);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(txtGroup);
            Controls.Add(label4);
            Controls.Add(ConfigmPassword);
            Controls.Add(label7);
            Controls.Add(txtPassword);
            Controls.Add(label6);
            Controls.Add(txtLastName);
            Controls.Add(label3);
            Controls.Add(txtFirstName);
            Controls.Add(label2);
            Controls.Add(lbQuestion);
            Controls.Add(label1);
            Controls.Add(btnChangeStyles);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "RegisterForm";
            Text = "Реєстарція користувача";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChangeStyles;
        private Label label1;
        private Label lbQuestion;
        private Label label2;
        private TextBox txtFirstName;
        private Label label3;
        private TextBox txtLastName;
        private TextBox txtGroup;
        private Label label4;
        private Label label5;
        private TextBox txtEmail;
        private Label label6;
        private TextBox txtPassword;
        private Label label7;
        private TextBox ConfigmPassword;
    }
}
