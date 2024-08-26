using Supermaket.Model;
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
    public partial class FormKhuyenMaiView : MauView
    {
        public static SqlConnection connection;
        public FormKhuyenMaiView()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            FormKhuyenMaiAdd add = new FormKhuyenMaiAdd();
            add.ShowDialog();
            LoadData();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY TenKM) AS 'STT',MAKM,TENKM,NGAYBATDAU,NGAYKETTHUC,GIAMGIA
            FROM KHUYENMAI
            WHERE TENKM LIKE 
            N'%" + txtTk.Text + "%'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 50;
            data.Columns[1].HeaderText = "Mã khuyến mãi";
            data.Columns[2].HeaderText = "Tên khuyến mãi";
            data.Columns[3].HeaderText = "Ngày bắt đầu";
            data.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.Columns[4].HeaderText = "Ngày kết thúc";
            data.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.Columns[5].HeaderText = "Giảm giá";
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }

        public override void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        public override void data_DoubleClick(object sender, EventArgs e)
        {
            FormKhuyenMaiAdd themkm = new FormKhuyenMaiAdd();
            themkm.id = Convert.ToInt32(data.CurrentRow.Cells["MAKM"].Value);
            themkm.txtTenKM.Text = data.CurrentRow.Cells["TENKM"].Value.ToString();
            themkm.txtGiamGia.Text = ((double.Parse(data.CurrentRow.Cells["GIAMGIA"].Value.ToString())) * 100).ToString(); ;
            themkm.dtpNgayBD.Value = (DateTime)data.CurrentRow.Cells["NGAYBATDAU"].Value;
            themkm.dtpNgayKT.Value = (DateTime)data.CurrentRow.Cells["NGAYKETTHUC"].Value;
            themkm.ShowDialog();
            LoadData();
        }

        private void FormKhuyenMaiView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                string ma = row.Cells["MAKM"].Value.ToString();
                string checkSql = "SELECT COUNT(*) FROM SANPHAM WHERE MAKM = @MAKM";
                SqlCommand checkCmd = new SqlCommand(checkSql, connection);
                checkCmd.Parameters.AddWithValue("@MAKM", ma);
                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    string sql = "DELETE KHUYENMAI WHERE MAKM = @MAKM";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MAKM", ma);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xóa được khuyến mãi vì đang có sản phẩm được khuyến mãi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadData();
            connection.Close();
        }
    }
}
