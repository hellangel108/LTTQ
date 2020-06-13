using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_HOADON : DAL_connect
    {

        public DataTable getHoaDon()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HOADON", connect);
            DataTable dtHoaDon = new DataTable();
            da.Fill(dtHoaDon);
            return dtHoaDon;
        }


        public bool themHoaDon(DTO_HoaDon tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO HOADON(MAHD,MANV,MAKH,NGHD,TONGTIENHANG,GIAMGIA,THANHTIEN) " +
                                           "VALUES ( '{0}', '{1}', '{2}' , '{3}' , {4} , '{5}' , {6} ) ",
                                            tv.MAHD, tv.MANV, tv.MAKH, tv.NGHD, tv.TONGTIENHANG, tv.GIAMGIA,tv.THANHTIEN);// DỮ LIỆU NHẬP VÀO

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


        public bool suaHoaDon(DTO_HoaDon tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE HOADON " +
                                           "SET MANV= '{1}',MAKH='{2}',NGHD= '{3}' ,TONGTIENHANG={4} ,GIAMGIA='{5}',THANHTIEN={6} " +
                                           "WHERE MAHD='{0}' ",
                                           tv.MAHD, tv.MANV, tv.MAKH, tv.NGHD, tv.TONGTIENHANG, tv.GIAMGIA, tv.THANHTIEN);

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


        public bool xoaHoaDon(string MAHD)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM HOADON WHERE MAHD = '{0}'", MAHD);

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

        public DataTable timkiemHoaDon(string mhd)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT HOTEN FROM HOADON " +
                                                   "WHERE MAHD LIKE " + mhd, connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }

    }
}