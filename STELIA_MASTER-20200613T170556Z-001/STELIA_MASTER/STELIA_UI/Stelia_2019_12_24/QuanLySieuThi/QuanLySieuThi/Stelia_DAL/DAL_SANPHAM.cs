using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_SANPHAM : DAL_connect
    {

        public DataTable getSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SANPHAM", connect);
            DataTable dtSanPham = new DataTable();
            da.Fill(dtSanPham);
            return dtSanPham;
        }


        public bool themSanPham(DTO_SanPham tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO SANPHAM (MASP, TENSP, MANCC, DONGIA, LOINHUAN, SLUONG,TRANGTHAI) " +
                                           "VALUES ('{0}', N'{1}', '{2}',{3}, {4}, {5}, N'{6}' )",
                                           tv.MASP, tv.TENSP, tv.MANCC, tv.DONGIA, tv.LOINHUAN, tv.SLUONG, tv.TRANGTHAI); // DỮ LIỆU NHẬP VÀO

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


        public bool suaSanPham(DTO_SanPham tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE SANPHAM " +
                                           "SET TENSP= N'{1}', MANCC='{2}',DONGIA= {3} , LOINHUAN={4} , SLUONG={5},TRANGTHAI= N'{6}' " +
                                           "WHERE MASP='{0}' ",
                                            tv.MASP, tv.TENSP, tv.MANCC, tv.DONGIA, tv.LOINHUAN, tv.SLUONG, tv.TRANGTHAI);

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


        public bool xoaSanPham(string MASP)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM SANPHAM WHERE MASP = '{0}' ", MASP);

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
        public DataTable timKiemSanPham(string name)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SANPHAM " +
                                                   "WHERE MASP LIKE '%" + name + "%' OR TENSP LIKE N'%" + name + "%'", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable getTop12SanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(12) sp.TENSP "+
                                                   "FROM SANPHAM sp JOIN CTPN ct ON sp.MASP = ct.MASP JOIN PHIEUNHAP pn ON ct.MAPN = pn.MAPN "+
                                                   "ORDER BY pn.NGNHAP DESC", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable getSanPham_NCC(string name)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TENSP FROM SANPHAM " +
                                                   "WHERE MANCC LIKE '" + name + "'", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }

    }
}