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
            string lastName = txtLastname.Text.Trim();
            string firstName = txtFirstname.Text.Trim();
            string secondName = txtSecondname.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (lastName.Length == 0) // Якщо довжина масиву 0
            {
                lbInvalidLastname.Visible = true; // Показуємо повідомлення про помилку
                isValid = false; // Встановлюємо флаг невалідності
            }

            if(isValid) // Якщо дані валідні - тобто усе сказано вірно
            {
                string fileStorage = "contacts.txt"; // Ім'я файлу для збереження контактів
                //MessageBox.Show($"{lastName} {firstName} {secondName} - {phone}");
                if(!File.Exists(fileStorage)) // Якщо файл не існує
                {
                    File.Create(fileStorage).Close(); // Створюємо файл і закриваємо його
                }
                //додамоє дані у файл
                //File.WriteAllText(fileStorage, 
                //    $"{lastName} {firstName} {secondName} {phone}{Environment.NewLine}", 
                //    Encoding.UTF8); // Записуємо дані у файл з кодуванням UTF-8

                File.AppendAllText(fileStorage,
                    $"{lastName} {firstName} {secondName} {phone}{Environment.NewLine}",
                    Encoding.UTF8); // Записуємо дані у файл з кодуванням UTF-8

                //Форма буде закриватися і поверти результат OK
                DialogResult = DialogResult.OK; // Встановлюємо результат діалогу як OK
            }

        }
    }
}
