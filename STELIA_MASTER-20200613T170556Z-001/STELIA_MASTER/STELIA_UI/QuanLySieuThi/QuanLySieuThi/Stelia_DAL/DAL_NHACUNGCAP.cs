using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_NHACUNGCAP : DAL_connect
    {

        public DataTable getNhaCungCap()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NHACUNGCAP", connect);
            DataTable dtNhaCungCap = new DataTable();
            da.Fill(dtNhaCungCap);
            return dtNhaCungCap;
        }


        public bool themNhaCungCap(DTO_NhaCungCap tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO NHACUNGCAP (MANCC, TENNCC, NGHT, DIACHI, SDT, MUCDOCC, TRANGTHAI) " +
                                           "VALUES ('{0}', N'{1}', '{2}', N'{3}', '{4}', N'{5}', N'{6}')",
                                           tv.MANCC, tv.TENNCC, tv.NGHT, tv.DIACHI, tv.SDT, tv.MUCDOCC, tv.TRANGTHAI); // DỮ LIỆU NHẬP VÀO

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


        public bool suaNhaCungCap(DTO_NhaCungCap tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE NHACUNGCAP " +
                                           "SET TENNCC= N'{1}', NGHT='{2}',DIACHI= N'{3}' , SDT='{4}' , MUCDOCC=N'{5}',TRANGTHAI=N'{6}' " +
                                           "WHERE MANCC='{0}'",
                                            tv.MANCC, tv.TENNCC, tv.NGHT, tv.DIACHI, tv.SDT, tv.MUCDOCC, tv.TRANGTHAI);

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


        public bool xoaNhaCungCap(string MANCC)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM NHACUNGCAP WHERE MANCC = {0}", MANCC);

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
        public DataTable getTop3NhaCungCap()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(3) ncc.TENNCC " +
                                                   "FROM NHACUNGCAP ncc JOIN PHIEUNHAP pn ON ncc.MANCC=pn.MANCC " +
                                                   "ORDER BY pn.TONGSL DESC ", connect);
            DataTable dtNhaCungCap = new DataTable();
            da.Fill(dtNhaCungCap);
            return dtNhaCungCap;
        }
    }
}