using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.QuanLyVe
{
    public class VeThuongGia : Ve
    {
        public string MaVe { get; set; }
        public string MaChuyenBay { get; set; }
        public string LoaiVe { get; set; }
        public float GiaVe { get; set; }
        public DataTable hienThiThongTinVe()
        {
            string sqlstr = "select MaVe, LoaiVe, GiaVe, DiemDi, DiemDen from ThongTinVe as ttv INNER JOIN dbo.ChuyenBay AS cb ON ttv.MaCHuyenBay = cb.MaChuyenBay INNER JOIN dbo.DuongDi AS dd ON dd.MaDD = cb.MaDD where LoaiVe=N'Thương Gia'";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable demVeTheoLoaiTuChuyenBay(string maCB, string loaiVe)
        {
            string sqlstr_eco = "select count(*) as SoVe from ThongTinVe where MaCHuyenBay='" + maCB + "' and Loaive='" + loaiVe + "'";
            return ConnectSQL.GetData(sqlstr_eco);
        }
        public DataTable timKiemVeBangMaVe(string maVe)
        {
            string sqlstr = "select * from ThongTinVe where MaVe='" + maVe + "'";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable timKiemVeBangMaChuyenBay(string maChuyenBay)
        {
            string sqlstr = "select * from ThongTinVe where MaCHuyenBay='" + maChuyenBay + "'";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable timKiemVeBangMaVeThongKe(string maVe)
        {
            string sqlstr = "select MaVe, LoaiVe, GiaVe, DiemDi, DiemDen from ThongTinVe as ttv INNER JOIN dbo.ChuyenBay AS cb ON ttv.MaCHuyenBay = cb.MaChuyenBay INNER JOIN dbo.DuongDi AS dd ON dd.MaDD = cb.MaDD WHERE MaVe='" + maVe + "'";
            return ConnectSQL.GetData(sqlstr);

        }
        public bool themMoi(Ve ve)
        {
            string sqlstr = "insert into ThongTinVe(MaVe, MaCHuyenBay, LoaiVe, GiaVe) values (@MaVe, @MaCHuyenBay, @LoaiVe, @GiaVe)";

            SqlParameter[] pars = new SqlParameter[4];

            pars[0] = new SqlParameter("@MaVe", SqlDbType.NChar, 5);
            pars[0].Value = ve.MaVe;

            pars[1] = new SqlParameter("@MaCHuyenBay", SqlDbType.NChar, 5);
            pars[1].Value = ve.MaChuyenBay;

            pars[2] = new SqlParameter("@LoaiVe", SqlDbType.NVarChar, 50);
            pars[2].Value = ve.LoaiVe;

            pars[3] = new SqlParameter("@GiaVe", SqlDbType.Float);
            pars[3].Value = ve.GiaVe;

            return ConnectSQL.ThucHien(sqlstr, pars);

        }
        public bool xoaVeBangMaChuyenBay(string maChuyenBay)
        {
            string strDel = "delete from ThongTinVe where MaCHuyenBay = '" + maChuyenBay + "'";
            return ConnectSQL.ThucHien(strDel);
        }
    }
}
