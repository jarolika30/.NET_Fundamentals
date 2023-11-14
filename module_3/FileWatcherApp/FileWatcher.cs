using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWatcherApp
{
    internal class FileWatcher
    {
        private FileSystemWatcher fileSystemWatcher1;

        internal FileWatcher ()
        {
            this.fileSystemWatcher1 = new FileSystemWatcher();
        }

        public void startfileSystemWatcher()
        {
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.Changed += new FileSystemEventHandler(this.fileWasChanged);
            this.fileSystemWatcher1.Created += new FileSystemEventHandler(this.fileWasCreated);
            this.fileSystemWatcher1.Deleted += new FileSystemEventHandler(this.fileWasDeleted);
            this.fileSystemWatcher1.Error += new ErrorEventHandler(this.fileSystemError);
            this.fileSystemWatcher1.Renamed += new RenamedEventHandler(this.fileWasRenamed);
        }

        public void setFolderNameToWatch(string name)
        {
            // C:\\Users\\Katsiaryna_Staurova\\Documents
            string folderName = name;
            this.fileSystemWatcher1.Path = folderName;
        }

        private void fileWasChanged(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was changed. \n Full path: {e.FullPath}");
        }

        private void fileWasCreated(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was created.\nFull path: {e.FullPath}");
        }

        private void fileWasDeleted(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was deleted.\nFull path: {e.FullPath}");
        }

        private void fileSystemError(object sender, ErrorEventArgs e)
        {
            MessageBox.Show($"Sorry, an error occurs during the file processing.\nError: {e.GetException()}");
        }

        private void fileWasRenamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was renamed.\nFull path: {e.FullPath}");
        }
    }
}
