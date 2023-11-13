using System.IO;

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
            string folderName = textBox1.Text;
            string output = $"You selected {folderName?.ToUpper()} folder to watch";
            label2.Text = output;

            // setFolderNameToWatch(folderName);
            // startFileWatcher();
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was changed. \n Full path: {e.FullPath}");
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was created.\nFull path: {e.FullPath}");
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was deleted.\nFull path: {e.FullPath}");
        }

        private void fileSystemWatcher1_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show($"Sorry, an error occurs during the file processing.\nError: {e.GetException()}");
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show($"File {e.Name} was renamed.\nFull path: {e.FullPath}");
        }
    }
}