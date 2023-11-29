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
        private List<string> fileFilter;
        // public delegate void FileMonitoring(string message);
        // public static event FileMonitoring LogWork;
        public Form2()
        {
            watcher = new FileWatcher();
            fileFilter = new List<string>() { "*" };
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

            textBox1.Text = string.IsNullOrEmpty(rootPath) ? "Path is empty. Could you please select any folder?" : rootPath;

            try
            {
                var directory = new DirectoryInfo(rootPath);
                var files = fileFilter.SelectMany(directory.EnumerateFiles).ToArray();
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
            catch
            {
                richTextBox1.AppendText("Error whille processing selected folder...\nTry to select correct folder.");
            }

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
                watcher.Filter(fileFilter);
                watcher.LogWork += fileChangeHandler;
                watcher.Start += StartHandler;
                watcher.Stop += StopHandler;
                watcher.StartfileSystemWatcher();
            } else
            {
                richTextBox1.Text += $"Please select the correct folder name...{Environment.NewLine}";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            watcher.StopFileWatcher();
            watcher.Start -= StartHandler;
            watcher.Stop -= StopHandler;
            watcher.LogWork -= fileChangeHandler;
        }

        private void fileChangeHandler(string text)
        {
            richTextBox1.Text += text;
        }

        private void StopHandler()
        {
            richTextBox1.Text += $"You have stopped your FileWatcher... {Environment.NewLine}";
        }

        private void StartHandler()
        {
            richTextBox1.Text += $"You have started your FileWatcher...{Environment.NewLine}";
        }

        private void resetFilterCheckBoxes()
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            fileFilter.Remove("*.txt");
            fileFilter.Remove("*.img");
            fileFilter.Remove("*.png");
            fileFilter.Remove("*.jpg");
            fileFilter.Remove("*.svg");
            fileFilter.Remove("*.svg");
            fileFilter.Remove("*.csv");
        }

        private void resetAllFilesCheckBox()
        {
            checkBox1.Checked = false;
            fileFilter.Remove("*");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) {
                resetFilterCheckBoxes();

                if (!fileFilter.Contains(checkBox1.Text)) {
                    fileFilter.Add(checkBox1.Text); 
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                fileFilter.Add(checkBox2.Text);
            } else
            {
                fileFilter.Remove(checkBox2.Text);
            }

            if (checkBox1.Checked == true)
            {
                resetAllFilesCheckBox();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            var graphicFiles = checkBox3.Text;
            string[] extensions = graphicFiles.Split(", ");

            if (checkBox1.Checked == true)
            {
                resetAllFilesCheckBox();
            }

            if (checkBox3.Checked == true)
            {
                foreach(var extension in extensions)
                {
                    fileFilter.Add(extension);
                }

            } else
            {
                foreach (var extension in extensions)
                {
                    fileFilter.Remove(extension);
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                fileFilter.Add(checkBox4.Text);
            } else {
                fileFilter.Remove(checkBox4.Text);
            }

            if (checkBox1.Checked == true)
            {
                resetAllFilesCheckBox();
            }
        }
    }
}
