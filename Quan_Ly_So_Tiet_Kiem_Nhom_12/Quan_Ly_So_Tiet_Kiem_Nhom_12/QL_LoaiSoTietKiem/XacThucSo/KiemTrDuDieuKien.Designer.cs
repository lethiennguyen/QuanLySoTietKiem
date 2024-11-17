namespace Quan_Ly_So_Tiet_Kiem_Nhom_12.QL_LoaiSoTietKiem.XacThucSo
{
    partial class KiemTrDuDieuKien
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
            this.SignaturePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_clear = new Guna.UI2.WinForms.Guna2Button();
            this.btn_import = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // SignaturePanel
            // 
            this.SignaturePanel.BackColor = System.Drawing.Color.White;
            this.SignaturePanel.BorderColor = System.Drawing.Color.Black;
            this.SignaturePanel.BorderRadius = 15;
            this.SignaturePanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.SignaturePanel.BorderThickness = 2;
            this.SignaturePanel.Location = new System.Drawing.Point(87, 36);
            this.SignaturePanel.Name = "SignaturePanel";
            this.SignaturePanel.Size = new System.Drawing.Size(531, 179);
            this.SignaturePanel.TabIndex = 0;
            this.SignaturePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SignaturePanel_Paint);
            this.SignaturePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SignaturePanel_MouseDown);
            this.SignaturePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SignaturePanel_MouseMove);
            this.SignaturePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SignaturePanel_MouseUp);
            // 
            // btn_clear
            // 
            this.btn_clear.BorderColor = System.Drawing.Color.PeachPuff;
            this.btn_clear.BorderRadius = 10;
            this.btn_clear.BorderThickness = 2;
            this.btn_clear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_clear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_clear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_clear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_clear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(79)))), ((int)(((byte)(87)))));
            this.btn_clear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(119, 257);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(122, 45);
            this.btn_clear.TabIndex = 6;
            this.btn_clear.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_import
            // 
            this.btn_import.BorderColor = System.Drawing.Color.PeachPuff;
            this.btn_import.BorderRadius = 10;
            this.btn_import.BorderThickness = 2;
            this.btn_import.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_import.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_import.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_import.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_import.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(79)))), ((int)(((byte)(87)))));
            this.btn_import.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_import.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_import.ForeColor = System.Drawing.Color.White;
            this.btn_import.Location = new System.Drawing.Point(463, 257);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(122, 45);
            this.btn_import.TabIndex = 6;
            this.btn_import.Text = "Tải chữ ký";
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // KiemTrDuDieuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 362);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.SignaturePanel);
            this.Name = "KiemTrDuDieuKien";
            this.Text = "KiemTrDuDieuKien";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel SignaturePanel;
        private Guna.UI2.WinForms.Guna2Button btn_clear;
        private Guna.UI2.WinForms.Guna2Button btn_import;
    }
}