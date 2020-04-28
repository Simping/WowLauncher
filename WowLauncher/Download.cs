using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using System.Threading;

namespace WowLauncher
{
    public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Download_Load(object sender, EventArgs e)
        {
            startDownload();
        }

        // todo: specify which patch to download
        private void startDownload()
        {
            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.Proxy = null;
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(Settings.PATCH_DOWNLOAD_URL), $@"Data\\{Settings.PATCH_NAME}");
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
            this.BeginInvoke((MethodInvoker)delegate
            {
                Close();
            });
        }
    }
}
