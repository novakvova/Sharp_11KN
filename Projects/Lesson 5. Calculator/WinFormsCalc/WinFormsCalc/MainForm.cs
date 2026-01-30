namespace WinFormsCalc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var button = sender as Button; // Зробив із sender кнопку
            string btnText = button.Text; // Витягнув текст із кнопки
            txtInput.AppendText(btnText);
        }
    }
}
