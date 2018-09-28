using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;//
using System.Windows.Forms;//
using System.IO;//
using System.Drawing;
namespace KutuphaneOtomasyon
{
    class islemler
    {  
        /// <summary>
        /// Global değişkenler ve metotlar
        /// </summary>
        SQLiteConnection connection = new SQLiteConnection("Data Source="+ Application.CommonAppDataPath + "\\database.db; Read Only = false;");
        SQLiteCommand command;
        SQLiteDataReader reader;
        string query;
        #region üyeler
        public void uye_ekle(string ogr_no,string ad_soyad,string ogr_bolum, string cinsiyet, string sinif,string telefon,string resim_konumu)
        {
            try
            {
                connection.Open();
                bool mevcut_uye = false;
                query = "SELECT ogr_no FROM ogrenciler";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == ogr_no.ToString())
                    {
                        mevcut_uye = true;
                        break;
                    }
                }
                reader.Close();
                if (mevcut_uye)
                {
                    MessageBox.Show("Eklemeye çalıştığınız bu üye zaten mevcut.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    byte[] resim_oku = File.ReadAllBytes(resim_konumu);
                    query = "INSERT INTO ogrenciler(ogr_no, ad_soyad, ogr_bolum, cinsiyet, sinif, telefon, toplam_okuma, ceza, ogr_resim, odedigi_ceza) VALUES(" +
                        "@ogr_no, @ad_soyad, @ogr_bolum, @cinsiyet, @sinif, @telefon, @toplam_okuma, @ceza, @ogr_resim, @odedigi_ceza)";
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@ogr_no",ogr_no);
                    command.Parameters.AddWithValue("@ad_soyad", ad_soyad);
                    command.Parameters.AddWithValue("@ogr_bolum", ogr_bolum);
                    command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                    command.Parameters.AddWithValue("@sinif", sinif);
                    command.Parameters.AddWithValue("@telefon", telefon);
                    command.Parameters.AddWithValue("@toplam_okuma", 0);
                    command.Parameters.AddWithValue("@ceza", 0);
                    command.Parameters.AddWithValue("@odedigi_ceza", 0);
                    command.Parameters.Add("@ogr_resim", System.Data.DbType.Binary, resim_oku.Length);
                    command.Parameters["@ogr_resim"].Value = resim_oku;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Üye başarıyla eklendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exm)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + exm.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        public void uye_guncelle(string eski_ogr_no, string ogr_no,string ad_soyad, string ogr_bolum, string cinsiyet, string sinif,string telefon, string resim_konumu)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                bool mevcut_uye = false;
                if(eski_ogr_no != ogr_no)
                {
                    query = "SELECT ogr_no FROM ogrenciler";
                    command = new SQLiteCommand(query, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (ogr_no == reader[0].ToString() && eski_ogr_no != reader[0].ToString())
                        {
                            mevcut_uye = true;
                            break;
                        }
                    }
                    reader.Close();
                }
                if (mevcut_uye)
                {
                    MessageBox.Show(ogr_no + " numarasına ait üye zaten var.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    byte[] resim_oku = null;
                    
                    if(resim_konumu != string.Empty)
                    {
                        resim_oku = File.ReadAllBytes(resim_konumu);
                        query = "UPDATE ogrenciler SET ogr_no=@ogr_no, ad_soyad=@ad_soyad, ogr_bolum=@ogr_bolum, cinsiyet=@cinsiyet, sinif=@sinif,"
                        + " ogr_resim=@ogr_resim, telefon=@telefon WHERE ogr_no=" + eski_ogr_no;
                        command = new SQLiteCommand(query, connection);

                        command.Parameters.AddWithValue("@ogr_no", ogr_no);
                        command.Parameters.AddWithValue("@ad_soyad", ad_soyad);
                        command.Parameters.AddWithValue("@ogr_bolum", ogr_bolum);
                        command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                        command.Parameters.AddWithValue("@sinif", sinif);
                        command.Parameters.Add("@ogr_resim", System.Data.DbType.Binary, resim_oku.Length);
                        command.Parameters["@ogr_resim"].Value = resim_oku;
                        command.Parameters.AddWithValue("@telefon", telefon);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        query = "UPDATE ogrenciler SET ogr_no=@ogr_no, ad_soyad=@ad_soyad, ogr_bolum=@ogr_bolum, cinsiyet=@cinsiyet, sinif=@sinif,"
                        + " telefon=@telefon WHERE ogr_no=" + eski_ogr_no;
                        command = new SQLiteCommand(query, connection);
                        command.Parameters.AddWithValue("@ogr_no", ogr_no);
                        command.Parameters.AddWithValue("@ad_soyad", ad_soyad);
                        command.Parameters.AddWithValue("@ogr_bolum", ogr_bolum);
                        command.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                        command.Parameters.AddWithValue("@sinif", sinif);
                        command.Parameters.AddWithValue("@telefon", telefon);
                        command.ExecuteNonQuery();
                    }


                    MessageBox.Show("Üye başarıyla güncellendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception exm)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + exm.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }
        public bool uye_silinebilirlik_kontrol(string ogr_no)
        {
            if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
            bool kontrol = true;
            query = "SELECT COUNT(ogr_no) FROM emanet WHERE ogr_no = " + ogr_no;
            command = new SQLiteCommand(query,connection);
            int toplam = Convert.ToInt32(command.ExecuteScalar());
            if (toplam > 0) { kontrol = false; }
            if (connection.State != System.Data.ConnectionState.Closed) 
            {
                connection.Close();
            }
            return kontrol;
        }
        #endregion

        #region kitaplar
        public void kitap_ekle(string barkod, string ad, string yazar, string yayinevi, string tur,string sayfa_sayisi, string adet,string dolap_adi)
        {
            try
            {
                connection.Open();
                bool mevcut_kitap = false;
                query = "SELECT barkod_no FROM kitaplar";
                command = new SQLiteCommand(query, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString() == barkod.ToString())
                    {
                        mevcut_kitap = true;
                        break;
                    }
                }
                reader.Close();
                if (mevcut_kitap)
                {
                    MessageBox.Show(barkod + " barkod numarasına ait kitap zaten mevcut.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    query = "INSERT INTO kitaplar(barkod_no, ad, yazar, yayinevi, tur, sayfa_sayisi, adet, dolap_adi) VALUES"
                                    + "('" + barkod + "', "
                                    + "'" + ad + "', "
                                    + "'" + yazar + "', "
                                    + "'" + yayinevi + "', "
                                    + "'" + tur + "', "
                                    + sayfa_sayisi + ", "
                                    + adet + ", "
                                    + "'" + dolap_adi + "')";
                    command = new SQLiteCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kitap başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception exm)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + exm.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }
        public void kitap_guncelle(string eski_barkod, string barkod,string kitap_adi,string yazar,string yayinevi,string tur,string sayfa_sayisi,string adet,string dolap_adi)
        {
            try
            {
                bool mevcut_kitap=false;
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                if(eski_barkod != barkod)
                {
                    query = "SELECT barkod_no FROM kitaplar";
                    command = new SQLiteCommand(query, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == barkod && eski_barkod != reader[0].ToString())
                        {
                            mevcut_kitap = true;
                            break;
                        }
                    }
                    reader.Close();
                }
                query = "SELECT COUNT(barkod_no) FROM emanet WHERE barkod_no=" + eski_barkod;
                command = new SQLiteCommand(query,connection);
                int say = Convert.ToInt32(command.ExecuteScalar());
                if (Convert.ToInt32(adet) < say)
                {
                    MessageBox.Show("Bu kitabın adeti şu anda azaltılamaz. Çünkü teslim edilmiş durumda.","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else if(mevcut_kitap)
                {
                    MessageBox.Show(barkod + " barkod numarasına ait kitap zaten mevcut.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    query = "UPDATE kitaplar SET barkod_no=@barkod_no, ad=@ad, yazar=@yazar, yayinevi=@yayinevi, tur=@tur, sayfa_sayisi=@sayfa_sayisi,"
                        + "adet=@adet, dolap_adi=@dolap WHERE barkod_no=@eski_barkod";
                    command = new SQLiteCommand(query,connection);
                    command.Parameters.AddWithValue("@barkod_no",barkod);
                    command.Parameters.AddWithValue("@ad", kitap_adi);
                    command.Parameters.AddWithValue("@yazar", yazar);
                    command.Parameters.AddWithValue("@yayinevi", yayinevi);
                    command.Parameters.AddWithValue("@tur", tur);
                    command.Parameters.AddWithValue("@sayfa_sayisi", sayfa_sayisi);
                    command.Parameters.AddWithValue("@adet", adet);
                    command.Parameters.AddWithValue("@dolap", dolap_adi);
                    command.Parameters.AddWithValue("@eski_barkod", eski_barkod);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kitap başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception exm)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + exm.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
        }
        public bool kitap_silinebilirlik_kontrol(string barkod_no)
        {
            bool deger = true;
            if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
            query = "SELECT COUNT(barkod_no) FROM emanet WHERE barkod_no = " + barkod_no;
            command = new SQLiteCommand(query,connection);
            int toplam = Convert.ToInt32(command.ExecuteScalar());
            if(toplam > 0)
            {
                deger = false;
            }
            if (connection.State != System.Data.ConnectionState.Closed) { connection.Close(); }
            return deger;
        }
        #endregion
        #region kitap teslimi ve alımı
        public void kitap_ver(string barkod,string kitap_adi, string ogr_no,string ad_soyad, DateTime son_tarih)
        {
            try
            {
                bool kitap_verildimi = false; // Bir üye bir kitabı almışken tekrar alınması engellendi.
                bool max_alinan = false; // Bir üye maksimum 3 kitap alabilir.
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                query = "SELECT barkod_no, ogr_no FROM emanet";
                command = new SQLiteCommand(query,connection);
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if(reader[0].ToString() == barkod && reader[1].ToString() == ogr_no)
                    {
                        kitap_verildimi = true;
                        break;
                    }
                }
                reader.Close();
                // Öğrencinin kitap alabilme durumu.
                query = "SELECT COUNT(ogr_no) FROM emanet WHERE ogr_no=" + ogr_no;
                command = new SQLiteCommand(query,connection);
                int toplam = Convert.ToInt32(command.ExecuteScalar());
                if(toplam == 3)
                {
                    max_alinan = true;
                }
                // Kitabın meşguliyet durumu.
                query = "SELECT adet FROM kitaplar WHERE barkod_no=" + barkod;
                command = new SQLiteCommand(query, connection);
                int kitap_adeti = Convert.ToInt32(command.ExecuteScalar());

                query = "SELECT COUNT(barkod_no) FROM emanet WHERE barkod_no = " + barkod;
                command = new SQLiteCommand(query, connection);
                int emanet_edilen_sayi = Convert.ToInt32(command.ExecuteScalar());
                if(kitap_adeti==emanet_edilen_sayi)
                {
                    MessageBox.Show("Bu kitap şu anda kullanılabilir değil. Çünkü bu kitaptan " + kitap_adeti +
                        " adet bulunmaktadır ve bu kitaplar teslim edilmiştir.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(kitap_verildimi)
                {
                    MessageBox.Show("Bu kitap " + ogr_no + " numaralı öğrenciye zaten verildi.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(max_alinan)
                {
                    MessageBox.Show("Bir üye maksimum 3 kitap alabilir", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    query = "INSERT INTO emanet(barkod_no,kitap_adi,ogr_no,ad_soyad,son_tarih,teslim_tarih) VALUES("
                    + "@barkod_no,@kitap_adi,@ogr_no,@ad_soyad,@son_tarih,@teslim_tarih)";
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@barkod_no", barkod);
                    command.Parameters.AddWithValue("@kitap_adi", kitap_adi);
                    command.Parameters.AddWithValue("@ogr_no", ogr_no);
                    command.Parameters.AddWithValue("@ad_soyad", ad_soyad);
                    command.Parameters.AddWithValue("@son_tarih", son_tarih.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@teslim_tarih", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla teslim edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message);
            }
            finally
            {
                if(connection.State != System.Data.ConnectionState.Closed) { connection.Close();}
                command.Dispose();
                reader.Dispose();
            }
        }
        public void okunanlari_sil(string ogr_no,string kitap_adi)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                query = "SELECT toplam_okuma FROM ogrenciler WHERE ogr_no = " + ogr_no;
                command = new SQLiteCommand(query, connection);
                int toplam_okuma = Convert.ToInt32(command.ExecuteScalar());

                query = "UPDATE ogrenciler SET toplam_okuma=" + (toplam_okuma - 1).ToString() + " WHERE ogr_no=" + ogr_no;
                command = new SQLiteCommand(query,connection);
                command.ExecuteNonQuery();

                query = "DELETE FROM okunanlar WHERE ogr_no = " + ogr_no + " AND kitap_adi = '" + kitap_adi + "'";
                command = new SQLiteCommand(query,connection);
                command.ExecuteNonQuery();
            }
            catch(Exception exm)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + exm.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed) { connection.Close(); }
            }

        }
        #endregion
    }
}
