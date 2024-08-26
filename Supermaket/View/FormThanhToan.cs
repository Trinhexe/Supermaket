using Supermaket.Model;
using Supermaket.View.TrangChu;
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
    public partial class FormThanhToan : Mau
    {

        public FormPos pos = new FormPos();
        public static SqlConnection connection;
        public FormThanhToan()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public float tienmat = 0;
        public float tienthoi = 0;
        public float tong = 0;
        public int id = 0;
        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
            Load_CBXHD();
            txtTong.Text = tong.ToString("N0");
            txtTra.Text = tienmat.ToString("N0");
            txtThoi.Text = tienthoi.ToString("N0");
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            data1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            data.Columns[0].Width = 50;
        }
        private void Load_CBXHD()
        {
            string sql = "select MAHD from HOADON ORDER BY MAHD DESC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxMaHD.DataSource = ds;
            cbxMaHD.DisplayMember = "MAHD";
            cbxMaHD.ValueMember = "MAHD";
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql =@"select ROW_NUMBER() OVER (ORDER BY HOVATEN) AS 'STT',HoVaTen,SĐT,DIEMTICHLUY,LOAIKH,MAKH from KHACHHANG where HOVATEN LIKE N'%" + txtTk.Text + "%' OR SĐT LIKE '%" + txtTk.Text + "%'";
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

        private void data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKH.Text = data1.CurrentRow.Cells["MAKH"].Value.ToString();
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
                string sql = "UPDATE HOADON SET MAKH = @MAKH,TONGTIEN = @TONGTIEN,TIENMAT=@TIENMAT,TIENTHOI=@TIENTHOI,NGAYLAPHOADON=@NGAYLAPHOADON WHERE MAHD = @MAHD";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@MAHD", cbxMaHD.SelectedValue);
                    if (txtKH.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@MAKH", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MAKH", int.Parse(txtKH.Text));
                    }
                    cmd.Parameters.AddWithValue("@TONGTIEN", tong);
                    cmd.Parameters.AddWithValue("@TIENMAT", tienmat);
                    cmd.Parameters.AddWithValue("@TIENTHOI",tienthoi);
                    cmd.Parameters.AddWithValue("@NGAYLAPHOADON", dtpNgayLHD.Value);
                    cmd.ExecuteNonQuery();
                }
                
                foreach (DataGridViewRow row in data.Rows)
                {
                        int masp = int.Parse(row.Cells["Mã SP"].Value.ToString());
                        int soluong = int.Parse(row.Cells["Số lượng"].Value.ToString());
                        float gia = float.Parse(row.Cells["Đơn giá"].Value.ToString());
                        float thanhtien = float.Parse(row.Cells["Thành tiền"].Value.ToString());
                        string sql1 = "INSERT INTO CTHOADON (MAHD,IDSP,SOLUONG,GIA,THANHTIEN)VALUES(@MAHD,@masp,@soluong,@gia,@thanhtien)";
                        SqlCommand cmd = new SqlCommand(sql1, connection);
                        cmd.Parameters.AddWithValue("@MAHD", cbxMaHD.SelectedValue);
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
            btnDong.Enabled = true;
            btnIn.Enabled = true;
            btnTaoTK.Enabled = false;
            btnLuu.Enabled = false;
            LoadData();
        }

        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormHoaDonRP hoaDonRP = new FormHoaDonRP();
            hoaDonRP.id = cbxMaHD.SelectedIndex;
            hoaDonRP.cbxHDrp.Enabled = false;
            hoaDonRP.ShowDialog();
           
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            FormKhachHangAdd themkh = new FormKhachHangAdd();
            themkh.ShowDialog();
            LoadData();
        }

        private void data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (data.Columns[e.ColumnIndex].Name == "Đơn giá" && e.Value != null)
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
