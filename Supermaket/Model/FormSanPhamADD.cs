using Supermaket.View;
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

namespace Supermaket.Model
{
    public partial class FormSanPhamAdd : Mau
    {
        public static SqlConnection connection;
        public FormSanPhamAdd()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public int id = 0;
       

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string filepath { get; set; }
        private void btnUpA_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpeg, .png)|* .png; *.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                txtpic.Image = new Bitmap(filepath);
            }
        }
        Byte[] imageByteArray;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Image temp = new Bitmap(txtpic.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();
            if (id == 0)
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string sql = "INSERT INTO SANPHAM (TENSP, DONGIA, MANCC, MADM, MAKM, MoTa, NGAYSX, NGAYHH, TRANGTHAI,HINHANH) VALUES (@TENSP, @DONGIA, @MANCC, @MADM, @MAKM, @MoTa, @NGAYSANXUAT, @NGAYHETHAN, @TRANGTHAI,@HINHANH)";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@TENSP", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@DONGIA", txtGia.Text);
                        cmd.Parameters.AddWithValue("@MANCC", cbxNCC.SelectedValue);
                        cmd.Parameters.AddWithValue("@MADM", cbxMaDM.SelectedValue);
                        cmd.Parameters.AddWithValue("@MAKM", cbxMaKM.SelectedValue);
                        cmd.Parameters.AddWithValue("@MoTa", rtxtboxMoTa.Text);
                        cmd.Parameters.AddWithValue("@NGAYSANXUAT", dtpNgaySX.Value);
                        cmd.Parameters.AddWithValue("@NGAYHETHAN", dtpNgayHH.Value);
                        cmd.Parameters.AddWithValue("@TRANGTHAI", 1);
                        cmd.Parameters.AddWithValue("@HINHANH", imageByteArray);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtTenSP.ResetText();
                txtGia.ResetText();
                rtxtboxMoTa.ResetText();
                txtpic.Image = Supermaket.Properties.Resources.dairy_products;
                txtTenSP.Focus();

            }
            else 
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                   
                    string sql = "UPDATE SANPHAM SET TENSP = @TENSP, DONGIA=@DONGIA, MANCC=@MANCC,MAKM=@MAKM,MADM=@MADM,MOTA=@MOTA,NGAYSX=@NGAYSANXUAT,NGAYHH=@NGAYHETHAN,HINHANH=@HINHANH  WHERE IDSP = @IDSP";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@IDSP", id);
                        cmd.Parameters.AddWithValue("@TENSP", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@DONGIA", txtGia.Text);
                        cmd.Parameters.AddWithValue("@MANCC", cbxNCC.SelectedValue);
                        cmd.Parameters.AddWithValue("@MADM", cbxMaDM.SelectedValue);
                        cmd.Parameters.AddWithValue("@MAKM", cbxMaKM.SelectedValue);
                        cmd.Parameters.AddWithValue("@MoTa", rtxtboxMoTa.Text);
                        cmd.Parameters.AddWithValue("@NGAYSANXUAT", dtpNgaySX.Value);
                        cmd.Parameters.AddWithValue("@NGAYHETHAN", dtpNgayHH.Value);
                        cmd.Parameters.AddWithValue("@HINHANH", imageByteArray);
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
        
        private void Load_CBXDM()
        {
            string sql = "select TENDM,MADM from DANHMUC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxMaDM.DataSource = ds;
            cbxMaDM.DisplayMember = "TENDM";
            cbxMaDM.ValueMember = "MADM";
        }
        private void Load_CBXNCC()
        {
            string sql = "select TENNCC,MANCC from NHACUNGCAP";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxNCC.DataSource = ds;
            cbxNCC.DisplayMember = "TENNCC";
            cbxNCC.ValueMember = "MANCC";
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

        private void FormSanPhamAdd_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                Load_CBXDM();
                Load_CBXKM();
                Load_CBXNCC();
            }    
        }

        private void cbxMaKM_TextChanged(object sender, EventArgs e)
        {
            Load_CBXKM();
        }

        private void cbxMaDM_TextChanged(object sender, EventArgs e)
        {
           Load_CBXDM();
        }

        private void cbxNCC_TextChanged(object sender, EventArgs e)
        {
            Load_CBXNCC();
        }

       
    }
}
