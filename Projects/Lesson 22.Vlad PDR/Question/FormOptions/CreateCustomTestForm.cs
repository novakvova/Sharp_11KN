using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using FormOptions;

namespace WinAppPDR
{
    public partial class CreateCustomTestForm : Form
    {
        private List<QuestionData> createdQuestions = new List<QuestionData>();
        private string selectedImagePath = string.Empty;
        private string testsFolder = "custom_tests";

        private string configPath = "appsettings.json";
        private bool isDarkMode = false;
        private Color buttonBorderColor;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public CreateCustomTestForm()
        {
            InitializeComponent();

            txtQuestion.MaxLength = 150;

            btnNextQuestion.Click -= BtnAddQuestion_Click;
            btnDone.Click -= BtnSaveTest_Click;
            btnImage.Click -= BtnUploadImage_Click;

            btnNextQuestion.Click += BtnAddQuestion_Click;
            btnDone.Click += BtnSaveTest_Click;
            btnImage.Click += BtnUploadImage_Click;

            LoadThemeSettings();
            ApplyTheme();
        }

        private DialogResult ShowCustomMessageBox(string text, string title, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            using (Form msgForm = new Form())
            {
                msgForm.Text = title;
                msgForm.Size = new Size(420, 180);
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
                    Width = 355,
                    Height = 50,
                    ForeColor = textCol,
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                msgForm.Controls.Add(lblText);

                if (buttons == MessageBoxButtons.YesNo)
                {
                    Button btnNo = new Button
                    {
                        Text = "Ні",
                        Left = 270,
                        Top = 90,
                        Size = new Size(110, 34),
                        BackColor = btnBg,
                        ForeColor = textCol,
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = DialogResult.No,
                        Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
                    };
                    btnNo.FlatAppearance.BorderSize = 1;
                    btnNo.FlatAppearance.BorderColor = borderCol;
                    btnNo.FlatAppearance.MouseOverBackColor = btnHover;
                    btnNo.FlatAppearance.MouseDownBackColor = btnActive;

                    Button btnYes = new Button
                    {
                        Text = "Так",
                        Left = 150,
                        Top = 90,
                        Size = new Size(110, 34),
                        BackColor = btnBg,
                        ForeColor = textCol,
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = DialogResult.Yes,
                        Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
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
                        Size = new Size(130, 34),
                        BackColor = btnBg,
                        ForeColor = textCol,
                        FlatStyle = FlatStyle.Flat,
                        DialogResult = DialogResult.OK,
                        Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
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

        private void ApplyTheme()
        {
            bool dark = isDarkMode;

            Color graphiteBackground = dark ? Color.FromArgb(28, 30, 33) : Color.FromArgb(245, 246, 248);
            Color textForeColor = dark ? Color.White : Color.FromArgb(30, 30, 30);

            Color textBoxBack = dark ? Color.FromArgb(41, 43, 47) : Color.White;
            Color buttonBack = dark ? Color.FromArgb(41, 43, 47) : Color.White;

            buttonBorderColor = dark ? Color.FromArgb(55, 55, 55) : Color.FromArgb(218, 220, 224);

            Color btnHover = dark ? Color.FromArgb(51, 54, 59) : Color.FromArgb(235, 238, 242);
            Color btnActive = dark ? Color.FromArgb(33, 35, 38) : Color.FromArgb(220, 224, 228);

            this.BackColor = graphiteBackground;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = textBoxBack;
                    txt.ForeColor = textForeColor;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = textForeColor;
                    lbl.BackColor = Color.Transparent;
                }
                else if (ctrl is Button btn)
                {
                    btn.BackColor = buttonBack;
                    btn.ForeColor = textForeColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = buttonBorderColor;
                    btn.FlatAppearance.MouseOverBackColor = btnHover;
                    btn.FlatAppearance.MouseDownBackColor = btnActive;
                }
                else if (ctrl is RadioButton rb)
                {
                    rb.ForeColor = textForeColor;
                    rb.BackColor = Color.Transparent;
                }
                else if (ctrl is Panel || ctrl is GroupBox)
                {
                    ctrl.BackColor = graphiteBackground;
                    ctrl.ForeColor = textForeColor;

                    foreach (Control child in ctrl.Controls)
                    {
                        if (child is RadioButton childRb)
                        {
                            childRb.ForeColor = textForeColor;
                            childRb.BackColor = Color.Transparent;
                        }
                        if (child is Label childLbl)
                        {
                            childLbl.ForeColor = textForeColor;
                            childLbl.BackColor = Color.Transparent;
                        }
                        if (child is TextBox childTxt)
                        {
                            childTxt.BackColor = textBoxBack;
                            childTxt.ForeColor = textForeColor;
                            childTxt.BorderStyle = BorderStyle.FixedSingle;
                        }
                        if (child is Button childBtn)
                        {
                            childBtn.BackColor = buttonBack;
                            childBtn.ForeColor = textForeColor;
                            childBtn.FlatStyle = FlatStyle.Flat;
                            childBtn.FlatAppearance.BorderSize = 1;
                            childBtn.FlatAppearance.BorderColor = buttonBorderColor;
                            childBtn.FlatAppearance.MouseOverBackColor = btnHover;
                            childBtn.FlatAppearance.MouseDownBackColor = btnActive;
                        }
                    }
                }
            }

            int attributeValue = dark ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attributeValue, sizeof(int));

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
            catch
            {
                isDarkMode = false;
            }
        }

        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Зображення (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    txtImage.Text = Path.GetFileName(selectedImagePath);
                }
            }
        }

