using System.Text.Json;

namespace FormOptions
{
    public partial class TestForm : Form
    {
        // Налаштування теми
        bool isDarkMode = false;
        string configPath = "appsettings.json";

        // Логіка тесту
        private int currentQuestionIndex = 0;
        private int score = 0;

        // Таймер
        private System.Windows.Forms.Timer testTimer;
        private int totalTimeSeconds = 150; // 5 хвилин на весь тест
        private int timePerQuestionSeconds = 30; // 60 секунд на питання
        private int remainingTimeTotal;
        private int remainingTimeQuestion;

        private List<Question> questions = new List<Question>
        {
            new Question {
                Text = "Яка подія вважається початком Другої світової війни?",
                Answers = new[] { "Напад на Польщу", "Аншлюс Австрії", "Перл-Гарбор", "Пакт М-Р" },
                CorrectAnswerIndex = 0
            },
            new Question {
                Text = "Як називався німецький план нападу на СРСР?",
                Answers = new[] { "Вайс", "Барбаросса", "Оверлорд", "Гельб" },
                CorrectAnswerIndex = 1
            },
            new Question {
                Text = "В якому році відбулася висадка в Нормандії?",
                Answers = new[] { "1941", "1943", "1944", "1945" },
                CorrectAnswerIndex = 2
            },
            new Question {
                Text = "Що намалювали вандали на електричці?",
                Answers = new[] { "Свастику", "Смайлик", "ЦОЙ ЖИВ", "Інше" },
                CorrectAnswerIndex = 0
            }
        };

        public TestForm()
        {
            InitializeComponent();

            // Підписуємо всі радіобатони на подію активації кнопки
            rdBtnAnswer1.CheckedChanged += AnyRadioButton_CheckedChanged;
            rdBtnAnswer2.CheckedChanged += AnyRadioButton_CheckedChanged;
            rdBtnAnswer3.CheckedChanged += AnyRadioButton_CheckedChanged;
            rdBtnAnswer4.CheckedChanged += AnyRadioButton_CheckedChanged;
            // Ініціалізація таймера
            testTimer = new System.Windows.Forms.Timer();
            testTimer.Interval = 1000; // 1 секунда
            testTimer.Tick += TestTimer_Tick;
        }

        private void TestTimer_Tick(object sender, EventArgs e)
        {
            remainingTimeTotal--;
            remainingTimeQuestion--;

            // Оновлюємо дисплей часу
            UpdateTimeDisplay();

            // Час закінчився на питання
            if (remainingTimeQuestion <= 0)
            {
                remainingTimeQuestion = timePerQuestionSeconds;
                btnCont_Click(null, null); // Автоматично переходимо на наступне питання
            }

            // Час закінчився на весь тест
            if (remainingTimeTotal <= 0)
            {
                testTimer.Stop();
                MessageBox.Show($"Час вийшов! " +
                    $"Правильних відповідей: " +
                    $"{score} з {questions.Count}", "Результат");
                RestartTest();
            }
        }


        private void UpdateTimeDisplay()
        {
            // Форматування часу: MM:SS
            int minutesTotal = remainingTimeTotal / 60;
            int secondsTotal = remainingTimeTotal % 60;

            int minutesQuestion = remainingTimeQuestion / 60;
            int secondsQuestion = remainingTimeQuestion % 60;

            // Встановлюємо текст для лейблів (якщо вони створені)
            if (lbTimerQuestion != null)
                lbTimerQuestion.Text = $"Час на питання: {minutesQuestion:D2}:{secondsQuestion:D2}";

            if (lbTimerTotal != null)
                lbTimerTotal.Text = $"Загальний час: {minutesTotal:D2}:{secondsTotal:D2}";

            // Змінюємо колір часу залежно від часу, що залишився
            if (remainingTimeQuestion <= 10 && lbTimerQuestion != null)
                lbTimerQuestion.ForeColor = Color.Red; // Червоний, коли мало часу
            else if (lbTimerQuestion != null)
                lbTimerQuestion.ForeColor = Color.Green;

            if (remainingTimeTotal <= 30 && lbTimerTotal != null)
                lbTimerTotal.ForeColor = Color.Red;
            else if (lbTimerTotal != null)
                lbTimerTotal.ForeColor = Color.Green;
        }

        private void RestartTest()
        {
            currentQuestionIndex = 0;
            score = 0;
            remainingTimeTotal = totalTimeSeconds;
            remainingTimeQuestion = timePerQuestionSeconds;
            DisplayQuestion();
            testTimer.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Закинемо усі питання у json файл.
            //Як questions перетворити у json?
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(questions,
                Newtonsoft.Json.Formatting.Indented); // включаючи дочірні елементи
            
            File.WriteAllText("questions.json", str);

            LoadSettings();
            ApplyTheme();

            // Ініціалізація часу
            remainingTimeTotal = totalTimeSeconds;
            remainingTimeQuestion = timePerQuestionSeconds;

            DisplayQuestion();
            testTimer.Start();
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var q = questions[currentQuestionIndex];

                lbQuestion.Text = q.Text;
                rdBtnAnswer1.Text = q.Answers[0];
                rdBtnAnswer2.Text = q.Answers[1];
                rdBtnAnswer3.Text = q.Answers[2];
                rdBtnAnswer4.Text = q.Answers[3];

                // Скидаємо вибір
                rdBtnAnswer1.Checked = false;
                rdBtnAnswer2.Checked = false;
                rdBtnAnswer3.Checked = false;
                rdBtnAnswer4.Checked = false;

                // РОБИМО КНОПКУ НЕАКТИВНОЮ
                btnCont.Enabled = false;
            }
            else
            {
                MessageBox.Show($"Тест закінчено! " +
                    $"Правильних відповідей: " +
                    $"{score} з {questions.Count}", "Результат");
                currentQuestionIndex = 0;
                score = 0;
                DisplayQuestion();
            }
        }

        // Подія: якщо будь-яка кнопка обрана — активуємо "Далі"
        private void AnyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                btnCont.Enabled = true;
            }
        }

        private void btnCont_Click(object sender, EventArgs e)
        {
            RadioButton[] answers = { rdBtnAnswer1, rdBtnAnswer2, rdBtnAnswer3, rdBtnAnswer4 };
            int selectedIndex = -1;

            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i].Checked)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == questions[currentQuestionIndex].CorrectAnswerIndex)
            {
                score++;
            }

            currentQuestionIndex++;
            DisplayQuestion();
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
                if (ctrl is Label || ctrl is RadioButton)
                    ctrl.ForeColor = dark ? Color.White : Color.Black;

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
    }
}