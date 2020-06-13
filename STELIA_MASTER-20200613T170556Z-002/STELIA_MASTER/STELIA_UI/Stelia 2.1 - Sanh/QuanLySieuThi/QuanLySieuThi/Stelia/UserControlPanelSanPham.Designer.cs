namespace Stelia
{
    partial class UserControlPanelSanPham
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.PictureBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.picAnhSP = new System.Windows.Forms.PictureBox();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhSP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnXoa);
            this.panel8.Controls.Add(this.lblTenSP);
            this.panel8.Controls.Add(this.lblSoLuong);
            this.panel8.Controls.Add(this.picAnhSP);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(20);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 267);
            this.panel8.TabIndex = 35;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel8_Paint);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::Stelia.Properties.Resources.xoa;
            this.btnXoa.Location = new System.Drawing.Point(51, 223);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 41);
            this.btnXoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnXoa.TabIndex = 35;
            this.btnXoa.TabStop = false;
            this.btnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // lblTenSP
            // 
            this.lblTenSP.BackColor = System.Drawing.Color.White;
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTenSP.Location = new System.Drawing.Point(4, 175);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(196, 45);
            this.lblTenSP.TabIndex = 1;
            this.lblTenSP.Text = "Thú nhồi bông - 180000";
            this.lblTenSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenSP.Click += new System.EventHandler(this.LblTenSP_Click);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.Red;
            this.lblSoLuong.Location = new System.Drawing.Point(125, 3);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(75, 24);
            this.lblSoLuong.TabIndex = 34;
            this.lblSoLuong.Text = "X18";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAnhSP
            // 
            this.picAnhSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.picAnhSP.Image = global::Stelia.Properties.Resources.thunhoibong1;
            this.picAnhSP.Location = new System.Drawing.Point(0, 0);
            this.picAnhSP.Name = "picAnhSP";
            this.picAnhSP.Size = new System.Drawing.Size(200, 172);
            this.picAnhSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnhSP.TabIndex = 0;
            this.picAnhSP.TabStop = false;
            this.picAnhSP.Click += new System.EventHandler(this.PicAnhSP_Click);
            // 
            // UserControlPanelSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel8);
            this.Name = "UserControlPanelSanPham";
            this.Size = new System.Drawing.Size(200, 267);
            this.Load += new System.EventHandler(this.UserControlPanelSanPham_Load);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox btnXoa;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.PictureBox picAnhSP;
    }
}
