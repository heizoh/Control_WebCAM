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

            Fr = new Mat(HEIGHT, WIDTH, MatType.CV_8UC3);

            bmp = new Bitmap(Fr.Cols, Fr.Rows, (int)Fr.Step(), System.Drawing.Imaging.PixelFormat.Format24bppRgb, Fr.Data);

            Gr = pictureBox1.CreateGraphics();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        

        private bool waitCancel()
        {
            CV.Grab();

            Invoke((MethodInvoker)delegate
            {
                NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(CV.CvPtr, Fr.CvPtr);
                
                Gr.DrawImage(bmp, 0, 0, Fr.Cols, Fr.Rows);
                pictureBox1.Refresh();
            });
            return true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool Frg = true;
            while (Frg)
            {
                Task.Run(() =>
                {

                    Frg = waitCancel();
                    System.Threading.Thread.Sleep(100);

                });
            }

        }
    }
}
