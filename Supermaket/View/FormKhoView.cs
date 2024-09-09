using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermaket.View.Kho;
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

        private void btnNhap_Click(object sender, EventArgs e)
        {
            AddControls(new FormNhapXuat());
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            AddControls(new FormXuatHang());
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
            btnNhap.Checked = true;
            AddControls(new FormNhapXuat());
        }
    }
}
