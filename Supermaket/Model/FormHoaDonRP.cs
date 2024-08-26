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

namespace Supermaket.Model
{
    public partial class FormHoaDonRP : Mau
    {
        public static SqlConnection connection;
        public int id = 0;
        public FormHoaDonRP()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHoaDonRP_Load(object sender, EventArgs e)
        {
            btnMax.PerformClick();
            if (id == 0)
            {
                Load_CBXHD();
            }
        }
        private void Load_CBXHD()
        {
            string sql = "select MAHD from HOADON ORDER BY MAHD DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxHDrp.DataSource = ds;
            cbxHDrp.DisplayMember = "MAHD";
            cbxHDrp.ValueMember = "MAHD";
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = @"select HOADON.MAHD,HOVATEN,DIACHI,SOLUONG,SĐT,NGAYLAPHOADON,
            TENSP,TIENMAT,TONGTIEN,TIENTHOI,GIA,THANHTIEN
            FROM HOADON LEFT JOIN KHACHHANG ON HOADON.MAKH = KHACHHANG.MAKH
                        INNER JOIN CTHOADON ON CTHOADON.MAHD = HOADON.MAHD
                        INNER JOIN SANPHAM ON CTHOADON.IDSP = SANPHAM.IDSP
            WHERE HOADON.MAHD = '"+cbxHDrp.Text+"'";
            SqlDataAdapter AD = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            AD.Fill(dt);
            CrystalReport1 rp = new CrystalReport1();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
