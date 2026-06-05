using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using FormOptions;

namespace WinAppPDR
{
    public partial class CustomQuestionForm : Form
    {
        private List<QuestionData> questions;
        private string testName;
        private int currentQuestionIndex = 0;
        private int[] userAnswers;
        private int correctAnswersCount = 0;
        private string imagesFolder = "images";

        private string configPath = "appsettings.json";
        private bool isDarkMode = false;
        private Color buttonBorderColor;

        private FlowLayoutPanel flowPanelQuestionNumbers;
        private Label lblQuestionText;
        private RadioButton[] radioButtonsAnswers;
        private PictureBox pbQuestionImage;
        private Button btnNextQuestion;
        private Button btnFinishTest;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public CustomQuestionForm(List<QuestionData> customQuestions, string name)
        {
            InitializeComponent();

            this.questions = customQuestions ?? new List<QuestionData>();
            if (this.questions.Count > 30)
            {
                this.questions = this.questions.GetRange(0, 30);
            }

            this.testName = name;
            this.Text = $"Тестування: {this.testName}";
            this.DoubleBuffered = true;
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadThemeSettings();
            InitializeSafeControls();
            InitializeImageControl();
            InitializeNavigationButtons();
            GenerateQuestionNavigationButtons();
            ApplyTheme();

            ShowQuestion(currentQuestionIndex);
        }

        private void ApplyTheme()
        {
            bool dark = isDarkMode;

            Color bgForm = dark ? Color.FromArgb(28, 30, 33) : Color.FromArgb(245, 246, 248);
            Color panelBack = dark ? Color.FromArgb(33, 35, 38) : Color.White;
            Color textCol = dark ? Color.White : Color.FromArgb(30, 30, 30);
            buttonBorderColor = dark ? Color.FromArgb(55, 55, 55) : Color.FromArgb(218, 220, 224);

            this.BackColor = bgForm;

            if (flowPanelQuestionNumbers != null)
            {
                flowPanelQuestionNumbers.BackColor = panelBack;
            }

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = textCol;
                    lbl.BackColor = Color.Transparent;
                }
                else if (ctrl is RadioButton rb)
                {
                    rb.ForeColor = textCol;
                    rb.BackColor = Color.Transparent;
                }
                else if (ctrl is Button btn && btn.Parent != flowPanelQuestionNumbers)
                {
                    btn.ForeColor = textCol;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = buttonBorderColor;

                    if (btn == btnFinishTest)
                    {
                        btn.BackColor = dark ? Color.FromArgb(120, 35, 35) : Color.FromArgb(240, 210, 210);
                        btn.ForeColor = dark ? Color.White : Color.DarkRed;
                    }
                    else
                    {
                        btn.BackColor = dark ? Color.FromArgb(46, 48, 53) : Color.FromArgb(220, 224, 230);
                    }
                }
            }

            UpdateNavigationHighlight(currentQuestionIndex);

