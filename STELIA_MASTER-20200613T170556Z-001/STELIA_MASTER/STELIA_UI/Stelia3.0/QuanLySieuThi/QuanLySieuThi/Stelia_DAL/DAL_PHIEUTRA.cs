using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_PHIEUTRA: DAL_connect
    {

        public DataTable getPhieuTra()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHIEUTRA", connect);
            DataTable dtPhieuTra = new DataTable();
            da.Fill(dtPhieuTra);
            return dtPhieuTra;
        }


        public bool themPhieuTra(DTO_PhieuTra tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO PHIEUTRA (MAPT, MANCC, NGNHAP, TONGSL,TONGTIEN, GHICHU) " +
                                           "VALUES ('{0}', '{1}', '{2}',{3}, {4}, N'{5}')",
                                           tv.MAPT, tv.MANCC, tv.NGNHAP, tv.TONGSL, tv.TONGTIEN, tv.GHICHU); // DỮ LIỆU NHẬP VÀO

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


        public bool suaPhieuTra(DTO_PhieuTra tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE PHIEUTRA " +
                                           "SET MANCC= '{1}', NGNHAP='{2}',TONGSL= {3} , TONGTIEN={4} ,GHICHU= N'{5}' " +
                                           "WHERE MAPT='{0}' ",
                                            tv.MAPT, tv.MANCC, tv.NGNHAP, tv.TONGSL, tv.TONGTIEN, tv.GHICHU);

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


        public bool xoaPhieuTra(string MAPT)
        {
            try
            {
                // Ket noi
                connect.Open();

                string SQL = string.Format("DELETE FROM PHIEUTRA WHERE MAPT = '{0}'", MAPT);

              
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
        public DataTable timKiemPhieuTra(string NgLap)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHIEUTRA " +
                                                   "WHERE NGNHAP LIKE '" + NgLap + "' ", connect);
            DataTable dtPhieuTra = new DataTable();
            da.Fill(dtPhieuTra);
            return dtPhieuTra;
        }
    }
}