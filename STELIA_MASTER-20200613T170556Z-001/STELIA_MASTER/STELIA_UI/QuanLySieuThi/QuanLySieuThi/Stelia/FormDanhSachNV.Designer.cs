namespace Stelia
{
    partial class FormDanhSachNV
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
        ///
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.qLBHDataSet = new Stelia.QLBHDataSet();
            this.nHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHANVIENTableAdapter = new Stelia.QLBHDataSetTableAdapters.NHANVIENTableAdapter();
            this.mANVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hOTENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nGSINHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHUCVUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nGAYVLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gIOITINHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lUONGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLHDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOANHTHUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLBHDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mANVDataGridViewTextBoxColumn,
            this.hOTENDataGridViewTextBoxColumn,
            this.nGSINHDataGridViewTextBoxColumn,
            this.cHUCVUDataGridViewTextBoxColumn,
            this.nGAYVLDataGridViewTextBoxColumn,
            this.gIOITINHDataGridViewTextBoxColumn,
            this.lUONGDataGridViewTextBoxColumn,
            this.sLHDDataGridViewTextBoxColumn,
            this.dOANHTHUDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.nHANVIENBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1033, 595);
            this.dataGridView1.TabIndex = 0;
            // 
            // qLBHDataSet
            // 
            this.qLBHDataSet.DataSetName = "QLBHDataSet";
            this.qLBHDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nHANVIENBindingSource
            // 
            this.nHANVIENBindingSource.DataMember = "NHANVIEN";
            this.nHANVIENBindingSource.DataSource = this.qLBHDataSet;
            // 
            // nHANVIENTableAdapter
            // 
            this.nHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // mANVDataGridViewTextBoxColumn
            // 
            this.mANVDataGridViewTextBoxColumn.DataPropertyName = "MANV";
            this.mANVDataGridViewTextBoxColumn.HeaderText = "MANV";
            this.mANVDataGridViewTextBoxColumn.Name = "mANVDataGridViewTextBoxColumn";
            // 
            // hOTENDataGridViewTextBoxColumn
            // 
            this.hOTENDataGridViewTextBoxColumn.DataPropertyName = "HOTEN";
            this.hOTENDataGridViewTextBoxColumn.HeaderText = "HOTEN";
            this.hOTENDataGridViewTextBoxColumn.Name = "hOTENDataGridViewTextBoxColumn";
            this.hOTENDataGridViewTextBoxColumn.Width = 150;
            // 
            // nGSINHDataGridViewTextBoxColumn
            // 
            this.nGSINHDataGridViewTextBoxColumn.DataPropertyName = "NGSINH";
            this.nGSINHDataGridViewTextBoxColumn.HeaderText = "NGSINH";
            this.nGSINHDataGridViewTextBoxColumn.Name = "nGSINHDataGridViewTextBoxColumn";
            // 
            // cHUCVUDataGridViewTextBoxColumn
            // 
            this.cHUCVUDataGridViewTextBoxColumn.DataPropertyName = "CHUCVU";
            this.cHUCVUDataGridViewTextBoxColumn.HeaderText = "CHUCVU";
            this.cHUCVUDataGridViewTextBoxColumn.Name = "cHUCVUDataGridViewTextBoxColumn";
            // 
            // nGAYVLDataGridViewTextBoxColumn
            // 
            this.nGAYVLDataGridViewTextBoxColumn.DataPropertyName = "NGAYVL";
            this.nGAYVLDataGridViewTextBoxColumn.HeaderText = "NGAYVL";
            this.nGAYVLDataGridViewTextBoxColumn.Name = "nGAYVLDataGridViewTextBoxColumn";
            // 
            // gIOITINHDataGridViewTextBoxColumn
            // 
            this.gIOITINHDataGridViewTextBoxColumn.DataPropertyName = "GIOITINH";
            this.gIOITINHDataGridViewTextBoxColumn.HeaderText = "GIOITINH";
            this.gIOITINHDataGridViewTextBoxColumn.Name = "gIOITINHDataGridViewTextBoxColumn";
            // 
            // lUONGDataGridViewTextBoxColumn
            // 
            this.lUONGDataGridViewTextBoxColumn.DataPropertyName = "LUONG";
            this.lUONGDataGridViewTextBoxColumn.HeaderText = "LUONG";
            this.lUONGDataGridViewTextBoxColumn.Name = "lUONGDataGridViewTextBoxColumn";
            this.lUONGDataGridViewTextBoxColumn.Width = 130;
            // 
            // sLHDDataGridViewTextBoxColumn
            // 
            this.sLHDDataGridViewTextBoxColumn.DataPropertyName = "SLHD";
            this.sLHDDataGridViewTextBoxColumn.HeaderText = "SLHD";
            this.sLHDDataGridViewTextBoxColumn.Name = "sLHDDataGridViewTextBoxColumn";
            // 
            // dOANHTHUDataGridViewTextBoxColumn
            // 
            this.dOANHTHUDataGridViewTextBoxColumn.DataPropertyName = "DOANHTHU";
            this.dOANHTHUDataGridViewTextBoxColumn.HeaderText = "DOANHTHU";
            this.dOANHTHUDataGridViewTextBoxColumn.Name = "dOANHTHUDataGridViewTextBoxColumn";
            this.dOANHTHUDataGridViewTextBoxColumn.Width = 130;
            // 
            // FormDanhSachNV
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1033, 595);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDanhSachNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Nhân Viên";
            this.Load += new System.EventHandler(this.FormDanhSachNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLBHDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private QLBHDataSet qLBHDataSet;
        private System.Windows.Forms.BindingSource nHANVIENBindingSource;
        private QLBHDataSetTableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mANVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hOTENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nGSINHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHUCVUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nGAYVLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gIOITINHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lUONGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLHDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOANHTHUDataGridViewTextBoxColumn;
    }

}