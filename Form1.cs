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
                    pictureBox1.Image = new SepiaFilter().UseFilter(defaultImage);
                    break;

                case 2:
                    pictureBox1.Image = new InversionFilter().UseFilter(defaultImage);
                    break;

                case 3:
                    pictureBox1.Image = new ContourFilter().UseFilter(defaultImage);
                    break;

                case 4:
                    pictureBox1.Image = new DreamcoreFilter().UseFilter(defaultImage);
                    break;

                default:
                    break;
            }
        }


    }
}
