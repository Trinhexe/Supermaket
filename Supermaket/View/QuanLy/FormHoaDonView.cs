using Supermaket.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermaket.View
{
    public partial class FormHoaDonView : Mau
    {
        public static SqlConnection connection;
        public FormHoaDonView()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData(string dk)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            
            string sql = @"select ROW_NUMBER() OVER (ORDER BY MAHD DESC) AS 'STT',MAHD,KHACHHANG.HOVATEN,NHANVIEN.HOVATEN,FORMAT(TONGTIEN, 'N0') as TONGTIEN,NGAYLAPHOADON,SĐT
                from HOADON LEFT JOIN KHACHHANG ON KHACHHANG.MAKH = HOADON.MAKH
                            INNER JOIN NHANVIEN ON NHANVIEN.MANV = HOADON.MANV
                WHERE "+dk;
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 40;
            data.Columns[1].HeaderText = "Mã hóa đơn";
            data.Columns[2].HeaderText = "Khách hàng";
            data.Columns[3].HeaderText = "Nhân viên";
            data.Columns[4].HeaderText = "Tổng tiền";
            data.Columns[5].HeaderText = "Ngày lập hóa đơn";
            data.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.Columns[6].Visible = false;
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }

        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            string dk = "KHACHHANG.HOVATEN LIKE N'%" + txtTk.Text + "%' OR NHANVIEN.HOVATEN LIKE N'%" + txtTk.Text + "%' OR SĐT LIKE N'%" + txtTk.Text + "%' OR HOADON.MAHD LIKE '%" + txtTk.Text+"%'";
            LoadData(dk);
        }
        private void btnLoc_Click_1(object sender, EventArgs e)
        {
            string dk = "NGAYLAPHOADON BETWEEN ('" + dtpNgayBD.Value + "') AND ('" + dtpNgayKT.Value + "')";
            LoadData(dk);
        }

        private void data_DoubleClick(object sender, EventArgs e)
        {
            FormHoaDonRP hoadon = new FormHoaDonRP();
            hoadon.cbxHDrp.Text = data.CurrentRow.Cells["MAHD"].Value.ToString();
            hoadon.id = Convert.ToInt32(data.CurrentRow.Cells["MAHD"].Value);
            hoadon.ShowDialog();
        }

        private void FormHoaDonView_Load(object sender, EventArgs e)
        {

            txtTk_TextChanged(sender, e);
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
