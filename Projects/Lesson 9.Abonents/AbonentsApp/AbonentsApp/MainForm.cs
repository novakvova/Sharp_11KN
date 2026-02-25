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
            dlg.ShowDialog();
            //MessageBox.Show("Створення абонента");
        }
    }
}
