using Newtonsoft.Json;
using System.Text;


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
            bool isValid = true; // Змінна для перевірки валідності даних
            //обрізає пусті символи з початку та кінця рядка

            MyAbonent a = new ();

            a.LastName = txtLastname.Text.Trim();
            a.FirstName = txtFirstname.Text.Trim();
            a.SecondName = txtSecondname.Text.Trim();
            a.Phone = txtPhone.Text.Trim();

            if (a.LastName.Length == 0) // Якщо довжина масиву 0
            {
                lbInvalidLastname.Visible = true; // Показуємо повідомлення про помилку
                isValid = false; // Встановлюємо флаг невалідності
            }

            if(isValid) // Якщо дані валідні - тобто усе сказано вірно
            {
                string fileStorage = "jsonContacts.txt"; // Ім'я файлу для збереження контактів
                //MessageBox.Show($"{lastName} {firstName} {secondName} - {phone}");
                if(!File.Exists(fileStorage)) // Якщо файл не існує
                {
                    File.Create(fileStorage).Close(); // Створюємо файл і закриваємо його
                }
                //додамоє дані у файл
                //File.WriteAllText(fileStorage, 
                //    $"{lastName} {firstName} {secondName} {phone}{Environment.NewLine}", 
                //    Encoding.UTF8); // Записуємо дані у файл з кодуванням UTF-8

                //File.AppendAllText(fileStorage,
                //    $"{lastName} {firstName} {secondName} {phone}{Environment.NewLine}",
                //    Encoding.UTF8); // Записуємо дані у файл з кодуванням UTF-8

                string json = JsonConvert.SerializeObject(a);
                File.AppendAllText(fileStorage, json+"\n", Encoding.UTF8);

                //Форма буде закриватися і поверти результат OK
                DialogResult = DialogResult.OK; // Встановлюємо результат діалогу як OK
            }

        }
    }
}
