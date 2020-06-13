using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stelia_DTO;
using Stelia_BUS;

namespace Stelia
{
    class CheckThongTin
    {
        static public string check_Nhap(DTO_NhanVien nv)
        {
            string error = "";
            Stelia_BUS.Stelia_BUS bus = new Stelia_BUS.Stelia_BUS();
            DTO_NhanVien[] nhanvien = bus.search_NhanVien(nv.MANV);
            if (nhanvien[0].MANV == nv.MANV)
                error += "Mã nhân viên này đã tồn tại";
            if (nv.GIOITINH != "Nữ" && nv.GIOITINH != "Nam" && nv.GIOITINH != "Khác")
                error += "\n" + "Giới tính chỉ được {Nam, Nữ, Khác}";
            return error;
        }
    }
}
