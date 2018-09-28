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
using System.IO; //
using Microsoft.VisualBasic;//
using System.Globalization; //
namespace KutuphaneOtomasyon
{
    public partial class yapilandirma : Form
    {
        public yapilandirma()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Yapılandırma işlemleri (içe aktarım,dışa aktarım, tablo yapılandırması)
        /// </summary>
        SQLiteConnection connection = new SQLiteConnection("Data Source = " + Application.CommonAppDataPath + "\\database.db; Read Only=false;");
        SQLiteDataAdapter data_adapt;
        DataSet dt_set;
        SQLiteCommand command;
        string query;
        yapilandirma_islemleri yapilandirma_obj = new yapilandirma_islemleri();
        #region özel metotlar(listeleme vs)
        private void listeleme()
        {
            if (connection.State != ConnectionState.Open) { connection.Open(); }
            switch(tabControl.SelectedIndex)
            {
                case 0:
                    query = "SELECT tur_adi AS [Tür Adı] FROM kitap_turleri";
                    data_adapt = new SQLiteDataAdapter(query,connection);
                    dt_set = new DataSet();
                    data_adapt.Fill(dt_set,"kitap_turleri");
                    kitap_turleri_dataGrid.DataSource = dt_set.Tables["kitap_turleri"];
                    break;
                case 1:
                    query = "SELECT bolum_adi AS [Bölüm Adı] FROM bolumler";
                    data_adapt = new SQLiteDataAdapter(query,connection);
                    dt_set = new DataSet();
                    data_adapt.Fill(dt_set,"bolumler");
                    bolumler_dataGrid.DataSource = dt_set.Tables["bolumler"];
                    break;
                case 2:
                    query = "SELECT dolap_adi AS [Dolap] FROM dolaplar";
                    data_adapt = new SQLiteDataAdapter(query,connection);
                    dt_set = new DataSet();
                    data_adapt.Fill(dt_set,"dolaplar");
                    dolaplar_dataGrid.DataSource = dt_set.Tables["dolaplar"];
                    break;
            }
            if (connection.State != ConnectionState.Closed) { connection.Close(); }
        }
        private bool dolap_silinebilirlik()
        {
            bool deger = true;
            if (connection.State != ConnectionState.Open) { connection.Open(); }
            query = "SELECT COUNT(dolap_adi) FROM dolaplar WHERE dolap_adi='" + dolaplar_dataGrid.SelectedRows[0].Cells[0].Value.ToString() + "'";
            command = new SQLiteCommand(query,connection);
            int toplam = Convert.ToInt32(command.ExecuteScalar());
            if(toplam > 0)
            {
                deger = false;
            }
            if (connection.State != ConnectionState.Closed) { connection.Close(); }
            return deger;
        }
        #endregion
        private void yapilandirma_Load(object sender, EventArgs e)
        {
            listeleme();
        }
        
