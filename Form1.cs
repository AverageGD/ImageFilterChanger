using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Image defaultImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)|*.BMP; *.JPG; *.GIF; *.PNG|All files(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    defaultImage = pictureBox1.Image;
                } catch 
                {
                    MessageBox.Show("Impossible to open the chosen file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;

            sfd.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)|*.BMP; *.JPG; *.GIF; *.PNG|All files(*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image.Save(sfd.FileName);
                }
                catch
                {
                    MessageBox.Show("Impossible to save the chosen file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;


            short filterNum;

            short.TryParse(textBox1.Text, out filterNum);

            textBox1.Text = "";

            switch (filterNum)
            {
                case 1:
                    FilterSepia();
                    break;

                case 2:
                    FilterInversion();
                    break;

                case 3:
                    FilterContour();
                    break;

                default:
                    break;
            }
        }

        private void FilterSepia()
        {
            Bitmap bitmap = new Bitmap(defaultImage);

            for (int i = 0; i < defaultImage.Height; i++)
            {
                for (int j = 0; j < defaultImage.Width; j++)
                {
                    short red = bitmap.GetPixel(j, i).R;
                    short green = bitmap.GetPixel(j, i).G;
                    short blue = bitmap.GetPixel(j, i).B;

                    Color newColor = Color.FromArgb((red + green + blue) / 3, (red + green + blue) / 3, (red + green + blue) / 3);

                    bitmap.SetPixel(j, i, newColor);

                }
            }

            pictureBox1.Image = bitmap;
        }

        private void FilterInversion()
        {
            Bitmap bitmap = new Bitmap(defaultImage);

            for (int i = 0; i < defaultImage.Height; i++)
            {
                for (int j = 0; j < defaultImage.Width; j++)
                {
                    short red = bitmap.GetPixel(j, i).R;
                    short green = bitmap.GetPixel(j, i).G;
                    short blue = bitmap.GetPixel(j, i).B;

                    Color newColor = Color.FromArgb(255 - red, 255 - green, 255 - blue);

                    bitmap.SetPixel(j, i, newColor);

                }
            }

            pictureBox1.Image = bitmap;
        }

        private void FilterContour()
        {
            Bitmap bitmap = new Bitmap(defaultImage);

            for (int i = 0; i < defaultImage.Height; i++)
            {
                for (int j = 0; j < defaultImage.Width; j++)
                {
                    short red = bitmap.GetPixel(j, i).R;
                    short green = bitmap.GetPixel(j, i).G;
                    short blue = bitmap.GetPixel(j, i).B;

                    Color newColor = Color.FromArgb((red + green + blue) / 3, (red + green + blue) / 3, (red + green + blue) / 3);

                    bitmap.SetPixel(j, i, newColor);

                }
            }

            for (int i = 0; i < defaultImage.Height - 1; i++)
            {
                for (int j = 0; j < defaultImage.Width - 1; j++)
                {
                    int current = bitmap.GetPixel(j, i).G;
                    int up = bitmap.GetPixel(j, i + 1).G;
                    int right = bitmap.GetPixel(j + 1, i).G;

                    int dx = Math.Abs(current - up);
                    int dy = Math.Abs(current - right);

                    int gradient = (int)Math.Sqrt(dx * dx + dy * dy) * 100;

                    gradient = Math.Min(255, gradient);

                    Color newColor = Color.FromArgb(gradient, gradient, gradient);

                    bitmap.SetPixel(j, i, newColor);

                }
            }

            pictureBox1.Image = bitmap;
        }

    }
}
