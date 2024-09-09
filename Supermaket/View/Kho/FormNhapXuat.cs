using Supermaket.Add.Kho;
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
    public partial class FormNhapXuat : Mau
    {
        public static SqlConnection connection;
        public FormNhapXuat()
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
                        N'%" + txtTk.Text + "%' OR MABAR LIKE '"+txtTk.Text+"'" +
                        "AND SANPHAM.TRANGTHAI = 1";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                data.Rows.Add(row["STT"], row["TENSP"], row["IDSP"], row["MABAR"], row["MoTa"], row["TENNCC"], row["TENDM"], row["SOLUONGTON"], row["NGAYSX"], row["NGAYHH"], row["HINHANH"], row["BARCODE"]);
            }
            data.Columns[0].Width = 50;
            data.Columns[8].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.Columns[9].DefaultCellStyle.Format = "dd-MM-yyyy";
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormNhapHangADD NP = new FormNhapHangADD();
            NP.ShowDialog();
            LoadData();
        }

        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormNhapXuat_Load(object sender, EventArgs e)
        {
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            LoadData();
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
