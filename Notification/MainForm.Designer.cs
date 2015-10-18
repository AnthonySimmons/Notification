namespace Notification
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.labelCpuUsage = new System.Windows.Forms.Label();
            this.labelRam = new System.Windows.Forms.Label();
            this.labelDisk = new System.Windows.Forms.Label();
            this.progressBarCpu = new System.Windows.Forms.ProgressBar();
            this.progressBarRam = new System.Windows.Forms.ProgressBar();
            this.progressBarDisk = new System.Windows.Forms.ProgressBar();
            this.dataGridViewProc = new System.Windows.Forms.DataGridView();
            this.ProcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndProcessColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.trackBarTransparent = new System.Windows.Forms.TrackBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonSleep = new System.Windows.Forms.Button();
            this.buttonShutdown = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonVolumeUp = new System.Windows.Forms.Button();
            this.buttonVolumeDown = new System.Windows.Forms.Button();
            this.buttonMute = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonExpand = new System.Windows.Forms.Button();
            this.pictureBoxClock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClock)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCpuUsage
            // 
            this.labelCpuUsage.AutoSize = true;
            this.labelCpuUsage.Location = new System.Drawing.Point(9, 165);
            this.labelCpuUsage.Name = "labelCpuUsage";
            this.labelCpuUsage.Size = new System.Drawing.Size(35, 13);
            this.labelCpuUsage.TabIndex = 1;
            this.labelCpuUsage.Text = "CPU: ";
            // 
            // labelRam
            // 
            this.labelRam.AutoSize = true;
            this.labelRam.Location = new System.Drawing.Point(9, 192);
            this.labelRam.Name = "labelRam";
            this.labelRam.Size = new System.Drawing.Size(34, 13);
            this.labelRam.TabIndex = 2;
            this.labelRam.Text = "RAM:";
            // 
            // labelDisk
            // 
            this.labelDisk.AutoSize = true;
            this.labelDisk.Location = new System.Drawing.Point(13, 226);
            this.labelDisk.Name = "labelDisk";
            this.labelDisk.Size = new System.Drawing.Size(35, 13);
            this.labelDisk.TabIndex = 3;
            this.labelDisk.Text = "DISK:";
            // 
            // progressBarCpu
            // 
            this.progressBarCpu.Location = new System.Drawing.Point(79, 158);
            this.progressBarCpu.Name = "progressBarCpu";
            this.progressBarCpu.Size = new System.Drawing.Size(192, 20);
            this.progressBarCpu.TabIndex = 4;
            // 
            // progressBarRam
            // 
            this.progressBarRam.Location = new System.Drawing.Point(79, 189);
            this.progressBarRam.Name = "progressBarRam";
            this.progressBarRam.Size = new System.Drawing.Size(192, 20);
            this.progressBarRam.TabIndex = 5;
            // 
            // progressBarDisk
            // 
            this.progressBarDisk.Location = new System.Drawing.Point(79, 219);
            this.progressBarDisk.Name = "progressBarDisk";
            this.progressBarDisk.Size = new System.Drawing.Size(192, 20);
            this.progressBarDisk.TabIndex = 7;
            // 
            // dataGridViewProc
            // 
            this.dataGridViewProc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewProc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcName,
            this.CPU,
            this.RAM,
            this.EndProcessColumn});
            this.dataGridViewProc.Location = new System.Drawing.Point(10, 261);
            this.dataGridViewProc.Name = "dataGridViewProc";
            this.dataGridViewProc.ReadOnly = true;
            this.dataGridViewProc.Size = new System.Drawing.Size(272, 122);
            this.dataGridViewProc.TabIndex = 10;
            this.dataGridViewProc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProc_CellContentClick);
            this.dataGridViewProc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewProc_KeyDown);
            // 
            // ProcName
            // 
            this.ProcName.HeaderText = "Name";
            this.ProcName.Name = "ProcName";
            this.ProcName.ReadOnly = true;
            this.ProcName.Width = 60;
            // 
            // CPU
            // 
            this.CPU.HeaderText = "CPU";
            this.CPU.Name = "CPU";
            this.CPU.ReadOnly = true;
            this.CPU.Width = 54;
            // 
            // RAM
            // 
            this.RAM.HeaderText = "RAM";
            this.RAM.Name = "RAM";
            this.RAM.ReadOnly = true;
            this.RAM.Width = 56;
            // 
            // EndProcessColumn
            // 
            this.EndProcessColumn.HeaderText = "End";
            this.EndProcessColumn.Name = "EndProcessColumn";
            this.EndProcessColumn.ReadOnly = true;
            this.EndProcessColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EndProcessColumn.Width = 32;
            // 
            // trackBarTransparent
            // 
            this.trackBarTransparent.Location = new System.Drawing.Point(12, 118);
            this.trackBarTransparent.Name = "trackBarTransparent";
            this.trackBarTransparent.Size = new System.Drawing.Size(202, 45);
            this.trackBarTransparent.TabIndex = 11;
            this.trackBarTransparent.ValueChanged += new System.EventHandler(this.trackBarTransparent_ValueChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // buttonSleep
            // 
            this.buttonSleep.BackColor = System.Drawing.Color.White;
            this.buttonSleep.BackgroundImage = global::Notification.Properties.Resources.LogoutIcon;
            this.buttonSleep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSleep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSleep.Location = new System.Drawing.Point(194, 38);
            this.buttonSleep.Name = "buttonSleep";
            this.buttonSleep.Size = new System.Drawing.Size(20, 20);
            this.buttonSleep.TabIndex = 15;
            this.buttonSleep.UseVisualStyleBackColor = false;
            this.buttonSleep.Click += new System.EventHandler(this.buttonSleep_Click);
            // 
            // buttonShutdown
            // 
            this.buttonShutdown.BackColor = System.Drawing.Color.White;
            this.buttonShutdown.BackgroundImage = global::Notification.Properties.Resources.PowerIcon1;
            this.buttonShutdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShutdown.Location = new System.Drawing.Point(194, 90);
            this.buttonShutdown.Name = "buttonShutdown";
            this.buttonShutdown.Size = new System.Drawing.Size(20, 20);
            this.buttonShutdown.TabIndex = 17;
            this.buttonShutdown.UseVisualStyleBackColor = false;
            this.buttonShutdown.Click += new System.EventHandler(this.buttonShutdown_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.Color.White;
            this.buttonRestart.BackgroundImage = global::Notification.Properties.Resources.RestartIcon;
            this.buttonRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestart.Location = new System.Drawing.Point(194, 64);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(20, 20);
            this.buttonRestart.TabIndex = 16;
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // buttonVolumeUp
            // 
            this.buttonVolumeUp.BackgroundImage = global::Notification.Properties.Resources.VolumeUpIcon;
            this.buttonVolumeUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVolumeUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolumeUp.Location = new System.Drawing.Point(168, 38);
            this.buttonVolumeUp.Name = "buttonVolumeUp";
            this.buttonVolumeUp.Size = new System.Drawing.Size(20, 20);
            this.buttonVolumeUp.TabIndex = 14;
            this.buttonVolumeUp.UseVisualStyleBackColor = true;
            this.buttonVolumeUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonVolumeUp_MouseDown);
            this.buttonVolumeUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonVolumeUp_MouseUp);
            // 
            // buttonVolumeDown
            // 
            this.buttonVolumeDown.BackgroundImage = global::Notification.Properties.Resources.VolumeDownIcon;
            this.buttonVolumeDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVolumeDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolumeDown.Location = new System.Drawing.Point(168, 64);
            this.buttonVolumeDown.Name = "buttonVolumeDown";
            this.buttonVolumeDown.Size = new System.Drawing.Size(20, 20);
            this.buttonVolumeDown.TabIndex = 13;
            this.buttonVolumeDown.UseVisualStyleBackColor = true;
            this.buttonVolumeDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonVolumeDown_MouseDown);
            this.buttonVolumeDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonVolumeDown_MouseUp);
            // 
            // buttonMute
            // 
            this.buttonMute.BackgroundImage = global::Notification.Properties.Resources.VolumeMuteIcon;
            this.buttonMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMute.Location = new System.Drawing.Point(168, 90);
            this.buttonMute.Name = "buttonMute";
            this.buttonMute.Size = new System.Drawing.Size(20, 20);
            this.buttonMute.TabIndex = 12;
            this.buttonMute.UseVisualStyleBackColor = true;
            this.buttonMute.Click += new System.EventHandler(this.buttonMute_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::Notification.Properties.Resources.CloseIcon;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(194, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(20, 20);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonExpand
            // 
            this.buttonExpand.BackgroundImage = global::Notification.Properties.Resources.MaximizeIcon;
            this.buttonExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpand.Location = new System.Drawing.Point(168, 12);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(20, 20);
            this.buttonExpand.TabIndex = 8;
            this.buttonExpand.UseVisualStyleBackColor = true;
            this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
            // 
            // pictureBoxClock
            // 
            this.pictureBoxClock.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxClock.Name = "pictureBoxClock";
            this.pictureBoxClock.Size = new System.Drawing.Size(150, 100);
            this.pictureBoxClock.TabIndex = 0;
            this.pictureBoxClock.TabStop = false;
            this.pictureBoxClock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClock_MouseDoubleClick);
            this.pictureBoxClock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClock_MouseDown);
            this.pictureBoxClock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClock_MouseMove);
            this.pictureBoxClock.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClock_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(294, 395);
            this.Controls.Add(this.buttonShutdown);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonSleep);
            this.Controls.Add(this.buttonVolumeUp);
            this.Controls.Add(this.buttonVolumeDown);
            this.Controls.Add(this.buttonMute);
            this.Controls.Add(this.dataGridViewProc);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonExpand);
            this.Controls.Add(this.progressBarDisk);
            this.Controls.Add(this.progressBarRam);
            this.Controls.Add(this.progressBarCpu);
            this.Controls.Add(this.labelDisk);
            this.Controls.Add(this.labelRam);
            this.Controls.Add(this.labelCpuUsage);
            this.Controls.Add(this.pictureBoxClock);
            this.Controls.Add(this.trackBarTransparent);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTransparent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxClock;
        private System.Windows.Forms.Label labelCpuUsage;
        private System.Windows.Forms.Label labelRam;
        private System.Windows.Forms.Label labelDisk;
        private System.Windows.Forms.ProgressBar progressBarCpu;
        private System.Windows.Forms.ProgressBar progressBarRam;
        private System.Windows.Forms.ProgressBar progressBarDisk;
        private System.Windows.Forms.Button buttonExpand;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewProc;
        private System.Windows.Forms.TrackBar trackBarTransparent;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button buttonMute;
        private System.Windows.Forms.Button buttonVolumeDown;
        private System.Windows.Forms.Button buttonVolumeUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAM;
        private System.Windows.Forms.DataGridViewButtonColumn EndProcessColumn;
        private System.Windows.Forms.Button buttonSleep;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonShutdown;
    }
}

