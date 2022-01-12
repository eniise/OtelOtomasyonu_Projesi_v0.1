using otel_otomasyonu.Kafeterya_Siniflar;
using otel_otomasyonu.Kafeterya_Siniflar.Arayuz;
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
    public partial class frmKafeteryaSiparis : Form
    {
        public frmKafeterya frm;
        public frmKafeteryaSiparis()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        List<urunList> urunler = new List<urunList>();
        private static string secilen_urun { get; set; }
        private static string secilen_urun_tip { get; set; }
        private static int secilen_urun_tip_deger { get; set; }
        private static int secilen_urun_tip_deger_ { get; set; }
        private static float ucret;
        private List<int> tip_degerleri = new List<int>();
        private List<string> urunler_listesi = new List<string>();
        private List<int> toplam_tip_degeri = new List<int>();
        private void frmKafeteryaSiparis_Load(object sender, EventArgs e)
        {
            urunler = new DB_Islemleri().Siparis_Urun_Liste();
            for(int i = 0; i<urunler.Count; i++)
            {
                cmbUrun.Items.Add(urunler[i].getUrunAdi());
            }
        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_urun = cmbUrun.SelectedItem.ToString();
            string tip_kontrol = new DB_Islemleri().Siparis_Urun_Tip_Kontrol(secilen_urun);
            cmbTip.Items.Clear();
            if(tip_kontrol != "NULL")
            {
                cmbTip.Items.Add(tip_kontrol);
            }
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_urun_tip = cmbTip.SelectedItem.ToString();
            string tip_deger_kontrol = new DB_Islemleri().Siparis_Get_Urun_Tip_Deger(secilen_urun, secilen_urun_tip);
            int _out = 0;
            cmbTipDeger.Items.Clear();
            if (int.TryParse(tip_deger_kontrol,out _out))
            {
                secilen_urun_tip_deger = _out; // ürün adetini out_ ettik
                for(int i=1; i<secilen_urun_tip_deger; i++)
                {
                    cmbTipDeger.Items.Add(i);
                }
            }
            else
            {
                cmbTipDeger.Items.Add(1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float tutar = 0;
            if (!lstUrunler.Items.Equals(secilen_urun))
            {
                if (secilen_urun.Length > 0)
                {
                    if (secilen_urun_tip.Length > 0)
                    {
                        if (secilen_urun_tip_deger_ > 0)
                        {
                            tutar = (secilen_urun_tip_deger_ * new DB_Islemleri().Siparis_Urun_Fiyat(secilen_urun));
                            lstUrunler.Items.Add(secilen_urun_tip_deger_ + "-adet " + secilen_urun + " ücret :" + tutar);
                        }
                        else
                        {
                            MessageBox.Show("Bu üründen elimiz de mevcut değil.", "Ürün mevcut değil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        tutar = (new DB_Islemleri().Siparis_Urun_Fiyat(secilen_urun) * 1);
                        lstUrunler.Items.Add(1 + "-adet " + secilen_urun + " ücret :" + tutar);
                    }
                }
                ucret += tutar;
                lblToplamTutar.Text = "Toplam tutar : " + ucret.ToString() + "TL";
                toplam_tip_degeri.Add(secilen_urun_tip_deger);
                tip_degerleri.Add(secilen_urun_tip_deger_);//adet burada
                urunler_listesi.Add(secilen_urun);//sanırım bitti test edelim // ürünler burada
                cmbTip.Items.Clear();
                cmbTipDeger.Items.Clear();
            }
            else
                MessageBox.Show("Bu ürün satış için listeye eklenmiş. Ürün adetini; ürünü sildikten sonra değiştirebilirsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbTipDeger_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilen_urun_tip_deger_ = int.Parse(cmbTipDeger.SelectedItem.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (lstUrunler.Items.Count > 0)
            {
                if (tip_deger_kontrol().Contains(false))
                {
                    List<SiparisList> yeniListe = new List<SiparisList>();
                    string urunler = "";
                    for (int i = 0; i < tip_degerleri.Count; i++)
                    {
                        urunler += urunler_listesi[i];
                        if (i + 1 != tip_degerleri.Count)
                        {
                            urunler += ",";
                        }
                    }
                    yeniListe.Add(new SiparisList(urunler, lblMasaName.Text, ucret));
                    new DB_Islemleri().Kasa_Kayit(lblMasa.Text, ucret, DateTime.Now.Date).ExecuteNonQuery();
                    for (int i = 0; i < urunler_listesi.Count; i++)
                    {
                        new DB_Islemleri().UrunAdetGuncelle(urunler_listesi[i], toplam_tip_degeri[i], tip_degerleri[i]);
                    }
                    MessageBox.Show(new DB_Islemleri().SiparisKayit(yeniListe), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbTip.Items.Clear();
                    cmbTipDeger.Items.Clear();
                    cmbTip.Text = "";
                    cmbTipDeger.Text = "";
                    cmbUrun.Text = "";
                    lstUrunler.Items.Clear();
                    toplam_tip_degeri.Clear();
                    urunler_listesi.Clear();
                    tip_degerleri.Clear();
                    yeniListe.Clear();
                    this.Close();
                }
                else
                    MessageBox.Show("Ürün adetinden fazla ürün satmak istiyorsunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Önce sipariş için ürün ekle.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        bool[] tip_deger_kontrol()//ürün adetinden fazla ürün satmasını engellemek için
        {
            bool[] adet_control = new bool[urunler.Count];
            for (int j = 0; j < urunler_listesi.Count; j++)//urun listesi -> test,test1,test2,test toplam degerler listesi -> 5,10,12 -> satılmak istenen 6,5,7,1 -> 6+1 -> stack down
            {
                int toplam_deger = toplam_tip_degeri[j];
                if((toplam_deger < tip_degerleri[j]))
                {
                    adet_control[j] = false;
                    break;
                }
                else
                {
                    adet_control[j] = true;
                    continue;
                }
            }
            return adet_control;
        }
        private void ürünListesindenÇıkartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = lstUrunler.SelectedItem.ToString();
            string s_tip_deger = s.Split('-')[0];//1-adet  bla bla ücret :123
            string s_fiyat = s.Split(':')[1];//1-adet bla bla ücret :123
            string s_urun = s.Split(' ')[1];
            int index = urunler_listesi.FindIndex(a => a.ToString() == s_urun);
            toplam_tip_degeri.RemoveAt(index);
            urunler_listesi.Remove(s_urun);
            tip_degerleri.Remove(int.Parse(s_tip_deger));
            if ((ucret - float.Parse(s_fiyat)) > 0)
            { ucret -= float.Parse(s_fiyat); lblToplamTutar.Text = "Toplam tutar :"+ucret.ToString(); }
            else { lblToplamTutar.Text = "Toplam tutar: 0"; }
            lstUrunler.Items.Remove(s);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
