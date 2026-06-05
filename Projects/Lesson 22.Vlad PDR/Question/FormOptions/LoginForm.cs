using FormOptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

namespace FormOptions
{
    public partial class LoginForm : Form
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

        public LoginForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;

            txtEmail.TextChanged += (s, e) => ClearErrorOnInput(txtEmail, lbError1);
            txtPassword.TextChanged += (s, e) => ClearErrorOnInput(txtPassword, lbError3);

            LoadSettings();
            ApplyTheme();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private DialogResult ShowCustomMessageBox(string text, string title, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            using (Form msgForm = new Form())
            {
                msgForm.Text = title;
                msgForm.Size = new Size(440, 180);
                msgForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                msgForm.StartPosition = FormStartPosition.CenterParent;
                msgForm.MaximizeBox = false;
                msgForm.MinimizeBox = false;

                Color bg = isDarkMode ? Color.FromArgb(28, 30, 33) : Color.FromArgb(245, 246, 248);
                Color textCol = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
                Color btnBg = isDarkMode ? Color.FromArgb(41, 43, 47) : Color.White;
                Color btnHover = isDarkMode ? Color.FromArgb(51, 54, 59) : Color.FromArgb(235, 238, 242);
                Color btnActive = isDarkMode ? Color.FromArgb(33, 35, 38) : Color.FromArgb(220, 224, 228);
                Color borderCol = isDarkMode ? Color.FromArgb(55, 55, 55) : Color.FromArgb(218, 220, 224);

                msgForm.BackColor = bg;

                Label lblText = new Label
                {
                    Text = text,
                    Left = 25,
                    Top = 25,
                    Width = 375,
                    Height = 50,
                    ForeColor = textCol,
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent
                };
                msgForm.Controls.Add(lblText);

                if (buttons == MessageBoxButtons.YesNo)
                {
                    Button btnNo = new Button
                    {
                        Text = "Ні",
                        Left = 290,
                        Top = 90,
                        Size = new Size(110, 34),
                        BackColor = btnBg,
                        ForeColor = textCol,
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = DialogResult.No,
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        Cursor = Cursors.Default
                    };
                    btnNo.FlatAppearance.BorderSize = 1;
                    btnNo.FlatAppearance.BorderColor = borderCol;
                    btnNo.FlatAppearance.MouseOverBackColor = btnHover;
                    btnNo.FlatAppearance.MouseDownBackColor = btnActive;

                    Button btnYes = new Button
                    {
                        Text = "Так",
                        Left = 170,
                        Top = 90,
                        Size = new Size(110, 34),
                        BackColor = btnBg,
                        ForeColor = textCol,
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = DialogResult.Yes,
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        Cursor = Cursors.Default
                    };
                    btnYes.FlatAppearance.BorderSize = 1;
                    btnYes.FlatAppearance.BorderColor = borderCol;
                    btnYes.FlatAppearance.MouseOverBackColor = btnHover;
                    btnYes.FlatAppearance.MouseDownBackColor = btnActive;

                    msgForm.Controls.Add(btnYes);
                    msgForm.Controls.Add(btnNo);
                    msgForm.AcceptButton = btnYes;
                    msgForm.CancelButton = btnNo;
                }
                else
                {
                    Button btnOk = new Button
                    {
                        Text = "Продовжити",
                        Left = 250,
                        Top = 90,
                        Size = new Size(150, 34),
                        BackColor = btnBg,
                        ForeColor = textCol,
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = DialogResult.OK,
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        Cursor = Cursors.Default
                    };
                    btnOk.FlatAppearance.BorderSize = 1;
                    btnOk.FlatAppearance.BorderColor = borderCol;
                    btnOk.FlatAppearance.MouseOverBackColor = btnHover;
                    btnOk.FlatAppearance.MouseDownBackColor = btnActive;

                    msgForm.Controls.Add(btnOk);
                    msgForm.AcceptButton = btnOk;
                }

                int attrValue = isDarkMode ? 1 : 0;
                DwmSetWindowAttribute(msgForm.Handle, 20, ref attrValue, sizeof(int));

                return msgForm.ShowDialog();
            }
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
                successColor = Color.FromArgb(100, 220, 100);
                textBoxErrorBack = Color.FromArgb(60, 35, 35);
                textBoxSuccessBack = Color.FromArgb(35, 55, 35);
            }
            else
            {
                this.BackColor = Color.FromArgb(245, 246, 248);
                defaultTextBoxBack = Color.White;
                defaultForeColor = Color.FromArgb(30, 30, 30);

                errorColor = Color.FromArgb(200, 40, 40);
                successColor = Color.FromArgb(40, 140, 40);
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
            Label[] labels = { label3, label5, label6 };

            foreach (var lb in labels)
            {
                if (lb != null)
                {
                    lb.ForeColor = defaultForeColor;
                    lb.BackColor = Color.Transparent;
                    lb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
            }

            if (chBoxRememberMe != null)
            {
                chBoxRememberMe.ForeColor = defaultForeColor;
                chBoxRememberMe.BackColor = Color.Transparent;
                chBoxRememberMe.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                chBoxRememberMe.Cursor = Cursors.Default;
            }

            if (checkBox1 != null)
            {
                checkBox1.ForeColor = defaultForeColor;
                checkBox1.BackColor = Color.Transparent;
                checkBox1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                checkBox1.Cursor = Cursors.Default;
            }

            Color btnBg = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            Color btnHover = dark ? Color.FromArgb(51, 54, 59) : Color.FromArgb(235, 238, 242);
            Color btnActive = dark ? Color.FromArgb(33, 35, 38) : Color.FromArgb(220, 224, 228);
            Color btnBorder = dark ? Color.FromArgb(55, 55, 55) : Color.FromArgb(218, 220, 224);

            Button[] buttons = { btnCreateAcc, btnEye };
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
            if (btnEye != null) btnEye.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            LinkLabel[] links = { linkLbToLog, linkLbForgetPassword };
            foreach (var lnk in links)
            {
                if (lnk != null)
                {
                    lnk.LinkColor = dark ? Color.FromArgb(140, 190, 255) : Color.FromArgb(0, 102, 204);
                    lnk.ActiveLinkColor = dark ? Color.White : Color.Black;
                    lnk.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    lnk.BackColor = Color.Transparent;
                }
            }

            UpdateTextBoxThemeState(txtEmail, lbError1);
            UpdateTextBoxThemeState(txtPassword, lbError3);
        }

        private void UpdateTextBoxThemeState(TextBox tb, Label lb)
        {
            if (tb == null || lb == null) return;

            tb.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            tb.BorderStyle = BorderStyle.FixedSingle;

            if (!string.IsNullOrEmpty(lb.Text) && lb.Text.Contains("⚠"))
            {
                tb.BackColor = textBoxErrorBack;
                tb.ForeColor = isDarkMode ? Color.FromArgb(255, 120, 120) : Color.Red;
                lb.ForeColor = errorColor;
                lb.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }
            else if (!string.IsNullOrEmpty(lb.Text) && lb.Text.Contains("✔"))
            {
                tb.BackColor = textBoxSuccessBack;
                tb.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
                lb.ForeColor = successColor;
                lb.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
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

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                SetErrorStyle(txtEmail, lbError1, "⚠ Введіть Email.");
                isValid = false;
            }
            else if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                SetErrorStyle(txtEmail, lbError1, "⚠ Некоректний формат Email.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                SetErrorStyle(txtPassword, lbError3, "⚠ Введіть пароль.");
                isValid = false;
            }

            if (!isValid) return;

            try
            {
                if (!File.Exists("storage.json"))
                {
                    recaptchaForm recaptcha = new recaptchaForm("");
                    recaptcha.ShowDialog();
                    SetErrorStyle(txtEmail, lbError1, "⚠ Користувача не знайдено.");
                    return;
                }

                string json = File.ReadAllText("storage.json");
                var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                var user = users.FirstOrDefault(x => x.Email != null && x.Email.Trim().Equals(txtEmail.Text.Trim(), StringComparison.OrdinalIgnoreCase));

                if (user == null)
                {
                    recaptchaForm recaptcha = new recaptchaForm("");
                    recaptcha.ShowDialog();
                    SetErrorStyle(txtEmail, lbError1, "⚠ Користувача не знайдено.");
                    return;
                }

                string hashedInputPassword = hashPasswordMD5(txtPassword.Text);

                if (user.Password != hashedInputPassword)
                {
                    SetErrorStyle(txtPassword, lbError3, "⚠ Невірний пароль.");
                    return;
                }

                SetSuccessStyle(txtEmail, lbError1, "✔ Логін знайдено");
                SetSuccessStyle(txtPassword, lbError3, "✔ Пароль вірний");

                string fileAuthUser = "auth.bin";
                string authJson = JsonSerializer.Serialize(user);
                File.WriteAllText(fileAuthUser, authJson);

                ToMainForm();
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox($"Помилка при зчитуванні бази даних: {ex.Message}", "Помилка", MessageBoxButtons.OK);
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
            if (tb != null) { tb.BackColor = textBoxSuccessBack; tb.ForeColor = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30); }
        }

        private void ResetValidationStyles()
        {
            Label[] labels = { lbError1, lbError3 };
            TextBox[] boxes = { txtEmail, txtPassword };

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
            RegisterForm regForm = new RegisterForm();
            this.Hide();
            regForm.ShowDialog();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtEmail.Text = "vlad.radionov877@gmail.com";
            }
            else
            {
                txtEmail.Text = "";
            }
        }

