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

namespace Supermaket.View.ThungRac
{
    public partial class FormThungRacView2 : Mau
    {
        public static SqlConnection connection;
        public FormThungRacView2()
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
                        "AND NHANVIEN.TRANGTHAI = 0";
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
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if(connection.State == ConnectionState.Closed)
                connection.Open();
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                // Lấy giá trị của trường MANV từ mỗi dòng đã chọn
                string manv = row.Cells["dgvidnv"].Value.ToString();
                // Sử dụng giá trị MANV trong câu lệnh SQL DELETE
                string sql = "UPDATE NHANVIEN SET TRANGTHAI = 1 WHERE MANV = @manv";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.ExecuteNonQuery();
            }
            LoadData();
            connection.Close();
        }

        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormThungRacView2_Load(object sender, EventArgs e)
        {
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            LoadData();
        }
    }
}
