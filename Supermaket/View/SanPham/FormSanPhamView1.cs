using Supermaket.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermaket.View
{
    public partial class FormSanPhamView1 : Mau
    {
        public static SqlConnection connection;
        
        public FormSanPhamView1()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY IDSP DESC) AS 'STT',TENSP,IDSP,SanPham.MoTa,GIANHAP,DONGIA,GIAKM ,TENNCC, TENDM, SOLUONGTON, NGAYSX, NGAYHH,HINHANH,SANPHAM.GIAMGIA,TENKM,MABAR,BARCODE
                        from SANPHAM LEFT JOIN DANHMUC ON SANPHAM.MADM = DANHMUC.MADM
                                    LEFT JOIN NHACUNGCAP ON NHACUNGCAP.MANCC = SANPHAM.MANCC 
                                    LEFT JOIN KHUYENMAI ON SANPHAM.MAKM = KHUYENMAI.MAKM
                        WHERE (TENSP LIKE N'%" + txtTk.Text + "%' OR TENDM LIKE N'%" + txtTk.Text + "%')" +
                        "AND SANPHAM.TRANGTHAI = 1" +
                        "AND SOLUONGTON > 0";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 50;
            data.Columns[1].HeaderText = "Tên sản phẩm";
            data.Columns[1].Width = 200;
            data.Columns[2].HeaderText = "id";
            data.Columns[2].Name = "dgvid";
            data.Columns[2].Visible = false;
            data.Columns[3].HeaderText = "Mô tả";
            data.Columns[3].Visible = false;
            data.Columns[4].HeaderText = "Giá nhập";
            data.Columns[4].Width = 150;
            data.Columns[5].HeaderText = "Giá gốc";
            data.Columns[5].Width = 150;
            data.Columns[6].HeaderText = "Giá bán";
            data.Columns[6].Width = 150;
            data.Columns[7].HeaderText = "Nhà cung cấp";
            data.Columns[7].Width = 200;
            data.Columns[8].HeaderText = "Danh mục";
            data.Columns[8].Width = 150;
            data.Columns[9].HeaderText = "Số lượng";
            data.Columns[9].Width = 100;
            data.Columns[10].HeaderText = "Ngày sản xuất";
            data.Columns[10].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.Columns[10].Width = 150;
            data.Columns[11].HeaderText = "Ngày hết hạn";
            data.Columns[11].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.Columns[11].Width = 150;
            data.Columns[12].Name = "dgvanh";
            data.Columns[12].Visible = false;
            data.Columns[13].Name = "dgvGG";
            data.Columns[13].Visible = false;
            data.Columns[14].Name = "dgvKMGG";
            data.Columns[14].Visible = false;
            data.Columns[15].Name = "dgvMaBar";
            data.Columns[15].Visible = false;
            data.Columns[16].Name = "dgvBarCode";
            data.Columns[16].Visible = false;
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        private void FormSanPhamView1_Load(object sender, EventArgs e)
        {
            LoadData();
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }
        private void txtTk_TextChanged_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                // Lấy giá trị của trường MASV từ mỗi dòng đã chọn
                string masp = row.Cells["dgvid"].Value.ToString();
                // Sử dụng giá trị MASV trong câu lệnh SQL DELETE
                string sql = "UPDATE SANPHAM SET TRANGTHAI = 0 WHERE IDSP = @masp";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@masp", masp);
                cmd.ExecuteNonQuery();
            }
            LoadData();
            connection.Close();
        }

        private void data_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (data.Columns[e.ColumnIndex].Name == "DONGIA" && e.Value != null)
            {
                decimal dongia;
                if (decimal.TryParse(e.Value.ToString(), out dongia))
                {
                    e.Value = dongia.ToString("N0")+" VND";
                    e.FormattingApplied = true;
                }
            }
            if (data.Columns[e.ColumnIndex].Name == "GIAKM" && e.Value != null)
            {
                decimal dongia;
                if (decimal.TryParse(e.Value.ToString(), out dongia))
                {
                    e.Value = dongia.ToString("N0")+" VND";
                    e.FormattingApplied = true;
                }
            }
            if (data.Columns[e.ColumnIndex].Name == "GIANHAP" && e.Value != null)
            {
                decimal dongia;
                if (decimal.TryParse(e.Value.ToString(), out dongia))
                {
                    e.Value = dongia.ToString("N0") + " VND";
                    e.FormattingApplied = true;
                }
            }
        }

        private void data_DoubleClick_1(object sender, EventArgs e)
        {
            FormSanPhamAdd themsp = new FormSanPhamAdd();
            themsp.id = Convert.ToInt32(data.CurrentRow.Cells["dgvid"].Value);
            themsp.txtMaSp.Text = data.CurrentRow.Cells["dgvMaBar"].Value.ToString();
            themsp.txtTenSP.Text = data.CurrentRow.Cells["TENSP"].Value.ToString();
            themsp.txtGia.Text = data.CurrentRow.Cells["DONGIA"].Value.ToString();
            themsp.txtGiaNhap.Text = data.CurrentRow.Cells["GIANHAP"].Value.ToString();
            themsp.rtxtboxMoTa.Text = data.CurrentRow.Cells["MOTA"].Value.ToString();
            themsp.cbxNCC.Text = data.CurrentRow.Cells["TENNCC"].Value.ToString();
            themsp.cbxMaDM.Text = data.CurrentRow.Cells["TENDM"].Value.ToString();
            themsp.dtpNgaySX.Value = (DateTime)data.CurrentRow.Cells["NGAYSX"].Value;
            themsp.dtpNgayHH.Value = (DateTime)data.CurrentRow.Cells["NGAYHH"].Value;
            byte[] imageData = (byte[])data.CurrentRow.Cells["dgvanh"].Value;
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                themsp.txtpic.Image = Image.FromStream(ms);
            }
            byte[] imageData2 = (byte[])data.CurrentRow.Cells["dgvBarCode"].Value;
            using (MemoryStream ms = new MemoryStream(imageData2))
            {
                themsp.picbarcode.Image = Image.FromStream(ms);
            }    
            themsp.txtGiamGia.Text = ((double.Parse(data.CurrentRow.Cells["dgvGG"].Value.ToString())) * 100).ToString();
            themsp.txtKMPT.Text = data.CurrentRow.Cells["dgvKMGG"].Value.ToString();
            themsp.ShowDialog();
            LoadData();
        }
    }
}
