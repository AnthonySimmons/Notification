using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Notification
{
    public partial class MainForm : Form
    {
        BinaryClock binaryClock = new BinaryClock();

        Timer timer;

        const int ClockCellSize = 25;

        const int ClockCellBuffer = 5;

        public MainForm()
        {
            InitializeComponent();
            InitTimer();
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
                g.Clear(pictureBoxClock.BackColor);

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

                        g.FillRectangle(brush, x * (ClockCellSize + ClockCellBuffer), pictureBoxClock.Height - (y+1) * (ClockCellSize + ClockCellBuffer),
                                ClockCellSize, ClockCellSize);
                        y++;
                    }
                    x++;
                }
            }
        }


        #region Event Handlers

        void timer_Tick(object sender, EventArgs e)
        {
            binaryClock.UpdateTime();
            UpdateClockDisplay();
        }

        #endregion Event Handlers


    }
}
