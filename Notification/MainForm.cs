using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using Notification.SystemControls;

namespace Notification
{
    public partial class MainForm : Form
    {
        private int _volumeUpdateTime = 150;

        private bool _volumeUp = false;

        private bool _volumeDown = false;

        BinaryClock binaryClock = new BinaryClock();

        Timer timer;

        const int ClockCellSize = 20;

        const int ClockCellBuffer = 5;

        bool Expanded = false;

        bool Drag = false;

        Point DragPoint;

        delegate void SetCpuCallback(float usage);

        private VolumeControl _volumeControl;

        public MainForm()
        {
            InitializeComponent();
            InitTimer();
            this.TopMost = true;

            this.CreateHandle();

            Diagnostics.Diagnostics.progressBarCallBack += new Diagnostics.Diagnostics.ProgressBarCallBack(Diagnostics_progressBarCallBack);
            SetControlLocations();

            this.ShowInTaskbar = false;

            Bitmap bmp = new Bitmap("../../Icon.png");
            this.Icon = Icon.FromHandle(bmp.GetHicon());
                       

            _volumeControl = new VolumeControl(this.Handle);
            
        }



        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void UpdateClockDisplay()
        {
            using (Graphics g = pictureBoxClock.CreateGraphics())
            {
                g.Clear(Color.Transparent);

                int x = 0;

                foreach (var column in binaryClock.TimeColumns)
                {
                    int y = 0;
                    foreach (var cell in column.Cells)
                    {
                        Brush brush;
                        if (cell.IsOn)
                        {
                            brush = Brushes.Blue;   
                        }
                        else
                        {
                            brush = Brushes.White;
                        }

                        g.FillRectangle(brush, x * (ClockCellSize + ClockCellBuffer)+5, pictureBoxClock.Height - (y+1) * (ClockCellSize + ClockCellBuffer),
                                ClockCellSize, ClockCellSize);
                        y++;
                    }
                    x++;
                }
            }
        }

        private void UpdateDiagnostics()
        {
            Thread thread = new Thread(SetCpuUsageThread);
            thread.Start();
    
            float availableRam = Diagnostics.Diagnostics.GetRamUsage();
            ulong totalRam = Diagnostics.Diagnostics.GetTotalRam();

            labelRam.Text = String.Format("RAM:\n {0}/{1}", availableRam.ToString("##"), totalRam.ToString("##"));

            progressBarRam.Value = (int)((availableRam / totalRam) * 100);
            SetDriveSpace();
        }

        private void SetCpuUsageThread()
        { 
            float usage = Diagnostics.Diagnostics.GetCpuUsage();
            SetCpuUsage(usage);
        }

        private void SetCpuUsage(float usage)
        {
            if (labelCpuUsage.InvokeRequired)
            {
                SetCpuCallback callBack = new SetCpuCallback(SetCpuUsage);
                this.Invoke(callBack, new object[] { usage });
            }
            else
            {
                Diagnostics_progressBarCallBack(usage);
            }
        }

        private void SetDriveSpace()
        {
            var drives =  DriveInfo.GetDrives();
            foreach (DriveInfo info in drives)
            {
                if (info.IsReady && info.Name.Contains("C:"))
                {
                    labelDisk.Text = String.Format("Disk: {0}", info.TotalFreeSpace / (1024*1024));
                    progressBarDisk.Value = (int)(100 * (info.TotalSize - info.AvailableFreeSpace) / info.TotalSize);
                }
            }
        }

        private void LoadProcesses()
        {
            var procs = Process.GetProcesses();

            foreach (var p in procs)
            {
                if (!string.IsNullOrEmpty(p.MainWindowTitle))
                {
                    DataGridViewRow row = GetRowByName(p.ProcessName);
                    if (row == null)
                    {
                        int n = dataGridViewProc.Rows.Add();
                        row = dataGridViewProc.Rows[n];
                    }
                    
                    row.Cells[0].Value = p.ProcessName;
                    row.Cells[1].Value = Diagnostics.Diagnostics.CachedCpuUsageByProc(p.ProcessName).ToString("##.#") + "%";
                    row.Cells[2].Value = Diagnostics.Diagnostics.GetRamUsageByProc(p.ProcessName) + "Mb";
                    
                }
            }
        }

        private DataGridViewRow GetRowByName(string name)
        {
            DataGridViewRow row = null;

            foreach (DataGridViewRow r in dataGridViewProc.Rows)
            {
                if (r.Cells.Count > 0 && r.Cells[0].Value != null
                 && r.Cells[0].Value.ToString().Contains(name))
                {
                    row = r;
                    break;
                }
            }

            return row;        
        }


