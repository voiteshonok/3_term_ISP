using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class RenameForm : Form
    {
        public string NewName { get; set; }
        public RenameForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            NewName = textBox.Text;
            Close();
        }
    }
}
