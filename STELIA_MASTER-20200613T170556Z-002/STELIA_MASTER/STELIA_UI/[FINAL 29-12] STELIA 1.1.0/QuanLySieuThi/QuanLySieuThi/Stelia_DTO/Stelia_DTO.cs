using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelia_DTO
{
    public class DTO_NhanVien
    {
        public string MANV, HOTEN, NGSINH, CHUCVU, NGAYVL, GIOITINH, LUONG, SLHD, DOANHTHU;
        public DTO_NhanVien()
        {

        }
        public DTO_NhanVien(string manv, string hoten, string ngsinh, string chucvu, string ngayvl, string gioitinh, string luong, string slhd, string doanhthu)
        {
            this.MANV = manv;
            this.HOTEN = hoten;
            this.NGSINH = ngsinh;
            this.CHUCVU = chucvu;
            this.NGAYVL = ngayvl;
            this.GIOITINH = gioitinh;
            this.LUONG = luong;
            this.SLHD = slhd;
            this.DOANHTHU = doanhthu;
        }
    }
    public class DTO_KhachHang
    {
        public string MAKH, HOTEN, NGSINH, DIACHI, NGDK, GIOITINH, LOAIKH, DIEMTL;
        public DTO_KhachHang() { }
        public DTO_KhachHang(string makh, string hoten, string ngsinh, string diachi, string ngdk, string gioitinh, string loaikh, string diemtl)
        {
            this.MAKH = makh;
            this.HOTEN = hoten;
            this.NGSINH = ngsinh;
            this.DIACHI = diachi;
            this.NGDK = ngdk;
            this.GIOITINH = gioitinh;
            this.LOAIKH = loaikh;
            this.DIEMTL = diemtl;
        }
    }
    public class DTO_NhaCungCap
    {
        public string MANCC, TENNCC, NGHT, DIACHI, SDT, MUCDOCC, TRANGTHAI;//MUCDOCC: MUC DO CUNG CAP
        public DTO_NhaCungCap() { }
        public DTO_NhaCungCap(string mancc, string tenncc, string nght, string diachi, string sdt, string mucdocc, string trangthai)
        {
            this.MANCC = mancc;
            this.TENNCC = tenncc;
            this.NGHT = nght;
            this.DIACHI = diachi;
            this.SDT = sdt;
            this.MUCDOCC = mucdocc;
            this.TRANGTHAI = trangthai;
        }
    }
    public class DTO_SanPham
    {
        public string MASP, TENSP, MANCC, DONGIA, LOINHUAN, SLUONG, TRANGTHAI;
        public DTO_SanPham() { }
        public DTO_SanPham(string masp, string tensp, string mancc, string dongia, string loinhuan, string sluong, string trangthai)
        {
            this.MASP = masp;
            this.TENSP = tensp;
            this.MANCC = mancc;
            this.DONGIA = dongia;
            this.LOINHUAN = loinhuan;
            this.SLUONG = sluong;
            this.TRANGTHAI = trangthai;
        }
    }
    public class DTO_HoaDon
    {
        public string MAHD, MANV, MAKH, NGHD, TONGTIENHANG, GIAMGIA, THANHTIEN;
        public DTO_HoaDon() { }
        public DTO_HoaDon(string mahd, string manv, string makh, string nghd, string tongtienhang, string giamgia, string thanhtien)
        {
            this.MAHD = mahd;
            this.MANV = manv;
            this.MAKH = makh;
            this.NGHD = nghd;
            this.TONGTIENHANG = tongtienhang;
            this.GIAMGIA = giamgia;
            this.THANHTIEN = thanhtien;
        }
    }
    public class DTO_CTHoaDon
    {
        public string MAHD, MASP, SOLUONG, GIATIEN;
        public DTO_CTHoaDon() { }
        public DTO_CTHoaDon(string mahd, string masp, string soluong, string giatien)
        {
            this.MAHD = mahd;
            this.MASP = masp;
            this.SOLUONG = soluong;
            this.GIATIEN = giatien;
        }
    }
    public class DTO_PhieuNhap
    {
        public string MAPN, MANCC, NGNHAP, TONGSL, TONGTIEN, GHICHU;
        public DTO_PhieuNhap() { }
        public DTO_PhieuNhap(string mapn, string mancc, string ngnhap, string tongsl, string tongtien, string ghichu)
        {
            this.MAPN = mapn;
            this.MANCC = mancc;
            this.NGNHAP = ngnhap;
            this.TONGSL = tongsl;
            this.TONGTIEN = tongtien;
            this.GHICHU = ghichu;
        }
    }
    public class DTO_CTPhieuNhap
    {
        public string MAPN, MASP, SOLUONG, THANHTIEN;
        public DTO_CTPhieuNhap() { }
        public DTO_CTPhieuNhap(string mapn, string masp, string soluong, string thanhtien)
        {
            this.MAPN = mapn;
            this.MASP = masp;
            this.SOLUONG = soluong;
            this.THANHTIEN = thanhtien;
        }
    }
    public class DTO_PhieuTra
    {
        public string MAPT, MANCC, NGNHAP, TONGSL, TONGTIEN, GHICHU;
        public DTO_PhieuTra() { }
        public DTO_PhieuTra(string mapt, string mancc, string ngnhap, string tongsl, string tongtien, string ghichu)
        {
            this.MAPT = mapt;
            this.MANCC = mancc;
            this.NGNHAP = ngnhap;
            this.TONGSL = tongsl;
            this.TONGTIEN = tongtien;
            this.GHICHU = ghichu;
        }
    }
    public class DTO_CTPhieuTra
    {
        public string MAPT, MASP, SOLUONG, THANHTIEN;
        public DTO_CTPhieuTra() { }
        public DTO_CTPhieuTra(string mapt, string masp, string soluong, string thanhtien)
        {
            this.MAPT = mapt;
            this.MASP = masp;
            this.SOLUONG = soluong;
            this.THANHTIEN = thanhtien;
        }
    }

    public class DTO_PTTQ
    {
        public string MAPTTQ, MAKH, MASP, SOLUONG, THANHTIEN, MANV,NGTRA;
        public DTO_PTTQ() { }
        public DTO_PTTQ(string mapttq, string makh, string manv, string masp, string soluong, string thanhtien,string ngaytra)
        {
            this.MAPTTQ = mapttq;
            this.MAKH = makh;
            this.MASP = masp;
            this.MANV = manv;
            this.SOLUONG = soluong;
            this.THANHTIEN = thanhtien;
            this.NGTRA = ngaytra;
        }
    }

    public class DTO_DiemDanh
    {
        public string MANV, NGAYDD;
        public DTO_DiemDanh() { }
        public DTO_DiemDanh(string manv, string ngaydd)
        {
            this.MANV = manv;
            this.NGAYDD = ngaydd;
        }
    }
    public class DTO_TaiKhoan
    {
        public string TENDN, MATKHAU;
        public DTO_TaiKhoan() { }
        public DTO_TaiKhoan(string tk, string mk)
        {
            this.TENDN = tk;
            this.MATKHAU = mk;
        }
    }
}
