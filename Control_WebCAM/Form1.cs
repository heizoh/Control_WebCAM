using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace Control_WebCAM
{
    public partial class Form1 : Form
    {
        VideoCapture CV;
        Bitmap bmp;
        Mat Fr;
        Graphics Gr;

        int HEIGHT = 480;
        int WIDTH = 720;
        public Form1()
        {
            InitializeComponent();

            CV = new VideoCapture(0);
            if(!CV.IsOpened())
            {
                MessageBox.Show("カメラが開けません。");
                this.Close();
            }

            CV.FrameHeight = HEIGHT;
            CV.FrameWidth = WIDTH;

            Fr = new Mat(HEIGHT, WIDTH, MatType.CV_8SC3);

            bmp = new Bitmap(Fr.Cols, Fr.Rows, (int)Fr.Step(), System.Drawing.Imaging.PixelFormat.Format24bppRgb, Fr.Data);

            Gr = pictureBox1.CreateGraphics();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
