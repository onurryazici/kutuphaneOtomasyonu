using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite; //
using System.Globalization; //
namespace KutuphaneOtomasyon
{
    public partial class kitap_ekle : Form
    {
        public kitap_ekle()
        {
            InitializeComponent();
        }
        islemler isl_obj = new islemler();
        SQLiteConnection connection = new SQLiteConnection("Data Source = " + Application.CommonAppDataPath + "\\database.db; Read Only = false;");
        SQLiteCommand command;
        SQLiteDataReader reader;
        string query;
        string form_verisi;
        #region metotlar
        private bool form_kontrolu()
        {
            bool deger=true;

            foreach(Control ctrl in Controls)
            {
                if (ctrl is TextBox)
                {
                    if(ctrl.Text.Trim(' ') == string.Empty)
                    {
                        deger = false;
                    }
                }
            }
            return deger;
        }
        private void yenile()
        {
            try
            {
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                dolap.Items.Clear();
                tur.Items.Clear();

                query = "SELECT tur_adi FROM kitap_turleri";
                command = new SQLiteCommand(query, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tur.Items.Add(reader[0].ToString());
                }
                reader.Close();
                query = "SELECT dolap_adi FROM dolaplar";
                command = new SQLiteCommand(query,connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dolap.Items.Add(reader[0].ToString());
                }
                reader.Close();
            }
            catch(Exception exm)
            {
                MessageBox.Show("Üzgünüz bir sorunla karşılaştık.\n\n" + exm.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed) { connection.Close(); }
            }
        }
        private void formu_temizle()
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is TextBox) { (ctrl as TextBox).Clear(); }
                else if (ctrl is TextBox) { (ctrl as MaskedTextBox).Clear(); }
                else if (ctrl is ComboBox) { (ctrl as ComboBox).SelectedItem = string.Empty; }
                else if (ctrl is NumericUpDown) { (ctrl as NumericUpDown).Value = 0; }
            }
        }
#endregion
        private void kitap_ekle_btn_Click(object sender, EventArgs e)
        {
            
            if (tur.Items.Count == 0 || dolap.Items.Count == 0)
            {
                MessageBox.Show("Galiba eklenmiş dolap veya kitap türü yok. Yapılandırmadan yeni bir dolap veya kitap türü ekleyiniz.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (barkod_no.TextLength == 13 && form_kontrolu() && tur.Text != string.Empty && sayfa.Value != 0 && adet.Value !=0)
                {
                    isl_obj.kitap_ekle(barkod_no.Text, ad.Text, yazar.Text, yayinevi.Text, tur.Text, sayfa.Value.ToString(), adet.Value.ToString(), dolap.Text);
                    form_verisi = "yapilandirma";
                }
                else
                {
                    MessageBox.Show("Gerekli alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kitap_ekle_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void yazar_Leave(object sender, EventArgs e)
        {
            yazar.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(yazar.Text);
        }

        private void ad_Leave(object sender, EventArgs e)
        {
            ad.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ad.Text);
        }

        private void yayinevi_Leave(object sender, EventArgs e)
        {
            yayinevi.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(yayinevi.Text);
        }
        private void kitap_ekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void barkod_no_KeyPress(object sender, KeyPressEventArgs e)
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

        private void yeni_tur_ekle_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(yeni_tur_ekle, "Yeni tür ekleyin");
        }
        private void yeni_dolap_ekle_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(yeni_dolap_ekle, "Yeni dolap ekleyin");
        }
        
        private void yeni_tur_ekle_Click(object sender, EventArgs e)
        {
            form_verisi = "yapilandirma";
            yapilandirma yapilandirma_v = null;
            if (yapilandirma_v == null)
            {
                yapilandirma_v = new yapilandirma();
            }
            yapilandirma_v.tabControl.SelectedIndex = 0;
            yapilandirma_v.ShowDialog();

            yapilandirma_v.Dispose();
            GC.SuppressFinalize(yapilandirma_v);
            yapilandirma_v = null;
        }

        private void yeni_dolap_ekle_Click(object sender, EventArgs e)
        {
            form_verisi = "yapilandirma";
            yapilandirma yapilandirma_v = null;
            if (yapilandirma_v == null)
            {
                yapilandirma_v = new yapilandirma();
            }
            yapilandirma_v.tabControl.SelectedIndex = 2;
            yapilandirma_v.ShowDialog();

            yapilandirma_v.Dispose();
            GC.SuppressFinalize(yapilandirma_v);
            yapilandirma_v = null;
        }

        private void kitap_ekle_Activated(object sender, EventArgs e)
        {
            if (form_verisi == "yapilandirma")
            { 
                yenile(); 
            }
            form_verisi = null;
        }

        private void kitap_temizle_btn_Click(object sender, EventArgs e)
        {
            formu_temizle();
        }
    }
}
