namespace FormOptions
{
    partial class PasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
            txtPassword = new TextBox();
            bgPasswordForm = new Label();
            btnCont = new Button();
            lbError = new Label();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(237, 239, 241);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(txtPassword, "txtPassword");
            txtPassword.ForeColor = SystemColors.HotTrack;
            txtPassword.Name = "txtPassword";
            // 
            // bgPasswordForm
            // 
            bgPasswordForm.BackColor = Color.FromArgb(228, 230, 233);
            resources.ApplyResources(bgPasswordForm, "bgPasswordForm");
            bgPasswordForm.Name = "bgPasswordForm";
            // 
            // btnCont
            // 
            btnCont.BackColor = Color.White;
            resources.ApplyResources(btnCont, "btnCont");
            btnCont.ForeColor = SystemColors.ControlText;
            btnCont.Name = "btnCont";
            btnCont.UseVisualStyleBackColor = false;
            btnCont.Click += btnCont_Click;
            // 
            // lbError
            // 
            resources.ApplyResources(lbError, "lbError");
            lbError.ForeColor = Color.Firebrick;
            lbError.Name = "lbError";
            // 
            // PasswordForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 239, 241);
            Controls.Add(lbError);
            Controls.Add(btnCont);
            Controls.Add(bgPasswordForm);
            Controls.Add(txtPassword);
            DoubleBuffered = true;
            MaximizeBox = false;
            Name = "PasswordForm";
            Load += PasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Label bgPasswordForm;
        private Button btnCont;
        private Label lbError;
    }
}