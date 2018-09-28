namespace KutuphaneOtomasyon
{
    partial class kitap_guncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kitap_guncelle));
            this.guncelle_btn = new System.Windows.Forms.Button();
            this.dolap = new System.Windows.Forms.ComboBox();
            this.adet = new System.Windows.Forms.NumericUpDown();
            this.sayfa = new System.Windows.Forms.NumericUpDown();
            this.yayinevi = new System.Windows.Forms.TextBox();
            this.yazar = new System.Windows.Forms.TextBox();
            this.tur = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.barkod_no = new System.Windows.Forms.TextBox();
            this.ad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.adet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayfa)).BeginInit();
            this.SuspendLayout();
            // 
            // guncelle_btn
            // 
            this.guncelle_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guncelle_btn.FlatAppearance.BorderSize = 0;
            this.guncelle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guncelle_btn.ForeColor = System.Drawing.Color.Black;
            this.guncelle_btn.Image = ((System.Drawing.Image)(resources.GetObject("guncelle_btn.Image")));
            this.guncelle_btn.Location = new System.Drawing.Point(205, 228);
            this.guncelle_btn.Name = "guncelle_btn";
            this.guncelle_btn.Size = new System.Drawing.Size(85, 28);
            this.guncelle_btn.TabIndex = 11;
            this.guncelle_btn.Text = "Güncelle";
            this.guncelle_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.guncelle_btn.UseVisualStyleBackColor = false;
            this.guncelle_btn.Click += new System.EventHandler(this.guncelle_btn_Click);
            // 
            // dolap
            // 
            this.dolap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dolap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dolap.FormattingEnabled = true;
            this.dolap.Location = new System.Drawing.Point(106, 201);
            this.dolap.Name = "dolap";
            this.dolap.Size = new System.Drawing.Size(184, 21);
            this.dolap.TabIndex = 27;
            // 
            // adet
            // 
            this.adet.Location = new System.Drawing.Point(106, 174);
            this.adet.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.adet.Name = "adet";
            this.adet.Size = new System.Drawing.Size(184, 21);
            this.adet.TabIndex = 26;
            // 
            // sayfa
            // 
            this.sayfa.Location = new System.Drawing.Point(106, 147);
            this.sayfa.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.sayfa.Name = "sayfa";
            this.sayfa.Size = new System.Drawing.Size(184, 21);
            this.sayfa.TabIndex = 23;
            // 
            // yayinevi
            // 
            this.yayinevi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yayinevi.Location = new System.Drawing.Point(106, 93);
            this.yayinevi.MaxLength = 20;
            this.yayinevi.Name = "yayinevi";
            this.yayinevi.Size = new System.Drawing.Size(184, 21);
            this.yayinevi.TabIndex = 15;
            // 
            // yazar
            // 
            this.yazar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yazar.Location = new System.Drawing.Point(106, 66);
            this.yazar.MaxLength = 30;
            this.yazar.Name = "yazar";
            this.yazar.Size = new System.Drawing.Size(184, 21);
            this.yazar.TabIndex = 14;
            // 
            // tur
            // 
            this.tur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tur.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tur.FormattingEnabled = true;
            this.tur.Location = new System.Drawing.Point(106, 120);
            this.tur.Name = "tur";
            this.tur.Size = new System.Drawing.Size(184, 21);
            this.tur.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(18, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Dolap";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(18, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Adet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(18, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Sayfa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(18, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tür";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(18, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Yayınevi";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(18, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Yazar";
            // 
            // barkod_no
            // 
            this.barkod_no.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barkod_no.Location = new System.Drawing.Point(106, 12);
            this.barkod_no.MaxLength = 13;
            this.barkod_no.Name = "barkod_no";
            this.barkod_no.Size = new System.Drawing.Size(184, 21);
            this.barkod_no.TabIndex = 13;
            // 
            // ad
            // 
            this.ad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ad.Location = new System.Drawing.Point(106, 39);
            this.ad.MaxLength = 35;
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(184, 21);
            this.ad.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Ad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Barkod No";
            // 
            // kitap_guncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(306, 269);
            this.Controls.Add(this.dolap);
            this.Controls.Add(this.adet);
            this.Controls.Add(this.sayfa);
            this.Controls.Add(this.yayinevi);
            this.Controls.Add(this.yazar);
            this.Controls.Add(this.tur);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.barkod_no);
            this.Controls.Add(this.ad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guncelle_btn);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kitap_guncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitap Güncelle";
            this.Load += new System.EventHandler(this.kitap_guncelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayfa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button guncelle_btn;
        public System.Windows.Forms.ComboBox dolap;
        public System.Windows.Forms.NumericUpDown adet;
        public System.Windows.Forms.NumericUpDown sayfa;
        public System.Windows.Forms.TextBox yayinevi;
        public System.Windows.Forms.TextBox yazar;
        public System.Windows.Forms.ComboBox tur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox barkod_no;
        public System.Windows.Forms.TextBox ad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}