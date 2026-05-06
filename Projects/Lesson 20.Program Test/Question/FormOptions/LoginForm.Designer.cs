namespace FormOptions
{
    partial class LoginForm
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
            label5 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            label11 = new Label();
            label12 = new Label();
            btnVissiblePassword = new Button();
            btnToLogin = new Button();
            SuspendLayout();
            // 
            // btnChangeStyles
            // 
            btnChangeStyles.BackColor = Color.White;
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChangeStyles.Location = new Point(925, 9);
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
            label1.Location = new Point(829, 19);
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
            lbQuestion.Size = new Size(273, 41);
            lbQuestion.TabIndex = 3;
            lbQuestion.Text = "Вхід у застосунок";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(58, 90);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(115, 41);
            label5.TabIndex = 3;
            label5.Text = "Пошта";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtEmail.Location = new Point(58, 157);
            txtEmail.Margin = new Padding(4);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(399, 53);
            txtEmail.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(586, 93);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(129, 41);
            label6.TabIndex = 3;
            label6.Text = "Пароль";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtPassword.Location = new Point(586, 164);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(399, 44);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLogin.Location = new Point(555, 390);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(166, 71);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Вхід";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnSave_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(58, 221);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(233, 30);
            label11.TabIndex = 3;
            label11.Tag = "error";
            label11.Text = "Вкажіть вашу пошту";
            label11.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(586, 222);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(231, 30);
            label12.TabIndex = 3;
            label12.Tag = "error";
            label12.Text = "Вкажіть ваш пароль";
            label12.Visible = false;
            // 
            // btnVissiblePassword
            // 
            btnVissiblePassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnVissiblePassword.Location = new Point(984, 162);
            btnVissiblePassword.Margin = new Padding(4);
            btnVissiblePassword.Name = "btnVissiblePassword";
            btnVissiblePassword.Size = new Size(41, 48);
            btnVissiblePassword.TabIndex = 6;
            btnVissiblePassword.Text = "👁️";
            btnVissiblePassword.UseVisualStyleBackColor = true;
            btnVissiblePassword.Click += btnVissiblePassword_Click;
            // 
            // btnToLogin
            // 
            btnToLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnToLogin.Location = new Point(220, 390);
            btnToLogin.Margin = new Padding(4);
            btnToLogin.Name = "btnToLogin";
            btnToLogin.Size = new Size(301, 71);
            btnToLogin.TabIndex = 7;
            btnToLogin.Text = "Перейти до реєстрації";
            btnToLogin.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1065, 493);
            Controls.Add(btnToLogin);
            Controls.Add(btnVissiblePassword);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(lbQuestion);
            Controls.Add(label1);
            Controls.Add(btnChangeStyles);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "Реєстрація користувача";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChangeStyles;
        private Label label1;
        private Label lbQuestion;
        private Label label5;
        private TextBox txtEmail;
        private Label label6;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label label11;
        private Label label12;
        private Button btnVissiblePassword;
        private Button btnToLogin;
    }
}
