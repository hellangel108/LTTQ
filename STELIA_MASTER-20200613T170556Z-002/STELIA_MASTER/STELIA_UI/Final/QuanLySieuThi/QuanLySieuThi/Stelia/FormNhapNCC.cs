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
using System.IO;

namespace Stelia
{
    public partial class FormNhapNCC : DevExpress.XtraEditors.XtraForm
    {
        private string fileAnh = "";
        public FormNhapNCC()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            if (bus.getDataTable("NHACUNGCAP") == null)
            {
                txtMa.Text = "NCC001";
                return;
            }
            try
            {
                string str = bus.getThongTinNCC(0, bus.getDataTable("NHACUNGCAP").Rows.Count - 1);
                str = str.Remove(0, 3);
                int temp = str.Length;
                str = (Convert.ToInt32(str) + 1).ToString();
                while (str.Length < temp)
                {
                    str = "0" + str;
                }
                string masp = "NCC";
                masp += str;
                txtMa.Text = masp;
            }
            catch (Exception ex) { }
        }

        private void FormNhapNCC_Load(object sender, EventArgs e)
        {
            lbl1.BackColor = lbl2.BackColor = Color.FromArgb(39, 174, 96);
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
            }
            else
            {
                MessageBox.Show("Có vấn đề xảy ra mời bạn xem lại! Không thành công");
                return;
            }
            string desAnh = Application.StartupPath + "/HinhAnhNCC/" + txtMa.Text + ".jpg";
            if (fileAnh != "")
            {
                if (File.Exists(desAnh))
                    File.Delete(desAnh);
                File.Copy(fileAnh, desAnh);
            }
            DialogResult = DialogResult.OK;
            Close();

        }

        private void PicChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileAnh = dlg.FileName;
            }
            else return;
            picAnh.Image = Image.FromFile(fileAnh);
        }
    }
}