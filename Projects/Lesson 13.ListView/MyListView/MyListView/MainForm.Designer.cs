namespace MyListView
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
            lvExplorer = new ListView();
            txtFolderPath = new TextBox();
            label1 = new Label();
            btnLoadData = new Button();
            txtViewInfo = new TextBox();
            SuspendLayout();
            // 
            // lvExplorer
            // 
            lvExplorer.Location = new Point(48, 114);
            lvExplorer.Name = "lvExplorer";
            lvExplorer.Size = new Size(676, 308);
            lvExplorer.TabIndex = 0;
            lvExplorer.UseCompatibleStateImageBehavior = false;
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(48, 53);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(544, 31);
            txtFolderPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 19);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 2;
            label1.Text = "Шлях до папки";
            // 
            // btnLoadData
            // 
            btnLoadData.Location = new Point(598, 19);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(132, 78);
            btnLoadData.TabIndex = 3;
            btnLoadData.Text = "Показати вміст";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // txtViewInfo
            // 
            txtViewInfo.Location = new Point(749, 114);
            txtViewInfo.Multiline = true;
            txtViewInfo.Name = "txtViewInfo";
            txtViewInfo.Size = new Size(445, 308);
            txtViewInfo.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1221, 479);
            Controls.Add(txtViewInfo);
            Controls.Add(btnLoadData);
            Controls.Add(label1);
            Controls.Add(txtFolderPath);
            Controls.Add(lvExplorer);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvExplorer;
        private TextBox txtFolderPath;
        private Label label1;
        private Button btnLoadData;
        private TextBox txtViewInfo;
    }
}
