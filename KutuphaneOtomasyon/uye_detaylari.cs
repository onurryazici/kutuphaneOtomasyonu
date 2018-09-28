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
    public partial class uye_detaylari : Form
    {
        public uye_detaylari()
        {
            InitializeComponent();
        }
        public string ogr_no;
        SQLiteConnection connection = new SQLiteConnection("Data Source=" + Application.CommonAppDataPath + "\\database.db; Read Only=false;");
        SQLiteCommand command;
        SQLiteDataReader reader;
        string query;
        private void uye_detaylari_Load(object sender, EventArgs e)
        {
            try
            {
                
                int ceza = 0;
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                query = "SELECT * FROM ogrenciler WHERE ogr_no=" + ogr_no;
                command = new SQLiteCommand(query, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.Text = reader["ad_soyad"].ToString();
                    ogr_no_data.Text = reader["ogr_no"].ToString();
                    ad_soyad_data.Text = reader["ad_soyad"].ToString();
                    bolum_data.Text = reader["ogr_bolum"].ToString();
                    sinif_data.Text = reader["sinif"].ToString();
                    okunan_kitap_s.Text = reader["toplam_okuma"].ToString();
                    aldigi_ceza_s.Text = reader["ceza"].ToString();
                    odedigi_ceza_m.Text = string.Format("{0} TL", reader["odedigi_ceza"].ToString());
                }
                reader.Close();

                query = "SELECT son_tarih FROM emanet WHERE ogr_no=" + ogr_no ;
                command = new SQLiteCommand(query, connection);
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    DateTime tarih = Convert.ToDateTime(reader["son_tarih"].ToString());
                    TimeSpan tms = DateTime.Now - tarih;
                    int sonuc = tms.Days;
                    if (sonuc > 0)
                    {
                        ceza += 1 * sonuc;
                    }
                }
                if(ceza == 0)
                {
                    odeyecegi_ceza_m.Text = "Yok";
                }
                else
                {
                    odeyecegi_ceza_m.Text = string.Format("{0} TL", ceza);
                }
                reader.Close();
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
    }
}
