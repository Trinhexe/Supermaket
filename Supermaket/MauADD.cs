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
    public partial class MauADD : Mau
    {
        public MauADD()
        {
            InitializeComponent();
        }
        
        public virtual void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
