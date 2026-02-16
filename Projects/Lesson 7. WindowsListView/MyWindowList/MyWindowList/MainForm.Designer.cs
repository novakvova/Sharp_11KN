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
            mHeadMenu = new MenuStrip();
            mHeadMenuFile = new ToolStripMenuItem();
            mFileExit = new ToolStripMenuItem();
            mHelp = new ToolStripMenuItem();
            mHelpContacts = new ToolStripMenuItem();
            mHeadMenu.SuspendLayout();
            SuspendLayout();
            // 
            // btnContactView
            // 
            btnContactView.Location = new Point(31, 48);
            btnContactView.Margin = new Padding(2);
            btnContactView.Name = "btnContactView";
            btnContactView.Size = new Size(152, 72);
            btnContactView.TabIndex = 0;
            btnContactView.Text = "Контакти";
            btnContactView.UseVisualStyleBackColor = true;
            btnContactView.Click += btnContactView_Click;
            // 
            // mHeadMenu
            // 
            mHeadMenu.ImageScalingSize = new Size(24, 24);
            mHeadMenu.Items.AddRange(new ToolStripItem[] { mHeadMenuFile, mHelp });
            mHeadMenu.Location = new Point(0, 0);
            mHeadMenu.Name = "mHeadMenu";
            mHeadMenu.Size = new Size(800, 33);
            mHeadMenu.TabIndex = 1;
            mHeadMenu.Text = "menuStrip1";
            // 
            // mHeadMenuFile
            // 
            mHeadMenuFile.DropDownItems.AddRange(new ToolStripItem[] { mFileExit });
            mHeadMenuFile.Name = "mHeadMenuFile";
            mHeadMenuFile.Size = new Size(54, 29);
            mHeadMenuFile.Text = "File";
            // 
            // mFileExit
            // 
            mFileExit.Name = "mFileExit";
            mFileExit.ShortcutKeys = Keys.Control | Keys.X;
            mFileExit.Size = new Size(218, 34);
            mFileExit.Text = "Вихід";
            mFileExit.Click += mFileExit_Click;
            // 
            // mHelp
            // 
            mHelp.DropDownItems.AddRange(new ToolStripItem[] { mHelpContacts });
            mHelp.Name = "mHelp";
            mHelp.Size = new Size(65, 29);
            mHelp.Text = "Help";
            // 
            // mHelpContacts
            // 
            mHelpContacts.Name = "mHelpContacts";
            mHelpContacts.ShortcutKeys = Keys.Control | Keys.M;
            mHelpContacts.Size = new Size(270, 34);
            mHelpContacts.Text = "Contacts";
            mHelpContacts.Click += mHelpContacts_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnContactView);
            Controls.Add(mHeadMenu);
            MainMenuStrip = mHeadMenu;
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Головне вікно";
            mHeadMenu.ResumeLayout(false);
            mHeadMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnContactView;
        private MenuStrip mHeadMenu;
        private ToolStripMenuItem mHeadMenuFile;
        private ToolStripMenuItem mFileExit;
        private ToolStripMenuItem mHelp;
        private ToolStripMenuItem mHelpContacts;
    }
}