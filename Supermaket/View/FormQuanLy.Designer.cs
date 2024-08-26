namespace Supermaket.View
{
    partial class FormQuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuanLy));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.titleKhuyenMai = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleHoaDon = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleKhachHang = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleNhanVien = new Guna.UI2.WinForms.Guna2TileButton();
            this.CenterPannel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2Panel1.Controls.Add(this.titleKhuyenMai);
            this.guna2Panel1.Controls.Add(this.titleHoaDon);
            this.guna2Panel1.Controls.Add(this.titleKhachHang);
            this.guna2Panel1.Controls.Add(this.titleNhanVien);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(12, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(215, 666);
            this.guna2Panel1.TabIndex = 1;
            // 
            // titleKhuyenMai
            // 
            this.titleKhuyenMai.BackColor = System.Drawing.Color.Transparent;
            this.titleKhuyenMai.BorderRadius = 10;
            this.titleKhuyenMai.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleKhuyenMai.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleKhuyenMai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleKhuyenMai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleKhuyenMai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleKhuyenMai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleKhuyenMai.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleKhuyenMai.ForeColor = System.Drawing.Color.White;
            this.titleKhuyenMai.Image = ((System.Drawing.Image)(resources.GetObject("titleKhuyenMai.Image")));
            this.titleKhuyenMai.ImageOffset = new System.Drawing.Point(0, 9);
            this.titleKhuyenMai.ImageSize = new System.Drawing.Size(45, 45);
            this.titleKhuyenMai.Location = new System.Drawing.Point(19, 216);
            this.titleKhuyenMai.Name = "titleKhuyenMai";
            this.titleKhuyenMai.Size = new System.Drawing.Size(178, 80);
            this.titleKhuyenMai.TabIndex = 1;
            this.titleKhuyenMai.Text = "Khuyến mãi";
            this.titleKhuyenMai.Click += new System.EventHandler(this.titleKhuyenMai_Click);
            // 
            // titleHoaDon
            // 
            this.titleHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.titleHoaDon.BorderRadius = 10;
            this.titleHoaDon.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleHoaDon.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleHoaDon.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleHoaDon.ForeColor = System.Drawing.Color.White;
            this.titleHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("titleHoaDon.Image")));
            this.titleHoaDon.ImageSize = new System.Drawing.Size(36, 36);
            this.titleHoaDon.Location = new System.Drawing.Point(19, 44);
            this.titleHoaDon.Name = "titleHoaDon";
            this.titleHoaDon.Size = new System.Drawing.Size(178, 80);
            this.titleHoaDon.TabIndex = 1;
            this.titleHoaDon.Text = "Hóa đơn";
            this.titleHoaDon.Click += new System.EventHandler(this.titleHoaDon_Click);
            // 
            // titleKhachHang
            // 
            this.titleKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.titleKhachHang.BorderRadius = 10;
            this.titleKhachHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleKhachHang.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleKhachHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleKhachHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleKhachHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleKhachHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleKhachHang.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleKhachHang.ForeColor = System.Drawing.Color.White;
            this.titleKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("titleKhachHang.Image")));
            this.titleKhachHang.ImageOffset = new System.Drawing.Point(0, 8);
            this.titleKhachHang.ImageSize = new System.Drawing.Size(47, 47);
            this.titleKhachHang.Location = new System.Drawing.Point(19, 302);
            this.titleKhachHang.Name = "titleKhachHang";
            this.titleKhachHang.Size = new System.Drawing.Size(178, 80);
            this.titleKhachHang.TabIndex = 1;
            this.titleKhachHang.Text = "Khách hàng";
            this.titleKhachHang.Click += new System.EventHandler(this.guna2TileButton3_Click);
            // 
            // titleNhanVien
            // 
            this.titleNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.titleNhanVien.BorderRadius = 10;
            this.titleNhanVien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleNhanVien.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleNhanVien.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleNhanVien.ForeColor = System.Drawing.Color.White;
            this.titleNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("titleNhanVien.Image")));
            this.titleNhanVien.ImageOffset = new System.Drawing.Point(0, 5);
            this.titleNhanVien.ImageSize = new System.Drawing.Size(45, 45);
            this.titleNhanVien.Location = new System.Drawing.Point(19, 130);
            this.titleNhanVien.Name = "titleNhanVien";
            this.titleNhanVien.Size = new System.Drawing.Size(178, 80);
            this.titleNhanVien.TabIndex = 1;
            this.titleNhanVien.Text = "Nhân viên";
            this.titleNhanVien.Click += new System.EventHandler(this.titleNhanVien_Click);
            // 
            // CenterPannel
            // 
            this.CenterPannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CenterPannel.Location = new System.Drawing.Point(233, 12);
            this.CenterPannel.Name = "CenterPannel";
            this.CenterPannel.Size = new System.Drawing.Size(762, 666);
            this.CenterPannel.TabIndex = 2;
            // 
            // FormQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 690);
            this.Controls.Add(this.CenterPannel);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FormQuanLy";
            this.Text = "FormQuanLy";
            this.Load += new System.EventHandler(this.FormQuanLy_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TileButton titleHoaDon;
        private Guna.UI2.WinForms.Guna2Panel CenterPannel;
        private Guna.UI2.WinForms.Guna2TileButton titleKhuyenMai;
        private Guna.UI2.WinForms.Guna2TileButton titleKhachHang;
        private Guna.UI2.WinForms.Guna2TileButton titleNhanVien;
    }
}