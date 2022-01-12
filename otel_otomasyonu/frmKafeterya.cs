using System;
using System.Collections.Generic;
using otel_otomasyonu.Kafeterya_Siniflar;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using otel_otomasyonu.Kafeterya_Siniflar.Arayuz;
using System.Drawing;
using System.Runtime.InteropServices;

namespace otel_otomasyonu
{
    public partial class frmKafeterya : Form
    {
        public frmKafeterya()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            BGWLog = new BackgroundWorker();
            BGWLog.DoWork += BGWLog_DoWork;
            tmrLog = new Timer();
            tmrLog.Interval = 100;
            tmrLog.Tick += TmrLog_Tick;
            ControlOfTable = new Timer();
            ControlOfTable.Interval = 1000;
            ControlOfTable.Tick += ControlOfTable_Tick;
            BGWControlOfTable = new BackgroundWorker();
            BGWControlOfTable.DoWork += BGWControlOfTable_DoWork;
            ControlOfTable.Start();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public BackgroundWorker BGWLog;
        public Timer tmrLog;
        public Timer ControlOfTable;
        public BackgroundWorker BGWControlOfTable;
        public static List<urunList> urunler = new List<urunList>();
        List<string> isimler = new DB_Islemleri().Masalar_Durum();
        private void BGWControlOfTable_DoWork(object sender, DoWorkEventArgs e)
        {
            isimler = new DB_Islemleri().Masalar_Durum();
            if (isimler != null)
            {
                for (int i = 0; i < isimler.Count; i++)
                {
                    this.tabControl1.TabPages["tabPage1"].Controls.Find(isimler[i], true)[0].BackColor = Color.DeepPink;
                }
            }
        }
        private void ControlOfTable_Tick(object sender, EventArgs e)
        {
            if (!BGWControlOfTable.IsBusy)
                BGWControlOfTable.RunWorkerAsync();
        }

