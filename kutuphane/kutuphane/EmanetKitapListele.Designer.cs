namespace kutuphane
{
    partial class EmanetKitapListele
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmanetKitapListele));
            this.cbxFiltrele = new System.Windows.Forms.ComboBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.dgvEmanetKitaplar = new System.Windows.Forms.DataGridView();
            this.btnCik = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxIadeKitapIdAra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxIadeUyeIdAra = new System.Windows.Forms.TextBox();
            this.btnTeslimAl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmanetKitaplar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxFiltrele
            // 
            this.cbxFiltrele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(203)))), ((int)(((byte)(201)))));
            this.cbxFiltrele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFiltrele.FormattingEnabled = true;
            this.cbxFiltrele.Items.AddRange(new object[] {
            "Tüm Kitaplar",
            "Geciken Kitaplar",
            "Gecikmeyen Kitaplar"});
            this.cbxFiltrele.Location = new System.Drawing.Point(731, 49);
            this.cbxFiltrele.Name = "cbxFiltrele";
            this.cbxFiltrele.Size = new System.Drawing.Size(184, 24);
            this.cbxFiltrele.TabIndex = 0;
            this.cbxFiltrele.SelectedIndexChanged += new System.EventHandler(this.cbxFiltrele_SelectedIndexChanged);
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.BackColor = System.Drawing.Color.Transparent;
            this.lblTarih.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTarih.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih.Location = new System.Drawing.Point(642, 49);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(57, 20);
            this.lblTarih.TabIndex = 1;
            this.lblTarih.Text = "Filtrele:";
            // 
            // dgvEmanetKitaplar
            // 
            this.dgvEmanetKitaplar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(203)))), ((int)(((byte)(201)))));
            this.dgvEmanetKitaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmanetKitaplar.Location = new System.Drawing.Point(55, 116);
            this.dgvEmanetKitaplar.Name = "dgvEmanetKitaplar";
            this.dgvEmanetKitaplar.ReadOnly = true;
            this.dgvEmanetKitaplar.RowHeadersWidth = 51;
            this.dgvEmanetKitaplar.RowTemplate.Height = 24;
            this.dgvEmanetKitaplar.Size = new System.Drawing.Size(952, 349);
            this.dgvEmanetKitaplar.TabIndex = 2;
            // 
            // btnCik
            // 
            this.btnCik.BackColor = System.Drawing.Color.Transparent;
            this.btnCik.FlatAppearance.BorderSize = 0;
            this.btnCik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCik.Location = new System.Drawing.Point(1029, 0);
            this.btnCik.Name = "btnCik";
            this.btnCik.Size = new System.Drawing.Size(30, 30);
            this.btnCik.TabIndex = 3;
            this.btnCik.Text = "X";
            this.btnCik.UseVisualStyleBackColor = false;
            this.btnCik.Click += new System.EventHandler(this.btnCik_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnCik);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 30);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Kitap ID Ara:";
            // 
            // tbxIadeKitapIdAra
            // 
            this.tbxIadeKitapIdAra.BackColor = System.Drawing.Color.White;
            this.tbxIadeKitapIdAra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxIadeKitapIdAra.Location = new System.Drawing.Point(446, 57);
            this.tbxIadeKitapIdAra.Name = "tbxIadeKitapIdAra";
            this.tbxIadeKitapIdAra.Size = new System.Drawing.Size(100, 15);
            this.tbxIadeKitapIdAra.TabIndex = 9;
            this.tbxIadeKitapIdAra.TextChanged += new System.EventHandler(this.tbxIadeKitapIdAra_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Üye ID Ara:";
            // 
            // tbxIadeUyeIdAra
            // 
            this.tbxIadeUyeIdAra.BackColor = System.Drawing.Color.White;
            this.tbxIadeUyeIdAra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxIadeUyeIdAra.Location = new System.Drawing.Point(221, 57);
            this.tbxIadeUyeIdAra.Name = "tbxIadeUyeIdAra";
            this.tbxIadeUyeIdAra.Size = new System.Drawing.Size(100, 15);
            this.tbxIadeUyeIdAra.TabIndex = 7;
            this.tbxIadeUyeIdAra.TextChanged += new System.EventHandler(this.tbxIadeUyeIdAra_TextChanged);
            // 
            // btnTeslimAl
            // 
            this.btnTeslimAl.FlatAppearance.BorderSize = 2;
            this.btnTeslimAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeslimAl.Location = new System.Drawing.Point(848, 493);
            this.btnTeslimAl.Name = "btnTeslimAl";
            this.btnTeslimAl.Size = new System.Drawing.Size(159, 30);
            this.btnTeslimAl.TabIndex = 11;
            this.btnTeslimAl.Text = "Teslim Et";
            this.btnTeslimAl.UseVisualStyleBackColor = true;
            this.btnTeslimAl.Click += new System.EventHandler(this.btnTeslimAl_Click);
            // 
            // EmanetKitapListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1062, 560);
            this.Controls.Add(this.btnTeslimAl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxIadeKitapIdAra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxIadeUyeIdAra);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvEmanetKitaplar);
            this.Controls.Add(this.lblTarih);
            this.Controls.Add(this.cbxFiltrele);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmanetKitapListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmanetKitapListele";
            this.Load += new System.EventHandler(this.EmanetKitapListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmanetKitaplar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxFiltrele;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DataGridView dgvEmanetKitaplar;
        private System.Windows.Forms.Button btnCik;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxIadeKitapIdAra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxIadeUyeIdAra;
        private System.Windows.Forms.Button btnTeslimAl;
    }
}