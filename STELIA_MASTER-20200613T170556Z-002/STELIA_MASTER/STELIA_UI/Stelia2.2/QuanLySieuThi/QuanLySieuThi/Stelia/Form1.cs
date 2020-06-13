using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace Stelia
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int switch0 = 0; //0 - popup allow, 1 - not allow
        Point p = new Point(0, 9999);
        UserControlTongQuanMain TQ = new UserControlTongQuanMain(1918, 913);
        UserControlNhapHang NH = new UserControlNhapHang();
        UserControlHangHoa HH = new UserControlHangHoa();
        UserControlNhanVien NV = new UserControlNhanVien();
        public Form1()
        {
            InitializeComponent();
            PanelUserControl.Controls.Add(TQ);
            //TQ.Dock = DockStyle.Top;
        }

        private void backstageViewTabItem1_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radialMenu1.ShowPopup(p, false);
            switch0 = 0;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void radialMenu1_CloseUp(object sender, EventArgs e)
        {
            if (switch0 == 0)
                radialMenu1.ShowPopup(p, false);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch0 = 1;
            radialMenu1.HidePopup();
        }

        private void ribbonControl1_ApplicationButtonClick(object sender, EventArgs e)
        {
            if (switch0 == 0)
                switch0 = 2;
            radialMenu1.HidePopup();
        }

        private void backstageViewControl2_BackButtonClick(object sender, EventArgs e)
        {
            if (switch0 == 2)
            {
                radialMenu1.ShowPopup(p, false);
                switch0 = 0;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                radialMenu1.ShowPopup(new Point(e.X, e.Y), true);
            }
        }

        private void BackstageViewControl2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PanelUserControl.Controls.Clear();
            PanelUserControl.Controls.Add(NH);
        }

        private void BarButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PanelUserControl.Controls.Clear();
            PanelUserControl.Controls.Add(HH);
        }

        private void PanelUserControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PanelUserControl.Controls.Clear();
            PanelUserControl.Controls.Add(NV);
        }
    }
}
