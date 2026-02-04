namespace WinSelectBox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var text = myTextInput.Text;
            //MessageBox.Show("Натиснули кнопку " + text);
            cbCountries.Items.Add(text);
            myTextInput.Text = String.Empty;
        }
    }
}
