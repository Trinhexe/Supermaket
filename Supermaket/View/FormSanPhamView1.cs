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
    public partial class FormSanPhamView1 : MauView
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
            string sql = @"select ROW_NUMBER() OVER (ORDER BY TENSP) AS 'STT',TENSP,IDSP,SanPham.MoTa,DONGIA, TENNCC, TENDM, SOLUONGTON, NGAYSX, NGAYHH,HINHANH,TENKM
                        from SANPHAM INNER JOIN DANHMUC ON SANPHAM.MADM = DANHMUC.MADM
                                    INNER JOIN NHACUNGCAP ON NHACUNGCAP.MANCC = SANPHAM.MANCC 
                                    INNER JOIN KHUYENMAI ON SANPHAM.MAKM = KHUYENMAI.MAKM
                        WHERE TENSP LIKE 
                        N'%" + txtTk.Text + "%'" +
                        "AND SANPHAM.TRANGTHAI = 1";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 40;
            data.Columns[1].HeaderText = "Tên sản phẩm";
            data.Columns[1].Width = 250;
            data.Columns[2].HeaderText = "id";
            data.Columns[2].Name = "dgvid";
            data.Columns[2].Visible = false;
            data.Columns[3].HeaderText = "Mô tả";
            data.Columns[3].Width = 150;
            data.Columns[4].HeaderText = "Giá";
            data.Columns[4].Width = 150;
            data.Columns[5].HeaderText = "Tên nhà cung cấp";
            data.Columns[5].Width = 200;
            data.Columns[6].HeaderText = "Tên danh mục";
            data.Columns[6].Width = 100;
            data.Columns[7].HeaderText = "Số lượng";
            data.Columns[7].Width = 80;
            data.Columns[8].HeaderText = "Ngày sản xuất";
            data.Columns[8].Width = 100;
            data.Columns[9].HeaderText = "Ngày hết hạn";
            data.Columns[9].Width = 200;
            data.Columns[10].Name = "dgvanh";
            data.Columns[10].Visible = false;
            data.Columns[11].Name = "TENKM";
            data.Columns[11].Visible = false;
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            FormSanPhamAdd add = new FormSanPhamAdd();
            add.ShowDialog();
            LoadData();
        }

        public override void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        public override void data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (data.Columns[e.ColumnIndex].Name == "DONGIA" && e.Value != null)
            {
                decimal dongia;
                if (decimal.TryParse(e.Value.ToString(), out dongia))
                {
                    e.Value = dongia.ToString("N0") + " VND";
                    e.FormattingApplied = true;
                }
            }
        }

        public override void data_DoubleClick(object sender, EventArgs e)
        {
            FormSanPhamAdd themsp = new FormSanPhamAdd();
            themsp.id = Convert.ToInt32(data.CurrentRow.Cells["dgvid"].Value);
            themsp.txtTenSP.Text = data.CurrentRow.Cells["TENSP"].Value.ToString();
            themsp.txtGia.Text = data.CurrentRow.Cells["DONGIA"].Value.ToString();
            themsp.rtxtboxMoTa.Text = data.CurrentRow.Cells["MOTA"].Value.ToString();
            themsp.cbxNCC.Text = data.CurrentRow.Cells["TENNCC"].Value.ToString();
            themsp.cbxMaKM.Text = data.CurrentRow.Cells["TENKM"].Value.ToString();
            themsp.cbxMaDM.Text = data.CurrentRow.Cells["TENDM"].Value.ToString();
            themsp.dtpNgaySX.Value = (DateTime)data.CurrentRow.Cells["NGAYSX"].Value;
            themsp.dtpNgayHH.Value = (DateTime)data.CurrentRow.Cells["NGAYHH"].Value;
            byte[] imageData = (byte[])data.CurrentRow.Cells["dgvanh"].Value;
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                themsp.txtpic.Image = Image.FromStream(ms);
            }
            themsp.ShowDialog();
            LoadData();
        }

        private void FormSanPhamView1_Load(object sender, EventArgs e)
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
    }
}
