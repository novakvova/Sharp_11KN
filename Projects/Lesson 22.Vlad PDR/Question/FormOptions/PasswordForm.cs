using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormOptions
{
    public partial class PasswordForm : Form
    {
        private string correctCode;
        private string userEmail;

        private Color successColor;
        private Color errorColor;
        private Color textBoxErrorBack;
        private Color textBoxSuccessBack;
        private Color defaultTextBoxBack;
        private Color defaultForeColor;
        private bool isDarkMode = false;
        private string configPath = "appsettings.json";

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public PasswordForm(string code, string email)
        {
            InitializeComponent();
            this.correctCode = code;
            this.userEmail = email;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            txtPassword.TextChanged += (s, e) => ClearErrorOnInput(txtPassword, lbError);

            LoadSettings();
            ApplyTheme();

            this.AcceptButton = btnCont;
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private async void btnCont_Click(object sender, EventArgs e)
        {
            ResetValidationStyles();
            string enteredCode = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(enteredCode))
            {
                SetErrorStyle(txtPassword, lbError, "⚠ Введіть код підтвердження");
                return;
            }

            if (enteredCode.Length != 6 || !int.TryParse(enteredCode, out _))
            {
                SetErrorStyle(txtPassword, lbError, "⚠ Код підтвердження має містити 6 цифр");
                return;
            }

            if (enteredCode != correctCode)
            {
                SetErrorStyle(txtPassword, lbError, "⚠ Невірний код підтвердження");
                return;
            }

            SetSuccessStyle(txtPassword, lbError, "✔ Код підтверджено успішно");

            this.Refresh();

            await Task.Delay(300);

            this.DialogResult = DialogResult.OK;

            this.Hide();

            using (ResetPasswordForm resetForm = new ResetPasswordForm(userEmail))
            {
                resetForm.ShowDialog();
            }

            this.Close();
        }

        private void ApplyTheme()
        {
            Color backColor, controlBack, lb2color;

            if (isDarkMode)
            {
                backColor = Color.FromArgb(33, 35, 38);
                defaultTextBoxBack = Color.FromArgb(33, 35, 38);
                controlBack = Color.FromArgb(64, 64, 64);
                defaultForeColor = Color.White;
                lb2color = Color.FromArgb(40, 42, 45);

                errorColor = Color.FromArgb(255, 120, 120);
                successColor = Color.FromArgb(144, 238, 144);
                textBoxErrorBack = Color.FromArgb(70, 40, 40);
                textBoxSuccessBack = Color.FromArgb(33, 35, 38);
            }
            else
            {
                Color lightColor = Color.FromArgb(237, 239, 241);

                backColor = lightColor;
                defaultTextBoxBack = lightColor;
                controlBack = Color.White;
                defaultForeColor = Color.Black;
                lb2color = Color.FromArgb(228, 230, 233);

                errorColor = Color.Red;
                successColor = Color.DarkGreen;
                textBoxErrorBack = Color.FromArgb(255, 230, 230);
                textBoxSuccessBack = Color.FromArgb(230, 255, 230);
            }

            this.BackColor = backColor;

            if (txtPassword != null)
            {
                txtPassword.BackColor = defaultTextBoxBack;
                txtPassword.ForeColor = defaultForeColor;
                txtPassword.BorderStyle = BorderStyle.FixedSingle;
                txtPassword.Font = new Font("Segoe UI", 11F);
            }

            if (btnCont != null)
            {
                btnCont.BackColor = controlBack;
                btnCont.ForeColor = defaultForeColor;
                btnCont.FlatStyle = FlatStyle.Flat;
                btnCont.FlatAppearance.BorderColor = isDarkMode ? Color.White : Color.DarkGray;
                btnCont.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btnCont.BringToFront();
            }

            if (bgPasswordForm != null)
            {
                bgPasswordForm.BackColor = lb2color;
                bgPasswordForm.FlatStyle = FlatStyle.Flat;
            }

            foreach (Control c in this.Controls)
            {
                if (c is Label lb)
                {
                    if (lb == bgPasswordForm) continue;

                    lb.ForeColor = defaultForeColor;
                    lb.Font = new Font("Segoe UI", 9.5F);

                    if (bgPasswordForm != null && bgPasswordForm.Bounds.Contains(lb.Location))
                    {
                        lb.BackColor = lb2color;
                    }
                    else
                    {
                        lb.BackColor = isDarkMode ? Color.Transparent : Color.FromArgb(237, 239, 241);
                    }
                }
            }

            int attrValue = isDarkMode ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attrValue, sizeof(int));

            UpdateControlColors();
            this.Refresh();
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

        private void ClearErrorOnInput(TextBox textBox, Label errorLabel)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorLabel.Visible = false;
                errorLabel.Text = "";
                textBox.BackColor = defaultTextBoxBack;
                textBox.ForeColor = defaultForeColor;
            }
        }

        private void UpdateControlColors()
        {
            if (txtPassword != null)
            {
                if (!lbError.Visible || !lbError.Text.Contains("⚠"))
                {
                    txtPassword.BackColor = defaultTextBoxBack;
                    txtPassword.ForeColor = defaultForeColor;
                }
            }

            if (btnCont != null) btnCont.ForeColor = defaultForeColor;

            if (lbError != null && lbError.Visible)
            {
                lbError.ForeColor = lbError.Text.Contains("⚠") ? errorColor : successColor;

                if (bgPasswordForm != null && bgPasswordForm.Bounds.Contains(lbError.Location))
                {
                    lbError.BackColor = bgPasswordForm.BackColor;
                }
            }
        }

        private void SetErrorStyle(TextBox tb, Label lb, string message)
        {
            tb.BackColor = textBoxErrorBack;
            tb.ForeColor = isDarkMode ? Color.FromArgb(255, 120, 120) : Color.DarkRed;
            lb.ForeColor = errorColor;
            lb.Text = message;
            lb.Visible = true;

            if (bgPasswordForm != null && bgPasswordForm.Bounds.Contains(lb.Location))
            {
                lb.BackColor = bgPasswordForm.BackColor;
            }
        }

        private void SetSuccessStyle(TextBox tb, Label lb, string message)
        {
            tb.BackColor = textBoxSuccessBack;
            tb.ForeColor = isDarkMode ? Color.White : Color.DarkGreen;
            lb.ForeColor = successColor;
            lb.Text = message;
            lb.Visible = true;

            if (bgPasswordForm != null && bgPasswordForm.Bounds.Contains(lb.Location))
            {
                lb.BackColor = bgPasswordForm.BackColor;
            }
        }

        private void ResetValidationStyles()
        {
            lbError.Visible = false;
            lbError.Text = "";
            txtPassword.BackColor = defaultTextBoxBack;
            txtPassword.ForeColor = defaultForeColor;
        }
    }
}