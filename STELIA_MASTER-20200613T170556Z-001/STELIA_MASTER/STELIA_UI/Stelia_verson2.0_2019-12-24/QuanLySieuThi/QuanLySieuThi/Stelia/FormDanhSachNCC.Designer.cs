﻿namespace Stelia
{
    partial class FormDanhSachNCC
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mANCCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tENNCCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nGHTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dIACHIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mUCDOCCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRANGTHAIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHACUNGCAPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mANCCDataGridViewTextBoxColumn,
            this.tENNCCDataGridViewTextBoxColumn,
            this.nGHTDataGridViewTextBoxColumn,
            this.dIACHIDataGridViewTextBoxColumn,
            this.sDTDataGridViewTextBoxColumn,
            this.mUCDOCCDataGridViewTextBoxColumn,
            this.tRANGTHAIDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.nHACUNGCAPBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1094, 672);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // mANCCDataGridViewTextBoxColumn
            // 
            this.mANCCDataGridViewTextBoxColumn.DataPropertyName = "Mã nhà cung cấp";
            this.mANCCDataGridViewTextBoxColumn.HeaderText = "MANCC";
            this.mANCCDataGridViewTextBoxColumn.Name = "mANCCDataGridViewTextBoxColumn";
            // 
            // tENNCCDataGridViewTextBoxColumn
            // 
            this.tENNCCDataGridViewTextBoxColumn.DataPropertyName = "Tên nhà cung cấp";
            this.tENNCCDataGridViewTextBoxColumn.HeaderText = "TENNCC";
            this.tENNCCDataGridViewTextBoxColumn.Name = "tENNCCDataGridViewTextBoxColumn";
            this.tENNCCDataGridViewTextBoxColumn.Width = 200;
            // 
            // nGHTDataGridViewTextBoxColumn
            // 
            this.nGHTDataGridViewTextBoxColumn.DataPropertyName = "NGHT";
            this.nGHTDataGridViewTextBoxColumn.HeaderText = "Ngày hợp tác";
            this.nGHTDataGridViewTextBoxColumn.Name = "nGHTDataGridViewTextBoxColumn";
            this.nGHTDataGridViewTextBoxColumn.Width = 150;
            // 
            // dIACHIDataGridViewTextBoxColumn
            // 
            this.dIACHIDataGridViewTextBoxColumn.DataPropertyName = "DIACHI";
            this.dIACHIDataGridViewTextBoxColumn.HeaderText = "DIACHI";
            this.dIACHIDataGridViewTextBoxColumn.Name = "dIACHIDataGridViewTextBoxColumn";
            this.dIACHIDataGridViewTextBoxColumn.Width = 250;
            // 
            // sDTDataGridViewTextBoxColumn
            // 
            this.sDTDataGridViewTextBoxColumn.DataPropertyName = "SDT";
            this.sDTDataGridViewTextBoxColumn.HeaderText = "SDT";
            this.sDTDataGridViewTextBoxColumn.Name = "sDTDataGridViewTextBoxColumn";
            // 
            // mUCDOCCDataGridViewTextBoxColumn
            // 
            this.mUCDOCCDataGridViewTextBoxColumn.DataPropertyName = "MUCDOCC";
            this.mUCDOCCDataGridViewTextBoxColumn.HeaderText = "MUCDOCC";
            this.mUCDOCCDataGridViewTextBoxColumn.Name = "mUCDOCCDataGridViewTextBoxColumn";
            this.mUCDOCCDataGridViewTextBoxColumn.Width = 150;
            // 
            // tRANGTHAIDataGridViewTextBoxColumn
            // 
            this.tRANGTHAIDataGridViewTextBoxColumn.DataPropertyName = "TRANGTHAI";
            this.tRANGTHAIDataGridViewTextBoxColumn.HeaderText = "TRANGTHAI";
            this.tRANGTHAIDataGridViewTextBoxColumn.Name = "tRANGTHAIDataGridViewTextBoxColumn";
            // 
            // FormDanhSachNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 672);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDanhSachNCC";
            this.Text = "FormDanhSachNCC";
            this.Load += new System.EventHandler(this.FormDanhSachNCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHACUNGCAPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource nHACUNGCAPBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn mANCCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tENNCCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nGHTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIACHIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mUCDOCCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRANGTHAIDataGridViewTextBoxColumn;
    }
}