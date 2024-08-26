using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Supermaket.Add.Kho.NhapHang;

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
            FormHoaDonNH formHoaDonNH = new FormHoaDonNH();
            formHoaDonNH.id = cbxMaHDNP.SelectedIndex;
            formHoaDonNH.cbxHDNHrp.Enabled = false;
            formHoaDonNH.ShowDialog();
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
                    cmd.Parameters.AddWithValue("@TONGTIEN", double.Parse(txtTong.Text));
                    cmd.ExecuteNonQuery();
                }
                foreach (DataGridViewRow row in data.Rows)
                {
                    int masp = int.Parse(row.Cells["Mã SP"].Value.ToString());
                    int soluong = int.Parse(row.Cells["Số lượng"].Value.ToString());
                    double gia = double.Parse(row.Cells["Giá Nhập"].Value.ToString());
                    double thanhtien = double.Parse(row.Cells["Thành tiền"].Value.ToString());
                    string sql1 = "INSERT INTO CTNHAPHANG (MANHAPHANG,IDSP,SOLUONG,GIANH,THANHTIEN)VALUES(@MAHD,@masp,@soluong,@gia,@thanhtien)";
                    SqlCommand cmd = new SqlCommand(sql1, connection);
                    cmd.Parameters.AddWithValue("@MAHD", cbxMaHDNP.SelectedValue);
                    cmd.Parameters.AddWithValue("@masp", masp);
                    cmd.Parameters.AddWithValue("@soluong", soluong);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.Parameters.AddWithValue("@thanhtien", thanhtien);
                    cmd.ExecuteNonQuery();

                    string sl2 = "UPDATE SANPHAM SET GIANHAP = @GIANHAP WHERE IDSP = @IDSP";
                    SqlCommand cmd2 = new SqlCommand(sl2, connection);
                    cmd2.Parameters.AddWithValue("@IDSP", masp);
                    cmd2.Parameters.AddWithValue("@GIANHAP", gia);
                    cmd2.ExecuteNonQuery();
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
            data.Columns[0].Width = 50;
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
            double thanhtien = 0;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string columnName = data.Columns[e.ColumnIndex].Name;

                if (columnName == "Số lượng" || columnName == "Giá Nhập")
                {
                    if (double.TryParse(data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out _))
                    {
                        int rowIndex = e.RowIndex;
                        int soLuong = Convert.ToInt32(data.Rows[rowIndex].Cells["Số lượng"].Value);
                        float gia = Convert.ToSingle(data.Rows[rowIndex].Cells["Giá Nhập"].Value);
                        if (soLuong == 0 || gia == 0)
                        {
                            if (soLuong == 0)
                            {
                                MessageBox.Show("Số lượng không thể bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                            }
                            if (gia == 0)
                            {
                                MessageBox.Show("Giá không thể = 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                            }
                        }
                        else
                        {
                            thanhtien = soLuong * gia;
                            data.Rows[rowIndex].Cells["Thành tiền"].Value = thanhtien;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào cột số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                    }
                }
            }
            TongTien();
        }
        private void TongTien()
        {
            double total = 0;
            txtTong.Text = "";
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Cells["Thành tiền"].Value != null)  
                {
                    total += double.Parse(row.Cells["Thành tiền"].Value.ToString());
                }
            }
            txtTong.Text = total.ToString("N0");
        }

        private void data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (data.Columns[e.ColumnIndex].Name == "Giá Nhập" && e.Value != null)
            {
                double dongia;
                if (double.TryParse(e.Value.ToString(), out dongia))
                {
                    e.Value = dongia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
            if (data.Columns[e.ColumnIndex].Name == "Thành tiền" && e.Value != null)
            {
                double dongia;
                if (double.TryParse(e.Value.ToString(), out dongia))
                {
                    e.Value = dongia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

   
    }
}
