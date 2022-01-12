using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace otel_otomasyonu.Kafeterya_Siniflar.Arayuz
{
    public class DB_Islemleri : IDBTransactions
    {
        private const string V = "NULL";
        private const float F = 0.0F;
        private const string SIPARIS_KAYIT = "Sipariş kayıt edildi.";
        private const string SIPARIS_KAYIT_ERROR = "Sipariş kayıt sırasında hata!";
        private const string MASA_SILME_DURUMU = "MASA BOŞALTILDI";
        private const string MASA_SILME_DURUMU_ERR = "MASA BOŞALTMA SIRASINDA HATA";
        #region urunler => veritabanı tarıfı için yapı
        public static DataTable selected_transaction_list;
        public static string err { get; set; }
        public DB_Islemleri(string aramaTipi)
        {
            selected_transaction_list = new DataTable();
            string part1 = aramaTipi.Split('-')[0];
            string part2 = aramaTipi.Split('-')[1];
            switch (part1.ToLower())
            {
                case "isim ":
                    selected_transaction_list = GetUrunList_UrunAdi(part2);
                    err = "isime göre listeleme işlemi başarılı.";
                    if (selected_transaction_list.Rows.Count <= 0)
                        err += "\nFakat veritabanı bir sonuç vermedi.";
                    break;
                case "fiyat ":
                    selected_transaction_list = GetUrunList_UrunFiyat(int.Parse(part2));
                    err = "fiyata göre listeleme işlemi başarılı.";
                    if (selected_transaction_list.Rows.Count <= 0)
                        err += "\nFakat veritabanı bir sonuç vermedi.";
                    break;
                case "tip ":
                    selected_transaction_list = GetUrunList_UrunTip(part2);
                    err = "tipe göre listeleme işlemi başarılı.";
                    if (selected_transaction_list.Rows.Count <= 0)
                        err += "\nFakat veritabanı bir sonuç vermedi.";
                    break;
                default:
                    selected_transaction_list = null;
                    err = "parametre hatası";
                    break;
            }
        }
        public DB_Islemleri()
        {

        }
        public DataTable GetUrunList_ALL()
        {
            DataTable table_All = new DataTable();
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand select_All_SQL = new SqlCommand("select * from kafeteryaUrunler", database.staticBaglanti))
            {
                using (SqlDataAdapter adaptor = new SqlDataAdapter(select_All_SQL))
                    adaptor.Fill(table_All);
            }
            return table_All;
        }

        public DataTable GetUrunList_UrunAdi(string urunAdi)
        {
            DataTable table_UrunAdi = new DataTable();
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand select_UrunAdi_SQL = new SqlCommand("select * from kafeteryaUrunler where urunAdi LIKE @param", database.staticBaglanti))
            {
                select_UrunAdi_SQL.Parameters.AddWithValue("@param", "%"+urunAdi+"%");
                using (SqlDataAdapter adaptor = new SqlDataAdapter(select_UrunAdi_SQL))
                    adaptor.Fill(table_UrunAdi);
            }
            return table_UrunAdi;
        }

        public DataTable GetUrunList_UrunFiyat(int urunFiyat)
        {
            DataTable table_UrunFiyat = new DataTable();
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand select_UrunFiyat_SQL = new SqlCommand("select * from kafeteryaUrunler where urunFiyat = @param", database.staticBaglanti))
            {
                select_UrunFiyat_SQL.Parameters.AddWithValue("@param", urunFiyat);
                using (SqlDataAdapter adaptor = new SqlDataAdapter(select_UrunFiyat_SQL))
                    adaptor.Fill(table_UrunFiyat);
            }
            return table_UrunFiyat;
        }

        public DataTable GetUrunList_UrunTip(string urunTip)
        {
            DataTable table_UrunTip = new DataTable();
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand select_UrunTip_SQL = new SqlCommand("select * from kafeteryaUrunler where urunTip = @param", database.staticBaglanti))
            {
                select_UrunTip_SQL.Parameters.AddWithValue("@param", urunTip);
                using (SqlDataAdapter adaptor = new SqlDataAdapter(select_UrunTip_SQL))
                    adaptor.Fill(table_UrunTip);
            }
            return table_UrunTip;
        }

        public SqlCommand UrunGuncelle(string urunAdi, string urunKod, int urunFiyat, string urun_Tip, string urun_Tip_Deger, int id)
        {
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand urunGuncelle = new SqlCommand("update kafeteryaUrunler set urunAdi=@p1, urunKod=@p2,urunFiyat=@p3,urunTip=@p4,urunTipDeger=@p5 where id=@id", database.staticBaglanti))
            {
                urunGuncelle.Parameters.AddWithValue("@p1", urunAdi);
                urunGuncelle.Parameters.AddWithValue("@p2", urunKod);
                urunGuncelle.Parameters.AddWithValue("@p3", urunFiyat);
                urunGuncelle.Parameters.AddWithValue("@p4", urun_Tip);
                urunGuncelle.Parameters.AddWithValue("@p5", urun_Tip_Deger);
                urunGuncelle.Parameters.AddWithValue("@id", id);
                return urunGuncelle;
            }
        }

        public SqlCommand UrunKayit(string urunAdi, string urunKod, int urunFiyat, string urun_Tip, string urun_Tip_Deger)
        {
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand urunKayit = new SqlCommand("insert into kafeteryaUrunler values(@p1,@p2,@p3,@p4,@p5)", database.staticBaglanti))
            {
                urunKayit.Parameters.AddWithValue("@p1", urunAdi);
                urunKayit.Parameters.AddWithValue("@p2", urunKod);
                urunKayit.Parameters.AddWithValue("@p3", urunFiyat);
                urunKayit.Parameters.AddWithValue("@p4", urun_Tip);
                urunKayit.Parameters.AddWithValue("@p5", urun_Tip_Deger);
                return urunKayit;
            }
        }

        public SqlCommand UrunSil(int id)
        {
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand urunSil = new SqlCommand("delete from kafeteryaUrunler where id = @id", database.staticBaglanti))
            {
                urunSil.Parameters.AddWithValue("@id", id);
                return urunSil;
            }
        }
        #endregion
        #region kasa => veritabanı tarafı için yapı
        public static string Kasa_Arama_Durum;
        public SqlCommand Kasa_Kayit(string masa,float fiyat, DateTime tarih)
        {
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand kasaKayit = new SqlCommand("exec kasaKayit @p1,@p2,@p3", database.staticBaglanti))
            {
                kasaKayit.Parameters.AddWithValue("@p1", masa);
                kasaKayit.Parameters.AddWithValue("@p2", fiyat);
                kasaKayit.Parameters.AddWithValue("@p3", tarih.ToString("yyyy-MM-dd"));
                return kasaKayit;
            }
        }
        public void UrunAdetGuncelle(string UrunAdi,int suankiAdet,int DegisecekAdet)
        {
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand urunAdetGuncelle = new SqlCommand("exec UrunAdet_Guncelle @p1,@p2,@p3", database.staticBaglanti))
            {
                urunAdetGuncelle.Parameters.AddWithValue("@p1", suankiAdet);
                urunAdetGuncelle.Parameters.AddWithValue("@p2", DegisecekAdet);
                urunAdetGuncelle.Parameters.AddWithValue("@p3", UrunAdi);
                urunAdetGuncelle.ExecuteNonQuery();
            }
        }
        public SqlCommand Kasa_Guncelle(float fiyat, DateTime tarih, int id)
        {
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand kasaGuncelle = new SqlCommand("exec kasaGuncelle @p1,@p2,@p3", database.staticBaglanti))
            {
                kasaGuncelle.Parameters.AddWithValue("@p1", fiyat);
                kasaGuncelle.Parameters.AddWithValue("@p2", tarih.ToString("yyyy-MM-dd"));
                kasaGuncelle.Parameters.AddWithValue("@p3", id);
                return kasaGuncelle;
            }
        }

        public SqlCommand Kasa_Sil(int id)
        {
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand kasaSil = new SqlCommand("exec kasaSil @p1", database.staticBaglanti))
            {
                kasaSil.Parameters.AddWithValue("@p1", id);
                return kasaSil;
            }
        }

        public DataTable Kasa_Getir_ALL()
        {
            DataTable table_All = new DataTable();
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand kafeteryaKasa = new SqlCommand("select * from kafeteryaKasa", database.staticBaglanti))
            {
                using (SqlDataAdapter adaptor = new SqlDataAdapter(kafeteryaKasa))
                    adaptor.Fill(table_All);
            }
            return table_All;
        }

        public DataTable Kasa_Getir_FiyatAralik(string fiyat)
        {
            DataTable table_All = new DataTable();
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand kafeteryaKasa = new SqlCommand("select * from kafeteryaKasa where kasa_Fiyat >= @p1 AND kasa_Fiyat <= @p2", database.staticBaglanti))
            {
                int p1 = int.Parse(fiyat.Split('-')[0]);
                int p2 = int.Parse(fiyat.Split('-')[1]);
                kafeteryaKasa.Parameters.AddWithValue("@p1", p1);
                kafeteryaKasa.Parameters.AddWithValue("@p2", p2);
                using (SqlDataAdapter adaptor = new SqlDataAdapter(kafeteryaKasa))
                    adaptor.Fill(table_All);
            }
            if (table_All.Rows.Count > 0)
                Kasa_Arama_Durum = table_All.Rows.Count + " değer bulundu.";
            else
                Kasa_Arama_Durum = "Değer bulunamadı.";
            return table_All;
        }

        public DataTable Kasa_Getir_Tarih(DateTime Tarih)
        {
            DataTable table_All = new DataTable();
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand kafeteryaKasa = new SqlCommand("select * from kafeteryaKasa where kasa_EklenmeTarih = @p1", database.staticBaglanti))
            {
                kafeteryaKasa.Parameters.AddWithValue("@p1", Tarih.ToString("yyyy-MM-dd"));
                using (SqlDataAdapter adaptor = new SqlDataAdapter(kafeteryaKasa))
                    adaptor.Fill(table_All);
            }
            if (table_All.Rows.Count > 0)
                Kasa_Arama_Durum = table_All.Rows.Count + " değer bulundu.";
            else
                Kasa_Arama_Durum = "Değer bulunamadı.";
            return table_All;
        }

        public List<KasaRaporList> KasaRaporList()
        {
            List<KasaRaporList> temp = new List<KasaRaporList>();
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand raporList = new SqlCommand("Select * from kasaRapor", database.staticBaglanti))
            {
                using (SqlDataReader readRapor = raporList.ExecuteReader())
                {
                    if (readRapor.HasRows)
                    {
                        while (readRapor.Read())
                        {
                            string Tarih = Convert.ToDateTime(readRapor["RaporTarih"]).ToString("yyyy-MM-dd");
                            string Rapor = readRapor["RaporIcerik"].ToString()+" => "+Tarih+"\n";
                            temp.Add(new KasaRaporList(Rapor, Tarih));
                        }
                        return temp;
                    }
                    else
                    {
                        List<KasaRaporList> lists = new List<KasaRaporList>();
                        lists.Add(new KasaRaporList("=> Rapor Eklenmemiş olabilir\n=> Kasa üzerinde işlem yapılmamış olabilir\n=> Sorgulama Tarihi = "+DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd")));
                        return lists;
                    }
                }
            }
        }
        #endregion
        public string Siparis_Urun_Tip_Kontrol(string urunAdi)
        {
            if (database.staticBaglanti.State == ConnectionState.Open)
                database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using(SqlCommand getTip = new SqlCommand("select urunTip from kafeteryaUrunler where urunAdi = @p1", database.staticBaglanti))
            {
                getTip.Parameters.AddWithValue("@p1", urunAdi);
                using(SqlDataReader read = getTip.ExecuteReader())
                {
                    if (read.HasRows)
                        if (read.Read())
                            return read["urunTip"].ToString();
                        else
                            return V;
                    else
                        return V;
                }
            }
        }

        public List<urunList> Siparis_Urun_Liste()
        {
            List<urunList> list_temp = new List<urunList>();
            if (database.staticBaglanti.State == ConnectionState.Open)
                database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using(SqlCommand liste_urunler = new SqlCommand("select * from kafeteryaUrunler", database.staticBaglanti))
            {
                using(SqlDataReader read_urunler = liste_urunler.ExecuteReader())
                {
                    if (read_urunler.HasRows)
                    {
                        while (read_urunler.Read())
                        {
                            string urunAdi = read_urunler["urunAdi"].ToString();
                            string urunKod = read_urunler["urunKod"].ToString();
                            float urunFiyat = float.Parse(read_urunler["urunFiyat"].ToString());
                            string urunTip = read_urunler["urunTip"].ToString();
                            string urunTipDeger = read_urunler["urunTipDeger"].ToString();
                            list_temp.Add(new urunList(urunAdi, urunKod, urunFiyat.ToString(), urunTip, urunTipDeger));
                        }
                        return list_temp;
                    }
                    else
                    {
                        List<urunList> lists = new List<urunList>();
                        lists.Add(new urunList("Ürün", "Yok", "0", "TipYok", "0"));
                        return lists;
                    }
                }
            }
        }
        public string Siparis_Get_Urun_Tip_Deger(string urunAdi, string Tip)
        {
            if (database.staticBaglanti.State == ConnectionState.Open)
                database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand getTipDeger = new SqlCommand("select urunTipDeger from kafeteryaUrunler where urunAdi = @p1 AND urunTip = @p2", database.staticBaglanti))
            {
                getTipDeger.Parameters.AddWithValue("@p1", urunAdi);
                getTipDeger.Parameters.AddWithValue("@p2", Tip);
                using (SqlDataReader read = getTipDeger.ExecuteReader())
                {
                    if (read.HasRows)
                        if (read.Read())
                            return read["urunTipDeger"].ToString();
                        else
                            return V;
                    else
                        return V;
                }
            }
        }

        public float Siparis_Urun_Fiyat(string urunAdi)
        {
            if (database.staticBaglanti.State == ConnectionState.Open)
                database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using (SqlCommand getTipDeger = new SqlCommand("select urunFiyat from kafeteryaUrunler where urunAdi = @p1", database.staticBaglanti))
            {
                getTipDeger.Parameters.AddWithValue("@p1", urunAdi);
                using (SqlDataReader read = getTipDeger.ExecuteReader())
                {
                    if (read.HasRows)
                        if (read.Read())
                            return float.Parse(read["urunFiyat"].ToString());
                        else
                            return F;
                    else
                        return F;
                }
            }
        }

        public string SiparisKayit(List<SiparisList> liste)
        {
            int kayit_ = 0;
            int kayit_err = 0;
            for(int i=0; i<liste.Count; i++)
            {
                if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
                database.staticBaglanti.Open();
                string urunler = liste[i].getUrunler();
                string buttonAdi = liste[i].getButtonAdi();
                float tutar = liste[i].getTutar();
                using(SqlCommand siparisKayit = new SqlCommand("exec siparisKayit @p1,@p2,@p3",database.staticBaglanti))
                {
                    siparisKayit.Parameters.AddWithValue("@p1", urunler);
                    siparisKayit.Parameters.AddWithValue("@p2", tutar);
                    siparisKayit.Parameters.AddWithValue("@p3", buttonAdi);
                    try
                    {
                        siparisKayit.ExecuteNonQuery();
                        kayit_++;
                    }
                    catch (Exception ex){ kayit_err++; }
                }
            }
            if (kayit_ > 0)
                return kayit_ + SIPARIS_KAYIT;
            else if (kayit_err > 0)
                return kayit_err + SIPARIS_KAYIT_ERROR;
            else
                return V;
        }

        public string EnCokTercihEdilenMasa()
        {
            if (database.staticBaglanti.State == ConnectionState.Open) database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            List<int> masalar = new List<int>();
            List<int> index = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                using (SqlCommand masa = new SqlCommand("select Count(*) as Count from kafeteryaKasa where kasa_Masa = @p1", database.staticBaglanti))
                {
                    masa.Parameters.AddWithValue("@p1", "MASA " + i);
                    using (SqlDataReader oku = masa.ExecuteReader())
                    {
                        if (oku.Read())
                        {
                            masalar.Add(int.Parse(oku["Count"].ToString()));
                            index.Add(i);
                        }
                        else
                        {
                            masalar.Add(0);
                        }
                    }
                }
            }
            int en_buyuk = masalar[0];
            int masa_index = 0;
            for(int i=0; i< masalar.Count; i++)
            {
                if(en_buyuk < masalar[i])
                {
                    en_buyuk = masalar[i];
                    masa_index = i;
                }
            }
            if (masa_index == 0)
                return "EN ÇOK TERCİH EDİLEN MASA => MASA" + index[masa_index];
            else
                return "EN ÇOK TERCİH EDİLEN MASA => MASA" + index[masa_index];
        }

        public List<string> Masalar_Durum()
        {
            List<string> temp_list = new List<string>();
            if (database.staticBaglanti.State == ConnectionState.Open)
                database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using(SqlCommand masalarControl = new SqlCommand("select * from kafteryaMusteriSiparis", database.staticBaglanti))
            {
                using(var oku = masalarControl.ExecuteReader())
                {
                    while (oku.Read())
                    {
                        temp_list.Add(oku["buttonAdi"].ToString());
                    }
                }
            }
            if (temp_list.Count > 0)
                return temp_list;
            else
                return null;
        }

        public string SiparisSil(string MasaAdi)
        {
            int err_ = 0;
            int normal_ = 0;
            if (database.staticBaglanti.State == ConnectionState.Open)
                database.staticBaglanti.Close();
            database.staticBaglanti.Open();
            using(SqlCommand siparisSil = new SqlCommand("exec siparisKayit_Sil @p1", database.staticBaglanti))
            {
                siparisSil.Parameters.AddWithValue("@p1", MasaAdi);
                try
                {
                    siparisSil.ExecuteNonQuery();
                    normal_++;
                }
                catch { err_++; }
            }
            if (err_ > 0)
                return err_ + MASA_SILME_DURUMU_ERR;
            else if (normal_ > 0)
                return normal_ + MASA_SILME_DURUMU;
            else
                return "Kardeşim sen nereye geldin böyle bir şey olanaksız.";
        }
    }
}
