using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Supermaket.View.TrangChu
{
    public partial class FormTKSP : Mau
    {
        public static SqlConnection connection;
       
        public FormTKSP()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void FormTKSP_Load(object sender, EventArgs e)
        {
            lblKH.Text = DemKH().ToString();
            lblSoSP.Text = SoLuongSP().ToString();
            Top10SP();
            Top10KH();
            LoadTop10SP();
            LoadTop10KH();
        }
        private int SoLuongSP()
        {
            int dem = 0;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "SELECT COUNT(IDSP) AS SL FROM SANPHAM " +
                         "WHERE TRANGTHAI = 1 AND SOLUONGTON > 0 AND DONGIA IS NOT NULL";
            SqlCommand cmd = new SqlCommand(sql, connection);
            var ketqua = cmd.ExecuteScalar();
            if (ketqua != DBNull.Value)
            {
                dem = Convert.ToInt32(ketqua);
            }
            return dem;
        }
        private int DemKH()
        {
            int dem = 0;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "SELECT COUNT(*) FROM KHACHHANG";
            SqlCommand cmd = new SqlCommand(sql, connection);
            dem = (int)cmd.ExecuteScalar();
            return dem;
        }

       
        private DataTable Top10SP()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = @"SELECT TOP 7 CTHOADON.IDSP, TENSP, SUM(CTHOADON.SOLUONG) AS TONGSL  
                         FROM SANPHAM INNER JOIN CTHOADON ON SANPHAM.IDSP = CTHOADON.IDSP  
                         GROUP BY CTHOADON.IDSP, TENSP 
                         ORDER BY TONGSL DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        private void LoadTop10SP()
        {
            chartSP.Series["Quantity"].Points.Clear();
            DataTable dt = Top10SP(); 
            chartSP.DataSource = dt; 
            chartSP.Series["Quantity"].XValueMember = "TENSP";
            chartSP.Series["Quantity"].YValueMembers = "TONGSL";
        }
        private DataTable Top10KH()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = @"SELECT TOP 7 KHACHHANG.MAKH, KHACHHANG.HOVATEN, SUM(HOADON.TongTien) AS TONG
                         FROM KHACHHANG INNER JOIN HOADON ON KHACHHANG.MAKH = HOADON.MAKH  
                         
                         GROUP BY KHACHHANG.MAKH, KHACHHANG.HOVATEN
                         ORDER BY TONG DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        private void LoadTop10KH()
        {
            chartKH.Series["Money"].Points.Clear();
            DataTable dt = Top10KH();
            chartKH.DataSource = dt;
            chartKH.Series["Money"].XValueMember = "HOVATEN";
            chartKH.Series["Money"].YValueMembers = "TONG";
        }

        private void chartKH_MouseMove(object sender, MouseEventArgs e)
        {
            // Lấy vị trí hit test
            HitTestResult ketqua = chartKH.HitTest(e.X, e.Y);
            // Kiểm tra nếu hit test là một điểm dữ liệu
            if (ketqua.ChartElementType == ChartElementType.DataPoint)
            {
                // Lấy chỉ số của điểm dữ liệu
                int pointIndex = ketqua.PointIndex;
                DataPoint point = chartKH.Series["Money"].Points[pointIndex];
                // Lấy thông tin ngày trong tuần và doanh thu
                string hoten = point.AxisLabel;
                double tienmua = point.YValues[0];
                // Thiết lập tooltip cho điểm dữ liệu
                point.ToolTip = $"{hoten}\nĐã mua: {tienmua.ToString("N0")}";
            }
        }

        private void chartSP_MouseMove(object sender, MouseEventArgs e)
        {
            // Lấy vị trí hit test
            HitTestResult ketqua = chartSP.HitTest(e.X, e.Y);
            // Kiểm tra nếu hit test là một điểm dữ liệu
            if (ketqua.ChartElementType == ChartElementType.DataPoint)
            {
                // Lấy chỉ số của điểm dữ liệu
                int pointIndex = ketqua.PointIndex;
                DataPoint point = chartSP.Series["Quantity"].Points[pointIndex];
                // Lấy thông tin ngày trong tuần và doanh thu
                string tensp = point.AxisLabel;
                double daban = point.YValues[0];
                // Thiết lập tooltip cho điểm dữ liệu
                point.ToolTip = $"{tensp}\nĐã bán: {daban.ToString("N0")}";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormTKSP_Load(sender,e);
        }
    }
}
