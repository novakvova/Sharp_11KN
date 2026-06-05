namespace FormOptions
{
    partial class recaptchaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(recaptchaForm));
            label1 = new Label();
            bgMessageForm = new Label();
            chBoxNotRobot = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // bgMessageForm
            // 
            bgMessageForm.BackColor = Color.FromArgb(228, 230, 233);
            resources.ApplyResources(bgMessageForm, "bgMessageForm");
            bgMessageForm.Name = "bgMessageForm";
            // 
            // chBoxNotRobot
            // 
            resources.ApplyResources(chBoxNotRobot, "chBoxNotRobot");
            chBoxNotRobot.BackColor = Color.FromArgb(228, 230, 233);
            chBoxNotRobot.Name = "chBoxNotRobot";
            chBoxNotRobot.UseVisualStyleBackColor = false;
            chBoxNotRobot.CheckedChanged += chBoxNotRobot_CheckedChanged;
            // 
            // recaptchaForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 239, 241);
            ControlBox = false;
            Controls.Add(chBoxNotRobot);
            Controls.Add(bgMessageForm);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "recaptchaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label bgMessageForm;
        private CheckBox chBoxNotRobot;
    }
}