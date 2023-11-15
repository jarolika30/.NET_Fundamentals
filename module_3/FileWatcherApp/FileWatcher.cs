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
        public delegate void FileMonitoring(string message);
        public event FileMonitoring LogWork;
        public event EventHandler Start;
        public event EventHandler Stop;

        internal FileWatcher ()
        {
            fileSystemWatcher1 = new FileSystemWatcher();
        }

        public void StartfileSystemWatcher()
        {
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.IncludeSubdirectories = true;
            fileSystemWatcher1.Changed += new FileSystemEventHandler(FileWasChanged);
            fileSystemWatcher1.Created += new FileSystemEventHandler(FileWasCreated);
            fileSystemWatcher1.Deleted += new FileSystemEventHandler(FileWasDeleted);
            fileSystemWatcher1.Error += new ErrorEventHandler(FileSystemError);
            fileSystemWatcher1.Renamed += new RenamedEventHandler(FileWasRenamed);

            Start?.Invoke(this, new EventArgs());
        }

        public void SetFolderNameToWatch(string name)
        {
            string folder = name;
            fileSystemWatcher1.Path = folder;
        }

        public void StopFileWatcher()
        {
            fileSystemWatcher1.EnableRaisingEvents = false;
            fileSystemWatcher1.Changed -= new FileSystemEventHandler(FileWasChanged);
            fileSystemWatcher1.Created -= new FileSystemEventHandler(FileWasCreated);
            fileSystemWatcher1.Deleted -= new FileSystemEventHandler(FileWasDeleted);
            fileSystemWatcher1.Error -= new ErrorEventHandler(FileSystemError);
            fileSystemWatcher1.Renamed -= new RenamedEventHandler(FileWasRenamed);

            Stop?.Invoke(this, new EventArgs());
        }

        public void Filter (string filter)
        {
            fileSystemWatcher1.Filter = filter;
        }

        private void FileWasChanged(object sender, FileSystemEventArgs e)
        {
            LogWork.Invoke($"File {e.Name} was changed.\n Full path: {e.FullPath}");
        }

        private void FileWasCreated(object sender, FileSystemEventArgs e)
        {
            LogWork.Invoke($"File {e.Name} was created.\nFull path: {e.FullPath}");
        }

        private void FileWasDeleted(object sender, FileSystemEventArgs e)
        {
            LogWork.Invoke($"File {e.Name} was deleted.\nFull path: {e.FullPath}");
        }

        private void FileSystemError(object sender, ErrorEventArgs e)
        {
            LogWork.Invoke($"Sorry, an error occurs during the file processing.\nError: {e.GetException()}");
        }

        private void FileWasRenamed(object sender, RenamedEventArgs e)
        {
            LogWork.Invoke($"File {e.Name} was renamed.\nFull path: {e.FullPath}");
        }
    }
}
