using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace FormOptions
{
    public partial class ResetPasswordForm : Form
    {
        private string userEmail;
        private List<User> users;

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

        public ResetPasswordForm(string email)
        {
            this.userEmail = email;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(450, 350);
            this.Text = "Установлення нового пароля";

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
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(33, 35, 38);
                defaultTextBoxBack = Color.FromArgb(33, 35, 38);
                defaultForeColor = Color.White;
                errorColor = Color.FromArgb(255, 120, 120);
                successColor = Color.FromArgb(144, 238, 144);
                textBoxErrorBack = Color.FromArgb(70, 40, 40);
                textBoxSuccessBack = Color.FromArgb(40, 70, 40);
            }
            else
            {
                this.BackColor = Color.FromArgb(237, 239, 241);
                defaultTextBoxBack = Color.FromArgb(237, 239, 241);
                defaultForeColor = Color.Black;
                errorColor = Color.Red;
                successColor = Color.DarkGreen;
                textBoxErrorBack = Color.FromArgb(255, 230, 230);
                textBoxSuccessBack = Color.FromArgb(230, 255, 230);
            }

            int attrValue = isDarkMode ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attrValue, sizeof(int));
        }

        private void CreateControls()
        {
            // Завантажуємо користувачів
            if (File.Exists("storage.json"))
            {
                string json = File.ReadAllText("storage.json");
                users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            else
            {
                users = new List<User>();
            }

            Label lblTitle = new Label
            {
                Text = "Установлення нового пароля",
                Location = new Point(20, 20),
                Size = new Size(410, 30),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = defaultForeColor,
                BackColor = this.BackColor
            };
            this.Controls.Add(lblTitle);

            Label lblEmail = new Label
            {
                Text = $"Акаунт: {userEmail}",
                Location = new Point(20, 55),
                Size = new Size(410, 20),
                Font = new Font("Arial", 10),
                ForeColor = defaultForeColor,
                BackColor = this.BackColor
            };
            this.Controls.Add(lblEmail);

            Label lblNewPass = new Label
            {
                Text = "Новий пароль (мін. 4 символи):",
                Location = new Point(20, 85),
                AutoSize = true,
                ForeColor = defaultForeColor,
                BackColor = this.BackColor
            };
            this.Controls.Add(lblNewPass);

            TextBox txtNewPass = new TextBox
            {
                Location = new Point(20, 110),
                Size = new Size(410, 30),
                BackColor = defaultTextBoxBack,
                ForeColor = defaultForeColor,
                UseSystemPasswordChar = true,
                Font = new Font("Arial", 10)
            };
            txtNewPass.TextChanged += (s, e) => ClearError(null);
            this.Controls.Add(txtNewPass);

            Label lblConfirmPass = new Label
            {
                Text = "Підтвердити пароль:",
                Location = new Point(20, 150),
                AutoSize = true,
                ForeColor = defaultForeColor,
                BackColor = this.BackColor
            };
            this.Controls.Add(lblConfirmPass);

            TextBox txtConfirmPass = new TextBox
            {
                Location = new Point(20, 175),
                Size = new Size(410, 30),
                BackColor = defaultTextBoxBack,
                ForeColor = defaultForeColor,
                UseSystemPasswordChar = true,
                Font = new Font("Arial", 10)
            };
            txtConfirmPass.TextChanged += (s, e) => ClearError(null);
            this.Controls.Add(txtConfirmPass);

            Label lblError = new Label
            {
                Location = new Point(20, 215),
                Size = new Size(410, 40),
                ForeColor = errorColor,
                AutoSize = false,
                BackColor = this.BackColor
            };
            this.Controls.Add(lblError);

            Button btnReset = new Button
            {
                Text = "Установити новий пароль",
                Location = new Point(20, 260),
                Size = new Size(200, 40),
                BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White,
                ForeColor = defaultForeColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnReset.Click += (s, e) => ResetPassword(txtNewPass.Text, txtConfirmPass.Text, lblError);
            this.Controls.Add(btnReset);

            Button btnCancel = new Button
            {
                Text = "Скасувати",
                Location = new Point(230, 260),
                Size = new Size(200, 40),
                BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White,
                ForeColor = defaultForeColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);
        }

        private void ResetPassword(string newPassword, string confirmPassword, Label errorLabel)
        {
            // Валідація
            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ShowError(errorLabel, "⚠ Всі поля мають бути заповнені");
                return;
            }

            if (newPassword.Length < 4)
            {
                ShowError(errorLabel, "⚠ Пароль має мати мінімум 4 символи");
                return;
            }

            if (newPassword != confirmPassword)
            {
                ShowError(errorLabel, "⚠ Паролі не співпадають");
                return;
            }

            // Знаходимо користувача
            var user = users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                ShowError(errorLabel, "⚠ Користувача не знайдено");
                return;
            }

            // Оновлюємо пароль
            user.Password = hashPasswordMD5(newPassword);

            // Зберігаємо в storage.json
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("storage.json", json);

            // Оновлюємо auth.bin також
            if (File.Exists("auth.bin"))
            {
                try
                {
                    string userJson = JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("auth.bin", userJson);
                }
                catch { }
            }

            // Показуємо успіх
            errorLabel.Text = "✔ Пароль успішно змінено!";
            errorLabel.ForeColor = successColor;

            System.Threading.Thread.Sleep(1500);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowError(Label errorLabel, string message)
        {
            errorLabel.Text = message;
            errorLabel.ForeColor = errorColor;
        }

        private void ClearError(Label errorLabel)
        {
            if (errorLabel != null)
            {
                errorLabel.Text = "";
            }
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
