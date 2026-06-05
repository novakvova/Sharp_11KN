using FormOptions;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ChooseThemeForm : Form
    {
        private bool isDarkMode = false;
        private string configPath = "appsettings.json";
        private Color buttonBorderColor;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public ChooseThemeForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;

            LoadSettings();

            rdBtnDarkTheme.CheckedChanged += ThemeRadioButton_CheckedChanged;
            rdBtnLightTheme.CheckedChanged += ThemeRadioButton_CheckedChanged;
        }

        private void ChooseThemeForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
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
                        isDarkMode = doc.RootElement.GetProperty("theme").GetString() == "dark";
                    }
                }
            }
            catch
            {
                isDarkMode = false;
            }

            if (isDarkMode)
                rdBtnDarkTheme.Checked = true;
            else
                rdBtnLightTheme.Checked = true;

            ApplyTheme();
        }

        private void SaveSettings()
        {
            try
            {
                var data = new { theme = isDarkMode ? "dark" : "light" };
                File.WriteAllText(configPath, JsonSerializer.Serialize(data));
            }
            catch { }
        }

        private void ThemeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                isDarkMode = (rb == rdBtnDarkTheme);
                ApplyTheme();
                SaveSettings();
            }
        }

        private void ApplyTheme()
        {
            bool dark = isDarkMode;

            Color bgForm = dark ? Color.FromArgb(28, 30, 33) : Color.FromArgb(245, 246, 248);
            Color textCol = dark ? Color.White : Color.FromArgb(30, 30, 30);

            Color btnBg = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            Color btnHover = dark ? Color.FromArgb(51, 54, 59) : Color.FromArgb(235, 238, 242);
            Color btnActive = dark ? Color.FromArgb(33, 35, 38) : Color.FromArgb(220, 224, 228);
            buttonBorderColor = dark ? Color.FromArgb(55, 55, 55) : Color.FromArgb(218, 220, 224);

            this.BackColor = bgForm;

            if (btnCancel != null)
            {
                btnCancel.FlatStyle = FlatStyle.Flat;
                btnCancel.BackColor = btnBg;
                btnCancel.ForeColor = textCol;
                btnCancel.Cursor = Cursors.Default;
                btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                btnCancel.FlatAppearance.BorderSize = 1;
                btnCancel.FlatAppearance.BorderColor = buttonBorderColor;
                btnCancel.FlatAppearance.MouseOverBackColor = btnHover;
                btnCancel.FlatAppearance.MouseDownBackColor = btnActive;
            }

            if (btnApply != null)
            {
                btnApply.FlatStyle = FlatStyle.Flat;
                btnApply.BackColor = btnBg;
                btnApply.ForeColor = textCol;
                btnApply.Cursor = Cursors.Default;
                btnApply.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                btnApply.FlatAppearance.BorderSize = 1;
                btnApply.FlatAppearance.BorderColor = buttonBorderColor;
                btnApply.FlatAppearance.MouseOverBackColor = btnHover;
                btnApply.FlatAppearance.MouseDownBackColor = btnActive;
            }

            if (lb1 != null) lb1.ForeColor = textCol;
            if (lb2 != null) lb2.ForeColor = textCol;

            if (rdBtnLightTheme != null)
            {
                rdBtnLightTheme.ForeColor = textCol;
                rdBtnLightTheme.BackColor = Color.Transparent;
                rdBtnLightTheme.Cursor = Cursors.Default;
            }

            if (rdBtnDarkTheme != null)
            {
                rdBtnDarkTheme.ForeColor = textCol;
                rdBtnDarkTheme.BackColor = Color.Transparent;
                rdBtnDarkTheme.Cursor = Cursors.Default;
            }

            if (bgChooseThemeForm != null)
            {
                bgChooseThemeForm.BackColor = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            }

            int attributeValue = dark ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attributeValue, sizeof(int));
            this.Refresh();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}