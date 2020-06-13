using System;
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
    public partial class FormQuanLiTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public FormQuanLiTaiKhoan()
        {
            InitializeComponent();
        }
        private void ShowSelectedRow()
        {
            try
            {
                DataGridViewRow currow = dataGridView1.SelectedCells[0].OwningRow;
                lblTenDN.Text = currow.Cells[0].Value.ToString();
                txtMK.Text = currow.Cells[1].Value.ToString();
            }
            catch (Exception e)
            {
                lblTenDN.Text = "";
                txtMK.Text = "";
            }
        }
        void Reset()
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DataTable temp = bus.getDataTable("TAIKHOAN");
            DataColumn col = new DataColumn("HOTEN");
            col.DataType = System.Type.GetType("System.String");
            DataColumn col2 = new DataColumn("LOAI");
            col2.DataType = System.Type.GetType("System.String");
            temp.Columns.Add(col);
            temp.Columns.Add(col2);
            foreach (DataRow row in temp.Rows)
            {
                if (row[0].ToString() == "admin")
                {
                    temp.Rows.Remove(row);
                    break;
                }
            }
            foreach (DataRow row in temp.Rows)
            {
                string re = "";
                DataTable search = bus.getDataTable("NHANVIEN");
                foreach (DataRow row2 in search.Rows)
                {
                    if (row[0].ToString() == row2[0].ToString())
                    {
                        re = row2["HOTEN"].ToString();
                        row["LOAI"] = row2["CHUCVU"].ToString();
                        break;
                    }
                }
                search = bus.getDataTable("KHACHHANG");
                foreach (DataRow row2 in search.Rows)
                {
                    if (row[0].ToString() == row2[0].ToString())
                    {
                        re = row2["HOTEN"].ToString();
                        row["LOAI"] = "Khách hàng";
                        break;
                    }
                }
                row["HOTEN"] = re;
            }
            dataGridView1.DataSource = temp;
            foreach (DataGridViewTextBoxColumn col1 in this.dataGridView1.Columns)
            {
                switch (col1.HeaderText)
                {
                    case "TENDN":
                        col1.HeaderText = "Tên đăng nhập";
                        break;
                    case "MATKHAU":
                        col1.HeaderText = "Mật khẩu";
                        break;
                    case "HOTEN":
                        col1.HeaderText = "Tên chủ tài khoản";
                        break;
                    case "LOAI":
                        col1.HeaderText = "Loại tài khoản";
                        break;
                }
            }
        }

        private void FormQuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            Reset();
            ShowSelectedRow();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            ShowSelectedRow();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if(lblTenDN.Text == "admin")
            {
                ShowSelectedRow();
                PushNoti noti1 = new PushNoti("Warning", "Không thể đổi mật khẩu tài khoản admin theo cách này! Chọn mục đổi mật khẩu trên thanh tác vụ chính!");
                noti1.Width = this.Width;
                this.panel2.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            DTO_TaiKhoan tk = new DTO_TaiKhoan(lblTenDN.Text, txtMK.Text);
            if(new Stelia_BUS.Stelia_BUS().suaData(tk))
            {
                PushNoti noti1 = new PushNoti("Success", "Đổi mật khẩu thành công!");
                noti1.Width = this.Width;
                this.panel2.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
            }
            else
            {
                PushNoti noti1 = new PushNoti("Error", "Đổi mật khẩu không thành công!");
                noti1.Width = this.Width;
                this.panel2.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
            }
            Reset();
            ShowSelectedRow();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (lblTenDN.Text == "admin")
            {
                PushNoti noti1 = new PushNoti("Warning", "Không thể xoá tài khoản admin!");
                noti1.Width = this.Width;
                this.panel2.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                return;
            }
            DialogResult kq = MessageBox.Show("Bạn có chắc xóa tài khoản " + lblTenDN.Text + "?", "Hỏi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No) return;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.xoaTaiKhoan(lblTenDN.Text) == false)
                MessageBox.Show("Việc xóa xảy ra một số vấn đề! Không thành công");
            else MessageBox.Show("Đã xóa tài khoản " + lblTenDN.Text + " ra khỏi hệ thống!");
            Reset();
            ShowSelectedRow();
        }
    }
}