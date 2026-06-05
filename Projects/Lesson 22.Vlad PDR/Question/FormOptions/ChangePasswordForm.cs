using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FormOptions
{
    public partial class ChangePasswordForm : Form
    {
        private string targetEmail;
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

        public ChangePasswordForm(string email)
        {
            InitializeComponent();
            this.targetEmail = email;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;

            txtPassword.TextChanged += (s, e) => ClearErrorOnInput(txtPassword, lbError3);
            txtPassword2.TextChanged += (s, e) => ClearErrorOnInput(txtPassword2, lbError4);

            LoadSettings();
            ApplyTheme();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void ClearErrorOnInput(TextBox textBox, Label errorLabel)
        {
            if (errorLabel != null && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorLabel.Text = "";
                textBox.BackColor = defaultTextBoxBack;
                textBox.ForeColor = defaultForeColor;
            }
        }

        private void ApplyTheme()
        {
            bool dark = isDarkMode;

            if (dark)
            {
                this.BackColor = Color.FromArgb(28, 30, 33);
                defaultTextBoxBack = Color.FromArgb(41, 43, 47);
                defaultForeColor = Color.White;

                errorColor = Color.FromArgb(255, 120, 120);
                successColor = Color.FromArgb(144, 238, 144);
                textBoxErrorBack = Color.FromArgb(70, 40, 40);
                textBoxSuccessBack = Color.FromArgb(40, 70, 40);
            }
            else
            {
                this.BackColor = Color.FromArgb(245, 246, 248);
                defaultTextBoxBack = Color.White;
                defaultForeColor = Color.FromArgb(30, 30, 30);

                errorColor = Color.Red;
                successColor = Color.DarkGreen;
                textBoxErrorBack = Color.FromArgb(255, 230, 230);
                textBoxSuccessBack = Color.FromArgb(230, 255, 230);
            }

            UpdateControlColors();

            int attributeValue = dark ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attributeValue, sizeof(int));
            this.Refresh();
        }

        private void UpdateControlColors()
        {
            bool dark = isDarkMode;
            Label[] labels = { label2, label3, label4 };

            foreach (var lb in labels)
            {
                if (lb != null)
                {
                    lb.ForeColor = defaultForeColor;
                    lb.BackColor = Color.Transparent;
                }
            }

            Color btnBg = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            Color btnHover = dark ? Color.FromArgb(51, 54, 59) : Color.FromArgb(235, 238, 242);
            Color btnActive = dark ? Color.FromArgb(33, 35, 38) : Color.FromArgb(220, 224, 228);
            Color btnBorder = dark ? Color.FromArgb(55, 55, 55) : Color.FromArgb(218, 220, 224);

            Button[] buttons = { btnCreateAcc, btnEye, btnEye2 };
            foreach (var btn in buttons)
            {
                if (btn != null)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = btnBg;
                    btn.ForeColor = defaultForeColor;
                    btn.Cursor = Cursors.Default;

                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = btnBorder;

                    btn.FlatAppearance.MouseOverBackColor = btnHover;
                    btn.FlatAppearance.MouseDownBackColor = btnActive;
                }
            }

            if (btnCreateAcc != null) btnCreateAcc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            if (btnEye != null) btnEye.Font = new Font("Segoe UI", 9F);
            if (btnEye2 != null) btnEye2.Font = new Font("Segoe UI", 9F);

            if (checkBox1 != null) { checkBox1.ForeColor = defaultForeColor; checkBox1.Cursor = Cursors.Default; }

            UpdateTextBoxThemeState(txtPassword, lbError3);
            UpdateTextBoxThemeState(txtPassword2, lbError4);
        }

        private void UpdateTextBoxThemeState(TextBox tb, Label lb)
        {
            if (tb == null || lb == null) return;

            if (!string.IsNullOrEmpty(lb.Text) && lb.Text.Contains("⚠"))
            {
                tb.BackColor = textBoxErrorBack;
                tb.ForeColor = isDarkMode ? Color.FromArgb(255, 120, 120) : Color.Red;
                lb.ForeColor = errorColor;
            }
            else if (!string.IsNullOrEmpty(lb.Text) && lb.Text.Contains("✔"))
            {
                tb.BackColor = textBoxSuccessBack;
                tb.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
                lb.ForeColor = successColor;
            }
            else
            {
                tb.BackColor = defaultTextBoxBack;
                tb.ForeColor = defaultForeColor;
            }
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            ResetValidationStyles();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                SetErrorStyle(txtPassword, lbError3, "⚠ Введіть пароль.");
                isValid = false;
            }
            else if (txtPassword.Text.Length < 4)
            {
                SetErrorStyle(txtPassword, lbError3, "⚠ Пароль має бути не менше 4 символів.");
                isValid = false;
            }
            else
            {
                SetSuccessStyle(txtPassword, lbError3, "✔ Пароль прийнято.");
            }

            if (string.IsNullOrWhiteSpace(txtPassword2.Text))
            {
                SetErrorStyle(txtPassword2, lbError4, "⚠ Підтвердіть пароль.");
                isValid = false;
            }
            else if (txtPassword2.Text != txtPassword.Text)
            {
                SetErrorStyle(txtPassword2, lbError4, "⚠ Паролі не співпадають.");
                isValid = false;
            }
            else
            {
                SetSuccessStyle(txtPassword2, lbError4, "✔ Паролі підтвердено.");
            }

            if (!isValid) return;

            List<User> users = new List<User>();
            if (File.Exists("storage.json"))
            {
                try
                {
                    string jsonFromFile = File.ReadAllText("storage.json");
                    if (!string.IsNullOrEmpty(jsonFromFile))
                    {
                        users = JsonSerializer.Deserialize<List<User>>(jsonFromFile) ?? new List<User>();
                    }
                }
                catch
                {
                    CustomMessageBox.Show("Помилка", "Помилка читання бази даних. Файл пошкоджений.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                CustomMessageBox.Show("Помилка", "База даних користувачів не знайдена.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var userToUpdate = users.FirstOrDefault(x =>
                x.Email != null &&
                x.Email.Trim().Equals(targetEmail.Trim(), StringComparison.OrdinalIgnoreCase));

            if (userToUpdate != null)
            {
                userToUpdate.Password = hashPasswordMD5(txtPassword.Text.Trim());
            }
            else
            {
                CustomMessageBox.Show("Помилка", "Користувача з таким Email не знайдено в базі даних.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updatedJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("storage.json", updatedJson);

            ToMainForm();
        }

        private void ToMainForm()
        {
            MainForm mainForm = new MainForm();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void SetErrorStyle(TextBox tb, Label lb, string message)
        {
            if (lb != null) { lb.Text = message; lb.ForeColor = errorColor; }
            if (tb != null) { tb.BackColor = textBoxErrorBack; tb.ForeColor = isDarkMode ? Color.FromArgb(255, 120, 120) : Color.Red; }
        }

        private void SetSuccessStyle(TextBox tb, Label lb, string message)
        {
            if (lb != null) { lb.Text = message; lb.ForeColor = successColor; }
            if (tb != null) { tb.BackColor = textBoxSuccessBack; tb.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30); }
        }

        private void ResetValidationStyles()
        {
            Label[] labels = { lbError3, lbError4 };
            TextBox[] boxes = { txtPassword, txtPassword2 };

            for (int i = 0; i < labels.Length; i++)
            {
                if (labels[i] != null) labels[i].Text = "";
                if (boxes[i] != null) { boxes[i].BackColor = defaultTextBoxBack; boxes[i].ForeColor = defaultForeColor; }
            }
        }

        private string hashPasswordMD5(string password)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
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
            catch { isDarkMode = false; }
        }

        private void btnEye_Click(object sender, EventArgs e) => txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        private void btnEye2_Click(object sender, EventArgs e) => txtPassword2.UseSystemPasswordChar = !txtPassword2.UseSystemPasswordChar;

        private void linkLbToLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.Text = "12345";
                txtPassword2.Text = "12345";
            }
            else
            {
                txtPassword.Text = ""; txtPassword2.Text = "";
            }
        }
    }
}