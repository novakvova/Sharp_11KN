namespace MyWindowList
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            pbImage.Image = Image.FromFile("images/logo.jpg");
        }


    }
}
