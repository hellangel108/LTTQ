using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stelia_DTO;
using Stelia_BUS;

namespace Stelia
{
    class CheckThongTin
    {
        static public string check_Nhap(DTO_NhanVien nv)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhanVien[] nhanvien = bus.search_NhanVien(nv.MANV);
            if (nhanvien[0].MANV == nv.MANV)
                error += "Mã nhân viên này đã tồn tại";
            if (nv.GIOITINH != "Nữ" && nv.GIOITINH != "Nam" && nv.GIOITINH != "Khác")
                error += "\n" + "Giới tính chỉ được {Nam, Nữ, Khác}";
            return error;
        }

        static public string check_Nhap(DTO_KhachHang kh)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_KhachHang[] khachhang = bus.search_KhachHang(kh.MAKH);
            if (khachhang[0].MAKH == kh.MAKH)
                error += "Mã khách hàng này đã tồn tại";
            if (kh.GIOITINH != "Nữ" && kh.GIOITINH != "Nam" && kh.GIOITINH != "Khác")
                error += "\n" + "Giới tính chỉ được {Nam, Nữ, Khác}";
            return error;
        }

        static public string check_Nhap(DTO_SanPham sp)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_SanPham[] sanpham = bus.search_SANPHAM(sp.MASP);
            if (sanpham[0].MASP == sp.MASP)
                error += "Mã sản phẩm này đã tồn tại";
            if (Double.Parse(sanpham[0].DONGIA) < 0)
                error += "\n" + "Giá sản phẩm phải > 0 ";
            if (Double.Parse(sanpham[0].SLUONG) < 0)
                error += "\n" + "Số lượng phải > 0 ";
            return error;
        }

        static public string check_Nhap(DTO_PhieuNhap pn)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_PhieuNhap[] phieunhap = bus.search_PhieuNhap(pn.MAPN);
            if (phieunhap[0].MAPN == pn.MAPN)
                error += "Phiếu nhập này đã tồn tại";
            return error;
        }

        static public string check_Nhap(DTO_PhieuTra pt)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_PhieuTra[] phieutra = bus.search_PhieuTra(pt.MAPT);
            if (phieutra[0].MAPT == pt.MAPT)
                error += "Phiếu trả này đã tồn tại";
            return error;
        }

        static public string check_Nhap(DTO_NhaCungCap ncc)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhaCungCap[] nhacc = bus.search_NhaCungCap(ncc.MANCC);
            if (nhacc[0].MANCC == ncc.MANCC)
                error += "Mã nhà cung cấp này đã tồn tại";
            return error;
        }

        static public string check_Nhap(DTO_HoaDon hd)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_HoaDon[] hoadon = bus.searchHoaDon(hd.MAHD);
            if (hoadon[0].MAHD == hd.MAHD)
                error += "Mã hóa đơn này đã tồn tại";
            return error;
        }

        static public string check_Nhap(DTO_PTTQ pttq)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_PTTQ[] phieutratq = bus.search_PhieuTraTaiQuay(pttq.MAPTTQ);
            if (phieutratq[0].MAPTTQ == pttq.MAPTTQ)
                error += "Mã phiếu trả tại quầy này đã tồn tại";
            return error;
        }
    }
}