        private void BtnAddQuestion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                ShowCustomMessageBox("Будь ласка, введіть текст питання.", "Помилка валідації");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAnswer1.Text) || string.IsNullOrWhiteSpace(txtAnswer2.Text) ||
                string.IsNullOrWhiteSpace(txtAnswer3.Text) || string.IsNullOrWhiteSpace(txtAnswer4.Text))
            {
                ShowCustomMessageBox("Заповніть усі 4 варіанти відповідей.", "Помилка валідації");
                return;
            }

            if (!rdBtnAnswer1.Checked && !rdBtnAnswer2.Checked && !rdBtnAnswer3.Checked && !rdBtnAnswer4.Checked)
            {
                ShowCustomMessageBox("Оберіть, яка з відповідей є правильною.", "Помилка валідації");
                return;
            }

            string finalImagePath = string.Empty;
            if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {
                string targetFolder = Path.Combine(Application.StartupPath, "images");
                if (!Directory.Exists(targetFolder)) Directory.CreateDirectory(targetFolder);

                finalImagePath = Path.GetFileName(selectedImagePath);
                string destPath = Path.Combine(targetFolder, finalImagePath);

                try
                {
                    File.Copy(selectedImagePath, destPath, true);
                }
                catch (Exception ex)
                {
                    ShowCustomMessageBox($"Не вдалося зберегти файл зображення: {ex.Message}", "Помилка файлу");
                }
            }

            int correctAnswerIndex = rdBtnAnswer1.Checked ? 0 : rdBtnAnswer2.Checked ? 1 : rdBtnAnswer3.Checked ? 2 : 3;

            QuestionData newQuestion = new QuestionData
            {
                Text = txtQuestion.Text.Trim(),
                Options = new List<string>
                {
                    txtAnswer1.Text.Trim(),
                    txtAnswer2.Text.Trim(),
                    txtAnswer3.Text.Trim(),
                    txtAnswer4.Text.Trim()
                }.ToArray(),
                CorrectIndex = correctAnswerIndex,
                ImagePath = finalImagePath
            };

            createdQuestions.Add(newQuestion);
            ShowCustomMessageBox($"Питання додано! Всього у тесті: {createdQuestions.Count}", "Успіх");

            ClearQuestionFields();
        }

        private void BtnSaveTest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQuestion.Text) && createdQuestions.Count == 0)
            {
                var autoAdd = ShowCustomMessageBox("Ви заповнили поля питання, але не додали його. Додати автоматично?", "Залишились дані", MessageBoxButtons.YesNo);
                if (autoAdd == DialogResult.Yes)
                {
                    BtnAddQuestion_Click(sender, e);
                }
            }

            if (createdQuestions.Count == 0)
            {
                ShowCustomMessageBox("Неможливо створити порожній тест. Додайте хоча б одне питання.", "Помилка");
                return;
            }

            string testName = "Мій тест " + DateTime.Now.ToString("dd.MM.yyyy");
            using (Form inputForm = new Form())
            {
                Label lbl = new Label { Left = 20, Top = 20, Text = "Введіть назву для картки тесту:", Width = 250, Font = new Font("Segoe UI", 9.5F) };
                TextBox txt = new TextBox { Left = 20, Top = 50, Width = 340, Text = testName, MaxLength = 40, Font = new Font("Segoe UI", 10F) };

                Button btnOk = new Button
                {
                    Text = "Створити",
                    Left = 260,
                    Top = 95,
                    Size = new Size(100, 32),
                    DialogResult = DialogResult.OK,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
                };

                inputForm.Text = "Створення тесту";
                inputForm.Size = new Size(400, 185);
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.StartPosition = FormStartPosition.CenterParent;
                inputForm.MaximizeBox = false;

                Color graphiteBg = isDarkMode ? Color.FromArgb(28, 30, 33) : Color.FromArgb(245, 246, 248);
                Color textCol = isDarkMode ? Color.White : Color.FromArgb(30, 30, 30);
                Color textBoxInputBack = isDarkMode ? Color.FromArgb(41, 43, 47) : Color.White;
                Color btnBg = isDarkMode ? Color.FromArgb(41, 43, 47) : Color.White;
                Color borderCol = buttonBorderColor;

                inputForm.BackColor = graphiteBg;
                lbl.ForeColor = textCol;

                txt.BackColor = textBoxInputBack;
                txt.ForeColor = textCol;
                txt.BorderStyle = BorderStyle.FixedSingle;

                btnOk.BackColor = btnBg;
                btnOk.ForeColor = textCol;
                btnOk.FlatStyle = FlatStyle.Flat;
                btnOk.FlatAppearance.BorderSize = 1;
                btnOk.FlatAppearance.BorderColor = borderCol;

                inputForm.Controls.Add(lbl);
                inputForm.Controls.Add(txt);
                inputForm.Controls.Add(btnOk);

                int attrValue = isDarkMode ? 1 : 0;
                DwmSetWindowAttribute(inputForm.Handle, 20, ref attrValue, sizeof(int));

                if (inputForm.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(txt.Text))
                {
                    testName = txt.Text.Trim();
                }
            }

            CustomTestProject project = new CustomTestProject
            {
                TestName = testName,
                Questions = createdQuestions
            };

            try
            {
                if (!Directory.Exists(testsFolder)) Directory.CreateDirectory(testsFolder);

                string safeFileName = string.Join("_", testName.Split(Path.GetInvalidFileNameChars())) + ".json";
                string fullPath = Path.Combine(testsFolder, safeFileName);

                string jsonString = JsonSerializer.Serialize(project, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fullPath, jsonString);

                ShowCustomMessageBox($"Тест '{testName}' успішно збережено в систему!", "Готово");
                this.Close();
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox($"Помилка запису файлу JSON: {ex.Message}", "Критична помилка");
            }
        }

        private void ClearQuestionFields()
        {
            txtQuestion.Clear();
            txtAnswer1.Clear();
            txtAnswer2.Clear();
            txtAnswer3.Clear();
            txtAnswer4.Clear();
            rdBtnAnswer1.Checked = false;
            rdBtnAnswer2.Checked = false;
            rdBtnAnswer3.Checked = false;
            rdBtnAnswer4.Checked = false;
            selectedImagePath = string.Empty;
            txtImage.Text = "";
        }
    }
}