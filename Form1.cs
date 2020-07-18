/*
ROE BFG arcade installer

Copyright(C) 2019 George Kalmpokis

Permission is hereby granted, free of charge, to any person obtaining a copy of this software
and associated documentation files(the "Software"), to deal in the Software without
restriction, including without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following conditions :

The above copyright notice and this permission notice shall be included in all copies or substantial
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using d3xp_arcadenet.file;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace d3xp_arcadenet
{
    public partial class Form1 : Form
    {
        private FileTransfer transfer;
        private string d3path;
        private string bfgpath;
        private string bfgfolder;
        private int imageScaling;
        public Form1()
        {
            InitializeComponent();
            transfer = new FileTransferImpl();
            imageScaling = 1;
            hScrollBar1.Maximum = 41;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Value = imageScaling;
            label8.Text = "x" + imageScaling;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (d3path == null || d3path.Equals("")) {
                printToUi("Please set Doom 3 Installation directory");
                return;
            }
            if (bfgpath == null || bfgpath.Equals(""))
            {
                printToUi("Please set Doom 3 BFG Edition Installation directory");
                return;
            }
            if (bfgfolder == null || bfgfolder.Equals(""))
            {
                printToUi("Please set Type of installation");
                return;
            }
            bfgpath += bfgfolder;
            try
            {
                printToUi("Instalation in Progress... Please wait");
                Task<bool> transferTask = transfer.transferFiles(d3path, bfgpath, imageScaling);
                await Task.WhenAny(transferTask);
            }catch(Exception ex)
            {
                printToUi(ex.Message);
            }
            printToUi("Installation Complete");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK) {
                d3path = folder.SelectedPath + "/d3xp";
                textBox1.Text = folder.SelectedPath;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                bfgpath = folder.SelectedPath;
                textBox2.Text = folder.SelectedPath;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bfgfolder = "/d3xp-arcade";
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bfgfolder = "/base";
        }

        private void printToUi(string message)
        {
            label5.Text = message;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            imageScaling = hScrollBar1.Value;
            label8.Text = "x" + imageScaling;
        }
    }
}
