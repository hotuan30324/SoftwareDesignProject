using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.QuanLyChuyenBay
{
    public interface ChuyenBay
    {
        string MaChuyenBay { get; set; }
        string MaMayBay { get; set; }
        string MaDD { get; set; }
        string Manv { get; set; }
        DateTime NgayDi { get; set; }
        DateTime NgayDen { get; set; }
        string GioDi { get; set; }
        string Ghichu { get; set; }
        DataTable layDuLieuChuyenBay();
        DataTable hienThiDanhSachChuyenBay();
        bool themChuyenBay(ChuyenBay objCB);
        bool capNhatChuyenBay(ChuyenBay objCB);
        bool xoaChuyenBay(string MaCB);
    }
}
