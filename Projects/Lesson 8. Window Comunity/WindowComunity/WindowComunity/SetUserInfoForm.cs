using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowComunity
{
    public partial class SetUserInfoForm : Form
    {
        public SetUserInfoForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(); // Закриваємо поточну форму
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Форма буде закриватися і повідомляти
            // що вона закрилася у статусі OK
            DialogResult = DialogResult.OK;
            //MessageBox.Show("Інформація збережена!"); // Тут можна додати код для збереження інформації
        }
    }
}
