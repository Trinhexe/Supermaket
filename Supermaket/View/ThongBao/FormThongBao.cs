using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermaket.View.ThongBao
{
    public partial class FormThongBao : Mau
    {
        public static SqlConnection connection;
        public FormThongBao()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadSP()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"SELECT IDSP, TENSP, NGAYHH, HINHANH
                         FROM SANPHAM
                         WHERE DATEDIFF(day, GETDATE(), NGAYHH) BETWEEN 1 AND 60
                         ORDER BY NGAYHH ASC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                Byte[] ImageArray = (byte[])(row["HINHANH"]);
                byte[] ImageByteArray = ImageArray;
                AddItems(row["IDSP"].ToString(), row["TENSP"].ToString(), row["NGAYHH"].ToString(), Image.FromStream(new MemoryStream(ImageArray)));
            }
        }
        private void AddItems(string masp, string tensp, string ngayhh,Image anh)
        {
            try
            {
                var w = new UserTB()
                {
                   masp = masp,
                   tensp = tensp,
                   hh = ngayhh,
                   anh = anh
                };
                flowLayoutPanel1.Controls.Add(w);

            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }


        }

        private void FormThongBao_Load(object sender, EventArgs e)
        {
            LoadSP();
        }
    }
}
