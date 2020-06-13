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
using Stelia_BUS;
using Stelia_DTO;

namespace Stelia
{
    public partial class FormNhapNCC : DevExpress.XtraEditors.XtraForm
    {
        public FormNhapNCC()
        {
            InitializeComponent();
        }

        private void FormNhapNCC_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhaCungCap NCC = new DTO_NhaCungCap();
            NCC.MANCC = txtMa.Text;
            NCC.TENNCC = txtTen.Text;
            NCC.NGHT = dateNgHT.Text;
            NCC.DIACHI = txtDiaChi.Text;
            NCC.SDT = txtHotLine.Text;
            NCC.MUCDOCC = txtMucDo.Text;
            NCC.TRANGTHAI = txtTrangThai.Text;

            if (bus.themData(NCC))
            {
                MessageBox.Show("Bạn đã thêm thành công!");
            }
            else MessageBox.Show("Có vấn đề xảy ra mời bạn xem lại! Không thành công");
        }
    }
}