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
    public partial class RegisterForm : Form
    {
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

        public RegisterForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;

            // Живе очищення помилок через TextChanged
            txtName.TextChanged += (s, e) => ClearErrorOnInput(txtName, lbError1);
            txtEmail.TextChanged += (s, e) => ClearErrorOnInput(txtEmail, lbError2);
            txtPassword.TextChanged += (s, e) => ClearErrorOnInput(txtPassword, lbError3);
            txtPassword2.TextChanged += (s, e) => ClearErrorOnInput(txtPassword2, lbError4);

            // 1. Спочатку завантажуємо налаштування з файлу appsettings.json
            LoadSettings();

            // 2. Одразу застосовуємо тему, щоб форма не "блимала" при переході
            ApplyTheme();
            SetupButtonHoverEffects();
        }

        // --- МЕТОД ДЛЯ СТВОРЕННЯ КАСТОМНИХ ПОВІДОМЛЕНЬ (Заміна MessageBox) ---

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
                Color lightColor = Color.FromArgb(237, 239, 241);

                this.BackColor = lightColor;
                defaultTextBoxBack = lightColor;
                defaultForeColor = Color.Black;

                errorColor = Color.Red;
                successColor = Color.DarkGreen;
                textBoxErrorBack = Color.FromArgb(255, 230, 230);
                textBoxSuccessBack = Color.FromArgb(230, 255, 230);
            }

            UpdateControlColors();

            int attributeValue = isDarkMode ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attributeValue, sizeof(int));
            this.Refresh();
        }

        private void UpdateControlColors()
        {
            Label[] labels = { label1, label2, label3, label4, label6 };

            foreach (var lb in labels)
            {
                if (lb != null)
                {
                    lb.ForeColor = defaultForeColor;
                    lb.BackColor = isDarkMode ? Color.Transparent : Color.FromArgb(237, 239, 241);
                }
            }

            if (chBoxRememberMe != null)
            {
                chBoxRememberMe.ForeColor = defaultForeColor;
                chBoxRememberMe.BackColor = isDarkMode ? Color.Transparent : Color.FromArgb(237, 239, 241);
            }

            Color btnBack = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
            Color btnFore = isDarkMode ? Color.White : Color.Black;

            if (btnCreateAcc != null) { btnCreateAcc.BackColor = btnBack; btnCreateAcc.ForeColor = btnFore; }
            if (btnEye != null) { btnEye.BackColor = btnBack; btnEye.ForeColor = btnFore; }
            if (btnEye2 != null) { btnEye2.BackColor = btnBack; btnEye2.ForeColor = btnFore; }

            UpdateTextBoxThemeState(txtName, lbError1);
            UpdateTextBoxThemeState(txtEmail, lbError2);
            UpdateTextBoxThemeState(txtPassword, lbError3);
            UpdateTextBoxThemeState(txtPassword2, lbError4);
        }

        private void SetupButtonHoverEffects()
        {
            Button[] formsButtons = { btnCreateAcc, btnEye, btnEye2 };
            foreach (var btn in formsButtons)
            {
                if (btn == null) continue;
                btn.Cursor = Cursors.Hand;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = isDarkMode ? 0 : 1;
                btn.FlatAppearance.BorderColor = Color.DarkGray;

                btn.MouseEnter += (s, e) => {
                    btn.BackColor = isDarkMode ? Color.FromArgb(80, 80, 80) : Color.FromArgb(230, 233, 237);
                };
                btn.MouseLeave += (s, e) => {
                    btn.BackColor = isDarkMode ? Color.FromArgb(64, 64, 64) : Color.White;
                };
            }
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
                tb.ForeColor = defaultForeColor;
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
                catch { users = new List<User>(); }
            }

            // 1. ВАЛІДАЦІЯ ЛОГІНА
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                SetErrorStyle(txtName, lbError1, "⚠ Введіть логін.");
                isValid = false;
            }
            // Використовуємо звичайний Length для підрахунку символів рядка
            else if (txtName.Text.Length < 3)
            {
                SetErrorStyle(txtName, lbError1, "⚠ Логін має бути не менше 3 символів.");
                isValid = false;
            }
            else if (txtName.Text.Length > 20)
            {
                SetErrorStyle(txtName, lbError1, "⚠ Логін має бути не більше 20 символів.");
                isValid = false;
            }
            else
            {
                SetSuccessStyle(txtName, lbError1, "✔ Логін прийнято.");
            }

            // 2. ВАЛІДАЦІЯ EMAIL
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                SetErrorStyle(txtEmail, lbError2, "⚠ Введіть Email.");
                isValid = false;
            }
            else if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                SetErrorStyle(txtEmail, lbError2, "⚠ Некоректний формат Email.");
                isValid = false;
            }
            else if (users.Any(x => x.Email != null && x.Email.Equals(txtEmail.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                SetErrorStyle(txtEmail, lbError2, "⚠ Користувач з даною поштою вже зареєстрований.");
                isValid = false;
            }
            else
            {
                SetSuccessStyle(txtEmail, lbError2, "✔ Email прийнято.");
            }

            // 3. ВАЛІДАЦІЯ ПАРОЛЯ
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                SetErrorStyle(txtPassword, lbError3, "⚠ Введіть пароль.");
                isValid = false;
            }
            else if (txtPassword.Text.Length < 8)
            {
                SetErrorStyle(txtPassword, lbError3, "⚠ Пароль має бути не менше 8 символів.");
                isValid = false;
            }
            else
            {
                SetSuccessStyle(txtPassword, lbError3, "✔ Пароль прийнято.");
            }

            // 4. ВАЛІДАЦІЯ ПІДТВЕРДЖЕННЯ
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
                SetSuccessStyle(txtPassword2, lbError4, "✔ Паролі підтверджено.");
            }

            if (!isValid) return;

            try
            {
                User newUser = new User
                {
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = hashPasswordMD5(txtPassword.Text)
                };

                users.Add(newUser);
                string updatedJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("storage.json", updatedJson);
                ToMainForm();
            }
            catch (Exception ex)
            {
                lbError3.Text = "⚠ Щось пішло не так. Спробуйте ще раз.";
            }
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
            if (tb != null) { tb.BackColor = textBoxSuccessBack; tb.ForeColor = defaultForeColor; }
        }

        private void ResetValidationStyles()
        {
            Label[] labels = { lbError1, lbError2, lbError3, lbError4 };
            TextBox[] boxes = { txtName, txtEmail, txtPassword, txtPassword2 };

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

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
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
                txtName.Text = "Владислав";
                txtEmail.Text = "vlad.radionov877@gmail.com";
                txtPassword.Text = "12345678a!";
                txtPassword2.Text = "12345678a!";
            }
            else
            {
                txtName.Text = ""; txtEmail.Text = ""; txtPassword.Text = ""; txtPassword2.Text = "";
            }
        }

        private void chBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEye_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void btnEye2_Click(object sender, EventArgs e)
        {
            txtPassword2.UseSystemPasswordChar = !txtPassword2.UseSystemPasswordChar;
        }
    }
}

