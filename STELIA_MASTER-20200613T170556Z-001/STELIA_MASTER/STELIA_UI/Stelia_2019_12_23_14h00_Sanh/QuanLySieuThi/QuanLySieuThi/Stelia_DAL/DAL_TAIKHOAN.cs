using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_TAIKHOAN : DAL_connect
    {

        public DataTable getTaiKhoan()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TAIKHOAN", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }


        public bool themTaiKhoan(DTO_TaiKhoan tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO TAIKHOAN (TENDN, MATKHAU) " +
                                           "VALUES ('{0}', '{1}')",
                                            tv.TENDN, tv.MATKHAU);// DỮ LIỆU NHẬP VÀO

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


        public bool suaTaiKhoan(DTO_TaiKhoan tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE TAIKHOAN " +
                                           "SET MATKHAU = '{1}' " +
                                           "WHERE TENDN = '{0}'",
                                          tv.TENDN, tv.MATKHAU);

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


        public bool xoaTaiKhoan(string TENDN)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM TAIKHOAN WHERE TENDN = '{0}' ", TENDN);

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
    }
}

