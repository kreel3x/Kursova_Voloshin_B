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
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt|Boris Notepad File (*.tnf)|*.tnf";

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            path = filename;
            File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("File Saved!");
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            path = filename;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("File Opened!");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = saveFileDialog1.FileName;
                path = filename;
                File.WriteAllText(filename, richTextBox1.Text);
                MessageBox.Show("File Saved!");
            }
            else
            {
                File.WriteAllText(path, richTextBox1.Text);
                MessageBox.Show("File Saved!");

            }
        }



        private void backgroundSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                delateToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                delateToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }

        }

        private void delateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
        }

        private void richTextBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                richTextBox1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            string[] lines = text.Split('\n');

      
            label5.Text = text.Length.ToString();
            
       
            label4.Text = lines.Length.ToString();

        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true)
            {
                panel1.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                panel1.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordToolStripMenuItem.Checked == true)
            {
                wordToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
            else
            {
                richTextBox1.WordWrap = true;
                wordToolStripMenuItem.Checked = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            label6.Text = richTextBox1.ZoomFactor.ToString("p0");
        }
    }
}
