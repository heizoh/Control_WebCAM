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
        private VideoCapture CV;
        private Bitmap bmp;
        private Mat Fr;
        private bool CFrg = true;
        private readonly int HEIGHT = 720;
        private readonly int WIDTH = 1280;
        private StringBuilder sb = new StringBuilder();
        private string path = "";
        private string ext = "";
        private SettingPanel st;

        public Form1()
        {
            InitializeComponent();
            st = new SettingPanel();
            st.fm = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CV = new VideoCapture(0);
            if (!CV.IsOpened())
            {
                MessageBox.Show("カメラが開けません。");
                this.Close();
            }

            CV.FrameHeight = HEIGHT;
            CV.FrameWidth = WIDTH;

            Fr = new Mat(HEIGHT, WIDTH, MatType.CV_8UC3);

            bmp = new Bitmap(Fr.Cols, Fr.Rows, (int)Fr.Step(), System.Drawing.Imaging.PixelFormat.Format24bppRgb, Fr.Data);
            pictureBox1.Image = bmp;
            textBox1.Text = "";
        }



        private bool WaitCancel(bool frg)
        {

            Invoke((MethodInvoker)delegate
                {
                    if (frg)
                    {
                        pictureBox1.Image = BitmapConverter.ToBitmap(Fr);
                        pictureBox1.Refresh();
                    }
                });
            if (frg)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool Frg;

            if (button1.Text == "起動")
            {
                CFrg = true;
                Frg = true;
                textBox1.AppendText("カメラを起動しました。\r\n");
                Task.Run(() =>
                {
                    while (Frg)
                    {
                        CV.Read(Fr);

                        Frg = WaitCancel(CFrg);
                        System.Threading.Thread.Sleep(50);
                    }
                });
                button1.Text = "停止";

            }
            else
            {
                CFrg = false;
                textBox1.AppendText("カメラを停止しました。\r\n");
                GC.Collect();
                button1.Text = "起動";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (CV != null) CV.Dispose();
            if (bmp != null) bmp.Dispose();
            if (Fr != null) Fr.Dispose();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //静止画像を保存します。
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //動画を保存します。
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        }

        public string Path
        {
            set
            {
                path = value;
            }
            get
            {
                return path;
            }
        }

        public string Pict_Format
        {
            set
            {
                ext = value;
            }
            get
            {
                return ext;
            }
        }

    }
}
