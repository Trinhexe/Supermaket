using Supermaket.View.TrangChu;
using System;
using System.Windows.Forms;

namespace Supermaket.View
{
    public partial class FormTrangChu : Mau
    {
        public FormTrangChu()
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

        private void titleChung_Click(object sender, EventArgs e)
        {
            AddControls(new FormChung());
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            titleChung.Checked = true;
            titleChung_Click(sender,e);
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            AddControls(new FormTKSP());
        }

        private void guna2TileButton1_Click_1(object sender, EventArgs e)
        {
            AddControls(new FormTKHO());
        }
    }
}