        private void chBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {
        }

        private async void linkLbForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetValidationStyles();

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                SetErrorStyle(txtEmail, lbError1, "⚠ Введіть Email для відновлення пароля.");
                return;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                SetErrorStyle(txtEmail, lbError1, "⚠ Некоректний формат Email.");
                return;
            }

            recaptchaForm recaptcha = new recaptchaForm("");
            recaptcha.ShowDialog();

            try
            {
                if (!File.Exists("storage.json"))
                {
                    SetErrorStyle(txtEmail, lbError1, "⚠ База даних порожня. Зареєструйтесь!");
                    return;
                }

                string json = File.ReadAllText("storage.json");
                var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                var user = users.FirstOrDefault(x => x.Email != null && x.Email.Trim().Equals(txtEmail.Text.Trim(), StringComparison.OrdinalIgnoreCase));

                if (user == null)
                {
                    SetErrorStyle(txtEmail, lbError1, "⚠ Користувача з таким Email не знайдено.");
                    return;
                }

                Random rand = new Random();
                string recoveryCode = rand.Next(100000, 999999).ToString();

                string message = "Відновлення паролю";
                string body = $"<h3>КОД ВІДНОВЛЕННЯ ПАРОЛЮ: <b>{recoveryCode}</b></h3>" +
                    $"<p>Введіть цей код у програмі для відновлення паролю.</p>" +
                    $"<p>‼️ Не повідомляйте цей код нікому! Ми більше ні для чого його не просимо.</p>" +
                    $"<p>Якщо ви не намагаєтесь відновити пароль, проігноруйте цей лист.</p>";
                string to = txtEmail.Text.Trim();

                await MySendEmail(message, body, to);

                ShowCustomMessageBox("Код відновлення було відправлено на ваш Email.\nБудь ласка, перевірте вашу пошту.", "Успіх", MessageBoxButtons.OK);

                PasswordForm passwordForm = new PasswordForm(recoveryCode, to);
                passwordForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox($"Помилка при відновленні пароля: {ex.Message}", "Помилка", MessageBoxButtons.OK);
            }
        }

        async Task MySendEmail(string subject, string body, string to)
        {
            string password = "8csOk2OFw044usql";
            string smtpServer = "smtp.ukr.net";
            int port = 2525;
            string from = "vladyslav_radik@ukr.net";
            string username = from;

            var bodyHtml = new TextPart("html") { Text = body };
            var multipart = new Multipart("mixed") { bodyHtml };

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("", from));
            emailMessage.To.Add(new MailboxAddress("", to));
            emailMessage.Subject = subject;
            emailMessage.Body = multipart;

            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(smtpServer, port, true);
                await client.AuthenticateAsync(username, password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox(ex.Message, "Помилка відправки пошти");
            }
        }

        private void btnEye_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }
    }
}