namespace WinFormsCalc
{
    public partial class MainForm : Form
    {
        Button _currentButtonOperation = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var button = sender as Button; // «робив ≥з sender кнопку
            string btnText = button.Text; // ¬ит€гнув текст ≥з кнопки
            txtInput.AppendText(btnText);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length > 0)
            {
                // ¬идал€Їмо останн≥й символ ≥з тексту
                txtInput.Text = txtInput.Text[..^1];
            }
        }

        private void onMyClickOperation(object sender)
        {
            if (txtInput.Text.Length > 0)
            {
                var button = sender as Button;
                if(_currentButtonOperation != null)
                {
                    // ¬микаЇмо попередню кнопку
                    _currentButtonOperation.Enabled = true;
                }
                _currentButtonOperation = button;
                // ¬имикаЇмо кнопку п≥сл€ натисканн€
                button.Enabled = false;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            onMyClickOperation(sender);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            onMyClickOperation(sender);
        }
    }
}
