using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace otel_otomasyonu.Kafeterya_Siniflar.Arayuz
{
    internal interface IDBTransactions 
    {
        DataTable GetUrunList_ALL();
        DataTable GetUrunList_UrunAdi(string urunAdi);
        DataTable GetUrunList_UrunFiyat(int urunFiyat);
        DataTable GetUrunList_UrunTip(string urunTip);
        SqlCommand UrunGuncelle(string urunAdi, string urunKod, int urunFiyat, string urun_Tip, string urun_Tip_Deger, int id);
        SqlCommand UrunKayit(string urunAdi, string urunKod, int urunFiyat, string urun_Tip, string urun_Tip_Deger);
        SqlCommand UrunSil(int id);
        SqlCommand Kasa_Kayit(string masa,float fiyat, DateTime tarih);
        SqlCommand Kasa_Guncelle(float fiyat, DateTime tarih,int id);
        SqlCommand Kasa_Sil(int id);
        DataTable Kasa_Getir_ALL();
        DataTable Kasa_Getir_FiyatAralik(string fiyat);
        DataTable Kasa_Getir_Tarih(DateTime Tarih);
        List<KasaRaporList> KasaRaporList();
        string Siparis_Urun_Tip_Kontrol(string urunAdi);
        List<urunList> Siparis_Urun_Liste();
        string Siparis_Get_Urun_Tip_Deger(string urunAdi,string Tip);
        float Siparis_Urun_Fiyat(string urunAdi);
        void UrunAdetGuncelle(string UrunAdi, int suankiAdet, int DegisecekAdet);
        string SiparisKayit(List<SiparisList> liste);
        string SiparisSil(string MasaAdi);
        string EnCokTercihEdilenMasa();
        List<string> Masalar_Durum();
    }
}
