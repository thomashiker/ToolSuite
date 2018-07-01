using System;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Drawing;

using MetroFramework;
using MetroFramework.Forms;


namespace ToolSuite
{
    public partial class NotifyForm : MetroCForm
    {
        private System.Timers.Timer ShowTimer = new System.Timers.Timer();
        private double timerElapsed = 2000;

        public NotifyForm()
        {
            InitializeComponent();

            TopMost = true;
            UpdateNotifyLocation();

            ShowTimer.AutoReset = false;
            ShowTimer.Interval = timerElapsed;

            ShowTimer.Enabled = true;
            ShowTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
        }

        public string NotifyText
        {
            get { return labelNotify.Text; }
            set { labelNotify.Text = value; }
        }

        public double ShowElapsed
        {
            get { return timerElapsed; }
            set { timerElapsed = value; }
        }

        public Point NotifyLocation
        {
            get { return new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height); }
        }

        public void UpdateNotifyLocation()
        {
            Location = NotifyLocation;
        }

        /// <summary>
        /// Timer类执行定时到点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUp(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Hide();
            ShowTimer.Stop();
        }

        public void ShowNotify()
        {
            Show();

            ShowTimer.Start();
        }

        public void ShowNotify(string message)
        {
            UpdateNotifyLocation();
            NotifyText = message;
            ShowNotify();
        }
    }
}
