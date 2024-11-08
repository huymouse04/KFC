namespace KFC
{
    partial class BanControl
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
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblBan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(14, 17);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(105, 19);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "Trạng thái bàn";
            // 
            // lblBan
            // 
            this.lblBan.AutoSize = true;
            this.lblBan.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBan.Location = new System.Drawing.Point(42, 48);
            this.lblBan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(90, 25);
            this.lblBan.TabIndex = 1;
            this.lblBan.Text = "Tên bàn";
            // 
            // BanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBan);
            this.Controls.Add(this.lblTrangThai);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BanControl";
            this.Size = new System.Drawing.Size(169, 119);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblBan;
    }
}
