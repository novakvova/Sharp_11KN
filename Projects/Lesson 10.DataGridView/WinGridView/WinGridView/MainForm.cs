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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Обраний елемент у DataGridView
            var selected = dgvUsers.SelectedRows[0];
            if (selected!=null)
            {
                var userId = selected.Cells[0].Value;
                var userName = selected.Cells[1].Value;
                var userPhone = selected.Cells[2].Value;
                var userAge = selected.Cells[3].Value;
                MessageBox.Show($"{userId} {userName} {userPhone} {userAge}");
                EditForm dlg = new EditForm();
                if (dlg.ShowDialog()== DialogResult.OK)
                {
                    MessageBox.Show("Зберігаємо зміни");
                }
            }

            //MessageBox.Show("Зміна користувача");
        }
    }
}
