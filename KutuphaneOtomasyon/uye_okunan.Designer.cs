namespace KutuphaneOtomasyon
{
    partial class uye_okunan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uye_okunan_dataGrid = new System.Windows.Forms.DataGridView();
            this.okuma_statusu = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uye_okunan_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.okuma_statusu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 273);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 26);
            this.panel1.TabIndex = 0;
            // 
            // uye_okunan_dataGrid
            // 
            this.uye_okunan_dataGrid.AllowUserToAddRows = false;
            this.uye_okunan_dataGrid.AllowUserToDeleteRows = false;
            this.uye_okunan_dataGrid.AllowUserToResizeColumns = false;
            this.uye_okunan_dataGrid.AllowUserToResizeRows = false;
            this.uye_okunan_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uye_okunan_dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uye_okunan_dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uye_okunan_dataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.uye_okunan_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uye_okunan_dataGrid.Location = new System.Drawing.Point(0, 0);
            this.uye_okunan_dataGrid.Name = "uye_okunan_dataGrid";
            this.uye_okunan_dataGrid.ReadOnly = true;
            this.uye_okunan_dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uye_okunan_dataGrid.Size = new System.Drawing.Size(761, 273);
            this.uye_okunan_dataGrid.TabIndex = 2;
            this.uye_okunan_dataGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.uye_okunan_dataGrid_RowsAdded);
            // 
            // okuma_statusu
            // 
            this.okuma_statusu.AutoSize = true;
            this.okuma_statusu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.okuma_statusu.Location = new System.Drawing.Point(8, 7);
            this.okuma_statusu.Name = "okuma_statusu";
            this.okuma_statusu.Size = new System.Drawing.Size(35, 13);
            this.okuma_statusu.TabIndex = 3;
            this.okuma_statusu.Text = "statü";
            // 
            // uye_okunan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 299);
            this.Controls.Add(this.uye_okunan_dataGrid);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "uye_okunan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "okunanlar";
            this.Load += new System.EventHandler(this.uye_okunan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uye_okunan_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView uye_okunan_dataGrid;
        private System.Windows.Forms.Label okuma_statusu;


    }
}