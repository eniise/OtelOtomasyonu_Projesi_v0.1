using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace otel_otomasyonu
{
    class odalar
    {
        public string alanKisi { get; set; }
        public string durum_oku { get; set; }
        public string butonn_adi { get; set; }
        database db = new database();
        public void odaDegerleri(string oda_adi, string durumu)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand odaAl = new SqlCommand("select * from odalar where oda_adi = @odaAdi and durumu = @durum", db.baglanti);
                odaAl.Parameters.AddWithValue("@odaAdi", oda_adi);
                odaAl.Parameters.AddWithValue("@durum", durumu);
                SqlDataReader odaAl_Oku = odaAl.ExecuteReader();
                if (odaAl_Oku.Read())
                {
                    alanKisi = odaAl_Oku["odayı_alan"].ToString();
                    durum_oku = odaAl_Oku["durumu"].ToString();
                    butonn_adi = odaAl_Oku["buton_adi"].ToString();
                }
                odaAl.Dispose();
                odaAl_Oku.Close();
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
