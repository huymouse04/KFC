namespace KFC
{
    partial class Combo
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnAdd = new CustomButton.VBButton();
            this.btnXoa = new CustomButton.VBButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboControl1 = new KFC.ComboControl();
            this.comboControl2 = new KFC.ComboControl();
            this.comboControl3 = new KFC.ComboControl();
            this.comboControl4 = new KFC.ComboControl();
            this.comboControl5 = new KFC.ComboControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.comboControl1);
            this.flowLayoutPanel1.Controls.Add(this.comboControl2);
            this.flowLayoutPanel1.Controls.Add(this.comboControl3);
            this.flowLayoutPanel1.Controls.Add(this.comboControl4);
            this.flowLayoutPanel1.Controls.Add(this.comboControl5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(845, 450);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.Firebrick;
            this.BtnAdd.BackgroundColor = System.Drawing.Color.Firebrick;
            this.BtnAdd.BorderColor = System.Drawing.Color.LavenderBlush;
            this.BtnAdd.BorderRadius = 10;
            this.BtnAdd.BorderSize = 0;
            this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(609, 0);
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(118, 76);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Thêm";
            this.BtnAdd.TextColor = System.Drawing.Color.White;
            this.BtnAdd.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnXoa.BorderColor = System.Drawing.Color.Crimson;
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.BorderSize = 0;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(727, 0);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(118, 76);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextColor = System.Drawing.Color.White;
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnAdd);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 450);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(845, 76);
            this.panel3.TabIndex = 16;
            // 
            // comboControl1
            // 
            this.comboControl1.GiaCombo = "Giá Combo";
            this.comboControl1.Location = new System.Drawing.Point(3, 3);
            this.comboControl1.MaCombo = "Mã Combo";
            this.comboControl1.Name = "comboControl1";
            this.comboControl1.Size = new System.Drawing.Size(302, 108);
            this.comboControl1.TabIndex = 0;
            this.comboControl1.TenCombo = "Tên ComBo";
            // 
            // comboControl2
            // 
            this.comboControl2.GiaCombo = "Giá Combo";
            this.comboControl2.Location = new System.Drawing.Point(311, 3);
            this.comboControl2.MaCombo = "Mã Combo";
            this.comboControl2.Name = "comboControl2";
            this.comboControl2.Size = new System.Drawing.Size(302, 108);
            this.comboControl2.TabIndex = 1;
            this.comboControl2.TenCombo = "Tên ComBo";
            // 
            // comboControl3
            // 
            this.comboControl3.GiaCombo = "Giá Combo";
            this.comboControl3.Location = new System.Drawing.Point(3, 117);
            this.comboControl3.MaCombo = "Mã Combo";
            this.comboControl3.Name = "comboControl3";
            this.comboControl3.Size = new System.Drawing.Size(302, 108);
            this.comboControl3.TabIndex = 2;
            this.comboControl3.TenCombo = "Tên ComBo";
            // 
            // comboControl4
            // 
            this.comboControl4.GiaCombo = "Giá Combo";
            this.comboControl4.Location = new System.Drawing.Point(311, 117);
            this.comboControl4.MaCombo = "Mã Combo";
            this.comboControl4.Name = "comboControl4";
            this.comboControl4.Size = new System.Drawing.Size(302, 108);
            this.comboControl4.TabIndex = 3;
            this.comboControl4.TenCombo = "Tên ComBo";
            // 
            // comboControl5
            // 
            this.comboControl5.GiaCombo = "Giá Combo";
            this.comboControl5.Location = new System.Drawing.Point(3, 231);
            this.comboControl5.MaCombo = "Mã Combo";
            this.comboControl5.Name = "comboControl5";
            this.comboControl5.Size = new System.Drawing.Size(302, 108);
            this.comboControl5.TabIndex = 4;
            this.comboControl5.TenCombo = "Tên ComBo";
            // 
            // Combo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 526);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Name = "Combo";
            this.Text = "Combo";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CustomButton.VBButton BtnAdd;
        private CustomButton.VBButton btnXoa;
        private System.Windows.Forms.Panel panel3;
        private ComboControl comboControl1;
        private ComboControl comboControl2;
        private ComboControl comboControl3;
        private ComboControl comboControl4;
        private ComboControl comboControl5;
    }
}