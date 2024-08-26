using Supermaket.View.ThungRac;
using System;
using System.Windows.Forms;

namespace Supermaket.View
{
    public partial class FormThungRac : Mau
    {
        public FormThungRac()
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
            AddControls(new FormThungRacView1());
        }

        private void FormThungRac_Load(object sender, EventArgs e)
        {
            titleSanPham1.Checked = true;
            titleSanPham1_Click(sender,e);
        }

        private void titleNhanVien_Click(object sender, EventArgs e)
        {
            AddControls(new FormThungRacView2());
        }
    }
}
