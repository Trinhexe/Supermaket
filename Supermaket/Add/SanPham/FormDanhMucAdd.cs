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
                        string sql = "INSERT INTO DANHMUC (TENDM,MOTA) VALUES (@TENDM,@MOTA)";
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
                        if (cbxMaKM.Text == "")
                        {
                            string sql = "UPDATE DANHMUC SET TENDM = @TENDM, MOTA = @MOTA WHERE MADM = @MADM";
                            using (SqlCommand cmd = new SqlCommand(sql, connection))
                            {
                                cmd.Parameters.AddWithValue("@MADM", id);
                                cmd.Parameters.AddWithValue("@TENDM", txtTenDM.Text);
                                cmd.Parameters.AddWithValue("@MOTA", rtxtboxDM.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sql2 = "UPDATE SANPHAM SET " +
                                "MAKM = @MAKM WHERE MADM IN (SELECT MADM FROM SANPHAM WHERE MADM = @MADM)";
                            using (SqlCommand cmd2 = new SqlCommand(sql2, connection))
                            {
                                cmd2.Parameters.AddWithValue("@MADM", id);
                                cmd2.Parameters.AddWithValue("@MAKM", cbxMaKM.SelectedValue); 
                                cmd2.ExecuteNonQuery();
                            }
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
        private void Load_CBXKM()
        {
            string sql = "select TENKM,MAKM from KHUYENMAI";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxMaKM.DataSource = ds;
            cbxMaKM.DisplayMember = "TENKM";
            cbxMaKM.ValueMember = "MAKM";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDanhMucAdd_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                cbxMaKM.Enabled = false;
            }    
            else
            {
                cbxMaKM.Enabled = true;
            }    
        }

        private void cbxMaKM_TextChanged(object sender, EventArgs e)
        {
            Load_CBXKM();
        }
    }
}
