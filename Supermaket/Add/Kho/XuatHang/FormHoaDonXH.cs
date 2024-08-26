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

namespace Supermaket.Add.Kho.XuatHang
{
    public partial class FormHoaDonXH : Mau
    {
        public static SqlConnection connection;
        public int id = 0;
        public FormHoaDonXH()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHoaDonXH_Load(object sender, EventArgs e)
        {
            btnMax.PerformClick();
            if (id == 0)
            {
                Load_CBXHDXH();
            }
        }
        private void Load_CBXHDXH()
        {
            string sql = "select MAXUATHANG from HDXUATHANG ORDER BY MAXUATHANG DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxHDXHrp.DataSource = ds;
            cbxHDXHrp.DisplayMember = "MAXUATHANG";
            cbxHDXHrp.ValueMember = "MAXUATHANG";
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = @"select HDXUATHANG.MAXUATHANG,HOVATEN,DIACHI,SĐT,NGAYXUAT,TENSP,SOLUONG,GIAXH,THANHTIEN,TONGTIEN
            FROM HDXUATHANG INNER JOIN CTXUATHANG ON CTXUATHANG.MAXUATHANG = HDXUATHANG.MAXUATHANG
                            INNER JOIN SANPHAM ON CTXUATHANG.IDSP = SANPHAM.IDSP
                            LEFT JOIN KHACHHANG ON HDXUATHANG.MAKH = KHACHHANG.MAKH
            WHERE HDXUATHANG.MAXUATHANG = '"+cbxHDXHrp.Text+"'";
            SqlDataAdapter AD = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            AD.Fill(dt);
            HoaDonXuatHang rp = new HoaDonXuatHang();
            rp.SetDataSource(dt);
            crystalReportViewer3.ReportSource = rp;
        }
    }
}
