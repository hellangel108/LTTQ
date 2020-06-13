using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_PHIEUNHAP: DAL_connect
    {

        public DataTable getPhieuNhap()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHIEUNHAP", connect);
            DataTable dtPhieuNhap = new DataTable();
            da.Fill(dtPhieuNhap);
            return dtPhieuNhap;
        }


        public bool themPhieuNhap(DTO_PhieuNhap tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO PHIEUNHAP (MAPN, MANCC, NGNHAP, TONGSL,TONGTIEN, GHICHU) " +
                                           "VALUES ('{0}', '{1}', '{2}', {3} , {4}, N'{5}')",
                                           tv.MAPN, tv.MANCC, tv.NGNHAP, tv.TONGSL, tv.TONGTIEN, tv.GHICHU); // DỮ LIỆU NHẬP VÀO
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


        public bool suaPhieuNhap(DTO_PhieuNhap tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE PHIEUNHAP " +
                                           "SET MANCC= '{1}', NGNHAP='{2}',TONGSL= {3} , TONGTIEN={4} ,GHICHU= N'{5}' " +
                                           "WHERE MAPN='{0}'",
                                            tv.MAPN, tv.MANCC, tv.NGNHAP, tv.TONGSL, tv.TONGTIEN, tv.GHICHU);

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


        public bool xoaPhieuNhap(string MAPN)
        {
            try
            {
                // Ket noi
                connect.Open();

                string SQL = string.Format("DELETE FROM PHIEUNHAP WHERE MAPN = '{0}' ", MAPN);

              
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
        public DataTable timKiemPhieuNhap(string NgNhap)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHIEUNHAP " +
                                                   "WHERE NGNHAP LIKE '"+NgNhap+"' ", connect);
            DataTable dtPhieuNhap = new DataTable();
            da.Fill(dtPhieuNhap);
            return dtPhieuNhap;
        }
        public DataTable timKiemTheoMaPhieuNhap(string mapn)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHIEUNHAP " +
                                                   "WHERE MAPN LIKE '%" + mapn + "%' ", connect);
            DataTable dtPhieuNhap = new DataTable();
            da.Fill(dtPhieuNhap);
            return dtPhieuNhap;
        }
        public DataTable timKiemChiTiet(string mapn, string mancc)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHIEUNHAP " +
                                                   "WHERE MAPN LIKE '%" + mapn + "%' AND MANCC LIKE '%" + mancc + "%'", connect);
            DataTable dtPhieuNhap = new DataTable();
            da.Fill(dtPhieuNhap);
            return dtPhieuNhap;
        }
    }
}