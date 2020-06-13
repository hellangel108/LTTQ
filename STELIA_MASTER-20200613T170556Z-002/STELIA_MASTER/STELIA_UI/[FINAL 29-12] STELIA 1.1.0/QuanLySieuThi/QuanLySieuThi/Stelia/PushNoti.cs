using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stelia
{
    public partial class PushNoti : System.Windows.Forms.UserControl
    {
        Timer t1 = new Timer();
        public PushNoti()
        {
            InitializeComponent();
            t1.Interval = 2000;
            t1.Tick += new EventHandler(TimerOnTick);
            t1.Enabled = true;
        }
        public PushNoti(string NotiType, string message)
        {
            InitializeComponent();
            t1.Interval = 2000;
            t1.Tick += new EventHandler(TimerOnTick);
            t1.Enabled = true;
            switch (NotiType)
            {
                case "Error":
                    BackColor = Color.FromArgb(255, 220, 20, 60);
                    break;
                case "Success":
                    BackColor = Color.FromArgb(255, 50, 205, 50);
                    break;
                case "Normal":
                    BackColor = Color.FromArgb(255, 192, 192, 192);
                    break;
                case "Warning":
                    BackColor = Color.FromArgb(255, 255, 255, 102);
                    break;
            }
            label1.Text = message;
            
        }
        public void ShowNoti()
        {
            int loca_x = (this.Width - label1.Width) / 2;
            int loca_y = (this.Height - label1.Height) / 2;
            label1.Location = new Point(loca_x, loca_y);
            label1.ForeColor = Color.Black;
        }
        public void TimerOnTick(object obj, EventArgs e)
        {
            this.Hide();
        }
    }
}
