namespace KutuphaneOtomasyon
{
    partial class yapilandirma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yapilandirma));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.kitap_turleri_dataGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tur_ekle_btn = new System.Windows.Forms.Button();
            this.tur_sil_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bolumler_dataGrid = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bolum_ekle_btn = new System.Windows.Forms.Button();
            this.bolum_sil_btn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dolaplar_dataGrid = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dolap_ekle_btn = new System.Windows.Forms.Button();
            this.dolap_sil_btn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.yedekleme_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.geri_yukle_btn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kitap_turleri_dataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bolumler_dataGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dolaplar_dataGrid)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(567, 226);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.kitap_turleri_dataGrid);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(559, 200);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kitap Türleri";
            // 
            // kitap_turleri_dataGrid
            // 
            this.kitap_turleri_dataGrid.AllowUserToAddRows = false;
            this.kitap_turleri_dataGrid.AllowUserToDeleteRows = false;
            this.kitap_turleri_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kitap_turleri_dataGrid.BackgroundColor = System.Drawing.Color.Gray;
            this.kitap_turleri_dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.kitap_turleri_dataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.kitap_turleri_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitap_turleri_dataGrid.Location = new System.Drawing.Point(147, 36);
            this.kitap_turleri_dataGrid.Name = "kitap_turleri_dataGrid";
            this.kitap_turleri_dataGrid.ReadOnly = true;
            this.kitap_turleri_dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kitap_turleri_dataGrid.Size = new System.Drawing.Size(409, 161);
            this.kitap_turleri_dataGrid.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tur_ekle_btn);
            this.panel2.Controls.Add(this.tur_sil_btn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 161);
            this.panel2.TabIndex = 5;
            // 
            // tur_ekle_btn
            // 
            this.tur_ekle_btn.BackColor = System.Drawing.Color.White;
            this.tur_ekle_btn.FlatAppearance.BorderSize = 0;
            this.tur_ekle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tur_ekle_btn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tur_ekle_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tur_ekle_btn.Image = ((System.Drawing.Image)(resources.GetObject("tur_ekle_btn.Image")));
            this.tur_ekle_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tur_ekle_btn.Location = new System.Drawing.Point(5, 0);
            this.tur_ekle_btn.Name = "tur_ekle_btn";
            this.tur_ekle_btn.Size = new System.Drawing.Size(133, 34);
            this.tur_ekle_btn.TabIndex = 0;
            this.tur_ekle_btn.Text = "Tür Ekle";
            this.tur_ekle_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tur_ekle_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tur_ekle_btn.UseVisualStyleBackColor = false;
            this.tur_ekle_btn.Click += new System.EventHandler(this.tur_ekle_btn_Click);
            // 
            // tur_sil_btn
            // 
            this.tur_sil_btn.BackColor = System.Drawing.Color.White;
            this.tur_sil_btn.FlatAppearance.BorderSize = 0;
            this.tur_sil_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tur_sil_btn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tur_sil_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tur_sil_btn.Image = ((System.Drawing.Image)(resources.GetObject("tur_sil_btn.Image")));
            this.tur_sil_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tur_sil_btn.Location = new System.Drawing.Point(5, 40);
            this.tur_sil_btn.Name = "tur_sil_btn";
            this.tur_sil_btn.Size = new System.Drawing.Size(133, 34);
            this.tur_sil_btn.TabIndex = 1;
            this.tur_sil_btn.Text = "Sil";
            this.tur_sil_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tur_sil_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tur_sil_btn.UseVisualStyleBackColor = false;
            this.tur_sil_btn.Click += new System.EventHandler(this.tur_sil_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 33);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(32, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eklenen kitaplara yeni tür ekleyebilirsiniz veya mevcut türü silebilirsiniz";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.bolumler_dataGrid);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(559, 200);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bölümler";
            // 
            // bolumler_dataGrid
            // 
            this.bolumler_dataGrid.AllowUserToAddRows = false;
            this.bolumler_dataGrid.AllowUserToDeleteRows = false;
            this.bolumler_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bolumler_dataGrid.BackgroundColor = System.Drawing.Color.Gray;
            this.bolumler_dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bolumler_dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.bolumler_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bolumler_dataGrid.Location = new System.Drawing.Point(147, 36);
            this.bolumler_dataGrid.Name = "bolumler_dataGrid";
            this.bolumler_dataGrid.ReadOnly = true;
            this.bolumler_dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bolumler_dataGrid.Size = new System.Drawing.Size(409, 161);
            this.bolumler_dataGrid.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bolum_ekle_btn);
            this.panel3.Controls.Add(this.bolum_sil_btn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(144, 161);
            this.panel3.TabIndex = 19;
            // 
            // bolum_ekle_btn
            // 
            this.bolum_ekle_btn.BackColor = System.Drawing.Color.White;
            this.bolum_ekle_btn.FlatAppearance.BorderSize = 0;
            this.bolum_ekle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bolum_ekle_btn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bolum_ekle_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.bolum_ekle_btn.Image = ((System.Drawing.Image)(resources.GetObject("bolum_ekle_btn.Image")));
            this.bolum_ekle_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bolum_ekle_btn.Location = new System.Drawing.Point(5, 0);
            this.bolum_ekle_btn.Name = "bolum_ekle_btn";
            this.bolum_ekle_btn.Size = new System.Drawing.Size(133, 34);
            this.bolum_ekle_btn.TabIndex = 2;
            this.bolum_ekle_btn.Text = "Yeni Bölüm";
            this.bolum_ekle_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bolum_ekle_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bolum_ekle_btn.UseVisualStyleBackColor = false;
            this.bolum_ekle_btn.Click += new System.EventHandler(this.bolum_ekle_btn_Click);
            // 
            // bolum_sil_btn
            // 
            this.bolum_sil_btn.BackColor = System.Drawing.Color.White;
            this.bolum_sil_btn.FlatAppearance.BorderSize = 0;
            this.bolum_sil_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bolum_sil_btn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bolum_sil_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.bolum_sil_btn.Image = ((System.Drawing.Image)(resources.GetObject("bolum_sil_btn.Image")));
            this.bolum_sil_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bolum_sil_btn.Location = new System.Drawing.Point(5, 40);
            this.bolum_sil_btn.Name = "bolum_sil_btn";
            this.bolum_sil_btn.Size = new System.Drawing.Size(133, 34);
            this.bolum_sil_btn.TabIndex = 3;
            this.bolum_sil_btn.Text = "Sil";
            this.bolum_sil_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bolum_sil_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bolum_sil_btn.UseVisualStyleBackColor = false;
            this.bolum_sil_btn.Click += new System.EventHandler(this.bolum_sil_btn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(553, 33);
            this.panel4.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(91, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Üye eklerken seçilen bölümleri buradan belirleyebilirsiniz";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage3.Controls.Add(this.dolaplar_dataGrid);
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Controls.Add(this.panel6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(559, 200);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dolaplar";
            // 
            // dolaplar_dataGrid
            // 
            this.dolaplar_dataGrid.AllowUserToAddRows = false;
            this.dolaplar_dataGrid.AllowUserToDeleteRows = false;
            this.dolaplar_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dolaplar_dataGrid.BackgroundColor = System.Drawing.Color.Gray;
            this.dolaplar_dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dolaplar_dataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.dolaplar_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dolaplar_dataGrid.Location = new System.Drawing.Point(144, 33);
            this.dolaplar_dataGrid.Name = "dolaplar_dataGrid";
            this.dolaplar_dataGrid.ReadOnly = true;
            this.dolaplar_dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dolaplar_dataGrid.Size = new System.Drawing.Size(415, 167);
            this.dolaplar_dataGrid.TabIndex = 23;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dolap_ekle_btn);
            this.panel5.Controls.Add(this.dolap_sil_btn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(144, 167);
            this.panel5.TabIndex = 22;
            // 
            // dolap_ekle_btn
            // 
            this.dolap_ekle_btn.BackColor = System.Drawing.Color.White;
            this.dolap_ekle_btn.FlatAppearance.BorderSize = 0;
            this.dolap_ekle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dolap_ekle_btn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dolap_ekle_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dolap_ekle_btn.Image = ((System.Drawing.Image)(resources.GetObject("dolap_ekle_btn.Image")));
            this.dolap_ekle_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dolap_ekle_btn.Location = new System.Drawing.Point(5, 1);
            this.dolap_ekle_btn.Name = "dolap_ekle_btn";
            this.dolap_ekle_btn.Size = new System.Drawing.Size(133, 34);
            this.dolap_ekle_btn.TabIndex = 2;
            this.dolap_ekle_btn.Text = "Yeni Dolap";
            this.dolap_ekle_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dolap_ekle_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dolap_ekle_btn.UseVisualStyleBackColor = false;
            this.dolap_ekle_btn.Click += new System.EventHandler(this.dolap_ekle_btn_Click);
            // 
            // dolap_sil_btn
            // 
            this.dolap_sil_btn.BackColor = System.Drawing.Color.White;
            this.dolap_sil_btn.FlatAppearance.BorderSize = 0;
            this.dolap_sil_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dolap_sil_btn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dolap_sil_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dolap_sil_btn.Image = ((System.Drawing.Image)(resources.GetObject("dolap_sil_btn.Image")));
            this.dolap_sil_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dolap_sil_btn.Location = new System.Drawing.Point(5, 41);
            this.dolap_sil_btn.Name = "dolap_sil_btn";
            this.dolap_sil_btn.Size = new System.Drawing.Size(133, 34);
            this.dolap_sil_btn.TabIndex = 3;
            this.dolap_sil_btn.Text = "Sil";
            this.dolap_sil_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dolap_sil_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dolap_sil_btn.UseVisualStyleBackColor = false;
            this.dolap_sil_btn.Click += new System.EventHandler(this.dolap_sil_btn_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(559, 33);
            this.panel6.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(91, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kitapların bulunduğu dolapları buradan düzenleyebilirsiniz";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage4.Controls.Add(this.yedekleme_btn);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(559, 200);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Yedekleme";
            // 
            // yedekleme_btn
            // 
            this.yedekleme_btn.BackColor = System.Drawing.Color.White;
            this.yedekleme_btn.FlatAppearance.BorderSize = 0;
            this.yedekleme_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yedekleme_btn.Location = new System.Drawing.Point(215, 110);
            this.yedekleme_btn.Name = "yedekleme_btn";
            this.yedekleme_btn.Size = new System.Drawing.Size(129, 35);
            this.yedekleme_btn.TabIndex = 1;
            this.yedekleme_btn.Text = "Verileri dışa aktar";
            this.yedekleme_btn.UseVisualStyleBackColor = false;
            this.yedekleme_btn.Click += new System.EventHandler(this.yedekleme_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(106, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Yedeklediğiniz verileri daha sonra geri yükleme aracılığıyla \r\ngeri alabilirsiniz" +
    ".";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.geri_yukle_btn);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(559, 200);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Geri Yükleme";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(133, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(292, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Daha önce yedeklediğiniz veritabanını içe aktarın.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // geri_yukle_btn
            // 
            this.geri_yukle_btn.BackColor = System.Drawing.Color.White;
            this.geri_yukle_btn.FlatAppearance.BorderSize = 0;
            this.geri_yukle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.geri_yukle_btn.Location = new System.Drawing.Point(215, 98);
            this.geri_yukle_btn.Name = "geri_yukle_btn";
            this.geri_yukle_btn.Size = new System.Drawing.Size(129, 35);
            this.geri_yukle_btn.TabIndex = 2;
            this.geri_yukle_btn.Text = "Geri Yükle";
            this.geri_yukle_btn.UseVisualStyleBackColor = false;
            this.geri_yukle_btn.Click += new System.EventHandler(this.geri_yukle_btn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // yapilandirma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 226);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "yapilandirma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yapılandırma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.yapilandirma_FormClosing);
            this.Load += new System.EventHandler(this.yapilandirma_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kitap_turleri_dataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bolumler_dataGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dolaplar_dataGrid)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button tur_sil_btn;
        private System.Windows.Forms.Button tur_ekle_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView kitap_turleri_dataGrid;
        public System.Windows.Forms.DataGridView bolumler_dataGrid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bolum_ekle_btn;
        private System.Windows.Forms.Button bolum_sil_btn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dolaplar_dataGrid;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button dolap_ekle_btn;
        private System.Windows.Forms.Button dolap_sil_btn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button yedekleme_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button geri_yukle_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TabControl tabControl;
    }
}