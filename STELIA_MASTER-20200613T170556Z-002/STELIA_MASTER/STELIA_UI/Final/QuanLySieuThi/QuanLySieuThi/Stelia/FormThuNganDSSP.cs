﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stelia_DTO;

namespace Stelia
{
    public partial class FormThuNganDSSP : DevExpress.XtraEditors.XtraForm
    {
        public string MaSP;
        public FormThuNganDSSP()
        {
            InitializeComponent();
            Reset();
        }
        void Reset()
        {
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timkiemSanPham(txtTimKiem.Text);
            foreach (DataGridViewTextBoxColumn col in this.dataGridView1.Columns)
            {
                switch (col.HeaderText)
                {
                    case "MASP":
                        col.HeaderText = "Mã sản phẩm";
                        break;
                    case "TENSP":
                        col.HeaderText = "Tên sản phẩm";
                        break;
                    case "DONGIA":
                        col.HeaderText = "Đơn giá";
                        break;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Stelia_BUS.Stelia_BUS().timkiemSanPham(txtTimKiem.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] SP = bus.search_SANPHAM(currow.Cells[0].Value.ToString());
            MaSP = SP[0].MASP;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] SP = bus.search_SANPHAM(currow.Cells[0].Value.ToString());
            MaSP = SP[0].MASP;
            Close();
        }
    }
}