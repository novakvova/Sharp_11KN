using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbonentsApp
{
    public partial class AbonentCreateForm : Form
    {
        public AbonentCreateForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(); // Закриваємо форму без збереження даних
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //обрізає пусті символи з початку та кінця рядка
            string lastName = txtLastname.Text.Trim();

            if (lastName.Length == 0) // Якщо довжина масиву 0
            {
                lbInvalidLastname.Visible = true; // Показуємо повідомлення про помилку
            }

        }
    }
}
