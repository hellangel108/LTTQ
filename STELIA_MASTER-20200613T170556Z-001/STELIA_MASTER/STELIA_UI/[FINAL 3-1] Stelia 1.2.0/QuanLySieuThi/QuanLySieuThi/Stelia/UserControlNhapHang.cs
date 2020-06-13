﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace Stelia
{
    public partial class UserControlNhapHang : UserControl
    {
        private Color Green_Main = Color.FromArgb(39, 174, 96);
        public UserControlNhapHang()
        {
            InitializeComponent();
            lbl1.BackColor = Green_Main;
        }

        private void DateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            dataGridView1.DataSource = bus.timkiemnhanh_PhieuNhap(textBox1.Text, textBox2.Text);
            foreach (DataGridViewTextBoxColumn col in this.dataGridView1.Columns)
            {
                switch (col.HeaderText)
                {
                    case "MAPN":
                        col.HeaderText = "Mã phiếu nhập";
                        break;
                    case "MANCC":
                        col.HeaderText = "Mã nhà cung cấp";
                        break;
                    case "NGNHAP":
                        col.HeaderText = "Ngày nhập";
                        break;
                    case "TONGSL":
                        col.HeaderText = "Tổng số lượng";
                        break;
                    case "TONGTIEN":
                        col.HeaderText = "Tổng giá trị";
                        break;
                    case "GHICHU":
                        col.HeaderText = "Ghi chú";
                        break;
                }
            }
        }
        private void UserControlNhapHang_Load(object sender, EventArgs e)
        {
            dataGridView1.Font = new Font("Time New Roman", 12, FontStyle.Regular);
            Reset();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            NhapPhieuNhap();
        }
        public void NhapPhieuNhap()
        {
            FormNhapPhieuNhap pn = new FormNhapPhieuNhap();
            pn.ShowDialog();
            if (pn.DialogResult == DialogResult.OK)
            {
                PushNoti noti1 = new PushNoti("Success", "Thêm phiếu nhập mới thành công!");
                noti1.Width = this.Width;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
            }
            Reset();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DialogResult res = MessageBox.Show("Bạn có chắc xóa phiếu nhập " + currow.Cells[0].Value.ToString() + " không?",
                "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            
            foreach (DataRow row in bus.InPhieuNhap(currow.Cells[0].Value.ToString()).Rows)
            {
                bus.xoaCTPN(currow.Cells[0].Value.ToString(),row["MASP"].ToString());
            }
            if (bus.xoaPhieuNhap(currow.Cells[0].Value.ToString()))
                MessageBox.Show("Bạn đã xóa " + currow.Cells[0].Value.ToString() + " thành công");
            else MessageBox.Show("Có vấn đề xảy ra! Không thành công");
            Reset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void pictureBoxDanhSach_Click(object sender, EventArgs e)
        {
            FormNhapPhieuNhap_NCC ncc = new FormNhapPhieuNhap_NCC();
            ncc.ShowDialog();
            if (ncc.DialogResult == DialogResult.OK)
                textBox2.Text = ncc.mancc;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            RPhieuNhap pn = new RPhieuNhap();
            pn.DataSource = new Stelia_BUS.Stelia_BUS().InPhieuNhap(currow.Cells[0].Value.ToString());
            pn.ShowPreviewDialog();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            RPhieuNhap pn = new RPhieuNhap();
            pn.DataSource = new Stelia_BUS.Stelia_BUS().InPhieuNhap(currow.Cells[0].Value.ToString());
            pn.ShowPreviewDialog();
        }
    }
}