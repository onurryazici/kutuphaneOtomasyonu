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
    public partial class uyedeki_kitaplar : Form
    {
        public uyedeki_kitaplar()
        {
            InitializeComponent();
        }
        SQLiteConnection connection = new SQLiteConnection("Data Source = " + Application.CommonAppDataPath + "\\database.db; Read Only=false;");
        SQLiteDataAdapter data_adapt;
        SQLiteCommand command;
        SQLiteDataReader reader;
        DataSet dt_set;
        string query;
        public string ogr_no, ad_soyad;


        #region özel metotlar(listeleme, kitap alma)

        private void say()
        {
            if (uye_dataGrid.Rows.Count >= 1)
            {
                statu.Text = ad_soyad + " üyesinde toplam " + uye_dataGrid.Rows.Count.ToString() + " kitap bulunmakta.";
            }
            else
            {
                statu.Text = "Listelenecek öğe yok.";
            }
        }
        private void listele()
        {
            query = "SELECT barkod_no AS [Barkod No], kitap_adi AS [Aldığı Kitap], teslim_tarih AS [Teslim Edilen Tarih], "
                + "son_tarih AS [Son Tarih] FROM emanet WHERE ogr_no=" + ogr_no;
            data_adapt = new SQLiteDataAdapter(query, connection);
            dt_set = new DataSet();
            data_adapt.Fill(dt_set, "emanet");
            uye_dataGrid.DataSource = dt_set.Tables["emanet"];
            say();
        }
        private void kitabi_al()
        {
            if (connection.State != ConnectionState.Open) { connection.Open(); }
            query = "SELECT son_tarih FROM emanet WHERE barkod_no = " + uye_dataGrid.CurrentRow.Cells["Barkod No"].Value.ToString() +
                            " AND ogr_no = " + ogr_no;
            command = new SQLiteCommand(query, connection);
            DateTime son_tarih = Convert.ToDateTime(command.ExecuteScalar());
            TimeSpan tms = son_tarih - DateTime.Now;
            int sonuc = tms.Days;
            if(sonuc >= 0)
            {
                DialogResult result = MessageBox.Show("Seçili işlem onaylanacaktır. Kabul ediyor musunuz?\n\n Ödenmesi gereken "
                                + "ceza yok.",
                                "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    query = "DELETE FROM emanet WHERE barkod_no=" + uye_dataGrid.CurrentRow.Cells["Barkod No"].Value.ToString()
                        + " AND ogr_no = " + ogr_no;
                    command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();

                    // Okunanlar tablosuna eklenecek.
                    DateTime teslim_tarih = Convert.ToDateTime(uye_dataGrid.CurrentRow.Cells["Teslim Edilen Tarih"].Value.ToString());
                    DateTime bitis_tarih = Convert.ToDateTime(uye_dataGrid.CurrentRow.Cells["Son Tarih"].Value.ToString());
                    query = "INSERT INTO okunanlar(ogr_no,ad_soyad,barkod_no,kitap_adi,teslim_tar,bitis_tar,alinan_tar) VALUES"
                        + "(@ogr_no,@ad_soyad,@barkod_no,@kitap_adi,@teslim_tar,@bitis_tar,@alinan_tar)";
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@ogr_no", ogr_no);
                    command.Parameters.AddWithValue("@ad_soyad", ad_soyad);
                    command.Parameters.AddWithValue("@barkod_no", uye_dataGrid.CurrentRow.Cells["Barkod No"].Value.ToString());
                    command.Parameters.AddWithValue("@kitap_adi", uye_dataGrid.CurrentRow.Cells["Aldığı Kitap"].Value.ToString());
                    command.Parameters.AddWithValue("@teslim_tar", teslim_tarih.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@bitis_tar", bitis_tarih.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@alinan_tar", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();

                    // okuma_sayisi arttırılacak
                    query = "SELECT toplam_okuma FROM ogrenciler WHERE ogr_no=" + ogr_no;
                    command = new SQLiteCommand(query, connection);
                    int okuma_sayisi = Convert.ToInt32(command.ExecuteScalar());
                    query = "UPDATE ogrenciler SET toplam_okuma = " + (++okuma_sayisi) + " WHERE ogr_no=" + ogr_no;
                    command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("İşlem tamamlandı.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                int odenecek_ceza = sonuc * 1;
                DialogResult result = MessageBox.Show("Seçili işlem onaylanacaktır. Kabul ediyor musunuz?\n\n Ödenmesi gereken "
                    + "ceza : " + Math.Abs(odenecek_ceza) + " TL",
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    query = "DELETE FROM emanet WHERE barkod_no=" + uye_dataGrid.CurrentRow.Cells["Barkod No"].Value.ToString()
                        + " AND ogr_no = " + ogr_no;
                    command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();

                    //ceza arttırılıyor.
                    query = "SELECT ceza, odedigi_ceza,toplam_okuma FROM ogrenciler WHERE ogr_no=" + ogr_no;
                    command = new SQLiteCommand(query, connection);
                    reader = command.ExecuteReader();
                    reader.Read();
                    int ceza = Convert.ToInt16(reader["ceza"].ToString());
                    int odedigi_ceza = Convert.ToInt32(reader["odedigi_ceza"].ToString());
                    int toplam_okuma = Convert.ToInt16(reader["toplam_okuma"].ToString());
                    query = "UPDATE ogrenciler SET ceza=" + (++ceza) + ", odedigi_ceza = " + (odedigi_ceza + Math.Abs(odenecek_ceza)) +
                        ", toplam_okuma=" + (++toplam_okuma) + " WHERE ogr_no=" + ogr_no;
                    command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();
                    reader.Close();
                    MessageBox.Show("İşlem tamamlandı.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            listele();
            if (connection.State != ConnectionState.Closed) { connection.Close(); }
        }
        
        
        
        #endregion
        private void uyedeki_kitaplar_Load(object sender, EventArgs e)
        {
            this.Text = ad_soyad + " üyesinde bulunan kitaplar";
            listele();
            if (uye_dataGrid.Rows.Count < 1)
            {
                this.Close();
                MessageBox.Show("Bu üyede şu anda kitap bulunmamaktadır.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void uye_dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (uye_dataGrid.SelectedRows.Count >= 1)
                kitap_al.Visible = true;
            else
                kitap_al.Visible = false;
        }

        private void kitap_al_Click(object sender, EventArgs e)
        {
            kitabi_al();
        }

        private void uye_dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach(DataGridViewRow satir in uye_dataGrid.Rows)
            {
                DateTime son_tarih = Convert.ToDateTime(satir.Cells["Son Tarih"].Value.ToString());
                TimeSpan tms = son_tarih - DateTime.Now;
                int sonuc = tms.Days;
                if (sonuc < 0)
                {
                    satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D93600");
                    satir.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#D93600");
                }
            }
        }

        private void uye_dataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && uye_dataGrid.Rows.Count >= 1)
            {
                TimeSpan tms = DateTime.Now - Convert.ToDateTime(uye_dataGrid.Rows[e.RowIndex].Cells["Son Tarih"].Value);
                int kalan_gun = tms.Days;
                foreach (DataGridViewCell hucreler in uye_dataGrid.Rows[e.RowIndex].Cells)
                {
                    if (uye_dataGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor == ColorTranslator.FromHtml("#D93600"))
                    { hucreler.ToolTipText = "Üye, kitabı " + kalan_gun + " gündür teslim etmiyor."; }
                    else
                    {
                        if (kalan_gun == 0)
                        {
                            hucreler.ToolTipText = "Üyenin kitabı teslim etmesi için son gün.";
                        }
                        else if (kalan_gun < 0)
                        {
                            hucreler.ToolTipText = "Üyenin kitabı teslim etmesine " + Math.Abs(kalan_gun) + " gün kaldı.";
                        }
                    }
                }
            }
        }
    }
}
