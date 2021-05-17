using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    class Presenter
    {
        Model MyModel;
        Form1 MyForm;

        public Presenter(Form1 MyForm)
        {
            this.MyForm = MyForm;
            MyModel = new Model(MyForm);

            MyForm.saveAsToolStripMenuItem.Click += saveAsToolStripMenuItemHandler;
            MyForm.openToolStripMenuItem1.Click += MyModel.openToolStripMenuItem1_Click;
            MyForm.saveToolStripMenuItem.Click += MyModel.saveToolStripMenuItem_Click;
            MyForm.delateToolStripMenuItem.Click += delateToolStripMenuItemHandler;
            MyForm.richTextBox1.TextChanged += richTextBox1_TextChangedHandler;

            Application.Run(MyForm);

            
        }

        void saveAsToolStripMenuItemHandler (object sender, EventArgs e)
        {
            bool a = MyModel.saveAsToolStripMenuItem_Click();
            if (a == true)
            {
                MessageBox.Show("File Saved!");
            }
        }

        void delateToolStripMenuItemHandler(object sender, EventArgs e)
        {
            MyModel.delateToolStripMenuItem_Click(MyForm.richTextBox1.SelectedText);
        }

        void richTextBox1_TextChangedHandler(object sender, EventArgs e)
        {
            string[] array = MyModel.richTextBox1_TextChanged();

            MyForm.label5.Text = array[0];
            MyForm.label4.Text = array[1];

        }

    }
}
