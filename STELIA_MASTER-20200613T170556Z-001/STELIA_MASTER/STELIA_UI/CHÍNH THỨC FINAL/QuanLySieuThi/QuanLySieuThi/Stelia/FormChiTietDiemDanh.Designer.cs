namespace Stelia
{
    partial class FormChiTietDiemDanh
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
            this.gridDiemDanh = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateNgDD = new DevExpress.XtraEditors.DateEdit();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDiemDanh)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgDD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgDD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDiemDanh
            // 
            this.gridDiemDanh.AllowUserToAddRows = false;
            this.gridDiemDanh.AllowUserToDeleteRows = false;
            this.gridDiemDanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDiemDanh.Location = new System.Drawing.Point(12, 94);
            this.gridDiemDanh.Name = "gridDiemDanh";
            this.gridDiemDanh.ReadOnly = true;
            this.gridDiemDanh.Size = new System.Drawing.Size(809, 442);
            this.gridDiemDanh.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dateNgDD);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(27, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 66);
            this.panel2.TabIndex = 37;
            // 
            // dateNgDD
            // 
            this.dateNgDD.EditValue = null;
            this.dateNgDD.Location = new System.Drawing.Point(331, 12);
            this.dateNgDD.Name = "dateNgDD";
            this.dateNgDD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgDD.Properties.Appearance.Options.UseFont = true;
            this.dateNgDD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgDD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgDD.Size = new System.Drawing.Size(321, 42);
            this.dateNgDD.TabIndex = 36;
            this.dateNgDD.EditValueChanged += new System.EventHandler(this.dateNgDD_EditValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(98, 22);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 26);
            this.label11.TabIndex = 35;
            this.label11.Text = "Chọn ngày";
            // 
            // FormChiTietDiemDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 564);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gridDiemDanh);
            this.Name = "FormChiTietDiemDanh";
            this.Text = "Danh sách điểm danh";
            this.Load += new System.EventHandler(this.FormChiTietDiemDanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDiemDanh)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgDD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgDD.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridDiemDanh;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.DateEdit dateNgDD;
        private System.Windows.Forms.Label label11;
    }
}