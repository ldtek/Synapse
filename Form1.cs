using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compression3
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

        Archiving ar = new Archiving();
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Fbd = new FolderBrowserDialog();
            string path = string.Empty;
            if (Fbd.ShowDialog() == DialogResult.OK)
            {
                path = Fbd.SelectedPath;
            }
            DirectoryInfo Dinfo = new DirectoryInfo(path);
            foreach (FileInfo fInfo in Dinfo.GetFiles())
            {
                if (YesDo)
                {
                    ar.Compress(fInfo,this.listBox1);
                    File.Delete(fInfo.FullName);
                }
                else
                {
                    ar.Compress(fInfo,this.listBox1);
                }
                
            }
        }

        bool YesDo = false; 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                YesDo = true;
                return;
            }
            YesDo = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Fbd = new FolderBrowserDialog();
            string path = string.Empty;
            if (Fbd.ShowDialog() == DialogResult.OK)
            {
                path = Fbd.SelectedPath;
            }
            DirectoryInfo Dinfo = new DirectoryInfo(path);
            foreach (FileInfo fInfo in Dinfo.GetFiles())
            {
                    ar.Extract(fInfo);
                    File.Delete(fInfo.FullName);
            }
        }
    }
}
