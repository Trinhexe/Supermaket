using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Supermaket
{
    public static class MainClass
    {
        static string KN = "Data Source=.;Initial Catalog=SieuThi;Integrated Security=True;Encrypt=False";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(KN);
        }
        private static string ten;
        private static string chucvu;
        private static int manv;
        public static string HoTen
        {
            get { return ten; }
            set { ten = value; }
        }
        public static string ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
        public static int MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        public static bool ChiTietNV(string tk, string mk)
        {
            bool ktr = false;
            string sql = "SELECT MANV,TENCV,HOVATEN FROM NHANVIEN INNER JOIN CHUCVU ON NHANVIEN.MACV = CHUCVU.MACV " +
                         "WHERE (TAIKHOAN = '"+tk+"' and MATKHAU = '"+mk+"') AND TRANGTHAI = 1";
            SqlCommand cmd = new SqlCommand(sql,MainClass.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 1)
            {
                ten = ds.Tables[0].Rows[0]["HOVATEN"].ToString();
                chucvu = ds.Tables[0].Rows[0]["TENCV"].ToString();
                manv = int.Parse(ds.Tables[0].Rows[0]["MaNV"].ToString());
                ktr = true;
            }    
            return ktr;
        }
        public static float DoanhThuNgay()
        {
            float doanhthu = 0;
            using (SqlConnection connection = MainClass.GetConnection())
            {
                connection.Open(); 
                string sql = "SELECT SUM(TONGTIEN)FROM HOADON WHERE CONVERT(date,NGAYLAPHOADON) = CONVERT(date,GETDATE())";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var ketqua = cmd.ExecuteScalar();
                if (ketqua != DBNull.Value)
                {
                    doanhthu = Convert.ToSingle(ketqua);
                }
            }
            return doanhthu;
        }
        public static double DoanhThuBanHang()
        {
            double doanhthu = 0;
            using (SqlConnection connection = MainClass.GetConnection())
            {
                connection.Open();
                string sql = "SELECT SUM(TONGTIEN)FROM HOADON ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var ketqua = cmd.ExecuteScalar();
                if (ketqua != DBNull.Value)
                {
                    doanhthu = Convert.ToSingle(ketqua);
                }
            }
            return doanhthu;
        }
        public static double DoanhThuXuatHang()
        {
            double doanhthu = 0;
            using (SqlConnection connection = MainClass.GetConnection())
            {
                connection.Open();
                string sql = "SELECT SUM(TONGTIEN)FROM HDXUATHANG ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                var ketqua = cmd.ExecuteScalar();
                if (ketqua != DBNull.Value)
                {
                    doanhthu = Convert.ToSingle(ketqua);
                }
            }
            return doanhthu;
        }
        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = FormMain.Instance.Size;
                Background.Location = FormMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }
    }
}
