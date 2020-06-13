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
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using Stelia_DTO;
using Stelia_BUS;

namespace Stelia
{
    public partial class FormCapNhatNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        public FormCapNhatNhaCungCap(string mancc)
        {
            InitializeComponent();
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhaCungCap[] NV = bus.search_NhaCungCap(mancc);
            DTO_NhaCungCap ncc = NV[0];
            lbl_MaDN.Text = mancc;
            TbTenNCC.Text = ncc.TENNCC;
            TbDiaChi.Text = ncc.DIACHI;
            dateHT.Text = ncc.NGHT;
            TbMucDo.Text = ncc.MUCDOCC;
            TbTrangThai.Text = ncc.TRANGTHAI;
            TbSdt.Text = ncc.SDT;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Label40_Click(object sender, EventArgs e)
        {

        }

        private void Lbl2_Click(object sender, EventArgs e)
        {

        }

        private void Pic_UpdateNCC_Click(object sender, EventArgs e)
        {
            string NGHT = DateChange.ToString(dateHT.DateTime);
            DTO_NhaCungCap NCC = new DTO_NhaCungCap(lbl_MaDN.Text, TbTenNCC.Text, NGHT, TbDiaChi.Text, TbSdt.Text, TbMucDo.Text, TbTrangThai.Text);
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.suaData(NCC) == false)
            {
                //MessageBox.Show("Có lỗi xảy ra! Không thành công");
                PushNoti noti = new PushNoti("Error", "Có lỗi xảy ra! Sửa không thành công!");
                noti.Width = 800;
                noti.Height = 30;
                this.Controls.Add(noti);
                noti.Show();
                noti.ShowNoti();
                return;
            }
            else
            {
                PushNoti noti1 = new PushNoti("Success", "Cập nhật thông tin thành công!");
                noti1.Width = 800;
                noti1.Height = 30;
                this.Controls.Add(noti1);
                noti1.Show();
                noti1.ShowNoti();
                //MessageBox.Show("Bạn đã cập nhật thành công");
            }
        }
    }
}