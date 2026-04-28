namespace Pasxa
{
    public partial class MainForm : Form
    {
        List<MyPasxa> myPasxas = new();
        public MainForm()
        {
            InitializeComponent();
            lvPasxy.LargeImageList = new ImageList();
            lvPasxy.LargeImageList.ImageSize = new Size(180, 130);
            lvPasxy.MultiSelect = false;
            //lvExplorer.ListViewItemSorter = new ListViewIndexComparer();
            lvPasxy.InsertionMark.Color= Color.Green;
            lvPasxy.AllowDrop = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            myPasxas.Add(new MyPasxa
            {
                name = "Європейська",
                weight = 500,
                producer = "Скиба",
                image = "C:\\images\\1.png"
            });
            myPasxas.Add(new MyPasxa
            {
                name = "Малятко",
                weight = 80,
                producer = "Скиба",
                image = "C:\\images\\2.png"
            });
            myPasxas.Add(new MyPasxa
            {
                name = "Бурштинова",
                weight = 350,
                producer = "Скиба",
                image = "C:\\images\\3.png"
            });

            foreach (var p in myPasxas)
            {
                string key = Guid.NewGuid().ToString();
                ListViewItem item = new ListViewItem();
                item.Tag = p.name;
                item.Text = p.name;
                item.ImageKey = key;
                lvPasxy.LargeImageList.Images.Add(key, Image.FromFile(p.image));
                lvPasxy.Items.Add(item);
            }
        }
    }
}
