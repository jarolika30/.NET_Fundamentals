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
        public delegate void FileMonitoring(string message);
        public delegate void StartHandler();
        public delegate void StopHandler();
        public event FileMonitoring LogWork;
        public event StartHandler Start;
        public event StopHandler Stop;
        private string folder;
        private bool isStarted;
        private List<string> fileFilter;
        private FileInfo[] files;

        internal FileWatcher ()
        {
            isStarted = false;
        }

        public void StartfileSystemWatcher()
        {
            isStarted = true;
            Start?.Invoke();

            while (isStarted)
            {
                Thread.Sleep(3000);
                var directory = new DirectoryInfo(folder);
                var filesNow = directory.EnumerateFiles().ToArray();
                bool equal = files.SequenceEqual(filesNow, new FileInfoComparer);

                if (!equal)
                {
                    IEnumerable<FileInfo> deletedFiles = files.Except(filesNow);
                    IEnumerable<FileInfo> createdFiles = filesNow.Except(files);

                    foreach (var file in deletedFiles)
                    {
                        FileWasDeleted(file.Name, file.FullName);
                    }

                    foreach (var file in createdFiles)
                    {
                        FileWasCreated(file.Name, file.FullName);
                    }
                }
            }
        }

        public void SetFolderNameToWatch(string name)
        {
            folder = name;
        }

        public void StopFileWatcher()
        {
            /* fileSystemWatcher1.Created -= new FileSystemEventHandler(FileWasCreated);
            fileSystemWatcher1.Deleted -= new FileSystemEventHandler(FileWasDeleted); */
            isStarted = false;
            Stop?.Invoke();
        }

        public void Filter (List<string> filter)
        {
            // fileSystemWatcher1.Filter = filter;
            var directory = new DirectoryInfo(folder);
            files = directory.EnumerateFiles().ToArray();
            fileFilter = filter;
        }


        private void FileWasCreated(string name, string fullPath)
        {
            LogWork.Invoke($"File {name} was created.\nFull path: {fullPath}");
        }

        private void FileWasDeleted(string name, string fullPath)
        {
            LogWork.Invoke($"File {name} was deleted.\nFull path: {fullPath}");
        }
    }
}
