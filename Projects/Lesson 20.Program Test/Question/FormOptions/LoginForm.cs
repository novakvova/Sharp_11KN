//using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;
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
                string json = File.ReadAllText("storage.json");
                var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json)
                    ?? new List<User>();

                User? user = users.SingleOrDefault(x => x.Email == txtEmail.Text);

                if (user!=null)
                {
                    if (!string.IsNullOrEmpty(user.Value.Email))
                    {
                        if (user.Value.Password == hashPasswordMD5(txtPassword.Text))
                        {
                            MessageBox.Show("Вхід успішний!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //this.Close();
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
            this.Close();
        }
    }
}