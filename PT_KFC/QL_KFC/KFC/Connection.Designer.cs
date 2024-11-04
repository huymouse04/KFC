namespace KFC
{
    partial class Connection
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
            this.cbbDatabase = new System.Windows.Forms.ComboBox();
            this.btnDoc = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnKetnoi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSever = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbDatabase
            // 
            this.cbbDatabase.FormattingEnabled = true;
            this.cbbDatabase.Location = new System.Drawing.Point(321, 176);
            this.cbbDatabase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbDatabase.Name = "cbbDatabase";
            this.cbbDatabase.Size = new System.Drawing.Size(221, 21);
            this.cbbDatabase.TabIndex = 2;
            this.cbbDatabase.Click += new System.EventHandler(this.cbbDatabase_Click);
            // 
            // btnDoc
            // 
            this.btnDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnDoc.Location = new System.Drawing.Point(335, 237);
            this.btnDoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(75, 35);
            this.btnDoc.TabIndex = 1;
            this.btnDoc.Text = "Đọc file";
            this.btnDoc.UseVisualStyleBackColor = false;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGhi.Location = new System.Drawing.Point(448, 237);
            this.btnGhi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(75, 35);
            this.btnGhi.TabIndex = 2;
            this.btnGhi.Text = "Ghi file";
            this.btnGhi.UseVisualStyleBackColor = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KFC.Properties.Resources.sql;
            this.pictureBox1.Location = new System.Drawing.Point(46, 103);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnthoat.Location = new System.Drawing.Point(448, 284);
            this.btnthoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 35);
            this.btnthoat.TabIndex = 4;
            this.btnthoat.Text = "thoat";
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnKetnoi
            // 
            this.btnKetnoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnKetnoi.Location = new System.Drawing.Point(335, 284);
            this.btnKetnoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnKetnoi.Name = "btnKetnoi";
            this.btnKetnoi.Size = new System.Drawing.Size(75, 35);
            this.btnKetnoi.TabIndex = 3;
            this.btnKetnoi.Text = "Kết nối";
            this.btnKetnoi.UseVisualStyleBackColor = false;
            this.btnKetnoi.Click += new System.EventHandler(this.btnKetnoi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(318, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Tên dữ liệu";
            // 
            // txtSever
            // 
            this.txtSever.Location = new System.Drawing.Point(320, 103);
            this.txtSever.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSever.Multiline = true;
            this.txtSever.Name = "txtSever";
            this.txtSever.Size = new System.Drawing.Size(222, 26);
            this.txtSever.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(318, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Tên sever";
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.cbbDatabase);
            this.Controls.Add(this.btnDoc);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnKetnoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSever);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.Connection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbDatabase;
        private System.Windows.Forms.Button btnDoc;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnKetnoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSever;
        private System.Windows.Forms.Label label3;
    }
}