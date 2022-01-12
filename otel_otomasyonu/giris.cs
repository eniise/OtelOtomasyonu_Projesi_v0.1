using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace otel_otomasyonu
{
    class giris
    {
       database db = new database();
        public string kullaniciAdi_tut { get; set; }
        public string kullaniciSifre_tut { get; set; }
       

        public string girisDurumu { get; set; }


        public void girisYap(string kullanıcı_adi, string kullanıcı_sifre, DateTime tarih)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            
            try
            {
                db.baglanti.Open();
                SqlCommand loginName = new SqlCommand("select kullanıcı_adi from login where kullanıcı_adi=@kulAdi", db.baglanti);
                loginName.Parameters.AddWithValue("@kulAdi", kullanıcı_adi);
                SqlDataReader kulAdi_Oku = loginName.ExecuteReader();
                if (kulAdi_Oku.Read())
                {
                    kullaniciAdi_tut = kulAdi_Oku["kullanıcı_adi"].ToString();
                    SqlCommand loginPw = new SqlCommand("select kullanıcı_sifre from login where kullanıcı_sifre = @sifre", db.baglanti);
                    loginPw.Parameters.AddWithValue("@sifre", kullanıcı_sifre);
                    SqlDataReader loginPw_Oku = loginPw.ExecuteReader();
                    if (loginPw_Oku.Read())
                    {
                        kullaniciSifre_tut = loginPw_Oku["kullanıcı_sifre"].ToString();

                        girisDurumu = kullaniciAdi_tut + kullaniciSifre_tut;
                        SqlCommand dateUpdate = new SqlCommand("update login set giris_tarihi=@tarih where kullanıcı_adi = @kuladi AND kullanıcı_sifre = @kulsifre", db.baglanti);
                        dateUpdate.Parameters.AddWithValue("@tarih", tarih);
                        dateUpdate.Parameters.AddWithValue("@kuladi", kullaniciAdi_tut);
                        dateUpdate.Parameters.AddWithValue("@kulsifre", kullaniciSifre_tut);
                        dateUpdate.ExecuteNonQuery();
                        dateUpdate.Dispose();
                    }

                    loginPw.Dispose();
                    loginPw_Oku.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adını yanlış girdin..", "Hata | Otel otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loginName.Dispose();
                kulAdi_Oku.Close();
                db.baglanti.Close();

            }
            catch { }
            finally
            {
                db.baglanti.Close();
            }
        }
        }
    }

