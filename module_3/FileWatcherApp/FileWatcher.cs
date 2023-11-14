using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWatcherApp
{
    public class FileWatcher
    {
        private FileSystemWatcher fileSystemWatcher1;
        private Func<string, bool> filter;

        public FileWatcher ()
        {
            this.fileSystemWatcher1 = new FileSystemWatcher();
        }

        public FileWatcher (Func<string, bool> filter)
        {
            this.filter = filter;
            this.fileSystemWatcher1 = new FileSystemWatcher();
        }

        public void startfileSystemWatcher()
        {
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.Created += this.FileWasCreated;
            this.fileSystemWatcher1.Deleted += this.FileWasDeleted;
        }

        public void setFolderNameToWatch(string folderPath)
        {
            // C:\\Users\\Katsiaryna_Staurova\\Documents
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            this.fileSystemWatcher1.Path = folderPath;
        }
        public void Start()
        {
            this.fileSystemWatcher1.EnableRaisingEvents = true;

        }

        public bool Validate(string fileName)
        {
            return this.filter(fileName);
        }

        private event File FileWasChanged(object sender, FileSystemEventArgs e)
        {
            bool valid = this.fileWatcher.fileWasChanged(e.Name);
                this.richTextBox1.Text += $"File {e.Name} was created.\nFull path: {e.FullPath}";
        }

        private void FileWasCreated(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was created.\nFull path: {e.FullPath}");
        }

        private void FileWasDeleted(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was deleted.\nFull path: {e.FullPath}");
        }

        private void FilteredFileWasCreated(object sender, ErrorEventArgs e)
        {
            MessageBox.Show($"Sorry, an error occurs during the file processing.\nError: {e.GetException()}");
        }

        private void FilteredFileWasDeleted(object sender, RenamedEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was renamed.\nFull path: {e.FullPath}");
        }

    }
}
