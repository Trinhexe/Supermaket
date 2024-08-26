using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            byte[] imageByteArray;
            Image temp = new Bitmap(txtpic.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();
            try
            {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    if (txtTenSP.Text == "")
                    {
                        MessageBox.Show("Không được để trống thông tin sản phẩm", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string sql = "UPDATE SANPHAM SET TENSP = @TENSP, DONGIA=@DONGIA, MANCC=@MANCC,MADM=@MADM,MOTA=@MOTA,GIAMGIA = @GIAMGIA,NGAYSX=@NGAYSANXUAT,NGAYHH=@NGAYHETHAN,HINHANH=@HINHANH  WHERE IDSP = @IDSP";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@IDSP", id);
                            cmd.Parameters.AddWithValue("@TENSP", txtTenSP.Text);
                            cmd.Parameters.AddWithValue("@DONGIA", txtGia.Text);
                            cmd.Parameters.AddWithValue("@MANCC", cbxNCC.SelectedValue);
                            cmd.Parameters.AddWithValue("@MADM", cbxMaDM.SelectedValue);  
                            cmd.Parameters.AddWithValue("@MoTa", rtxtboxMoTa.Text);
                            if (txtGiamGia.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@GIAMGIA",1);
                            }   
                            else
                            {
                                cmd.Parameters.AddWithValue("@GIAMGIA", double.Parse(txtGiamGia.Text) / 100);
                            }    
                            cmd.Parameters.AddWithValue("@NGAYSANXUAT", dtpNgaySX.Value);
                            cmd.Parameters.AddWithValue("@NGAYHETHAN", dtpNgayHH.Value);
                            cmd.Parameters.AddWithValue("@HINHANH", imageByteArray);
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

        private void FormSanPhamAdd_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                Load_CBXDM();
                Load_CBXNCC();
            }    
          
        }


        private void cbxMaDM_TextChanged(object sender, EventArgs e)
        {
           Load_CBXDM();
        }

        private void cbxNCC_TextChanged(object sender, EventArgs e)
        {
            Load_CBXNCC();
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenSP.Text;
            if (input.Length > 100)
            {
                MessageBox.Show("Tên sản phẩm không được quá 100 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.ResetText();
            }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            string input = txtGia.Text;
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Giá chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGia.ResetText();
                    break;
                }
            }
        }

        private void dtpNgayHH_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayHH.Value < dtpNgaySX.Value)
            {
                MessageBox.Show("Ngày nhập vào không được bé hơn ngày sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayHH.Value = dtpNgaySX.Value;
            }
        }

        private void dtpNgaySX_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgaySX.Value > dtpNgayHH.Value)
            {
                MessageBox.Show("Ngày nhập vào không được lớn hơn ngày hết hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySX.Value = dtpNgayHH.Value;
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            string input = txtGiamGia.Text;
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Giá chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiamGia.ResetText();
                    break;
                }
            }

        }

    }
}
