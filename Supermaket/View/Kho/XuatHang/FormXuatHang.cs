using Supermaket.View.Kho.XuatHang;
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
    public partial class FormXuatHang : Mau
    {
        public static SqlConnection connection;
        public FormXuatHang()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY IDSP DESC) AS 'STT',TENSP,IDSP,SanPham.MoTa, TENNCC, TENDM, DONGIA,SOLUONGTON, NGAYSX, NGAYHH
                        from SANPHAM INNER JOIN DANHMUC ON SANPHAM.MADM = DANHMUC.MADM
                                    INNER JOIN NHACUNGCAP ON NHACUNGCAP.MANCC = SANPHAM.MANCC 
                        WHERE TENSP LIKE 
                        N'%" + txtTk.Text + "%'" +
                        "AND SANPHAM.TRANGTHAI = 1 AND SOLUONGTON > 0";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.Rows.Clear();
            data.Columns[0].Width = 50;
            foreach (DataRow row in dt.Rows)
            {
                data.Rows.Add(row["STT"], row["TENSP"], row["IDSP"], row["MoTa"], row["TENNCC"], row["TENDM"], row["DONGIA"], row["SOLUONGTON"], ((DateTime)row["NGAYSX"]).ToString("dd-MM-yyyy"), ((DateTime)row["NGAYHH"]).ToString("dd-MM-yyyy"));
            }
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }

        private void FormXuatHang_Load(object sender, EventArgs e)
        {
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            LoadData();
        }
        private DataTable ChiTietXH()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns[0].ReadOnly = true;
            dt.Columns.Add("Mã SP", typeof(int));
            dt.Columns[1].ReadOnly = true;
            dt.Columns.Add("Tên SP", typeof(string));
            dt.Columns[2].ReadOnly = true;
            dt.Columns.Add("Nhà cung cấp", typeof(string));
            dt.Columns[3].ReadOnly = true;
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns[4].ReadOnly = false;
            dt.Columns.Add("Giá Xuất", typeof(float));
            dt.Columns[5].ReadOnly = false;
            dt.Columns.Add("Thành tiền", typeof(double));
            dt.Columns[6].ReadOnly = false;
            dt.Columns.Add("SL Tồn", typeof(int));
            data.Columns[7].Visible = false;
            return dt;
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            FormCTXH formCTXH = new FormCTXH();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql1 = "INSERT INTO HDXUATHANG (MANV)VALUES(@MANV)";
            SqlCommand cmd = new SqlCommand(sql1, connection);
            cmd.Parameters.AddWithValue("@MANV", MainClass.MaNV);
            cmd.ExecuteNonQuery();
            DataTable xuathang = ChiTietXH();
            int dem = 0;
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Cells["dgvCheck"].Value != null && (bool)row.Cells["dgvCheck"].Value == true)
                {
                    dem++;
                    int maSp = Convert.ToInt32(row.Cells["dgvId"].Value);
                    string tenSp = row.Cells["dgvTenSP"].Value.ToString();
                    string tenncc = row.Cells["dgvTenNCC"].Value.ToString();
                    int soLuong = 1;
                    float gianhap = float.Parse(row.Cells["dgvGia"].Value.ToString()); 
                    double thanhtien = soLuong * gianhap;
                    int slton = Convert.ToInt32(row.Cells["dgvSL"].Value.ToString());
                    xuathang.Rows.Add(dem, maSp, tenSp, tenncc, soLuong, gianhap, thanhtien, slton);
                }
            }
            formCTXH.data.DataSource = xuathang;
            formCTXH.data.AllowUserToAddRows = false;
            formCTXH.ShowDialog();
            LoadData();
        }
        private List<int> luuchon = new List<int>();
        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            List<int> tempSelectedIds = new List<int>(luuchon);
            LoadData();
            foreach (DataGridViewRow row in data.Rows)
            {
                if (tempSelectedIds.Contains((int)row.Cells["dgvId"].Value))
                {
                    row.Cells["dgvCheck"].Value = true;
                }
            }
            luuchon = tempSelectedIds;
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data.CurrentCell.OwningColumn.Name == "dgvCheck")
            {
                // Đảo ngược giá trị của ô CheckBox khi được click
                if (data.CurrentCell.Value != null && (bool)data.CurrentCell.Value == true)
                {
                    data.CurrentCell.Value = false;
                    // Nếu ô CheckBox được bỏ chọn, xóa IDSP khỏi danh sách
                    luuchon.Remove((int)data.CurrentRow.Cells["dgvId"].Value);
                }
                else
                {
                    data.CurrentCell.Value = true;
                    // Nếu ô CheckBox được chọn, thêm IDSP vào danh sách
                    luuchon.Add((int)data.CurrentRow.Cells["dgvId"].Value);
                }
            }
        }
    }
}
