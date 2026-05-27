//using Newtonsoft.Json;
using MailKit.Net.Smtp;
using Microsoft.VisualBasic.ApplicationServices;
using MimeKit;
using System.Text.Json;

namespace FormOptions
{
    public partial class LoginForm : Form
    {
        // Налаштування теми
        bool isDarkMode = false;
        string configPath = "appsettings.json";


        public LoginForm()
        {
            InitializeComponent();

            txtEmail.TextChanged += (s, e) => ClearErrorOnInput(txtEmail, label11);
            txtPassword.TextChanged += (s, e) => ClearErrorOnInput(txtPassword, label12);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            ApplyTheme();
        }

        // --- Теми та налаштування ---
        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
            SaveSettings();
        }

        private void ApplyTheme()
        {
            bool dark = isDarkMode;
            this.BackColor = dark ? Color.FromArgb(26, 26, 26) : SystemColors.Control;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    if (lbl.Tag?.ToString() == "error")
                    {
                        lbl.ForeColor = dark ? Color.LightCoral : Color.Red;
                    }
                    else
                    {
                        lbl.ForeColor = dark ? Color.White : Color.Black;
                    }
                }


                if (ctrl is Button btn)
                {
                    btn.BackColor = dark ? Color.DimGray : Color.White;
                    btn.ForeColor = dark ? Color.White : Color.Black;
                }
            }
            btnChangeStyles.Text = dark ? "Світла" : "Темна";
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
                        isDarkMode = (doc.RootElement.GetProperty("theme").GetString() == "dark");
                    }
                }
            }
            catch { }
        }

        private void SaveSettings()
        {
            try
            {
                var data = new { theme = isDarkMode ? "dark" : "light" };
                string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, jsonString);
            }
            catch { }
        }
        private void ClearErrorOnInput(TextBox textBox, Label errorLabel)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorLabel.Visible = false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                label11.Visible = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                label12.Visible = true;
                hasError = true;
            }

            if (!hasError)
            {
                var users = new List<User>();
                if (File.Exists("storage.json"))
                {
                    string json = File.ReadAllText("storage.json");
                    users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json)
                        ?? new List<User>();
                }
                
                User? user = users.SingleOrDefault(x => x.Email == txtEmail.Text);

                if (user!=null)
                {
                    if (!string.IsNullOrEmpty(user.Value.Email))
                    {
                        if (user.Value.Password == hashPasswordMD5(txtPassword.Text))
                        {
                            MessageBox.Show("Вхід успішний!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //this.Close();
                            string fileAuthUser = "auth.bin";
                            string json = Newtonsoft.Json.JsonConvert.SerializeObject(user); // інформація про користувача
                            File.WriteAllText(fileAuthUser, json);
                            //Це означає, що кристувач успішно зайшов
                            DialogResult = DialogResult.OK;
                            this.Close();
                            return;

                        }
                    }
                }

                MessageBox.Show("Дані вказано не вірно");
                return;

            }

        }

        private void btnVissiblePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }


        private string hashPasswordMD5(string password)
        {
            // Використання MD5 для хешування пароля (не рекомендується для безпеки)
            using var md5 = System.Security.Cryptography.MD5.Create();
            // Перетворення пароля у байти
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            //та обчислення хешу
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            // Перетворення хешу у шістнадцятковий рядок
            return Convert.ToHexString(hashBytes); // .NET 5+ method
        }

        private void btnToLogin_Click(object sender, EventArgs e)
        {
            RegisterForm dlg = new RegisterForm();
            dlg.ShowDialog();
            //this.Close();
        }



        private void btnRestoreRequest_Click(object sender, EventArgs e)
        {
            string message = "Відновлення паролю";
            string body = "Ось код для відновлення паролю: ";
            string to = txtEmail.Text;
            MySendEmail(message, body, to);

        }

        async Task MySendEmail(string subject, string body, string to)
        {
            //пароль для додатку
            string password = "mNVAsm2BvttvjJlW"; //пароль у кожного свій
                                                  //назва smtp - сервера
            string smtpServer = "smtp.ukr.net";
            //потр на якому працює сервер
            int port = 2525;
            //хто буде відправляти листи
            string from = "super.novakvova@ukr.net"; //користувач у кожного свій
                                                     //ім'я користувача
            string username = from;


            //string to = "novakvova@gmail.com";

            //var attachment = new MimePart("image", "webp")
            //{
            //    FileName = "Привіт друже",
            //    Content = new MimeContent(File.OpenRead(file))
            //};

            var bodyHtml = new TextPart("html")
            {
                Text = body
            };
            var multipart = new Multipart("mixed");
            multipart.Add(bodyHtml);
            //multipart.Add(attachment);

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(from));
            emailMessage.To.Add(new MailboxAddress(to));
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
                MessageBox.Show(ex.Message, "Щось пішло не так!");
                //Console.WriteLine("Error send EMAIL {0}", ex.Message);
            }
        }




    }
}