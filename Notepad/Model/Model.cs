using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    class Model
    {
        string path;
        Form1 MyForm;
        public Model (Form1 MyForm)
        {
            this.MyForm = MyForm;
            MyForm.saveFileDialog1.Filter = "Text File(*.txt)|*.txt|Boris Notepad File (*.tnf)|*.tnf";
        }

        public bool saveAsToolStripMenuItem_Click()
        {
            if (MyForm.saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }
            string filename = MyForm.saveFileDialog1.FileName;
            path = filename;
            File.WriteAllText(filename, MyForm.richTextBox1.Text);
            return true;
        }

        public void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MyForm.openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = MyForm.openFileDialog1.FileName;
            path = filename;
            string fileText = File.ReadAllText(filename);
            MyForm.richTextBox1.Text = fileText;
            MessageBox.Show("File Opened!");
        }

        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                if (MyForm.saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = MyForm.saveFileDialog1.FileName;
                path = filename;
                File.WriteAllText(filename, MyForm.richTextBox1.Text);
                MessageBox.Show("File Saved!");
            }
            else
            {
                File.WriteAllText(path, MyForm.richTextBox1.Text);
                MessageBox.Show("File Saved!");

            }
        }

        public void delateToolStripMenuItem_Click(string a)
        {
            a = "";
        }

        public string[] richTextBox1_TextChanged()
        {
            string text = MyForm.richTextBox1.Text;
            string[] lines = text.Split('\n');
            string[] test = new string[2];

            test[0] = text.Length.ToString();
            test[1] = lines.Length.ToString();
            return test;

        }


    }
}
