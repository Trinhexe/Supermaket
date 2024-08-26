using Guna.UI2.WinForms;
using Supermaket.View;
using Supermaket.View.TrangChu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermaket
{
    public partial class FormMain : Mau
    {
        

        public FormMain()
        {
            InitializeComponent();
        }
        static FormMain _obj;
        public static FormMain Instance
        {
            get { if (_obj == null) { _obj = new FormMain(); } return _obj; }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            _obj = this;
            btnMax.PerformClick();
            if(MainClass.ChucVu =="Thu ngân")
            {
                titleTrangChu.Hide();
                titleSanPham.Hide();
                titleKho.Hide();
                titleQuanLy.Hide();
                titleThungRac.Hide();
                titlePOS.Checked = true;
                titlePOS_Click(sender,e);
            }
            else if (MainClass.ChucVu =="Kho")
            {
                titleTrangChu.Hide();
                titlePOS.Hide();
                titleQuanLy.Hide();
                titleThungRac.Hide();
                titleSanPham.Hide();
                titleKho.Checked = true;
                titleKho_Click(sender,e);
            }
            else
            {
                titleTrangChu.Checked = true;
                titleTrangChu_Click(sender, e);
            }    
            lbUser.Text = MainClass.HoTen;
            lblChucVu.Text = MainClass.ChucVu;
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void AddControls(Form f)
        {
            CenterPannel.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            CenterPannel.Controls.Add(f);
            f.Show();
        }

        private void titleTrangChu_Click(object sender, EventArgs e)
        {
            AddControls(new FormTrangChu());
        }

        private void titleSanPham_Click(object sender, EventArgs e)
        {
            AddControls(new FormSanPhamView());
        }

        private void titlePOS_Click(object sender, EventArgs e)
        {
            AddControls(new FormPos());
        }

        private void titleKho_Click(object sender, EventArgs e)
        {
            AddControls(new FormKhoView());
        }

        private void titleQuanLy_Click(object sender, EventArgs e)
        {
            AddControls(new FormQuanLy());
        }

        private void titleThungRac_Click(object sender, EventArgs e)
        {
            AddControls(new FormThungRac());
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có đăng xuất ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                FormLogin login = new FormLogin();
                login.Show();
                this.Hide();
            }
        }
    }
}
