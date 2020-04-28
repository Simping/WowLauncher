namespace WowLauncher
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.newsPage = new System.Windows.Forms.WebBrowser();
            this.closeButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.cacheButton = new System.Windows.Forms.Button();
            this.donateButton = new System.Windows.Forms.Button();
            this.voteButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.checkServerStatus = new System.ComponentModel.BackgroundWorker();
            this.statusLabel = new System.Windows.Forms.Label();
            this.serverStatusLabel = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // newsPage
            // 
            this.newsPage.Location = new System.Drawing.Point(27, 368);
            this.newsPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.newsPage.Name = "newsPage";
            this.newsPage.Size = new System.Drawing.Size(306, 120);
            this.newsPage.TabIndex = 2;
            // 
            // closeButton
            // 
            this.closeButton.BackgroundImage = global::WowLauncher.Properties.Resources.closeButton;
            this.closeButton.Location = new System.Drawing.Point(605, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 22);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackgroundImage = global::WowLauncher.Properties.Resources.minimizeButton;
            this.minimizeButton.Location = new System.Drawing.Point(577, 12);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(22, 22);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // playButton
            // 
            this.playButton.BackgroundImage = global::WowLauncher.Properties.Resources.playButton;
            this.playButton.Location = new System.Drawing.Point(505, 400);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(93, 56);
            this.playButton.TabIndex = 3;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // cacheButton
            // 
            this.cacheButton.BackgroundImage = global::WowLauncher.Properties.Resources.cacheButton;
            this.cacheButton.Location = new System.Drawing.Point(387, 434);
            this.cacheButton.Name = "cacheButton";
            this.cacheButton.Size = new System.Drawing.Size(93, 20);
            this.cacheButton.TabIndex = 4;
            this.cacheButton.UseVisualStyleBackColor = true;
            this.cacheButton.Click += new System.EventHandler(this.cacheButton_Click);
            // 
            // donateButton
            // 
            this.donateButton.BackgroundImage = global::WowLauncher.Properties.Resources.donateButton;
            this.donateButton.Location = new System.Drawing.Point(387, 403);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(93, 20);
            this.donateButton.TabIndex = 5;
            this.donateButton.UseVisualStyleBackColor = true;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // voteButton
            // 
            this.voteButton.BackgroundImage = global::WowLauncher.Properties.Resources.voteButton;
            this.voteButton.Location = new System.Drawing.Point(387, 372);
            this.voteButton.Name = "voteButton";
            this.voteButton.Size = new System.Drawing.Size(93, 20);
            this.voteButton.TabIndex = 6;
            this.voteButton.UseVisualStyleBackColor = true;
            this.voteButton.Click += new System.EventHandler(this.voteButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.BackgroundImage = global::WowLauncher.Properties.Resources.registerButton;
            this.registerButton.Location = new System.Drawing.Point(505, 372);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(93, 20);
            this.registerButton.TabIndex = 7;
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // checkServerStatus
            // 
            this.checkServerStatus.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkServerStatus_DoWork);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Black;
            this.statusLabel.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.statusLabel.Location = new System.Drawing.Point(495, 464);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(102, 18);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Connecting";
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.BackColor = System.Drawing.Color.Black;
            this.serverStatusLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverStatusLabel.ForeColor = System.Drawing.Color.Gold;
            this.serverStatusLabel.Location = new System.Drawing.Point(387, 465);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(107, 16);
            this.serverStatusLabel.TabIndex = 9;
            this.serverStatusLabel.Text = "Server status:";
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(316, 200);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(292, 102);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 10;
            this.logo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(111, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Unable to connect";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WowLauncher.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(642, 531);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.serverStatusLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.voteButton);
            this.Controls.Add(this.donateButton);
            this.Controls.Add(this.cacheButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.newsPage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WoW Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser newsPage;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button cacheButton;
        private System.Windows.Forms.Button donateButton;
        private System.Windows.Forms.Button voteButton;
        private System.Windows.Forms.Button registerButton;
        private System.ComponentModel.BackgroundWorker checkServerStatus;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label serverStatusLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label1;
    }
}

