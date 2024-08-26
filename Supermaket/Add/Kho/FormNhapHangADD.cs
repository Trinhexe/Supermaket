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

namespace Supermaket.Add.Kho
{
    public partial class FormNhapHangADD : Mau
    {
        public static SqlConnection connection;
        public FormNhapHangADD()
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
                    MessageBox.Show("Vui lòng nhập thông tin sản phẩm", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql = "INSERT INTO SANPHAM (TENSP, MANCC, MADM, MoTa, NGAYSX, NGAYHH,SOLUONGTON, TRANGTHAI,HINHANH) VALUES (@TENSP, @MANCC, @MADM, @MoTa, @NGAYSANXUAT, @NGAYHETHAN,@SOLUONGTON, @TRANGTHAI,@HINHANH)";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                            cmd.Parameters.AddWithValue("@TENSP", txtTenSP.Text);
                            cmd.Parameters.AddWithValue("@MANCC", cbxNCC.SelectedValue);
                            cmd.Parameters.AddWithValue("@MADM", cbxMaDM.SelectedValue);
                            cmd.Parameters.AddWithValue("@MoTa", rtxtboxMoTa.Text);
                            cmd.Parameters.AddWithValue("@NGAYSANXUAT", dtpNgaySX.Value);
                            cmd.Parameters.AddWithValue("@NGAYHETHAN", dtpNgayHH.Value);
                            cmd.Parameters.AddWithValue("@SOLUONGTON",0);
                            cmd.Parameters.AddWithValue("@TRANGTHAI", 1);
                            cmd.Parameters.AddWithValue("@HINHANH", imageByteArray);
                            cmd.ExecuteNonQuery();
                    }

                        MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenSP.ResetText();
                        rtxtboxMoTa.ResetText();
                        txtpic.Image = Supermaket.Properties.Resources.dairy_products;
                        txtTenSP.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void FormNhapHangADD_Load(object sender, EventArgs e)
        {
            Load_CBXDM();
            Load_CBXNCC();
        }
    }
}
