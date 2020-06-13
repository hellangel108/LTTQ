using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_CTHD : DAL_connect
    {

        public DataTable getCTHD()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CTHD", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }


        public bool themCTHD(DTO_CTHoaDon tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO CTHD(MAHD,MASP,SOLUONG,GIATIEN) " +
                                           "VALUES ('{0}', '{1}', {2} , {3} )",
                                            tv.MAHD,tv.MASP,tv.SOLUONG,tv.GIATIEN);// DỮ LIỆU NHẬP VÀO

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, connect);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                connect.Close();
            }

            return false;
        }


        public bool suaCTHD(DTO_CTHoaDon tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE CTHD " +
                                           "SET MASP = '{1}', SOLUONG = {2}, GIATIEN = {3} " +
                                           "WHERE MAHD ='{0}' ",
                                          tv.MAHD, tv.MASP, tv.SOLUONG, tv.GIATIEN);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, connect);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                connect.Close();
            }

            return false;
        }


        public bool xoaCTHD(string MAHD,string MASP)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM CTHD WHERE MAHD = '{0}' AND MASP = '{1}' ", MAHD,MASP);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, connect);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                connect.Close();
            }

            return false;
        }
        public DataTable getTop5SPTrongNgay(string dt)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(5) sp.MASP, sp.TENSP, SUM(ct.GIATIEN) AS DoanhThu " +
                                                   "FROM(HOADON hd JOIN CTHD ct ON hd.MAHD = ct.MAHD) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE hd.NGHD = '" + dt + "' " +
                                                   "GROUP BY sp.MASP, sp.TENSP " +
                                                   "ORDER BY DoanhThu DESC ", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }
        public DataTable getTop10SPTheoNgay()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(10) sp.MASP, sp.TENSP, SUM(ct.GIATIEN) AS DoanhThu " +
                                                   "FROM(HOADON hd JOIN CTHD ct ON hd.MAHD = ct.MAHD) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE hd.NGHD = '"+ DateTime.Today.ToString("yyyy-MM-dd") + "' " +
                                                   "GROUP BY sp.MASP, sp.TENSP " +
                                                   "ORDER BY DoanhThu DESC ", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }
        public DataTable getTop10SPTheoTuan()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(10) sp.MASP, sp.TENSP, SUM(ct.GIATIEN) AS DoanhThu " +
                                                   "FROM(HOADON hd JOIN CTHD ct ON hd.MAHD = ct.MAHD) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE hd.NGHD BETWEEN '" + DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") + "' AND '" + DateTime.Today.ToString("yyyy-MM-dd") + "'" +
                                                   "GROUP BY sp.MASP, sp.TENSP " +
                                                   "ORDER BY DoanhThu DESC ", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }
        public DataTable getTop10SPTheoThang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(10) sp.MASP, sp.TENSP, SUM(ct.GIATIEN) AS DoanhThu " +
                                                   "FROM(HOADON hd JOIN CTHD ct ON hd.MAHD = ct.MAHD) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE MONTH(hd.NGHD) = MONTH('"+ DateTime.Today.ToString("yyyy-MM-dd") +"') " +
                                                   "AND   YEAR(hd.NGHD) = YEAR('"+ DateTime.Today.ToString("yyyy-MM-dd") +"') " +
                                                   "GROUP BY sp.MASP, sp.TENSP " +
                                                   "ORDER BY DoanhThu DESC ", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }
        public DataTable getTop10SPTheoNgay_SL()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(10) sp.MASP, sp.TENSP, SUM(ct.SOLUONG) AS SL " +
                                                   "FROM(HOADON hd JOIN CTHD ct ON hd.MAHD = ct.MAHD) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE hd.NGHD = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' " +
                                                   "GROUP BY sp.MASP, sp.TENSP " +
                                                   "ORDER BY SL DESC ", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }
        public DataTable getTop10SPTheoTuan_SL()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(10) sp.MASP, sp.TENSP,SUM(ct.SOLUONG) AS SL " +
                                                   "FROM(HOADON hd JOIN CTHD ct ON hd.MAHD = ct.MAHD) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE hd.NGHD BETWEEN '" + DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") + "' AND '"+ DateTime.Today.ToString("yyyy-MM-dd") +"'" +
                                                   "GROUP BY sp.MASP, sp.TENSP " +
                                                   "ORDER BY SL DESC ", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }
        public DataTable getTop10SPTheoThang_SL()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(10) sp.MASP, sp.TENSP, SUM(ct.SOLUONG) AS SL " +
                                                   "FROM(HOADON hd JOIN CTHD ct ON hd.MAHD = ct.MAHD) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE MONTH(hd.NGHD) = MONTH('" + DateTime.Today.ToString("yyyy-MM-dd") + "') " +
                                                   "AND   YEAR(hd.NGHD) = YEAR('" + DateTime.Today.ToString("yyyy-MM-dd") + "') " +
                                                   "GROUP BY sp.MASP, sp.TENSP " +
                                                   "ORDER BY SL DESC ", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }
        public DataTable InHoaDon(string mahd)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT hd.*, sp.TenSP AS TenSP, ct.SOLUONG AS SOLUONG, ct.GIATIEN AS GIATIEN, ct.SOLUONG * ct.GIATIEN AS TONGTIENHANG, kh.HOTEN AS TENKH, nv.HOTEN AS TENNV " +
                                                               "FROM (((HOADON hd JOIN CTHD ct ON hd.MAHD = ct.MAHD) JOIN SANPHAM sp ON ct.MASP = sp.MASP) LEFT JOIN NHANVIEN nv ON nv.MANV = HD.MANV) LEFT JOIN KHACHHANG kh ON kh.MAKH = hd.MAKH " +
                                                               "WHERE hd.MAHD LIKE '"+mahd+"'", connect);
            DataTable dtCTHD = new DataTable();
            da.Fill(dtCTHD);
            return dtCTHD;
        }
    }
}