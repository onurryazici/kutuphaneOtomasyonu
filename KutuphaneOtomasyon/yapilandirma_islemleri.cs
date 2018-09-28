using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;//
using Microsoft.VisualBasic; //
using System.Windows.Forms;//
using System.Globalization; //

namespace KutuphaneOtomasyon
{
    class yapilandirma_islemleri
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source = " + Application.CommonAppDataPath + "\\database.db; Read Only = false;");
        SQLiteCommand command;
        string query;
        public void tur_ekle()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                string sonuc = Interaction.InputBox("Eklemek istediğiniz türün adını yazın.", "Yeni tür", string.Empty);
                if (sonuc != string.Empty)
                {
                    sonuc = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sonuc);
                    query = "SELECT COUNT(tur_adi) FROM kitap_turleri WHERE tur_adi=@tur";
                    command = new SQLiteCommand(query,connection);
                    command.Parameters.AddWithValue("@tur",sonuc);
                    int toplam = Convert.ToInt16(command.ExecuteScalar());

                    if(toplam > 0)
                    {
                        MessageBox.Show("Bu tür zaten mevcut.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        query = "INSERT INTO kitap_turleri(tur_adi) VALUES (@tur)";
                        command = new SQLiteCommand(query, connection);
                        command.Parameters.AddWithValue("@tur", sonuc);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed) { connection.Close(); }
            }
        }
        public void bolum_ekle()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                string sonuc = Interaction.InputBox("Eklemek istediğiniz bölümün adını yazın.", "Yeni bölüm", string.Empty);
                if (sonuc != string.Empty)
                {
                    sonuc = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sonuc);
                    query = "SELECT COUNT(bolum_adi) FROM bolumler WHERE bolum_adi=@bolum";
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@bolum",sonuc);
                    int toplam = Convert.ToInt16(command.ExecuteScalar());
                    if (toplam > 0)
                    {
                        MessageBox.Show("Bu bölüm zaten mevcut.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        
                        query = "INSERT INTO bolumler(bolum_adi) VALUES (@bolum)";
                        command = new SQLiteCommand(query, connection);
                        command.Parameters.AddWithValue("@bolum", sonuc);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed) { connection.Close(); }
            }
        }
        public void dolap_ekle()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                string sonuc = Interaction.InputBox("Eklemek istediğiniz dolabın adını yazın.", "Yeni dolap", string.Empty);
                if (sonuc != string.Empty)
                {
                    sonuc = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sonuc);
                    query = "SELECT COUNT(dolap_adi) FROM dolaplar WHERE dolap_adi=@dolap";
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@dolap", sonuc);
                    int toplam = Convert.ToInt16(command.ExecuteScalar());
                    if (toplam > 0)
                    {
                        MessageBox.Show("Bu dolap zaten mevcut.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        query = "INSERT INTO dolaplar(dolap_adi) VALUES (@dolap)";
                        command = new SQLiteCommand(query, connection);
                        command.Parameters.AddWithValue("@dolap", sonuc);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üzgünüz bir hatayla karşılaştık.\n\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed) { connection.Close(); }
            }
        }
    }
}
