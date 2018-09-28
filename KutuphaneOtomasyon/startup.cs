using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //
namespace KutuphaneOtomasyon
{
    public partial class startup : Form
    {
        public startup()
        {
            InitializeComponent();
        }
        Form1 form1_v=null;
        kurulum kurulum_v = null;
        private void startup_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.CommonAppDataPath + "\\database.db") != true)
            {
                this.Hide();
                if (kurulum_v == null)
                {
                    kurulum_v = new kurulum();
                }
                kurulum_v.Show();
            }
            else
            {
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.timer.Interval == 2000)
            {
                if (form1_v == null)
                {
                    form1_v = new Form1();
                }
                this.Hide();
                form1_v.Show();
                this.timer.Stop();
            }
        }
    }
}
