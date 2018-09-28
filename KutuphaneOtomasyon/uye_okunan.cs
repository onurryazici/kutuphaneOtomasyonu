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
    public partial class uye_okunan : Form
    {
        public uye_okunan()
        {
            InitializeComponent();
        }
        SQLiteConnection connection = new SQLiteConnection("Data Source=" + Application.CommonAppDataPath + "\\database.db; Read Only=false;");
        SQLiteDataAdapter data_adapt;
        DataSet dt_set;

        string query;
        public string ogr_no, ad_soyad;
        private void say()
        {
            if (uye_okunan_dataGrid.Rows.Count >= 1)
                okuma_statusu.Text = ad_soyad + " toplam " + uye_okunan_dataGrid.Rows.Count.ToString() + " kitap okudu.";
            else
                okuma_statusu.Text = "Okunan kitap yok.";
        }
        private void uye_okunan_Load(object sender, EventArgs e)
        {
            this.Text = ad_soyad + " üyesinin okuduğu kitaplar";
            query = "SELECT ad_soyad AS [Alıcı], barkod_no AS [Barkod No], kitap_adi AS [Kitap], teslim_tar AS [Teslim Edilen Tarih], "
                + " bitis_tar AS [Son Tarih] FROM okunanlar WHERE ogr_no=" + ogr_no;
            data_adapt = new SQLiteDataAdapter(query,connection);
            dt_set = new DataSet();
            data_adapt.Fill(dt_set, "okunanlar");
            uye_okunan_dataGrid.DataSource = dt_set.Tables["okunanlar"];
            say();
            if (uye_okunan_dataGrid.Rows.Count == 0)
            {
                MessageBox.Show("Bu üyenin okuduğu kitap yok.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void uye_okunan_dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int index = 0;
            foreach (DataGridViewRow satir in uye_okunan_dataGrid.Rows)
            {
                if (index % 2 == 0)
                { satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D3DDF6"); }
                else
                { satir.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E5E4F2"); }
                index++;
            }
        }
    }
}