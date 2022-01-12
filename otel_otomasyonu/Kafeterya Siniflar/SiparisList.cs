using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otel_otomasyonu.Kafeterya_Siniflar
{
    public class SiparisList
    {
        private string urunler;
        private string buttonAdi;
        private float tutar;
        public SiparisList(string urunler, string buttonAdi, float tutar)
        {
            setButtonAdi(buttonAdi); setTutar(tutar); setUrunler(urunler);
        }
        public string getUrunler()
        {
            return this.urunler;
        }
        public string getButtonAdi()
        {
            return this.buttonAdi;
        }
        public float getTutar()
        {
            return this.tutar;
        }
        public void setUrunler(string urunler)
        {
            this.urunler = urunler;
        }
        public void setButtonAdi(string buttonAdi)
        {
            this.buttonAdi = buttonAdi;
        }
        public void setTutar(float tutar)
        {
            this.tutar = tutar;
        }

    }
}
