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
    public partial class MyTestsForm : Form
    {
        private string testsFolder = "custom_tests";

        private Panel panelTopBar;
        private FlowLayoutPanel flowLayoutPanelTests;
        private Button btnAddHeader;
        private Button btnDeleteAllHeader;
        private Button btnBack;

        private Label lblEmptyMessage;

        private bool isDarkMode = false;
        private string configPath = "appsettings.json";

        private Color defaultFormBack;
        private Color defaultTileBack;
        private Color defaultForeColor;
        private Color buttonBack;
        private Color topBarBack;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public MyTestsForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            LoadSettings();
            InitializeSeparatedPanels();
            ApplyTheme();
            LoadAllCustomTests();
        }

        private void InitializeSeparatedPanels()
        {
            panelTopBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(15, 10, 15, 10)
            };
            this.Controls.Add(panelTopBar);

            btnBack = new Button
            {
                Text = "◀️",
                Font = new Font("Arial", 11, FontStyle.Bold),
                Size = new Size(45, 40),
                Dock = DockStyle.Left,
                FlatStyle = FlatStyle.Flat
            };
            btnBack.FlatAppearance.BorderSize = 1;
            btnBack.Click += (s, e) => this.Close();
            panelTopBar.Controls.Add(btnBack);

            btnAddHeader = new Button
            {
                Text = "➕ Створити новий тест",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(220, 40),
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat
            };
            btnAddHeader.FlatAppearance.BorderSize = 1;
            btnAddHeader.Click += btnAddTest_Click;
            panelTopBar.Controls.Add(btnAddHeader);

            btnDeleteAllHeader = new Button
            {
                Text = "🗑️ Очистити все",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(160, 40),
                Dock = DockStyle.Right,
                Margin = new Padding(0, 0, 10, 0),
                FlatStyle = FlatStyle.Flat,
                Visible = false
            };
            btnDeleteAllHeader.FlatAppearance.BorderSize = 1;
            btnDeleteAllHeader.Click += btnDeleteAllHeader_Click;
            panelTopBar.Controls.Add(btnDeleteAllHeader);

            flowLayoutPanelTests = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(60)
            };
            this.Controls.Add(flowLayoutPanelTests);

            lblEmptyMessage = new Label
            {
                Text = "Кастомних тестів поки немає.\nНатисніть кнопку вище, щоб створити його.",
                Font = new Font("Arial", 14, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(500, 80),
                Visible = false
            };
            this.Controls.Add(lblEmptyMessage);

            panelTopBar.BringToFront();
        }

        private void LoadAllCustomTests()
        {
            flowLayoutPanelTests.Controls.Clear();

            if (!Directory.Exists(testsFolder) || Directory.GetFiles(testsFolder, "*.json").Length == 0)
            {
                ShowEmptyMessage(true);
                btnDeleteAllHeader.Visible = false;
                return;
            }

            string[] files = Directory.GetFiles(testsFolder, "*.json");
            foreach (var file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    var project = JsonSerializer.Deserialize<CustomTestProject>(json);
                    if (project != null)
                    {
                        CreateTestTile(project, Path.GetFileName(file));
                    }
                }
                catch { }
            }

            if (flowLayoutPanelTests.Controls.Count > 0)
            {
                ShowEmptyMessage(false);
                btnDeleteAllHeader.Visible = true;
            }
            else
            {
                ShowEmptyMessage(true);
                btnDeleteAllHeader.Visible = false;
            }
        }

        private void ShowEmptyMessage(bool show)
        {
            if (show)
            {
                lblEmptyMessage.Visible = true;
                flowLayoutPanelTests.Visible = false;
                lblEmptyMessage.Location = new Point(
                    (this.ClientSize.Width - lblEmptyMessage.Width) / 2,
                    (this.ClientSize.Height - lblEmptyMessage.Height + panelTopBar.Height) / 2
                );
                lblEmptyMessage.BringToFront();
            }
            else
            {
                lblEmptyMessage.Visible = false;
                flowLayoutPanelTests.Visible = true;
            }
        }

        private void CreateTestTile(CustomTestProject project, string fileName)
        {
            Panel tile = new Panel
            {
                Size = new Size(200, 180),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = defaultTileBack,
                Margin = new Padding(10)
            };

            Label lblTitle = new Label
            {
                Text = project.TestName,
                Font = new Font("Arial", 11, FontStyle.Regular),
                ForeColor = defaultForeColor,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 138,
                AutoSize = false,
                AutoEllipsis = true
            };
            tile.Controls.Add(lblTitle);

            Panel btnPanel = new Panel { Dock = DockStyle.Bottom, Height = 40 };
            tile.Controls.Add(btnPanel);

            Button btnTake = new Button
            {
                Text = "Пройти тест",
                Width = 110,
                Dock = DockStyle.Left,
                BackColor = isDarkMode ? Color.FromArgb(70, 75, 80) : Color.LightGray,
                ForeColor = defaultForeColor,
                FlatStyle = FlatStyle.Flat
            };
            btnTake.FlatAppearance.BorderSize = 0;
            btnTake.Click += (s, e) => {
                CustomQuestionForm testForm = new CustomQuestionForm(project.Questions, project.TestName);
                testForm.ShowDialog();
            };

            Button btnEdit = new Button
            {
                Text = "✏",
                Width = 40,
                Dock = DockStyle.Left,
                BackColor = isDarkMode ? Color.FromArgb(180, 140, 20) : Color.Gold,
                ForeColor = isDarkMode ? Color.White : Color.Black,
                FlatStyle = FlatStyle.Flat
            };
            btnEdit.FlatAppearance.BorderSize = 0;

            Button btnDelete = new Button
            {
                Text = "❌",
                Width = 48,
                Dock = DockStyle.Fill,
                BackColor = isDarkMode ? Color.FromArgb(170, 50, 50) : Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += (s, e) => {
                if (CustomMessageBox.Show($"Видалити тест '{project.TestName}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(Path.Combine(testsFolder, fileName));
                    LoadAllCustomTests();
                }
            };

            btnPanel.Controls.Add(btnDelete);
            btnPanel.Controls.Add(btnEdit);
            btnPanel.Controls.Add(btnTake);

            flowLayoutPanelTests.Controls.Add(tile);
        }

        private void btnDeleteAllHeader_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show(
                "Видалити",
                "Видалити ВСІ кастомні тести?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (Directory.Exists(testsFolder))
                    {
                        string[] files = Directory.GetFiles(testsFolder, "*.json");
                        foreach (var file in files) File.Delete(file);
                    }
                    LoadAllCustomTests();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"Помилка під час видалення файлів: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                defaultFormBack = Color.FromArgb(33, 35, 38);
                topBarBack = Color.FromArgb(25, 26, 28);
                defaultTileBack = Color.FromArgb(43, 45, 49);
                defaultForeColor = Color.White;
                buttonBack = Color.FromArgb(50, 52, 55);
            }
            else
            {
                defaultFormBack = Color.FromArgb(237, 239, 241);
                topBarBack = Color.FromArgb(220, 223, 226);
                defaultTileBack = Color.White;
                defaultForeColor = Color.Black;
                buttonBack = Color.White;
            }

            this.BackColor = defaultFormBack;

            if (panelTopBar != null) panelTopBar.BackColor = topBarBack;
            if (flowLayoutPanelTests != null) flowLayoutPanelTests.BackColor = defaultFormBack;

            if (lblEmptyMessage != null)
            {
                lblEmptyMessage.BackColor = Color.Transparent;
                lblEmptyMessage.ForeColor = isDarkMode ? Color.Gray : Color.DimGray;
            }

            if (panelTopBar != null)
            {
                foreach (Control ctrl in panelTopBar.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.BackColor = buttonBack;
                        btn.ForeColor = defaultForeColor;
                        btn.FlatAppearance.BorderColor = isDarkMode ? Color.FromArgb(70, 70, 70) : Color.DarkGray;

                        if (btn == btnDeleteAllHeader)
                        {
                            btn.ForeColor = isDarkMode ? Color.FromArgb(230, 90, 90) : Color.DarkRed;
                        }
                    }
                }
            }

            int attributeValue = isDarkMode ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref attributeValue, sizeof(int));
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
                        isDarkMode = doc.RootElement.GetProperty("theme").GetString() == "dark";
                    }
                }
            }
            catch { isDarkMode = false; }
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            CreateCustomTestForm createForm = new CreateCustomTestForm();
            createForm.ShowDialog();
            LoadAllCustomTests();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (lblEmptyMessage != null && lblEmptyMessage.Visible)
            {
                lblEmptyMessage.Location = new Point(
                    (this.ClientSize.Width - lblEmptyMessage.Width) / 2,
                    (this.ClientSize.Height - lblEmptyMessage.Height + panelTopBar.Height) / 2
                );
            }
        }
    }
}