namespace WinFormsCalc
{
    public partial class MainForm : Form
    {
        Button _currentButtonOperation = null;
        //€ку саме кнопку нажав
        char curentChar = '\0'; //поточна операц≥€
        double curentValue = 0; //поточне значенн€ input

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            var button = sender as Button; // «робив ≥з sender кнопку
            string btnText = button.Text; // ¬ит€гнув текст ≥з кнопки

            txtInput.AppendText($"{btnText[0]}");
            //txtInput.AppendText(btnText);  “ут була цифра ≥ ще щось
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
                if (_currentButtonOperation != null)
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
            curentChar = '+';
            curentValue = double.Parse(txtInput.Text);
            onMyClickOperation(sender);
            txtInput.Text = "";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            curentChar = '-';
            string text = txtInput.Text;
            curentValue = Convert.ToDouble(text);
            onMyClickOperation(sender);
            txtInput.Text = "";
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            //1.ѕерев≥р€ю операц≥ю
            if(curentChar == '\0')
            {
                MessageBox.Show("ќперац≥€ в≥дсутн€");
                return;
            }
            if(string.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("¬вед≥ть значенн€");
                return; 
            }

            switch(curentChar)
            {
                case '-':
                    {
                        double b = Convert.ToDouble(txtInput.Text);
                        var result = curentValue - b;
                        txtInput.Text = result.ToString();
                        curentChar = '\0'; //скасовую в≥дн≥менн€
                        //активовую кнопку назад, щоб ще раз можна було натискати
                        _currentButtonOperation.Enabled = true;
                        break;
                    }
                case '+':
                    {
                        double b = Convert.ToDouble(txtInput.Text);
                        var result = curentValue + b;
                        txtInput.Text = result.ToString();
                        curentChar = '\0'; //скасовую в≥дн≥менн€
                        //активовую кнопку назад, щоб ще раз можна було натискати
                        _currentButtonOperation.Enabled = true;
                        break;
                    }
            }
        }
    }
}
