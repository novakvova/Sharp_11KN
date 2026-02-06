namespace WinSelectBox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //Виводимо усі наші компоненти
            InitializeComponent();

            string filePath = @"C:\Users\hp\Desktop\images\dog.jpg";
            pbImage.Image = Image.FromFile(filePath);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var myCountry = new MyCountry
            {
                Name = myTextInput.Text,
                Prapor = txtImagePath.Text,
            };
            //var text = myTextInput.Text;
            //MessageBox.Show("Натиснули кнопку " + text);
            cbCountries.Items.Add(myCountry);
            myTextInput.Text = String.Empty;
            txtImagePath.Text= String.Empty;
        }
    }
}
