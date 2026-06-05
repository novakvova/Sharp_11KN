using System.Drawing;
using System.Windows.Forms;

namespace WinAppPDR
{
    partial class CreateForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            
            SuspendLayout();

            Name = "CreateForm";
            Text = "Створення тесту";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }
    }
}