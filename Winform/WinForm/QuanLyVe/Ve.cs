using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.QuanLyVe
{
    public interface Ve
    {
        string MaVe { get; set; }
        string MaChuyenBay { get; set; }
        string LoaiVe { get; set; }
        float GiaVe { get; set; }
        DataTable hienThiThongTinVe();
        DataTable demVeTheoLoaiTuChuyenBay(string maCB, string loaiVe);
        DataTable timKiemVeBangMaVe(string maVe);
        DataTable timKiemVeBangMaChuyenBay(string maChuyenBay);
        DataTable timKiemVeBangMaVeThongKe(string maVe);
        bool themMoi(Ve ve);
        bool xoaVeBangMaChuyenBay(string maChuyenBay);

    }
        
}

