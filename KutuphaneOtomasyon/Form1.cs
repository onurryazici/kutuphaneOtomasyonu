using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;//
using System.IO;//
using System.Globalization;//
namespace KutuphaneOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        
        /// <summary>
        /// Onur Yazıcı
        /// 
        /// Bazı yerlerde trigger kullanılması gerekirdi. Ama sqlite veritabanında parametre(declare) özelliği tanımlanamadığı için
        /// trigger kullanamadım. Bu veritabanı programın içine gömülüdür. Herhangi bir ek kurulum istemez (ms sql server, access vs.)
        /// Bütün veri girişleri kontrol edilerek işlem yapılır. Kontroller(textbox,picturebox vs.) döngülerle kontrol edilir.
        /// Bazı nesnelerde işlem yapıldıktan sonra bellekten temizlendi.
        /// 
        /// </summary>
        #region Global değişkenler
        SQLiteConnection connection = new SQLiteConnection("Data Source = " + Application.CommonAppDataPath + "\\database.db; Read Only = false;");
        SQLiteCommand command;
        SQLiteDataAdapter data_adapt;
        SQLiteDataReader reader;
        DataSet dt_set;
        islemler isl_obj = new islemler();
        string query; // sorgular
        public string form_verisi = null;// form active olayı için veri tutucusu
        string cinsiyet_d = null, bolum_d = null, sinif_d = null; //0.index aramaları (üyeler)
        string tur_d = null, yazar_d = null, kitap_ad_d=null; //1.index aramaları (kitaplar)
        bool uye_duzenleme=false;
        #endregion

        private void say(DataGridView tablo)
        {
            int toplam = Convert.ToInt32(tablo.RowCount.ToString());
            if (toplam > 0)
            {
                switch (tablo.Name)
                {
                    case "uyeler_dataGrid":
                        statu.Text = toplam + " üye listelendi.";
                        break;
                    case "kitaplar_dataGrid":
                        statu.Text = toplam + " kitap listelendi.";
                        break;
                    case "emanet_dataGrid":
                        statu.Text = toplam + " kitap teslim edildi.";
                        break;
                    case "okunanlar_dataGrid":
                        statu.Text = toplam + " okuma gerçekleşti.";
                        break;
                    case "Cezalılar":
                        statu.Text = toplam + " kullanıcı cezalandırıldı.";
                        break;
                }
            }
            else
            {
                statu.Text = "Listelenecek öğe yok.";
            }
        }
        #region Form işlemleri(temizleme, kontrol vs.)
        private void formu_temizle(Panel etkilenecek_alan)
        {
            foreach(Control ctrl in etkilenecek_alan.Controls)
            {
                if(ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                }
                else if(ctrl is ComboBox)
                {
                    (ctrl as ComboBox).SelectedItem = string.Empty;
                }
                else if(ctrl is PictureBox)
                {
                    (ctrl as PictureBox).Image = null;
                }
                else if(ctrl is MaskedTextBox)
                {
                    (ctrl as MaskedTextBox).Clear();
                }
            }
        }
        private void formu_guncellemekicin_aktiflestir(Panel etkilenecek_alan, Button tiklanan)
        {
            foreach(Control ctrl in etkilenecek_alan.Controls)
            {
                if (ctrl is ComboBox || ctrl is PictureBox || ctrl is TextBox || ctrl is PictureBox || ctrl is MaskedTextBox) 
                {
                    ctrl.Enabled = true;
                }
                else if(ctrl is Button && (ctrl as Button).Name != tiklanan.Name)
                {
                    ctrl.Enabled = false;
                }
            }
        }
        private void formu_aktiflestir(Panel etkilenecek_alan, Button tiklanan)
        {
            foreach (Control ctrl in etkilenecek_alan.Controls)
            {
                if(ctrl is TextBox)
                {
                    ctrl.Enabled = true;
                    (ctrl as TextBox).Clear();
                }
                else if(ctrl is PictureBox)
                {
                    ctrl.Enabled = true;
                    (ctrl as PictureBox).Image = null;
                }
                else if(ctrl is ComboBox)
                {
                    ctrl.Enabled = true;
                    (ctrl as ComboBox).SelectedItem = "";
                }
                else if(ctrl is MaskedTextBox)
                {
                    ctrl.Enabled = true;
                    (ctrl as MaskedTextBox).Clear();
                }
                else if(ctrl is Button && (ctrl as Button).Name != tiklanan.Name)
                {
                    ctrl.Enabled = false;
                }
            }
        }
        private void formu_pasiflestir(Panel etkilenecek_alan)
        {
            foreach (Control ctrl in etkilenecek_alan.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Enabled = false;
                    (ctrl as TextBox).Clear();
                }
                else if (ctrl is PictureBox)
                {
                    ctrl.Enabled = false;
                    (ctrl as PictureBox).Image = null;
                }
                else if (ctrl is ComboBox)
                {
                    ctrl.Enabled = false;
                    (ctrl as ComboBox).SelectedItem = "";
                }
                else if (ctrl is MaskedTextBox)
                {
                    ctrl.Enabled = false;
                    (ctrl as MaskedTextBox).Clear();
                }
            }
        }
        private void formu_varsayilana_getir(Panel etkilenecek_alan)
        {
            foreach(Control ctrl in etkilenecek_alan.Controls)
            {
                if(ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                    ctrl.Enabled = false;
                }
                else if(ctrl is ComboBox)
                {
                    (ctrl as ComboBox).SelectedItem = "";
                    ctrl.Enabled = false;
                }
                else if(ctrl is MaskedTextBox)
                {
                    (ctrl as MaskedTextBox).Clear();
                    ctrl.Enabled = false;
                }
                else if(ctrl is PictureBox)
                {
                    (ctrl as PictureBox).Image = null;
                    ctrl.Enabled = false;
                }
                else if(ctrl is ComboBox)
                {
                    (ctrl as ComboBox).SelectedItem = "";
                    ctrl.Enabled = false;
                }
                else if(ctrl is Button)
                {
                    ctrl.Enabled = true;
                }
            }
        }
        private bool formu_kontrolet(Panel etkilenecek_alan)
        {
            bool deger = true;
            foreach(Control ctrl in etkilenecek_alan.Controls)
            {
                if (ctrl is TextBox && (ctrl as TextBox).Text.Trim(' ') == string.Empty)
                {
                    deger = false;
                }
                /*else if (ctrl is PictureBox && (ctrl as PictureBox).Image == null)
                {
                    deger = false;
                }*/
                else if (ctrl is ComboBox && (ctrl as ComboBox).SelectedItem.ToString() == string.Empty)
                {
                    deger = false;
                }
                else if (ctrl is MaskedTextBox && (ctrl as MaskedTextBox).Text.Trim(' ').Length != 12)
                {
                    deger = false;
                }
            }
            return deger;
        }
        #endregion

        #region Özel metotlar (listeleme,verileri yükleme vs)
        private void listele(DataGridView tablo)
        {
            try
            {
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                switch (tablo.Name)
                {
                    case "uyeler_dataGrid":
                        query = "SELECT ogr_no AS [Öğrenci No], ad_soyad AS [Ad Soyad], ogr_bolum AS [Bölüm], cinsiyet AS [Cinsiyet], sinif AS [Sınıf], "
                            + "telefon AS [Telefon], toplam_okuma AS [Toplam Okuma] FROM ogrenciler";
                        data_adapt = new SQLiteDataAdapter(query, connection);
                        dt_set = new DataSet();
                        data_adapt.Fill(dt_set, "ogrenciler");
                        tablo.DataSource = dt_set.Tables["ogrenciler"];

                        if (tablo.Rows.Count >= 1 && tablo.SelectedRows.Count < 1)
                        {
                            tablo.Rows[0].Selected = true;
                        }

                        ogr_cinsiyet.SelectedIndex = 0;
                        ogr_bolum.Items.Clear();
                        ogr_bolum.Items.Add("");
                        bolum_data.Items.Clear();
                        bolum_data.Items.Add("");
                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        query = "SELECT bolum_adi FROM bolumler";
                        command = new SQLiteCommand(query, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ogr_bolum.Items.Add(reader[0].ToString());
                            bolum_data.Items.Add(reader[0].ToString());
                        }
                        reader.Close();
                        say(uyeler_dataGrid);
                        break;

                    case "kitaplar_dataGrid":
                        query = "SELECT barkod_no AS [Barkod No], ad AS [Kitap Adı], yazar AS [Yazar], yayinevi AS [Yayınevi], tur AS [Tür], "
                            + "adet AS [Adet], sayfa_sayisi AS [Sayfa Sayısı], dolap_adi AS [Dolap] FROM kitaplar";
                        data_adapt = new SQLiteDataAdapter(query, connection);
                        dt_set = new DataSet();
                        data_adapt.Fill(dt_set, "kitaplar");
                        tablo.DataSource = dt_set.Tables["kitaplar"];

                        kitap_tur.Items.Clear();
                        kitap_tur.Items.Add("");
                        query = "SELECT tur_adi FROM kitap_turleri";
                        command = new SQLiteCommand(query, connection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            kitap_tur.Items.Add(reader[0].ToString());
                        }
                        reader.Close();
                        say(kitaplar_dataGrid);

                        break;
                    case "emanet_dataGrid":
                        query = "SELECT barkod_no AS [Barkod No], kitap_adi AS [Kitap], ogr_no AS [Öğrenci No], ad_soyad AS [Ad Soyad], "
                         + "teslim_tarih AS [Teslim Edilen Tarih], son_tarih AS [Son Tarih] FROM emanet";
                        data_adapt = new SQLiteDataAdapter(query, connection);
                        dt_set = new DataSet();
                        data_adapt.Fill(dt_set, "emanet");
                        tablo.DataSource = dt_set.Tables["emanet"];
                        say(emanet_dataGrid);

                        kitap_arama_kriter.SelectedIndex = 0;
                        ogr_arama_kriter.SelectedIndex = 0;
                        break;
                }
            }
            catch(Exception exm)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n"+exm.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed) { connection.Close(); }
            }
        }
        private void verileri_yukle(string ogr_no, DataGridView etkilenecek_tablo)
        {
            try
            {
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                if (uye_duzenleme == false && etkilenecek_tablo.Rows.Count >= 1 && etkilenecek_tablo.SelectedRows.Count >= 1) 
                {
                    uye_okunan_kitap_p.Visible = true;
                    uyedeki_kitap_panel.Visible = true;
                    uye_detaylari.Visible = true;
                    query = "SELECT ogr_resim FROM ogrenciler WHERE ogr_no=@ogr_no";
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@ogr_no", ogr_no);
                    byte[] veri = (byte[])command.ExecuteScalar();
                    MemoryStream ms = new MemoryStream(veri);
                    ogr_resim.Image = Image.FromStream(ms);

                    query = "SELECT * FROM ogrenciler WHERE ogr_no=@ogr_no";
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@ogr_no", ogr_no);
                    reader = command.ExecuteReader();
                    reader.Read();
                    ogr_no_data.Text = reader["ogr_no"].ToString();
                    ad_soyad_data.Text = reader["ad_soyad"].ToString();
                    bolum_data.SelectedItem = reader["ogr_bolum"].ToString();


                    cinsiyet_data.SelectedItem = reader["cinsiyet"].ToString();
                    sinif_data.SelectedItem = reader["sinif"].ToString();
                    telefon_data.Text = reader["telefon"].ToString();
                    toplam_okuma_data.Text = reader["toplam_okuma"].ToString();
                    ceza_data.Text = reader["ceza"].ToString();
                    reader.Close();
                }
                else
                {
                    uye_okunan_kitap_p.Visible = false;
                    uyedeki_kitap_panel.Visible = false;
                    uye_detaylari.Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
        #endregion

        #region Olaylar
        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle dikdortgen = new Rectangle(tabPage1.Left, tabPage1.Top, tabPage1.Width, tabPage1.Height);
            maintabControl.Region = new Region(dikdortgen);

            uyeler_btn.PerformClick();
            foreach(DataGridViewColumn sutun in uyeler_dataGrid.Columns)
            {
                sutun.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn sutun in kitaplar_dataGrid.Columns)
            {
                sutun.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach(DataGridViewColumn sutun in emanet_dataGrid.Columns)
            {
                sutun.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void uyeler_btn_Click(object sender, EventArgs e)
        {
            maintabControl.SelectedIndex = 0;
            listele(uyeler_dataGrid);
            if (uyeler_dataGrid.Rows.Count >= 1 && uyeler_dataGrid.SelectedRows.Count >= 1)  
                verileri_yukle(uyeler_dataGrid.CurrentRow.Cells[0].Value.ToString(),uyeler_dataGrid);
        }
        private void kitap_listesi_btn_Click(object sender, EventArgs e)
        {
            maintabControl.SelectedIndex = 1;
            listele(kitaplar_dataGrid);
        }

        private void emanet_btn_Click(object sender, EventArgs e)
        {
            maintabControl.SelectedIndex = 2;
            listele(emanet_dataGrid);
        }
        private void yapilandirma_btn_Click(object sender, EventArgs e)
        {
            var yapilandirma_v = Application.OpenForms["yapilandirma"];
            if(yapilandirma_v==null)
            {
                yapilandirma_v = new yapilandirma();
            }
            yapilandirma_v.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Rectangle dikdortgen;
            dikdortgen = new Rectangle(maintabControl.SelectedTab.Left, maintabControl.SelectedTab.Top,
                       maintabControl.SelectedTab.Width, maintabControl.SelectedTab.Height);
            maintabControl.Region = new Region(dikdortgen);
        }

        private void uye_ekle_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(ogr_no_data.Enabled==false)
                {
                    formu_aktiflestir(uye_paneli,uye_ekle_btn);
                    uye_ekle_btn.Text = "Eklemeyi bitir";
                    uye_duzenleme = true;
                    uye_okunan_kitap_p.Visible = false;
                    uyedeki_kitap_panel.Visible = false;
                    uye_detaylari.Visible = false;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Üye eklemek istiyorsanız evet, işlemi iptal etmek için hayır butonunu tıklayın",
                        "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (formu_kontrolet(uye_paneli) && ogr_no_data.TextLength == 12)
                        {
                            if(uye_resmi_sec.FileName==string.Empty)
                            {
                                MessageBox.Show("Lütfen üye resmi yükleyiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                isl_obj.uye_ekle(ogr_no_data.Text, ad_soyad_data.Text, bolum_data.Text, cinsiyet_data.Text, sinif_data.Text,
                                    telefon_data.Text, uye_resmi_sec.FileName);

                                formu_pasiflestir(uye_paneli);
                                uye_ekle_btn.Text = "Üye Ekle";
                                uyeler_btn.PerformClick();
                                formu_varsayilana_getir(uye_paneli);
                                uye_duzenleme = false;

                                if (uyeler_dataGrid.Rows.Count >= 1 && uyeler_dataGrid.SelectedRows.Count >= 1)
                                    verileri_yukle(uyeler_dataGrid.SelectedRows[0].Cells[0].Value.ToString(), uyeler_dataGrid);
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Gerekli alanları doldurmalısınız.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        formu_varsayilana_getir(uye_paneli);
                        uye_ekle_btn.Text = "Üye Ekle";
                        uye_duzenleme = false;
                        if (uyeler_dataGrid.Rows.Count >= 1 && uyeler_dataGrid.SelectedRows.Count >= 1) 
                            verileri_yukle(uyeler_dataGrid.SelectedRows[0].Cells[0].Value.ToString(),uyeler_dataGrid);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            
        }
        private void uye_sil_btn_Click(object sender, EventArgs e)
        {
            try
            {
                form_verisi = null;
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                if (uyeler_dataGrid.SelectedRows.Count == 0 || uyeler_dataGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Silinecek üye bulunamadı.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (uyeler_dataGrid.SelectedRows.Count > 1)
                {
                    DialogResult result = MessageBox.Show("Seçili " + uyeler_dataGrid.SelectedRows.Count.ToString() + " üyeyi silmek "
                    + "istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = 0; i < uyeler_dataGrid.SelectedRows.Count; i++)
                        {
                            if(isl_obj.uye_silinebilirlik_kontrol(uyeler_dataGrid.SelectedRows[i].Cells["Öğrenci No"].Value.ToString()))
                            {
                                query = "DELETE FROM ogrenciler WHERE ogr_no=" + uyeler_dataGrid.SelectedRows[i].Cells[0].Value.ToString();
                                command = new SQLiteCommand(query, connection);
                                command.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Kitap almış bir öğrenci kitabı teslim etmeden silinemez.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                        listele(uyeler_dataGrid);
                    }
                }
                else if (uyeler_dataGrid.SelectedRows.Count == 1)
                {
                    DialogResult result = MessageBox.Show("Seçili " + uyeler_dataGrid.CurrentRow.Cells[1].Value.ToString() + " "
                        + "üyesini silmek istediğinize emin misiniz ?", "Uyarı",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if(isl_obj.uye_silinebilirlik_kontrol(uyeler_dataGrid.CurrentRow.Cells[0].Value.ToString()))
                        {
                            query = "DELETE FROM ogrenciler WHERE ogr_no=" + uyeler_dataGrid.CurrentRow.Cells[0].Value.ToString();
                            command = new SQLiteCommand(query, connection);
                            command.ExecuteNonQuery();
                            listele(uyeler_dataGrid);
                        }
                        else
                        {
                            MessageBox.Show("Kitap almış bir öğrenci kitabı teslim etmeden silinemez.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            
        }
        private void uye_guncelle_btn_Click(object sender, EventArgs e)
        {
            if(uyeler_dataGrid.Rows.Count >= 1 && uyeler_dataGrid.SelectedRows.Count >= 1)
            {
                if (uyeler_dataGrid.SelectedRows.Count >= 1)
                {
                    for (int i = 0; i < uyeler_dataGrid.Rows.Count; i++)
                    {
                        if(uyeler_dataGrid.Rows[i] != uyeler_dataGrid.CurrentRow)
                        {
                            uyeler_dataGrid.Rows[i].Selected = false;
                        }
                    }
                }
                string eski_ogr_no = uyeler_dataGrid.SelectedRows[0].Cells[0].Value.ToString();
                if (uye_guncelle_btn.Text == "Güncelle")
                {
                    uye_guncelle_btn.Text = "Güncellemeyi bitir";
                    formu_guncellemekicin_aktiflestir(uye_paneli, uye_guncelle_btn);
                    uye_duzenleme = true;
                    uye_okunan_kitap_p.Visible = false;
                    uyedeki_kitap_panel.Visible = false;
                    uye_detaylari.Visible = false;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Güncellemeyi tamamlamak için evet, işlemi iptal etmek için hayır butonuna basın", "",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (formu_kontrolet(uye_paneli) && ogr_no_data.TextLength == 12)
                        {
                            isl_obj.uye_guncelle(eski_ogr_no, ogr_no_data.Text, ad_soyad_data.Text, bolum_data.Text, cinsiyet_data.Text, sinif_data.Text, telefon_data.Text, uye_resmi_sec.FileName);
                            uye_resmi_sec.FileName = null;
                            formu_varsayilana_getir(uye_paneli);
                            uye_okunan_kitap_p.Visible = true;
                            uyedeki_kitap_panel.Visible = true;
                            uye_detaylari.Visible = true;
                            uye_guncelle_btn.Text = "Güncelle";
                            uye_duzenleme = false;
                            listele(uyeler_dataGrid);
                            if (uyeler_dataGrid.SelectedRows.Count >= 1)
                                verileri_yukle(uyeler_dataGrid.SelectedRows[0].Cells[0].Value.ToString(), uyeler_dataGrid);
                        }
                        else
                        {
                            MessageBox.Show("Gerekli alanları doldurmalısınız.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        formu_varsayilana_getir(uye_paneli);
                        uye_guncelle_btn.Text = "Güncelle";
                        uye_duzenleme = false;
                        if (uyeler_dataGrid.SelectedRows.Count >= 1)
                            verileri_yukle(uyeler_dataGrid.SelectedRows[0].Cells[0].Value.ToString(), uyeler_dataGrid);
                    }
                }
            }
            else
            {
                MessageBox.Show("Üye güncellemek için üyenin kayıtlı olup seçilmesi gerekir.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
        private void uye_araTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT ogr_no AS [Öğrenci No], ad_soyad AS [Ad Soyad], ogr_bolum AS [Bölüm], cinsiyet AS [Cinsiyet], sinif AS [Sınıf], "
                        + "telefon AS [Telefon], toplam_okuma AS [Toplam Okuma] FROM ogrenciler WHERE "
                        + "ogr_no LIKE '" + ogr_no.Text + "%' AND ad_soyad LIKE '%" + uye_araTextbox.Text + "%' AND cinsiyet LIKE '%" + cinsiyet_d + "%' AND "
                        + "ogr_bolum LIKE '%" + bolum_d + "%' AND sinif LIKE '%" + sinif_d + "%'";
                data_adapt = new SQLiteDataAdapter(query, connection);
                dt_set = new DataSet();
                data_adapt.Fill(dt_set, "ogrenciler");
                uyeler_dataGrid.DataSource = dt_set.Tables["ogrenciler"];
                say(uyeler_dataGrid);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void kitap_ekle_btn_Click(object sender, EventArgs e)
        {
            var kitap_ekle_v = Application.OpenForms["kitap_ekle"];
            if (kitap_ekle_v == null) 
            {
                kitap_ekle_v = new kitap_ekle();
            }
            form_verisi = kitap_ekle_v.Name;
            kitap_ekle_v.ShowDialog();
        }

        private void kitap_ver_btn_Click(object sender, EventArgs e)
        {
            if (connection.State != ConnectionState.Open) { connection.Open(); }
            query = "SELECT COUNT(barkod_no) FROM kitaplar";
            command = new SQLiteCommand(query,connection);
            int kitap_toplam = Convert.ToInt32(command.ExecuteScalar());

            query = "SELECT COUNT(ogr_no) FROM ogrenciler";
            command = new SQLiteCommand(query,connection);
            int uye_toplam = Convert.ToInt32(command.ExecuteScalar());

            if (uye_toplam == 0 || kitap_toplam == 0)
            {
                MessageBox.Show("Eklenmiş kitap veya üye yok. Bu işlemi yapamazsınız.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var kitapver_v = Application.OpenForms["kitap_ver"];
                if (kitapver_v == null)
                {
                    kitapver_v = new kitap_ver();
                }
                form_verisi = kitapver_v.Name;
                kitapver_v.ShowDialog();
            }
        }

        private void kitap_sil_btn_Click(object sender, EventArgs e)
        {
            form_verisi = null;
            if (connection.State != ConnectionState.Open) { connection.Open(); }


            if (kitaplar_dataGrid.SelectedRows.Count == 0 || kitaplar_dataGrid.Rows.Count == 0)
            {
                MessageBox.Show("Silme işlemi yapabilmeniz için en az bir kitap kayıtlı olmalı ve seçilmelidir.", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (kitaplar_dataGrid.SelectedRows.Count > 1)
            {
                DialogResult result = MessageBox.Show("Seçili " + kitaplar_dataGrid.SelectedRows.Count.ToString() + " kitabı silmek istediğinize "
                    + "emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < kitaplar_dataGrid.SelectedRows.Count; i++)
                    {
                        if(isl_obj.kitap_silinebilirlik_kontrol(kitaplar_dataGrid.SelectedRows[i].Cells["Barkod No"].Value.ToString()))
                        {
                            query = "DELETE FROM kitaplar WHERE barkod_no = " + kitaplar_dataGrid.SelectedRows[i].Cells[0].Value.ToString();
                            command = new SQLiteCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Teslim edilmiş kitap geri alınmadan silinemez","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }
            else if (kitaplar_dataGrid.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show(kitaplar_dataGrid.CurrentRow.Cells[1].Value.ToString() + " adlı kitabı "
                    + "silmek istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if(isl_obj.kitap_silinebilirlik_kontrol(kitaplar_dataGrid.CurrentRow.Cells["Barkod No"].Value.ToString()))
                    {
                        query = "DELETE FROM kitaplar WHERE barkod_no=" + kitaplar_dataGrid.CurrentRow.Cells["Barkod No"].Value.ToString();
                        command = new SQLiteCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Teslim edilmiş kitap geri alınmadan silinemez", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (connection.State != ConnectionState.Closed) { connection.Close(); }
            listele(kitaplar_dataGrid);
        }
        kitap_guncelle kitap_guncelle_v;
        private void kitap_guncelle_btn_Click(object sender, EventArgs e)
        {
            
            if (kitaplar_dataGrid.Rows.Count == 0 || kitaplar_dataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncelleme yapabilmek için en az bir kitabın kayıtlı olması ve seçilmesi gerekir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < kitaplar_dataGrid.RowCount; i++)
                {
                    if (kitaplar_dataGrid.Rows[i] != kitaplar_dataGrid.SelectedRows[0])
                    {
                        kitaplar_dataGrid.Rows[i].Selected = false;
                    }
                }
                if (kitap_guncelle_v == null)
                {
                    kitap_guncelle_v = new kitap_guncelle();
                }
                form_verisi = kitap_guncelle_v.Name;
                kitap_guncelle_v.barkod_no_d = kitaplar_dataGrid.SelectedRows[0].Cells["Barkod No"].Value.ToString();
                kitap_guncelle_v.ad_d = kitaplar_dataGrid.SelectedRows[0].Cells["Kitap Adı"].Value.ToString();
                kitap_guncelle_v.yazar_d = kitaplar_dataGrid.SelectedRows[0].Cells["Yazar"].Value.ToString();
                kitap_guncelle_v.yayinevi_d = kitaplar_dataGrid.SelectedRows[0].Cells["Yayınevi"].Value.ToString();
                kitap_guncelle_v.tur_d = kitaplar_dataGrid.SelectedRows[0].Cells["Tür"].Value.ToString();
                kitap_guncelle_v.sayfa_d = kitaplar_dataGrid.SelectedRows[0].Cells["Sayfa Sayısı"].Value.ToString();
                kitap_guncelle_v.adet_d = kitaplar_dataGrid.SelectedRows[0].Cells["Adet"].Value.ToString();
                kitap_guncelle_v.dolap_d = kitaplar_dataGrid.SelectedRows[0].Cells["Dolap"].Value.ToString();
                kitap_guncelle_v.ShowDialog();

                this.kitap_guncelle_v.Dispose();
                GC.SuppressFinalize(this.kitap_guncelle_v);
                kitap_guncelle_v = null;
            }
        }
        private void ogr_bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            bolum_d = ogr_bolum.SelectedItem.ToString();
            this.ogr_bolum.SelectedIndexChanged += new System.EventHandler(uye_araTextbox_TextChanged);
            
        }
        private void ogr_cinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            cinsiyet_d = ogr_cinsiyet.SelectedItem.ToString();
            this.ogr_cinsiyet.SelectedIndexChanged += new System.EventHandler(uye_araTextbox_TextChanged);
        }
        private void ogr_sinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            sinif_d = ogr_sinif.SelectedItem.ToString();
            this.ogr_sinif.SelectedIndexChanged += new System.EventHandler(uye_araTextbox_TextChanged);
        }

        private void kitap_tur_SelectedIndexChanged(object sender, EventArgs e)
        {
            tur_d = kitap_tur.SelectedItem.ToString();
            this.kitap_tur.SelectedIndexChanged += new System.EventHandler(kitap_barkod_txtb_TextChanged);
        }
        private void kitap_yazar_TextChanged(object sender, EventArgs e)
        {
            yazar_d = kitap_yazar.Text;
            this.kitap_yazar.TextChanged += new System.EventHandler(kitap_barkod_txtb_TextChanged);
        }
        private void kitap_barkod_txtb_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT barkod_no AS [Barkod No], ad AS [Kitap Adı], yazar AS [Yazar], yayinevi AS [Yayınevi], tur AS [Tür], "
                        + "adet AS [Adet], sayfa_sayisi AS [Sayfa Sayısı], dolap_adi AS [Dolap] FROM kitaplar WHERE barkod_no LIKE '" + kitap_barkod_txtb.Text + "%' AND yazar LIKE '%" + yazar_d + "%' AND tur LIKE '%" + tur_d + "%'"
                        + " AND ad LIKE '%" + kitap_ad.Text + "%'";
            data_adapt = new SQLiteDataAdapter(query, connection);
            dt_set = new DataSet();
            data_adapt.Fill(dt_set, "kitaplar");
            kitaplar_dataGrid.DataSource = dt_set.Tables["kitaplar"];
            say(kitaplar_dataGrid);
        }
        
        private void emanet_iptal_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (emanet_dataGrid.SelectedRows.Count == 0 || emanet_dataGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Teslim edilen kitabı iptal etmek için en az bir kaydın mevcut olup seçilmesi gerekir", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (emanet_dataGrid.SelectedRows.Count >= 1)
                {
                    for (int i = 0; i < emanet_dataGrid.Rows.Count; i++)
                    {
                        if(emanet_dataGrid.Rows[i] != emanet_dataGrid.CurrentRow)
                        {
                            emanet_dataGrid.Rows[i].Selected = false;
                        }
                    }
                    DialogResult result = MessageBox.Show("Seçili işlemi iptal etmek istediğinize emin misiniz?","",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        query = "DELETE FROM emanet WHERE barkod_no = " + emanet_dataGrid.CurrentRow.Cells[0].Value.ToString() +
                            " AND ogr_no=" + emanet_dataGrid.CurrentRow.Cells[2].Value.ToString();
                        command = new SQLiteCommand(query, connection);
                        command.ExecuteNonQuery();
                        listele(emanet_dataGrid);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (form_verisi == "uye_ekle" || form_verisi == "uye_guncelle" || form_verisi== "uyedeki_kitaplar")
            {
                listele(uyeler_dataGrid);
            }
            else if (form_verisi == "kitap_ekle" || form_verisi == "kitap_guncelle")
            {
                listele(kitaplar_dataGrid);
            }
            else if (form_verisi == "emanet_guncelle" || form_verisi == "kitap_ver" || form_verisi == "kitap_al")  
            {
                listele(emanet_dataGrid);
            }
            form_verisi = null;
        }
        private void ogr_resim_MouseEnter(object sender, EventArgs e)
        {
            if (ogr_resim.Enabled)
            {
                ogr_resim.Cursor = Cursors.Hand;
            }
            else
            {
                ogr_resim.Cursor = Cursors.Default;
            }
        }
        private void ogr_resim_Click(object sender, EventArgs e)
        {
            try
            {
                uye_resmi_sec.Filter = "Resim Dosyaları | *.bmp; *.jpg; *.png;";
                uye_resmi_sec.FilterIndex = 1;
                uye_resmi_sec.Title = "Ekleyeceğiniz üyenin resmini seçin.";
                uye_resmi_sec.FileName = string.Empty;
                
                if (uye_resmi_sec.ShowDialog() == DialogResult.OK)
                {
                    FileInfo dosya_bilgisi = new FileInfo(uye_resmi_sec.FileName);
                    long boyut=dosya_bilgisi.Length;
                    if(boyut < 800000)
                    {
                        ogr_resim.Image = new Bitmap(uye_resmi_sec.OpenFile());
                    }
                    else
                    {
                        MessageBox.Show("Yükleyeceğiniz resim maksimum 800kb olmalıdır.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ogr_no_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ad_soyad_data_Leave(object sender, EventArgs e)
        {
            ad_soyad_data.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ad_soyad_data.Text);
        }

        private void uye_ekle_btn_MouseEnter(object sender, EventArgs e)
        {
            if (uye_ekle_btn.Text != "Üye Ekle")
            {
                toolTip.SetToolTip(this.uye_ekle_btn,"İşlemi iptal etmek için bu butonu tıklatın.\n Ardından hayır butonu ile işlemi iptal edin");
            }
        }

        private void uyeler_dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (uyeler_dataGrid.SelectedRows.Count >= 1)
            {
                verileri_yukle(uyeler_dataGrid.CurrentRow.Cells[0].Value.ToString(), uyeler_dataGrid);
            }
        }

        private void ogr_no_TextChanged(object sender, EventArgs e)
        {
            this.ogr_no.TextChanged += new EventHandler(uye_araTextbox_TextChanged);
        }

        private void ogr_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void arama_sifirla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formu_temizle(uye_arama_paneli);
        }

        private void kitap_arama_sifirla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formu_temizle(kitap_arama_paneli);
        }

        private void kitap_barkod_txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void kitap_ad_TextChanged(object sender, EventArgs e)
        {
            kitap_barkod_txtb.Clear();
            kitap_ad_d = kitap_ad.Text;
            this.kitap_ad.TextChanged += new System.EventHandler(kitap_barkod_txtb_TextChanged);
        }

        private void uyeler_dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int index = 0;
            foreach(DataGridViewRow satir in uyeler_dataGrid.Rows)
            {
                if (index % 2 == 0)
                { satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D3DDF6"); }
                else
                { satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E5E4F2"); }
                index++;
            }
        }

        private void emanet_dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            foreach(DataGridViewRow satir in emanet_dataGrid.Rows)
            {
                
                TimeSpan tms = Convert.ToDateTime(satir.Cells["Son Tarih"].Value.ToString()) - DateTime.Now;
                int kalan_gun = tms.Days;
                if (kalan_gun >= 0)
                { 
                    satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E5E4F2");
                    satir.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#333333");
                }
                else
                { 
                    satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D93600");
                    satir.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#D93600");
                }
            }
            
        }

        private void kitaplar_dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int index = 0;
            foreach(DataGridViewRow satir in kitaplar_dataGrid.Rows)
            {
                if (index % 2 == 0)
                { satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D3DDF6"); }
                else
                { satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E5E4F2"); }
                index++;
            }
        }

        private void kitap_al_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                if (emanet_dataGrid.Rows.Count != 0)
                {
                    if (emanet_dataGrid.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Teslim edilen kitabı almak için seçmeniz gerekir.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        for (int i = 0; i < emanet_dataGrid.Rows.Count; i++)
                        {
                            if (emanet_dataGrid.Rows[i] != emanet_dataGrid.CurrentRow)
                            {
                                emanet_dataGrid.Rows[i].Selected = false;
                            }
                        }
                        query = "SELECT son_tarih FROM emanet WHERE barkod_no = " + emanet_dataGrid.CurrentRow.Cells[0].Value.ToString() +
                            " AND ogr_no = " + emanet_dataGrid.CurrentRow.Cells[2].Value.ToString();
                        command = new SQLiteCommand(query,connection);
                        DateTime son_tarih = Convert.ToDateTime(command.ExecuteScalar());
                        TimeSpan tms = son_tarih - DateTime.Now;
                        int sonuc = tms.Days;
                        if(sonuc >= 0) // son tarih geçmemişse
                        {
                            DialogResult result = MessageBox.Show("Seçili işlem onaylanacaktır. Kabul ediyor musunuz?\n\n Ödenmesi gereken "
                                +"ceza yok.",
                                "",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                            if(result==DialogResult.Yes)
                            {
                                // Trigger kullanılmasının sebebi iptal etmede işlemindede silinmektedir.
                                // Bu yüzden okunan_sayi değeri okunup arttırılacak.

                                // Emanetler tablosundan silinecek.
                                query = "DELETE FROM emanet WHERE barkod_no=" + emanet_dataGrid.CurrentRow.Cells["Barkod No"].Value.ToString()
                                    + " AND ogr_no = " + emanet_dataGrid.CurrentRow.Cells["Öğrenci No"].Value.ToString();
                                command = new SQLiteCommand(query,connection);
                                command.ExecuteNonQuery();

                                // Okunanlar tablosuna eklenecek.
                                DateTime teslim_tarih = Convert.ToDateTime(emanet_dataGrid.CurrentRow.Cells["Teslim Edilen Tarih"].Value.ToString());
                                DateTime bitis_tarih= Convert.ToDateTime(emanet_dataGrid.CurrentRow.Cells["Son Tarih"].Value.ToString());
                                query = "INSERT INTO okunanlar(ogr_no,ad_soyad,barkod_no,kitap_adi,teslim_tar,bitis_tar,alinan_tar) VALUES"
                                    +"(@ogr_no,@ad_soyad,@barkod_no,@kitap_adi,@teslim_tar,@bitis_tar,@alinan_tar)";
                                command = new SQLiteCommand(query,connection);
                                command.Parameters.AddWithValue("@ogr_no",emanet_dataGrid.CurrentRow.Cells["Öğrenci No"].Value.ToString());
                                command.Parameters.AddWithValue("@ad_soyad", emanet_dataGrid.CurrentRow.Cells["Ad Soyad"].Value.ToString());
                                command.Parameters.AddWithValue("@barkod_no",emanet_dataGrid.CurrentRow.Cells["Barkod No"].Value.ToString());
                                command.Parameters.AddWithValue("@kitap_adi",emanet_dataGrid.CurrentRow.Cells["Kitap"].Value.ToString());
                                command.Parameters.AddWithValue("@teslim_tar",teslim_tarih.ToString("yyyy-MM-dd"));
                                command.Parameters.AddWithValue("@bitis_tar",bitis_tarih.ToString("yyyy-MM-dd"));
                                command.Parameters.AddWithValue("@alinan_tar", DateTime.Now.ToString("yyyy-MM-dd"));
                                command.ExecuteNonQuery();

                                // okuma_sayisi arttırılacak
                                query = "SELECT toplam_okuma FROM ogrenciler WHERE ogr_no=" + emanet_dataGrid.CurrentRow.Cells["Öğrenci No"].Value.ToString();
                                command = new SQLiteCommand(query,connection);
                                int okuma_sayisi = Convert.ToInt32(command.ExecuteScalar());
                                query = "UPDATE ogrenciler SET toplam_okuma = " + Convert.ToString(++okuma_sayisi) + " WHERE ogr_no=" + emanet_dataGrid.CurrentRow.Cells["Öğrenci No"].Value.ToString();
                                command = new SQLiteCommand(query,connection);
                                command.ExecuteNonQuery();
                                MessageBox.Show("İşlem tamamlandı.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                listele(emanet_dataGrid);
                            }
                        }
                        else//son tarih geçtikten sonra
                        {
                            int odenecek_ceza = sonuc * 1;
                            DialogResult result = MessageBox.Show("Seçili işlem onaylanacaktır. Kabul ediyor musunuz?\n\n Ödenmesi gereken "
                                + "ceza : " + Math.Abs(odenecek_ceza) + " TL",
                                "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                query = "DELETE FROM emanet WHERE barkod_no=" + emanet_dataGrid.CurrentRow.Cells[0].Value.ToString()
                                    + " AND ogr_no = " + emanet_dataGrid.CurrentRow.Cells[2].Value.ToString();
                                command = new SQLiteCommand(query, connection);
                                command.ExecuteNonQuery();

                                //ceza arttırılıyor.
                                query = "SELECT ceza, odedigi_ceza FROM ogrenciler WHERE ogr_no="+emanet_dataGrid.CurrentRow.Cells["Öğrenci No"].Value.ToString();
                                command = new SQLiteCommand(query,connection);
                                reader = command.ExecuteReader();
                                reader.Read();
                                int ceza = Convert.ToInt16(reader["ceza"].ToString());
                                int toplam_okuma = Convert.ToInt16(reader["toplam_okuma"].ToString());
                                int odedigi_ceza = Convert.ToInt16(reader["odedigi_ceza"].ToString());
                                query = "UPDATE ogrenciler SET ceza=" + (++ceza) + ", odedigi_ceza = " + (odedigi_ceza + Math.Abs(odenecek_ceza)) +
                                    ", toplam_okuma=" + (++toplam_okuma) + " WHERE ogr_no=" + emanet_dataGrid.CurrentRow.Cells["Öğrenci No"].Value.ToString();
                                command = new SQLiteCommand(query, connection);
                                command.ExecuteNonQuery();
                                MessageBox.Show("İşlem tamamlandı.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reader.Close();
                                listele(emanet_dataGrid);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Teslim alınacak kitap yok", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception exm)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + exm.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed) { connection.Close(); }
            }
        }

        private void emanet_dataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && emanet_dataGrid.Rows.Count >= 1)
            {
                TimeSpan tms = DateTime.Now - Convert.ToDateTime(emanet_dataGrid.Rows[e.RowIndex].Cells["Son Tarih"].Value);
                int kalan_gun = tms.Days;
                foreach(DataGridViewCell hucreler in emanet_dataGrid.Rows[e.RowIndex].Cells)
                {
                    if (emanet_dataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor == ColorTranslator.FromHtml("#D93600")) 
                    { hucreler.ToolTipText = "Üye, kitabı " + kalan_gun + " gündür teslim etmiyor."; }
                    else
                    {
                        if(kalan_gun == 0 )
                        {
                            hucreler.ToolTipText = "Üyenin kitabı teslim etmesi için son gün.";
                        }
                        else if(kalan_gun < 0)
                        {
                            hucreler.ToolTipText = "Üyenin kitabı teslim etmesine " + Math.Abs(kalan_gun) + " gün kaldı.";
                        }
                    }
                }
            }
        }

        private void kitap_arama_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT barkod_no AS [Barkod No], kitap_adi AS [Kitap], ogr_no AS [Öğrenci No], ad_soyad AS [Ad Soyad], teslim_tar AS [Teslim Tarihi], "
                + "son_tarih AS [Son Tarih] FROM emanet WHERE " + kitap_kriter +" LIKE '%" + kitap_arama.Text + "%' AND " + ogr_kriter + " LIKE '%"
                + ogr_arama.Text + "%'";
            data_adapt = new SQLiteDataAdapter(query, connection);
            dt_set = new DataSet();
            data_adapt.Fill(dt_set, "emanet");
            emanet_dataGrid.DataSource = dt_set.Tables["emanet"];
            say(emanet_dataGrid);
        }
        string kitap_kriter, ogr_kriter;
        private void kitap_arama_kriter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(kitap_arama_kriter.SelectedIndex)
            {
                case 0:
                    kitap_kriter = "barkod_no";
                    break;
                case 1:
                    kitap_kriter = "kitap_adi";
                    break;
            }
            kitap_arama.Clear();
        }

        private void ogr_arama_kriter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ogr_arama_kriter.SelectedIndex)
            {
                case 0:
                    ogr_kriter = "ogr_no";
                    break;
                case 1:
                    ogr_kriter = "ad_soyad";
                    break;
            }
            ogr_arama.Clear();
        }

        private void kitap_arama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (kitap_arama_kriter.SelectedIndex == 0)
            {
                kitap_arama.MaxLength = 13;
                if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                    
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Barkod numarası için rakam girmelisiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                kitap_arama.MaxLength = 30;
                if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void ogr_arama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(ogr_arama_kriter.SelectedIndex==0)
            {
                ogr_arama.MaxLength = 12;
                if(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Öğrenci numarası için rakam girmelisiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ogr_arama.MaxLength = 20;
                if(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void ogr_arama_TextChanged(object sender, EventArgs e)
        {
            this.ogr_arama.TextChanged += new System.EventHandler(kitap_arama_TextChanged);
        }
        private void emanet_arama_sifirla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formu_temizle(emanet_arama_paneli);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result==DialogResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void uyeler_dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (uyeler_dataGrid.SelectedRows.Count >= 1 && uyeler_dataGrid.Rows.Count >= 1)
                verileri_yukle(uyeler_dataGrid.CurrentRow.Cells["Öğrenci No"].Value.ToString(), uyeler_dataGrid);
            else
            {
                uye_okunan_kitap_p.Visible = false;
                uyedeki_kitap_panel.Visible = false;
                uye_detaylari.Visible = false;
                formu_varsayilana_getir(uye_paneli);
            }
                
        }
        uye_okunan uye_okunan_v=null;
        private void uye_okunan_kitap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uyeler_dataGrid.SelectedRows.Count >= 1)
            {
                if(uye_okunan_v == null)
                {
                    uye_okunan_v = new uye_okunan();
                }
                uye_okunan_v.ogr_no = ogr_no_data.Text;
                uye_okunan_v.ad_soyad = ad_soyad_data.Text;
                uye_okunan_v.ShowDialog();

                this.uye_okunan_v.Dispose();
                GC.SuppressFinalize(this.uye_okunan_v);
                uye_okunan_v = null;
            }
        }

        uyedeki_kitaplar uyedeki_kitaplar_v;
        private void uyedeki_kitap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uyeler_dataGrid.SelectedRows.Count >= 1)
            {
                if (uyedeki_kitaplar_v == null)
                {
                    uyedeki_kitaplar_v = new uyedeki_kitaplar();
                }
                uyedeki_kitaplar_v.ogr_no = ogr_no_data.Text;
                uyedeki_kitaplar_v.ad_soyad = ad_soyad_data.Text;
                form_verisi = uyedeki_kitaplar_v.Name;
                uyedeki_kitaplar_v.ShowDialog();

                uyedeki_kitaplar_v.Dispose();
                GC.SuppressFinalize(this.uyedeki_kitaplar_v);
                uyedeki_kitaplar_v = null;
            }
        }
        uye_detaylari uye_detaylari_v=null;
        private void uye_detaylari_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(uye_detaylari_v==null)
            {
                uye_detaylari_v = new uye_detaylari();
            }
            uye_detaylari_v.ogr_no = ogr_no_data.Text;
            uye_detaylari_v.ShowDialog();

            uye_detaylari_v.Dispose();
            GC.SuppressFinalize(uye_detaylari_v);
            uye_detaylari_v = null;
        }
    }
}
        #endregion 