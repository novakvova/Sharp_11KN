using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormOptions
{
    public partial class MainForm : Form
    {
        bool isAuth = false;
        string fileAuthUser = "auth.bin";
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Тут знаходиться користувач, який є авторизований

            if (File.Exists(fileAuthUser))
            {
                var json = File.ReadAllText(fileAuthUser);
                var user = JsonConvert.DeserializeObject<User>(json);
                lbPIB.Text = user.LastName + " " + user.Name;
                isAuth = true;
            }
            else
            {
                ViewLoginForm();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Видаляємо користувача, який зайшов
            File.Delete("auth.bin");
            isAuth = false;
            ViewLoginForm();
        }

        private void ViewLoginForm()
        {
            LoginForm dlgLogin = new LoginForm();
            //якщо користвач у форму ввів вірно дані по входу
            if (dlgLogin.ShowDialog() == DialogResult.OK)
            {
                //Читаємо дані про користувача
                var json = File.ReadAllText(fileAuthUser);
                var user = JsonConvert.DeserializeObject<User>(json);
                lbPIB.Text = user.LastName + " " + user.Name;
                isAuth = true;
            }
            else
            {
                Application.Exit(); //якщо не не зайшов, ми виходимо з програми
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAuth)
            {
                var dlg = MessageBox.Show(
                    "Ви впевнені, що хочете вийти з програми?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dlg == DialogResult.No)
                    e.Cancel = true; //відміняємо вихід
            }

        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            TestForm dlg = new TestForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
            }
        }
    }
}
