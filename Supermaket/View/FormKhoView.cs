using Supermaket.View.Kho;
using System;
using System.Windows.Forms;
namespace Supermaket.View
{
    public partial class FormKhoView : Mau
    {
        public FormKhoView()
        {
            InitializeComponent();
        }
        public void AddControls(Form f)
        {
            CenterPannel.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            CenterPannel.Controls.Add(f);
            f.Show();
        }

        private void btnHDnhap_Click(object sender, EventArgs e)
        {
            AddControls(new FormHoaDonNhapHang());
        }

        private void btnHDxuat_Click(object sender, EventArgs e)
        {
            AddControls(new FormHoaDonXuatHang());
        }

        private void FormKhoView_Load(object sender, EventArgs e)
        {
            btnHDnhap.Checked = true;
            btnHDnhap_Click(sender, e);
        }

        private void btnNhap_Click_1(object sender, EventArgs e)
        {
            AddControls(new FormNhapHang());
        }

        private void btnXuat_Click_1(object sender, EventArgs e)
        {
            AddControls(new FormXuatHang());
        }
    }
}
