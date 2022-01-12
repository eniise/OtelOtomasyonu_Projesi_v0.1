using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otel_otomasyonu
{
    public partial class Frmodalar : Form
    {
        public Frmodalar()
        {
            InitializeComponent();
        }
        ArrayList odalar = new ArrayList();

        void odalarinDurumu()
        {
            string yenioda = "";
            odalar oda = new odalar();
            try
            {
                foreach (string odanın_adi in odalar) 
                {
                    oda.odaDegerleri(odanın_adi, "Dolu"); 
                    if (oda.durum_oku == "Dolu")
                    {
                        yenioda = odanın_adi;
                        this.Controls.Find(oda.butonn_adi, true)[0].BackColor = Color.DeepPink;
                        this.Controls.Find(oda.butonn_adi, true)[0].Text = yenioda + " \n" + oda.alanKisi;
                        oda.durum_oku = "";
                    }
                    if (oda.durum_oku == "Boş")
                    {
                        this.Controls.Find(oda.butonn_adi, true)[0].BackColor = Color.LightPink;
                    }
                }
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
        }

        private void Frmodalar_Load_1(object sender, EventArgs e)
        {
            string odaAdi = "";
            string yeniDeger = "";
           
            for (int i = 1; i < this.Controls.Count +1; i++)
            {
                odaAdi = Convert.ToString(this.Controls.Find("oda" + i.ToString(), true).FirstOrDefault() as Button);
                yeniDeger = odaAdi.Split(':').Last();
                odalar.Add(yeniDeger);
           
            }
           
            odalarinDurumu();
            
        }
        Form2 main = new Form2();
        private void Frmodalar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                main.StartPosition = FormStartPosition.CenterScreen;  ;
                main.Show();
            }
        }
    }
}
