using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_PTTQ : DAL_connect
    {

        public DataTable getPTTQ()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHIEUTRATAIQUAY", connect);
            DataTable dtCTPN = new DataTable();
            da.Fill(dtCTPN);
            return dtCTPN;
        }


        public bool themPTTQ(DTO_PTTQ tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO PHIEUTRATAIQUAY(MAPTTQ,MANV,MAKH,MASP,SOLUONG,THANHTIEN,NGTRA) " +
                                           "VALUES ('{0}', '{1}', '{2}' , '{3}' , {4} , {5},'{6}')",
                                            tv.MAPTTQ, tv.MANV, tv.MAKH, tv.MASP, tv.SOLUONG, tv.THANHTIEN,tv.NGTRA);// DỮ LIỆU NHẬP VÀO

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


        public bool suaPTTQ(DTO_PTTQ tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE PHIEUTRATAIQUAY " +
                                           "SET  MANV = '{1}', MAKH = '{2}', MASP = '{3}', SOLUONG = {4}, THANHTIEN = {5}, NGTRA='{6}' " +
                                           "WHERE MAPTTQ= '{0}' ",
                                          tv.MAPTTQ, tv.MANV, tv.MAKH, tv.MASP, tv.SOLUONG, tv.THANHTIEN,tv.NGTRA);

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


        public bool xoaPTTQ(string MAPTTQ)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM PHIEUTRATAIQUAY WHERE MAPTTQ = '{0}' ", MAPTTQ);

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
        public DataTable getSP_PTTQ()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(5) MASP FROM PHIEUTRATAIQUAY " +
                                                   "ORDER BY NGTRA DESC", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable getTongTienTraTaiQuay_TrongThang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUM(THANHTIEN) as TONGTRA FROM PHIEUTRATAIQUAY " +
                                                     "WHERE MONTH(NGTRA) = MONTH('" + DateTime.Today.ToString("yyyy-MM-dd") + "') " +
                                                   "AND   YEAR(NGTRA) = YEAR('" + DateTime.Today.ToString("yyyy-MM-dd") + "') " , connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public bool updateSL_SP(string MaSP, int SL)
        {
            
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format(" UPDATE SANPHAM " +
                                           " SET SLUONG = SLUONG + {0} "+
                                           " WHERE MASP LIKE '{1}'",SL,MaSP);

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
        public DataTable timKiemPhieuTraTaiQuay(string mapttq)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PTTQ " +
                                                     "WHERE MAPTTQ LIKE " + mapttq, connect);
            DataTable dtCTPT = new DataTable();
            da.Fill(dtCTPT);
            return dtCTPT;
        }
    }
}

