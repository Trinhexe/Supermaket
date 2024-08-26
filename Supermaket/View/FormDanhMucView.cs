using Supermaket.Model;
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
    public partial class FormDanhMucView : MauView
    {
        public static SqlConnection connection;
        
        public FormDanhMucView()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY TENDM) AS 'STT',TENDM,MADM,MOTA from DANHMUC where TENDM LIKE
            N'%" + txtTk.Text + "%'"+
            "AND TRANGTHAI = 1";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[1].HeaderText = "Tên danh mục";
            data.Columns[2].HeaderText = "Mã danh mục";
            data.Columns[3].HeaderText = "Ghi chú";
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            FormDanhMucAdd add = new FormDanhMucAdd();
            add.ShowDialog();
            LoadData();
        }

        public override void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        public override void data_DoubleClick(object sender, EventArgs e)
        {
            FormDanhMucAdd themdm = new FormDanhMucAdd();
            themdm.id = Convert.ToInt32(data.CurrentRow.Cells["MADM"].Value);
            themdm.txtTenDM.Text = data.CurrentRow.Cells["TENDM"].Value.ToString();
            themdm.rtxtboxDM.Text = data.CurrentRow.Cells["MOTA"].Value.ToString();
            themdm.ShowDialog();
            LoadData();
        }

        private void FormKhachHangView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

       

        private void FormDanhMucView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
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
    }
}
