using System;
using System.Windows.Forms;
using UserNameHelper;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTimeDecorator dateTimeDecorator = new DateTimeDecorator();
            string name = textBox1.Text;
            string output = dateTimeDecorator.ConcatUserName(name);
            label2.Text = output;
        }
    }
}
