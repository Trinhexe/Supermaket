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

namespace Supermaket.View
{
    
    public partial class FormKhachHangView : MauView
    {
        public static SqlConnection connection;
        
        public FormKhachHangView()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select ROW_NUMBER() OVER (ORDER BY HOVATEN) AS 'STT',HoVaTen,MAKH,NGAYSINH,DiaChi,(CASE
            WHEN (GIOITINH = 1) THEN N'Nam'
            WHEN (GIOITINH = 0) THEN N'Nữ'
            end) as Phai,SĐT,EMAIL,LOAIKH, DIEMTICHLUY,NGAYTAOTK from KHACHHANG where HOVATEN LIKE
            N'%" + txtTk.Text + "%'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            data.DataSource = dt;
            data.Columns[0].HeaderText = "STT";
            data.Columns[0].Width = 60;
            data.Columns[1].HeaderText = "Họ và tên";
            data.Columns[1].Width = 250;
            data.Columns[2].HeaderText = "Mã khách";
            data.Columns[2].Width = 150;
            data.Columns[3].HeaderText = "Ngày sinh";
            data.Columns[3].Width = 200;
            data.Columns[4].HeaderText = "Địa chỉ";
            data.Columns[4].Width = 250;
            data.Columns[5].HeaderText = "Phái";
            data.Columns[5].Width = 70;
            data.Columns[6].HeaderText = "SĐT";
            data.Columns[6].Width = 200;
            data.Columns[7].HeaderText = "Gmail";
            data.Columns[7].Name = "dgvgmail";
            data.Columns[7].Visible = false;
            data.Columns[8].HeaderText = "Loại KH";
            data.Columns[8].Width = 150;
            data.Columns[9].HeaderText = "Điểm tích lũy";
            data.Columns[9].Width = 250;
            data.Columns[10].HeaderText = "Ngày tạo tk";
            data.Columns[10].Width = 200;
            data.AllowUserToAddRows = false;
            data.EditMode = DataGridViewEditMode.EditProgrammatically;
            connection.Close();
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            FormKhachHangAdd add = new FormKhachHangAdd();
            add.ShowDialog();
            LoadData();
        }

        public override void txtTk_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        public override void data_DoubleClick(object sender, EventArgs e)
        {
            FormKhachHangAdd themkh = new FormKhachHangAdd();
            themkh.id = Convert.ToInt32(data.CurrentRow.Cells["MAKH"].Value);
            themkh.txtHoTen.Text = data.CurrentRow.Cells["HOVATEN"].Value.ToString();
            themkh.dtpngaysinh.Value = (DateTime)data.CurrentRow.Cells["NGAYSINH"].Value;
            themkh.txtDiaChi.Text = data.CurrentRow.Cells["DIACHI"].Value.ToString();
            if (data.CurrentRow.Cells["PHAI"].Value.ToString() == "Nam")
            {
                themkh.ckNam.Checked = true;
            }
            else
            {
                themkh.ckNu.Checked = true;
            }
            themkh.txtSDT.Text = data.CurrentRow.Cells["SĐT"].Value.ToString();
            themkh.txtgmail.Text = data.CurrentRow.Cells["dgvgmail"].Value.ToString();
            themkh.dtpngaytaotk.Value = (DateTime)data.CurrentRow.Cells["NGAYTAOTK"].Value;
            themkh.ShowDialog();
            LoadData();
        }

        private void FormKhachHangView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
