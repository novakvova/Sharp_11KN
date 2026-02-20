namespace WindowComunity
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
            btnSetInfo = new Button();
            SuspendLayout();
            // 
            // btnSetInfo
            // 
            btnSetInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSetInfo.Location = new Point(804, 12);
            btnSetInfo.Name = "btnSetInfo";
            btnSetInfo.Size = new Size(268, 107);
            btnSetInfo.TabIndex = 0;
            btnSetInfo.Text = "Вказати інформацію";
            btnSetInfo.UseVisualStyleBackColor = true;
            btnSetInfo.Click += btnSetInfo_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 584);
            Controls.Add(btnSetInfo);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSetInfo;
    }
}
