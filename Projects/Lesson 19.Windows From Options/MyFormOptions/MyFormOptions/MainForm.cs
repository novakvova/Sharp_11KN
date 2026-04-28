namespace MyFormOptions
{
    public partial class MainForm : Form
    {
        // Додайте змінну для відстеження поточного режиму
        bool isDarkMode = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            BackColor = isDarkMode ?
                SystemColors.Control : Color.FromArgb(26,26,26);

            btnChangeStyles.BackColor = isDarkMode ?
                Color.White : Color.Gray;

            btnChangeStyles.ForeColor = isDarkMode ?
                Color.Black : Color.White; 

            isDarkMode = !isDarkMode;
        }
    }
}
