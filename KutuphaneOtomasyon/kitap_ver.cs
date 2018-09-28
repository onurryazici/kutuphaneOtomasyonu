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
namespace KutuphaneOtomasyon
{
    public partial class kitap_ver : Form
    {
        public kitap_ver()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Kitap ver form
        /// </summary>
        SQLiteConnection connection = new SQLiteConnection("Data Source = " + Application.CommonAppDataPath + "\\database.db; Read Only=false;");
        SQLiteDataAdapter data_adapt;
        DataSet dt_set;
        SQLiteCommand command;
        string kitap_sutun, uye_sutun;// seçilen sütunlar
        string query;
        islemler isl_obj = new islemler();
        private void uye_satirlarini_ayarla()
        {
            try
            {
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                foreach(DataGridViewRow satir in uyeler_dataGrid.Rows)
                {
                    query = "SELECT COUNT(ogr_no) FROM emanet WHERE ogr_no = " + satir.Cells[0].Value.ToString();
                    command = new SQLiteCommand(query,connection);
                    int aldigi_kitap_sayisi = Convert.ToInt32(command.ExecuteScalar());
                    if(aldigi_kitap_sayisi == 3)
                    {
                        satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D93600");
                        satir.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#D93600");
                    }
                    else
                    {
                        satir.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#333333");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed) { connection.Close(); }
                command.Dispose();
            }
        }
        private void kitap_satirlarini_ayarla()
        {
            try
            {
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                foreach(DataGridViewRow satir in kitaplar_dataGrid.Rows)
                {
                    query = "SELECT adet FROM kitaplar WHERE barkod_no=" + satir.Cells[0].Value.ToString();
                    command = new SQLiteCommand(query, connection);
                    int kitap_adeti = Convert.ToInt32(command.ExecuteScalar());

                    query = "SELECT COUNT(barkod_no) FROM emanet WHERE barkod_no = " + satir.Cells[0].Value.ToString();
                    command = new SQLiteCommand(query, connection);
                    int toplam_emanet = Convert.ToInt32(command.ExecuteScalar());
                    if(kitap_adeti == toplam_emanet)
                    {
                        satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D93600");
                        satir.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#D93600");
                    }
                    else
                    {
                        satir.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#333333");
                    }
                }
            }
            catch(Exception exm)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + exm.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed) { connection.Close(); }
                command.Dispose();
            }
        }
        private void emanet_Load(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                son_tarih.MinDate = DateTime.Now;
                
                //this.Load += new System.EventHandler(son_tarih_ValueChanged);
                query = "SELECT barkod_no AS [Barkod No], ad AS [Ad], yazar AS [Yazar], yayinevi AS [Yayınevi], tur AS [Tür] FROM kitaplar";
                data_adapt = new SQLiteDataAdapter(query,connection);
                dt_set = new DataSet();
                data_adapt.Fill(dt_set, "kitaplar");
                kitaplar_dataGrid.DataSource = dt_set.Tables["kitaplar"];

                query = "SELECT ogr_no AS [Öğrenci No], ad_soyad AS [Ad Soyad], ogr_bolum [Bölüm], sinif AS [Sınıf] FROM ogrenciler";
                data_adapt = new SQLiteDataAdapter(query, connection);
                dt_set = new DataSet();
                data_adapt.Fill(dt_set, "ogrenciler");
                uyeler_dataGrid.DataSource = dt_set.Tables["ogrenciler"];

                kitap_kriter.SelectedIndex = 0;
                uye_kriter.SelectedIndex = 0;
                kitaplar_dataGrid.Rows[0].Selected = false;
                uyeler_dataGrid.Rows[0].Selected = false;

                foreach (DataGridViewColumn sutun in uyeler_dataGrid.Columns)
                {
                    sutun.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn sutun in kitaplar_dataGrid.Columns)
                {
                    sutun.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                kitap_satirlarini_ayarla();
                uye_satirlarini_ayarla();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed) { connection.Close(); }
            }
        }
        private void teslim_et_btn_Click(object sender, EventArgs e)
        {
            if(barkod_no.Text != "-" && ogr_no.Text != "-")
            {
                if(Convert.ToInt16(secilen_gun.Text) > 0)
                {
                    DialogResult result = MessageBox.Show(kitaplar_dataGrid.CurrentRow.Cells[0].Value.ToString() + " barkod numaralı "
                    + kitaplar_dataGrid.CurrentRow.Cells[1].Value.ToString() + " kitabını " + uyeler_dataGrid.CurrentRow.Cells[1].Value.ToString() +
                    " adlı üyeye " + secilen_gun.Text + " gün boyunca teslim etmek" + " istediğinize emin misiniz?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        isl_obj.kitap_ver(barkod_no.Text, kitap_adi.Text, ogr_no.Text, ad_soyad.Text, son_tarih.Value);
                        uye_satirlarini_ayarla();
                        kitap_satirlarini_ayarla();
                    }
                }
                else
                {
                    MessageBox.Show("Bir kitap minimum 1 gün boyunca teslim edilebilir", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Teslim edeceğiniz kitabı ve üyeyi seçin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void son_tarih_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan tms = son_tarih.Value - DateTime.Now;
            int gun = tms.Days;
            secilen_gun.Text = gun.ToString();
        }

        private void kitap_kriter_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(this.kitap_kriter, "Aramak istediğiniz öğeyi seçin");
        }

        private void uye_kriter_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(this.uye_kriter, "Aramak istediğiniz öğeyi seçin");
        }

        private void kitap_kriter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(kitap_kriter.SelectedIndex)
            {
                case 0:
                    kitap_sutun = "barkod_no";
                    break;
                case 1:
                    kitap_sutun = "ad";
                    break;
            }
            kitap_ara.Clear();
        }

