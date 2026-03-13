using Newtonsoft.Json;

namespace AbonentsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadListAbotnents();
        }

        private void LoadListAbotnents()
        {
            dgvAbontnts.Rows.Clear();
            var lines = File.ReadAllLines("jsonContacts.txt");
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                string json = line.Trim();
                MyAbonent? abontent = JsonConvert.DeserializeObject<MyAbonent>(json);
                if (abontent!=null)
                {
                    object[] row = {
                        $"{abontent.LastName} {abontent.FirstName} {abontent.SecondName}",
                        abontent.Phone
                    };
                    dgvAbontnts.Rows.Add(row);
                }

            }
        }


        private void btnCreateAbontent_Click(object sender, EventArgs e)
        {
            AbonentCreateForm dlg = new AbonentCreateForm();
            //Перевіряємо стан із яким закрився діалог
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadListAbotnents();
                //MessageBox.Show("Абонент створений успішно!"); // Виводимо повідомлення про успішне створення абонента
            }
            //MessageBox.Show("Створення абонента");
        }
    }
}
