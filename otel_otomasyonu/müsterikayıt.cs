using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace otel_otomasyonu
{
    class musteriKayit
    {
        public string kisininAdi_soyadi { get; set; }
        database db = new database();
        public static void odaGuncelle(string oda, string kisiAdSoyad)
        {
          database db = new database();
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update odalar set odayı_alan=@alanKisi, durumu=@durum where oda_adi = @odaAdi", db.baglanti);
                guncelle.Parameters.AddWithValue("@alanKisi", kisiAdSoyad);
                guncelle.Parameters.AddWithValue("@durum", "Dolu");
                guncelle.Parameters.AddWithValue("@odaAdi", oda);
                guncelle.ExecuteNonQuery();
                guncelle.Dispose();
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
        public void kayitAl(string adi, string soyadi, string cinsiyet, string telefon, string mail, string tcno, string odano, string ucret, DateTime giristarihi, DateTime cıkıstarihi)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand kayit_Al = new SqlCommand("insert into müsteriler values(@adi,@soyadi,@cinsiyet,@telefon,@mail,@tc,@oda,@ucret,@giris,@cikis)", db.baglanti);
                kayit_Al.Parameters.AddWithValue("@adi", adi);
                kayit_Al.Parameters.AddWithValue("@soyadi", soyadi);
                kayit_Al.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                kayit_Al.Parameters.AddWithValue("@telefon", telefon);
                kayit_Al.Parameters.AddWithValue("@mail", mail);
                kayit_Al.Parameters.AddWithValue("@tc", tcno);
                kayit_Al.Parameters.AddWithValue("@oda", odano);
                kayit_Al.Parameters.AddWithValue("@ucret", ucret);
                kayit_Al.Parameters.AddWithValue("@giris", giristarihi);
                kayit_Al.Parameters.AddWithValue("@cikis", cıkıstarihi);
                kayit_Al.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Müşteri kayıdı, başarılı bir şekilde oluşmuştur : " + odano + " isimli oda :" + adi + " " + soyadi + " isimli kişiye verilmiştir.", "Bilgi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                kayit_Al.Dispose();
                
                kisininAdi_soyadi = adi + " " + soyadi;
                odaGuncelle(odano, kisininAdi_soyadi);
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
