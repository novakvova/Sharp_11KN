using FormOptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using WinAppPDR;

namespace FormOptions
{
    public partial class MainForm : Form
    {
        private bool isAuth = false;
        private string fileAuthUser = "auth.bin";
        private string configPath = "appsettings.json";
        private bool isDarkMode = false;

        private Panel sidebarPanel;
        private Panel mainContentPanel;
        private Label lblAppTitle;
        private Label lblUserGreeting;
        private Label lblStatus;
        private Button btnStartDefaultTest;
        private Button btnMyCustomTests;
        private Button btnThemeToggle;
        private Button btnExit;
        private PictureBox pbUserAvatar;
        private Panel userCard;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public MainForm()
        {
            InitializeComponent();

            this.Size = new Size(1000, 650);
            this.MinimumSize = new Size(850, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Головне меню";

            LoadThemeSettings();
            BuildDynamicUI();
            ApplyTheme();

            this.SizeChanged += MainForm_SizeChanged;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(fileAuthUser))
            {
                UpdateUserAuthentication();
            }
            else
            {
                ViewLoginForm();
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            CenterUserCard();
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

                Color bg = isDarkMode ? Color.FromArgb(33, 35, 38) : Color.FromArgb(237, 239, 241);
                Color textCol = isDarkMode ? Color.White : Color.Black;
                Color btnBg = isDarkMode ? Color.FromArgb(50, 52, 55) : Color.FromArgb(220, 224, 230);
                Color borderCol = isDarkMode ? Color.FromArgb(80, 83, 88) : Color.DarkGray;

                msgForm.BackColor = bg;

                Label lblText = new Label
                {
                    Text = text,
                    Left = 25,
                    Top = 25,
                    Width = 355,
                    Height = 50,
                    ForeColor = textCol,
                    Font = new Font("Segoe UI", 11F, FontStyle.Regular),
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
                        Font = new Font("Segoe UI", 10F)
                    };
                    btnNo.FlatAppearance.BorderColor = borderCol;

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
                        Font = new Font("Segoe UI", 10F)
                    };
                    btnYes.FlatAppearance.BorderColor = borderCol;

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
                        Font = new Font("Segoe UI", 10F)
                    };
                    btnOk.FlatAppearance.BorderColor = borderCol;

                    msgForm.Controls.Add(btnOk);
                    msgForm.AcceptButton = btnOk;
                }

                int attrValue = isDarkMode ? 1 : 0;
                DwmSetWindowAttribute(msgForm.Handle, 20, ref attrValue, sizeof(int));

