using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermaket.View.ThongBao
{
    public partial class UserTB : UserControl
    {
        public UserTB()
        {
            InitializeComponent();
        }
        public string masp
        {
            get { return txtmasp.Text; }
            set { txtmasp.Text = value; }
        }
        public string tensp
        {
            get { return txttensp.Text; }
            set { txttensp.Text = value; }
        }
        public string hh
        {
            get { return txtngayhh.Text; }
            set
            {
                DateTime dateValue;
                if (DateTime.TryParse(value, out dateValue)) // ÉP KIỂU THÀNH DATE
                {
                    txtngayhh.Text = dateValue.ToString("dd-MM-yyyy"); // Định dạng lại
                }
            }
        }

        public Image anh
        {
            get { return picsp2.Image; }
            set { picsp2.Image = value; }
        }
    }
}