        private void tur_ekle_btn_Click(object sender, EventArgs e)
        {
            yapilandirma_obj.tur_ekle();
            listeleme();
        }
        private void tur_sil_btn_Click(object sender, EventArgs e)
        {
            if (connection.State != ConnectionState.Open) { connection.Open(); }
            if(kitap_turleri_dataGrid.Rows.Count >= 1)
            {
                if(kitap_turleri_dataGrid.SelectedRows.Count > 1)
                {
                    DialogResult result = MessageBox.Show("Seçili " + kitap_turleri_dataGrid.SelectedRows.Count.ToString() + " kitap türünü"
                        + " silmek istediğinize emin misiniz?","",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = 0; i < kitap_turleri_dataGrid.SelectedRows.Count; i++)
                        {
                            query = "DELETE FROM kitap_turleri WHERE tur_adi=@tur";
                            command = new SQLiteCommand(query, connection);
                            command.Parameters.AddWithValue("@tur", kitap_turleri_dataGrid.SelectedRows[i].Cells[0].Value.ToString());
                            command.ExecuteScalar();
                        }
                    }
                }
                else if(kitap_turleri_dataGrid.SelectedRows.Count == 1)
                {
                    DialogResult result = MessageBox.Show(kitap_turleri_dataGrid.CurrentRow.Cells["Tür Adı"].Value.ToString() + " türünü silmek istediğinize emin misiniz ?",
                        "", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if(result==DialogResult.Yes)
                    {
                        query = "DELETE FROM kitap_turleri WHERE tur_adi=@tur";
                        command = new SQLiteCommand(query, connection);
                        command.Parameters.AddWithValue("@tur",kitap_turleri_dataGrid.CurrentRow.Cells["Tür Adı"].Value.ToString());
                        command.ExecuteScalar();
                    }
                }
                listeleme();
            }
            else
            {
                MessageBox.Show("Silinecek tür yok", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (connection.State != ConnectionState.Closed) { connection.Close(); }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void bolum_ekle_btn_Click(object sender, EventArgs e)
        {
            yapilandirma_obj.bolum_ekle();
            listeleme();
        }

        private void bolum_sil_btn_Click(object sender, EventArgs e)
        {
            if (connection.State != ConnectionState.Open) { connection.Open(); }
            if (bolumler_dataGrid.Rows.Count >= 1)
            {
                if (bolumler_dataGrid.SelectedRows.Count > 1)
                {
                    DialogResult result = MessageBox.Show("Seçili " + bolumler_dataGrid.SelectedRows.Count.ToString() + " bölümü"
                        + " silmek istediğinize emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = 0; i < bolumler_dataGrid.SelectedRows.Count; i++)
                        {
                            query = "DELETE FROM bolumler WHERE bolum_adi=@bolum";
                            command = new SQLiteCommand(query, connection);
                            command.Parameters.AddWithValue("@bolum", bolumler_dataGrid.SelectedRows[i].Cells[0].Value.ToString());
                            command.ExecuteScalar();
                        }
                    }
                }
                else if (bolumler_dataGrid.SelectedRows.Count == 1)
                {
                    DialogResult result = MessageBox.Show(bolumler_dataGrid.CurrentRow.Cells["Bölüm Adı"].Value.ToString() + " bölümünü silmek istediğinize emin misiniz ?",
                        "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        query = "DELETE FROM bolumler WHERE bolum_adi=@bolum";
                        command = new SQLiteCommand(query, connection);
                        command.Parameters.AddWithValue("@bolum", bolumler_dataGrid.CurrentRow.Cells["Bölüm Adı"].Value.ToString());
                        command.ExecuteScalar();
                    }
                }
                listeleme();
            }
            else
            {
                MessageBox.Show("Silinecek bölüm yok", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (connection.State != ConnectionState.Closed) { connection.Close(); }
        }

        private void dolap_ekle_btn_Click(object sender, EventArgs e)
        {
            yapilandirma_obj.dolap_ekle();
            listeleme();
        }

        private void dolap_sil_btn_Click(object sender, EventArgs e)
        {
            if (connection.State != ConnectionState.Open) { connection.Open(); }
            if (dolaplar_dataGrid.Rows.Count >= 1)
            {
                if (dolaplar_dataGrid.SelectedRows.Count > 1)
                {
                    if(dolap_silinebilirlik())
                    {
                        DialogResult result = MessageBox.Show("Seçili " + bolumler_dataGrid.SelectedRows.Count.ToString() + " dolabı"
                                                + " silmek istediğinize emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            for (int i = 0; i < dolaplar_dataGrid.SelectedRows.Count; i++)
                            {
                                query = "DELETE FROM bolumler WHERE bolum_adi=@bolum";
                                command = new SQLiteCommand(query, connection);
                                command.Parameters.AddWithValue("@bolum", dolaplar_dataGrid.SelectedRows[i].Cells[0].Value.ToString());
                                command.ExecuteScalar();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu dolaplardan birinde bazı kitaplar mevcut. Kitapların yeri değiştirilmeden bu dolaplar silinemez.",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dolaplar_dataGrid.SelectedRows.Count == 1)
                {
                    if(dolap_silinebilirlik())
                    {
                        DialogResult result = MessageBox.Show(dolaplar_dataGrid.CurrentRow.Cells["Dolap"].Value.ToString() + " adlı dolabı silmek istediğinize emin misiniz ?",
                        "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            query = "DELETE FROM dolaplar WHERE dolap_adi=@dolap";
                            command = new SQLiteCommand(query, connection);
                            command.Parameters.AddWithValue("@dolap", dolaplar_dataGrid.CurrentRow.Cells["Dolap"].Value.ToString());
                            command.ExecuteScalar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu dolapta bazı kitaplar mevcut. Kitapların yeri değiştirilmeden bu dolap silinemez.",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                listeleme();
            }
            else
            {
                MessageBox.Show("Silinecek bölüm yok", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (connection.State != ConnectionState.Closed) { connection.Close(); }
        }

        private void yedekleme_btn_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Dışa aktaracağınız yeri seçin";
            saveFileDialog.Filter = "Veritabanı | *.db";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.FileName = "database.db";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Application.CommonAppDataPath + "\\database.db", saveFileDialog.FileName, true);
            }
        }
        private void geri_yukle_btn_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Veritabanını seçin";
            openFileDialog.Filter = "Veritabanı | *.db";
            openFileDialog.FilterIndex = 2;
            openFileDialog.FileName = string.Empty;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.SafeFileName != "database.db")
                {
                    MessageBox.Show("Veritabanı dosyasının adını 'database' olarak değiştirin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(openFileDialog.SafeFileName, Application.CommonAppDataPath + "\\database.db", true);
                }
            }
        }

        private void yapilandirma_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Değişiklikler için yeniden başlatın.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
