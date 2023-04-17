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
    public partial class Form_ChatBot : Form
    {
        ChatBotCS user;
        public Form_ChatBot()
        {
            InitializeComponent();

            user = new ChatBotCS();

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("Справка");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);

            FormClosing += new FormClosingEventHandler(Form2_Closing);

            KeyPreview = true;
        }

        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Справка \n" +
                "Возможности ЧатБота:\n" +
                "1. Отвечает на приветствие(любое слово, которое начинается на 'прив')\n" +
                "2. Показывает время(врем)\n" +
                "3. Показывает дату(дат)\n" +
                "4. Умеет складывать/умножать/вычитать/делить числа(прибавь число к числу/умножь/разность/раздели)\n");
        }

        public string Txt
        {
            get { return user.username_get(); }
            set { user.username_set(value); }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (textBox_In.Text != "")
            {
                // сообщение пользователя  
                textBox_out.Text += textBox_In.Text + "(" + user.username_get() + ", " + DateTime.Now.ToString("T") + ")\n" + Environment.NewLine;
                // ответ чатбота
                textBox_out.Text += user.answer(textBox_In.Text) + Environment.NewLine + Environment.NewLine;
            }
            textBox_In.Text = "";
        }

        private void Form2_Closing(object sender, FormClosingEventArgs e)
        {
            string path = @"D:\University\OOP2\ChatBotFinal\Chat\MyFile";

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            string Text = textBox_out.Text;
            File.AppendAllText(path, Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string path = @"D:\University\OOP2\ChatBotFinal\Chat\MyFile";
            if (!File.Exists(path))
            {
                textBox_out.Text += File.ReadAllText(path);
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_send.PerformClick();
                // чтобы при нажатии на enter курсор в поле ввода оставался на первой строчке
                e.SuppressKeyPress = true;
            }
        }
    }
}
