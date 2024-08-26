using Supermaket.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Media;
namespace Supermaket
{
    public partial class FormPos : Mau
    {
        public static SqlConnection connection;
        FilterInfoCollection filter; // lưu camera vào
        VideoCaptureDevice video; // Biến tương tác với thiết bị video
        public FormPos()
        {
            InitializeComponent();
            connection = MainClass.GetConnection();
        }
        
        
        private void LoadNCC()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select * from NHACUNGCAP";
            SqlCommand cmd = new SqlCommand(sql, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            NCCPannel2.Controls.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(94, 148, 255);
                    b.Size = new Size(155, 30);
                    b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
                    b.Text = row["TENNCC"].ToString();
                    b.Click += new EventHandler(b_ClickNCC);
                    NCCPannel2.Controls.Add(b);
                }
            }    
        }
        private void b_ClickNCC(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            foreach (var item in flowLayoutPanel1.Controls)
            {
                if (item is PosSP)  
                {
                    var product = (PosSP)item;
                    product.Visible = product.Pnhacc.ToLower().Contains(b.Text.Trim().ToLower());
                }
            }
            
        }
        private void LoadDM()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"select * from DANHMUC";
            SqlCommand cmd = new SqlCommand(sql, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            DanhMucPannel1.Controls.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button c = new Guna.UI2.WinForms.Guna2Button();
                    c.FillColor = Color.FromArgb(94, 148, 255);
                    c.Size = new Size(155, 30);
                    c.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    c.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
                    c.Text = row["TENDM"].ToString();
                    c.Click += new EventHandler(b_ClickNDM);
                    DanhMucPannel1.Controls.Add(c);
                }
            }
        }

        private void b_ClickNDM(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            foreach (var item in flowLayoutPanel1.Controls)
            {
                if (item is PosSP)
                {
                    var product = (PosSP)item;
                    product.Visible = product.Pdmuc.ToLower().Contains(b.Text.Trim().ToLower());
                }
            }
        }

        private void LoadSP()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string sql = @"SELECT IDSP,MABAR,TENSP,GIAKM,DONGIA,TENDM,TENNCC,HINHANH,GIAMGIA,SOLUONGTON
                        FROM SANPHAM INNER JOIN DANHMUC ON SANPHAM.MADM = DANHMUC.MADM 
                                     INNER JOIN NHACUNGCAP ON SANPHAM.MANCC = NHACUNGCAP.MANCC
                        WHERE SANPHAM.TRANGTHAI = 1 and SOLUONGTON > 0 AND DONGIA IS NOT NULL  ORDER BY IDSP DESC;";
            SqlCommand cmd = new SqlCommand(sql, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows) 
            {
                Byte[] ImageArray = (byte[])(row["HINHANH"]); 
                byte[] ImageByteArray = ImageArray;
                AddItems(row["IDSP"].ToString(), row["MABAR"].ToString(), row["TENSP"].ToString(), ((double)row["GIAKM"]).ToString("N0"), ((double)row["DONGIA"]).ToString("N0"), row["TENDM"].ToString(), row["TENNCC"].ToString(), Image.FromStream(new MemoryStream(ImageArray)), (100 - (double)row["GIAMGIA"] * 100).ToString(), row["SOLUONGTON"].ToString());
            }
        }

        private void AddItems(string idsp,string mabar, string name, string giakm,string gia, string dm, string ncc, Image anh, string gg,string sl)
        {
            try
            {
                var w = new PosSP()
                {
                    pName = name,
                    pImage = anh,
                    pGiaKm = giakm,
                    pGia = gia,
                    Pdmuc = dm,
                    Pnhacc = ncc,
                    masp = mabar,
                    Pgg = gg,
                    slton = Convert.ToInt32(sl),
                    id = Convert.ToInt32(idsp)
                };
                flowLayoutPanel1.Controls.Add(w);// ss đối tượng đại diện cho người gửi sự kiện
                w.onSelect += (ss, ee) =>
                {
                    var wdg = (PosSP)ss;
                    foreach (DataGridViewRow item in data.Rows)
                    {
                        if (Convert.ToInt32(item.Cells["dgvIdSp"].Value) == wdg.id )
                        {
                            item.Cells["dgvSl"].Value = int.Parse(item.Cells["dgvSl"].Value.ToString()) + 1;
                            item.Cells["dgvTong"].Value = int.Parse(item.Cells["dgvSl"].Value.ToString()) * double.Parse(item.Cells["dgvGia"].Value.ToString());
                            TongTien();
                            return;
                        }
                    }
                    data.Rows.Add(new object[] { 0, wdg.id,wdg.masp, wdg.slton, wdg.pName, wdg.pGiaKm, 1, wdg.pGiaKm });
                    TongTien();
                };
               
            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }

            
        }
       
        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                var sanpham = (PosSP)item;
                sanpham.Visible = sanpham.pName.ToLower().Contains(txtTk.Text.Trim().ToLower());
            }
        }
        private void TongTien()
        {
            double total = 0;
            txtTong.Text = "";
            foreach (DataGridViewRow row in data.Rows)
            {
                total += double.Parse(row.Cells["dgvTong"].Value.ToString());
            }
            txtTong.Text = total.ToString("N0");
        }

        private void data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in data.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
            if (data.Columns[e.ColumnIndex].Name == "dgvGia" && e.Value != null)
            {
                double dongia;
                if (double.TryParse(e.Value.ToString(), out dongia))
                {
                    e.Value = dongia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
            if (data.Columns[e.ColumnIndex].Name == "dgvTong" && e.Value != null)
            {
                double dongia;
                if (double.TryParse(e.Value.ToString(), out dongia))
                {
                    e.Value = dongia.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }
        public void TinhTien()
        {
            float khachtra = 0;
            float tong = 0;
            float.TryParse(txtTong.Text, out tong);
            float.TryParse(txtTra.Text, out khachtra);
            if (khachtra >= tong)
            {
                btnThanhToan.Enabled = true;
                float thoi = khachtra - tong;
                txtThoi.Text = thoi.ToString("N0");
            }
            else
            {
                btnThanhToan.Enabled = false;
            }
            if (khachtra == 0)
            {
                btnThanhToan.Enabled = false;
            }
        }
        private void txtTra_TextChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void btnDon_Click(object sender, EventArgs e)
        {
            data.Rows.Clear();
            txtTong.Enabled = true ;
            txtTong.ResetText();
            txtTra.ResetText();
            txtThoi.Enabled=true ;
            txtThoi.ResetText();
            txtTong.Enabled=false;
            txtThoi.Enabled = false;
            btnThanhToan.Enabled=false;
            foreach (Control cc in DanhMucPannel1.Controls)
            {
                if (cc is Guna.UI2.WinForms.Guna2Button)
                {
                    Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)cc;
                    b.Checked = false;
                }
            }
            foreach (Control cc in NCCPannel2.Controls)
            {
                if (cc is Guna.UI2.WinForms.Guna2Button)
                {
                    Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)cc;
                    b.Checked = false;
                }
            }
            txtTk.ResetText();
            txtTk_TextChanged(sender, e);
            btnKetThuc_Click(sender, e);
        }
        private DataTable CreatePaymentData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã SP", typeof(int));
            dt.Columns.Add("Tên SP", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Đơn giá", typeof(float));
            dt.Columns.Add("Thành tiền", typeof(float));
            return dt;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            FormThanhToan toan = new FormThanhToan();
            toan.tong = float.Parse(txtTong.Text);
            toan.tienmat = float.Parse(txtTra.Text);
            toan.tienthoi = float.Parse(txtThoi.Text);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql1 = "INSERT INTO HOADON (MANV)VALUES(@MANV)";
            SqlCommand cmd = new SqlCommand(sql1, connection);
            cmd.Parameters.AddWithValue("@MANV", MainClass.MaNV);
            cmd.ExecuteNonQuery();
            DataTable paymentData = CreatePaymentData();
            int dem = 0;
            foreach (DataGridViewRow row in data.Rows)
            {
                dem++;
                int maSp = Convert.ToInt32(row.Cells["dgvIdSp"].Value); 
                string tenSp = row.Cells["dgvTen"].Value.ToString();
                int soLuong = Convert.ToInt32(row.Cells["dgvSl"].Value);
                float donGia = float.Parse(row.Cells["dgvGia"].Value.ToString());
                float thanhTien = soLuong * donGia;
                paymentData.Rows.Add(dem,maSp, tenSp, soLuong, donGia, thanhTien );
            }
            toan.data.DataSource = paymentData;
            toan.data.AllowUserToAddRows = false;
            toan.ShowDialog();
            btnDon_Click(sender,e);
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (data.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nó không ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int rowindex = data.CurrentCell.RowIndex;
                    data.Rows.RemoveAt(rowindex);
                    TongTien();
                }    
            }
        }

        private void txtTong_TextChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double thanhtien = 0;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string columnName = data.Columns[e.ColumnIndex].Name;

                if (columnName == "dgvSl" || columnName == "dgvGia")
                {
                    
                    if (double.TryParse(data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out _))
                    {
                        int rowIndex = e.RowIndex;
                        int soLuong = Convert.ToInt32(data.Rows[rowIndex].Cells["dgvSl"].Value);
                        float gia = Convert.ToSingle(data.Rows[rowIndex].Cells["dgvGia"].Value);
                        int slton = Convert.ToInt32(data.Rows[rowIndex].Cells["dgvslton"].Value);
                        if (soLuong == 0 || soLuong > slton)
                        {
                            if (soLuong == 0)
                            {
                                MessageBox.Show("Số lượng không thể bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                            } 
                            if (soLuong > slton)
                            {
                                MessageBox.Show("Số lượng không thể lớn hơn số lượng hiện có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                            }    
                            
                        }
                        else
                        {
                            thanhtien = soLuong * gia;
                            data.Rows[rowIndex].Cells["dgvTong"].Value = thanhtien;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào cột số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; 
                    }
                }
            }
            TongTien();
        }
        public void FormPos_Load(object sender, EventArgs e)
        {
            LoadDM();
            LoadSP();
            LoadNCC();
            data.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            data.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filter)
            {
                cbxCam.Items.Add(filterInfo.Name);
            }

            if (cbxCam.Items.Count > 0)
            {
                cbxCam.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Không có camera.");
            }
        }
        private void btnBatdau_Click(object sender, EventArgs e)
        {
            // Khởi tạo thiết bị video, dựa trên thiết bị được chọn
            video = new VideoCaptureDevice(filter[cbxCam.SelectedIndex].MonikerString);
            // Đăng ký nhận sự kiện frame mới từ camera
            video.NewFrame += VideoCaptureDevice_NewFrame;
            video.Start();
        }
        private Timer timer;
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Nhả frame hình ảnh từ camera
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();// tạo đối tượng barcode
            var ketqua = reader.Decode(bitmap); // doc bar code tu hinh anh
            if (ketqua != null)
            {
                txtKetQua.Invoke(new MethodInvoker(delegate () // xác định mã sẽ được thực thi trên luồng dữ liệu
                {
                    txtKetQua.Text = ketqua.ToString(); //hiển thị kết quả đọc được

                    // kiểm tra xem mã bar có khớp với mã bar trong PosSp hay không ?
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        PosSP wdg = control as PosSP;
                        if (wdg != null && wdg.masp == txtKetQua.Text)
                        {
                            if (timer == null || !timer.Enabled)
                            {
                                wdg.picsp_Click(wdg, new EventArgs());
                                timer = new Timer { Interval = 9000 / 3 };
                                timer.Tick += (s, e) => timer.Stop();
                                timer.Start();
                                Music("bip.wav");
                            }
                            //break;
                        }
                    }
                }
                ));
            }
            picimg.Image = bitmap; //hienthi frame hinh anh len
        }
        private void Music(string filepath)
        {
            SoundPlayer music = new SoundPlayer();
            music.SoundLocation = filepath;
            music.Play();
        }
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            if (video != null)
            {
                if (video.IsRunning)
                {
                    video.Stop();
                    picimg.Image = null;
                }
            }
        }

        private void FormPos_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnKetThuc_Click(sender, e);
        }
      
    }
}
