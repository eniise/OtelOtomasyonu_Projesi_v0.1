using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace otel_otomasyonu
{
    class personelekle
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
                SqlCommand veriAl = new SqlCommand("select * from personel", db.baglanti);
                SqlDataAdapter da = new SqlDataAdapter(veriAl);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                return tablo;
                db.baglanti.Close();

            }
            catch(Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); return null; }
            finally
            {
                db.baglanti.Close();
            }
        }
        public void personelGuncelle(string tcno, string adi, string soyadi, string telefon, string maas, string görev)
        {
            if (db.baglanti.State == ConnectionState.Open)
                db.baglanti.Close();
            try
            {
                db.baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update personel set adi=@adi,soyadi=@soyadi, telno=@telefon, maas=@maas,gorev=@gorev where tcno=@tcno ", db.baglanti);
                guncelle.Parameters.AddWithValue("@adi", adi);
                guncelle.Parameters.AddWithValue("@soyadi", soyadi);
                guncelle.Parameters.AddWithValue("@telefon", telefon);
                guncelle.Parameters.AddWithValue("@maas", maas);
                guncelle.Parameters.AddWithValue("@gorev",görev);
                guncelle.Parameters.AddWithValue("@tcno", tcno);

                guncelle.ExecuteNonQuery();
                durum = adi + "  " + soyadi + " İSİMLİ KİŞİNİN VERİLERİN GÜNCELLENDİ ";


                db.baglanti.Close();

            }
            catch
            {
            }
            finally
            {
                db.baglanti.Close();
            }

        }
        public void personelSil(string tc)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand sil = new SqlCommand("delete personel where tcno=@tc", db.baglanti);
                sil.Parameters.AddWithValue("@tc", tc);
                sil.ExecuteNonQuery();
                sil_durum = "Silme işlemi gerçekleştirildi.";


            }
            catch { }
            finally
            {
                db.baglanti.Close();

            }
        }
        public DataTable personelAra(string tcNo)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand ara = new SqlCommand("select * from personel where tcno=@tc ", db.baglanti);
                ara.Parameters.AddWithValue("@tc", tcNo);
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
        public void ekle(string tcno, string adi, string soyadi, string telefon, string maası, string gorev)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand ekle = new SqlCommand("insert into personel values(@tcno,@adi,@soyadi,@telefon,@maas,@gorev)", db.baglanti);
                ekle.Parameters.AddWithValue("@tcno", tcno);
                ekle.Parameters.AddWithValue("@adi", adi);
                ekle.Parameters.AddWithValue("@soyadi", soyadi);
                ekle.Parameters.AddWithValue("@telefon", telefon);
                ekle.Parameters.AddWithValue("@maas", maası);
                ekle.Parameters.AddWithValue("@gorev", gorev);

                ekle.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Personel kayıdı, başarılı bir şekilde oluşmuştur...", "Bilgi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
             
                ekle.Dispose();


            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
