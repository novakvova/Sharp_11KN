//using Newtonsoft.Json;
using System.Text.Json;

namespace FormOptions
{
    public partial class RegisterForm : Form
    {
        // Налаштування теми
        bool isDarkMode = false;
        string configPath = "appsettings.json";


        public RegisterForm()
        {
            InitializeComponent();

            txtName.TextChanged += (s, e) => ClearErrorOnInput(txtName, label8); //використовується для очищення помилки
            txtLastName.TextChanged += (s, e) => ClearErrorOnInput(txtLastName, label9);
            txtGroup.TextChanged += (s, e) => ClearErrorOnInput(txtGroup, label10);
            txtEmail.TextChanged += (s, e) => ClearErrorOnInput(txtEmail, label11);
            txtPassword.TextChanged += (s, e) => ClearErrorOnInput(txtPassword, label12);
            txtPasswordCheck.TextChanged += (s, e) => ClearErrorOnInput(txtPasswordCheck, label13);
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                label8.Visible = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                label9.Visible = true;
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(txtGroup.Text))
            {
                label10.Visible = true;
                hasError = true;
            }

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

            if (string.IsNullOrWhiteSpace(txtPasswordCheck.Text))
            {
                label13.Visible = true;
                hasError = true;
            }
            if (txtPassword.Text != txtPasswordCheck.Text)
            {
                label13.Visible = true;
                hasError = true;
            }
            if (!hasError)
            {
                // Зберігає список користувачів
                List<User> users = new List<User>();

                var json = "";
                if (File.Exists("storage.json")) //Якщо існую користувачів, то ми їх читаємо
                    json = File.ReadAllText("storage.json");

                //Отримуємо усіх користувачів із файлу
                users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json)
                    ?? new List<User>();

                //Будемо шукати у списки користувача, який можна знайти по пошті
                //пошук 1 користувача, якщо їх 2 то буде 0
                User? user = users.SingleOrDefault(x => x.Email == txtEmail.Text);

                if (user!=null)
                {
                    if (!string.IsNullOrEmpty(user.Value.Email))
                    {
                        MessageBox.Show("Користувач з даною поштою уже зареєстрований");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Користувач з даною поштою уже зареєстрований");
                    return;
                }


                DialogResult = DialogResult.OK;
                User newUser = new User
                {
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    Group = txtGroup.Text,
                    Email = txtEmail.Text,
                    Password = hashPasswordMD5(txtPassword.Text)
                };

                users.Add(newUser);
                json = Newtonsoft.Json.JsonConvert.SerializeObject(users);
                File.WriteAllText("storage.json", json);
                ToLoginForm();
                //this.Hide();
                //LoginForm dlg = new LoginForm();
                //dlg.ShowDialog();
            }

        }

        private void btnVissiblePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            txtPasswordCheck.UseSystemPasswordChar = !txtPasswordCheck.UseSystemPasswordChar;
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
            //ToLoginForm();
            this.Close();
        }

        private void ToLoginForm()
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            if (loginForm.ShowDialog()==DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.Show();
                //this.Close();
            }
        }
    }
}