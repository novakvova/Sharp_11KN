namespace AbonentsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCreateAbontent_Click(object sender, EventArgs e)
        {
            AbonentCreateForm dlg = new AbonentCreateForm();
            //Перевіряємо стан із яким закрився діалог
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Абонент створений успішно!"); // Виводимо повідомлення про успішне створення абонента
            }
            //MessageBox.Show("Створення абонента");
        }
    }
}
