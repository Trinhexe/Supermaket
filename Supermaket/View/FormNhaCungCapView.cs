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
    public partial class FormNhaCungCapView : MauView
    {
        public static SqlConnection connection;
        
        public FormNhaCungCapView()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY TENNCC) AS 'STT',TENNCC,MANCC,DIACHI,EMAIL,SDT from NHACUNGCAP where TENNCC LIKE
            N'%" + txtTk.Text + "%'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[1].HeaderText = "Tên nhà cung cấp";
            data.Columns[2].HeaderText = "Mã nhà cung cấp";
            data.Columns[3].HeaderText = "Địa chỉ";
            data.Columns[4].HeaderText = "Email";
            data.Columns[5].HeaderText = "SĐT";
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            FormNCCADD add = new FormNCCADD();
            add.ShowDialog();
            LoadData();
        }

        public override void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        public override void data_DoubleClick(object sender, EventArgs e)
        {
            FormNCCADD themncc = new FormNCCADD();
            themncc.id = Convert.ToInt32(data.CurrentRow.Cells["mancc"].Value);
            themncc.txtncc.Text = data.CurrentRow.Cells["TENNCC"].Value.ToString();
            themncc.txtdiachi.Text = data.CurrentRow.Cells["DIACHI"].Value.ToString();
            themncc.txtGmail.Text = data.CurrentRow.Cells["EMAIL"].Value.ToString();
            themncc.txtSDT.Text = data.CurrentRow.Cells["SDT"].Value.ToString();
            themncc.ShowDialog();
            LoadData();
        }

        private void FormNhaCungCapView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                string ma = row.Cells["MANCC"].Value.ToString();
                string checkSql = "SELECT COUNT(*) FROM SANPHAM WHERE MANCC = @MANCC";
                SqlCommand checkCmd = new SqlCommand(checkSql, connection);
                checkCmd.Parameters.AddWithValue("@MANCC", ma);
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    string sql = "DELETE NHACUNGCAP WHERE MANCC = @MANCC";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MANCC", ma);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xóa được vì nhà cung cấp này đang cung cấp sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string ma = row.Cells["MANCC"].Value.ToString();
                string checkSql = "SELECT COUNT(*) FROM SANPHAM WHERE MANCC = @MANCC";
                SqlCommand checkCmd = new SqlCommand(checkSql, connection);
                checkCmd.Parameters.AddWithValue("@MANCC", ma);
                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    string sql = "DELETE NHACUNGCAP WHERE MANCC = @MANCC";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MANCC", ma);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xóa được vì nhà cung cấp này vẫn đang cung cấp sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadData();
            connection.Close();
        }
    }
}
