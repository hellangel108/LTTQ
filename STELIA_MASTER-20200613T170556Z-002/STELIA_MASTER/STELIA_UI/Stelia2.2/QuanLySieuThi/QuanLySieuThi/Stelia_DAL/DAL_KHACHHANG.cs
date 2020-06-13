using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;
using System.Windows.Forms;

namespace Stelia_DAL
{
    public class DAL_KHACHHANG : DAL_connect
    {

        public DataTable getKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG", connect);
            DataTable dtKhachHang = new DataTable();
            da.Fill(dtKhachHang);
            return dtKhachHang;
        }


        public bool themKhachHang(DTO_KhachHang tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO KHACHHANG(MAKH, HOTEN, NGSINH, DIACHI, NGDK, GIOITINH, LOAIKH, DIEMTL) " +
                                           "VALUES ('{0}', N'{1}', '{2}', N'{3}', '{4}', N'{5}', N'{6}',{7} ) ",
                                            tv.MAKH, tv.HOTEN, tv.NGSINH, tv.DIACHI, tv.NGDK, tv.GIOITINH, tv.LOAIKH, tv.DIEMTL); // DỮ LIỆU NHẬP VÀO
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


        public bool suaKhachHang(DTO_KhachHang tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE KHACHHANG " +
                                           "SET HOTEN= N'{1}' ,NGSINH='{2}' ,DIACHI= N'{3}' ,NGDK='{4}' ,GIOITINH=N'{5}',LOAIKH=N'{6}',DIEMTL={7} " +
                                           "WHERE MAKH = '{0}'",
                                           tv.MAKH, tv.HOTEN, tv.NGSINH, tv.DIACHI, tv.NGDK, tv.GIOITINH, tv.LOAIKH, tv.DIEMTL);
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


        public bool xoaKhachHang(string MAKH)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM KHACHHANG WHERE MAKH = '{0}'", MAKH);

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
        public DataTable timKiemNhanhKhachHang(string name)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MAKH, HOTEN, LOAIKH FROM KHACHHANG " +
                                                   " WHERE MAKH LIKE '%" + name + "%' OR HOTEN LIKE N'%" + name + "%'", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable timKiemKhachHang(string name)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG " +
                                                   " WHERE MAKH LIKE '%"+ name + "%' OR HOTEN LIKE N'%" + name + "%'", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable getTop15KhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(15) HOTEN FROM KHACHHANG " +
                                                   "ORDER BY NGDK DESC", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
    }
}