using Supermaket.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Supermaket.View
{
    public partial class FormNhanVienView :MauView
    {
        public static SqlConnection connection;
        public FormNhanVienView()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY HOVATEN) AS 'STT',HOVATEN,TAIKHOAN,MATKHAU, NGAYSINH,
                        (CASE
                        WHEN(GIOITINH =1) THEN N'Nam' 
                        WHEN(GIOITINH = 0) THEN N'Nữ'
                        end)as Phai, DIACHI,EMAIL, SDT, TENCV,MANV
                        from NHANVIEN INNER JOIN CHUCVU ON CHUCVU.MACV = NHANVIEN.MACV
                        WHERE HOVATEN LIKE 
                        N'%" + txtTk.Text + "%'" +
                        "AND NHANVIEN.TRANGTHAI = 1";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 50;
            data.Columns[1].HeaderText = "Họ và tên";
            data.Columns[2].HeaderText = "Tài khoản";
            data.Columns[3].Visible = false;
            data.Columns[4].HeaderText = "Ngày sinh";
            data.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.Columns[5].HeaderText = "Phái";
            data.Columns[6].HeaderText = "Địa chỉ";
            data.Columns[7].HeaderText = "Gmail";
            data.Columns[8].HeaderText = "SĐT";
            data.Columns[9].HeaderText = "Chức vụ";
            data.Columns[10].Name = "dgvidnv";
            data.Columns[10].Visible = false;
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            FormNhanVienAdd add = new FormNhanVienAdd();
            add.ShowDialog();
            LoadData();
        }
        public override void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        public override void data_DoubleClick(object sender, EventArgs e)
        {
            FormNhanVienAdd themnv = new FormNhanVienAdd();
            themnv.id = Convert.ToInt32(data.CurrentRow.Cells["dgvidnv"].Value);
            themnv.txtHoTennv.Text = data.CurrentRow.Cells["Hovaten"].Value.ToString();
            themnv.txtTK.Text = data.CurrentRow.Cells["TAIKHOAN"].Value.ToString();
            themnv.tk1 = data.CurrentRow.Cells["TAIKHOAN"].Value.ToString();
            themnv.txtMk.Text = data.CurrentRow.Cells["MATKHAU"].Value.ToString();
            themnv.dtpngaysinhnv.Value = (DateTime)data.CurrentRow.Cells["NgaySinh"].Value;
            if (data.CurrentRow.Cells["PHAI"].Value.ToString() == "Nam")
            {
                themnv.ckNam.Checked = true;
            }    
            else
            {
                themnv.ckNu.Checked = true;
            }    
            themnv.txtDiaChinv.Text = data.CurrentRow.Cells["DIACHI"].Value.ToString();
            themnv.txtSDTnv.Text = data.CurrentRow.Cells["SDT"].Value.ToString();
            themnv.sdt = data.CurrentRow.Cells["SDT"].Value.ToString();
            themnv.txtgmailnv.Text = data.CurrentRow.Cells["email"].Value.ToString();
            themnv.gmail = data.CurrentRow.Cells["email"].Value.ToString();
            themnv.cbxChucVu.Text = data.CurrentRow.Cells["TENCV"].Value.ToString();
            themnv.ShowDialog();
            LoadData();
        }

        public void FormNhanVienView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                string ma = row.Cells["MADM"].Value.ToString();
                string checkSql = "SELECT COUNT(*) FROM SANPHAM WHERE MADM = @MADM";
                SqlCommand checkCmd = new SqlCommand(checkSql, connection);
                checkCmd.Parameters.AddWithValue("@MADM", ma);
                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    string sql = "DELETE DANHMUC WHERE MADM = @MADM";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MADM", ma);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xóa được vì đang có sản phầm nằm trong danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadData();
            connection.Close();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                // Lấy giá trị của trường MASV từ mỗi dòng đã chọn
                string manv = row.Cells["dgvidnv"].Value.ToString();
                // Sử dụng giá trị MASV trong câu lệnh SQL DELETE
                string sql = "UPDATE NHANVIEN SET TRANGTHAI = 0 WHERE MANV = @manv";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.ExecuteNonQuery();
            }
            LoadData();
            connection.Close();
        }
    }
}