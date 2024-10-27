namespace KFC
{
    partial class ComboControl
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
            this.lblCombo = new System.Windows.Forms.Label();
            this.lblTenCombo = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCombo
            // 
            this.lblCombo.AutoSize = true;
            this.lblCombo.Location = new System.Drawing.Point(16, 9);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(73, 16);
            this.lblCombo.TabIndex = 0;
            this.lblCombo.Text = "Mã Combo";
            this.lblCombo.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTenCombo
            // 
            this.lblTenCombo.AutoSize = true;
            this.lblTenCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCombo.Location = new System.Drawing.Point(66, 33);
            this.lblTenCombo.Name = "lblTenCombo";
            this.lblTenCombo.Size = new System.Drawing.Size(181, 36);
            this.lblTenCombo.TabIndex = 1;
            this.lblTenCombo.Text = "Tên ComBo";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.Location = new System.Drawing.Point(98, 76);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(102, 20);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "Giá Combo";
            // 
            // ComboControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblTenCombo);
            this.Controls.Add(this.lblCombo);
            this.Name = "ComboControl";
            this.Size = new System.Drawing.Size(302, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCombo;
        private System.Windows.Forms.Label lblTenCombo;
        private System.Windows.Forms.Label lblGia;
    }
}
