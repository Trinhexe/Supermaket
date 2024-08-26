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

namespace Supermaket.View
{
    public partial class FormThungRacView1 : Mau
    {
        public static SqlConnection connection;
        public FormThungRacView1()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY TENSP) AS 'STT',TENSP,IDSP,SanPham.MoTa, FORMAT(DONGIA, 'N0') + ' VND' as DONGIA, TENNCC, TENDM, SOLUONGTON, NGAYSX, NGAYHH,HINHANH,TENKM
                        from SANPHAM INNER JOIN DANHMUC ON SANPHAM.MADM = DANHMUC.MADM
                                    INNER JOIN NHACUNGCAP ON NHACUNGCAP.MANCC = SANPHAM.MANCC 
                                    INNER JOIN KHUYENMAI ON SANPHAM.MAKM = KHUYENMAI.MAKM
                        WHERE TENSP LIKE 
                        N'%" + txtTk.Text + "%'" +
                        "AND SANPHAM.TRANGTHAI = 0";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 40;
            data.Columns[1].HeaderText = "Tên sản phẩm";
            data.Columns[1].Width = 200;
            data.Columns[2].HeaderText = "id";
            data.Columns[2].Name = "dgvid";
            data.Columns[2].Visible = false;
            data.Columns[3].HeaderText = "Mô tả";
            data.Columns[3].Width = 200;
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

        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                string ma = row.Cells["dgvid"].Value.ToString();
                string checkSql = "SELECT COUNT(*) FROM CTHOADON WHERE IDSP  = @dgvid";
                SqlCommand checkCmd = new SqlCommand(checkSql, connection);
                checkCmd.Parameters.AddWithValue("@dgvid", ma);
                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    string sql = "DELETE SANPHAM WHERE IDSP = @dgvid";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@dgvid", ma);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa không thành công vì bất đồng độ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadData();
            connection.Close();
        }

        private void FormThungRacView1_Load(object sender, EventArgs e)
        {
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            LoadData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                // Lấy giá trị của trường MASV từ mỗi dòng đã chọn
                string masp = row.Cells["dgvid"].Value.ToString();
                // Sử dụng giá trị MASV trong câu lệnh SQL DELETE
                string sql = "UPDATE SANPHAM SET TRANGTHAI = 1 WHERE IDSP = @masp";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@masp", masp);
                cmd.ExecuteNonQuery();
            }
            LoadData();
            connection.Close();
        }
    }
}
