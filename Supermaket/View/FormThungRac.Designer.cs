namespace Supermaket.View
{
    partial class FormThungRac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThungRac));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.titleSanPham1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.CenterPannel = new Guna.UI2.WinForms.Guna2Panel();
            this.titleNhanVien = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2Panel1.Controls.Add(this.titleNhanVien);
            this.guna2Panel1.Controls.Add(this.titleSanPham1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(12, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(215, 477);
            this.guna2Panel1.TabIndex = 2;
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
            this.titleSanPham1.Location = new System.Drawing.Point(23, 43);
            this.titleSanPham1.Name = "titleSanPham1";
            this.titleSanPham1.Size = new System.Drawing.Size(174, 90);
            this.titleSanPham1.TabIndex = 2;
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
            this.CenterPannel.TabIndex = 3;
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
            this.titleNhanVien.Location = new System.Drawing.Point(23, 139);
            this.titleNhanVien.Name = "titleNhanVien";
            this.titleNhanVien.Size = new System.Drawing.Size(178, 80);
            this.titleNhanVien.TabIndex = 3;
            this.titleNhanVien.Text = "Nhân viên";
            this.titleNhanVien.Click += new System.EventHandler(this.titleNhanVien_Click);
            // 
            // FormThungRac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 501);
            this.Controls.Add(this.CenterPannel);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FormThungRac";
            this.Text = "FormThungRac";
            this.Load += new System.EventHandler(this.FormThungRac_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel CenterPannel;
        private Guna.UI2.WinForms.Guna2TileButton titleSanPham1;
        private Guna.UI2.WinForms.Guna2TileButton titleNhanVien;
    }
}