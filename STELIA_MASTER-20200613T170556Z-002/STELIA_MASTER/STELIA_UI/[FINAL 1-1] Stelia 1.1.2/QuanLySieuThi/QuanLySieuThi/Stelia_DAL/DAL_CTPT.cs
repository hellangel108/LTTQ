using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_CTPT : DAL_connect
    {

        public DataTable getCTPT()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CTPT", connect);
            DataTable dtCTPT = new DataTable();
            da.Fill(dtCTPT);
            return dtCTPT;
        }


        public bool themCTPT(DTO_CTPhieuTra tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO CTPT(MAPT,MASP,SOLUONG,THANHTIEN) " +
                                           "VALUES ('{0}', '{1}', {2} , {3} )",
                                            tv.MAPT,tv.MASP,tv.SOLUONG,tv.THANHTIEN);// DỮ LIỆU NHẬP VÀO

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


        public bool suaCTPT(DTO_CTPhieuTra tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE CTPT " +
                                           "SET MASP = '{1}', SOLUONG = {2}, THANHTIEN = {3} " +
                                           "WHERE MAPT= '{0}' ",
                                          tv.MAPT, tv.MASP, tv.SOLUONG, tv.THANHTIEN);

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


        public bool xoaCTPT(string MAPT,string MASP)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM CTPT WHERE MAPT = '{0}' AND MASP = '{1}' ", MAPT,MASP);

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
        public DataTable InPhieuTra(string mapt)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT pt.*, ncc.TENNCC, sp.TENSP, ct.MASP, ct.SOLUONG, ct.THANHTIEN " +
                                                   "FROM ((PHIEUTRA pt JOIN CTPT ct ON pt.MAPT = ct.MAPT) JOIN NHACUNGCAP ncc ON pt.MANCC = ncc.MANCC) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE pt.MAPT LIKE '" + mapt + "' ", connect);
            DataTable dtPhieuNhap = new DataTable();
            da.Fill(dtPhieuNhap);
            return dtPhieuNhap;
        }
    }
}