using Supermaket.Add.Kho.NhapHang;
using Supermaket.Add.Kho.XuatHang;
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
    public partial class FormHoaDonXuatHang : Mau
    {
        public static SqlConnection connection;
        public FormHoaDonXuatHang()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData(string dk)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            string sql = @"select ROW_NUMBER() OVER (ORDER BY MAXUATHANG DESC) AS 'STT',MAXUATHANG,NHANVIEN.HOVATEN,SDT,KHACHHANG.HOVATEN,SĐT,FORMAT(TONGTIEN, 'N0') + ' VND' as TONGTIEN,NGAYXUAT
                FROM HDXUATHANG INNER JOIN NHANVIEN ON NHANVIEN.MANV = HDXUATHANG.MANV
                                LEFT JOIN KHACHHANG ON KHACHHANG.MAKH = HDXUATHANG.MAKH
                WHERE "+dk;
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 50;
            data.Columns[1].HeaderText = "Mã hóa đơn";
            data.Columns[2].HeaderText = "Nhân viên";
            data.Columns[3].HeaderText = "SĐT nhân viên";
            data.Columns[4].HeaderText = "Khách hàng";
            data.Columns[5].HeaderText = "SĐT khách hàng";
            data.Columns[6].HeaderText = "Tổng tiền";
            data.Columns[7].HeaderText = "Ngày lập hóa đơn";
            data.Columns[7].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string dk = "NGAYXUAT BETWEEN ('" + dtpNgayBD.Value + "') AND ('" + dtpNgayKT.Value + "')";
            LoadData(dk);
        }
        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            string dk = "NHANVIEN.HOVATEN LIKE N'%" + txtTk.Text + "%' OR MAXUATHANG LIKE '%" + txtTk.Text + "%' OR SDT LIKE '%" + txtTk.Text + "%'";
            LoadData(dk);
        }

        private void data_DoubleClick(object sender, EventArgs e)
        {
            FormHoaDonXH frXH = new FormHoaDonXH();
            frXH.cbxHDXHrp.Text = data.CurrentRow.Cells["MAXUATHANG"].Value.ToString();
            frXH.id = int.Parse(data.CurrentRow.Cells["MAXUATHANG"].Value.ToString());
            frXH.ShowDialog();
        }

        private void FormHoaDonXuatHang_Load(object sender, EventArgs e)
        {
            txtTk_TextChanged(sender,e);
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular); 
        }

        private void dtpNgayBD_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Ngày nhập vào không được bé hơn kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayBD.Value = dtpNgayKT.Value;
            }
        }

        private void dtpNgayKT_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayKT.Value < dtpNgayBD.Value)
            {
                MessageBox.Show("Ngày nhập vào không được bé hơn ngày sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKT.Value = dtpNgayBD.Value;
            }
        }
    }
}
