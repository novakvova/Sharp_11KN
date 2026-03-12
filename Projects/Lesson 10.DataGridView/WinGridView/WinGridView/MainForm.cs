namespace WinGridView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Додати елемент в DataGridView");
            object[] row =
            {
                "1",
                "Сусанін Петро Васильович",
                "+380 98 345 21 24",
                "25"
            };
            dgvUsers.Rows.Add(row);
        }
    }
}
