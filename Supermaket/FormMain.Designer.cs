namespace Supermaket
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMax = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnThoat = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.CenterPannel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.titleThungRac = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleQuanLy = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleKho = new Guna.UI2.WinForms.Guna2TileButton();
            this.titlePOS = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleSanPham = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleTrangChu = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.Controls.Add(this.lblChucVu);
            this.guna2Panel1.Controls.Add(this.lbUser);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.btnMax);
            this.guna2Panel1.Controls.Add(this.btnThoat);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel1.FillColor = System.Drawing.Color.DodgerBlue;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1215, 57);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblChucVu.ForeColor = System.Drawing.Color.White;
            this.lblChucVu.Location = new System.Drawing.Point(83, 36);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(43, 17);
            this.lblChucVu.TabIndex = 8;
            this.lblChucVu.Text = "label1";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.White;
            this.lbUser.Location = new System.Drawing.Point(82, 9);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(57, 21);
            this.lbUser.TabIndex = 7;
            this.lbUser.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBox1.Image = global::Supermaket.Properties.Resources.hacker;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMax.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMax.IconColor = System.Drawing.Color.White;
            this.btnMax.Location = new System.Drawing.Point(1103, 12);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(45, 29);
            this.btnMax.TabIndex = 5;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnThoat.IconColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(1154, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(45, 29);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1052, 12);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 2;
            // 
            // CenterPannel
            // 
            this.CenterPannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CenterPannel.BorderRadius = 17;
            this.CenterPannel.Location = new System.Drawing.Point(12, 63);
            this.CenterPannel.Name = "CenterPannel";
            this.CenterPannel.Size = new System.Drawing.Size(1191, 450);
            this.CenterPannel.TabIndex = 1;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel3.BorderRadius = 17;
            this.guna2Panel3.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel3.Controls.Add(this.titleThungRac);
            this.guna2Panel3.Controls.Add(this.titleQuanLy);
            this.guna2Panel3.Controls.Add(this.titleKho);
            this.guna2Panel3.Controls.Add(this.titlePOS);
            this.guna2Panel3.Controls.Add(this.titleSanPham);
            this.guna2Panel3.Controls.Add(this.titleTrangChu);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.guna2Panel3.Location = new System.Drawing.Point(0, 520);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1215, 162);
            this.guna2Panel3.TabIndex = 2;
            // 
            // titleThungRac
            // 
            this.titleThungRac.BackColor = System.Drawing.Color.Transparent;
            this.titleThungRac.BorderRadius = 10;
            this.titleThungRac.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleThungRac.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleThungRac.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleThungRac.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleThungRac.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleThungRac.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleThungRac.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleThungRac.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleThungRac.ForeColor = System.Drawing.Color.White;
            this.titleThungRac.Image = ((System.Drawing.Image)(resources.GetObject("titleThungRac.Image")));
            this.titleThungRac.ImageSize = new System.Drawing.Size(40, 40);
            this.titleThungRac.Location = new System.Drawing.Point(592, 24);
            this.titleThungRac.Name = "titleThungRac";
            this.titleThungRac.Size = new System.Drawing.Size(110, 105);
            this.titleThungRac.TabIndex = 5;
            this.titleThungRac.Text = "Thùng rác";
            this.titleThungRac.Click += new System.EventHandler(this.titleThungRac_Click);
            // 
            // titleQuanLy
            // 
            this.titleQuanLy.BackColor = System.Drawing.Color.Transparent;
            this.titleQuanLy.BorderRadius = 10;
            this.titleQuanLy.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleQuanLy.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleQuanLy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleQuanLy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleQuanLy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleQuanLy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleQuanLy.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleQuanLy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleQuanLy.ForeColor = System.Drawing.Color.White;
            this.titleQuanLy.Image = ((System.Drawing.Image)(resources.GetObject("titleQuanLy.Image")));
            this.titleQuanLy.ImageSize = new System.Drawing.Size(40, 40);
            this.titleQuanLy.Location = new System.Drawing.Point(476, 24);
            this.titleQuanLy.Name = "titleQuanLy";
            this.titleQuanLy.Size = new System.Drawing.Size(110, 105);
            this.titleQuanLy.TabIndex = 4;
            this.titleQuanLy.Text = "Quản lý";
            this.titleQuanLy.Click += new System.EventHandler(this.titleQuanLy_Click);
            // 
            // titleKho
            // 
            this.titleKho.BackColor = System.Drawing.Color.Transparent;
            this.titleKho.BorderRadius = 10;
            this.titleKho.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleKho.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleKho.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleKho.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleKho.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleKho.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleKho.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleKho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleKho.ForeColor = System.Drawing.Color.White;
            this.titleKho.Image = ((System.Drawing.Image)(resources.GetObject("titleKho.Image")));
            this.titleKho.ImageSize = new System.Drawing.Size(40, 40);
            this.titleKho.Location = new System.Drawing.Point(360, 24);
            this.titleKho.Name = "titleKho";
            this.titleKho.Size = new System.Drawing.Size(110, 105);
            this.titleKho.TabIndex = 3;
            this.titleKho.Text = "Kho";
            this.titleKho.Click += new System.EventHandler(this.titleKho_Click);
            // 
            // titlePOS
            // 
            this.titlePOS.BackColor = System.Drawing.Color.Transparent;
            this.titlePOS.BorderRadius = 10;
            this.titlePOS.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titlePOS.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titlePOS.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titlePOS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titlePOS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titlePOS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titlePOS.FillColor = System.Drawing.Color.DodgerBlue;
            this.titlePOS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlePOS.ForeColor = System.Drawing.Color.White;
            this.titlePOS.Image = ((System.Drawing.Image)(resources.GetObject("titlePOS.Image")));
            this.titlePOS.ImageSize = new System.Drawing.Size(40, 40);
            this.titlePOS.Location = new System.Drawing.Point(244, 24);
            this.titlePOS.Name = "titlePOS";
            this.titlePOS.Size = new System.Drawing.Size(110, 105);
            this.titlePOS.TabIndex = 2;
            this.titlePOS.Text = "POS";
            this.titlePOS.Click += new System.EventHandler(this.titlePOS_Click);
            // 
            // titleSanPham
            // 
            this.titleSanPham.BackColor = System.Drawing.Color.Transparent;
            this.titleSanPham.BorderRadius = 10;
            this.titleSanPham.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleSanPham.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleSanPham.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleSanPham.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleSanPham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleSanPham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleSanPham.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleSanPham.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleSanPham.ForeColor = System.Drawing.Color.White;
            this.titleSanPham.Image = ((System.Drawing.Image)(resources.GetObject("titleSanPham.Image")));
            this.titleSanPham.ImageSize = new System.Drawing.Size(40, 40);
            this.titleSanPham.Location = new System.Drawing.Point(128, 24);
            this.titleSanPham.Name = "titleSanPham";
            this.titleSanPham.Size = new System.Drawing.Size(110, 105);
            this.titleSanPham.TabIndex = 1;
            this.titleSanPham.Text = "Sản phẩm";
            this.titleSanPham.Click += new System.EventHandler(this.titleSanPham_Click);
            // 
            // titleTrangChu
            // 
            this.titleTrangChu.BackColor = System.Drawing.Color.Transparent;
            this.titleTrangChu.BorderRadius = 10;
            this.titleTrangChu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleTrangChu.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleTrangChu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleTrangChu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleTrangChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleTrangChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleTrangChu.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleTrangChu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTrangChu.ForeColor = System.Drawing.Color.White;
            this.titleTrangChu.Image = ((System.Drawing.Image)(resources.GetObject("titleTrangChu.Image")));
            this.titleTrangChu.ImageSize = new System.Drawing.Size(40, 40);
            this.titleTrangChu.Location = new System.Drawing.Point(12, 24);
            this.titleTrangChu.Name = "titleTrangChu";
            this.titleTrangChu.Size = new System.Drawing.Size(110, 105);
            this.titleTrangChu.TabIndex = 0;
            this.titleTrangChu.Text = "Trang chủ";
            this.titleTrangChu.Click += new System.EventHandler(this.titleTrangChu_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BorderRadius = 17;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.DodgerBlue;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(1044, 15);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(155, 135);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 7;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 682);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.CenterPannel);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel CenterPannel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox btnThoat;
        private Guna.UI2.WinForms.Guna2ControlBox btnMax;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Guna.UI2.WinForms.Guna2TileButton titleTrangChu;
        public Guna.UI2.WinForms.Guna2TileButton titleThungRac;
        public Guna.UI2.WinForms.Guna2TileButton titleQuanLy;
        public Guna.UI2.WinForms.Guna2TileButton titleKho;
        public Guna.UI2.WinForms.Guna2TileButton titlePOS;
        public Guna.UI2.WinForms.Guna2TileButton titleSanPham;
        public System.Windows.Forms.Label lblChucVu;
        public System.Windows.Forms.Label lbUser;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}