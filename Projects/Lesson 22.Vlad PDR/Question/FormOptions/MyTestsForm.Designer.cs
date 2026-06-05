namespace WinAppPDR
{
    partial class MyTestsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MyTestsForm
            // 
            BackColor = Color.FromArgb(237, 239, 241);
            ClientSize = new Size(1250, 650);
            Name = "MyTestsForm";
            Text = "Мої тести";
            ResumeLayout(false);
        }
    }
}