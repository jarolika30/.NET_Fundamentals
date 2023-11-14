using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWatcherApp
{
    public partial class Form2 : Form
    {
        private readonly string FolderPath;
        private readonly string fileNamePattern;
        private readonly FileWatcher fileWatcher;

        // events 

        public Form2(string folderPath, string fileNamePattern = null)
        {
            this.FolderPath = folderPath;
            this.fileNamePattern = fileNamePattern;
            InitializeComponent();
            this.FolderInitialization();
        }

        public void FolderInitialization()
        {
            FileWatcher watcher;

            if (!string.IsNullOrEmpty(fileNamePattern))
            {
                watcher = new FileWatcher((fileName) => Regex.IsMatch(fileName, this.fileNamePattern));
            }
            else
            {
                watcher = new FileWatcher();
            }

            watcher.setFolderNameToWatch(this.FolderPath);
            watcher.startfileSystemWatcher();
        }
        private void buttonClick(object sender, FileSystemEventArgs e)
        {
            this.fileWatcher.Start();
        }

        private void fileWashanged(object sender, FileSystemEventArgs e)
        {
            bool valid = this.fileWatcher.fileWasChanged(e.Name);
            this.richTextBox1.Text += $"File {e.Name} was created.\nFull path: {e.FullPath}";
        }
    }
}