        private void uye_kriter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(uye_kriter.SelectedIndex)
            {
                case 0:
                    uye_sutun = "ogr_no";
                    break;
                case 1:
                    uye_sutun = "ad_soyad";
                    break;
            }
            uye_ara.Clear();
        }

        private void kitap_ara_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT barkod_no AS [Barkod No], ad AS [Ad], yazar AS [Yazar], yayinevi AS [Yayınevi], tur AS [Tür] FROM kitaplar"
                + " WHERE " + kitap_sutun + " LIKE '" + this.kitap_ara.Text + "%'";
            data_adapt = new SQLiteDataAdapter(query,connection);
            dt_set = new DataSet();
            data_adapt.Fill(dt_set,"kitaplar");
            kitaplar_dataGrid.DataSource=dt_set.Tables["kitaplar"];
            kitap_satirlarini_ayarla();
        }

        private void uye_ara_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT ogr_no AS [Öğrenci No], ad_soyad AS [Ad Soyad], ogr_bolum AS [Bölüm], sinif AS [Sınıf] FROM ogrenciler"
               + " WHERE " + uye_sutun + " LIKE '" + this.uye_ara.Text + "%'";
            data_adapt = new SQLiteDataAdapter(query, connection);
            dt_set = new DataSet();
            data_adapt.Fill(dt_set, "ogrenciler");
            uyeler_dataGrid.DataSource = dt_set.Tables["ogrenciler"];
        }

        private void kitaplar_dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if(kitaplar_dataGrid.SelectedRows.Count >= 1)
            {
                barkod_no.Text = kitaplar_dataGrid.CurrentRow.Cells[0].Value.ToString();
                kitap_adi.Text = kitaplar_dataGrid.CurrentRow.Cells[1].Value.ToString();
                yazar.Text = kitaplar_dataGrid.CurrentRow.Cells[2].Value.ToString();
                yayinevi.Text = kitaplar_dataGrid.CurrentRow.Cells[3].Value.ToString();
                tur.Text = kitaplar_dataGrid.CurrentRow.Cells[4].Value.ToString();

                if (kitaplar_dataGrid.CurrentRow.DefaultCellStyle.BackColor == ColorTranslator.FromHtml("#D93600"))
                {
                    kitap_teslim_durumu.ForeColor = ColorTranslator.FromHtml("#FF0000");
                    kitap_teslim_durumu.Text = "Teslim Edilemez";
                }
                else
                {
                    kitap_teslim_durumu.ForeColor = ColorTranslator.FromHtml("#2DB200");
                    kitap_teslim_durumu.Text = "Teslim Edilebilir";
                }
            }
            else
            {
                barkod_no.Text = "-";
                kitap_adi.Text = "-";
                yazar.Text = "-";
                yayinevi.Text = "-";
                tur.Text = "-";
                kitap_teslim_durumu.Text = "-";
            }
        }

        private void uyeler_dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            
            if (uyeler_dataGrid.SelectedRows.Count >= 1)
            {
                ogr_no.Text = uyeler_dataGrid.CurrentRow.Cells[0].Value.ToString();
                ad_soyad.Text = uyeler_dataGrid.CurrentRow.Cells[1].Value.ToString();
                bolum.Text = uyeler_dataGrid.CurrentRow.Cells[2].Value.ToString();
                sinif.Text = uyeler_dataGrid.CurrentRow.Cells[3].Value.ToString();
                if (uyeler_dataGrid.CurrentRow.DefaultCellStyle.BackColor == ColorTranslator.FromHtml("#D93600"))
                {
                    ogr_alabilme_durumu.ForeColor = ColorTranslator.FromHtml("#FF0000");
                    ogr_alabilme_durumu.Text = "Alamaz";
                }
                else
                {
                    ogr_alabilme_durumu.ForeColor = ColorTranslator.FromHtml("#2DB200");
                    ogr_alabilme_durumu.Text = "Alabilir";
                }
            }
            else
            {
                ogr_no.Text = "-";
                ad_soyad.Text = "-";
                bolum.Text = "-";
                sinif.Text = "-";
                ogr_alabilme_durumu.Text = "-";
            }

        }

        private void uye_ara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (uye_sutun == "ogr_no")
            {
                uye_ara.MaxLength = 12;
                if(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                uye_ara.MaxLength = 30;
                if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void uyeler_dataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (uyeler_dataGrid.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                if (uyeler_dataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor == ColorTranslator.FromHtml("#D93600"))
                {
                    foreach (DataGridViewCell hucreler in uyeler_dataGrid.Rows[e.RowIndex].Cells)
                    {
                        hucreler.ToolTipText = "Satırın turuncu olması o üyenin maksimum kitap aldığını belirtir.";
                    }
                }
            }
        }
        private void kitap_ara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(kitap_sutun == "barkod_no")
            {
                kitap_ara.MaxLength = 13;
                if(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    toolTip.SetToolTip(kitap_ara,"asdasd");
                    e.Handled = true;
                }
            }
            else
            {
                kitap_ara.MaxLength = 35;
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
        private void kitaplar_dataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (kitaplar_dataGrid.Rows.Count >= 1 && e.RowIndex >= 0)
            {
                if (kitaplar_dataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor == ColorTranslator.FromHtml("#D93600"))
                {
                    foreach (DataGridViewCell hucreler in kitaplar_dataGrid.Rows[e.RowIndex].Cells)
                    {
                        hucreler.ToolTipText = "Satırın turuncu olması o kitabın teslim edilemeyeceğini belirtir.";
                    }
                }
            }
        }
    }
}