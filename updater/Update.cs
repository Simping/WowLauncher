using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace updater
{
    public partial class Update : Form
    {
        string[] argv = Environment.GetCommandLineArgs();

        public Update()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (argv.Length != 3)
            {
                MessageBox.Show("No download link provided", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else
            {
                updateLauncher(argv[2]);
            }
        }

        void updateLauncher(string url)
        {
            
            string launcherName = argv[1];

            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.Proxy = null;
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(url), $"{launcherName}_.exe");
            });
            thread.Start();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
                //progressBar1.Value = int.Parse(Math.Truncate(percentage - 1).ToString());
            });
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string launcherName = argv[1];

            if (e.Cancelled)
            {
                Close();
                File.Delete($"{launcherName}_.exe");
                MessageBox.Show("The update was cancelled", "Update cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Diagnostics.Process.Start($"{launcherName}.exe");
                return;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                long fileSize = new FileInfo($"{launcherName}_.exe").Length;
                if (fileSize > 0)
                {
                    File.Delete($"{launcherName}.exe");
                    File.Move($"{launcherName}_.exe", $"{launcherName}.exe");
                    System.Diagnostics.Process.Start($"{launcherName}.exe");
                }
                else // Nothing was downloaded
                {
                    File.Delete($"{launcherName}_.exe");
                    MessageBox.Show("The launcher could not be downloaded. Please check the download URL.", "Invalid download URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Diagnostics.Process.Start($"{launcherName}.exe");
                }

                Close();
            });
        }

    }
}