namespace WebcamBarcodeDemo
{
    partial class Form1
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.btnAcquireSource = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnReadBarcode = new System.Windows.Forms.Button();
            this.comboResolution = new System.Windows.Forms.ComboBox();
            this.Resolution = new System.Windows.Forms.Label();
            this.btnRemoveAllImages = new System.Windows.Forms.Button();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMaVach = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAcquireSource
            // 
            this.btnAcquireSource.Location = new System.Drawing.Point(12, 157);
            this.btnAcquireSource.Name = "btnAcquireSource";
            this.btnAcquireSource.Size = new System.Drawing.Size(110, 23);
            this.btnAcquireSource.TabIndex = 1;
            this.btnAcquireSource.Text = "Grab Image";
            this.btnAcquireSource.UseVisualStyleBackColor = true;
            this.btnAcquireSource.Click += new System.EventHandler(this.btnAcquireSource_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(543, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 375);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 198);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(110, 23);
            this.btnLoadImage.TabIndex = 4;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnReadBarcode
            // 
            this.btnReadBarcode.Location = new System.Drawing.Point(12, 272);
            this.btnReadBarcode.Name = "btnReadBarcode";
            this.btnReadBarcode.Size = new System.Drawing.Size(110, 23);
            this.btnReadBarcode.TabIndex = 12;
            this.btnReadBarcode.Text = "Recognize Barcode";
            this.btnReadBarcode.UseVisualStyleBackColor = true;
            this.btnReadBarcode.Click += new System.EventHandler(this.btnReadBarcode_Click);
            // 
            // comboResolution
            // 
            this.comboResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboResolution.FormattingEnabled = true;
            this.comboResolution.Location = new System.Drawing.Point(12, 100);
            this.comboResolution.Name = "comboResolution";
            this.comboResolution.Size = new System.Drawing.Size(110, 21);
            this.comboResolution.TabIndex = 14;
            this.comboResolution.SelectedIndexChanged += new System.EventHandler(this.comboResolution_SelectedIndexChanged);
            // 
            // Resolution
            // 
            this.Resolution.AutoSize = true;
            this.Resolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Resolution.Location = new System.Drawing.Point(12, 84);
            this.Resolution.Name = "Resolution";
            this.Resolution.Size = new System.Drawing.Size(71, 13);
            this.Resolution.TabIndex = 15;
            this.Resolution.Text = "Resolution:";
            // 
            // btnRemoveAllImages
            // 
            this.btnRemoveAllImages.Location = new System.Drawing.Point(12, 398);
            this.btnRemoveAllImages.Name = "btnRemoveAllImages";
            this.btnRemoveAllImages.Size = new System.Drawing.Size(110, 23);
            this.btnRemoveAllImages.TabIndex = 17;
            this.btnRemoveAllImages.Text = "Remove All Images";
            this.btnRemoveAllImages.UseVisualStyleBackColor = true;
            this.btnRemoveAllImages.Click += new System.EventHandler(this.btnRemoveAllImages_Click);
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(151, 46);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(375, 375);
            this.dsViewer1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Select Source:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 21);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(148, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Image Container:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(540, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Video Container:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMaVach);
            this.panel1.Location = new System.Drawing.Point(-5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 409);
            this.panel1.TabIndex = 25;
            // 
            // lblMaVach
            // 
            this.lblMaVach.BackColor = System.Drawing.Color.White;
            this.lblMaVach.Location = new System.Drawing.Point(14, 14);
            this.lblMaVach.Name = "lblMaVach";
            this.lblMaVach.Size = new System.Drawing.Size(511, 380);
            this.lblMaVach.TabIndex = 0;
            this.lblMaVach.Click += new System.EventHandler(this.LblMaVach_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 443);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dsViewer1);
            this.Controls.Add(this.btnRemoveAllImages);
            this.Controls.Add(this.Resolution);
            this.Controls.Add(this.comboResolution);
            this.Controls.Add(this.btnReadBarcode);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAcquireSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Webcam Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcquireSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnReadBarcode;
        private System.Windows.Forms.ComboBox comboResolution;
        private System.Windows.Forms.Label Resolution;
        private System.Windows.Forms.Button btnRemoveAllImages;
        private Dynamsoft.Forms.DSViewer dsViewer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMaVach;
    }
}

