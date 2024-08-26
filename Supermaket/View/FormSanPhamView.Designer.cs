namespace Supermaket.View
{
    partial class FormSanPhamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSanPhamView));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.titleDanhMuc = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleNhaCungCap = new Guna.UI2.WinForms.Guna2TileButton();
            this.titleSanPham1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.CenterPannel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2Panel1.Controls.Add(this.titleDanhMuc);
            this.guna2Panel1.Controls.Add(this.titleNhaCungCap);
            this.guna2Panel1.Controls.Add(this.titleSanPham1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(12, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(215, 477);
            this.guna2Panel1.TabIndex = 0;
            // 
            // titleDanhMuc
            // 
            this.titleDanhMuc.BackColor = System.Drawing.Color.Transparent;
            this.titleDanhMuc.BorderRadius = 10;
            this.titleDanhMuc.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleDanhMuc.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleDanhMuc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleDanhMuc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleDanhMuc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleDanhMuc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleDanhMuc.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleDanhMuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleDanhMuc.ForeColor = System.Drawing.Color.White;
            this.titleDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("titleDanhMuc.Image")));
            this.titleDanhMuc.ImageSize = new System.Drawing.Size(30, 30);
            this.titleDanhMuc.Location = new System.Drawing.Point(113, 44);
            this.titleDanhMuc.Name = "titleDanhMuc";
            this.titleDanhMuc.Size = new System.Drawing.Size(89, 90);
            this.titleDanhMuc.TabIndex = 1;
            this.titleDanhMuc.Text = "Danh mục";
            this.titleDanhMuc.Click += new System.EventHandler(this.titleDanhMuc_Click);
            // 
            // titleNhaCungCap
            // 
            this.titleNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.titleNhaCungCap.BorderRadius = 10;
            this.titleNhaCungCap.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleNhaCungCap.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleNhaCungCap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleNhaCungCap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleNhaCungCap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleNhaCungCap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleNhaCungCap.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleNhaCungCap.ForeColor = System.Drawing.Color.White;
            this.titleNhaCungCap.Image = ((System.Drawing.Image)(resources.GetObject("titleNhaCungCap.Image")));
            this.titleNhaCungCap.ImageSize = new System.Drawing.Size(40, 40);
            this.titleNhaCungCap.Location = new System.Drawing.Point(19, 140);
            this.titleNhaCungCap.Name = "titleNhaCungCap";
            this.titleNhaCungCap.Size = new System.Drawing.Size(183, 80);
            this.titleNhaCungCap.TabIndex = 1;
            this.titleNhaCungCap.Text = "Nhà cung cấp";
            this.titleNhaCungCap.Click += new System.EventHandler(this.titleNhaCungCap_Click);
            // 
            // titleSanPham1
            // 
            this.titleSanPham1.BackColor = System.Drawing.Color.Transparent;
            this.titleSanPham1.BorderRadius = 10;
            this.titleSanPham1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.titleSanPham1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(128)))));
            this.titleSanPham1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.titleSanPham1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.titleSanPham1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.titleSanPham1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.titleSanPham1.FillColor = System.Drawing.Color.DodgerBlue;
            this.titleSanPham1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleSanPham1.ForeColor = System.Drawing.Color.White;
            this.titleSanPham1.Image = ((System.Drawing.Image)(resources.GetObject("titleSanPham1.Image")));
            this.titleSanPham1.ImageSize = new System.Drawing.Size(30, 30);
            this.titleSanPham1.Location = new System.Drawing.Point(19, 44);
            this.titleSanPham1.Name = "titleSanPham1";
            this.titleSanPham1.Size = new System.Drawing.Size(88, 90);
            this.titleSanPham1.TabIndex = 1;
            this.titleSanPham1.Text = "Sản phẩm";
            this.titleSanPham1.Click += new System.EventHandler(this.titleSanPham1_Click);
            // 
            // CenterPannel
            // 
            this.CenterPannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CenterPannel.Location = new System.Drawing.Point(233, 12);
            this.CenterPannel.Name = "CenterPannel";
            this.CenterPannel.Size = new System.Drawing.Size(647, 477);
            this.CenterPannel.TabIndex = 0;
            // 
            // FormSanPhamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 501);
            this.Controls.Add(this.CenterPannel);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FormSanPhamView";
            this.Text = "FormSanPhamView";
            this.Load += new System.EventHandler(this.FormSanPhamView_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel CenterPannel;
        private Guna.UI2.WinForms.Guna2TileButton titleSanPham1;
        private Guna.UI2.WinForms.Guna2TileButton titleDanhMuc;
        private Guna.UI2.WinForms.Guna2TileButton titleNhaCungCap;
    }
}