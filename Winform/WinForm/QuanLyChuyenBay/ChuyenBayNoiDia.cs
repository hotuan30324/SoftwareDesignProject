using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.QuanLyChuyenBay
{
    public class ChuyenBayNoiDia : ChuyenBay
    {
        public string MaChuyenBay { get; set; }
        public string MaMayBay { get; set; }
        public string MaDD { get; set; }
        public string Manv { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime NgayDen { get; set; }
        public string GioDi { get; set; }
        public string Ghichu { get; set; }
        public DataTable layDuLieuChuyenBay()
        {
            string sqlstr = "select cb.MaChuyenBay, cb.NgayDi , cb.NgayDen , cb.GioDi , " +
                "mb.SoLuongGhe1 , mb.SoLuongGhe2 , dd.DiemDi , dd.DiemDen ," +
                "cb.GhiChu " +
                "from ChuyenBay AS cb INNER JOIN dbo.MayBay AS mb ON cb.MaMayBay = mb.MaMayBay INNER JOIN dbo.DuongDi AS dd ON cb.MaDD = dd.MaDD";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable hienThiDanhSachChuyenBay()
        {
            string sqlstr = "select cb.MaChuyenBay, cb.NgayDi , cb.NgayDen , cb.GioDi , " +
                "mb.SoLuongGhe1 , mb.SoLuongGhe2 , dd.DiemDi , dd.DiemDen ," +
                "cb.GhiChu " +
                "from ChuyenBay AS cb INNER JOIN dbo.MayBay AS mb ON cb.MaMayBay = mb.MaMayBay INNER JOIN dbo.DuongDi AS dd ON cb.MaDD = dd.MaDD where GhiChu='Chuyen bay noi dia'";
            return ConnectSQL.GetData(sqlstr);
        }
        public bool themChuyenBay(ChuyenBay objCB)
        {
            string sqlstr = "insert into ChuyenBay(MaChuyenBay, MaMayBay, MaDD, Manv, NgayDi, NgayDen, GioDi, Ghichu) values (@MaChuyenBay, @MaMayBay,@MaDD,@Manv,@NgayDi,@NgayDen,@GioDi,@Ghichu)";
            SqlParameter[] pars = new SqlParameter[8];

            pars[0] = new SqlParameter("@MaChuyenBay", SqlDbType.NChar, 5);
            pars[0].Value = objCB.MaChuyenBay;

            pars[1] = new SqlParameter("@MaMayBay", SqlDbType.NChar, 5);
            pars[1].Value = objCB.MaMayBay;

            pars[2] = new SqlParameter("@MaDD", SqlDbType.NChar, 5);
            pars[2].Value = objCB.MaDD;

            pars[3] = new SqlParameter("@Manv", SqlDbType.NChar, 5);
            pars[3].Value = objCB.Manv;

            pars[4] = new SqlParameter("@NgayDi", SqlDbType.DateTime);
            pars[4].Value = objCB.NgayDi;

            pars[5] = new SqlParameter("@NgayDen", SqlDbType.DateTime);
            pars[5].Value = objCB.NgayDen;

            pars[6] = new SqlParameter("@GioDi", SqlDbType.NChar, 10);
            pars[6].Value = objCB.GioDi;

            pars[7] = new SqlParameter("@Ghichu", SqlDbType.NChar, 50);
            pars[7].Value = objCB.Ghichu;

            return ConnectSQL.ThucHien(sqlstr, pars);

        }
        public bool capNhatChuyenBay(ChuyenBay objCB)
        {
            string strsql = "update ChuyenBay set MaMayBay = @MaMayBay, MaDD = @MaDD, Manv=@Manv, NgayDi= @NgayDi , NgayDen = @NgayDen, GioDi = @GioDi, Ghichu=@Ghichu where MaChuyenBay = @MaChuyenBay";

            SqlParameter[] pars = new SqlParameter[8];

            pars[0] = new SqlParameter("@MaChuyenBay", SqlDbType.NChar, 5);
            pars[0].Value = objCB.MaChuyenBay;

            pars[1] = new SqlParameter("@MaMayBay", SqlDbType.NChar, 5);
            pars[1].Value = objCB.MaMayBay;

            pars[2] = new SqlParameter("@MaDD", SqlDbType.NChar, 5);
            pars[2].Value = objCB.MaDD;

            pars[3] = new SqlParameter("@Manv", SqlDbType.NChar, 5);
            pars[3].Value = objCB.Manv;

            pars[4] = new SqlParameter("@NgayDi", SqlDbType.DateTime);
            pars[4].Value = objCB.NgayDi;

            pars[5] = new SqlParameter("@NgayDen", SqlDbType.DateTime);
            pars[5].Value = objCB.NgayDen;

            pars[6] = new SqlParameter("@GioDi", SqlDbType.NChar, 10);
            pars[6].Value = objCB.GioDi;

            pars[7] = new SqlParameter("@Ghichu", SqlDbType.NChar, 50);
            pars[7].Value = objCB.Ghichu;

            return ConnectSQL.ThucHien(strsql, pars);


        }
        public bool xoaChuyenBay(string MaCB)
        {
            string strDel = "delete from ChuyenBay where MaChuyenBay = '" + MaCB + "'";
            return ConnectSQL.ThucHien(strDel);
        }
    }
}
