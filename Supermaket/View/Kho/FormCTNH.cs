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

namespace Supermaket.View.Kho
{
    public partial class FormCTNH : Mau
    {
        public static SqlConnection connection;
        public FormCTNH()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "UPDATE HDNHAPHANG SET TONGTIEN = @TONGTIEN,NGAYNHAP=@NGAYNHAP WHERE MANHAPHANG = @MANHAPHANG";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@MANHAPHANG", cbxMaHDNP.SelectedValue);
                    cmd.Parameters.AddWithValue("@NGAYNHAP", dtpNgayLHD.Value);
                    cmd.Parameters.AddWithValue("@TONGTIEN", float.Parse(txtTong.Text));
                    cmd.ExecuteNonQuery();
                }
                foreach (DataGridViewRow row in data.Rows)
                {
                    if (row.Cells["Mã SP"].Value == null)
                    {
                        data.Rows.Remove(row);
                    }
                    int masp = int.Parse(row.Cells["Mã SP"].Value.ToString());
                    int soluong = int.Parse(row.Cells["Số lượng"].Value.ToString());
                    float gia = float.Parse(row.Cells["Giá Nhập"].Value.ToString());
                    float thanhtien = float.Parse(row.Cells["Thành tiền"].Value.ToString());
                    string sql1 = "INSERT INTO CTNHAPHANG (MANHAPHANG,IDSP,SOLUONG,GIANH,THANHTIEN)VALUES(@MAHD,@masp,@soluong,@gia,@thanhtien)";
                    SqlCommand cmd = new SqlCommand(sql1, connection);
                    cmd.Parameters.AddWithValue("@MAHD", cbxMaHDNP.SelectedValue);
                    cmd.Parameters.AddWithValue("@masp", masp);
                    cmd.Parameters.AddWithValue("@soluong", soluong);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.Parameters.AddWithValue("@thanhtien", thanhtien);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnIn.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCTNH_Load(object sender, EventArgs e)
        {
            Load_CBXHD();
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }
        private void Load_CBXHD()
        {
            string sql = "select MANHAPHANG from HDNHAPHANG ORDER BY MANHAPHANG DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxMaHDNP.DataSource = ds;
            cbxMaHDNP.DisplayMember = "MANHAPHANG";
            cbxMaHDNP.ValueMember = "MANHAPHANG";
        }



        private void data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            float thanhtien = 0;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string columnName = data.Columns[e.ColumnIndex].Name;

                if (columnName == "Số lượng" || columnName == "Giá Nhập")
                {
                    int rowIndex = e.RowIndex;
                    int soLuong = Convert.ToInt32(data.Rows[rowIndex].Cells["Số lượng"].Value);
                    float gia = Convert.ToSingle(data.Rows[rowIndex].Cells["Giá Nhập"].Value);
                    thanhtien = soLuong * gia;
                    data.Rows[rowIndex].Cells["Thành tiền"].Value = thanhtien;
                }
            }
            TongTien();
        }
        private void TongTien()
        {
            float total = 0;
            txtTong.Text = "";
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Cells["Thành tiền"].Value != null)  
                {
                    total += float.Parse(row.Cells["Thành tiền"].Value.ToString());
                }
            }
            txtTong.Text = total.ToString("N0");
        }



    }
}
