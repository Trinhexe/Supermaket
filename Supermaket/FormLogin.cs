using Guna.UI2.WinForms;
using Supermaket;
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

namespace Supermaket
{
    public partial class FormLogin : Mau
    {
        
        public static SqlConnection connection;
        public FormLogin()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (txtTK.Text == "" || txtMK.Text == "")
            {
                
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            if(MainClass.ChiTietNV(txtTK.Text,txtMK.Text)==true)
            {
                FormLoading load = new FormLoading();
                load.ShowDialog();
                this.Hide();
            }    
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtTK.ResetText();
                txtMK.ResetText();
                txtTK.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


