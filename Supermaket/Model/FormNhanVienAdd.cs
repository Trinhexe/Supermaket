using Supermaket.View;
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
    public partial class FormNhanVienAdd : Mau
    {
        public static SqlConnection connection;
        public FormNhanVienAdd()
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
                    if(ckNam.Checked == true && ckNu.Checked == true)
                    {
                        MessageBox.Show("Vui lòng chọn 1 trong 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "INSERT INTO NHANVIEN (HOVATEN, TAIKHOAN,MATKHAU, DIACHI,GIOITINH,NGAYSINH,SDT,EMAIL,MACV,TRANGTHAI) VALUES (@HOVATEN, @TAIKHOAN,@MATKHAU, @DIACHI,@GIOITINH,@NGAYSINH,@SDT,@EMAIL,@MACV,@TRANGTHAI)";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@HOVATEN", txtHoTennv.Text);
                        cmd.Parameters.AddWithValue("@TAIKHOAN", txtTK.Text);
                        cmd.Parameters.AddWithValue("@MATKHAU", txtMk.Text);
                        cmd.Parameters.AddWithValue("@DIACHI", txtDiaChinv.Text);
                        if (ckNu.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@GIOITINH", 0);
                        }
                        if (ckNam.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@GIOITINH", 1);
                        }
                        cmd.Parameters.AddWithValue("@NGAYSINH", dtpngaysinhnv.Value);
                        cmd.Parameters.AddWithValue("@SDT", txtSDTnv.Text);
                        cmd.Parameters.AddWithValue("@EMAIL", txtgmailnv.Text);
                        cmd.Parameters.AddWithValue("@MACV", cbxChucVu.SelectedValue);
                        cmd.Parameters.AddWithValue("@TRANGTHAI", 1);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtHoTennv.ResetText();
                        txtTK.ResetText();
                        txtMk.ResetText();
                        txtDiaChinv.ResetText();
                        txtSDTnv.ResetText();
                        cbxChucVu.ResetText();
                        txtHoTennv.Focus();
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    if (ckNam.Checked == true && ckNu.Checked == true)
                    {
                        MessageBox.Show("Vui lòng chọn 1 trong 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "UPDATE NHANVIEN SET HOVATEN = @HOVATEN, TAIKHOAN=@TAIKHOAN,MATKHAU=@MATKHAU, DIACHI=@DIACHI,GIOITINH=@GIOITINH,NGAYSINH=@NGAYSINH,SDT=@SDT,EMAIL=@EMAIL,MACV=@MACV WHERE MANV = @MANV";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@MANV", id);
                            cmd.Parameters.AddWithValue("@HOVATEN", txtHoTennv.Text);
                            cmd.Parameters.AddWithValue("@TAIKHOAN", txtTK.Text);
                            cmd.Parameters.AddWithValue("@MATKHAU", txtMk.Text);
                            cmd.Parameters.AddWithValue("@DIACHI", txtDiaChinv.Text);

                            if (ckNu.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@GIOITINH", 0);
                            }
                            if (ckNam.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@GIOITINH", 1);
                            }
                            cmd.Parameters.AddWithValue("@NGAYSINH", dtpngaysinhnv.Value);
                            cmd.Parameters.AddWithValue("@SDT", txtSDTnv.Text);
                            cmd.Parameters.AddWithValue("@EMAIL", txtgmailnv.Text);
                            cmd.Parameters.AddWithValue("@MACV", cbxChucVu.SelectedValue);
                            cmd.Parameters.AddWithValue("@TRANGTHAI", 1);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }    
                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void FormNhanVienAdd_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                LoadCbxChucVu();
            }
        }
        private void LoadCbxChucVu()
        {
            string sql = "select TENCV,MACV from CHUCVU";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxChucVu.DataSource = ds;
            cbxChucVu.DisplayMember = "TENCV";
            cbxChucVu.ValueMember = "MACV";
        }
       

        private void cbxChucVu_TextChanged_1(object sender, EventArgs e)
        {
            LoadCbxChucVu();
        }
    }
}
