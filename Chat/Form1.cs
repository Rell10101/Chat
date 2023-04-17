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

namespace Chat
{
    public partial class Form_username : Form
    {
        public Form_username()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void button_username_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form_ChatBot();
            form2.Closed += (s, args) => this.Close();
            form2.Show();

            if (this.textBox_username.Text != "")
            {
                form2.Txt = this.textBox_username.Text;
            }
            else form2.Txt = "NoName";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_username.PerformClick();
            }
        }
    }
}
