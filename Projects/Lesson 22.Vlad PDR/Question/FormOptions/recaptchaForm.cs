using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormOptions
{
    public partial class recaptchaForm : Form
    {
        private string correctCode;
        private bool isDarkMode = false;
        private string configPath = "appsettings.json";

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public recaptchaForm(string code)
        {
            InitializeComponent();
            this.correctCode = code;

            // Базові налаштування вікна для плавності графіки
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Завантажуємо і одразу застосовуємо налаштування теми
            LoadSettings();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            Color backColor, foreColor, controlBack, lb2color;

            if (isDarkMode) // ТЕМНА ТЕМА
            {
                backColor = Color.FromArgb(33, 35, 38);   // Графітовий фон форми
                controlBack = Color.FromArgb(30, 30, 30); // Глибокий темний для кнопок
                foreColor = Color.White;                  // Білий текст
                lb2color = Color.FromArgb(40, 42, 45);     // Кастомний колір для bgMessageForm
            }
            else // СВІТЛА ТЕМА
            {
                Color lightColor = Color.FromArgb(237, 239, 241); // Світло-сірий

                backColor = lightColor;
                controlBack = Color.White;
                foreColor = Color.Black;
                lb2color = Color.FromArgb(228, 230, 233);
            }

            // Застосовуємо до форми
            this.BackColor = backColor;

            // Застосовуємо до фону плашки знизу
            if (bgMessageForm != null)
            {
                bgMessageForm.BackColor = lb2color;
                bgMessageForm.FlatStyle = FlatStyle.Flat;
            }

            // Застосовуємо до чекбокса chBoxNotRobot
            if (chBoxNotRobot != null)
            {
                chBoxNotRobot.ForeColor = foreColor;
                chBoxNotRobot.Font = new Font("Segoe UI", 11F);

                // Розумне фарбування фону чекбокса залежно від розташування
                if (bgMessageForm != null && bgMessageForm.Bounds.Contains(chBoxNotRobot.Location))
                {
                    chBoxNotRobot.BackColor = lb2color; // Зливається з плашкою
                }
                else
                {
                    chBoxNotRobot.BackColor = isDarkMode ? Color.Transparent : backColor; // Зливається з формою
                }
            }

            // Застосовуємо до всіх написів (Label) на формі
            foreach (Control c in this.Controls)
            {
                if (c is Label lb)
                {
                    if (lb == bgMessageForm) continue;

                    lb.ForeColor = foreColor;
                    lb.Font = new Font("Segoe UI", 10F);

                    // Розумне фарбування фону лейблів
                    if (bgMessageForm != null && bgMessageForm.Bounds.Contains(lb.Location))
                    {
                        lb.BackColor = lb2color;
                    }
                    else
                    {
                        lb.BackColor = isDarkMode ? Color.Transparent : backColor; // ВИПРАВЛЕНО: замість hardcode кольору
                    }
                }
            }

            // Темний або світлий заголовок вікна ОС Windows (DWM)
            int attrValue = isDarkMode ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attrValue, sizeof(int));

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
            catch
            {
                isDarkMode = false; // Якщо файл пошкоджений, ставимо світлу за замовчуванням
            }
        }

        // ВИПРАВЛЕНО: Назва події узгоджена з класом форми
        private void recaptchaForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        // Змінено на async, щоб зробити реалістичну UX паузу після кліку
        private async void chBoxNotRobot_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxNotRobot.Checked)
            {
                // Захист від миттєвого зникнення: даємо юзеру 600 мс побачити галочку
                chBoxNotRobot.Enabled = false; // Блокуємо від повторних кліків
                await Task.Delay(600);

                // Встановлюємо успішний статус завершення діалогу
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Порожній метод залишено, якщо він підв'язаний у дизайнері
        }
    }
}