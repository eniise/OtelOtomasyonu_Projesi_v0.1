using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace otel_otomasyonu
{
    class MüsteriEkrani
    {
        database db = new database();
        public string durum { get; set; }
        public string sil_durum { get; set; }
        public DataTable tablolar()
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand veriAl = new SqlCommand("select * from müsteriler", db.baglanti);
                SqlDataAdapter da = new SqlDataAdapter(veriAl);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                return tablo;
                db.baglanti.Close();

            }
            catch { return null; }
            finally
            {
                db.baglanti.Close();
            }
            }
        public void musteriGuncelle(int id,string adi,string soyadi,string cinsiyet,string telefon,string mail,string tcno,string odaadi,string ucret,DateTime giris,DateTime cıkıs)
        {if(db.baglanti.State==ConnectionState.Open)
            db.baglanti.Close();
            try
            {
                db.baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update müsteriler set adi=@adi,soyadi=@soyadi,cinsiyet=@cinsiyet, telefon=@telefon, mail=@mail,tcno=@tcno, odano=@oda, ucret=@ucret,giristarihi=@gtarih,cıkıstarihi=@ctarih where id=@id ", db.baglanti);
                guncelle.Parameters.AddWithValue("@adi", adi);
                guncelle.Parameters.AddWithValue("@soyadi", soyadi);
                guncelle.Parameters.AddWithValue("@cinsiyet",cinsiyet);
                guncelle.Parameters.AddWithValue("@telefon", telefon);
                guncelle.Parameters.AddWithValue("@mail", mail);
                guncelle.Parameters.AddWithValue("@tcno", tcno);
                guncelle.Parameters.AddWithValue("@oda", odaadi);
                guncelle.Parameters.AddWithValue("@ucret", ucret);
                guncelle.Parameters.AddWithValue("@gtarih", giris);
                guncelle.Parameters.AddWithValue("@ctarih", cıkıs);
                guncelle.Parameters.AddWithValue("@id", id);
                guncelle.ExecuteNonQuery();
                durum = adi + "  " + soyadi + " İSİMLİ KİŞİNİN VERİLERİN GÜNCELLENDİ ";
                

                db.baglanti.Close();

            }
            catch {
            }
            finally{
                db.baglanti.Close();
            }

        }
        public void MusteriSil(int id )
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand sil = new SqlCommand("delete müsteriler where id=@id", db.baglanti);
                sil.Parameters.AddWithValue("@id", id);
                sil.ExecuteNonQuery();
                sil_durum = "Silme işlemi gerçekleştirildi.";


            }
            catch{ }
            finally
            {
                db.baglanti.Close();

            }
        }
        public DataTable MusteriAra(string adi)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand ara = new SqlCommand("select * from müsteriler where adi LIKE '%' +  @adi + '%' ", db.baglanti);
                ara.Parameters.AddWithValue("@adi", adi);
                SqlDataAdapter da = new SqlDataAdapter(ara);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                return tablo;
               
                


            }
            catch { return null; }
            finally
            {
                db.baglanti.Close();

            }
        }
    }

    
}
