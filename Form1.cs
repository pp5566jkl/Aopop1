using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aopop1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "�Ϲ����(JPeg, Gif, Bmp, etc.)|.jpg;*jpeg;*.gif;*.bmp;*.tif;*.tiff;*.png|�Ҧ����(*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Bitmap MyBitmap = new Bitmap(openFileDialog1.FileName);
                    this.pictureBox1.Image = MyBitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "�T�����");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // �]�w�G�ת��e
                int threshold = 128; // �i�H�ھڻݭn�ק惡��

                int Height = this.pictureBox1.Image.Height;
                int Width = this.pictureBox1.Image.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;

                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        pixel = oldBitmap.GetPixel(x, y);
                        // �N pixel �ഫ���Ƕ�
                        int grayValue = (int)((299 * pixel.R + 587 * pixel.G + 114 * pixel.B) / 1000);

                        // �ھڪ��e�]�w�G�Ȥƹ�����
                        if (grayValue >= threshold)
                        {
                            newBitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255)); // �]�w���զ�
                        }
                        else
                        {
                            newBitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0)); // �]�w���¦�
                        }
                    }
                }
                this.pictureBox2.Image = newBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "�T�����");
            }
        }
    }
}
