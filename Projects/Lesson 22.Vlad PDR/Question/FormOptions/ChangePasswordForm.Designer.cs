namespace FormOptions
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            label2 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            btnCreateAcc = new Button();
            btnEye2 = new Button();
            txtPassword2 = new TextBox();
            lbError3 = new Label();
            lbError4 = new Label();
            btnEye = new Button();
            checkBox1 = new CheckBox();
            label4 = new Label();
            SuspendLayout();
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
            // 
            // checkBox1
            // 
            resources.ApplyResources(checkBox1, "checkBox1");
            checkBox1.Name = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ControlText;
            label4.Name = "label4";
            // 
            // ChangePasswordForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 239, 241);
            Controls.Add(label4);
            Controls.Add(checkBox1);
            Controls.Add(lbError4);
            Controls.Add(lbError3);
            Controls.Add(btnEye2);
            Controls.Add(txtPassword2);
            Controls.Add(btnCreateAcc);
            Controls.Add(btnEye);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            ForeColor = SystemColors.ControlText;
            MaximizeBox = false;
            Name = "ChangePasswordForm";
            Load += ChangePasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox txtPassword;
        private Button btnCreateAcc;
        private Button btnEye2;
        private TextBox txtPassword2;
        private Label lbError3;
        private Label lbError4;
        private Button btnEye;
        private CheckBox checkBox1;
        private Label label4;
    }
}