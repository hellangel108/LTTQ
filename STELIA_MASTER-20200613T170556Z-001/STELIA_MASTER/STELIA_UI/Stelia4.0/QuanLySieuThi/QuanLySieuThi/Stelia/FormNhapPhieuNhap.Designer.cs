namespace Stelia
{
    partial class FormNhapPhieuNhap
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MASP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLUONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIATIEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateNgNhap = new DevExpress.XtraEditors.DateEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Xoa = new System.Windows.Forms.PictureBox();
            this.picThemMoi = new System.Windows.Forms.PictureBox();
            this.pictureBoxDanhSach = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgNhap.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThemMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MASP,
            this.TENSP,
            this.SOLUONG,
            this.GIATIEN});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(10, 279);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(821, 160);
            this.dataGridView1.TabIndex = 0;
            // 
            // MASP
            // 
            this.MASP.FillWeight = 50F;
            this.MASP.HeaderText = "Mã sản phẩm";
            this.MASP.Name = "MASP";
            this.MASP.ReadOnly = true;
            // 
            // TENSP
            // 
            this.TENSP.HeaderText = "Tên sản phẩm";
            this.TENSP.Name = "TENSP";
            this.TENSP.ReadOnly = true;
            // 
            // SOLUONG
            // 
            this.SOLUONG.FillWeight = 50F;
            this.SOLUONG.HeaderText = "Số lượng nhập";
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.ReadOnly = true;
            // 
            // GIATIEN
            // 
            this.GIATIEN.HeaderText = "Giá tiền";
            this.GIATIEN.Name = "GIATIEN";
            this.GIATIEN.ReadOnly = true;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Teal;
            this.label29.Location = new System.Drawing.Point(11, 212);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(822, 10);
            this.label29.TabIndex = 39;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Navy;
            this.label30.Location = new System.Drawing.Point(10, 190);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(164, 22);
            this.label30.TabIndex = 38;
            this.label30.Text = "Chi tiết phiếu nhập";
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Teal;
            this.label28.Location = new System.Drawing.Point(12, 52);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(490, 10);
            this.label28.TabIndex = 37;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Navy;
            this.label27.Location = new System.Drawing.Point(11, 30);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(185, 22);
            this.label27.TabIndex = 36;
            this.label27.Text = "Thông tin phiếu nhập";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNCC.Location = new System.Drawing.Point(149, 115);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(353, 26);
            this.txtMaNCC.TabIndex = 43;
            // 
            // txtMaPN
            // 
            this.txtMaPN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPN.Location = new System.Drawing.Point(149, 73);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(353, 26);
            this.txtMaPN.TabIndex = 42;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(10, 120);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(138, 21);
            this.label21.TabIndex = 41;
            this.label21.Text = "Mã nhà cung cấp";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(10, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 21);
            this.label16.TabIndex = 40;
            this.label16.Text = "Mã phiếu nhập";
            // 
            // dateNgNhap
            // 
            this.dateNgNhap.EditValue = null;
            this.dateNgNhap.Location = new System.Drawing.Point(149, 161);
            this.dateNgNhap.Name = "dateNgNhap";
            this.dateNgNhap.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgNhap.Properties.Appearance.Options.UseFont = true;
            this.dateNgNhap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgNhap.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgNhap.Size = new System.Drawing.Size(353, 26);
            this.dateNgNhap.TabIndex = 45;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(11, 163);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 21);
            this.label17.TabIndex = 44;
            this.label17.Text = "Ngày nhập";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(10, 468);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(819, 82);
            this.richTextBox1.TabIndex = 48;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 21);
            this.label3.TabIndex = 49;
            this.label3.Text = "Ghi chú";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 21);
            this.label4.TabIndex = 50;
            this.label4.Text = "Danh sách nhập hàng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stelia.Properties.Resources.TaoSPMoi;
            this.pictureBox1.Location = new System.Drawing.Point(664, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Xoa
            // 
            this.Xoa.Image = global::Stelia.Properties.Resources.xoa;
            this.Xoa.Location = new System.Drawing.Point(311, 224);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(120, 50);
            this.Xoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Xoa.TabIndex = 59;
            this.Xoa.TabStop = false;
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // picThemMoi
            // 
            this.picThemMoi.Image = global::Stelia.Properties.Resources.ThêmMới;
            this.picThemMoi.Location = new System.Drawing.Point(185, 232);
            this.picThemMoi.Name = "picThemMoi";
            this.picThemMoi.Size = new System.Drawing.Size(120, 40);
            this.picThemMoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThemMoi.TabIndex = 58;
            this.picThemMoi.TabStop = false;
            this.picThemMoi.Click += new System.EventHandler(this.picThemMoi_Click);
            // 
            // pictureBoxDanhSach
            // 
            this.pictureBoxDanhSach.Image = global::Stelia.Properties.Resources.control_listbox_512;
            this.pictureBoxDanhSach.Location = new System.Drawing.Point(508, 114);
            this.pictureBoxDanhSach.Name = "pictureBoxDanhSach";
            this.pictureBoxDanhSach.Size = new System.Drawing.Size(28, 27);
            this.pictureBoxDanhSach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDanhSach.TabIndex = 57;
            this.pictureBoxDanhSach.TabStop = false;
            this.pictureBoxDanhSach.Click += new System.EventHandler(this.pictureBoxDanhSach_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Stelia.Properties.Resources.nhaplai;
            this.pictureBox4.Location = new System.Drawing.Point(701, 556);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(125, 117);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 52;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Stelia.Properties.Resources.Thêmmoi;
            this.pictureBox3.Location = new System.Drawing.Point(559, 556);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(125, 117);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // FormNhapPhieuNhap
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 678);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Xoa);
            this.Controls.Add(this.picThemMoi);
            this.Controls.Add(this.pictureBoxDanhSach);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dateNgNhap);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtMaNCC);
            this.Controls.Add(this.txtMaPN);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormNhapPhieuNhap";
            this.Text = "Tạo phiếu nhập";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgNhap.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThemMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.DateEdit dateNgNhap;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBoxDanhSach;
        private System.Windows.Forms.PictureBox picThemMoi;
        private System.Windows.Forms.PictureBox Xoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLUONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIATIEN;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}