using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_CTPN : DAL_connect
    {

        public DataTable getCTPN()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CTPN", connect);
            DataTable dtCTPN = new DataTable();
            da.Fill(dtCTPN);
            return dtCTPN;
        }


        public bool themCTPN(DTO_CTPhieuNhap tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO CTPN(MAPN,MASP,SOLUONG,THANHTIEN) " +
                                           "VALUES ('{0}', '{1}', {2} , {3} )",
                                            tv.MAPN,tv.MASP,tv.SOLUONG,tv.THANHTIEN);// DỮ LIỆU NHẬP VÀO

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


        public bool suaCTPN(DTO_CTPhieuNhap tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE CTPN " +
                                           "SET MASP = '{1}', SOLUONG = {2}, THANHTIEN = {3} " +
                                           "WHERE  MAPN= '{0}' ",
                                          tv.MAPN, tv.MASP, tv.SOLUONG, tv.THANHTIEN);

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


        public bool xoaCTPN(string MAPN,string MASP)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM CTPN WHERE MAPN = '{0}' AND MASP = '{1}' ", MAPN,MASP);

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
        public DataTable InPhieuNhap(string mapn)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT pn.*, ncc.TENNCC, sp.TENSP, ct.MASP, ct.SOLUONG, ct.THANHTIEN " +
                                                   "FROM ((PHIEUNHAP pn JOIN CTPN ct ON pn.MAPN = ct.MAPN) JOIN NHACUNGCAP ncc ON pn.MANCC = ncc.MANCC) JOIN SANPHAM sp ON ct.MASP = sp.MASP " +
                                                   "WHERE pn.MAPN LIKE '" + mapn + "' ", connect);
            DataTable dtPhieuNhap = new DataTable();
            da.Fill(dtPhieuNhap);
            return dtPhieuNhap;
        }
    }
}