namespace Supermaket
{
    partial class PosSP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosSP));
            this.txttensp = new System.Windows.Forms.Label();
            this.txtgiasp = new System.Windows.Forms.Label();
            this.btnChiTiet = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.txtgiakm = new System.Windows.Forms.Label();
            this.picsp = new System.Windows.Forms.PictureBox();
            this.btnUserCtrPercent = new System.Windows.Forms.Button();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picsp)).BeginInit();
            this.SuspendLayout();
            // 
            // txttensp
            // 
            this.txttensp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttensp.Location = new System.Drawing.Point(17, 233);
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(223, 61);
            this.txttensp.TabIndex = 2;
            this.txttensp.Text = "Tên sản phẩm";
            this.txttensp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtgiasp
            // 
            this.txtgiasp.Font = new System.Drawing.Font("Arial Narrow", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgiasp.Location = new System.Drawing.Point(17, 282);
            this.txtgiasp.Name = "txtgiasp";
            this.txtgiasp.Size = new System.Drawing.Size(223, 36);
            this.txtgiasp.TabIndex = 3;
            this.txtgiasp.Text = "200,000";
            this.txtgiasp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.AutoRoundedCorners = true;
            this.btnChiTiet.BorderRadius = 21;
            this.btnChiTiet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChiTiet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChiTiet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChiTiet.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChiTiet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChiTiet.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnChiTiet.Location = new System.Drawing.Point(16, 357);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(218, 45);
            this.btnChiTiet.TabIndex = 4;
            this.btnChiTiet.Text = "Chi tiết";
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.btnUserCtrPercent);
            this.guna2ShadowPanel1.Controls.Add(this.txtgiakm);
            this.guna2ShadowPanel1.Controls.Add(this.picsp);
            this.guna2ShadowPanel1.Controls.Add(this.txtgiasp);
            this.guna2ShadowPanel1.Controls.Add(this.btnChiTiet);
            this.guna2ShadowPanel1.Controls.Add(this.txttensp);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(250, 414);
            this.guna2ShadowPanel1.TabIndex = 5;
            // 
            // txtgiakm
            // 
            this.txtgiakm.Font = new System.Drawing.Font("Arial Narrow", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgiakm.Location = new System.Drawing.Point(16, 318);
            this.txtgiakm.Name = "txtgiakm";
            this.txtgiakm.Size = new System.Drawing.Size(223, 36);
            this.txtgiakm.TabIndex = 5;
            this.txtgiakm.Text = "200,000";
            this.txtgiakm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picsp
            // 
            this.picsp.Image = ((System.Drawing.Image)(resources.GetObject("picsp.Image")));
            this.picsp.Location = new System.Drawing.Point(16, 16);
            this.picsp.Name = "picsp";
            this.picsp.Size = new System.Drawing.Size(223, 214);
            this.picsp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picsp.TabIndex = 1;
            this.picsp.TabStop = false;
            this.picsp.Click += new System.EventHandler(this.picsp_Click);
            // 
            // btnUserCtrPercent
            // 
            this.btnUserCtrPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserCtrPercent.BackColor = System.Drawing.Color.Red;
            this.btnUserCtrPercent.FlatAppearance.BorderSize = 0;
            this.btnUserCtrPercent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserCtrPercent.Font = new System.Drawing.Font("Palatino Linotype", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUserCtrPercent.ForeColor = System.Drawing.Color.White;
            this.btnUserCtrPercent.Image = ((System.Drawing.Image)(resources.GetObject("btnUserCtrPercent.Image")));
            this.btnUserCtrPercent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserCtrPercent.Location = new System.Drawing.Point(179, 195);
            this.btnUserCtrPercent.Name = "btnUserCtrPercent";
            this.btnUserCtrPercent.Size = new System.Drawing.Size(55, 35);
            this.btnUserCtrPercent.TabIndex = 6;
            this.btnUserCtrPercent.Text = "00";
            this.btnUserCtrPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserCtrPercent.UseVisualStyleBackColor = false;
            // 
            // PosSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "PosSP";
            this.Size = new System.Drawing.Size(250, 413);
            //this.MouseEnter += new System.EventHandler(this.PosSP_MouseEnter);
            //this.MouseLeave += new System.EventHandler(this.PosSP_MouseLeave);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picsp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picsp;
        private System.Windows.Forms.Label txttensp;
        private System.Windows.Forms.Label txtgiasp;
        private Guna.UI2.WinForms.Guna2GradientButton btnChiTiet;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label txtgiakm;
        public System.Windows.Forms.Button btnUserCtrPercent;
    }
}
