using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stelia_DTO;

namespace Stelia_DAL
{
    public class DAL_DIEMDANH : DAL_connect
    {

        public DataTable getDiemDanh()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DIEMDANH", connect);
            DataTable dtCTPN = new DataTable();
            da.Fill(dtCTPN);
            return dtCTPN;
        }


        public bool themDiemDanh(DTO_DiemDanh tv)// THẮNG
        {
            try
            {
                // Ket noi
                connect.Open();


                string SQL = string.Format("INSERT INTO DIEMDANH(MANV, NGAYDD) " +
                                           "VALUES ('{0}', '{1}')",
                                            tv.MANV, tv.NGAYDD);// DỮ LIỆU NHẬP VÀO

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


        public bool suaDiemDanh(DTO_DiemDanh tv)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string
                string SQL = string.Format("UPDATE DIEMDANH " +
                                           "SET NGAYDD = '{1}' " +
                                           "WHERE MANV= '{0}'",
                                          tv.MANV, tv.NGAYDD);

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


        public bool xoaDiemDanh(string MANV, string NGAYDD)
        {
            try
            {
                // Ket noi
                connect.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM DIEMDANH WHERE MANV = '{0}' AND NGAYDD = '{1}' ", MANV, NGAYDD);

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
        public DataTable getTop10DiemDanh()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP(10) nv.HOTEN FROM DIEMDANH dd JOIN NHANVIEN nv ON dd.MANV = nv.MANV " +
                                                   "ORDER BY dd.NGAYDD DESC", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable timKiemDiemDanh(string manv, string date)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DIEMDANH " +
                                                   "WHERE MANV LIKE '%" + manv +"%' AND NGAYDD = '" + date + "'", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public DataTable timKiemDiemDanh_NhanVien(string manv, string date)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT dd.MANV, nv.HOTEN, nv.NGSINH, nv.CHUCVU, nv.GIOITINH " +
                                                   "FROM DIEMDANH dd JOIN NHANVIEN nv ON dd.MANV = nv.MANV " +
                                                   "WHERE dd.MANV LIKE '%" + manv + "%' AND dd.NGAYDD = '" + date + "'", connect);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
    }
}

