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

namespace FileManager
{
    public partial class TextForm : Form
    {
        private string _path;

        public TextForm(string path)
        {
            _path = path;
            InitializeComponent();

            using (var sr = new StreamReader(_path))
            {
                richTextBox.Text = sr.ReadToEnd();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter(_path))
            {
                sw.Write(richTextBox.Text);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
