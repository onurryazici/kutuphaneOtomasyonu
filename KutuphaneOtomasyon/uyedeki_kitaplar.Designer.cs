namespace KutuphaneOtomasyon
{
    partial class uyedeki_kitaplar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel28 = new System.Windows.Forms.Panel();
            this.kitap_al = new System.Windows.Forms.Button();
            this.statu = new System.Windows.Forms.Label();
            this.uye_dataGrid = new System.Windows.Forms.DataGridView();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uye_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.kitap_al);
            this.panel28.Controls.Add(this.statu);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel28.Location = new System.Drawing.Point(0, 99);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(605, 31);
            this.panel28.TabIndex = 14;
            // 
            // kitap_al
            // 
            this.kitap_al.BackColor = System.Drawing.Color.Silver;
            this.kitap_al.FlatAppearance.BorderSize = 0;
            this.kitap_al.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kitap_al.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kitap_al.Location = new System.Drawing.Point(508, 4);
            this.kitap_al.Name = "kitap_al";
            this.kitap_al.Size = new System.Drawing.Size(85, 23);
            this.kitap_al.TabIndex = 16;
            this.kitap_al.Text = "Kitabı Al";
            this.kitap_al.UseVisualStyleBackColor = false;
            this.kitap_al.Visible = false;
            this.kitap_al.Click += new System.EventHandler(this.kitap_al_Click);
            // 
            // statu
            // 
            this.statu.AutoSize = true;
            this.statu.Location = new System.Drawing.Point(12, 9);
            this.statu.Name = "statu";
            this.statu.Size = new System.Drawing.Size(35, 13);
            this.statu.TabIndex = 0;
            this.statu.Text = "statü";
            // 
            // uye_dataGrid
            // 
            this.uye_dataGrid.AllowUserToAddRows = false;
            this.uye_dataGrid.AllowUserToDeleteRows = false;
            this.uye_dataGrid.AllowUserToResizeColumns = false;
            this.uye_dataGrid.AllowUserToResizeRows = false;
            this.uye_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uye_dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uye_dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uye_dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.uye_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uye_dataGrid.Location = new System.Drawing.Point(0, 0);
            this.uye_dataGrid.MultiSelect = false;
            this.uye_dataGrid.Name = "uye_dataGrid";
            this.uye_dataGrid.ReadOnly = true;
            this.uye_dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uye_dataGrid.Size = new System.Drawing.Size(605, 99);
            this.uye_dataGrid.TabIndex = 15;
            this.uye_dataGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.uye_dataGrid_CellMouseEnter);
            this.uye_dataGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.uye_dataGrid_RowsAdded);
            this.uye_dataGrid.SelectionChanged += new System.EventHandler(this.uye_dataGrid_SelectionChanged);
            // 
            // uyedeki_kitaplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 130);
            this.Controls.Add(this.uye_dataGrid);
            this.Controls.Add(this.panel28);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "uyedeki_kitaplar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.uyedeki_kitaplar_Load);
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uye_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Label statu;
        public System.Windows.Forms.DataGridView uye_dataGrid;
        private System.Windows.Forms.Button kitap_al;



    }
}