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
    public partial class kurulum : Form
    {
        public kurulum()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Eğer veritabanı yoksa oluşturulacaktır.
        /// </summary>
        private void kurulum_Load(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = true;
                SQLiteConnection.CreateFile(Application.CommonAppDataPath+"\\database.db");
                SQLiteConnection connection = new SQLiteConnection("Data Source = " + Application.CommonAppDataPath + "\\database.db; Read Only=false;");
                connection.Open();
                SQLiteCommand command;
                string query = "CREATE TABLE ogrenciler (ogr_no INTEGER (12) PRIMARY KEY, ad_soyad VARCHAR (30), ogr_bolum VARCHAR (20), cinsiyet VARCHAR (5), sinif INTEGER, telefon VARCHAR (15), toplam_okuma INTEGER, ogr_resim BLOB, ceza INTEGER, odedigi_ceza INTEGER); "
                    + "CREATE TABLE kitaplar (barkod_no CHAR (13) PRIMARY KEY, ad VARCHAR (35), yazar VARCHAR (30), yayinevi VARCHAR (20), tur VARCHAR (15), sayfa_sayisi INTEGER, adet INTEGER, dolap_adi VARCHAR (20)); "
                    + "CREATE TABLE kitap_turleri (tur_id INTEGER PRIMARY KEY AUTOINCREMENT, tur_adi VARCHAR (25)); "
                    + "CREATE TABLE bolumler (bolum_id INTEGER PRIMARY KEY AUTOINCREMENT, bolum_adi VARCHAR (25)); "
                    + "CREATE TABLE dolaplar (dolap_id INTEGER PRIMARY KEY AUTOINCREMENT, dolap_adi VARCHAR (20)); "
                    + "CREATE TABLE emanet (emanet_id INTEGER PRIMARY KEY AUTOINCREMENT, barkod_no INTEGER REFERENCES kitaplar (barkod_no), kitap_adi VARCHAR (25), ogr_no INTEGER REFERENCES ogrenciler (ogr_no), ad_soyad VARCHAR (35), teslim_tarih DATE, son_tarih DATE); "
                    + "CREATE TABLE okunanlar (id INTEGER PRIMARY KEY AUTOINCREMENT, ogr_no INTEGER (12) REFERENCES ogrenciler (ogr_no), ad_soyad VARCHAR (30), barkod_no CHAR (13) REFERENCES kitaplar (barkod_no), kitap_adi VARCHAR (35), teslim_tar DATE, bitis_tar DATE, alinan_tar DATE); ";
                command = new SQLiteCommand(query,connection);
                command.ExecuteNonQuery();
                timer.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Üzgünüz veritabanı oluşturulamıyor.\n\n" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.timer.Stop();
            MessageBox.Show("Kurulum Tamamlandı!\nYapılandırmalar menüsünden kitap türlerini, öğrenci bölümlerini ve dolapları eklemeyi unutmayın."
            + "Aksi halde bir işlem yapamazsınız.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
}
