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
    public partial class MauView : Mau
    {
        public MauView()
        {
            InitializeComponent();
        }

        public virtual void btnAdd_Click(object sender, EventArgs e)
        {

        }

        public virtual void txtTk_TextChanged(object sender, EventArgs e)
        {

        }


        public virtual void data_DoubleClick(object sender, EventArgs e)
        {

        }

        private void MauView_Load(object sender, EventArgs e)
        {
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12,FontStyle.Regular);
        }

        public virtual void data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
