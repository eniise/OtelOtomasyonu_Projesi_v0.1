using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otel_otomasyonu.Kafeterya_Siniflar
{
    public class KasaRaporList
    {
        private string Rapor;
        private string Tarih;
        public KasaRaporList(string Rapor,string Tarih)
        {
            setRapor(Rapor); setTarih(Tarih);
        }
        public string getRapor()
        {
            return this.Rapor;
        }
        public string getTarih()
        {
            return this.Tarih;
        }
        public void setTarih(string Tarih)
        {
            this.Tarih = Tarih;
        }
        public void setRapor(string Rapor)
        {
            this.Rapor = Rapor;
        }
    }
}
