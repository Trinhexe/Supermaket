using Supermaket.Add.Kho;
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
            string sql = @"select ROW_NUMBER() OVER (ORDER BY IDSP) AS 'STT',TENSP,IDSP,SanPham.MoTa, TENNCC, TENDM, SOLUONGTON, NGAYSX, NGAYHH
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
                data.Rows.Add(row["STT"], row["TENSP"], row["IDSP"], row["MoTa"], row["TENNCC"], row["TENDM"], row["SOLUONGTON"], ((DateTime)row["NGAYSX"]).ToString("dd-MM-yyyy"), ((DateTime)row["NGAYHH"]).ToString("dd-MM-yyyy"));
            }
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
            dt.Columns.Add("Mã SP", typeof(int));
            dt.Columns[0].ReadOnly = true;
            dt.Columns.Add("Tên SP", typeof(string));
            dt.Columns[1].ReadOnly = true;
            dt.Columns.Add("Nhà cung cấp", typeof(string));
            dt.Columns[2].ReadOnly = true;
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns[3].ReadOnly = false;
            dt.Columns.Add("Giá Nhập", typeof(float));
            dt.Columns[4].ReadOnly = false;
            dt.Columns.Add("Thành tiền", typeof(float));
            dt.Columns[5].ReadOnly = false;
            
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
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Cells["dgvCheck"].Value != null && (bool)row.Cells["dgvCheck"].Value == true)
                {
                    int maSp = Convert.ToInt32(row.Cells["dgvId"].Value);
                    string tenSp = row.Cells["dgvTenSP"].Value.ToString();
                    string tenncc = row.Cells["dgvTenNCC"].Value.ToString();
                    int soLuong = 0;
                    float gianhap = 0;
                    float thanhtien = soLuong * gianhap;
                    nhaphang.Rows.Add(maSp, tenSp, tenncc, soLuong, gianhap, thanhtien);
                }
            }
            np.data.DataSource = nhaphang;
            np.data.AllowUserToAddRows = false;
            np.ShowDialog();
            LoadData();
        }

        private void txtTk_TextChanged_1(object sender, EventArgs e)
        {
            LoadData();
        }
       
        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data.CurrentCell.OwningColumn.Name == "dgvCheck")
            {
                // Đảo ngược giá trị của ô CheckBox khi được click
                if (data.CurrentCell.Value != null && (bool)data.CurrentCell.Value == true)
                {
                    data.CurrentCell.Value = false;
                }
                else
                {
                    data.CurrentCell.Value = true;
                }
            }
        }
    }
}
