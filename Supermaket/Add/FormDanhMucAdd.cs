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
    public partial class FormDanhMucAdd : Mau
    {
        public FormDanhMucView kh = new FormDanhMucView();
        public static SqlConnection connection;
        public FormDanhMucAdd()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public int id = 0;

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (id ==0)
            {
                if (txtTenDM.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục","Thông báo",MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        string sql = "INSERT INTO DANHMUC (TENDM,MOTA,TRANGTHAI) VALUES (@TENDM,@MOTA,1)";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@TENDM", txtTenDM.Text);
                        cmd.Parameters.AddWithValue("@MOTA", rtxtboxDM.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtTenDM.ResetText();
                    rtxtboxDM.ResetText();
                    txtTenDM.Focus();
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
                    if (txtTenDM.Text == "")
                    {
                        MessageBox.Show("Không được để trống tên danh mục", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string sql = "UPDATE DANHMUC SET TENDM = @TENDM, MOTA = @MOTA WHERE MADM = @MADM";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@MADM", id);
                            cmd.Parameters.AddWithValue("@TENDM", txtTenDM.Text);
                            cmd.Parameters.AddWithValue("@MOTA", rtxtboxDM.Text);
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
