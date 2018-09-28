namespace KutuphaneOtomasyon
{
    partial class kitap_ekle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kitap_ekle));
            this.panel1 = new System.Windows.Forms.Panel();
            this.yeni_dolap_ekle = new System.Windows.Forms.Button();
            this.yeni_tur_ekle = new System.Windows.Forms.Button();
            this.dolap = new System.Windows.Forms.ComboBox();
            this.adet = new System.Windows.Forms.NumericUpDown();
            this.sayfa = new System.Windows.Forms.NumericUpDown();
            this.yayinevi = new System.Windows.Forms.TextBox();
            this.yazar = new System.Windows.Forms.TextBox();
            this.tur = new System.Windows.Forms.ComboBox();
            this.kitap_temizle_btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.kitap_ekle_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.barkod_no = new System.Windows.Forms.TextBox();
            this.ad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayfa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.yeni_dolap_ekle);
            this.panel1.Controls.Add(this.yeni_tur_ekle);
            this.panel1.Controls.Add(this.dolap);
            this.panel1.Controls.Add(this.adet);
            this.panel1.Controls.Add(this.sayfa);
            this.panel1.Controls.Add(this.yayinevi);
            this.panel1.Controls.Add(this.yazar);
            this.panel1.Controls.Add(this.tur);
            this.panel1.Controls.Add(this.kitap_temizle_btn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.kitap_ekle_btn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.barkod_no);
            this.panel1.Controls.Add(this.ad);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 285);
            this.panel1.TabIndex = 1;
            // 
            // yeni_dolap_ekle
            // 
            this.yeni_dolap_ekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.yeni_dolap_ekle.FlatAppearance.BorderSize = 0;
            this.yeni_dolap_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yeni_dolap_ekle.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.yeni_dolap_ekle.Location = new System.Drawing.Point(254, 207);
            this.yeni_dolap_ekle.Name = "yeni_dolap_ekle";
            this.yeni_dolap_ekle.Size = new System.Drawing.Size(30, 21);
            this.yeni_dolap_ekle.TabIndex = 11;
            this.yeni_dolap_ekle.Text = "...";
            this.yeni_dolap_ekle.UseVisualStyleBackColor = false;
            this.yeni_dolap_ekle.Click += new System.EventHandler(this.yeni_dolap_ekle_Click);
            this.yeni_dolap_ekle.MouseHover += new System.EventHandler(this.yeni_dolap_ekle_MouseHover);
            // 
            // yeni_tur_ekle
            // 
            this.yeni_tur_ekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.yeni_tur_ekle.FlatAppearance.BorderSize = 0;
            this.yeni_tur_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yeni_tur_ekle.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.yeni_tur_ekle.Location = new System.Drawing.Point(254, 126);
            this.yeni_tur_ekle.Name = "yeni_tur_ekle";
            this.yeni_tur_ekle.Size = new System.Drawing.Size(30, 21);
            this.yeni_tur_ekle.TabIndex = 11;
            this.yeni_tur_ekle.Text = "...";
            this.yeni_tur_ekle.UseVisualStyleBackColor = false;
            this.yeni_tur_ekle.Click += new System.EventHandler(this.yeni_tur_ekle_Click);
            this.yeni_tur_ekle.MouseHover += new System.EventHandler(this.yeni_tur_ekle_MouseHover);
            // 
            // dolap
            // 
            this.dolap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dolap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dolap.FormattingEnabled = true;
            this.dolap.Location = new System.Drawing.Point(100, 207);
            this.dolap.Name = "dolap";
            this.dolap.Size = new System.Drawing.Size(148, 21);
            this.dolap.TabIndex = 8;
            // 
            // adet
            // 
            this.adet.Location = new System.Drawing.Point(100, 180);
            this.adet.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.adet.Name = "adet";
            this.adet.Size = new System.Drawing.Size(184, 21);
            this.adet.TabIndex = 7;
            // 
            // sayfa
            // 
            this.sayfa.Location = new System.Drawing.Point(100, 153);
            this.sayfa.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.sayfa.Name = "sayfa";
            this.sayfa.Size = new System.Drawing.Size(184, 21);
            this.sayfa.TabIndex = 6;
            // 
            // yayinevi
            // 
            this.yayinevi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yayinevi.Location = new System.Drawing.Point(100, 99);
            this.yayinevi.MaxLength = 20;
            this.yayinevi.Name = "yayinevi";
            this.yayinevi.Size = new System.Drawing.Size(184, 21);
            this.yayinevi.TabIndex = 3;
            this.yayinevi.Leave += new System.EventHandler(this.yayinevi_Leave);
            // 
            // yazar
            // 
            this.yazar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yazar.Location = new System.Drawing.Point(100, 72);
            this.yazar.MaxLength = 30;
            this.yazar.Name = "yazar";
            this.yazar.Size = new System.Drawing.Size(184, 21);
            this.yazar.TabIndex = 2;
            this.yazar.Leave += new System.EventHandler(this.yazar_Leave);
            // 
            // tur
            // 
            this.tur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tur.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tur.FormattingEnabled = true;
            this.tur.Location = new System.Drawing.Point(100, 126);
            this.tur.Name = "tur";
            this.tur.Size = new System.Drawing.Size(148, 21);
            this.tur.TabIndex = 5;
            // 
            // kitap_temizle_btn
            // 
            this.kitap_temizle_btn.BackColor = System.Drawing.Color.White;
            this.kitap_temizle_btn.FlatAppearance.BorderSize = 0;
            this.kitap_temizle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kitap_temizle_btn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kitap_temizle_btn.Image = ((System.Drawing.Image)(resources.GetObject("kitap_temizle_btn.Image")));
            this.kitap_temizle_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kitap_temizle_btn.Location = new System.Drawing.Point(100, 240);
            this.kitap_temizle_btn.Name = "kitap_temizle_btn";
            this.kitap_temizle_btn.Size = new System.Drawing.Size(98, 27);
            this.kitap_temizle_btn.TabIndex = 10;
            this.kitap_temizle_btn.Text = "Temizle";
            this.kitap_temizle_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.kitap_temizle_btn.UseVisualStyleBackColor = false;
            this.kitap_temizle_btn.Click += new System.EventHandler(this.kitap_temizle_btn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(12, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Dolap";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Adet";
            // 
            // kitap_ekle_btn
            // 
            this.kitap_ekle_btn.BackColor = System.Drawing.Color.White;
            this.kitap_ekle_btn.FlatAppearance.BorderSize = 0;
            this.kitap_ekle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kitap_ekle_btn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kitap_ekle_btn.Image = ((System.Drawing.Image)(resources.GetObject("kitap_ekle_btn.Image")));
            this.kitap_ekle_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kitap_ekle_btn.Location = new System.Drawing.Point(205, 240);
            this.kitap_ekle_btn.Name = "kitap_ekle_btn";
            this.kitap_ekle_btn.Size = new System.Drawing.Size(79, 27);
            this.kitap_ekle_btn.TabIndex = 9;
            this.kitap_ekle_btn.Text = "Ekle";
            this.kitap_ekle_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.kitap_ekle_btn.UseVisualStyleBackColor = false;
            this.kitap_ekle_btn.Click += new System.EventHandler(this.kitap_ekle_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sayfa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tür";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Yayınevi";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(12, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Yazar";
            // 
            // barkod_no
            // 
            this.barkod_no.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barkod_no.Location = new System.Drawing.Point(100, 18);
            this.barkod_no.MaxLength = 13;
            this.barkod_no.Name = "barkod_no";
            this.barkod_no.Size = new System.Drawing.Size(184, 21);
            this.barkod_no.TabIndex = 1;
            this.barkod_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.barkod_no_KeyPress);
            this.barkod_no.Leave += new System.EventHandler(this.ad_Leave);
            // 
            // ad
            // 
            this.ad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ad.Location = new System.Drawing.Point(100, 45);
            this.ad.MaxLength = 35;
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(184, 21);
            this.ad.TabIndex = 1;
            this.ad.Leave += new System.EventHandler(this.ad_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Barkod No";
            // 
            // kitap_ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 285);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kitap_ekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitap Ekle";
            this.Activated += new System.EventHandler(this.kitap_ekle_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.kitap_ekle_FormClosed);
            this.Load += new System.EventHandler(this.kitap_ekle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayfa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox tur;
        private System.Windows.Forms.Button kitap_temizle_btn;
        private System.Windows.Forms.Button kitap_ekle_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox ad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox yayinevi;
        private System.Windows.Forms.TextBox yazar;
        private System.Windows.Forms.TextBox barkod_no;
        private System.Windows.Forms.NumericUpDown adet;
        private System.Windows.Forms.NumericUpDown sayfa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dolap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button yeni_tur_ekle;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button yeni_dolap_ekle;
    }
}