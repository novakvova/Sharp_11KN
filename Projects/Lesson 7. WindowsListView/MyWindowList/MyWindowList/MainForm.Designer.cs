namespace MyWindowList
{
    partial class MainForm
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
            btnContactView = new Button();
            SuspendLayout();
            // 
            // btnContactView
            // 
            btnContactView.Location = new Point(31, 48);
            btnContactView.Name = "btnContactView";
            btnContactView.Size = new Size(152, 73);
            btnContactView.TabIndex = 0;
            btnContactView.Text = "Контакти";
            btnContactView.UseVisualStyleBackColor = true;
            btnContactView.Click += btnContactView_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnContactView);
            Name = "MainForm";
            Text = "Головне вікно";
            ResumeLayout(false);
        }

        #endregion

        private Button btnContactView;
    }
}