                return msgForm.ShowDialog();
            }
        }

        private void BuildDynamicUI()
        {
            while (this.Controls.Count > 0)
            {
                Control c = this.Controls[0];
                this.Controls.Remove(c);
                c.Dispose();
            }

            sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
                Padding = new Padding(15)
            };
            this.Controls.Add(sidebarPanel);

            lblAppTitle = new Label
            {
                Text = "🚗 ПДР ТЕСТ",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleLeft
            };
            sidebarPanel.Controls.Add(lblAppTitle);

            Panel linePanel = new Panel { Dock = DockStyle.Top, Height = 2, BackColor = Color.Gray, Margin = new Padding(0, 10, 0, 20) };
            sidebarPanel.Controls.Add(linePanel);

            btnStartDefaultTest = CreateSidebarButton("📝 Почати тест", 100);
            btnStartDefaultTest.Click += (s, e) => ShowCustomMessageBox("Тут запускається стандартний тест ПДР", "Інформація");
            sidebarPanel.Controls.Add(btnStartDefaultTest);

            btnMyCustomTests = CreateSidebarButton("🗂️ Мої тести", 150);
            btnMyCustomTests.Click += btnMyCustomTests_Click;
            sidebarPanel.Controls.Add(btnMyCustomTests);

            btnThemeToggle = CreateSidebarButton("🌓 Змінити тему", 200);
            btnThemeToggle.Click += btnThemeToggle_Click;
            sidebarPanel.Controls.Add(btnThemeToggle);

            btnExit = new Button
            {
                Text = "Вийти з акаунту",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 45,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            btnExit.FlatAppearance.BorderSize = 1;
            btnExit.Click += btnExit_Click;

            btnExit.MouseEnter += (s, e) => {
                btnExit.BackColor = isDarkMode ? Color.FromArgb(55, 35, 38) : Color.FromArgb(255, 230, 230);
            };
            btnExit.MouseLeave += (s, e) => {
                btnExit.BackColor = isDarkMode ? Color.FromArgb(28, 30, 33) : Color.FromArgb(240, 242, 245);
            };
            sidebarPanel.Controls.Add(btnExit);

            mainContentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(40)
            };
            this.Controls.Add(mainContentPanel);

            userCard = new Panel
            {
                Size = new Size(450, 160),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(20)
            };
            mainContentPanel.Controls.Add(userCard);

            pbUserAvatar = new PictureBox
            {
                Size = new Size(90, 90),
                Location = new Point(25, 35),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.DimGray
            };

            using (System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                gp.AddEllipse(0, 0, 90, 90);
                if (pbUserAvatar.Region != null) pbUserAvatar.Region.Dispose();
                pbUserAvatar.Region = new Region(gp);
            }
            userCard.Controls.Add(pbUserAvatar);

            lblUserGreeting = new Label
            {
                Text = "Вітаємо, Користувач!",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(135, 40),
                Size = new Size(290, 35),
                TextAlign = ContentAlignment.MiddleLeft
            };
            userCard.Controls.Add(lblUserGreeting);

            lblStatus = new Label
            {
                Text = "Статус: Готовий до тестування",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(135, 80),
                Size = new Size(290, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };
            userCard.Controls.Add(lblStatus);

            CenterUserCard();
        }

        private Button CreateSidebarButton(string text, int topLocation)
        {
            Button btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Size = new Size(230, 45),
                Location = new Point(15, topLocation),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            btn.MouseEnter += (s, e) => {
                btn.BackColor = isDarkMode ? Color.FromArgb(45, 47, 50) : Color.FromArgb(210, 215, 220);
            };

            btn.MouseLeave += (s, e) => {
                btn.BackColor = isDarkMode ? Color.FromArgb(28, 30, 33) : Color.FromArgb(240, 242, 245);
            };

            return btn;
        }

        private void CenterUserCard()
        {
            if (userCard != null && mainContentPanel != null && !userCard.IsDisposed && !mainContentPanel.IsDisposed)
            {
                userCard.Location = new Point(
                    (mainContentPanel.Width - userCard.Width) / 2,
                    (mainContentPanel.Height - userCard.Height) / 2
                );
            }
        }

        private void ApplyTheme()
        {
            Color baseBackground = isDarkMode ? Color.FromArgb(33, 35, 38) : Color.FromArgb(237, 239, 241);
            Color sidebarBack = isDarkMode ? Color.FromArgb(28, 30, 33) : Color.FromArgb(240, 242, 245);
            Color cardBack = isDarkMode ? Color.FromArgb(43, 45, 49) : Color.White;
            Color textForeColor = isDarkMode ? Color.White : Color.Black;
            Color borderColor = isDarkMode ? Color.FromArgb(65, 67, 71) : Color.LightGray;

            this.BackColor = baseBackground;
            mainContentPanel.BackColor = baseBackground;
            sidebarPanel.BackColor = sidebarBack;
            userCard.BackColor = cardBack;

            lblAppTitle.ForeColor = textForeColor;
            lblUserGreeting.ForeColor = textForeColor;

            btnStartDefaultTest.BackColor = sidebarBack;
            btnStartDefaultTest.ForeColor = textForeColor;
            btnMyCustomTests.BackColor = sidebarBack;
            btnMyCustomTests.ForeColor = textForeColor;
            btnThemeToggle.BackColor = sidebarBack;
            btnThemeToggle.ForeColor = textForeColor;

            btnExit.BackColor = sidebarBack;
            btnExit.ForeColor = isDarkMode ? Color.FromArgb(240, 100, 100) : Color.DarkRed;
            btnExit.FlatAppearance.BorderColor = borderColor;

            lblStatus.ForeColor = isDarkMode ? Color.FromArgb(100, 220, 100) : Color.DarkGreen;

            int attributeValue = isDarkMode ? 1 : 0;
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
            catch { isDarkMode = false; }
        }

        private void btnThemeToggle_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            try
            {
                var data = new { theme = isDarkMode ? "dark" : "light" };
                File.WriteAllText(configPath, JsonSerializer.Serialize(data));
            }
            catch { }
            ApplyTheme();
        }

        private void UpdateUserAuthentication()
        {
            try
            {
                if (!File.Exists(fileAuthUser)) return;

                var json = File.ReadAllText(fileAuthUser);
                var user = JsonSerializer.Deserialize<User>(json);
                if (user != null)
                {
                    lblUserGreeting.Text = $"{user.Name}";
                    isAuth = true;

                    if (!string.IsNullOrEmpty(user.AvatarPath) && File.Exists(user.AvatarPath))
                    {
                        if (pbUserAvatar.Image != null)
                        {
                            pbUserAvatar.Image.Dispose();
                            pbUserAvatar.Image = null;
                        }

                        using (var stream = File.OpenRead(user.AvatarPath))
                        {
                            pbUserAvatar.Image = Image.FromStream(stream);
                        }
                    }
                    else
                    {
                        pbUserAvatar.BackColor = Color.FromArgb(0, 120, 215);
                    }
                }
            }
            catch
            {
                lblUserGreeting.Text = "Авторизовано";
            }
        }

        private void ViewLoginForm()
        {
            using (LoginForm dlgLogin = new LoginForm())
            {
                if (dlgLogin.ShowDialog() == DialogResult.OK)
                {
                    UpdateUserAuthentication();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ShowCustomMessageBox("Ви впевнені, що хочете вийти з профілю?", "Вихід з акаунту", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (pbUserAvatar.Image != null)
                    {
                        pbUserAvatar.Image.Dispose();
                        pbUserAvatar.Image = null;
                    }

                    if (File.Exists(fileAuthUser)) File.Delete(fileAuthUser);
                }
                catch { }

                isAuth = false;
                this.Hide();
                ViewLoginForm();

                if (isAuth)
                {
                    this.Show();
                }
            }
        }

        private void btnMyCustomTests_Click(object sender, EventArgs e)
        {
            using (MyTestsForm dlgCustomTest = new MyTestsForm())
            {
                this.Hide();
                dlgCustomTest.ShowDialog();

                LoadThemeSettings();
                ApplyTheme();
                this.Show();
            }
        }
    }
}