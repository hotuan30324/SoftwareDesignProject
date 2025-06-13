using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.QuanLyVe;
using BTL.QuanLyChuyenBay;

namespace BTL
{
    public partial class frm_ThongKeVe : Form
    {
        public frm_ThongKeVe()
        {
            InitializeComponent();
            loadVe();
        }
        private void loadVe()
        {
            VeThuongCreator veThuongCreator = new VeThuongCreator();
            Ve ve = veThuongCreator.createVe();
            DataTable dt = ve.hienThiThongTinVe();
            lbSoVe.Text = dt.Rows.Count.ToString();
            dtgvVe.DataSource = dt;
        }
        private void countToTalRevenue()
        {
        }

        private void timKiemVe_Click(object sender, EventArgs e)
        {
            VeThuongCreator veThuongCreator = new VeThuongCreator();
            Ve ve = veThuongCreator.createVe();
            DataTable rs = ve.timKiemVeBangMaVeThongKe(textBox1.Text.Trim());
            dtgvVe.DataSource = rs;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                loadVe();
            }
        }
    }
   
}
