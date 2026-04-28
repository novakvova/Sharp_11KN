using System.Security.Cryptography.X509Certificates;

namespace Paska
{
    public partial class MainForm : Form
    {
        List<MyPasxa> myPasxa = new List<MyPasxa>();
        public MainForm()
        {
            InitializeComponent();
            lvPasxy.LargeImageList = new ImageList();
            lvPasxy.LargeImageList.ImageSize = new Size(150, 115);
            lvPasxy.MultiSelect = false;
            //lvExplorer.ListViewItemSorter = new ListViewIndexComparer();
            lvPasxy.InsertionMark.Color = Color.Green;
            lvPasxy.AllowDrop = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            myPasxa.Add(new MyPasxa {
                key = Guid.NewGuid().ToString(),
                name = "Малятко",
                weight = 80,
                producer = "Скиба",
                image = "images\\4VhEUAeRlxgiwe2lvZz-2e2TYWBZmm9U.png"
            });
            myPasxa.Add(new MyPasxa
            {
                key = Guid.NewGuid().ToString(),
                name = "Бурштинова",
                weight = 350,
                producer = "Скиба",
                image = "images\\2.png"
            });
            myPasxa.Add(new MyPasxa
            {
                key = Guid.NewGuid().ToString(),
                name = "Три шоколади",
                weight = 300,
                producer = "Скиба",
                image = "images\\choc.png"
            });
            myPasxa.Add(new MyPasxa
            {
                key = Guid.NewGuid().ToString(),
                name = "Три шоколади",
                weight = 35,
                producer = "Вацак",
                image = "images\\Tri_chocolada-562x429.jpg"
            });
            foreach (var p in myPasxa)
            {
                //Це ключ - GUID - унікальний ідентифікатор, який не може повторитися.
                // У кожного елемнета є свій унікальний ключ
                ListViewItem item = new ListViewItem();
                item.Tag = p.key;
                item.Text = p.name; // Це назва пасхи
                item.ImageKey = p.key;
                lvPasxy.LargeImageList.Images.Add(p.key, Image.FromFile(p.image));
                lvPasxy.Items.Add(item);
            }
            
        }
        private void lvPasxy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvPasxy.SelectedItems.Count > 0) //Спрацювала поадія 2 кліка. Перевірємо кількість обраних елементів
            {
                //Обаний елемент
                ListViewItem item = lvPasxy.SelectedItems[0];
                // Отримуємо назву пасхи з тексту обраного елемента
                //де у коді потрапляє у SelectedItems[0].Text
                string selectedKey = item.Tag as string; //

                // Шукаємо в нашому списку myPasxa
                // Робимо пошук по пасці
                MyPasxa ? found = myPasxa.Find(p => p.key == selectedKey);

                // Якщо об'єкт знайдено (не null), відкриваємо форму
                if (found != null)
                {
                    InfoForm details = new InfoForm(found.Value);
                    details.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Об'єкт не знайдено у списку!");
                }
            }
        }

    }
}
