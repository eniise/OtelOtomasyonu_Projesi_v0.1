using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace otel_otomasyonu
{
    public partial class müsteri : Form
    {
        public müsteri()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                    {
                        m.Result = (IntPtr)0x2;
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        ArrayList odalar = new ArrayList(); 
      public  void koltukYazdir()
        {
            string oda = "";
            for (int i = 0; i < odalar.Count; i++)
            {
                oda += odalar[i].ToString() + ",";
            }
            if (odalar.Count >= 1)
            {
                oda = oda.Remove(oda.Length - 1, 1);
            }
            txtOda.Text= oda;
        }
        private void odaTikla(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.LightPink)
            {
                ((Button)sender).BackColor = Color.Yellow;
                if (!odalar.Contains(((Button)sender).Text))
                {
                    odalar.Add(((Button)sender).Text);
                }
                koltukYazdir();
            }
            else if (((Button)sender).BackColor == Color.Yellow)
            {
                ((Button)sender).BackColor = Color.LightPink;
                if (odalar.Contains(((Button)sender).Text))
                {
                    odalar.Remove(((Button)sender).Text);
                }
                koltukYazdir();
            }
        }
        public DateTime giristarihi { get; set; }
        public DateTime cıkıstarihi { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            giristarihi = Convert.ToDateTime(dateTimePicker1.Value);
            cıkıstarihi = Convert.ToDateTime(dateTimePicker2.Value);
            musteriKayit kayit = new musteriKayit();
            for (int i = 0; i < odalar.Count; i++)
            {
                string oda = odalar[i].ToString();
                kayit.kayitAl(txtAdi.Text, txtSoyadi.Text, cmbCinsiyet.Text, txtTelefon.Text, txtMail.Text, txtTc.Text, oda, txtUcret.Text, giristarihi, cıkıstarihi);
            }
            tmrKontrol.Start();
        }

        private void tmrKontrol_Tick(object sender, EventArgs e)
        {
            database db = new database();
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand donustur = new SqlCommand("select * from odalar where durumu=@durum", db.baglanti);
                donustur.Parameters.AddWithValue("@durum", "Dolu");
                SqlDataReader donustur_Oku = donustur.ExecuteReader();
                while (donustur_Oku.Read())
                {
                    string buton_adi = donustur_Oku["buton_adi"].ToString();
                    string durumu = donustur_Oku["durumu"].ToString();
                    if (buton_adi == "oda1" && durumu == "Dolu")
                    {
                        oda1.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda2" && durumu == "Dolu")
                    {
                        oda2.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda3" && durumu == "Dolu")
                    {
                        oda3.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda4" && durumu == "Dolu")
                    {
                        oda4.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda5" && durumu == "Dolu")
                    {
                        oda5.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda6" && durumu == "Dolu")
                    {
                        oda6.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda7" && durumu == "Dolu")
                    {
                        oda7.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda8" && durumu == "Dolu")
                    {
                        oda8.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda9" && durumu == "Dolu")
                    {
                        oda9.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda10" && durumu == "Dolu")
                    {
                        oda10.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda11" && durumu == "Dolu")
                    {
                        oda11.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda12" && durumu == "Dolu")
                    {
                        oda12.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda13" && durumu == "Dolu")
                    {
                        oda13.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda14" && durumu == "Dolu")
                    {
                        oda14.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda15" && durumu == "Dolu")
                    {
                        oda15.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda16" && durumu == "Dolu")
                    {
                        oda16.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda17" && durumu == "Dolu")
                    {
                        oda17.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda18" && durumu == "Dolu")
                    {
                        oda18.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda19" && durumu == "Dolu")
                    {
                        oda19.BackColor = Color.DeepPink;
                    }
                    if (buton_adi == "oda20" && durumu == "Dolu")
                    {
                        oda20.BackColor = Color.DeepPink;
                    }
                }
                donustur.Dispose();
                donustur_Oku.Close();
                db.baglanti.Close();
                tmrKontrol.Stop();
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
       

        private void müsteri_Load(object sender, EventArgs e)
        {
            tmrKontrol.Start();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