        private void TmrLog_Tick(object sender, EventArgs e)
        {
            if (!BGWLog.IsBusy)
                BGWLog.RunWorkerAsync();
        }
        private void BGWLog_DoWork(object sender, DoWorkEventArgs e)
        {
            string logText = "";
            if(urunler.Count > 0)
            {
                for(int i =0; i<urunler.Count; i++)
                {
                    if(urunler[i].hatalar.Count > 0)
                    {
                        for(int j =0; j<urunler[i].hatalar.Count; j++)
                        {
                            if (urunler[i].hatalar[j].Fiyat_Hatasi.Length > 0)
                                logText += urunler[i].hatalar[j].Fiyat_Hatasi+"\n";
                            if (urunler[i].hatalar[j].Kod_Hatasi.Length > 0)
                                logText += urunler[i].hatalar[j].Kod_Hatasi+"\n";
                            if (urunler[i].hatalar[j].TipDeger_Hatasi.Length > 0)
                                logText += urunler[i].hatalar[j].TipDeger_Hatasi+"\n";
                        }
                    }
                    else
                    {
                        logText = "Liste güzel görünüyor.";
                    }
                }
                richTextBox1.Text = logText;
                tmrLog.Stop();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string[] s = txtUrunAdi.Text.Split(' ');
            if (s.Length == 1)
            {
                bool var_yok = false;
                for(int i=0; i<urunler.Count; i++)
                {
                    if(urunler[i].getUrunAdi() == txtUrunAdi.Text)
                    {
                        var_yok = true;
                        break;
                    }
                }
                if (!var_yok)
                {
                    urunler.Add(degerler());
                    tmrLog.Start();
                }
                else
                {
                    MessageBox.Show("Aynı ürün eklenemez.", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ürün isminde boşluk olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        urunList degerler()
        {
            return new urunList(txtUrunAdi.Text,txtUrunKodu.Text,txtUrunFiyat.Text,txtUrunTipi.Text,txtUrunTipDegeri.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Equals("Hata"))
            {
                MessageBox.Show("Liste içerisin de hata var. Liste görüntüle penceresinden hataları giderin.", "Hata var", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            richTextBox1.Text = "";
            for(int i =0; i<urunler.Count; i++)
            {
                if (veriKontrol(new DB_Islemleri().UrunKayit(urunler[i].getUrunAdi(), urunler[i].getUrunKod(), int.Parse(urunler[i].getUrunFiyat()), urunler[i].getUrunTip(), urunler[i].getUrunTipDeger())))
                    richTextBox1.Text += urunler[i].getUrunAdi() + " isimli ürün kayıt altına alındı.\n";
                else
                    richTextBox1.Text += urunler[i].getUrunAdi() + " isimli ürün kayıt altına alınamadı.\n";
            }
        }
        Boolean veriKontrol(SqlCommand com)
        {
            if (com.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DB_Islemleri().GetUrunList_ALL();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtUrunAdi.Text = dataGridView1.Rows[e.RowIndex].Cells["urunAdi"].Value.ToString();
                txtUrunFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["urunFiyat"].Value.ToString();
                txtUrunKodu.Text = dataGridView1.Rows[e.RowIndex].Cells["urunKod"].Value.ToString();
                txtUrunTipi.Text = dataGridView1.Rows[e.RowIndex].Cells["urunTip"].Value.ToString();
                txtUrunTipDegeri.Text = dataGridView1.Rows[e.RowIndex].Cells["urunTipDeger"].Value.ToString();
                lblID.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (veriKontrol(new DB_Islemleri().UrunGuncelle(txtUrunAdi.Text, txtUrunKodu.Text, int.Parse(txtUrunFiyat.Text), txtUrunTipi.Text, txtUrunTipDegeri.Text, int.Parse(lblID.Text))))
                richTextBox1.Text = "Bir ürün güncellendi";
            else
                richTextBox1.Text = "Ürün güncellenmedi.";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var mesaj = MessageBox.Show("Ürün silme işlemi geri alınamaz onaylıyormusunuz?", "Ürün silme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
                if (veriKontrol(new DB_Islemleri().UrunSil(int.Parse(lblID.Text))))
                    richTextBox1.Text = "Bir ürün silindi.";
                else
                    richTextBox1.Text = "Bir ürün silme işlemi sırasında hata meydana geldi.";
            else 
                richTextBox1.Text = "Bir ürün üzerinde silme işlemi uygulanmaya çalışıldı, işlem iptal edildi.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _ = new DB_Islemleri(txtParam.Text);
            dataGridView1.DataSource = DB_Islemleri.selected_transaction_list;
            richTextBox1.Text = DB_Islemleri.err;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmUrunListe liste = new frmUrunListe();
            liste.frm = this;
            liste.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKasaRapor rapor = new frmKasaRapor();
            rapor.frm = this;
            List<KasaRaporList> raporlar = new DB_Islemleri().KasaRaporList();
            for(int i=0; i<raporlar.Count; i++)
            {
                rapor.rtbRapor.Text += raporlar[i].getRapor();
            }
            rapor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDGW yazdir = new printDGW(DGWKasa, "Kasa Rapor");
            yazdir.PrintForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGWKasa.DataSource = new DB_Islemleri().Kasa_Getir_ALL();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(veriKontrol(new DB_Islemleri().Kasa_Guncelle(float.Parse(txtKasaFiyat.Text), dtpKasaTarih.Value, int.Parse(lblKasaID.Text))))
            {
                MessageBox.Show("Kasa başarılı bir şekilde güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kasa güncelleme sırasında hata.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var mesaj = MessageBox.Show("Kasa silme işlemi geri alınamaz. İşleme devam edilsin mi?", "Soru | Dikkat bu işlem geri alınamaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
            {
                if (veriKontrol(new DB_Islemleri().Kasa_Sil(int.Parse(lblKasaID.Text))))
                {
                    MessageBox.Show("Kasa silme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kasa silme işlemi sırasında hata.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kasa silme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DGWKasa.DataSource = new DB_Islemleri().Kasa_Getir_FiyatAralik(txtKasaFiyat.Text);
            MessageBox.Show(DB_Islemleri.Kasa_Arama_Durum, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DGWKasa.DataSource = new DB_Islemleri().Kasa_Getir_Tarih(dtpKasaTarih.Value);
            MessageBox.Show(DB_Islemleri.Kasa_Arama_Durum, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void masa_sender(object sender, EventArgs e)
        {
            var obje = sender as Button;
            if (obje.BackColor == Color.LightPink)
            {
                frmKafeteryaSiparis frmKafeteryaSiparis = new frmKafeteryaSiparis();
                frmKafeteryaSiparis.frm = this;
                frmKafeteryaSiparis.lblMasa.Text = obje.Text;
                frmKafeteryaSiparis.lblMasaName.Text = obje.Name;
                frmKafeteryaSiparis.Show();
            }
            else
            {
                MessageBox.Show("bu masa suanda dolu...", "masa dolu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGWKasa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKasaFiyat.Text = DGWKasa.Rows[e.RowIndex].Cells["kasa_Fiyat"].Value.ToString();
            dtpKasaTarih.Value = Convert.ToDateTime(DGWKasa.Rows[e.RowIndex].Cells["kasa_EklenmeTarih"].Value.ToString());
            lblKasaID.Text = DGWKasa.Rows[e.RowIndex].Cells["kasa_ID"].Value.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new DB_Islemleri().EnCokTercihEdilenMasa(),"Vaoov",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void masaBoşaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlOfTable.Stop();
            isimler.Remove(Masa_Name);
            this.tabControl1.TabPages["tabPage1"].Controls.Find(Masa_Name, true)[0].BackColor = Color.LightPink;
            new DB_Islemleri().SiparisSil(Masa_Name);
            isimler = new DB_Islemleri().Masalar_Durum();
            ControlOfTable.Start();
        }
        private static string Masa_Name { get; set; }
        private void masa1_MouseEnter(object sender, EventArgs e)
        {
            var obje = sender as Button;
            Masa_Name = obje.Name;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
