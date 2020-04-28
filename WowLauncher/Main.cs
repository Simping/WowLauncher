using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;
using System.Drawing;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace WowLauncher
{
    public partial class Main : Form
    {
        // Allows user to move form
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HT_CAPTION = 0x2;

            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        public Main()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.WoW_cat;
            FormBorderStyle = FormBorderStyle.None;
            this.MaximumSize = new Size(642,532);

            File.Delete("updater.exe");
            UpdateCheck();
        }

        private void UpdateCheck()
        {
            Version newVersion;
            Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            XmlDocument versionDoc = new XmlDocument();
            try
            {
                versionDoc.Load(Settings.LAUNCHER_VERSION_URL);
                string version = versionDoc.GetElementsByTagName("version")[0].InnerText;
                newVersion = new Version(version);
            }
            catch (Exception) // Unable to get version XML file, don't update
            {
                newVersion = applicationVersion;
            }

            if (newVersion > applicationVersion)
            {
                DialogResult update = MessageBox.Show("Version " + newVersion.Major + "." + newVersion.Minor + "." + newVersion.Build + " is available, would you like to update?", "Update available", MessageBoxButtons.YesNo);
                if (update == DialogResult.Yes)
                {
                    File.WriteAllBytes("updater.exe", Properties.Resources.updater);
                    string launcherName = System.Diagnostics.Process.GetCurrentProcess().ProcessName; // get the assembly name set in application properties
                    System.Diagnostics.Process.Start("updater.exe", $"\"{launcherName}\" \"{Settings.LAUNCHER_DOWNLOAD_URL}\"");
                    Environment.Exit(0);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                newsPage.Navigate(new Uri(Settings.NEWS_URL));
                newsPage.IsWebBrowserContextMenuEnabled = false;
                newsPage.AllowWebBrowserDrop = false;
                newsPage.Refresh();
            }
            catch (Exception)
            {
                this.Controls.Remove(newsPage);
            }

            // Start the server status checker
            checkServerStatus.RunWorkerAsync();

            // Setup button mouse events
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.MouseEnter += new EventHandler(closeButton_MouseEnter);
            closeButton.MouseLeave += new EventHandler(closeButton_MouseLeave);

            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.MouseEnter += new EventHandler(minimizeButton_MouseEnter);
            minimizeButton.MouseLeave += new EventHandler(minimizeButton_MouseLeave);

            playButton.FlatStyle = FlatStyle.Flat;
            playButton.MouseEnter += new EventHandler(playButton_MouseEnter);
            playButton.MouseLeave += new EventHandler(playButton_MouseLeave);

            cacheButton.FlatStyle = FlatStyle.Flat;
            cacheButton.MouseEnter += new EventHandler(cacheButton_MouseEnter);
            cacheButton.MouseLeave += new EventHandler(cacheButton_MouseLeave);

            donateButton.FlatStyle = FlatStyle.Flat;
            donateButton.MouseEnter += new EventHandler(donateButton_MouseEnter);
            donateButton.MouseLeave += new EventHandler(donateButton_MouseLeave);

            voteButton.FlatStyle = FlatStyle.Flat;
            voteButton.MouseEnter += new EventHandler(voteButton_MouseEnter);
            voteButton.MouseLeave += new EventHandler(voteButton_MouseLeave);

            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.MouseEnter += new EventHandler(registerButton_MouseEnter);
            registerButton.MouseLeave += new EventHandler(registerButton_MouseLeave);
        }

        void setRealmlist(string realmlistPath)
        {
            bool realmlistSet = false;
            string realmlist = $"SET realmlist {Settings.REALMLIST}";
            string patchlist = $"SET patchlist {Settings.REALMLIST}";
            string[] realmlistFile = File.ReadAllLines(realmlistPath);
            List<string> newRealmlistFile = new List<string>(realmlistFile);

            // Check if realmlist has already been set
            foreach (string line in newRealmlistFile)
            {
                if (line == realmlist)
                    realmlistSet = true;
            }

            // Realmlist has already been set - no need to continue
            if (realmlistSet)
                return;

            // Comment out old realmlists
            for (int i = 0; i < newRealmlistFile.Count; i++)
            {
                string strippedLine = newRealmlistFile[i].Replace(" ", "");
                if (strippedLine[0] != '#')
                    newRealmlistFile[i] = "# " + newRealmlistFile[i];
            }

            // Set the realmlist
            newRealmlistFile.Add(realmlist);
            newRealmlistFile.Add(patchlist);
            File.WriteAllLines(realmlistPath, newRealmlistFile);
        }

        public void playButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Wow.exe"))
            {
                MessageBox.Show("Wow.exe was not found.\nPlease move the launcher to your WoW folder.", "Wow.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // todo: find any type of locale
            string realmlistUS = "Data\\enUS\\realmlist.wtf";
            string realmlistGB = "Data\\enGB\\realmlist.wtf";
            if (File.Exists(realmlistUS))
            {
                setRealmlist(realmlistUS);

            }
            else if (File.Exists(realmlistGB))
            {
                setRealmlist(realmlistGB);
            }

            if (File.Exists("Wow_Patched.exe"))
            {
                if (File.Exists($"Data\\{Settings.PATCH_NAME}"))
                {
                    String hash, hashURL;

                    // Get the sha1 hash of latest patch
                    hashURL = (new WebClient().DownloadString(Settings.PATCH_CHECKSUM_URL));

                    // Get the sha1 hash of local patch
                    using (var sha1 = SHA1.Create())
                    {
                        using (var stream = File.OpenRead($"Data\\{Settings.PATCH_NAME}"))
                        {
                            hash = BitConverter.ToString(sha1.ComputeHash(stream)).ToLower().Replace("-", "");
                            stream.Dispose();
                        }
                    }

                    // If the hashes do not match, there is a new patch
                    if (hash != hashURL)
                    {
                        if (Directory.Exists("Cache"))
                            Directory.Delete("Cache", true);
                        Download downloadProgress = new Download();
                        downloadProgress.ShowDialog();
                    }
                }
                else
                {
                    if (Directory.Exists("Cache"))
                        Directory.Delete("Cache", true);
                    Download downloadProgress = new Download();
                    downloadProgress.ShowDialog();
                }

                // Start the client
                System.Diagnostics.Process.Start("Wow_Patched.exe");
                Application.Exit();
            }
            else
            {
                // Create the patched Wow.exe and launch it
                File.WriteAllBytes("Wow_Patched.exe", Properties.Resources.Wow_Patched);
                System.Diagnostics.Process.Start("Wow_Patched.exe");
                Application.Exit();
            }
        }

        private void cacheButton_Click(object sender, EventArgs e)
        {
            if (File.Exists("Wow.exe"))
            {
                if (Directory.Exists("Cache"))
                    Directory.Delete("Cache", true);

                MessageBox.Show("Done!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Wow.exe was not found.\nPlease move the launcher to your WoW folder.", "Wow.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkServerStatus_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            TcpClient client = new TcpClient();
            bool online;
            try
            {
                online = client.ConnectAsync(Settings.REALMLIST, 3724).Wait(TimeSpan.FromSeconds(5));
            }
            catch (Exception)
            {
                online = false;
            }

            statusLabel.Invoke((MethodInvoker)delegate
            {
                if (online)
                {
                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Online";
                }
                else
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = "Offline";
                }
            });
        }


        // Button mouse events
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void closeButton_MouseEnter(object sender, EventArgs e)
        {
            this.closeButton.Image = Properties.Resources.closeButton_hover;
            Cursor = Cursors.Hand;
        }

        void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.Image = Properties.Resources.closeButton;
            Cursor = Cursors.Default;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void minimizeButton_MouseEnter(object sender, EventArgs e)
        {
            this.minimizeButton.Image = Properties.Resources.minimizeButton_hover;
            Cursor = Cursors.Hand;
        }

        void minimizeButton_MouseLeave(object sender, EventArgs e)
        {
            this.minimizeButton.Image = Properties.Resources.minimizeButton;
            Cursor = Cursors.Default;
        }

        void playButton_MouseEnter(object sender, EventArgs e)
        {
            this.playButton.Image = Properties.Resources.playButton_hover;
            Cursor = Cursors.Hand;
        }

        void playButton_MouseLeave(object sender, EventArgs e)
        {
            this.playButton.Image = Properties.Resources.playButton;
            Cursor = Cursors.Default;
        }

        void cacheButton_MouseEnter(object sender, EventArgs e)
        {
            this.cacheButton.Image = Properties.Resources.cacheButton_hover;
            Cursor = Cursors.Hand;
        }

        void cacheButton_MouseLeave(object sender, EventArgs e)
        {
            this.cacheButton.Image = Properties.Resources.cacheButton;
            Cursor = Cursors.Default;
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Settings.DONATE_URL);
            } catch (Exception)
            {
                // Unable to open URL - do nothing
            }
        }

        void donateButton_MouseEnter(object sender, EventArgs e)
        {
            this.donateButton.Image = Properties.Resources.donateButton_hover;
            Cursor = Cursors.Hand;
        }

        void donateButton_MouseLeave(object sender, EventArgs e)
        {
            this.donateButton.Image = Properties.Resources.donateButton;
            Cursor = Cursors.Default;
        }

        private void voteButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Settings.VOTE_URL);
            }
            catch (Exception)
            {
                // Unable to open URL - do nothing
            }
        }

        void voteButton_MouseEnter(object sender, EventArgs e)
        {
            this.voteButton.Image = Properties.Resources.voteButton_hover;
            Cursor = Cursors.Hand;
        }

        void voteButton_MouseLeave(object sender, EventArgs e)
        {
            this.voteButton.Image = Properties.Resources.voteButton;
            Cursor = Cursors.Default;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Settings.REGISTER_URL);
            }
            catch (Exception)
            {
                // Unable to open URL - do nothing
            }
        }

        void registerButton_MouseEnter(object sender, EventArgs e)
        {
            this.registerButton.Image = Properties.Resources.registerButton_hover;
            Cursor = Cursors.Hand;
        }

        void registerButton_MouseLeave(object sender, EventArgs e)
        {
            this.registerButton.Image = Properties.Resources.registerButton;
            Cursor = Cursors.Default;
        }

        public float getDirSize(DirectoryInfo dir)
        {
            float sum = 0;
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                sum += getDirSize(d);
            }
            foreach (FileInfo f in dir.GetFiles())
            {
                //sum in MB
                sum += ((float)Convert.ToInt64(f.Length)) / 1048576f;
            }
            return sum;
        }
    }
}
