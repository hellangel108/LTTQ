using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;
namespace Stelia_DAL
{
    public class DAL_NhanVien : DAL_connect
    {
       
        public DataTable getNhanVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NHANVIEN", connect);
            DataTable dtNhanvien = new DataTable();
            da.Fill(dtNhanvien);
            return dtNhanvien;
        }


        public bool themNhanVien(DTO_NhanVien tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();

             
                string SQL = string.Format("INSERT INTO NHANVIEN(MANV, HOTEN, NGSINH, CHUCVU, NGAYVL, GIOITINH, LUONG, SLHD, DOANHTHU) " +
                                           "VALUES ('{0}', N'{1}', '{2}',N'{3}', '{4}', N'{5}', {6}, {7}, {8} )",
                                            tv.MANV, tv.HOTEN, tv.NGSINH, tv.CHUCVU, tv.NGAYVL, tv.GIOITINH, tv.LUONG, tv.SLHD, tv.DOANHTHU);// DỮ LIỆU NHẬP VÀO

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

       
        public bool suaNhanVien(DTO_NhanVien tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE NHANVIEN " +
                                           "SET HOTEN = N'{1}', NGSINH = '{2}', CHUCVU = N'{3}', NGAYVL='{4}', GIOITINH = N'{5}', LUONG = {6}, SLHD = {7}, DOANHTHU={8} " +
                                           "WHERE MANV = '{0}'",
                                          tv.MANV, tv.HOTEN, tv.NGSINH, tv.CHUCVU, tv.NGAYVL, tv.GIOITINH, tv.LUONG, tv.SLHD, tv.DOANHTHU);

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

       
        public bool xoaNhanVien(string MANV)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM NHANVIEN WHERE MANV = '{0}' ", MANV);

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
        public DataTable timKiemNhanVien(string name)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NHANVIEN " +
                                                   "WHERE MANV LIKE '%" + name + "%' OR HOTEN LIKE N'%" + name + "%'", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable getTop10NhanVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(10) HOTEN FROM NHANVIEN " +
                                                   "ORDER BY NGAYVL DESC", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable getTop3_DoanhThuNhanVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(3) HOTEN FROM NHANVIEN " +
                                                   "ORDER BY DOANHTHU DESC", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
    }
}