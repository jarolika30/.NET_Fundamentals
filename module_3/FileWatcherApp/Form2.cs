using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWatcherApp
{
    public partial class Form2 : Form
    {
        private FileWatcher watcher;
        // public delegate void FileMonitoring(string message);
        // public static event FileMonitoring LogWork;
        public Form2()
        {
            watcher = new FileWatcher();
            watcher.Start += StartHandler;
            watcher.Stop += StopHandler;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rootPath = textBox1.Text;
            var files = from file in Directory.EnumerateFiles(rootPath) select file;
            var fileString = $"List of Files: {Environment.NewLine}";

            int amount = 0;
            richTextBox1.Text = fileString;

            foreach (var file in files)
            {
                richTextBox1.Text += $"{file}{Environment.NewLine}";
                amount++;
            }

            richTextBox1.AppendText($"Total files - {amount}{Environment.NewLine}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderName = textBox1.Text;
            // richTextBox1.Text += $"You have started your FileWatcher...{Environment.NewLine}";
            
            if (!string.IsNullOrEmpty(folderName))
            {
                watcher.SetFolderNameToWatch(folderName);
                watcher.StartfileSystemWatcher();
                watcher.LogWork += fileChangeHandler;
            } else
            {
                richTextBox1.Text += $"Please select the correct folder name...{Environment.NewLine}";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // richTextBox1.Text += $"You have stopped your FileWatcher... {Environment.NewLine}";
            watcher.StopFileWatcher();
        }

        private void fileChangeHandler(string text)
        {
            richTextBox1.Text += text;
        }

        private void StopHandler(object sender, EventArgs e)
        {
            richTextBox1.Text += $"You have stopped your FileWatcher... {Environment.NewLine}";
        }

        private void StartHandler(object sender, EventArgs e)
        {
            richTextBox1.Text += $"You have started your FileWatcher...{Environment.NewLine}";
        }
    }
}
