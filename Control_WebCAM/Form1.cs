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
        private VideoWriter VW;
        private Mat Fr;
        private bool CFrg = true;
        private bool RecFrg = false;                    //録画状態
        private readonly int HEIGHT = 720;
        private readonly int WIDTH = 1280;
        private string path = "G:\\Pict";
        private string ext = "jpg";
        private SettingPanel st;
        private double FPS;
        private OpenCvSharp.Size SZ;
        private FourCC FCC = FourCC.XVID;

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

            //FPS = CV.Fps;
            FPS = 29.97;
            SZ.Width = CV.FrameWidth;
            SZ.Height = CV.FrameHeight;

            textBox1.Text = "";
        }

        private bool WaitCancel(bool frg)
        {

            Invoke((MethodInvoker)delegate
                {
                    Mat VF = Fr.Clone();
                    if (frg)
                    {
                        pictureBox1.Image = BitmapConverter.ToBitmap(Fr);
                        if(RecFrg)
                        {
                            VW.Write(VF);
                        }
                        else if(VW != null && VW.IsOpened())
                        {
                            VW.Release();
                        }
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

            if (button_Start.Text == "起動")
            {
                CFrg = true;
                Frg = true;
                textBox1.AppendText("カメラを起動しました。\r\n");

                //ボタンの動作を変更
                button_Rec.Enabled = true;
                button_Shot.Enabled = true;
                button_Config.Enabled = false;

                Task.Run(() =>
                {
                    while (Frg)
                    {
                        CV.Read(Fr);

                        Frg = WaitCancel(CFrg);
                        System.Threading.Thread.Sleep(20);
                    }
                });
                button_Start.Text = "停止";

            }
            else
            {
                CFrg = false;
                textBox1.AppendText("カメラを停止しました。\r\n");
                GC.Collect();

                //ボタンの動作を変更
                button_Rec.Enabled = false;
                button_Shot.Enabled = false;
                button_Config.Enabled = true;

                button_Start.Text = "起動";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CFrg = false;
            if (CV != null) CV.Dispose();
            if (Fr != null) Fr.Dispose();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //静止画像を保存します。
            if (Path != "" && Pict_Format != "")
            {
                pictureBox1.Image.Save($"{Path}\\{DateTime.Now:yyyyMMddHHmmss}.{Pict_Format}");
            }
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (button_Rec.Text == "録画")
            {
                //動画を保存します。
                
                VW = new VideoWriter(fileName: $"{Path}\\{DateTime.Now:yyyyMMddHHmmss}.avi", fourcc: FCC, fps: FPS, frameSize: SZ, isColor: true);
                RecFrg = true;

                System.Diagnostics.Debug.WriteLine($"Size:{SZ.Width}×{SZ.Height}, Fps:{FPS}, Codec:{FCC}");

                button_Shot.Enabled = false;
                button_Start.Enabled = false;
                button_Rec.Text = "停止";
                textBox1.AppendText("録画を開始しました。\r\n");
            }
            else
            {
                RecFrg = false;
                //VW.Release();
                button_Shot.Enabled = true;
                button_Start.Enabled = true;
                button_Rec.Text = "録画";
                textBox1.AppendText("録画を停止しました。\r\n");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            st.Show();
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
