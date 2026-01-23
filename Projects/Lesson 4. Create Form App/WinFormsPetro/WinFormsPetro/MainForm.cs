namespace WinFormsPetro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            // Отримую значення з текстового поля txtA
            string a = txtA.Text;
            string b = txtB.Text;
            //MessageBox.Show("Натиснули +");
            //MessageBox.Show($"Значення a = {a} та b = {b}");
            lbResult.Text = "Результат: "+(Convert.ToDouble(a) + Convert.ToDouble(b)).ToString();
        }
    }
}
