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
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            
            string sql = @"select ROW_NUMBER() OVER (ORDER BY MAHD) AS 'STT',MAHD,KHACHHANG.HOVATEN,NHANVIEN.HOVATEN,FORMAT(TONGTIEN, 'N0') + ' VND' as TONGTIEN,NGAYLAPHOADON
                from HOADON LEFT JOIN KHACHHANG ON KHACHHANG.MAKH = HOADON.MAKH
                            INNER JOIN NHANVIEN ON NHANVIEN.MANV = HOADON.MANV
                WHERE KHACHHANG.HOVATEN LIKE N'%" + txtTk.Text + "%' OR NHANVIEN.HOVATEN LIKE N'%"+txtTk.Text+"%'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[1].HeaderText = "Mã hóa đơn";
            data.Columns[2].HeaderText = "Khách hàng";
            data.Columns[3].HeaderText = "Nhân viên";
            data.Columns[4].HeaderText = "Tổng tiền";
            data.Columns[5].HeaderText = "Ngày lập hóa đơn";
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            
            connection.Close();
        }


        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
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
            
            LoadData();
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        }
    }
}
