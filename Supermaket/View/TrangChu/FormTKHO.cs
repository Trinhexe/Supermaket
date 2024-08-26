using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Supermaket.View.TrangChu
{
    public partial class FormTKHO : Mau
    {
        public static SqlConnection connection;
        public FormTKHO()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        private float ThangNhapHang(int thang)
        {
            float tiennhap = 0;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = "SELECT SUM(TONGTIEN)FROM HDNHAPHANG WHERE MONTH(NGAYNHAP) = '" + thang + "' AND YEAR(NGAYNHAP) = YEAR(GETDATE()) ";
            SqlCommand cmd = new SqlCommand(sql, connection);
            var ketqua = cmd.ExecuteScalar();
            if (ketqua != DBNull.Value)
            {
                tiennhap = Convert.ToSingle(ketqua);
            }
            return tiennhap;
        }
        private float ThangXuatHang(int thang)
        {
            float tienxuat = 0;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = "SELECT SUM(TONGTIEN)FROM HDXUATHANG WHERE MONTH(NGAYXUAT) = '" + thang + "' AND YEAR(NGAYXUAT) = YEAR(GETDATE()) ";
            SqlCommand cmd = new SqlCommand(sql, connection);
            var ketqua = cmd.ExecuteScalar();
            if (ketqua != DBNull.Value)
            {
                tienxuat = Convert.ToSingle(ketqua);
            }
            return tienxuat;
        }
        private string ThangTrongNam(int thang)
        {
            switch (thang)
            {
                case 1:
                    return "Tháng 1";
                case 2:
                    return "Tháng 2";
                case 3:
                    return "Tháng 3";
                case 4:
                    return "Tháng 4";
                case 5:
                    return "Tháng 5";
                case 6:
                    return "Tháng 6";
                case 7:
                    return "Tháng 7";
                case 8:
                    return "Tháng 8";
                case 9:
                    return "Tháng 9";
                case 10:
                    return "Tháng 10";
                case 11:
                    return "Tháng 11";
                case 12:
                    return "Tháng 12";
                default:
                    return "";
            }
        }
        private void LoadThang()
        {
            chartNhap.Series["Money"].Points.Clear();
            chartXuat.Series["Money"].Points.Clear();
            for (int i = 1; i <= 12; i++)
            {
                chartNhap.Series["Money"].Points.AddXY(ThangTrongNam(i), ThangNhapHang(i));
                chartXuat.Series["Money"].Points.AddXY(ThangTrongNam(i), ThangXuatHang(i));
            }
        }
        private double TongNhapHang()
        {
            double nhaphang = 0;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = "SELECT SUM(TONGTIEN)FROM HDNHAPHANG ";
            SqlCommand cmd = new SqlCommand(sql, connection);
            var ketqua = cmd.ExecuteScalar();
            if (ketqua != DBNull.Value)
            {
                nhaphang = Convert.ToSingle(ketqua);
            }
            return nhaphang;
        }
        private double TongXuatHang()
        {
            double xuathang = 0;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = "SELECT SUM(TONGTIEN)FROM HDXUATHANG ";
            SqlCommand cmd = new SqlCommand(sql, connection);
            var ketqua = cmd.ExecuteScalar();
            if (ketqua != DBNull.Value)
            {
                xuathang = Convert.ToSingle(ketqua);
            }
            return xuathang;
        }

        private void FormTKHO_Load(object sender, EventArgs e)
        {
            lbTongNhap.Text = TongNhapHang().ToString("N0") + " VND";
            lbTongXuat.Text = TongXuatHang().ToString("N0") + " VND";
            LoadThang();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormTKHO_Load(sender,e);
        }

        private void chartNhap_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Lấy vị trí hit test
            HitTestResult ketqua = chartNhap.HitTest(e.X, e.Y);
            // Kiểm tra nếu hit test là một điểm dữ liệu
            if (ketqua.ChartElementType == ChartElementType.DataPoint)
            {
                // Lấy chỉ số của điểm dữ liệu
                int pointIndex = ketqua.PointIndex;
                DataPoint point = chartNhap.Series["Money"].Points[pointIndex];
                // Lấy thông tin ngày trong tuần và doanh thu
                string thang = point.AxisLabel;
                double tienmua = point.YValues[0];
                // Thiết lập tooltip cho điểm dữ liệu
                point.ToolTip = $"{thang}\nĐã nhập: {tienmua.ToString("N0")}";
            }
        }

        private void chartXuat_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Lấy vị trí hit test
            HitTestResult ketqua = chartXuat.HitTest(e.X, e.Y);
            // Kiểm tra nếu hit test là một điểm dữ liệu
            if (ketqua.ChartElementType == ChartElementType.DataPoint)
            {
                // Lấy chỉ số của điểm dữ liệu
                int pointIndex = ketqua.PointIndex;
                DataPoint point = chartXuat.Series["Money"].Points[pointIndex];
                // Lấy thông tin ngày trong tuần và doanh thu
                string thang = point.AxisLabel;
                double tienmua = point.YValues[0];
                // Thiết lập tooltip cho điểm dữ liệu
                point.ToolTip = $"{thang}\nĐã xuất: {tienmua.ToString("N0")}";
            }
        }
    }
}
