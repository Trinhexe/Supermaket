using Supermaket.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermaket.View;

namespace Supermaket
{
    public partial class PosSP : UserControl
    {
        public EventHandler onSelect = null;
        public PosSP()
        {
            InitializeComponent();
        }
        public int id { get; set; }
        public int slton { get; set; }
        public string masp { get; set; }
        public string Pdmuc {  get; set; }
        public string Pnhacc { get; set; }
        public string Pgg
        {
            get { return Pgg; }
            set { btnUserCtrPercent.Text = value; }
        }
        public string pName
        {
            get { return txttensp.Text; }
            set { txttensp.Text = value; }
        }
        public string pGia
        {
            get { return txtgiasp.Text; }
            set { txtgiasp.Text = value; }
        }
        public string pGiaKm
        {
            get { return txtgiakm.Text; }
            set { txtgiakm.Text = value; }
        }
        public Image pImage
        {
            get { return picsp.Image; }
            set { picsp.Image = value; }
        }

        public void picsp_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new FormChiTietSP() { idv = id });
        }

        //private void PosSP_MouseEnter(object sender, EventArgs e)
        //{
        //    this.BackColor = Color.LightCyan;
        //}

        //private void PosSP_MouseLeave(object sender, EventArgs e)
        //{
        //    this.BackColor = Color.WhiteSmoke;
        //}
    }
}
