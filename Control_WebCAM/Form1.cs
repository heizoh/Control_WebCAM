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
using OpenCvSharp.Extensions;

namespace Control_WebCAM
{
    public partial class Form1 : Form
    {
        VideoCapture CV;
        Bitmap bmp;
        Mat Fr;
        Graphics Gr;
        Rectangle rect;

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
            pictureBox1.Image = bmp;
            rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Gr = pictureBox1.CreateGraphics();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        

        private bool WaitCancel()
        {

            Invoke((MethodInvoker)delegate
                {
                    
                    //if(pictureBox1.Image != null)
                    //{
                    //    pictureBox1.Image.Dispose();
                    //}

                    pictureBox1.Image = BitmapConverter.ToBitmap(Fr);

                    //System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                    //NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(CV.CvPtr, bmpData.Scan0);
                    //bmp.UnlockBits(bmpData);
                    //Gr.DrawImage(bmp, 0, 0, Fr.Cols, Fr.Rows);
                    pictureBox1.Refresh();
                });
            return true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool Frg = true;
            Task.Run(() =>
            {
                while (Frg)
                {

                    CV.Read(Fr);

                    Frg = WaitCancel();
                    System.Threading.Thread.Sleep(50);
                }
            });

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CV!=null)
            {
                CV.Dispose();
            }
            
        }
    }
}
