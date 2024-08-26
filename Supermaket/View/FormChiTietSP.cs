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

namespace Supermaket.View
{
    public partial class FormChiTietSP : Mau
    {
        public static SqlConnection connection;
        public FormChiTietSP()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public int idv = 0;

        private void FormChiTietSP_Load(object sender, EventArgs e)
        {
            if (idv > 0)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string sql = @"select TENSP,IDSP,SanPham.MoTa,DONGIA,GIAKM, TENNCC, TENDM, SOLUONGTON, NGAYSX, NGAYHH,HINHANH,TENKM,SANPHAM.GIAMGIA
                        from SANPHAM LEFT JOIN DANHMUC ON SANPHAM.MADM = DANHMUC.MADM
                                    LEFT JOIN NHACUNGCAP ON NHACUNGCAP.MANCC = SANPHAM.MANCC 
                                    LEFT JOIN KHUYENMAI ON SANPHAM.MAKM = KHUYENMAI.MAKM
                        WHERE IDSP = "+ idv +"";

                SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    lblTenSP.Text = row["TENSP"].ToString();
                    lblDonGia.Text = ((double)row["DONGIA"]).ToString("N0");
                    lblGiaKM.Text = ((double)row["GIAKM"]).ToString("N0");
                    lblTenKM.Text = row["TENKM"].ToString();
                    lblTenDm.Text = row["TENDM"].ToString();
                    lblNcc.Text = row["TENNCC"].ToString();
                    btnUserCtrPercent.Text = (100 - (double)row["GIAMGIA"]*100).ToString();
                    lblNgaySX.Text = ((DateTime)row["NGAYSX"]).ToString("dd-MM-yyyy");
                    lblNgayHH.Text = ((DateTime)row["NGAYHH"]).ToString("dd-MM-yyyy");
                    rtxtboxMoTa.Text = row["MOTA"].ToString();
                    byte[] imageData = (byte[])row["HINHANH"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }    
                connection.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
        
