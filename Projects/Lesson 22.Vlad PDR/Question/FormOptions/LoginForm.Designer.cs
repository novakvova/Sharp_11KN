namespace FormOptions
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label3 = new Label();
            txtPassword = new TextBox();
            btnCreateAcc = new Button();
            lbError1 = new Label();
            lbError3 = new Label();
            btnEye = new Button();
            checkBox1 = new CheckBox();
            linkLbToLog = new LinkLabel();
            label6 = new Label();
            label5 = new Label();
            txtEmail = new TextBox();
            chBoxRememberMe = new CheckBox();
            linkLbForgetPassword = new LinkLabel();
            SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ControlText;
            label3.Name = "label3";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(237, 239, 241);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtPassword, "txtPassword");
            txtPassword.ForeColor = Color.Black;
            txtPassword.Name = "txtPassword";
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnCreateAcc
            // 
            btnCreateAcc.BackColor = Color.White;
            btnCreateAcc.Cursor = Cursors.Hand;
            resources.ApplyResources(btnCreateAcc, "btnCreateAcc");
            btnCreateAcc.ForeColor = SystemColors.ControlText;
            btnCreateAcc.Name = "btnCreateAcc";
            btnCreateAcc.UseVisualStyleBackColor = false;
            btnCreateAcc.Click += btnCreateAcc_Click;
            // 
            // lbError1
            // 
            resources.ApplyResources(lbError1, "lbError1");
            lbError1.ForeColor = SystemColors.ControlText;
            lbError1.Name = "lbError1";
            // 
            // lbError3
            // 
            resources.ApplyResources(lbError3, "lbError3");
            lbError3.ForeColor = SystemColors.ControlText;
            lbError3.Name = "lbError3";
            // 
            // btnEye
            // 
            btnEye.BackColor = Color.White;
            resources.ApplyResources(btnEye, "btnEye");
            btnEye.ForeColor = SystemColors.ControlText;
            btnEye.Name = "btnEye";
            btnEye.UseVisualStyleBackColor = false;
            btnEye.Click += btnEye_Click;
            // 
            // checkBox1
            // 
            resources.ApplyResources(checkBox1, "checkBox1");
            checkBox1.Name = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // linkLbToLog
            // 
            resources.ApplyResources(linkLbToLog, "linkLbToLog");
            linkLbToLog.LinkColor = Color.FromArgb(128, 128, 255);
            linkLbToLog.Name = "linkLbToLog";
            linkLbToLog.TabStop = true;
            linkLbToLog.LinkClicked += linkLbToLog_LinkClicked;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = Color.Transparent;
            label5.ForeColor = SystemColors.ControlText;
            label5.Name = "label5";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(237, 239, 241);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtEmail, "txtEmail");
            txtEmail.ForeColor = Color.Black;
            txtEmail.Name = "txtEmail";
            // 
            // chBoxRememberMe
            // 
            resources.ApplyResources(chBoxRememberMe, "chBoxRememberMe");
            chBoxRememberMe.Name = "chBoxRememberMe";
            chBoxRememberMe.UseVisualStyleBackColor = true;
            chBoxRememberMe.CheckedChanged += chBoxRememberMe_CheckedChanged;
            // 
            // linkLbForgetPassword
            // 
            resources.ApplyResources(linkLbForgetPassword, "linkLbForgetPassword");
            linkLbForgetPassword.LinkColor = Color.FromArgb(128, 128, 255);
            linkLbForgetPassword.Name = "linkLbForgetPassword";
            linkLbForgetPassword.TabStop = true;
            linkLbForgetPassword.LinkClicked += linkLbForgetPassword_LinkClicked;
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 239, 241);
            Controls.Add(linkLbForgetPassword);
            Controls.Add(chBoxRememberMe);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(linkLbToLog);
            Controls.Add(checkBox1);
            Controls.Add(lbError3);
            Controls.Add(lbError1);
            Controls.Add(btnCreateAcc);
            Controls.Add(btnEye);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            ForeColor = SystemColors.ControlText;
            MaximizeBox = false;
            Name = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private TextBox txtPassword;
        private Button btnCreateAcc;
        private Label lbError1;
        private Label lbError3;
        private Button btnEye;
        private CheckBox checkBox1;
        private LinkLabel linkLbToLog;
        private Label label6;
        private Label label5;
        private TextBox txtEmail;
        private CheckBox chBoxRememberMe;
        private LinkLabel linkLbForgetPassword;
    }
}