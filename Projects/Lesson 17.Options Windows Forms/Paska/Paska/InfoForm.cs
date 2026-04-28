using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Paska
{
    public partial class InfoForm : Form
    {
        private Image originalImage;

        public InfoForm(MyPasxa pasxa)
        {
            InitializeComponent();

            label1.Text = $"Назва: {pasxa.name}";
            label2.Text = $"Вага: {pasxa.weight} г";
            label3.Text = $"Виробник: {pasxa.producer}";

            if (System.IO.File.Exists(pasxa.image))
            {
                originalImage = Image.FromFile(pasxa.image); //завантажую зображення
                pbImage.Image = originalImage; //завантажую зображення в PictureBox
                pbImage.SizeMode = PictureBoxSizeMode.Zoom; //встановилю початкове масштабування
            }

            // Налаштування повзунка
            trbZoom.Minimum = 1;
            trbZoom.Maximum = 20;
            trbZoom.Value = 10;
            trbZoom.Scroll += (s, e) => ZoomImage();
        }

        private void ZoomImage()
        {
            if (originalImage == null) return;

            double ratio = trbZoom.Value / 5.0;

            //Встановлюємо  розміри
            pbImage.Width = (int)(originalImage.Width * ratio); 
            pbImage.Height = (int)(originalImage.Height * ratio);

            //ЦЕНТРУВАННЯ:
            //Якщо картинка менша за панель — ставимо її в центр.
            //Якщо більша — AutoScroll панелі сам дозволить її крутити.

            int newX = (panel1.Width - pbImage.Width) / 2; 
            int newY = (panel1.Height - pbImage.Height) / 2;

            // Якщо ми хочемо, щоб вона завжди була по центру, навіть коли виходить за межі:
            pbImage.Location = new Point(Math.Max(0, newX), Math.Max(0, newY));
        }
    }
}
