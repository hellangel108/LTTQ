using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_QUETMA : DAL_connect
    {

        public DataTable getQuetMa(string MAVACH)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MASP FROM QUETMA" +
                                                   "WHERE MAVACH = '" + MAVACH + "' ", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }


        public bool themQuetMa(DTO_QuetMa tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO QUETMA (MAVACH, MASP) " +
                                           "VALUES ('{0}', '{1}')",
                                            tv.MAVACH, tv.MASP);// DỮ LIỆU NHẬP VÀO

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


        public bool suaQuetMa(DTO_QuetMa tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE QUETMA " +
                                           "SET MASP = '{1}' " +
                                           "WHERE MAVACH = '{0}'",
                                          tv.MAVACH, tv.MASP);

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


        public bool xoaQuetMa(string MAVACH)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM QUETMA WHERE MAVACH = '{0}' ", MAVACH);

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