            int attrValue = dark ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attrValue, sizeof(int));
            this.Refresh();
        }

        private void LoadThemeSettings()
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

        private void InitializeSafeControls()
        {
            if (flowPanelQuestionNumbers == null)
            {
                flowPanelQuestionNumbers = new FlowLayoutPanel
                {
                    Dock = DockStyle.Top,
                    Height = 50,
                    Padding = new Padding(10),
                    WrapContents = false,
                    AutoScroll = true
                };
                this.Controls.Add(flowPanelQuestionNumbers);
            }

            if (lblQuestionText == null)
            {
                lblQuestionText = new Label
                {
                    Location = new Point(30, 70),
                    Size = new Size(550, 60),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                this.Controls.Add(lblQuestionText);
            }

            if (radioButtonsAnswers == null || radioButtonsAnswers.Length == 0)
            {
                radioButtonsAnswers = new RadioButton[4];
                for (int i = 0; i < 4; i++)
                {
                    radioButtonsAnswers[i] = new RadioButton
                    {
                        Location = new Point(35, 150 + (i * 45)),
                        Size = new Size(500, 35),
                        Font = new Font("Segoe UI", 10F),
                        Cursor = Cursors.Hand
                    };
                    this.Controls.Add(radioButtonsAnswers[i]);
                }
            }
        }

        private void InitializeImageControl()
        {
            if (pbQuestionImage == null)
            {
                pbQuestionImage = new PictureBox
                {
                    Size = new Size(350, 250),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Visible = false
                };
                this.Controls.Add(pbQuestionImage);
            }
            pbQuestionImage.Location = new Point(this.ClientSize.Width - pbQuestionImage.Width - 30, 150);
            pbQuestionImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void InitializeNavigationButtons()
        {
            if (btnNextQuestion == null)
            {
                btnNextQuestion = new Button
                {
                    Text = "Наступне питання",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Size = new Size(200, 42),
                    Location = new Point(35, 360),
                    Cursor = Cursors.Hand
                };
                btnNextQuestion.Click += BtnNextQuestion_Click;
                this.Controls.Add(btnNextQuestion);
            }

            if (btnFinishTest == null)
            {
                btnFinishTest = new Button
                {
                    Text = "Завершити тест",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Size = new Size(180, 42),
                    Location = new Point(250, 360),
                    Cursor = Cursors.Hand
                };
                btnFinishTest.Click += BtnFinishTest_Click;
                this.Controls.Add(btnFinishTest);
            }
        }

        private void GenerateQuestionNavigationButtons()
        {
            flowPanelQuestionNumbers.Controls.Clear();
            userAnswers = new int[questions.Count];
            for (int i = 0; i < questions.Count; i++) userAnswers[i] = -1;

            bool dark = isDarkMode;
            Color btnBg = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            Color btnFore = dark ? Color.White : Color.FromArgb(30, 30, 30);
            Color borderC = dark ? Color.FromArgb(55, 55, 55) : Color.FromArgb(218, 220, 224);

            for (int i = 0; i < questions.Count; i++)
            {
                Button btnNum = new Button
                {
                    Text = (i + 1).ToString(),
                    Size = new Size(40, 32),
                    Margin = new Padding(4, 0, 4, 0),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = btnBg,
                    ForeColor = btnFore,
                    Tag = i,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };

                btnNum.FlatAppearance.BorderSize = 1;
                btnNum.FlatAppearance.BorderColor = borderC;

                int index = i;
                btnNum.Click += (s, e) => {
                    SaveCurrentAnswer();
                    currentQuestionIndex = index;
                    ShowQuestion(currentQuestionIndex);
                };
                flowPanelQuestionNumbers.Controls.Add(btnNum);
            }
        }

        private void ShowQuestion(int index)
        {
            if (index < 0 || index >= questions.Count) return;

            var currentQuestion = questions[index];
            lblQuestionText.Text = $"Питання №{index + 1}: {currentQuestion.Text}";

            int savedAnswer = userAnswers[index];
            for (int i = 0; i < radioButtonsAnswers.Length; i++)
            {
                if (currentQuestion.Options != null && i < currentQuestion.Options.Length)
                {
                    radioButtonsAnswers[i].Text = currentQuestion.Options[i];
                    radioButtonsAnswers[i].Visible = true;
                    radioButtonsAnswers[i].Checked = (i == savedAnswer);
                }
                else
                {
                    radioButtonsAnswers[i].Visible = false;
                }
            }

            if (pbQuestionImage.Image != null)
            {
                pbQuestionImage.Image.Dispose();
                pbQuestionImage.Image = null;
            }

            if (!string.IsNullOrWhiteSpace(currentQuestion.ImagePath))
            {
                string fullPath = Path.Combine(imagesFolder, currentQuestion.ImagePath);
                if (File.Exists(fullPath))
                {
                    pbQuestionImage.Image = Image.FromFile(fullPath);
                    pbQuestionImage.Visible = true;
                }
                else
                {
                    pbQuestionImage.Visible = false;
                }
            }
            else
            {
                pbQuestionImage.Visible = false;
            }

            if (btnNextQuestion != null)
            {
                btnNextQuestion.Enabled = (index < questions.Count - 1);
            }

            UpdateNavigationHighlight(index);
        }

        private void UpdateNavigationHighlight(int activeIndex)
        {
            bool dark = isDarkMode;
            Color defaultBtnBack = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            Color activeBtnBack = Color.FromArgb(0, 120, 215);
            Color textCol = dark ? Color.White : Color.FromArgb(30, 30, 30);

            foreach (Control ctrl in flowPanelQuestionNumbers.Controls)
            {
                if (ctrl is Button btn && btn.Tag is int btnIndex)
                {
                    if (btnIndex == activeIndex)
                    {
                        btn.BackColor = activeBtnBack;
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = defaultBtnBack;

                        if (userAnswers[btnIndex] != -1)
                        {
                            btn.ForeColor = dark ? Color.FromArgb(100, 220, 100) : Color.FromArgb(40, 150, 40);
                        }
                        else
                        {
                            btn.ForeColor = textCol;
                        }
                    }
                }
            }
        }

        private void SaveCurrentAnswer()
        {
            for (int i = 0; i < radioButtonsAnswers.Length; i++)
            {
                if (radioButtonsAnswers[i].Checked)
                {
                    userAnswers[currentQuestionIndex] = i;
                    if (flowPanelQuestionNumbers.Controls[currentQuestionIndex] is Button btn)
                    {
                        btn.ForeColor = isDarkMode ? Color.FromArgb(100, 220, 100) : Color.FromArgb(40, 150, 40);
                    }
                    break;
                }
            }
        }

        private void BtnNextQuestion_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                ShowQuestion(currentQuestionIndex);
            }
        }

        private void BtnFinishTest_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();

            correctAnswersCount = 0;
            int unanswered = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (userAnswers[i] == -1) unanswered++;
                else if (userAnswers[i] == questions[i].CorrectIndex) correctAnswersCount++;
            }

            if (unanswered > 0)
            {
                var dr = CustomMessageBox.Show("Тест не закінчено", $"Ви залишили {unanswered} питань без відповіді. Все одно завершити?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
            }

            CustomMessageBox.Show("Результат", $"Тест завершено!\nРезультат: {correctAnswersCount} з {questions.Count}");
            this.Close();
        }
    }
}