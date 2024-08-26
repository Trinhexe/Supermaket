using Supermaket.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermaket.Model
{
    public partial class FormNCCADD : Mau
    {
        public FormNhaCungCapView kh = new FormNhaCungCapView();
        public static SqlConnection connection;
        public FormNCCADD()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public int id = 0;
        private void FormNCCADD_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (id ==0)
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    if(txtncc.Text == ""||txtGmail.Text==""||txtSDT.Text ==""||txtdiachi.Text=="")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà cung cấp","Thông báo",MessageBoxButtons.OK);
                    }   
                    else 
                    {
                        string sql = "INSERT INTO NHACUNGCAP (TENNCC,DIACHI,EMAIL,SDT) VALUES (@TENNCC,@DIACHI,@EMAIL,@SDT)";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@TENNCC", txtncc.Text);
                        cmd.Parameters.AddWithValue("@DIACHI", txtdiachi.Text);
                        cmd.Parameters.AddWithValue("@EMAIL", txtGmail.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtncc.ResetText();
                        txtdiachi.ResetText();
                        txtSDT.ResetText();
                        txtGmail.ResetText();
                        txtncc.Focus();
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
                    if (txtncc.Text == "" || txtGmail.Text == "" || txtSDT.Text == "" || txtdiachi.Text == "")
                    {
                        MessageBox.Show("Không được để trống thông tin nhà cung cấp", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string sql = "UPDATE NHACUNGCAP SET TENNCC = @TENNCC,DIACHI = @DIACHI, EMAIL = @EMAIL,SDT = @SDT WHERE MANCC = @MANCC";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@MANCC", id);
                            cmd.Parameters.AddWithValue("@TENNCC", txtncc.Text);
                            cmd.Parameters.AddWithValue("@DIACHI", txtdiachi.Text);
                            cmd.Parameters.AddWithValue("@EMAIL", txtemail.Text);
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
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
        }

        private void txtncc_TextChanged(object sender, EventArgs e)
        {
            string input = txtncc.Text;
            if (input.Length > 50)
            {
                MessageBox.Show("Tên nhà cung cấp không được quá 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtncc.ResetText();
            }
        }

        private void txtdiachi_TextChanged_1(object sender, EventArgs e)
        {
            string input = txtncc.Text;
            if (input.Length > 50)
            {
                MessageBox.Show("Địa chỉ không được quá 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtncc.ResetText();
            }
        }

        private void txtGmail_Validating(object sender, CancelEventArgs e)
        {
            string input = txtGmail.Text;
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Định dạng Gmail không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGmail.ResetText();
            }
        }
    }
}
