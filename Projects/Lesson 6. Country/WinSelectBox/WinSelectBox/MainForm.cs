namespace WinSelectBox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //¬иводимо ус≥ наш≥ компоненти
            InitializeComponent();

            string filePath = @"C:\Users\hp\Desktop\images\dog1.jpg";
            if (File.Exists(filePath))
            {
                pbImage.Image = Image.FromFile(filePath);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string filePath = txtImagePath.Text;
            if (File.Exists(filePath))
            {
                string folder = "flags"; //папка де збер≥гаЇмо прапори
                Directory.CreateDirectory(folder);
                string fileExt = Path.GetExtension(filePath);
                string fileNameSave = $"{myTextInput.Text}{fileExt}";
                //MessageBox.Show(fileNameSave);
                //«бер≥гаЇмо обраний файл filePath по нашому ш€хов≥
                string fileSaveDirectory = 
                    Path.Combine(Directory.GetCurrentDirectory(), 
                        folder, fileNameSave);
                File.Copy(filePath, fileSaveDirectory, true);
            }

            return;

            var myCountry = new MyCountry
            {
                Name = myTextInput.Text,
                Prapor = txtImagePath.Text,
            };
            //var text = myTextInput.Text;
            //MessageBox.Show("Ќатиснули кнопку " + text);
            cbCountries.Items.Add(myCountry);
            myTextInput.Text = String.Empty;
            txtImagePath.Text= String.Empty;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            //—творюю в≥кно дл€ пошуку файлу
            // dlg - назва нашого в≥кна
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog() - показуЇ в≥кно дл€ користувача
            //якщо користувач обрав файл, то буде DialogResult.OK
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlg.FileName;
                //MessageBox.Show("file select " + fileName);
                txtImagePath.Text = fileName;
            }

        }
    }
}
