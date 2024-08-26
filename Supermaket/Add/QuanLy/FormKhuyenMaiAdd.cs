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

namespace Supermaket.Model
{
    public partial class FormKhuyenMaiAdd : Mau
    {
        public static SqlConnection connection;
        public FormKhuyenMaiAdd()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public int id = 0;

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string sql = "INSERT INTO KHUYENMAI (TENKM, NGAYBATDAU, NGAYKETTHUC,GIAMGIA) VALUES (@TENKM, @NGAYBATDAU, @NGAYKETTHUC,@GIAMGIA)";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@TENKM", txtTenKM.Text);
                        cmd.Parameters.AddWithValue("@NGAYBATDAU", dtpNgayBD.Value);
                        cmd.Parameters.AddWithValue("@NGAYKETTHUC", dtpNgayKT.Value);
                        cmd.Parameters.AddWithValue("@GIAMGIA", (double.Parse(txtGiamGia.Text)) / 100);
                       
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtTenKM.ResetText();
                txtGiamGia.ResetText();
                txtTenKM.Focus();

            }
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    string sql = "UPDATE KHUYENMAI SET TENKM = @TENKM,NGAYBATDAU=@NGAYBATDAU,NGAYKETTHUC=@NGAYKETTHUC,GIAMGIA=@GIAMGIA WHERE MAKM = @MAKM";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@MAKM", id);
                        cmd.Parameters.AddWithValue("@TENKM", txtTenKM.Text);
                        cmd.Parameters.AddWithValue("@NGAYBATDAU", dtpNgayBD.Value);
                        cmd.Parameters.AddWithValue("@NGAYKETTHUC", dtpNgayKT.Value);
                        cmd.Parameters.AddWithValue("@GIAMGIA", (double.Parse(txtGiamGia.Text))/100);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void txtTenKM_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenKM.Text;
            if (input.Length > 100)
            {
                MessageBox.Show("Tên khuyến mãi không được quá 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKM.ResetText();
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            string input = txtGiamGia.Text;
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Khuyến mãi chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiamGia.ResetText();
                    break;
                }
            }
        }

        private void dtpNgayBD_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayBD.Value > dtpNgayKT.Value)
            {
                MessageBox.Show("Ngày nhập vào không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
