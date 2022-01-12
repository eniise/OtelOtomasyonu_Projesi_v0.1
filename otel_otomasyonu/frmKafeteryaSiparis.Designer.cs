
namespace otel_otomasyonu
{
    partial class frmKafeteryaSiparis
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMasa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUrun = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipDeger = new System.Windows.Forms.ComboBox();
            this.lstUrunler = new System.Windows.Forms.ListBox();
            this.cmsUrunler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ürünListesindenÇıkartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.lblMasaName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.cmsUrunler.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblMasa);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 25);
            this.panel1.TabIndex = 2;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(208, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(554, 1);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(35, 23);
            this.button9.TabIndex = 1;
            this.button9.Text = "X";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masa Sipariş =>";
            // 
            // lblMasa
            // 
            this.lblMasa.AutoSize = true;
            this.lblMasa.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMasa.Location = new System.Drawing.Point(128, 5);
            this.lblMasa.Name = "lblMasa";
            this.lblMasa.Size = new System.Drawing.Size(24, 18);
            this.lblMasa.TabIndex = 3;
            this.lblMasa.Text = "    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ürün Seç :";
            // 
            // cmbUrun
            // 
            this.cmbUrun.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cmbUrun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUrun.ForeColor = System.Drawing.Color.White;
            this.cmbUrun.FormattingEnabled = true;
            this.cmbUrun.Location = new System.Drawing.Point(68, 30);
            this.cmbUrun.Name = "cmbUrun";
            this.cmbUrun.Size = new System.Drawing.Size(161, 21);
            this.cmbUrun.TabIndex = 4;
            this.cmbUrun.SelectedIndexChanged += new System.EventHandler(this.cmbUrun_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tip : ";
            // 
            // cmbTip
            // 
            this.cmbTip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cmbTip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTip.ForeColor = System.Drawing.Color.White;
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Location = new System.Drawing.Point(68, 57);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(161, 21);
            this.cmbTip.TabIndex = 4;
            this.cmbTip.SelectedIndexChanged += new System.EventHandler(this.cmbTip_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Adet/Kg/Litre : ";
            // 
            // cmbTipDeger
            // 
            this.cmbTipDeger.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cmbTipDeger.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTipDeger.ForeColor = System.Drawing.Color.White;
            this.cmbTipDeger.FormattingEnabled = true;
            this.cmbTipDeger.Location = new System.Drawing.Point(82, 84);
            this.cmbTipDeger.Name = "cmbTipDeger";
            this.cmbTipDeger.Size = new System.Drawing.Size(161, 21);
            this.cmbTipDeger.TabIndex = 4;
            this.cmbTipDeger.SelectedIndexChanged += new System.EventHandler(this.cmbTipDeger_SelectedIndexChanged);
            // 
            // lstUrunler
            // 
            this.lstUrunler.ContextMenuStrip = this.cmsUrunler;
            this.lstUrunler.FormattingEnabled = true;
            this.lstUrunler.Location = new System.Drawing.Point(7, 138);
            this.lstUrunler.Name = "lstUrunler";
            this.lstUrunler.Size = new System.Drawing.Size(232, 238);
            this.lstUrunler.TabIndex = 5;
            // 
            // cmsUrunler
            // 
            this.cmsUrunler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünListesindenÇıkartToolStripMenuItem});
            this.cmsUrunler.Name = "cmsUrunler";
            this.cmsUrunler.Size = new System.Drawing.Size(192, 26);
            // 
            // ürünListesindenÇıkartToolStripMenuItem
            // 
            this.ürünListesindenÇıkartToolStripMenuItem.Name = "ürünListesindenÇıkartToolStripMenuItem";
            this.ürünListesindenÇıkartToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ürünListesindenÇıkartToolStripMenuItem.Text = "Ürün listesinden çıkart";
            this.ürünListesindenÇıkartToolStripMenuItem.Click += new System.EventHandler(this.ürünListesindenÇıkartToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(7, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(232, 21);
            this.button3.TabIndex = 6;
            this.button3.Text = "LİSTE EKLE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(171, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "KASAYA EKLE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamTutar.Location = new System.Drawing.Point(7, 382);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(24, 16);
            this.lblToplamTutar.TabIndex = 3;
            this.lblToplamTutar.Text = "    ";
            // 
            // lblMasaName
            // 
            this.lblMasaName.AutoSize = true;
            this.lblMasaName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMasaName.Location = new System.Drawing.Point(11, 403);
            this.lblMasaName.Name = "lblMasaName";
            this.lblMasaName.Size = new System.Drawing.Size(24, 16);
            this.lblMasaName.TabIndex = 3;
            this.lblMasaName.Text = "    ";
            this.lblMasaName.Visible = false;
            // 
            // frmKafeteryaSiparis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 432);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lstUrunler);
            this.Controls.Add(this.cmbTipDeger);
            this.Controls.Add(this.lblMasaName);
            this.Controls.Add(this.lblToplamTutar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbUrun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKafeteryaSiparis";
            this.Text = "Masa Sipariş Girişi";
            this.Load += new System.EventHandler(this.frmKafeteryaSiparis_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsUrunler.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUrun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipDeger;
        private System.Windows.Forms.ListBox lstUrunler;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblToplamTutar;
        public System.Windows.Forms.Label lblMasa;
        public System.Windows.Forms.Label lblMasaName;
        private System.Windows.Forms.ContextMenuStrip cmsUrunler;
        private System.Windows.Forms.ToolStripMenuItem ürünListesindenÇıkartToolStripMenuItem;
    }
}