﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stelia_DAL;
using Stelia_DTO;
using System.Windows.Forms;

namespace Stelia_BUS
{
    public class Stelia_BUS
    {
        DAL_KHACHHANG kh = new DAL_KHACHHANG();
        DAL_NhanVien nv = new DAL_NhanVien();
        DAL_NHACUNGCAP ncc = new DAL_NHACUNGCAP();
        DAL_SANPHAM sp = new DAL_SANPHAM();
        DAL_HOADON hd = new DAL_HOADON();
        DAL_CTHD cthd = new DAL_CTHD();
        DAL_PHIEUNHAP pn = new DAL_PHIEUNHAP();
        DAL_CTPN ctpn = new DAL_CTPN();
        DAL_PHIEUTRA pt = new DAL_PHIEUTRA();
        DAL_CTPT ctpt = new DAL_CTPT();
        DAL_PTTQ pttq = new DAL_PTTQ();
        DAL_DIEMDANH dd = new DAL_DIEMDANH();
        DAL_TAIKHOAN tk = new DAL_TAIKHOAN();

        public string getThongTinNV(int column, int row)
        {
            DataTable infotable = nv.getNhanVien();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }

        public string getThongTinKH(int column, int row)
        {
            DataTable infotable = kh.getKhachHang();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }

        public string getThongTinNCC(int column, int row)
        {
            DataTable infotable = ncc.getNhaCungCap();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinSP(int column, int row)
        {
            DataTable infotable = sp.getSanPham();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinHD(int column, int row)
        {
            DataTable infotable = hd.getHoaDon();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinCTHD(int column, int row)
        {
            DataTable infotable = cthd.getCTHD();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinPN(int column, int row)
        {
            DataTable infotable = pn.getPhieuNhap();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinCTPN(int column, int row)
        {
            DataTable infotable = ctpn.getCTPN();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinPT(int column, int row)
        {
            DataTable infotable = pt.getPhieuTra();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinCTPT(int column, int row)
        {
            DataTable infotable = ctpt.getCTPT();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinPTTQ(int column, int row)
        {
            DataTable infotable = pttq.getPTTQ();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinDiemDanh(int column, int row)
        {
            DataTable infotable = dd.getDiemDanh();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }
        public string getThongTinTaiKhoan(int column, int row)
        {
            DataTable infotable = tk.getTaiKhoan();
            if (column >= infotable.Columns.Count || row >= infotable.Rows.Count)
                return "";
            return infotable.Rows[row].ItemArray[column].ToString();
        }

        public DataTable getDataTable(string tablename)
        {
            switch (tablename)
            {
                case "NHANVIEN":
                    return nv.getNhanVien();
                case "KHACHHANG":
                    return kh.getKhachHang();
                case "NHACUNGCAP":
                    return ncc.getNhaCungCap();
                case "SANPHAM":
                    return sp.getSanPham();
                case "HOADON":
                    return hd.getHoaDon();
                case "CTHD":
                    return cthd.getCTHD();
                case "PHIEUNHAP":
                    return pn.getPhieuNhap();
                case "CTPN":
                    return ctpn.getCTPN();
                case "PHIEUTRA:":
                    return pt.getPhieuTra();
                case "CTPT":
                    return ctpt.getCTPT();
                case "PTTQ":
                    return pttq.getPTTQ();
                case "DIEMDANH":
                    return dd.getDiemDanh();
                case "TAIKHOAN":
                    return tk.getTaiKhoan();
                default:
                    return null;
            }
        }
        #region Them du lieu
        public bool themData(DTO_NhanVien tv)
        {
            return nv.themNhanVien(tv);
        }
        public bool themData(DTO_KhachHang tv)
        {
            return kh.themKhachHang(tv);
        }
        public bool themData(DTO_NhaCungCap tv)
        {
            return ncc.themNhaCungCap(tv);
        }
        public bool themData(DTO_SanPham tv)
        {
            return sp.themSanPham(tv);
        }
        public bool themData(DTO_HoaDon tv)
        {
            return hd.themHoaDon(tv);
        }
        public bool themData(DTO_CTHoaDon tv)
        {
            return cthd.themCTHD(tv);
        }
        public bool themData(DTO_PhieuNhap tv)
        {
            return pn.themPhieuNhap(tv);
        }
        public bool themData(DTO_CTPhieuNhap tv)
        {
            return ctpn.themCTPN(tv);
        }
        public bool themData(DTO_PhieuTra tv)
        {
            return pt.themPhieuTra(tv);
        }
        public bool themData(DTO_CTPhieuTra tv)
        {
            return ctpt.themCTPT(tv);
        }
        public bool themData(DTO_PTTQ tv)
        {
            return pttq.themPTTQ(tv);
        }

        public bool themData(DTO_DiemDanh tv)
        {
            return dd.themDiemDanh(tv);
        }
        public bool themData(DTO_TaiKhoan tv)
        {
            return tk.themTaiKhoan(tv);
        }
        #endregion
        #region Sua du lieu
        public bool suaData(DTO_NhanVien tv)
        {
            return nv.suaNhanVien(tv);
        }
        public bool suaData(DTO_KhachHang tv)
        {
            return kh.suaKhachHang(tv);
        }
        public bool suaData(DTO_NhaCungCap tv)
        {
            return ncc.suaNhaCungCap(tv);
        }
        public bool suaData(DTO_SanPham tv)
        {
            return sp.suaSanPham(tv);
        }
        public bool suaData(DTO_HoaDon tv)
        {
            return hd.suaHoaDon(tv);
        }
        public bool suaData(DTO_CTHoaDon tv)
        {
            return cthd.suaCTHD(tv);
        }
        public bool suaData(DTO_PhieuNhap tv)
        {
            return pn.suaPhieuNhap(tv);
        }
        public bool suaData(DTO_CTPhieuNhap tv)
        {
            return ctpn.suaCTPN(tv);
        }
        public bool suaData(DTO_PhieuTra tv)
        {
            return pt.suaPhieuTra(tv);
        }
        public bool suaData(DTO_CTPhieuTra tv)
        {
            return ctpt.suaCTPT(tv);
        }
        public bool suaData(DTO_PTTQ tv)
        {
            return pttq.suaPTTQ(tv);
        }
        public bool suaData(DTO_DiemDanh tv)
        {
            return dd.suaDiemDanh(tv);
        }
        public bool suaData(DTO_TaiKhoan tv)
        {
            return tk.suaTaiKhoan(tv);
        }
        #endregion
        #region Xoa du lieu
        public bool xoaNhanVien(string manv)
        {
            return nv.xoaNhanVien(manv);
        }
        public bool xoaKhachHang(string makh)
        {
            return kh.xoaKhachHang(makh);
        }
        public bool xoaNhaCungCap(string mancc)
        {
            return ncc.xoaNhaCungCap(mancc);
        }
        public bool xoaSanPham(string masp)
        {
            return sp.xoaSanPham(masp);
        }
        public bool xoaHoaDon(string mahd)
        {
            return hd.xoaHoaDon(mahd);
        }
        public bool xoaCTHD(string mahd, string masp)
        {
            return cthd.xoaCTHD(mahd, masp);
        }
        public bool xoaPhieuNhap(string mapn)
        {
            return pn.xoaPhieuNhap(mapn);
        }
        public bool xoaCTPN(string mapn, string masp)
        {
            return ctpn.xoaCTPN(mapn, masp);
        }
        public bool xoaPhieuTra(string mapt)
        {
            return pt.xoaPhieuTra(mapt);
        }
        public bool xoaCTPT(string mapt, string masp)
        {
            return ctpt.xoaCTPT(mapt, masp);
        }
        public bool xoaPTTQ(string mapttq)
        {
            return pttq.xoaPTTQ(mapttq);
        }
        public bool xoaDiemDanh(string manv, string ngaydd)
        {
            return dd.xoaDiemDanh(manv, ngaydd);
        }
        public bool xoaTaiKhoan(string username)
        {
            return tk.xoaTaiKhoan(username);
        }
        #endregion
        #region User Control Tong quan
        public string doanhThuTheoNam(string nm)
        {
            DataTable infotable = hd.doanhThuTheoNam(nm);
            if (infotable.Rows.Count == 0)
            {
                return "0";
            }
            return ((long)double.Parse(infotable.Rows[0].ItemArray[0].ToString())).ToString("0,000");
        }
        public string doanhThuTheoThang(string th, string nm)
        {
            DataTable infotable = hd.doanhThuTheoThang(th,nm);
            if (infotable.Rows.Count == 0)
            {
                return "0";
            }
            return ((long)double.Parse(infotable.Rows[0].ItemArray[0].ToString())).ToString("0,000");
        }
        public string doanhThuTheoNgay(string ngay)
        {
            DataTable infotable = hd.doanhThuTheoNgay(ngay);
            if(infotable.Rows.Count == 0)
            {
                return "0";
            }
            return ((long)double.Parse(infotable.Rows[0].ItemArray[0].ToString())).ToString("0,000");
        }
        public string soLuongTheoNgay(string ngay)
        {
            DataTable infotable = hd.soLuongTheoNgay(ngay);
            if (infotable.Rows.Count == 0)
            {
                return "0";
            }
            return ((long)double.Parse(infotable.Rows[0].ItemArray[0].ToString())).ToString();
        }
        public int tinhSLTraHangTQ()
        {
            DataTable infotable = getDataTable("PTTQ");
            return infotable.Rows.Count;
        }
        public string[] top10_maSP_BanChayTheoDoanhThu_TheoNgay()
        {
            string[] rep = new string[10];
            int i = 0;
            DataTable infotable = cthd.getTop10SPTheoNgay();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 10)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        public string[] top10_maSP_BanChayTheoDoanhThu_TheoTuan()
        {
            string[] rep = new string[10];
            int i = 0;
            DataTable infotable = cthd.getTop10SPTheoTuan();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 10)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        public string[] top10_maSP_BanChayTheoDoanhThu_TheoThang()
        {
            string[] rep = new string[10];
            int i = 0;
            DataTable infotable = cthd.getTop10SPTheoThang();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 10)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        public string[] top10_maSP_BanChayTheoSoLuong_TheoNgay()
        {
            string[] rep = new string[10];
            int i = 0;
            DataTable infotable = cthd.getTop10SPTheoNgay_SL();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 10)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        public string[] top10_maSP_BanChayTheooSoLuong_TheoTuan()
        {
            string[] rep = new string[10];
            int i = 0;
            DataTable infotable = cthd.getTop10SPTheoTuan_SL();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 10)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        public string[] top10_maSP_BanChayTheooSoLuong_TheoThang()
        {
            string[] rep = new string[10];
            int i = 0;
            DataTable infotable = cthd.getTop10SPTheoThang_SL();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 10)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        public string[] top10_MaNV_DiemDanh()
        {
            string[] rep = new string[10];
            int i = 0;
            DataTable infotable = dd.getTop10DiemDanh();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 10)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        #endregion
        #region User Control Khach Hang
        public DataTable timKiemNhanh_KhachHang(string st)
        {
            return kh.timKiemNhanhKhachHang(st);
        }
        public DTO_KhachHang[] search_KhachHang(string st)
        {
            int i = 0;
            DataTable infotable = kh.timKiemKhachHang(st);
            if (infotable.Rows.Count == 0)
            {
                DTO_KhachHang[] temp = new DTO_KhachHang[1];
                temp[0] = new DTO_KhachHang(getThongTinKH(0, 0), getThongTinKH(1, 0), getThongTinKH(2, 0), getThongTinKH(3, 0), getThongTinKH(4, 0), getThongTinKH(5, 0), getThongTinKH(6, 0), getThongTinKH(7, 0));
                return temp;
            }
            DTO_KhachHang[] dtokh = new DTO_KhachHang[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[8];
                for (int j = 0; j <= 7; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtokh[i] = new DTO_KhachHang(str[0], str[1], str[2], str[3], str[4], str[5], str[6], str[7]);
                i++;
            }
            return dtokh;
        }
        public string[] Top15_KhachHang()
        {
            string[] rep = new string[15];
            int i = 0;
            DataTable infotable = kh.getTop15KhachHang();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 15)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        #endregion
        #region User Control Nhan Vien
        public DataTable timKiemNhanh_NhanVien(string st)
        {
            return nv.timKiemNhanhNhanVien(st);
        }
        public DTO_NhanVien[] search_NhanVien(string st)
        {
            int i = 0;
            DataTable infotable = nv.timKiemNhanVien(st);
            if (infotable.Rows.Count == 0)
            {
                DTO_NhanVien[] temp = new DTO_NhanVien[1];
                temp[0] = new DTO_NhanVien(getThongTinNV(0, 0), getThongTinNV(1, 0), getThongTinNV(2, 0), getThongTinNV(3, 0), getThongTinNV(4, 0), getThongTinNV(5, 0), getThongTinNV(6, 0), getThongTinNV(7, 0), getThongTinNV(8, 0));
                return temp;
            }
            DTO_NhanVien[] dtonv = new DTO_NhanVien[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[9];
                for (int j = 0; j <= 8; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtonv[i] = new DTO_NhanVien(str[0], str[1], str[2], str[3], str[4], str[5], str[6], str[7], str[8]);
                i++;
            }
            return dtonv;
        }
        public string[] Top10_NhanVien()
        {
            string[] rep = new string[10];
            int i = 0;
            DataTable infotable = nv.getTop10NhanVien();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 10)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        public string[] Top3_NhanVieN()
        {
            string[] rep = new string[3];
            rep[0] = "";
            rep[1] = "";
            rep[2] = "";
            int i = 0;
            DataTable infotable = nv.getTop3_DoanhThuNhanVien();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 3)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        #endregion
        #region User Control Hang Hoa
        public DataTable search_sanpham_ncc(string name, string mancc)
        {
            DataTable infotable = sp.getSanPham_NCC(name, mancc);
            return infotable;
        }
        public DataTable timkiemSanPham(string str)
        {
            return sp.timKiemNhanhSanPham(str);
        }
        public DTO_SanPham[] search_SANPHAM(string st)
        {
            int i = 0;
            DataTable infotable = sp.timKiemSanPham(st);
            if (infotable.Rows.Count == 0)
            {
                DTO_SanPham[] temp = new DTO_SanPham[1];
                temp[0] = new DTO_SanPham(getThongTinSP(0, 0), getThongTinSP(1, 0), getThongTinSP(2, 0), getThongTinSP(3, 0), getThongTinSP(4, 0), getThongTinSP(5, 0), getThongTinSP(6, 0));
                return temp;
            }
            DTO_SanPham[] dtosp = new DTO_SanPham[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[9];
                for (int j = 0; j <= 6; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtosp[i] = new DTO_SanPham(str[0], str[1], str[2], str[3], str[4], str[5], str[6]);
                i++;
            }
            return dtosp;
        }
        public string[] Top12_SanPham_VuaNhap()
        {
            string[] rep = new string[12];
            int i = 0;
            DataTable infotable = sp.getTop12SanPham();
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < 12)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        #endregion
        #region User Control NCC
        public DataTable list_SanPham_NCC(string mancc)
        {
            DataTable infotable = sp.getSanPham_NCC(mancc);
            return infotable;
        }

        public string[] Top3_NCC()
        {
            int i = 0; ;
            DataTable infotable = ncc.getTop3NhaCungCap();
            int count = infotable.Rows.Count;
            string[] rep = new string[3];
            rep[0] = "";
            rep[1] = "";
            rep[2] = "";
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < count)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }

        public string getTenNCC(string name)
        {
            
            DataTable infotable = ncc.getTenNCC(name);
            int count = infotable.Rows.Count;
            return infotable.Rows[0][1].ToString();
        }
        public DTO_NhaCungCap[] search_NhaCungCap(string st)
        {
            int i = 0;
            DataTable infotable = ncc.timKiemNhaCungCap(st);
            if (infotable.Rows.Count == 0)
            {
                DTO_NhaCungCap[] temp = new DTO_NhaCungCap[1];
                temp[0] = new DTO_NhaCungCap(getThongTinNCC(0, 0), getThongTinNCC(1, 0), getThongTinNCC(2, 0), getThongTinNCC(3, 0), getThongTinNCC(4, 0), getThongTinNCC(5, 0), getThongTinNCC(6, 0));
                return temp;
            }
            DTO_NhaCungCap[] dtoncc = new DTO_NhaCungCap[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[9];
                for (int j = 0; j <= 6; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtoncc[i] = new DTO_NhaCungCap(str[0], str[1], str[2], str[3], str[4], str[5], str[6]);
                i++;
            }
            return dtoncc;
        }
        public DataTable timkiem_NhaCungCap(string st)
        {
            return ncc.timKiemNhaCungCap(st);
        }

        #endregion
        #region User Control Tra Hang Tai Quay
        public string[] list_SanPham_TraTaiQuay()
        {
            int i = 0; ;
            DataTable infotable = pttq.getSP_PTTQ();
            int count = infotable.Rows.Count;
            string[] rep = new string[count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                if (i < count)
                {
                    rep[i] = row[0].ToString();
                    i++;
                }
            }
            return rep;
        }
        public int SoTienTraTaiQuay()
        {

            DataTable infotable = pttq.getTongTienTraTaiQuay_TrongThang();
            return Convert.ToInt32(infotable.Rows[0].ItemArray[0].ToString());
        }
        public bool TangSoLuong_TheoSanPham(string MaSP, int SL)
        {
            return pttq.updateSL_SP(MaSP, SL);
        }
        #endregion
        #region User Control Phieu Nhap


        public DTO_PhieuNhap[] search_PhieuNhap(string NgLap)
        {
            int i = 0;
            DataTable infotable = pn.timKiemPhieuNhap(NgLap);
            if (infotable.Rows.Count == 0)
            {
                DTO_PhieuNhap[] temp = new DTO_PhieuNhap[1];
                temp[0] = new DTO_PhieuNhap(getThongTinPN(0, 0), getThongTinPN(1, 0), getThongTinPN(2, 0), getThongTinPN(3, 0), getThongTinPN(4, 0), getThongTinPN(5, 0));
                return temp;
            }
            DTO_PhieuNhap[] dtopn = new DTO_PhieuNhap[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[8];
                for (int j = 0; j <= 5; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtopn[i] = new DTO_PhieuNhap(str[0], str[1], str[2], str[3], str[4], str[5]);
                i++;
            }
            return dtopn;
        }
        public DTO_PhieuNhap[] timkiem_PhieuNhap(string mapn)
        {
            int i = 0;
            DataTable infotable = pn.timKiemTheoMaPhieuNhap(mapn);
            if (infotable.Rows.Count == 0)
            {
                DTO_PhieuNhap[] temp = new DTO_PhieuNhap[1];
                temp[0] = new DTO_PhieuNhap(getThongTinPN(0, 0), getThongTinPN(1, 0), getThongTinPN(2, 0), getThongTinPN(3, 0), getThongTinPN(4, 0), getThongTinPN(5, 0));
                return temp;
            }
            DTO_PhieuNhap[] dtopn = new DTO_PhieuNhap[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[8];
                for (int j = 0; j <= 5; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtopn[i] = new DTO_PhieuNhap(str[0], str[1], str[2], str[3], str[4], str[5]);
                i++;
            }
            return dtopn;
        }
        public DataTable timkiemnhanh_PhieuNhap(string mapn, string mancc)
        {
            return pn.timKiemChiTiet(mapn, mancc);
        }
        public DataTable timkiemTheoNgay_PhieuNhap(string ngpn)
        {
            return pn.timKiemPhieuNhap(ngpn);
        }
        #endregion
        #region User Control Phieu Tra
        public DTO_PhieuTra[] search_PhieuTra(string NgLap)
        {
            int i = 0;
            DataTable infotable = pt.timKiemPhieuTra(NgLap);
            if (infotable.Rows.Count == 0)
            {
                DTO_PhieuTra[] temp = new DTO_PhieuTra[1];
                temp[0] = new DTO_PhieuTra(getThongTinPT(0, 0), getThongTinPT(1, 0), getThongTinPT(2, 0), getThongTinPT(3, 0), getThongTinPT(4, 0), getThongTinPT(5, 0));
                return temp;
            }
            DTO_PhieuTra[] dtopt = new DTO_PhieuTra[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[8];
                for (int j = 0; j <= 5; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtopt[i] = new DTO_PhieuTra(str[0], str[1], str[2], str[3], str[4], str[5]);
                i++;
            }
            return dtopt;
        }
        public DTO_PhieuTra[] timkiem_PhieuTra(string mapt)
        {
            int i = 0;
            DataTable infotable = pt.timKiemtheoMaPhieuTra(mapt);
            if (infotable.Rows.Count == 0)
            {
                DTO_PhieuTra[] temp = new DTO_PhieuTra[1];
                temp[0] = new DTO_PhieuTra(getThongTinPT(0, 0), getThongTinPT(1, 0), getThongTinPT(2, 0), getThongTinPT(3, 0), getThongTinPT(4, 0), getThongTinPT(5, 0));
                return temp;
            }
            DTO_PhieuTra[] dtopt = new DTO_PhieuTra[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[8];
                for (int j = 0; j <= 5; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtopt[i] = new DTO_PhieuTra(str[0], str[1], str[2], str[3], str[4], str[5]);
                i++;
            }
            return dtopt;
        }
        public DataTable timkiemnhanh_PhieuTra(string mapt, string mancc)
        {
            return pt.timKiemChiTiet(mapt, mancc);
        }
        public DataTable timkiemTheoNgay_PhieuTra(string ngpt)
        {
            return pn.timKiemPhieuNhap(ngpt);
        }
        #endregion
        #region IN
        public DataTable InHoaDon(string mahd)
        {
            return cthd.InHoaDon(mahd);
        }
        public DataTable InPhieuNhap(string mapn)
        {
            return ctpn.InPhieuNhap(mapn);
        }
        public DataTable InPhieuTra(string mapt)
        {
            return ctpt.InPhieuTra(mapt);
        }
        #endregion
        #region Search
        public DTO_DiemDanh[] searchDiemDanh(string manv, string date)
        {
            int i = 0;
            DataTable infotable = dd.timKiemDiemDanh(manv,date);
            if (infotable.Rows.Count == 0)
            {
                DTO_DiemDanh[] temp = new DTO_DiemDanh[1];
                temp[0] = new DTO_DiemDanh(getThongTinHD(0, 0), getThongTinHD(1, 0));
                return temp;
            }
            DTO_DiemDanh[] dtodd = new DTO_DiemDanh[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[2];
                for (int j = 0; j <= 1; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtodd[i] = new DTO_DiemDanh(str[0], str[1]);
                i++;
            }
            return dtodd;
        }
        public DTO_HoaDon[] searchHoaDon(string st)
        {
            int i = 0;
            DataTable infotable = hd.timkiemHoaDon(st);
            if (infotable.Rows.Count == 0)
            {
                DTO_HoaDon[] temp = new DTO_HoaDon[1];
                temp[0] = new DTO_HoaDon(getThongTinHD(0, 0), getThongTinHD(1, 0), getThongTinHD(2, 0), getThongTinHD(3, 0), getThongTinHD(4, 0), getThongTinHD(5, 0), getThongTinHD(6, 0));
                return temp;
            }
            DTO_HoaDon[] dtohd = new DTO_HoaDon[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[8];
                for (int j = 0; j <= 7; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtohd[i] = new DTO_HoaDon(str[0], str[1], str[2], str[3], str[4], str[5], str[6]);
                i++;
            }
            return dtohd;
        }

        public DTO_PTTQ[] search_PhieuTraTaiQuay(string st)
        {
            int i = 0;
            DataTable infotable = pttq.timKiemPhieuTraTaiQuay(st);
            if (infotable.Rows.Count == 0)
            {
                DTO_PTTQ[] temp = new DTO_PTTQ[1];
                temp[0] = new DTO_PTTQ(getThongTinPTTQ(0, 0), getThongTinPTTQ(1, 0), getThongTinPTTQ(2, 0), getThongTinPTTQ(3, 0), getThongTinPTTQ(4, 0), getThongTinPTTQ(5, 0), getThongTinPTTQ(6, 0));
                return temp;
            }
            DTO_PTTQ[] dtopttq = new DTO_PTTQ[infotable.Rows.Count];
            DataRowCollection result = infotable.Rows;
            foreach (DataRow row in result)
            {
                string[] str = new string[8];
                for (int j = 0; j <= 7; j++)
                {
                    str[j] = row[j].ToString();
                }
                dtopttq[i] = new DTO_PTTQ(str[0], str[1], str[2], str[3], str[4], str[5], str[6]);
                i++;
            }
            return dtopttq;
        }
        #endregion
    }
}