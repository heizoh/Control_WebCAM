using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_WebCAM
{


    public partial class SettingPanel : Form
    {

        public Form1 fm;
        public SettingPanel()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog Diag=new FolderBrowserDialog())
            {
                Diag.ShowDialog();
                if (Diag.SelectedPath != null)
                {
                    textBox1.Text = Diag.SelectedPath;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null || comboBox1.SelectedIndex==0)
            {
                MessageBox.Show("設定されていない項目があります。");
            }
            else
            {
                fm.Path = textBox1.Text;
                fm.Pict_Format = comboBox1.Text;
            }
        }
    }
}
