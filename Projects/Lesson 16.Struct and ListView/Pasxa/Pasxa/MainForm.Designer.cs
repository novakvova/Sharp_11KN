namespace Pasxa
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
            lvPasxy = new ListView();
            label1 = new Label();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // lvPasxy
            // 
            lvPasxy.Location = new Point(34, 68);
            lvPasxy.Name = "lvPasxy";
            lvPasxy.Size = new Size(846, 407);
            lvPasxy.TabIndex = 0;
            lvPasxy.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(309, 9);
            label1.Name = "label1";
            label1.Size = new Size(296, 38);
            label1.TabIndex = 1;
            label1.Text = "Підготовка до пасхи";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(899, 110);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(236, 69);
            trackBar1.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 527);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Controls.Add(lvPasxy);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvPasxy;
        private Label label1;
        private TrackBar trackBar1;
    }
}
