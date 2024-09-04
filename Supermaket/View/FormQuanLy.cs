using System;
using System.Windows.Forms;

namespace Supermaket.View
{
    public partial class FormQuanLy : Mau
    {
        public FormQuanLy()
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

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            AddControls(new FormKhachHangView());
        }

     

        private void titleHoaDon_Click(object sender, EventArgs e)
        {
            AddControls(new FormHoaDonView());
        }

        private void titleNhanVien_Click(object sender, EventArgs e)
        {
            AddControls(new FormNhanVienView());
        }

        private void titleKhuyenMai_Click(object sender, EventArgs e)
        {
            AddControls(new FormKhuyenMaiView());
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            titleHoaDon.Checked = true;
            AddControls(new FormHoaDonView());
        }

    }
}
