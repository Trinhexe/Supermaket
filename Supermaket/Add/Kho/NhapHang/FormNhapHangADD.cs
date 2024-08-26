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
        public string barcode;
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Image temp = new Bitmap(txtpic.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageByteArray = ms.ToArray();
            Image bar = new Bitmap(picbarcode.Image);
            MemoryStream ms2 = new MemoryStream();
            bar.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageByteArray2 = ms2.ToArray(); 
            if (id ==0)
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    if (txtTenSP.Text == "" || txtMaSp.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập thông tin sản phẩm", "Thông báo", MessageBoxButtons.OK);
                    }
                    else if (CheckBarcode(txtMaSp.Text) == false)
                    {
                        MessageBox.Show("Barcode đã có vui lòng nhập khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaSp.ResetText();
                    }    
                    else
                    {
                        string sql = "INSERT INTO SANPHAM (MABAR, TENSP, MANCC, MADM, MoTa,SANPHAM.GiamGia, NGAYSX, NGAYHH,SOLUONGTON, TRANGTHAI,HINHANH,BARCODE,GIANHAP) VALUES (@MABAR,@TENSP, @MANCC, @MADM, @MoTa,@GiamGia ,@NGAYSANXUAT, @NGAYHETHAN,@SOLUONGTON, @TRANGTHAI,@HINHANH,@BARCODE,@GIANHAP)";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@MABAR", txtMaSp.Text);
                            cmd.Parameters.AddWithValue("@TENSP", txtTenSP.Text);
                            cmd.Parameters.AddWithValue("@MANCC", cbxNCC.SelectedValue);
                            cmd.Parameters.AddWithValue("@MADM", cbxMaDM.SelectedValue);
                            cmd.Parameters.AddWithValue("@MoTa", rtxtboxMoTa.Text);
                            cmd.Parameters.AddWithValue("@GiamGia", 1);
                            cmd.Parameters.AddWithValue("@NGAYSANXUAT", dtpNgaySX.Value);
                            cmd.Parameters.AddWithValue("@NGAYHETHAN", dtpNgayHH.Value);
                            cmd.Parameters.AddWithValue("@SOLUONGTON", 0);
                            cmd.Parameters.AddWithValue("@TRANGTHAI", 1);
                            cmd.Parameters.AddWithValue("@HINHANH", imageByteArray);
                            cmd.Parameters.AddWithValue("@BARCODE", imageByteArray2);
                            cmd.Parameters.AddWithValue("@GIANHAP",0);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenSP.ResetText();
                        rtxtboxMoTa.ResetText();
                        txtpic.Image = Supermaket.Properties.Resources.dairy_products;
                        txtMaSp.ResetText();
                        picbarcode.Image = Supermaket.Properties.Resources.testBarcode1;
                        txtTenSP.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lưu thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (id >0)
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    if (txtTenSP.Text == "" || txtMaSp.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập thông tin sản phẩm", "Thông báo", MessageBoxButtons.OK);
                    }
                    else if(barcode != txtMaSp.Text)
                    {
                        if (CheckBarcode(txtMaSp.Text) == false)
                        {
                            MessageBox.Show("Barcode đã có vui lòng nhập khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaSp.Text = barcode.ToString();
                        }    
                    }    
                    else
                    {
                        string sql = " UPDATE SANPHAM SET MABAR = @MABAR, TENSP=@TENSP, MANCC=@MANCC, MADM=@MADM, MoTa=@MOTA,SANPHAM.GiamGia=@GIAMGIA, NGAYSX=@NGAYSX, NGAYHH=@NGAYHH,HINHANH=@HINHANH,BARCODE=@BARCODE where IDSP = @IDSP";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@IDSP", id);
                            cmd.Parameters.AddWithValue("@MABAR", txtMaSp.Text);
                            cmd.Parameters.AddWithValue("@TENSP", txtTenSP.Text);
                            cmd.Parameters.AddWithValue("@MANCC", cbxNCC.SelectedValue);
                            cmd.Parameters.AddWithValue("@MADM", cbxMaDM.SelectedValue);
                            cmd.Parameters.AddWithValue("@MoTa", rtxtboxMoTa.Text);
                            cmd.Parameters.AddWithValue("@GiamGia", 1);
                            cmd.Parameters.AddWithValue("@NGAYSX", dtpNgaySX.Value);
                            cmd.Parameters.AddWithValue("@NGAYHH", dtpNgayHH.Value);
                            cmd.Parameters.AddWithValue("@HINHANH", imageByteArray);
                            cmd.Parameters.AddWithValue("@BARCODE", imageByteArray2);
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
        private List<string> checkloilist = new List<string>();
        private bool CheckBarcode(string sdt)
        {
            bool ktr = true;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"SELECT MABAR FROM SANPHAM";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                checkloilist.Add(row["MABAR"].ToString());
            }
            if (checkloilist.Contains(sdt))
            {
                ktr = false;
            }
            return ktr;
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
            if (id ==0)
            {
                Load_CBXDM();
                Load_CBXNCC();
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

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenSP.Text;
            if (input.Length > 100)
            {
                MessageBox.Show("Tên sản phẩm không được quá 100 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.ResetText();
            }
        }
        public void TaoBarCode()
        {
            string barcode = txtMaSp.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw br = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                picbarcode.Image = br.Draw(barcode, 60);
            }
            catch
            {
                MessageBox.Show("Chưa tạo được");
            }
        }
        private void txtMaSp_TextChanged(object sender, EventArgs e)
        {
            
            string input = txtMaSp.Text;
            if (input.Length > 13) // check length
            {
                MessageBox.Show("Mã sản phẩm không được nhập quá 13 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSp.ResetText();
                return;
            }
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Mã sản phẩm chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSp.ResetText();
                    break;
                }
            }
            if (txtMaSp.Text != "")
            {
                TaoBarCode();
            }
            else
            {
                picbarcode.Image = Supermaket.Properties.Resources.testBarcode1;
            }

        }

        private void cbxNCC_TextChanged(object sender, EventArgs e)
        {
            Load_CBXNCC();
        }

        private void cbxMaDM_TextChanged_1(object sender, EventArgs e)
        {
            Load_CBXDM();
        }
    }
}
