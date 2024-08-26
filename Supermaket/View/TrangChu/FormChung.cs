using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Supermaket.View.TrangChu
{
    public partial class FormChung : Mau
    {

        
        public FormChung()
        {
            InitializeComponent();
        }
        public void FormChung_Load(object sender, EventArgs e)
        {
            lblNgay.Text = MainClass.DoanhThuNgay().ToString("N0") + " VND";
            lblDoanhThu.Text = (MainClass.DoanhThuBanHang()).ToString("N0") + " VND";
            LoadTuan();
            LoadThang();
        }
        private string NgayTrongTuan(int day)
        {
            switch (day)
            {
                case 1:
                    return "Chủ nhật";
                case 2:
                    return "Thứ 2";
                case 3:
                    return "Thứ 3";
                case 4:
                    return "Thứ 4";
                case 5:
                    return "Thứ 5";
                case 6:
                    return "Thứ 6";
                case 7:
                    return "Thứ 7";
                default:
                    return "";
            }
        }
        private void LoadTuan()
        {
            chartTuan.Series["Money"].Points.Clear();
            for (int i = 1; i <= 7; i++)
            {
                chartTuan.Series["Money"].Points.AddXY(NgayTrongTuan(i), DoanhThuThu(i));
            }
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
            chartThang.Series["Money"].Points.Clear();
            for (int i = 1; i <= 12; i++)
            {
                chartThang.Series["Money"].Points.AddXY(ThangTrongNam(i), DoanhThuThang(i));
            }
        }
        private float DoanhThuThang(int thang)
        {
            float doanhthubh = 0;
            using (SqlConnection connection = MainClass.GetConnection())
            {
                connection.Open();
                string sql = "SELECT SUM(TONGTIEN)FROM HOADON WHERE MONTH(NGAYLAPHOADON) = '" + thang + "' AND YEAR(NGAYLAPHOADON) = YEAR(GETDATE()) ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var ketqua = cmd.ExecuteScalar();
                if (ketqua != DBNull.Value)
                {
                    doanhthubh = Convert.ToSingle(ketqua);
                }
                
            }
            return doanhthubh;
        }

        private float DoanhThuThu(int thu)
        {
            float doanhthubh = 0;
            
            using (SqlConnection connection = MainClass.GetConnection())
            {
                connection.Open();
                string sql = "SELECT SUM(TONGTIEN) FROM HOADON WHERE YEAR(NGAYLAPHOADON) = YEAR(GETDATE()) AND DATEPART(WEEK, NGAYLAPHOADON) = DATEPART(WEEK, GETDATE())" +
                    "AND DATEPART(WEEKDAY, NGAYLAPHOADON) = '" + thu + "' ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var ketqua = cmd.ExecuteScalar();
                if (ketqua != DBNull.Value)
                {
                    doanhthubh = Convert.ToSingle(ketqua);
                }
            }
            return doanhthubh;
        }

        private void chartTuan_MouseMove(object sender, MouseEventArgs e)
        {
            // Lấy vị trí hit test
            HitTestResult result = chartTuan.HitTest(e.X, e.Y);
            // Kiểm tra nếu hit test là một điểm dữ liệu
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // Lấy chỉ số của điểm dữ liệu
                int pointIndex = result.PointIndex;
                DataPoint point = chartTuan.Series["Money"].Points[pointIndex];
                // Lấy thông tin ngày trong tuần và doanh thu
                string ngaytuan = point.AxisLabel;
                double doanhthu = point.YValues[0];
                // Thiết lập tooltip cho điểm dữ liệu
                point.ToolTip = $"{ngaytuan}\nDoanh thu: {doanhthu.ToString("N0")}";
            }
        }

        private void chartThang_MouseMove(object sender, MouseEventArgs e)
        {
            // Lấy vị trí hit test
            HitTestResult result = chartThang.HitTest(e.X, e.Y);
            // Kiểm tra nếu hit test là một điểm dữ liệu
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // Lấy chỉ số của điểm dữ liệu
                int pointIndex = result.PointIndex;
                DataPoint point = chartThang.Series["Money"].Points[pointIndex];
                // Lấy thông tin ngày trong tuần và doanh thu
                string ngaythang = point.AxisLabel;
                double doanhthu = point.YValues[0];
                // Thiết lập tooltip cho điểm dữ liệu
                point.ToolTip = $"{ngaythang}\nDoanh thu: {doanhthu.ToString("N0")}";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormChung_Load(sender, e);
        }
    }
}
