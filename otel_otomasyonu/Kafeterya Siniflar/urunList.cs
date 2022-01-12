using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otel_otomasyonu.Kafeterya_Siniflar
{
    public class urunList : TipKonrol
    {
        private string urunAdi;
        private string urunKod;
        private string urunFiyat;
        private string urun_Tip;
        private string urun_Tip_Deger;
        public List<HataListesi> hatalar = new List<HataListesi>();
        public urunList(string urunAdi, string urunKod, string urunFiyat, string urun_Tip, string urun_Tip_Deger)
        {
            HataListesi hataList = new HataListesi();
            setUrunAdi(urunAdi);
            if (urunKod_Konrol(urunKod)) { setUrunKod(urunKod); hataList.Kod_Hatasi = urunAdi + " isimli ürün listeye alındı."; } else { hataList.Kod_Hatasi = urunAdi + " isimli üründe Kod hatası"; }
            if (urunFiyat_Konrol(urunFiyat.ToString())) { setUrunFiyat(urunFiyat); hataList.Fiyat_Hatasi = urunAdi + " isimli ürün listeye alındı."; } else { hataList.Fiyat_Hatasi = urunAdi + " isimli üründe Fiyat hatası"; }
            if (urunTipDegeri_Konrol(urun_Tip_Deger)) { setUrunTip(urun_Tip); hataList.TipDeger_Hatasi = urunAdi + " isimli ürün listeye alındı."; } else { hataList.TipDeger_Hatasi = urunAdi + " isimli üründe Tip Değeri hatası"; }
            setUrunTipDeger(urun_Tip_Deger);
            if(hataList.Fiyat_Hatasi.Length > 0 || hataList.Kod_Hatasi.Length > 0 || hataList.TipDeger_Hatasi.Length > 0) hatalar.Add(hataList);
        }
        public urunList()
        {

        }
        #region set fields
        void setUrunAdi(string urunAdi)
        {
            this.urunAdi = urunAdi;
        }
        void setUrunKod(string urunKod)
        {
            this.urunKod = urunKod;
        }
        void setUrunFiyat(string urunFiyat)
        {
            this.urunFiyat = urunFiyat;
        }
        void setUrunTip(string urunTip)
        {
            this.urun_Tip = urunTip;
        }
        void setUrunTipDeger(string urunTipDeger)
        {
            this.urun_Tip_Deger = urunTipDeger;
        }
        #endregion
        #region get Fields
        public string getUrunAdi() { return this.urunAdi; }
        public string getUrunKod() { return this.urunKod; }
        public string getUrunFiyat() { return this.urunFiyat; }
        public string getUrunTip() { return this.urun_Tip; }
        public string getUrunTipDeger() { return this.urun_Tip_Deger; }
        #endregion
    }
}
