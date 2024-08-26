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
using Supermaket.Add.Kho;
using Supermaket.Add.Kho.XuatHang;

namespace Supermaket.View.Kho.XuatHang
{
    public partial class FormCTXH : Mau
    {
        public static SqlConnection connection;
        public FormCTXH()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "UPDATE HDXUATHANG SET MAKH = @MAKH,TONGTIEN = @TONGTIEN,NGAYXUAT=@NGAYXUAT WHERE MAXUATHANG = @MAXUATHANG";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MAXUATHANG", cbxMaHDXH.SelectedValue);
                cmd.Parameters.AddWithValue("@NGAYXUAT", dtpNgayLHD.Value);
                if (txtKH.Text == "")
                {
                    cmd.Parameters.AddWithValue("@MAKH", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MAKH", int.Parse(txtKH.Text));
                }
                cmd.Parameters.AddWithValue("@TONGTIEN", double.Parse(txtTong.Text));
                cmd.ExecuteNonQuery();
                bool ktr = true;
                foreach (DataGridViewRow row in data.Rows)
                {
                    int stt = int.Parse(row.Cells["STT"].Value.ToString());
                    int soluong = int.Parse(row.Cells["Số lượng"].Value.ToString());
                    int slton = int.Parse(row.Cells["SL Tồn"].Value.ToString());
                    if (soluong > slton)
                    {
                        ktr = false;
                        MessageBox.Show($"Dòng thứ {stt} số lượng xuất vượt quá mức sản phẩm tồn kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
                if (ktr)
                {
                    foreach (DataGridViewRow row in data.Rows)
                    {
                        int masp = int.Parse(row.Cells["Mã SP"].Value.ToString());
                        int soluong = int.Parse(row.Cells["Số lượng"].Value.ToString());
                        float gia = float.Parse(row.Cells["Giá Xuất"].Value.ToString());
                        double thanhtien = double.Parse(row.Cells["Thành tiền"].Value.ToString());
                        string sql1 = "INSERT INTO CTXUATHANG (MAXUATHANG,IDSP,SOLUONG,GIAXH,THANHTIEN)VALUES(@MAHD,@masp,@soluong,@gia,@thanhtien)";
                        SqlCommand cmd2 = new SqlCommand(sql1, connection);
                        cmd2.Parameters.AddWithValue("@MAHD", cbxMaHDXH.SelectedValue);
                        cmd2.Parameters.AddWithValue("@masp", masp);
                        cmd2.Parameters.AddWithValue("@soluong", soluong);
                        cmd2.Parameters.AddWithValue("@gia", gia);
                        cmd2.Parameters.AddWithValue("@thanhtien", thanhtien);
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLuu.Enabled = false;
                    btnIn.Enabled = true;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            FormHoaDonXH frxh = new FormHoaDonXH();
            frxh.id = cbxMaHDXH.SelectedIndex;
            frxh.cbxHDXHrp.Enabled = false;
            frxh.ShowDialog();
        }
        private void Load_CBXHD()
        {
            string sql = "select MAXUATHANG from HDXUATHANG ORDER BY MAXUATHANG DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxMaHDXH.DataSource = ds;
            cbxMaHDXH.DisplayMember = "MAXUATHANG";
            cbxMaHDXH.ValueMember = "MAXUATHANG";
        }
        public void LoadData()
        {

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY HOVATEN) AS 'STT',HoVaTen,SĐT,DIEMTICHLUY,LOAIKH,MAKH from KHACHHANG where HOVATEN LIKE N'%" + txtTk.Text + "%' OR SĐT LIKE '%" + txtTk.Text + "%'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data1.DataSource = dt;
            data1.Columns[0].HeaderText = "STT";
            data1.Columns[0].Width = 50;
            data1.Columns[1].HeaderText = "Họ và tên";
            data1.Columns[2].HeaderText = "SĐT";
            data1.Columns[3].HeaderText = "Điểm";
            data1.Columns[4].HeaderText = "Loại KH";
            data1.Columns[5].HeaderText = "Mã khách";
            data1.AllowUserToAddRows = false;
            data1.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        private void FormCTXH_Load(object sender, EventArgs e)
        {
            LoadData();
            Load_CBXHD();
            data1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            data.Columns[0].Width = 50;
        }

        private void data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKH.Text = data1.CurrentRow.Cells["MAKH"].Value.ToString();
        }

        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double thanhtien = 0;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string columnName = data.Columns[e.ColumnIndex].Name;

                if (columnName == "Số lượng" || columnName == "Giá Xuất")
                {
                    if (double.TryParse(data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out _))
                    {
                        int rowIndex = e.RowIndex;
                        int soLuong = Convert.ToInt32(data.Rows[rowIndex].Cells["Số lượng"].Value);
                        float gia = Convert.ToSingle(data.Rows[rowIndex].Cells["Giá Xuất"].Value);
                        if (soLuong == 0 )
                        {
                            if (soLuong == 0)
                            {
                                MessageBox.Show("Số lượng không thể bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Vui lòng chỉ nhập số vào cột số lượng và giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (data.Columns[e.ColumnIndex].Name == "Giá Xuất" && e.Value != null)
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
