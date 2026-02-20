namespace WindowComunity
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSetInfo_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Тут буде відкривати нова форма!");
            SetUserInfoForm setUserInfoForm = new SetUserInfoForm();
            //Результат від форми SetUserInfoForm буде
            //зберігатися в змінній setUserInfoForm,
            //яка є екземпляром класу SetUserInfoForm.
            //Метод ShowDialog() відображає форму як модальне
            //вікно, і якщо користувач натисне кнопку "Зберегти" (яка, ймовірно, встановлює DialogResult.OK), то виконається код всередині блоку if.
            if (setUserInfoForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Користувач нажав зберегти"); // Тут можна додати код для збереження інформації
            }
            //setUserInfoForm.ShowDialog(); //Фунція для відображення форми
            
        }
    }
}
