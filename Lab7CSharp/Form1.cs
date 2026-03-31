using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        // 7.1
        private int currentMetaIdx = 0;
        private string[] metaFiles;

        // 7.3
        private List<Shape> shapes = new List<Shape>();
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }

        // 7.1
        private void btnStart_Click(object sender, EventArgs e)
        {
            metaFiles = txtMemo.Lines; // (WMF/EMF)
            if (metaFiles.Length > 0) timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (metaFiles == null || metaFiles.Length == 0) return;
            try
            {
                pictureBox1.Image = Image.FromFile(metaFiles[currentMetaIdx]);
                currentMetaIdx = (currentMetaIdx + 1) % metaFiles.Length;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Помилка завантаження: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 7.2
        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null) return;
            Bitmap bmp = new Bitmap(pictureBox2.Image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    if (rbFull.Checked)
                        bmp.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                    else if (rbRed.Checked)
                        bmp.SetPixel(x, y, Color.FromArgb(255 - c.R, c.G, c.B));
                }
            }
            pictureBox2.Image = bmp;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
        }

        // 7.3
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            int count = (int)numCount.Value;
            for (int i = 0; i < count; i++)
            {
                int type = rnd.Next(3);
                int x = rnd.Next(50, pictureBox3.Width - 50);
                int y = rnd.Next(50, pictureBox3.Height - 50);
                Color c = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                if (type == 0) shapes.Add(new Rhombus(x, y, 30, c));
                else if (type == 1) shapes.Add(new Pentagon(x, y, 30, c));
                else shapes.Add(new Triangle(x, y, 30, c));
            }
            pictureBox3.Invalidate();
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            foreach (var s in shapes) s.Draw(e.Graphics);
        }
    }
}