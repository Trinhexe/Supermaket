using Supermaket.Add.Kho;
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

namespace Supermaket.View.Kho
{
    public partial class FormNhapHang : Mau

    {
        public static SqlConnection connection;
        public FormNhapHang()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY IDSP DESC) AS 'STT',TENSP,IDSP,SanPham.MoTa, TENNCC, TENDM, SOLUONGTON, NGAYSX, NGAYHH, MABAR, Barcode, HinhAnh
                        from SANPHAM INNER JOIN DANHMUC ON SANPHAM.MADM = DANHMUC.MADM
                                    INNER JOIN NHACUNGCAP ON NHACUNGCAP.MANCC = SANPHAM.MANCC 
                        WHERE TENSP LIKE 
                        N'%" + txtTk.Text + "%'" +
                        "AND SANPHAM.TRANGTHAI = 1";
                        
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.Rows.Clear();
            
            foreach (DataRow row in dt.Rows)
            {
                data.Rows.Add(row["STT"], row["TENSP"], row["IDSP"], row["MABAR"] ,row["MoTa"], row["TENNCC"], row["TENDM"], row["SOLUONGTON"], row["NGAYSX"], row["NGAYHH"], row["HINHANH"],row["BARCODE"]);
            }
            data.Columns[0].Width = 50;
            data.Columns[8].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.Columns[9].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            LoadData();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            FormNhapHangADD NP = new FormNhapHangADD();
            NP.ShowDialog();
            LoadData();
        }
        private DataTable ChiTietNH()
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
            dt.Columns.Add("Giá Nhập", typeof(double));
            dt.Columns[5].ReadOnly = false;
            dt.Columns.Add("Thành tiền", typeof(double));
            dt.Columns[6].ReadOnly = false;
            return dt;
        }

        private void btnNhap_Click_1(object sender, EventArgs e)
        {
            FormCTNH np = new FormCTNH();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql1 = "INSERT INTO HDNHAPHANG (MANV)VALUES(@MANV)";
            SqlCommand cmd = new SqlCommand(sql1, connection);
            cmd.Parameters.AddWithValue("@MANV", MainClass.MaNV);
            cmd.ExecuteNonQuery();
            DataTable nhaphang = ChiTietNH();
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
                    double gianhap = 1;
                    double thanhtien = soLuong * gianhap;
                    nhaphang.Rows.Add(dem,maSp, tenSp, tenncc, soLuong, gianhap, thanhtien);
                }
            }
            np.data.DataSource = nhaphang;
            np.data.AllowUserToAddRows = false;
            np.ShowDialog();
            LoadData();
        }
        private List<int> luuchon = new List<int>();
        private void txtTk_TextChanged_1(object sender, EventArgs e)
        {
            List<int> tempSelectedIds = new List<int>(luuchon);
            LoadData();

            // Restore lại danh sách selectedIds
            foreach (DataGridViewRow row in data.Rows)
            {
                if (tempSelectedIds.Contains((int)row.Cells["dgvId"].Value))
                {
                    row.Cells["dgvCheck"].Value = true;
                }
            }
            luuchon = tempSelectedIds;
        }
        
        private void data_CellClick_1(object sender, DataGridViewCellEventArgs e)
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

        private void data_DoubleClick(object sender, EventArgs e)
        {
            FormNhapHangADD nhaphang = new FormNhapHangADD();
            nhaphang.id = int.Parse(data.CurrentRow.Cells["dgvId"].Value.ToString());
            nhaphang.txtTenSP.Text = data.CurrentRow.Cells["dgvTenSP"].Value.ToString();
            nhaphang.txtMaSp.Text = data.CurrentRow.Cells["dgvMaSP"].Value.ToString();
            nhaphang.barcode = data.CurrentRow.Cells["dgvMaSP"].Value.ToString();
            nhaphang.cbxNCC.Text = data.CurrentRow.Cells["dgvTenNCC"].Value.ToString();
            nhaphang.cbxMaDM.Text = data.CurrentRow.Cells["dgvTenDM"].Value.ToString();
            nhaphang.dtpNgaySX.Value = (DateTime)data.CurrentRow.Cells["dgvNgaySX"].Value;
            nhaphang.dtpNgayHH.Value = (DateTime)data.CurrentRow.Cells["dgvNgayHH"].Value;
            byte[] imageData = (byte[])data.CurrentRow.Cells["dgvAnh"].Value;
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                nhaphang.txtpic.Image = Image.FromStream(ms);
            }
            byte[] imageData2 = (byte[])data.CurrentRow.Cells["dgvBarCode"].Value;
            using (MemoryStream ms = new MemoryStream(imageData2))
            {
                nhaphang.picbarcode.Image = Image.FromStream(ms);
            }
            nhaphang.ShowDialog();
            LoadData();
        }
    }
}
