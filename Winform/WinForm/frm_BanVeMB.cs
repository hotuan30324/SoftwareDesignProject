using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.QuanLyVe;
using BTL.QuanLyVe;
using BTL.QuanLyChuyenBay;

namespace BTL
{
    public partial class frm_BanVeMB : Form
    {
        public string MaNV;
        public string Eco = "eco";
        public string Bu = "bu";

        public frm_BanVeMB(string mcb, string maNV)
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            rbGhe1.BackColor = Color.Transparent;
            tbGhe2.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            btnMua.BackColor = Color.Transparent;

            hiddenMCB.Text = mcb;
            MaNV = maNV;
            loadKhachHang();
        }
        private void loadKhachHang()
        {
            DataTable dt = DAO.ActKhachHang.Instance.GetDataKhachHang();
            dtgvKhachHang.DataSource = dt;
        }

        private void btnMua_Click(object sender, EventArgs e)
        {

            if (checkSoVeConLai())
            {
                bool stVe = false;
                bool stKH = false;
                bool stHD = false;

                if (string.IsNullOrWhiteSpace(tbMaVe.Text) || string.IsNullOrWhiteSpace(tbMaHoaDon.Text) || string.IsNullOrWhiteSpace(tbGiaVe.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ các thông tin");
                    return;
                }
                // xu ly khach hang
                DataTable rs = DAO.ActKhachHang.Instance.timKiemKHByMaKH(maKH.Text.Trim());
                if (rs.Rows.Count == 0)
                {
                    if (!checkSDT(txtSdt.Text))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ");
                        return;
                    }
                    KhachHang objKh = new KhachHang();

                    objKh.MaKH = maKH.Text;
                    objKh.TenKH = tbTenKH.Text;
                    objKh.SDT = txtSdt.Text;
                    objKh.DiaChi = tbDiaChi.Text;
                    objKh.CMNDHoChieu = tbCMND.Text;
                    objKh.QuocTich = tbQuocTich.Text;
                    objKh.NgaySinh = dtpNgaySinh.Value;
                    if (rbNam.Checked) objKh.GioiTinh = "Nam";
                    else objKh.GioiTinh = "Nữ";

                    stKH = DAO.ActKhachHang.Instance.ThemMoi(objKh);

                }


                DataTable checkVe = new VeThuongCreator().createVe().timKiemVeBangMaVe(tbMaVe.Text.Trim());
                if (checkVe.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Vé đã tồn tại");
                    return;
                }
                else
                {
                    if (rbGhe1.Checked)
                    {
                        VeThuongCreator veThuongCreator = new VeThuongCreator();
                        Ve ve = veThuongCreator.createVe();
                        ve.MaVe = tbMaVe.Text;
                        ve.MaChuyenBay = hiddenMCB.Text;
                        ve.LoaiVe = "Thường";
                        ve.GiaVe = Convert.ToInt32(tbGiaVe.Text);
                        //stVe = DAO.ActVe.Instance.ThemMoi(ve);
                        stVe = ve.themMoi(ve);
                    }
                    else
                    {
                        VeThuongGiaCreator veThuongGiaCreator = new VeThuongGiaCreator();
                        Ve ve = veThuongGiaCreator.createVe();
                        ve.MaVe = tbMaVe.Text;
                        ve.MaChuyenBay = hiddenMCB.Text;
                        ve.LoaiVe = "Thương gia";
                        ve.GiaVe = Convert.ToInt32(tbGiaVe.Text);
                        //stVe = DAO.ActVe.Instance.ThemMoi(ve);
                        stVe = ve.themMoi(ve);
                    }
                }

                DataTable checkHoaDon = DAO.ActHoaDon.Instance.timKiemHoaDonbayMaHD(tbMaHoaDon.Text.Trim());
                if (checkHoaDon.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Hóa Đơn đã tồn tại");
                    return;
                }
                else
                {
                    HoaDon objHD = new HoaDon();

                    objHD.MaHoaDon = tbMaHoaDon.Text;
                    objHD.NgayBan = DateTime.Now;
                    objHD.MaNV = MaNV;
                    objHD.MaKH = maKH.Text;
                    objHD.MaVe = tbMaVe.Text;
                    objHD.TongTien = Convert.ToInt32(tbGiaVe.Text);

                    stHD = DAO.ActHoaDon.Instance.ThemMoi(objHD);
                }


                if (stVe && stHD)
                {
                    MessageBox.Show("Cập nhật thông tin thành công");
                }

            }

        }
        private bool checkSDT(string sdt)
        {
            if (sdt.Length != 10)
            {
                return false;
            }

            return true;
        }

        private bool checkSoVeConLai()
        {
            string toCheck = "SoLuongGhe1";
            DataTable ve = new VeThuongCreator().createVe().demVeTheoLoaiTuChuyenBay(hiddenMCB.Text.Trim(), Eco);
            if (tbGhe2.Checked)
            {
                toCheck = "SoLuongGhe2";
                ve = new VeThuongCreator().createVe().demVeTheoLoaiTuChuyenBay(hiddenMCB.Text.Trim(), Bu);
            }
            DataTable mb = DAO.ActChuyenBay.Instance.getMayBayFromChuyyenBay(hiddenMCB.Text.Trim());
   
            int soGhe = Convert.ToInt32(mb.Rows[0][toCheck]);

            int soGheDaMua = Convert.ToInt32(ve.Rows[0]["SoVe"]);

            if(soGhe <= soGheDaMua)
            {
                MessageBox.Show("Máy bay đã đầy ghế");
                return false;
            }

            return true;
        }
        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            if(txtSdt.Text.Length >= 6)
            {
                DataTable rs = DAO.ActKhachHang.Instance.timKiemKH(txtSdt.Text.Trim());
                if (rs.Rows.Count > 0)
                {
                    txtSdt.Text = rs.Rows[0]["SDT"].ToString();
                    maKH.Text = rs.Rows[0]["MaKH"].ToString();
                    tbTenKH.Text = rs.Rows[0]["TenKH"].ToString();
                    tbCMND.Text = rs.Rows[0]["CMNDHoChieu"].ToString();
                    dtpNgaySinh.Text = rs.Rows[0]["NgaySinh"].ToString();
                    tbDiaChi.Text = rs.Rows[0]["DiaChi"].ToString();
                    tbQuocTich.Text = rs.Rows[0]["QuocTich"].ToString();

                    string gioitinh = rs.Rows[0]["GioiTinh"].ToString();

                    if (gioitinh == "Nu")
                    {
                        rbNu.Checked = true;
                    }
                    else
                    {
                        rbNam.Checked = true;

                    }
                }
            }
           

        }

        private void maKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbQuocTich_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != null&& e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvKhachHang.Rows[e.RowIndex];

                txtSdt.Text = row.Cells[2].Value.ToString();
                maKH.Text = row.Cells[0].Value.ToString();
                tbTenKH.Text = row.Cells[1].Value.ToString();
                tbCMND.Text = row.Cells[6].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells[3].Value);
                tbDiaChi.Text = row.Cells[5].Value.ToString();
                tbQuocTich.Text = row.Cells[7].Value.ToString();

                string gioitinh = row.Cells[4].Value.ToString();

                if (gioitinh == "Nu")
                {
                    rbNu.Checked = true;
                }
                else
                {
                    rbNam.Checked = true;

                }
            }
        }

        private void tbGiaVe_TextChanged(object sender, EventArgs e)
        {
            totalMoney.Text = tbGiaVe.Text;
        }
    }
}
