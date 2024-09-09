using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
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
        public string sdt;
        public string gmail;
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
                    else if(txtHoTen.Text == "" || txtDiaChi.Text == ""||txtgmail.Text ==""||txtSDT.Text =="" || (ckNam.Checked == false && ckNu.Checked == false))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string sql = "INSERT INTO KHACHHANG (HOVATEN, NGAYSINH, DIACHI,GIOITINH,DIEMTICHLUY,SĐT,EMAIL,NGAYTAOTK) VALUES (@HOVATEN,@NGAYSINH, @DIACHI, @GIOITINH,@DIEMTICHLUY,@SĐT,@EMAIL,@NGAYTAOTK)";
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
                        cmd.Parameters.AddWithValue("@DIEMTICHLUY", 0);
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
                    else if (txtHoTen.Text == "" || txtDiaChi.Text == "" || txtgmail.Text == "" || txtSDT.Text == ""|| (ckNam.Checked == false && ckNu.Checked == false))
                    {
                        MessageBox.Show("Không được để trống thông tin khách hàng", "Thông báo", MessageBoxButtons.OK);
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
                        btnLuu.Enabled = false;
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

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string input = txtSDT.Text;
            if (input.Length > 11) // check length
            {
                MessageBox.Show("SĐT không được nhập quá 11 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.ResetText();
                return;
            }
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("SĐT chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.ResetText();
                    break;
                }
            }
            if(id ==0)
            {
                if (CheckDuLieu.CheckSDT(txtSDT.Text, "SELECT SĐT FROM KHACHHANG") == false)
                {
                    MessageBox.Show("Số điện thoại đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.ResetText();
                }
            }    
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            string input = txtHoTen.Text;
            if (input.Length > 50)
            {
                MessageBox.Show("Tên nhân viên không được quá 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.ResetText();
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            string input = txtDiaChi.Text;
            if (input.Length > 100)
            {
                MessageBox.Show("Địa chỉ không được quá 100 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.ResetText();
            }
        }

        private void txtgmail_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtSDT_Validated(object sender, EventArgs e)
        {
            if(id > 0)
            {
                if (CheckDuLieu.CheckSDT(txtSDT.Text, "SELECT SĐT FROM KHACHHANG") == false)
                {
                    MessageBox.Show("Số điện thoại đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Text = sdt.ToString();
                }
            }    
        }

        private void txtgmail_TextChanged(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (CheckDuLieu.CheckGmail(txtgmail.Text, "SELECT EMAIL FROM KHACHHANG") == false)
                {
                    MessageBox.Show("Gmail đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtgmail.ResetText();
                }
            }
        }

        private void txtgmail_Validated(object sender, EventArgs e)
        {
            string input = txtgmail.Text;
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Định dạng Gmail không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgmail.ResetText();
            }
            if (id > 0)
            {
                if (CheckDuLieu.CheckGmail(txtgmail.Text, "SELECT EMAIL FROM KHACHHANG") == false)
                {
                    MessageBox.Show("Gmail đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtgmail.Text = gmail.ToString();
                }
            }    
        }
    }
}
