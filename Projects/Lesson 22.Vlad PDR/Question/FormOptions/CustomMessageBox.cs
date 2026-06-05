using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace FormOptions
{
    public partial class CustomMessageBox : Form
    {
        private bool isDarkMode = false;
        private string configPath = "appsettings.json";

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private Label lblMessage;
        private Button btnOK;
        private Button btnCancel;
        private Button btnYes;
        private Button btnNo;

        public CustomMessageBox(string title, string message, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            this.Text = title;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.Size = new Size(420, 180);

            LoadSettings();

            lblMessage = new Label
            {
                Text = message,
                Location = new Point(25, 25),
                Size = new Size(355, 50),
                AutoSize = false,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblMessage);

            int buttonHeight = 34;
            int topPos = 90;

            if (buttons == MessageBoxButtons.OK)
            {
                btnOK = new Button
                {
                    Text = "Продовжити",
                    Location = new Point(250, topPos),
                    Size = new Size(130, buttonHeight),
                    DialogResult = DialogResult.OK
                };
                this.Controls.Add(btnOK);
                this.AcceptButton = btnOK;
            }
            else if (buttons == MessageBoxButtons.OKCancel)
            {
                btnCancel = new Button
                {
                    Text = "Скасувати",
                    Location = new Point(270, topPos),
                    Size = new Size(110, buttonHeight),
                    DialogResult = DialogResult.Cancel
                };
                this.Controls.Add(btnCancel);

                btnOK = new Button
                {
                    Text = "ОК",
                    Location = new Point(150, topPos),
                    Size = new Size(110, buttonHeight),
                    DialogResult = DialogResult.OK
                };
                this.Controls.Add(btnOK);

                this.AcceptButton = btnOK;
                this.CancelButton = btnCancel;
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                btnNo = new Button
                {
                    Text = "Ні",
                    Location = new Point(270, topPos),
                    Size = new Size(110, buttonHeight),
                    DialogResult = DialogResult.No
                };
                this.Controls.Add(btnNo);

                btnYes = new Button
                {
                    Text = "Так",
                    Location = new Point(150, topPos),
                    Size = new Size(110, buttonHeight),
                    DialogResult = DialogResult.Yes
                };
                this.Controls.Add(btnYes);

                this.AcceptButton = btnYes;
                this.CancelButton = btnNo;
            }

            ApplyTheme();
            ApplyButtonStyles();
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    string jsonString = File.ReadAllText(configPath);
                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        if (doc.RootElement.TryGetProperty("theme", out JsonElement themeElement))
                        {
                            isDarkMode = themeElement.GetString() == "dark";
                        }
                    }
                }
            }
            catch { isDarkMode = false; }
        }

        private void ApplyTheme()
        {
            bool dark = isDarkMode;

            Color graphiteBackground = dark ? Color.FromArgb(28, 30, 33) : Color.FromArgb(245, 246, 248);
            Color textForeColor = dark ? Color.White : Color.FromArgb(30, 30, 30);

            this.BackColor = graphiteBackground;
            if (lblMessage != null)
            {
                lblMessage.ForeColor = textForeColor;
                lblMessage.BackColor = Color.Transparent;
            }

            int attrValue = dark ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attrValue, sizeof(int));
            this.Refresh();
        }

        private void ApplyButtonStyles()
        {
            bool dark = isDarkMode;

            Color btnBackColor = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            Color btnForeColor = dark ? Color.White : Color.FromArgb(30, 30, 30);
            Color btnBorderColor = dark ? Color.FromArgb(55, 55, 55) : Color.FromArgb(218, 220, 224);

            Color btnHover = dark ? Color.FromArgb(51, 54, 59) : Color.FromArgb(235, 238, 242);
            Color btnActive = dark ? Color.FromArgb(33, 35, 38) : Color.FromArgb(220, 224, 228);

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = btnBackColor;
                    btn.ForeColor = btnForeColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = btnBorderColor;
                    btn.FlatAppearance.MouseOverBackColor = btnHover;
                    btn.FlatAppearance.MouseDownBackColor = btnActive;
                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    btn.Cursor = Cursors.Default;
                }
            }
        }

        public static DialogResult Show(string title, string message)
        {
            using (CustomMessageBox msg = new CustomMessageBox(title, message, MessageBoxButtons.OK, MessageBoxIcon.Information))
            {
                return msg.ShowDialog();
            }
        }

        public static DialogResult Show(string title, string message, MessageBoxButtons buttons)
        {
            using (CustomMessageBox msg = new CustomMessageBox(title, message, buttons, MessageBoxIcon.Information))
            {
                return msg.ShowDialog();
            }
        }

        public static DialogResult Show(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            using (CustomMessageBox msg = new CustomMessageBox(title, message, buttons, icon))
            {
                return msg.ShowDialog();
            }
        }
    }
}