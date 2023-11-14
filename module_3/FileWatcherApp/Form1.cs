namespace FileWatcherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string folderName = textBox1.Text;
            string output = $"You selected {folderName?.ToUpper()} folder to watch";
            label2.Text = output;

            var form2 = new Form2(folderName);
            this.Hide();
            form2.Show();
        }
    }
}