// --- ШПАРГАЛКИ --- //

/*

- Зміна теми програми

private bool isDarkMode = false;
private string configPath = "appsettings.json";

private void ApplyTheme()
        {
            bool dark = isDarkMode;
            this.BackColor = dark ? Color.FromArgb(38, 38, 38) : SystemColors.Control;
            label.ForeColor = dark ? Color.White : SystemColors.ControlText;
			radioButton.ForeColor = dark ? Color.White : SystemColors.ControlText;
            button.ForeColor = dark ? Color.White : SystemColors.ControlText;
            button.BackColor = dark ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
		}
(вставити у public partial class, а викликати під InitializeComponent() і об'єктах, з якими має бути взаємодія. Ще бажано вставити під )

Якщо у нас за зміну теми відповідає кнопка, то вставляємо в неї ось цей код:
isDarkMode = !isDarkMode;
ApplyTheme();

А в ApplyTheme() вставляємо ось це:
button1.Text = dark ? "Світла" : "Темна";

Якщо ж за зміну теми відповідають радіобатони, то вставляємо ЛИШЕ ДЛЯ ТОГО, ЩО ВІДПОВІДАЄ ЗА СВІТЛУ ТЕМУ ось цей код:
isDarkMode = !isDarkMode;
ApplyTheme();

А для іншого радіобатона лише ApplyTheme();

 
- Зміна теми для вікна заголовка (DWM API)

[DllImport("dwmapi.dll")]
private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
(вставити у public partial class)

int attributeValue = dark ? 1 : 0; // 1 — темна тема, 0 — світла тема
DwmSetWindowAttribute(this.Handle, 20, ref attributeValue, sizeof(int));
(вставити у ApplyTheme)


- Збереження теми

private void LoadSettings()
{
    try
    {
        if (File.Exists(configPath))
        {
            string jsonString = File.ReadAllText(configPath);
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                // Перевіряємо, чи записано в полі "theme" значення "dark"
                isDarkMode = doc.RootElement.GetProperty("theme").GetString() == "dark";
            }
        }
    }
    catch 
    { 
        isDarkMode = false; // Якщо файл пошкоджено — вмикаємо світлу тему
    }
}
(вставити у public partial class, а викликати під InitializeComponent())


- Прибрати "мерехтіння" форми (DoubleBuffered)
Я чесно хз, нащо воно треба і як воно впливає на програму, але нехай буде

this.DoubleBuffered = true;
(вставити під InitializeComponent())


- Заборона розтягувати вікно

this.FormBorderStyle = FormBorderStyle.FixedSingle;
this.MaximizeBox = false;
(вставити під InitializeComponent();)


- Перехід до іншої форми і закриття поточної

MainForm mainForm = new MainForm();
this.Hide();
mainForm.ShowDialog();
this.Close();
(вставити в об'єкт, з яким має бути взаємодія)

- Перехід до іншої форми без закриття поточної
MainForm mainForm = new MainForm();
mainForm.ShowDialog();
(вставити в об'єкт, з яким має бути взаємодія)

- Перехід до іншої форми без закриття поточної
MainForm mainForm = new MainForm();
mainForm.ShowDialog();
(вставити в об'єкт, з яким має бути взаємодія)

- Перехід до іншої форми і закриття двох (поточну і ту, що була відкритою до неї)
MainForm mainForm = new MainForm();
this.Hide();
mainForm.ShowDialog();
Application.Exit();
(вставити в об'єкт, з яким має бути взаємодія)


- Перевірка введення коректного Email

if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                CustomMessageBox.Show("Некоректний формат Email", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


- Прибирання помилки при введенні тексту

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
(вставити у public partial class, а викликати в TextChanged кожного TextBox)


- Хешування пароля за допомогою MD5

private string hashPasswordMD5(string password)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
(вставити у public partial class)


- Скорочені назви елементів з Toolbox

Button — btn
CheckBox — chBox
Label — lb
LinkLabel — linkLb
RadioButton — rdBtn
TxtBox — txt
*/