        private void SetControlLocations()
        {
            trackBarTransparent.Value = (int)this.Opacity * 10;
            this.pictureBoxClock.Height = (ClockCellSize + ClockCellBuffer) * 4 + 10;
            this.pictureBoxClock.Width = (ClockCellSize + ClockCellBuffer) * 6 + 5;

            this.pictureBoxClock.Location = new Point(5, 5);
            
            if (Expanded)
            {
                this.Height = this.dataGridViewProc.Location.Y + this.dataGridViewProc.Height + 15;
                this.Width = this.dataGridViewProc.Location.X + this.dataGridViewProc.Width + 25;
                this.buttonExpand.BackgroundImage = Properties.Resources.MinimizeIcon;
            }
            else
            {
                this.Height = this.trackBarTransparent.Location.Y + this.trackBarTransparent.Height - 10;
                this.Width = this.pictureBoxClock.Location.X + this.pictureBoxClock.Width + 60;
                this.buttonExpand.BackgroundImage = Properties.Resources.MaximizeIcon;
            }
            

            //buttonClose.Location = new Point(this.Width - buttonClose.Width - 15, 5);
            //this.buttonExpand.Location = new Point(this.Width - buttonExpand.Width - 15, this.buttonClose.Height + 10);

            DrawBorder();

            this.Refresh();
            Application.DoEvents();

        }


        private void DrawBorder()
        {
            int thickness = 2;
            using (var g = this.CreateGraphics())
            {
                g.DrawLine(new Pen(Brushes.Black), 0, 0, this.Width, this.Height);
                g.DrawRectangle(new Pen(Brushes.Black), 0, 0, this.Width - thickness, this.Height - thickness);
            }
        }


        #region Event Handlers

        void timer_Tick(object sender, EventArgs e)
        {
            binaryClock.UpdateTime();
            UpdateClockDisplay();

            if (Expanded)
            {
                LoadProcesses();
                UpdateDiagnostics();
            }
        }

        void Diagnostics_progressBarCallBack(float val)
        {
            labelCpuUsage.Text = String.Format("CPU: {0}%", val.ToString("##.#"));
            progressBarCpu.Value = (int)val;
        }

        private void pictureBoxClock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetControlLocations();
        }
        
        private void buttonExpand_Click(object sender, EventArgs e)
        {
            Expanded = !Expanded;
            bool isInCorner = IsInCorner();
            SetControlLocations();

            if(isInCorner)
            {
                SetLocation();    
            }
        }    
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            DragPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            Drag = false;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(Drag)
            {
                this.Location = new Point(Cursor.Position.X-DragPoint.X, Cursor.Position.Y-DragPoint.Y);
            }
        }


        private void pictureBoxClock_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Location = new Point(Cursor.Position.X-DragPoint.X, Cursor.Position.Y-DragPoint.Y);
            }
        }

        private void pictureBoxClock_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            DragPoint = new Point(e.X, e.Y);
        }

        private void pictureBoxClock_MouseUp(object sender, MouseEventArgs e)
        {
            Drag = false;
        }

        private void dataGridViewProc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridViewProc.SelectedCells.Count > 0)
                {
                    string name = dataGridViewProc.SelectedCells[0].Value.ToString();
                    Diagnostics.Diagnostics.KillProcByName(name);
                }
            }
        }

        private void trackBarTransparent_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = Math.Max(0.1, (float)trackBarTransparent.Value / (float)trackBarTransparent.Maximum);
            this.Refresh();
        }


        #endregion Event Handlers

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Activate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetLocation();
        }

        private bool IsInCorner()
        {
            bool isRightBound = this.Location.X + this.Width >= Screen.PrimaryScreen.WorkingArea.Width;
            bool isLowerBound = this.Location.Y + this.Height >= Screen.PrimaryScreen.WorkingArea.Height;
            return isRightBound && isLowerBound;
        }

        private void SetLocation()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
        }

        private void buttonMute_Click(object sender, EventArgs e)
        {
            _volumeControl.Mute();
        }

        private void buttonVolumeDown_Click(object sender, EventArgs e)
        {
            _volumeControl.VolumeDown();
        }

        private void buttonVolumeUp_Click(object sender, EventArgs e)
        {
            _volumeControl.VolumeUp();
        }

        private void buttonVolumeUp_MouseDown(object sender, MouseEventArgs e)
        {
            _volumeUp = true;
            var volumeUpThread = new Thread(VolumeUpThread);
            volumeUpThread.Start();
        }

        private void VolumeUpThread()
        {
            while (_volumeUp)
            {
                _volumeControl.VolumeUp();
                Thread.Sleep(_volumeUpdateTime);
            }
        }

        
        private void VolumeDownThread()
        {
            while (_volumeDown)
            {
                _volumeControl.VolumeDown();
                Thread.Sleep(_volumeUpdateTime);
            }
        }

        private void buttonVolumeUp_MouseUp(object sender, MouseEventArgs e)
        {
            _volumeUp = false;
        }

        private void buttonVolumeDown_MouseUp(object sender, MouseEventArgs e)
        {
            _volumeDown = false;
        }

        private void buttonVolumeDown_MouseDown(object sender, MouseEventArgs e)
        {
            _volumeDown = true;
            var volumeDownThread = new Thread(VolumeDownThread);
            volumeDownThread.Start();
        }

        private void dataGridViewProc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProc.SelectedCells.Count > 0)
            {
                string name = dataGridViewProc.Rows[e.RowIndex].Cells[0].Value.ToString();
                Diagnostics.Diagnostics.KillProcByName(name);
            }
        }

        private void buttonSleep_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sleep?", "Notifications Diagnostics", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Diagnostics.PowerControls.Sleep();
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Restart?", "Notifications Diagnostics", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Diagnostics.PowerControls.Restart();
            }
        }

        private void buttonShutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Shutdown?", "Notifications Diagnostics", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Diagnostics.PowerControls.Shutdown();
            }
        }

    }
}
