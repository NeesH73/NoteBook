using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace NoteBook
{
    public partial class Notebook : Form
    {
        private string myFile;
        public Notebook()
        {
            InitializeComponent();
        }

        private void Notebook_Load(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";  
        }

        private void изменитьШрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog myFont=new FontDialog();
            if (myFont.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = myFont.Font;
            }
        }

        private void изменитьЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog myColorDialog=new ColorDialog();
            if (myColorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = myColorDialog.Color;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Блокнот был разработан");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog=new OpenFileDialog();
            myOpenFileDialog.Filter = "all (*.*) |*.*";
            if (myOpenFileDialog.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(myOpenFileDialog.FileName);
                myFile=myOpenFileDialog.FileName;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySaveFileDialog = new SaveFileDialog();
            mySaveFileDialog.Filter = "all (*.*) |*.*";
            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(mySaveFileDialog.FileName, richTextBox1.Text);
                myFile = mySaveFileDialog.FileName;
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageH;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }
        }

        public void PrintPageH(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 0, 0);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
