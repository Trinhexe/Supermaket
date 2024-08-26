using Supermaket.ReportBaoCao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermaket.Add.Kho.NhapHang
{
    public partial class FormHoaDonNH : Mau
    {
        public static SqlConnection connection;
        public int id = 0;
        public FormHoaDonNH()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHoaDonNH_Load(object sender, EventArgs e)
        {
            btnMax.PerformClick();
            if (id == 0)
            {
                Load_CBXHDNH();
            }
        }
        private void Load_CBXHDNH()
        {
            string sql = "select MANHAPHANG from HDNHAPHANG ORDER BY MANHAPHANG DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxHDNHrp.DataSource = ds;
            cbxHDNHrp.DisplayMember = "MANHAPHANG";
            cbxHDNHrp.ValueMember = "MANHAPHANG";
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = @"select HDNHAPHANG.MANHAPHANG,HOVATEN,NHANVIEN.SDT,NGAYNHAP,TENSP,TENNCC,SOLUONG,GIANH,THANHTIEN,TONGTIEN
            FROM HDNHAPHANG INNER JOIN CTNHAPHANG ON HDNHAPHANG.MANHAPHANG = CTNHAPHANG.MANHAPHANG
                            INNER JOIN SANPHAM ON SANPHAM.IDSP = CTNHAPHANG.IDSP
                            INNER JOIN NHACUNGCAP ON SANPHAM.MANCC = NHACUNGCAP.MANCC
                            INNER JOIN NHANVIEN ON HDNHAPHANG.MANV = NHANVIEN.MANV
            WHERE HDNHAPHANG.MANHAPHANG = '" + cbxHDNHrp.Text + "'";
            SqlDataAdapter AD = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            AD.Fill(dt);
            HoaDonNhapHang rp = new HoaDonNhapHang();
            rp.SetDataSource(dt);
            crystalReportViewer2.ReportSource = rp;
        }
    }
}
