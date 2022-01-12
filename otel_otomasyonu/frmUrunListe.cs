using otel_otomasyonu.Kafeterya_Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otel_otomasyonu
{
    public partial class frmUrunListe : Form
    {
        public frmUrunListe()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public frmKafeterya frm;
        private void frmUrunListe_Load(object sender, EventArgs e)
        {
            new Kafeterya_Siniflar.Dinamik.TextBoxOlustur(frmKafeterya.urunler).flpAdd_TextBox();
        }
        List<urunList> urunler = new List<urunList>();
        private void button10_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i=1; i<=flpUrunler.Controls.Count/5; i++)
            {
                string urunAdi = flpUrunler.Controls.Find("name" + (j+1), true)[0].Text;
                string urunKodu = flpUrunler.Controls.Find("name" + (j+2), true)[0].Text;
                string fiyat = flpUrunler.Controls.Find("name" + (j+3), true)[0].Text;
                string tip = flpUrunler.Controls.Find("name" + (j+4), true)[0].Text;
                string tip_deger = flpUrunler.Controls.Find("name" + (j+5), true)[0].Text;
                urunler.Add(degerler(urunAdi, urunKodu, fiyat, tip, tip_deger));
                j += 5;
            }
            Kafeterya_Siniflar.Dinamik.TextBoxOlustur.urun_deger=0;
            frmKafeterya.urunler.Clear();
            frmKafeterya.urunler = urunler;
            MessageBox.Show("Yeni kayıtlarınız da hata olmadığını görmek için lütfen bir önceki log pencresine bakınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frm.tmrLog.Start();
            frm.tabControl2.TabPages["tabPage5"].Focus();
            this.Close();
        }
        urunList degerler(string urunAdi,string urunKodu,string fiyat,string tip,string tip_deger)
        {
            return new urunList(urunAdi,urunKodu,fiyat,tip,tip_deger);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
