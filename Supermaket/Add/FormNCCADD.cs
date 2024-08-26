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
    }
}
