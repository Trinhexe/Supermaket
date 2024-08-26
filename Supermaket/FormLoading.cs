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
    public partial class FormLoading : Mau
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 20;
            if (panel2.Width >= 900)
            {
                timer1.Stop();
                FormMain main = new FormMain();
                main.Show();
                this.Hide();
            }
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {

        }
    }
}
