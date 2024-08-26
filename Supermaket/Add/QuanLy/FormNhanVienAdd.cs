using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Supermaket.Model
{
    public partial class FormNhanVienAdd : Mau
    {
        public static SqlConnection connection;
        public FormNhanVienAdd()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        public int id = 0;
        public string tk1;
        public string sdt;
        public string gmail;
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                    else if (txtTK.Text == "" || txtMk.Text == "" || txtHoTennv.Text == "" || txtSDTnv.Text == "" || txtDiaChinv.Text == "" || txtgmailnv.Text == "" || (ckNam.Checked == false && ckNu.Checked == false))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string sql = "INSERT INTO NHANVIEN (HOVATEN, TAIKHOAN,MATKHAU, DIACHI,GIOITINH,NGAYSINH,SDT,EMAIL,MACV,TRANGTHAI) VALUES (@HOVATEN, @TAIKHOAN,@MATKHAU, @DIACHI,@GIOITINH,@NGAYSINH,@SDT,@EMAIL,@MACV,@TRANGTHAI)";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@HOVATEN", txtHoTennv.Text);
                        cmd.Parameters.AddWithValue("@TAIKHOAN", txtTK.Text);
                        cmd.Parameters.AddWithValue("@MATKHAU", txtMk.Text);
                        cmd.Parameters.AddWithValue("@DIACHI", txtDiaChinv.Text);
                        if (ckNu.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@GIOITINH", 0);
                        }
                        if (ckNam.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@GIOITINH", 1);
                        }
                        cmd.Parameters.AddWithValue("@NGAYSINH", dtpngaysinhnv.Value);
                        cmd.Parameters.AddWithValue("@SDT", txtSDTnv.Text);
                        cmd.Parameters.AddWithValue("@EMAIL", txtgmailnv.Text);
                        cmd.Parameters.AddWithValue("@MACV", cbxChucVu.SelectedValue);
                        cmd.Parameters.AddWithValue("@TRANGTHAI", 1);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtHoTennv.ResetText();
                        txtTK.ResetText();
                        txtMk.ResetText();
                        txtDiaChinv.ResetText();
                        txtSDTnv.ResetText();
                        cbxChucVu.ResetText();
                        txtHoTennv.Focus();
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
                    else if (txtTK.Text == "" || txtMk.Text == "" || txtHoTennv.Text == "" || txtSDTnv.Text == "" || txtDiaChinv.Text == "" || txtgmailnv.Text == "" || (ckNam.Checked == false && ckNu.Checked == false))
                    {
                        MessageBox.Show("Không được để trống thông tin nhân viên", "Thông báo", MessageBoxButtons.OK);
                    }
                    else /*if(CheckGmail(txtgmailnv.Text) == true && CheckTK(txtTK.Text) == true && CheckSDT(txtSDTnv.Text) == true)*/
                    {
                        string sql = "UPDATE NHANVIEN SET HOVATEN = @HOVATEN, TAIKHOAN=@TAIKHOAN,MATKHAU=@MATKHAU, DIACHI=@DIACHI,GIOITINH=@GIOITINH,NGAYSINH=@NGAYSINH,SDT=@SDT,EMAIL=@EMAIL,MACV=@MACV WHERE MANV = @MANV";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@MANV", id);
                            cmd.Parameters.AddWithValue("@HOVATEN", txtHoTennv.Text);
                            cmd.Parameters.AddWithValue("@TAIKHOAN", txtTK.Text);
                            cmd.Parameters.AddWithValue("@MATKHAU", txtMk.Text);
                            cmd.Parameters.AddWithValue("@DIACHI", txtDiaChinv.Text);
                            if (ckNu.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@GIOITINH", 0);
                            }
                            if (ckNam.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@GIOITINH", 1);
                            }
                            cmd.Parameters.AddWithValue("@NGAYSINH", dtpngaysinhnv.Value);
                            cmd.Parameters.AddWithValue("@SDT", txtSDTnv.Text);
                            cmd.Parameters.AddWithValue("@EMAIL", txtgmailnv.Text);
                            cmd.Parameters.AddWithValue("@MACV", cbxChucVu.SelectedValue);
                            cmd.Parameters.AddWithValue("@TRANGTHAI", 1);
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
        private List<string> checkloilist = new List<string>();
        private bool CheckTK(string tk)
        {
            bool ktr = true;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"SELECT TAIKHOAN FROM NHANVIEN";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                checkloilist.Add(row["TAIKHOAN"].ToString());
            }
            if (checkloilist.Contains(tk))
            {
                ktr = false;
            }
            return ktr;
        }
        private bool CheckSDT(string sdt)
        {
            bool ktr = true;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"SELECT SDT FROM NHANVIEN";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                checkloilist.Add(row["SDT"].ToString());
            }
            if (checkloilist.Contains(sdt))
            {
                ktr = false;
            }
            return ktr;
        }
        private bool CheckGmail(string gmail)
        {
            bool ktr = true;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"SELECT EMAIL FROM NHANVIEN";
            SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                checkloilist.Add(row["EMAIL"].ToString());
            }
            if (checkloilist.Contains(gmail))
            {
                ktr = false;
            }
            return ktr;
        }
        private void FormNhanVienAdd_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                LoadCbxChucVu();
            }
        }
        private void LoadCbxChucVu()
        {
            string sql = "select TENCV,MACV from CHUCVU";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            cbxChucVu.DataSource = ds;
            cbxChucVu.DisplayMember = "TENCV";
            cbxChucVu.ValueMember = "MACV";
        }
       

        private void cbxChucVu_TextChanged_1(object sender, EventArgs e)
        {
            LoadCbxChucVu();
        }



        private void txtSDTnv_TextChanged(object sender, EventArgs e)
        {
            string input = txtSDTnv.Text;
            if (input.Length > 11) // check length
            {
                MessageBox.Show("SĐT không được nhập quá 11 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDTnv.ResetText();
                return;
            }
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("SĐT chỉ được nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDTnv.ResetText();
                    break;
                }
            }
            if (id == 0)
            {
                if (CheckSDT(txtSDTnv.Text) == false)
                {
                    MessageBox.Show("Số điện thoại đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDTnv.ResetText();
                }
            }
            
        }

        private void txtHoTennv_TextChanged(object sender, EventArgs e)
        {
            string input = txtHoTennv.Text;
            if (input.Length > 50)
            {
                MessageBox.Show("Tên nhân viên không được quá 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTennv.ResetText();
            }
        }

        private void txtDiaChinv_TextChanged(object sender, EventArgs e)
        {
            string input = txtDiaChinv.Text;
            if (input.Length > 100)
            {
                MessageBox.Show("Địa chỉ không được quá 100 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChinv.ResetText();
            }
        }
        
        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            string input = txtTK.Text;
            if (input.Length > 50)
            {
                MessageBox.Show("Tài khoản không được quá 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTK.ResetText();
            }
            if (id ==0)
            {
                if (CheckTK(txtTK.Text) == false)
                {
                    MessageBox.Show("Tài khoản đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTK.ResetText();
                }
            }    
         
        }

        private void txtMk_TextChanged(object sender, EventArgs e)
        {
            string input = txtMk.Text;
            if (input.Length > 50)
            {
                MessageBox.Show("Mật khẩu không được quá 50 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMk.ResetText();
            }
        }

        private void txtgmailnv_Validating(object sender, CancelEventArgs e)
        {
            string input = txtgmailnv.Text;
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Định dạng Gmail không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgmailnv.ResetText();
            }
        }

        private void txtSDTnv_Validated(object sender, EventArgs e)
        {
            if (id > 0)
            {
                if (sdt != txtSDTnv.Text)
                {
                    if (CheckSDT(txtSDTnv.Text) == false)
                    {
                        MessageBox.Show("Số điện thoại đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSDTnv.Text = sdt.ToString();
                    }
                }
            }
        }

        private void txtgmailnv_Validated(object sender, EventArgs e)
        {
            if (id > 0)
            {
                if (gmail != txtgmailnv.Text)
                {
                    if (CheckGmail(txtgmailnv.Text) == false)
                    {
                        MessageBox.Show("Gmail đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtgmailnv.Text = gmail.ToString();
                    }
                }
            }
        }

        private void txtgmailnv_TextChanged(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (gmail != txtgmailnv.Text)
                {
                    if (CheckGmail(txtgmailnv.Text) == false)
                    {
                        MessageBox.Show("Gmail đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtgmailnv.ResetText();
                    }
                }
            }
        }

        private void txtTK_Validated(object sender, EventArgs e)
        {
            if (id > 0)
            {
                if (tk1 != txtTK.Text)
                {
                    if (CheckTK(txtTK.Text) == false)
                    {
                        MessageBox.Show("Tài khoản đã có vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTK.Text = tk1.ToString();
                    }
                }
            }
        }
    }
}
