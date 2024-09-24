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
                openFileDialog1.Filter = "圖像文件(JPeg, Gif, Bmp, etc.)|.jpg;*jpeg;*.gif;*.bmp;*.tif;*.tiff;*.png|所有文件(*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Bitmap MyBitmap = new Bitmap(openFileDialog1.FileName);
                    this.pictureBox1.Image = MyBitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息顯示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 設定亮度門檻
                int threshold = 128; // 可以根據需要修改此值

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
                        // 將 pixel 轉換為灰階
                        int grayValue = (int)((299 * pixel.R + 587 * pixel.G + 114 * pixel.B) / 1000);

                        // 根據門檻設定二值化像素值
                        if (grayValue >= threshold)
                        {
                            newBitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255)); // 設定為白色
                        }
                        else
                        {
                            newBitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0)); // 設定為黑色
                        }
                    }
                }
                this.pictureBox2.Image = newBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息顯示");
            }
        }
    }
}
