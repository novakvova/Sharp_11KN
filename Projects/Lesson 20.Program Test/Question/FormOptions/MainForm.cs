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
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Тут знаходиться користувач, який є авторизований
            string fileAuthUser = "auth.bin";
            if(File.Exists(fileAuthUser))
            {
                var json = File.ReadAllText(fileAuthUser);
                var user = JsonConvert.DeserializeObject<User>(json);
            }
            else
            {
                LoginForm dlgLogin = new LoginForm();
                //якщо користвач у форму ввів вірно дані по входу
                if(dlgLogin.ShowDialog() == DialogResult.OK)
                {
                    //Читаємо дані про користувача
                    var json = File.ReadAllText(fileAuthUser);
                    var user = JsonConvert.DeserializeObject<User>(json);
                }
                else
                {
                    Application.Exit(); //якщо не не зайшов, ми виходимо з програми
                }
            }
        }
    }
}
