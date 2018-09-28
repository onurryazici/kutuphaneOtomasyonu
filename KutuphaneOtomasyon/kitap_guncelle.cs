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
    public partial class kitap_guncelle : Form
    {
        public kitap_guncelle()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Üye güncellemesi..
        /// </summary>

        SQLiteConnection connection = new SQLiteConnection("Data Source = " + Application.CommonAppDataPath + "\\database.db; Read Only=false;");
        SQLiteCommand command;
        SQLiteDataReader reader;
        string query;
        islemler isl_obj = new islemler();
        public string barkod_no_d, ad_d, yazar_d, yayinevi_d, tur_d, sayfa_d, adet_d, dolap_d;
       
        private void kitap_guncelle_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                query = "SELECT tur_adi FROM kitap_turleri";
                command = new SQLiteCommand(query, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tur.Items.Add(reader[0].ToString());
                }
                query = "SELECT dolap_adi FROM dolaplar";
                command = new SQLiteCommand(query,connection);
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    dolap.Items.Add(reader[0].ToString());
                }
                reader.Close();
                this.barkod_no.Text = barkod_no_d;
                this.ad.Text = ad_d;
                this.yazar.Text = yazar_d;
                this.yayinevi.Text = yayinevi_d;
                for (int i = 0; i < tur.Items.Count; i++)
                {
                    if (tur.Items[i].ToString() == tur_d)
                    {
                        tur.SelectedIndex = i;
                    }
                }
                this.sayfa.Value = Convert.ToInt32(sayfa_d);
                this.adet.Value = Convert.ToInt32(adet_d);
                for (int j = 0; j < dolap.Items.Count; j++)
                {
                    if (dolap.Items[j].ToString() == dolap_d)
                    {
                        dolap.SelectedIndex = j;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
        public bool formkontrol()
        {
            bool deger = true;
            foreach(Control ctrl in Controls)
            {
                
                if(ctrl is TextBox)
                {
                    if(ctrl.Text.Trim(' ') == string.Empty)
                    {
                        deger = false;
                    }
                }
                if(ctrl is ComboBox)
                {
                    if((ctrl as ComboBox).Text == string.Empty)
                    {
                        deger = false;
                    }
                }    
            }
            return deger;
        }
    
        private void guncelle_btn_Click(object sender, EventArgs e)
        {
            if(formkontrol() && barkod_no.TextLength == 13)
            {
                isl_obj.kitap_guncelle(barkod_no_d, barkod_no.Text, ad.Text, yazar.Text, yayinevi.Text, tur.Text,sayfa.Value.ToString(),
                    adet.Value.ToString(),dolap.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Alanları eksiksiz doldurunuz", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ad_Leave(object sender, EventArgs e)
        {
            this.ad.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.ad.Text);
        }

        private void yazar_Leave(object sender, EventArgs e)
        {
            this.yazar.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.yazar.Text);
        }

        private void yayinevi_Leave(object sender, EventArgs e)
        {
            this.yayinevi.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.yayinevi.Text);
        }
    }
}
