namespace Stelia
{
    partial class FormDanhSachSP_NCC
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
            this.components = new System.ComponentModel.Container();
            this.grid = new System.Windows.Forms.DataGridView();
            this.qLBHDataSet = new Stelia.QLBHDataSet();
            this.sANPHAMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sANPHAMTableAdapter = new Stelia.QLBHDataSetTableAdapters.SANPHAMTableAdapter();
            this.mASPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tENSPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mANCCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dONGIADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOINHUANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLUONGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRANGTHAIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLBHDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sANPHAMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mASPDataGridViewTextBoxColumn,
            this.tENSPDataGridViewTextBoxColumn,
            this.mANCCDataGridViewTextBoxColumn,
            this.dONGIADataGridViewTextBoxColumn,
            this.lOINHUANDataGridViewTextBoxColumn,
            this.sLUONGDataGridViewTextBoxColumn,
            this.tRANGTHAIDataGridViewTextBoxColumn});
            this.grid.DataSource = this.sANPHAMBindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(842, 538);
            this.grid.TabIndex = 0;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick_1);
            // 
            // qLBHDataSet
            // 
            this.qLBHDataSet.DataSetName = "QLBHDataSet";
            this.qLBHDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sANPHAMBindingSource
            // 
            this.sANPHAMBindingSource.DataMember = "SANPHAM";
            this.sANPHAMBindingSource.DataSource = this.qLBHDataSet;
            // 
            // sANPHAMTableAdapter
            // 
            this.sANPHAMTableAdapter.ClearBeforeFill = true;
            // 
            // mASPDataGridViewTextBoxColumn
            // 
            this.mASPDataGridViewTextBoxColumn.DataPropertyName = "MASP";
            this.mASPDataGridViewTextBoxColumn.HeaderText = "MASP";
            this.mASPDataGridViewTextBoxColumn.Name = "mASPDataGridViewTextBoxColumn";
            // 
            // tENSPDataGridViewTextBoxColumn
            // 
            this.tENSPDataGridViewTextBoxColumn.DataPropertyName = "TENSP";
            this.tENSPDataGridViewTextBoxColumn.HeaderText = "TENSP";
            this.tENSPDataGridViewTextBoxColumn.Name = "tENSPDataGridViewTextBoxColumn";
            this.tENSPDataGridViewTextBoxColumn.Width = 150;
            // 
            // mANCCDataGridViewTextBoxColumn
            // 
            this.mANCCDataGridViewTextBoxColumn.DataPropertyName = "MANCC";
            this.mANCCDataGridViewTextBoxColumn.HeaderText = "MANCC";
            this.mANCCDataGridViewTextBoxColumn.Name = "mANCCDataGridViewTextBoxColumn";
            // 
            // dONGIADataGridViewTextBoxColumn
            // 
            this.dONGIADataGridViewTextBoxColumn.DataPropertyName = "DONGIA";
            this.dONGIADataGridViewTextBoxColumn.HeaderText = "DONGIA";
            this.dONGIADataGridViewTextBoxColumn.Name = "dONGIADataGridViewTextBoxColumn";
            // 
            // lOINHUANDataGridViewTextBoxColumn
            // 
            this.lOINHUANDataGridViewTextBoxColumn.DataPropertyName = "LOINHUAN";
            this.lOINHUANDataGridViewTextBoxColumn.HeaderText = "LOINHUAN";
            this.lOINHUANDataGridViewTextBoxColumn.Name = "lOINHUANDataGridViewTextBoxColumn";
            // 
            // sLUONGDataGridViewTextBoxColumn
            // 
            this.sLUONGDataGridViewTextBoxColumn.DataPropertyName = "SLUONG";
            this.sLUONGDataGridViewTextBoxColumn.HeaderText = "SLUONG";
            this.sLUONGDataGridViewTextBoxColumn.Name = "sLUONGDataGridViewTextBoxColumn";
            // 
            // tRANGTHAIDataGridViewTextBoxColumn
            // 
            this.tRANGTHAIDataGridViewTextBoxColumn.DataPropertyName = "TRANGTHAI";
            this.tRANGTHAIDataGridViewTextBoxColumn.HeaderText = "TRANGTHAI";
            this.tRANGTHAIDataGridViewTextBoxColumn.Name = "tRANGTHAIDataGridViewTextBoxColumn";
            this.tRANGTHAIDataGridViewTextBoxColumn.Width = 150;
            // 
            // FormDanhSachSP_NCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 538);
            this.Controls.Add(this.grid);
            this.Name = "FormDanhSachSP_NCC";
            this.Text = "Danh sách sản phẩm";
            this.Load += new System.EventHandler(this.FormDanhSachSP_NCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLBHDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sANPHAMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private QLBHDataSet qLBHDataSet;
        private System.Windows.Forms.BindingSource sANPHAMBindingSource;
        private QLBHDataSetTableAdapters.SANPHAMTableAdapter sANPHAMTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mASPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tENSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mANCCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dONGIADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOINHUANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLUONGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRANGTHAIDataGridViewTextBoxColumn;
    }
}