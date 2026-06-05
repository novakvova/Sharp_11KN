using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using FormOptions;

namespace WinAppPDR
{
    public partial class ChangeAccountForm : Form
    {
        private string currentUserEmail;
        private List<User> users;

        private Color successColor;
        private Color errorColor;
        private Color textBoxErrorBack;
        private Color textBoxSuccessBack;
        private Color defaultTextBoxBack;
        private Color defaultForeColor;
        private Color buttonBorderColor;

        private bool isDarkMode = false;
        private string configPath = "appsettings.json";

        private Label lblCurrentEmail;
        private TextBox txtNewEmail;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public ChangeAccountForm(string userEmail)
        {
            this.currentUserEmail = userEmail;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(500, 420);
            this.Text = "Зміна облікових даних";

            LoadSettings();
            ApplyTheme();
            CreateControls();
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
                buttonBorderColor = Color.FromArgb(55, 55, 55);
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
                buttonBorderColor = Color.FromArgb(218, 220, 224);
            }

            int attrValue = dark ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attrValue, sizeof(int));
        }

        private void CreateControls()
        {
            bool dark = isDarkMode;

            if (File.Exists("storage.json"))
            {
                try
                {
                    string json = File.ReadAllText("storage.json");
                    users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                }
                catch { users = new List<User>(); }
            }
            else
            {
                users = new List<User>();
            }

            Color btnBg = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            Color btnHover = dark ? Color.FromArgb(51, 54, 59) : Color.FromArgb(235, 238, 242);
            Color btnActive = dark ? Color.FromArgb(33, 35, 38) : Color.FromArgb(220, 224, 228);

            TabControl tabControl = new TabControl
            {
                Location = new Point(12, 12),
                Size = new Size(460, 310),
                Font = new Font("Segoe UI", 9F)
            };

            TabPage tabLogin = new TabPage("Змінити логін (Email)");
            tabLogin.BackColor = this.BackColor;

            lblCurrentEmail = new Label
            {
                Text = $"Поточний Email: {currentUserEmail}",
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                AutoSize = true,
                ForeColor = defaultForeColor
            };
            tabLogin.Controls.Add(lblCurrentEmail);

            Label lblNewEmail = new Label
            {
                Text = "Новий Email:",
                Location = new Point(20, 60),
                AutoSize = true,
                ForeColor = defaultForeColor
            };
            tabLogin.Controls.Add(lblNewEmail);

            txtNewEmail = new TextBox
            {
                Location = new Point(20, 85),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = defaultTextBoxBack,
                ForeColor = defaultForeColor
            };
            tabLogin.Controls.Add(txtNewEmail);

            Label lblErrorEmail = new Label
            {
                Location = new Point(20, 120),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = errorColor,
                AutoSize = false
            };
            tabLogin.Controls.Add(lblErrorEmail);

            Button btnChangeEmail = new Button
            {
                Text = "Змінити Email",
                Location = new Point(20, 160),
                Size = new Size(150, 35),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = btnBg,
                ForeColor = defaultForeColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnChangeEmail.FlatAppearance.BorderSize = 1;
            btnChangeEmail.FlatAppearance.BorderColor = buttonBorderColor;
            btnChangeEmail.FlatAppearance.MouseOverBackColor = btnHover;
            btnChangeEmail.FlatAppearance.MouseDownBackColor = btnActive;

            txtNewEmail.TextChanged += (s, e) => ResetTextBoxValidation(txtNewEmail, lblErrorEmail);
            btnChangeEmail.Click += (s, e) => ChangeEmail(txtNewEmail.Text, lblErrorEmail, txtNewEmail);
            tabLogin.Controls.Add(btnChangeEmail);

            tabControl.TabPages.Add(tabLogin);

            TabPage tabPassword = new TabPage("Змінити пароль");
            tabPassword.BackColor = this.BackColor;

            Label lblCurrentPass = new Label
            {
                Text = "Поточний пароль:",
                Location = new Point(20, 15),
                AutoSize = true,
                ForeColor = defaultForeColor
            };
            tabPassword.Controls.Add(lblCurrentPass);

            TextBox txtCurrentPass = new TextBox
            {
                Location = new Point(20, 38),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = defaultTextBoxBack,
                ForeColor = defaultForeColor,
                UseSystemPasswordChar = true
            };
            tabPassword.Controls.Add(txtCurrentPass);

            Label lblNewPass = new Label
            {
                Text = "Новий пароль:",
                Location = new Point(20, 75),
                AutoSize = true,
                ForeColor = defaultForeColor
            };
            tabPassword.Controls.Add(lblNewPass);

            TextBox txtNewPass = new TextBox
            {
                Location = new Point(20, 98),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = defaultTextBoxBack,
                ForeColor = defaultForeColor,
                UseSystemPasswordChar = true
            };
            tabPassword.Controls.Add(txtNewPass);

            Label lblConfirmPass = new Label
            {
                Text = "Підтвердити пароль:",
                Location = new Point(20, 135),
                AutoSize = true,
                ForeColor = defaultForeColor
            };
            tabPassword.Controls.Add(lblConfirmPass);

            TextBox txtConfirmPass = new TextBox
            {
                Location = new Point(20, 158),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = defaultTextBoxBack,
                ForeColor = defaultForeColor,
                UseSystemPasswordChar = true
            };
            tabPassword.Controls.Add(txtConfirmPass);

            Label lblErrorPass = new Label
            {
                Location = new Point(20, 195),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = errorColor,
                AutoSize = false
            };
            tabPassword.Controls.Add(lblErrorPass);

            Button btnChangePass = new Button
            {
                Text = "Змінити пароль",
                Location = new Point(20, 235),
                Size = new Size(150, 35),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                BackColor = btnBg,
                ForeColor = defaultForeColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnChangePass.FlatAppearance.BorderSize = 1;
            btnChangePass.FlatAppearance.BorderColor = buttonBorderColor;
            btnChangePass.FlatAppearance.MouseOverBackColor = btnHover;
            btnChangePass.FlatAppearance.MouseDownBackColor = btnActive;

            txtCurrentPass.TextChanged += (s, e) => ResetTextBoxValidation(txtCurrentPass, lblErrorPass);
            txtNewPass.TextChanged += (s, e) => ResetTextBoxValidation(txtNewPass, lblErrorPass);
            txtConfirmPass.TextChanged += (s, e) => ResetTextBoxValidation(txtConfirmPass, lblErrorPass);

            btnChangePass.Click += (s, e) => ChangePassword(txtCurrentPass, txtNewPass, txtConfirmPass, lblErrorPass);
            tabPassword.Controls.Add(btnChangePass);

            tabControl.TabPages.Add(tabPassword);
            this.Controls.Add(tabControl);

            Button btnClose = new Button
            {
                Text = "Закрити",
                Location = new Point(392, 335),
                Size = new Size(80, 30),
                Font = new Font("Segoe UI", 9F),
                BackColor = btnBg,
                ForeColor = defaultForeColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 1;
            btnClose.FlatAppearance.BorderColor = buttonBorderColor;
            btnClose.FlatAppearance.MouseOverBackColor = btnHover;
            btnClose.FlatAppearance.MouseDownBackColor = btnActive;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void ResetTextBoxValidation(TextBox tb, Label errorLabel)
        {
            if (errorLabel != null && !string.IsNullOrWhiteSpace(tb.Text))
            {
                errorLabel.Text = "";
                tb.BackColor = defaultTextBoxBack;
                tb.ForeColor = defaultForeColor;
            }
        }

        private void ChangeEmail(string newEmail, Label errorLabel, TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                errorLabel.Text = "⚠ Email не може бути порожнім";
                errorLabel.ForeColor = errorColor;
                textBox.BackColor = textBoxErrorBack;
                return;
            }

            if (newEmail.Trim() == currentUserEmail.Trim())
            {
                errorLabel.Text = "⚠ Новий Email такий же, як поточний";
                errorLabel.ForeColor = errorColor;
                textBox.BackColor = textBoxErrorBack;
                return;
            }

            if (users.Any(u => u.Email != null && u.Email.Trim().Equals(newEmail.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorLabel.Text = "⚠ Цей Email вже використовується";
                errorLabel.ForeColor = errorColor;
                textBox.BackColor = textBoxErrorBack;
                return;
            }

            var user = users.FirstOrDefault(u => u.Email != null && u.Email.Trim().Equals(currentUserEmail.Trim(), StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                user.Email = newEmail.Trim();
                string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("storage.json", json);

                string authJson = JsonSerializer.Serialize(user);
                File.WriteAllText("auth.bin", authJson);

                currentUserEmail = newEmail.Trim();
                if (lblCurrentEmail != null) lblCurrentEmail.Text = $"Поточний Email: {currentUserEmail}";

                errorLabel.Text = "✔ Email успішно змінено!";
                errorLabel.ForeColor = successColor;
                textBox.BackColor = textBoxSuccessBack;
            }
        }

        private void ChangePassword(TextBox txtCurrent, TextBox txtNew, TextBox txtConfirm, Label errorLabel)
        {
            if (string.IsNullOrWhiteSpace(txtCurrent.Text) || string.IsNullOrWhiteSpace(txtNew.Text) || string.IsNullOrWhiteSpace(txtConfirm.Text))
            {
                errorLabel.Text = "⚠ Всі поля мають бути заповнені";
                errorLabel.ForeColor = errorColor;
                if (string.IsNullOrWhiteSpace(txtCurrent.Text)) txtCurrent.BackColor = textBoxErrorBack;
                if (string.IsNullOrWhiteSpace(txtNew.Text)) txtNew.BackColor = textBoxErrorBack;
                if (string.IsNullOrWhiteSpace(txtConfirm.Text)) txtConfirm.BackColor = textBoxErrorBack;
                return;
            }

            var user = users.FirstOrDefault(u => u.Email != null && u.Email.Trim().Equals(currentUserEmail.Trim(), StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                errorLabel.Text = "⚠ Користувача не знайдено";
                errorLabel.ForeColor = errorColor;
                return;
            }

            string hashedCurrentPass = hashPasswordMD5(txtCurrent.Text.Trim());
            if (user.Password != hashedCurrentPass)
            {
                errorLabel.Text = "⚠ Поточний пароль невірний";
                errorLabel.ForeColor = errorColor;
                txtCurrent.BackColor = textBoxErrorBack;
                return;
            }

            if (txtNew.Text.Length < 4)
            {
                errorLabel.Text = "⚠ Новий пароль має мати мінімум 4 символи";
                errorLabel.ForeColor = errorColor;
                txtNew.BackColor = textBoxErrorBack;
                return;
            }

            if (txtNew.Text != txtConfirm.Text)
            {
                errorLabel.Text = "⚠ Паролі не співпадають";
                errorLabel.ForeColor = errorColor;
                txtConfirm.BackColor = textBoxErrorBack;
                return;
            }

            user.Password = hashPasswordMD5(txtNew.Text.Trim());
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("storage.json", json);

            string authJson = JsonSerializer.Serialize(user);
            File.WriteAllText("auth.bin", authJson);

            errorLabel.Text = "✔ Пароль успішно змінено!";
            errorLabel.ForeColor = successColor;

            txtCurrent.BackColor = textBoxSuccessBack;
            txtNew.BackColor = textBoxSuccessBack;
            txtConfirm.BackColor = textBoxSuccessBack;
        }

        private string hashPasswordMD5(string password)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}