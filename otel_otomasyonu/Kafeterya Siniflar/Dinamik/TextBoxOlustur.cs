using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace otel_otomasyonu.Kafeterya_Siniflar.Dinamik
{
    public class TextBoxOlustur
    {
        private List<urunList> urunler;
        public static int urun_deger = 0;
        public TextBoxOlustur(List<urunList> urunLists)
        {
            this.urunler = urunLists;
        }
        public TextBoxOlustur()
        {

        }
        public void flpAdd_TextBox()
        {
            var flp = Application.OpenForms["frmUrunListe"].Controls.Find("flpUrunler", true)[0] as FlowLayoutPanel;
            for(int i =0; i<urunler.Count; i++)
            {
                flp.Controls.Add(CreateTextBox(urunler[i].getUrunAdi()));
                flp.Controls.Add(CreateTextBox(urunler[i].getUrunKod()));
                flp.Controls.Add(CreateTextBox(urunler[i].getUrunFiyat()));
                flp.Controls.Add(CreateTextBox(urunler[i].getUrunTip()));
                flp.Controls.Add(CreateTextBox(urunler[i].getUrunTipDeger()));
            }
        }
        private TextBox CreateTextBox(string urunDegeri)
        {
            urun_deger++;
            TextBox textTemp_Box = new TextBox();
            textTemp_Box.Text = urunDegeri;
            textTemp_Box.Name = "name" + urun_deger;
            textTemp_Box.Width = 100;
            textTemp_Box.Height = 20;
            return textTemp_Box;

        }
    }
}
