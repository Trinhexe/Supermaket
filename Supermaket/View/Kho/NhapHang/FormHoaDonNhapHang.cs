using Supermaket.Add.Kho.NhapHang;
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
    public partial class FormHoaDonNhapHang : Mau
    {
        public static SqlConnection connection;
        public FormHoaDonNhapHang()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData(string dk)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            string sql = @"select ROW_NUMBER() OVER (ORDER BY MANHAPHANG DESC) AS 'STT',MANHAPHANG,NHANVIEN.HOVATEN,SDT,FORMAT(TONGTIEN, 'N0') + ' VND' as TONGTIEN,NGAYNHAP
                FROM HDNHAPHANG INNER JOIN NHANVIEN ON NHANVIEN.MANV = HDNHAPHANG.MANV
                WHERE  "+dk;
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 40;
            data.Columns[1].HeaderText = "Mã hóa đơn";
            data.Columns[2].HeaderText = "Nhân viên";
            data.Columns[3].HeaderText = "Số điện thoại";
            data.Columns[4].HeaderText = "Tổng tiền";
            data.Columns[5].HeaderText = "Ngày lập hóa đơn";
            data.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string dk = "NGAYNHAP BETWEEN ('" + dtpNgayBD.Value + "') AND ('" + dtpNgayKT.Value + "')";
            LoadData(dk);
        }
        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            string dk = "NHANVIEN.HOVATEN LIKE N'%" + txtTk.Text + "%' OR MANHAPHANG LIKE '%" + txtTk.Text + "%' OR SDT LIKE '%" + txtTk.Text +"%'";
            LoadData(dk);
        }

        private void data_DoubleClick(object sender, EventArgs e)
        {
            FormHoaDonNH frNH = new FormHoaDonNH();
            frNH.cbxHDNHrp.Text = data.CurrentRow.Cells["MANHAPHANG"].Value.ToString();
            frNH.id = int.Parse(data.CurrentRow.Cells["MANHAPHANG"].Value.ToString());
            frNH.ShowDialog();
        }

        private void FormHoaDonNhapHang_Load(object sender, EventArgs e)
        {
            txtTk_TextChanged(sender,e);
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }

        private void dtpNgayKT_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayKT.Value < dtpNgayBD.Value)
            {
                MessageBox.Show("Ngày nhập vào không được bé hơn ngày sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKT.Value = dtpNgayBD.Value;
            }
        }

        private void dtpNgayBD_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Ngày nhập vào không được bé hơn kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayBD.Value = dtpNgayKT.Value;
            }
        }
    }
}
