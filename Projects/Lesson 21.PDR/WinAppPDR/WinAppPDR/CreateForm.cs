using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace WinAppPDR
{
    public partial class CreateForm : Form
    {
        // тут мої змінні, якими буду керувати через код
        private Label lblTestName;
        private TextBox txtTestName;
        private Label lblQuestion;
        private TextBox txtQuestion;
        private Label lblOptions;
        private TextBox txtOptions;
        private Label lblCorrectIndex;
        private TextBox txtCorrectIndex;
        private Label lblCounter;
        private Button btnAddQuestion;
        private Button btnSaveTest;
        private Button btnChangeStyles;

        //--------------------
        private bool isDarkMode = true;
        private string configPath = "appsettings.json";
        private string testsFolder = Path.Combine(Application.StartupPath, "Tests");

        // список питань, які користувач додав під час поточного сеансу створення тесту
        private List<QuestionData> pendingQuestions = new List<QuestionData>();

        private void InitApp()
        {
            lblTestName = new Label();
            txtTestName = new TextBox();
            lblQuestion = new Label();
            txtQuestion = new TextBox();
            lblOptions = new Label();
            txtOptions = new TextBox();
            lblCorrectIndex = new Label();
            txtCorrectIndex = new TextBox();
            lblCounter = new Label();
            btnAddQuestion = new Button();
            btnSaveTest = new Button();
            btnChangeStyles = new Button();

            int col1 = 20, col2 = 160, w = 400, row = 20, step = 55;

            // Test name row
            lblTestName.Text = "Назва тесту:";
            lblTestName.Location = new Point(col1, row);
            lblTestName.Size = new Size(130, 30);
            lblTestName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtTestName.Location = new Point(col2, row);
            txtTestName.Size = new Size(w, 30);
            txtTestName.PlaceholderText = "Наприклад: Мій тест 1";
            row += step;

            // Question row
            lblQuestion.Text = "Питання:";
            lblQuestion.Location = new Point(col1, row);
            lblQuestion.Size = new Size(130, 30);
            lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtQuestion.Location = new Point(col2, row);
            txtQuestion.Size = new Size(w, 30);
            txtQuestion.PlaceholderText = "Текст питання";
            row += step;

            // Options row
            lblOptions.Text = "Варіанти:";
            lblOptions.Location = new Point(col1, row);
            lblOptions.Size = new Size(130, 30);
            lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtOptions.Location = new Point(col2, row);
            txtOptions.Size = new Size(w, 30);
            txtOptions.PlaceholderText = "Варіант А,Варіант Б,Варіант В";
            row += step;

            // Correct index row
            lblCorrectIndex.Text = "Правильний (0…):";
            lblCorrectIndex.Location = new Point(col1, row);
            lblCorrectIndex.Size = new Size(130, 30);
            lblCorrectIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtCorrectIndex.Location = new Point(col2, row);
            txtCorrectIndex.Size = new Size(80, 30);
            txtCorrectIndex.PlaceholderText = "0";
            row += step;

            // Counter
            lblCounter.Text = "Питань у тесті: 0";
            lblCounter.Location = new Point(col1, row);
            lblCounter.Size = new Size(300, 30);
            lblCounter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            row += 45;

            // Buttons
            btnAddQuestion.FlatStyle = FlatStyle.Flat;
            btnAddQuestion.FlatAppearance.BorderSize = 0;
            btnAddQuestion.Location = new Point(col1, row);
            btnAddQuestion.Size = new Size(170, 45);
            btnAddQuestion.Text = "+ Додати питання";
            btnAddQuestion.Click += btnAddQuestion_Click;

            btnSaveTest.FlatStyle = FlatStyle.Flat;
            btnSaveTest.FlatAppearance.BorderSize = 0;
            btnSaveTest.Location = new Point(200, row);
            btnSaveTest.Size = new Size(170, 45);
            btnSaveTest.Text = "💾 Зберегти тест";
            btnSaveTest.Click += btnSaveTest_Click;

            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.Location = new Point(390, row);
            btnChangeStyles.Size = new Size(130, 45);
            btnChangeStyles.Text = "Світла тема";
            btnChangeStyles.Click += btnChangeStyles_Click;

            // Form
            ClientSize = new Size(600, row + 80);
            Controls.AddRange(new Control[] {
                lblTestName, txtTestName,
                lblQuestion, txtQuestion,
                lblOptions, txtOptions,
                lblCorrectIndex, txtCorrectIndex,
                lblCounter,
                btnAddQuestion, btnSaveTest, btnChangeStyles
            });
        }

        public CreateForm()
        {
            InitApp();
            InitializeComponent();
            LoadSettings();
            ApplyTheme();
            UpdateQuestionCounter();
        }

        // додаю нове питання до поточного тесту (зберігаю в пам'яті, а не одразу в файл)
        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text) ||
                string.IsNullOrWhiteSpace(txtOptions.Text) ||
                string.IsNullOrWhiteSpace(txtCorrectIndex.Text))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Увага");
                return;
            }

            if (!int.TryParse(txtCorrectIndex.Text.Trim(), out int correctIdx))
            {
                MessageBox.Show("Індекс правильної відповіді має бути числом.", "Помилка");
                return;
            }

            string[] options = txtOptions.Text.Split(',');
            if (correctIdx < 0 || correctIdx >= options.Length)
            {
                MessageBox.Show($"Індекс має бути від 0 до {options.Length - 1}.", "Помилка");
                return;
            }

            pendingQuestions.Add(new QuestionData
            {
                Text = txtQuestion.Text.Trim(),
                Options = options,
                CorrectIndex = correctIdx,
                ImagePath = ""
            });

            txtQuestion.Clear();
            txtOptions.Clear();
            txtCorrectIndex.Clear();
            txtQuestion.Focus();
            UpdateQuestionCounter();

            MessageBox.Show($"Питання #{pendingQuestions.Count} додано.", "Успіх");
        }

        // зберігаю тест у файл
        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            if (pendingQuestions.Count == 0)
            {
                MessageBox.Show("Додайте хоча б одне питання перед збереженням.", "Увага");
                return;
            }

            string testName = txtTestName.Text.Trim();
            if (string.IsNullOrWhiteSpace(testName))
            {
                MessageBox.Show("Будь ласка, введіть назву тесту.", "Увага");
                return;
            }

            // замінюю недопустимі символи в назві файлу на підкреслення
            foreach (char c in Path.GetInvalidFileNameChars())
                testName = testName.Replace(c, '_');

            if (!Directory.Exists(testsFolder))
                Directory.CreateDirectory(testsFolder);

            string filePath = Path.Combine(testsFolder, testName + ".json");

            var testFile = new TestFile
            {
                TestName = testName,
                Questions = pendingQuestions
            };

            try
            {
                File.WriteAllText(filePath,
                    JsonSerializer.Serialize(testFile,
                        new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));

                MessageBox.Show($"Тест «{testName}» збережено ({pendingQuestions.Count} питань).", "Успіх");
                pendingQuestions.Clear();
                txtTestName.Clear();
                UpdateQuestionCounter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження: " + ex.Message, "Помилка");
            }
        }

        // оновлюю лічильник питань на формі
        private void UpdateQuestionCounter()
        {
            lblCounter.Text = $"Питань у тесті: {pendingQuestions.Count}";
        }

        //---зміна теми---
        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
            SaveSettings();
        }

        private void ApplyTheme()
        {
            this.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.WhiteSmoke;
            this.ForeColor = isDarkMode ? Color.White : Color.Black;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.White;
                    txt.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (ctrl is Button btn)
                {
                    btn.BackColor = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                    btn.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (ctrl is Label lbl)
                    lbl.ForeColor = isDarkMode ? Color.White : Color.Black;
            }

            btnSaveTest.BackColor = Color.FromArgb(46, 160, 95);
            btnSaveTest.ForeColor = Color.White;
            btnChangeStyles.Text = isDarkMode ? "Світла тема" : "Темна тема";
        }

        private void LoadSettings()
        {
            try
            {
                if (!File.Exists(configPath)) return;
                using var doc = JsonDocument.Parse(File.ReadAllText(configPath));
                if (doc.RootElement.TryGetProperty("theme", out var t))
                    isDarkMode = t.GetString() == "dark";
            }
            catch { }
        }

        private void SaveSettings()
        {
            try
            {
                File.WriteAllText(configPath,
                    JsonSerializer.Serialize(
                        new { theme = isDarkMode ? "dark" : "light" },
                        new JsonSerializerOptions { WriteIndented = true }));
            }
            catch { }
        }
    }
}