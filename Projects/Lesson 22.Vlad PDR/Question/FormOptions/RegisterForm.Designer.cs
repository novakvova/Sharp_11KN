namespace FormOptions
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            btnCreateAcc = new Button();
            btnEye2 = new Button();
            txtPassword2 = new TextBox();
            label1 = new Label();
            txtEmail = new TextBox();
            lbError1 = new Label();
            lbError2 = new Label();
            lbError3 = new Label();
            lbError4 = new Label();
            btnEye = new Button();
            checkBox1 = new CheckBox();
            linkLbToLog = new LinkLabel();
            label6 = new Label();
            label4 = new Label();
            chBoxRememberMe = new CheckBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(237, 239, 241);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtName, "txtName");
            txtName.ForeColor = Color.Black;
            txtName.Name = "txtName";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ControlText;
            label2.Name = "label2";
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
            // btnEye2
            // 
            btnEye2.AccessibleRole = AccessibleRole.TitleBar;
            btnEye2.BackColor = Color.White;
            resources.ApplyResources(btnEye2, "btnEye2");
            btnEye2.ForeColor = SystemColors.ControlText;
            btnEye2.Name = "btnEye2";
            btnEye2.UseVisualStyleBackColor = false;
            btnEye2.Click += btnEye2_Click;
            // 
            // txtPassword2
            // 
            txtPassword2.BackColor = Color.FromArgb(237, 239, 241);
            txtPassword2.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtPassword2, "txtPassword2");
            txtPassword2.ForeColor = Color.Black;
            txtPassword2.Name = "txtPassword2";
            txtPassword2.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.ControlText;
            label1.Name = "label1";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(237, 239, 241);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtEmail, "txtEmail");
            txtEmail.ForeColor = Color.Black;
            txtEmail.Name = "txtEmail";
            // 
            // lbError1
            // 
            resources.ApplyResources(lbError1, "lbError1");
            lbError1.ForeColor = SystemColors.ControlText;
            lbError1.Name = "lbError1";
            // 
            // lbError2
            // 
            resources.ApplyResources(lbError2, "lbError2");
            lbError2.ForeColor = SystemColors.ControlText;
            lbError2.Name = "lbError2";
            // 
            // lbError3
            // 
            resources.ApplyResources(lbError3, "lbError3");
            lbError3.ForeColor = SystemColors.ControlText;
            lbError3.Name = "lbError3";
            // 
            // lbError4
            // 
            resources.ApplyResources(lbError4, "lbError4");
            lbError4.ForeColor = SystemColors.ControlText;
            lbError4.Name = "lbError4";
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
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ControlText;
            label4.Name = "label4";
            // 
            // chBoxRememberMe
            // 
            resources.ApplyResources(chBoxRememberMe, "chBoxRememberMe");
            chBoxRememberMe.Name = "chBoxRememberMe";
            chBoxRememberMe.UseVisualStyleBackColor = true;
            chBoxRememberMe.CheckedChanged += chBoxRememberMe_CheckedChanged;
            // 
            // RegisterForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 239, 241);
            Controls.Add(chBoxRememberMe);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(linkLbToLog);
            Controls.Add(checkBox1);
            Controls.Add(lbError4);
            Controls.Add(lbError3);
            Controls.Add(lbError2);
            Controls.Add(lbError1);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(btnEye2);
            Controls.Add(txtPassword2);
            Controls.Add(btnCreateAcc);
            Controls.Add(btnEye);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtName);
            ForeColor = SystemColors.ControlText;
            MaximizeBox = false;
            Name = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private TextBox txtPassword;
        private Button btnCreateAcc;
        private Button btnEye2;
        private TextBox txtPassword2;
        private Label label1;
        private TextBox txtEmail;
        private Label lbError1;
        private Label lbError2;
        private Label lbError3;
        private Label lbError4;
        private Button btnEye;
        private CheckBox checkBox1;
        private LinkLabel linkLbToLog;
        private Label label6;
        private Label label4;
        private CheckBox chBoxRememberMe;
    }
}