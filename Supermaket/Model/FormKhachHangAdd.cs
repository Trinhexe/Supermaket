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
    public partial class FormKhachHangAdd : Mau
    {
        
        public static SqlConnection connection;
        public FormKhachHangAdd()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public int id = 0;
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
                    if (ckNam.Checked == true && ckNu.Checked == true)
                    {
                        MessageBox.Show("Vui lòng chọn 1 trong 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "INSERT INTO KHACHHANG (HOVATEN, NGAYSINH, DIACHI,GIOITINH,SĐT,EMAIL,NGAYTAOTK) VALUES (@HOVATEN,@NGAYSINH, @DIACHI, @GIOITINH,@SĐT,@EMAIL,@NGAYTAOTK)";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@HOVATEN", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@NGAYSINH", dtpngaysinh.Value);
                        cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                        if (ckNu.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@GIOITINH", 0);
                        }
                        if (ckNam.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@GIOITINH", 1);
                        }
                        cmd.Parameters.AddWithValue("@SĐT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@EMAIL", txtgmail.Text);
                        cmd.Parameters.AddWithValue("@NGAYTAOTK", dtpngaytaotk.Value);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtHoTen.ResetText();
                        txtDiaChi.ResetText();
                        txtSDT.ResetText();
                        txtgmail.ResetText();
                        txtHoTen.Focus();
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
                        string sql = "UPDATE KHACHHANG SET HOVATEN = @HOVATEN, NGAYSINH=@NGAYSINH, DIACHI=@DIACHI,GIOITINH=@GIOITINH,SĐT=@SDT,EMAIL=@EMAIL,NGAYTAOTK=@NGAYTAOTK WHERE MAKH = @MAKH";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@MAKH", id);
                            cmd.Parameters.AddWithValue("@HOVATEN", txtHoTen.Text);
                            cmd.Parameters.AddWithValue("@NGAYSINH", dtpngaysinh.Value);
                            cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                            if (ckNu.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@GIOITINH", 0);
                            }
                            if (ckNam.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@GIOITINH", 1);
                            }
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@EMAIL", txtgmail.Text);
                            cmd.Parameters.AddWithValue("@NGAYTAOTK", dtpngaytaotk.Value);
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

  

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
