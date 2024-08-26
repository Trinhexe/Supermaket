using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermaket.View
{
    public partial class FormSanPhamView : Mau
    {
        public FormSanPhamView()
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

        private void titleSanPham1_Click(object sender, EventArgs e)
        {
            AddControls(new FormSanPhamView1());
        }

        private void titleDanhMuc_Click(object sender, EventArgs e)
        {
            AddControls(new FormDanhMucView());
        }

        private void titleNhaCungCap_Click(object sender, EventArgs e)
        {
            AddControls(new FormNhaCungCapView());
        }

        private void FormSanPhamView_Load(object sender, EventArgs e)
        {
            titleSanPham1.Checked = true;
            titleSanPham1_Click(sender, e);
        }
    }
}
